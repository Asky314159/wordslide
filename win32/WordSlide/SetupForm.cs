//WordSlide
//Copyright (C) 2008-2012 Jonathan Ray <asky314159@gmail.com>

//WordSlide is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//A copy of the GNU General Public License should be in the
//Installer directory of this source tree. If not, see
//<http://www.gnu.org/licenses/>.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WordSlideEngine;

namespace WordSlide
{
    public partial class SetupForm : Form
    {
        private List<string> slidePool;
        private List<string> limitedPool;
        private List<string> slideOrder;

        public DisplaySlideSet[] selectedslideslist
        {
            get
            {
                DisplaySlideSet[] ret = new DisplaySlideSet[slideOrder.Count];
                for (int x = 0; x < ret.Length; x++)
                {
                    if (((string)slideOrder[x]) == "<Blank Slide>")
                    {
                        ret[x] = new DisplaySlideSet();
                    }
                    else
                    {
                        ret[x] = new DisplaySlideSet(EditableSlideSet.getNewPath((string)slideOrder[x]));
                    }
                }
                return ret;
            }
        }

        public SetupForm()
        {
            InitializeComponent();
            slidePool = new List<string>();
            limitedPool = new List<string>();
            slideOrder = new List<string>();
            allSlides.DataSource = limitedPool;
            selectedSlides.DataSource = slideOrder;
            acceptButton.Enabled = false;
        }

        private void SetupForm_Load(object sender, EventArgs e)
        {
            /*if (Program.isRunningOnMono())
            {
                this.Height += 30;
                this.Width += 3;
            }*/
            string[] slides = Library.getCurrentLibraryList();
            Array.Sort(slides);
            slidePool.AddRange(slides);
            loadLastTime();
            /*for (int x = 0; x < Screen.AllScreens.Length; x++)
                screenSelect.Items.Add("Screen " + (x + 1));
            screenSelect.SelectedIndex = 0;
            if (Screen.AllScreens.Length == 1)
                screenSelect.Visible = false;*/
            fillLimitedPool();
            refreshLists();
            checkButtons();
        }

        private void allSlides_DoubleClick(object sender, MouseEventArgs e)
        {
            addSlides_Click(sender, e);
        }

        private void addSlides_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < allSlides.SelectedIndices.Count; x++)
            {
                slideOrder.Add(limitedPool[allSlides.SelectedIndices[x]]);
            }
            refreshLists();
            checkButtons();
        }

        private void removeSlides_Click(object sender, EventArgs e)
        {
            //Have to move backwards through the list because the indices change when removeAt is called,
            //and the selectedIndices array does not update accordingly.
            for (int x = selectedSlides.SelectedIndices.Count - 1; x >= 0; x--)
            {
                slideOrder.RemoveAt(selectedSlides.SelectedIndices[x]);
            }
            refreshLists();
            checkButtons();
        }

        private void reorderUp_Click(object sender, EventArgs e)
        {
            bool[] toSelect = new bool[slideOrder.Count];
            for (int x = 0; x < slideOrder.Count; x++)
            {
                toSelect[x] = false;
                if (selectedSlides.GetSelected(x))
                {
                    int index = x;
                    if (index > 0)
                    {
                        string selected = slideOrder[index];
                        slideOrder.RemoveAt(index);
                        slideOrder.Insert(index - 1, selected);
                        toSelect[index - 1] = true;
                    }
                    else
                    {
                        toSelect[index] = true;
                    }
                }
            }
            refreshLists();
            updateSelection(toSelect);
        }

        private void reorderDown_Click(object sender, EventArgs e)
        {
            bool[] toSelect = new bool[slideOrder.Count];
            for (int x = slideOrder.Count - 1; x >= 0; x--)
            {
                toSelect[x] = false;
                if (selectedSlides.GetSelected(x))
                {
                    int index = x;
                    if (index < selectedSlides.Items.Count - 1)
                    {
                        string selected = slideOrder[index];
                        slideOrder.RemoveAt(index);
                        slideOrder.Insert(index + 1, selected);
                        toSelect[index + 1] = true;
                    }
                    else
                    {
                        toSelect[index] = true;
                    }
                }
            }
            refreshLists();
            updateSelection(toSelect);
        }

        private void addblankButton_Click(object sender, EventArgs e)
        {
            slideOrder.Insert(selectedSlides.SelectedIndex + 1, "<Blank Slide>");
            refreshLists();
            checkButtons();
        }

        private void loadLastTime()
        {
            if (File.Exists(Path.Combine(Engine.DataDirectory, "lastshow.o")))
            {
                BinaryReader reader = new BinaryReader(new FileStream(Path.Combine(Engine.DataDirectory, "lastshow.o"), FileMode.Open));
                byte count = reader.ReadByte();
                for (int x = 0; x < count; x++)
                {
                    string temp = reader.ReadString();
                    if (temp.Equals("<Blank Slide>"))
                    {
                        slideOrder.Add(temp);
                    }
                    else
                    {
                        for (int y = 0; y < slidePool.Count; y++)
                        {
                            if (temp.Equals(slidePool[y].ToString()))
                            {
                                slideOrder.Add(temp);
                                break;
                            }
                        }
                    }
                }
                reader.Close();
            }
        }

        private void saveLastTime()
        {
            BinaryWriter writer = new BinaryWriter(new FileStream(Path.Combine(Engine.DataDirectory, "lastshow.o"), FileMode.Create));
            writer.Write((byte)slideOrder.Count);
            for (int x = 0; x < slideOrder.Count; x++)
            {
                writer.Write(slideOrder[x]);
            }
            writer.Close();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            saveLastTime();
            this.Close();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            slideOrder.Clear();
            refreshLists();
            checkButtons();
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            fillLimitedPool();
            refreshLists();
            checkButtons();
        }

        private void fillLimitedPool()
        {
            limitedPool.Clear();
            if (searchBox.Text == "")
            {
                for (int x = 0; x < slidePool.Count; x++)
                {
                    limitedPool.Add(slidePool[x]);
                }
            }
            else
            {
                string searchstring = searchBox.Text.ToLower();
                for (int x = 0; x < slidePool.Count; x++)
                {
                    string title = slidePool[x];
                    StringBuilder newtitle = new StringBuilder();
                    for (int y = 0; y < title.Length; y++)
                    {
                        if (Char.IsPunctuation(title[y]))
                        {
                        }
                        else if (Char.IsUpper(title[y]))
                        {
                            newtitle.Append(Char.ToLower(title[y]));
                        }
                        else
                        {
                            newtitle.Append(title[y]);
                        }
                    }
                    if (newtitle.ToString().Contains(searchstring))
                    {
                        limitedPool.Add(slidePool[x]);
                    }
                }
            }
        }

        private void refreshLists()
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[limitedPool];
            cm.Refresh();
            cm = (CurrencyManager)BindingContext[slideOrder];
            cm.Refresh();
        }

        private void checkButtons()
        {
            acceptButton.Enabled = (slideOrder.Count > 0);
            addSlides.Enabled = (limitedPool.Count > 0);
            removeSlides.Enabled = (slideOrder.Count > 0);
            reorderUp.Enabled = (slideOrder.Count > 0);
            reorderDown.Enabled = (slideOrder.Count > 0);
        }

        private void updateSelection(bool[] toSelect)
        {
            for (int x = 0; x < toSelect.Length; x++)
            {
                selectedSlides.SetSelected(x, toSelect[x]);
            }
        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addSlides_Click(sender, e);
            }
            if (e.KeyCode == Keys.Up)
            {
                if (allSlides.SelectedIndex > 0)
                {
                    int index = allSlides.SelectedIndices[0] - 1;
                    allSlides.SelectedIndices.Clear();
                    allSlides.SelectedIndices.Add(index);
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (allSlides.SelectedIndex < slidePool.Count - 1)
                {
                    int index = allSlides.SelectedIndices[0] + 1;
                    allSlides.SelectedIndices.Clear();
                    allSlides.SelectedIndices.Add(index);
                }
            }
        }

        private void selectedSlides_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void selectedSlides_DragEnter(object sender, DragEventArgs e)
        {
        }

        private void selectedSlides_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void allSlides_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void allSlides_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addSlides_Click(sender, e);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}