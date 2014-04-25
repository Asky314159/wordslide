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
using WordSlideEngine;

namespace WordSlide
{
    public partial class EditorForm : Form
    {
        private EditorOpenForm open;
        private EditableSlideSet openFile;
        private int chorusindex;
        private List<EditableSlide> slidePool;
        private List<PlaceholderSlide> slideList;

        public EditorForm()
        {
            InitializeComponent();
            open = new EditorOpenForm();
            slidePool = new List<EditableSlide>();
            slideList = new List<PlaceholderSlide>();
            availableSlides.DataSource = slidePool;
            slideOrder.DataSource = slideList;
        }

        private void Save()
        {
            if (openFile.Name != titleBox.Text)
            {
                Library.removeFromLibrary(openFile.Name);
            }
            openFile.Name = titleBox.Text;
            openFile.Byline = bylineBox.Text;
            openFile.Copyright = copyrightBox.Text;
            openFile.LinesPerSlide = Decimal.ToInt32(linesPerSlide.Value);
            openFile.Chorus = -1;
            openFile.setupTexts(slidePool.Count, slideList.Count);
            for (int x = 0; x < slidePool.Count; x++)
            {
                EditableSlide temp = slidePool[x];
                openFile.addText(temp.Index, temp.Text, temp.LinesPerSlide);
                if (temp.Chorus) openFile.Chorus = temp.Index;
            }
            for (int x = 0; x < slideList.Count; x++)
            {
                PlaceholderSlide temp = slideList[x];
                openFile.addOrder(x, temp.Index);
            }
            openFile.Write();
            Library.addToLibrary(openFile.Name);
        }

        private void openbutton_Click(object sender, EventArgs e)
        {
            if (open.ShowDialog() == DialogResult.OK)
            {
                openFile = open.selectedSet;
                openFile.loadFile();
                populate();
                saveToolStripMenuItem.Enabled = false;
            }
        }

        private void enableCommonControls()
        {
            titleBox.Enabled = true;
            bylineBox.Enabled = true;
            copyrightBox.Enabled = true;
            linesPerSlide.Enabled = true;
            cButton.Enabled = true;
            createSlide.Enabled = true;
            slideOrder.Enabled = true;
            availableSlides.Enabled = true;
            defaultLinesCheckBox.Enabled = true;
        }

        private void populate()
        {
            enableCommonControls();
            titleBox.Text = openFile.Name;
            bylineBox.Text = openFile.Byline;
            copyrightBox.Text = openFile.Copyright;
            linesPerSlide.Value = openFile.LinesPerSlide;
            slidePool.Clear();
            slideList.Clear();
            for (int x = 0; x < openFile.Texts.Length; x++)
            {
                slidePool.Add(new EditableSlide(x, openFile.Texts[x], openFile.Chorus == x, openFile.Chorus != -1, openFile.LocalLinesPerSlide[x]));
            }
            for (int x = 0; x < openFile.Order.Length; x++)
            {
                slideList.Add(new PlaceholderSlide(openFile.Order[x], openFile.Chorus == openFile.Order[x], openFile.Chorus != -1));
            }
            chorusindex = openFile.Chorus;
            refreshLists();
            updateSlideTextBox();
            updateSlideOrderButtons();
            updateLocalLinesPerSlide();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem.Enabled = false;
            Save();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            enableCommonControls();
            chorusindex = -1;
            openFile = new EditableSlideSet();
            titleBox.Text = "";
            bylineBox.Text = "";
            copyrightBox.Text = "";
            slideContents.Text = "";
            availableSlides.SelectedIndex = -1;
            slideOrder.SelectedIndex = -1;
            slidePool.Clear();
            slideList.Clear();
            refreshLists();
            checkSaveButton();
        }

        private void EditorForm_Load(object sender, EventArgs e)
        {

        }

        private void EditorForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (saveToolStripMenuItem.Enabled)
            {
                switch (MessageBox.Show("Any unsaved changes will be lost. Do you want to save now?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    case DialogResult.Yes: Save();
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel: e.Cancel = true;
                        break;
                }
            }
        }

        private void titleBox_TextChanged(object sender, EventArgs e)
        {
            checkSaveButton();
        }

        private void bylineBox_TextChanged(object sender, EventArgs e)
        {
            checkSaveButton();
        }

        private void copyrightBox_TextChanged(object sender, EventArgs e)
        {
            checkSaveButton();
        }

        private void createSlide_Click(object sender, EventArgs e)
        {
            slidePool.Add(new EditableSlide(slidePool.Count, "", false, chorusindex != -1, 0));
            checkSaveButton();
            refreshLists();
            availableSlides.SelectedIndex = slidePool.Count - 1;
            if (slidePool.Count == 1)
            {
                updateSlideTextBox();
            }
            updateSlideOrderButtons();
            updateAvailableSlidesButtons();
        }

        private void destroySlide_Click(object sender, EventArgs e)
        {
            int index = availableSlides.SelectedIndex;
            if (slidePool[index].Chorus) chorusindex = -1;
            for (int x = 0; x < slideList.Count; x++)
            {
                if (slideList[x].Index == index)
                {
                    slideList.RemoveAt(x);
                }
                else
                {
                    slideList[x].SongHasChorus = (chorusindex != -1);
                }
            }
            slidePool.RemoveAt(index);
            for (int x = 0; x < slidePool.Count; x++)
            {
                if (slidePool[x].Index != x)
                {
                    int oldindex = slidePool[x].Index;
                    slidePool[x].Index = x;
                    slidePool[x].SongHasChorus = (chorusindex != -1);
                    for (int y = 0; y < slideList.Count; y++)
                    {
                        if (slideList[x].Index == oldindex)
                        {
                            slideList[x].Index = x;
                        }
                    }
                }
            }
            removeSlides.Enabled = (slideList.Count > 0);
            reorderUp.Enabled = (slideList.Count > 0);
            reorderDown.Enabled = (slideList.Count > 0);
            checkSaveButton();
            refreshLists();
            availableSlides.SelectedIndex = ((index < slidePool.Count) ? index : index - 1);
            updateSlideOrderButtons();
            updateAvailableSlidesButtons();
        }

        private void updateAvailableSlidesButtons()
        {
            destroySlide.Enabled = (slidePool.Count > 0);
            chorusButton.Enabled = (slidePool.Count > 0);
        }

        private void availableSlides_DoubleClick(object sender, MouseEventArgs e)
        {
            addSlides_Click(sender, e);
        }

        private void addSlides_Click(object sender, EventArgs e)
        {
            if (availableSlides.SelectedIndex < 0) return;
            EditableSlide temp = slidePool[availableSlides.SelectedIndex];
            slideList.Add(new PlaceholderSlide(temp.Index, temp.Chorus, (chorusindex != -1)));
            checkSaveButton();
            refreshLists();
            updateSlideOrderButtons();
        }

        private void removeSlides_Click(object sender, EventArgs e)
        {
            //int index = slideOrder.SelectedIndex;
            for (int x = slideOrder.SelectedIndices.Count - 1; x >= 0; x--)
            {
                slideList.RemoveAt(slideOrder.SelectedIndices[x]);
            }
            checkSaveButton();
            refreshLists();
            //slideOrder.SelectedIndex = ((index < slideList.Count) ? index : index - 1);
            updateSlideOrderButtons();
        }

        private void reorderUp_Click(object sender, EventArgs e)
        {
            bool[] toSelect = new bool[slideList.Count];
            for (int x = 0; x < slideList.Count; x++)
            {
                toSelect[x] = false;
                if (slideOrder.GetSelected(x))
                {
                    int index = x;
                    if (index > 0)
                    {
                        PlaceholderSlide selected = slideList[index];
                        slideList.RemoveAt(index);
                        slideList.Insert(index - 1, selected);
                        toSelect[index - 1] = true;
                    }
                    else
                    {
                        toSelect[index] = true;
                    }
                }
            }
            checkSaveButton();
            refreshLists();
            updateSelection(toSelect);
        }

        private void reorderDown_Click(object sender, EventArgs e)
        {
            bool[] toSelect = new bool[slideList.Count];
            for (int x = slideList.Count - 1; x >= 0; x--)
            {
                toSelect[x] = false;
                if (slideOrder.GetSelected(x))
                {
                    int index = x;
                    if (index < slideList.Count - 1)
                    {
                        PlaceholderSlide selected = slideList[index];
                        slideList.RemoveAt(index);
                        slideList.Insert(index + 1, selected);
                        toSelect[index + 1] = true;
                    }
                    else
                    {
                        toSelect[index] = true;
                    }
                }
            }
            checkSaveButton();
            refreshLists();
            updateSelection(toSelect);
        }

        private void availableSlides_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (availableSlides.SelectedIndex == -1)
            {
                slideContents.Enabled = false;
                destroySlide.Enabled = false;
                chorusButton.Enabled = false;
            }
            else
            {
                updateSlideTextBox();
                updateLocalLinesPerSlide();
            }
        }

        private void updateSlideTextBox()
        {
            slideContents.Text = slidePool[availableSlides.SelectedIndex].Text;
            slideContents.Enabled = true;
            destroySlide.Enabled = true;
            chorusButton.Enabled = (chorusindex == -1);
        }

        private void updateLocalLinesPerSlide()
        {
            defaultLinesCheckBox.Text = String.Format(WordSlide.Resources.DefaultLocalLinesPerSlide, slidePool[availableSlides.SelectedIndex].ToString());
            localLinesLabel.Text = String.Format(WordSlide.Resources.LocalLinesPerSlide, slidePool[availableSlides.SelectedIndex].ToString());
            if (slidePool[availableSlides.SelectedIndex].LinesPerSlide == 0)
            {
                localLinesPerSlide.Value = linesPerSlide.Value;
                defaultLinesCheckBox.Checked = true;
            }
            else
            {
                localLinesPerSlide.Value = slidePool[availableSlides.SelectedIndex].LinesPerSlide;
                defaultLinesCheckBox.Checked = false;
            }
        }

        private void slideContents_TextChanged(object sender, EventArgs e)
        {
            slidePool[availableSlides.SelectedIndex].Text = slideContents.Text;
            checkSaveButton();
        }

        private void slideContents_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                slideContents.SuspendLayout();
                int insPt = slideContents.SelectionStart;
                string postRTFContent = slideContents.Text.Substring(insPt);
                slideContents.Text = slideContents.Text.Substring(0, insPt);
                slideContents.Text += (string)Clipboard.GetData("Text") + postRTFContent;
                slideContents.SelectionStart = slideContents.TextLength - postRTFContent.Length;
                slideContents.ResumeLayout();
                e.Handled = true;
            }
        }

        private void slideOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void updateSlideOrderButtons()
        {
            addSlides.Enabled = (availableSlides.SelectedIndex != -1);
            removeSlides.Enabled = (slideOrder.SelectedIndices.Count > 0);
            reorderUp.Enabled = (slideOrder.SelectedIndices.Count > 0);
            reorderDown.Enabled = (slideOrder.SelectedIndices.Count > 0);
        }

        private void checkSaveButton()
        {
            saveToolStripMenuItem.Enabled = (slidePool.Count > 0 && slideList.Count > 0 && titleBox.Text.Trim().Length > 0);
        }

        private void chorusButton_Click(object sender, EventArgs e)
        {
            EditableSlide temp = slidePool[availableSlides.SelectedIndex];
            slidePool.RemoveAt(availableSlides.SelectedIndex);
            temp.Chorus = true;
            for (int x = 0; x < slideList.Count; x++)
            {
                slideList[x].SongHasChorus = true;
                if (slideList[x].Index == temp.Index)
                {
                    slideList[x].Index = 0;
                    slideList[x].Chorus = true;
                }
                else if (slideList[x].Index < temp.Index)
                {
                    slideList[x].Index++;
                }
            }
            temp.Index = 0;
            slidePool.Insert(0, temp);
            for (int x = 0; x < slidePool.Count; x++)
            {
                slidePool[x].Index = x;
                slidePool[x].SongHasChorus = true;
            }
            refreshLists();
            availableSlides.SelectedIndex = 0;
            chorusindex = temp.Index;
            chorusButton.Enabled = false;
            checkSaveButton();
        }

        private void linesPerSlide_ValueChanged(object sender, EventArgs e)
        {
            checkSaveButton();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            ImportForm imp = new ImportForm();
            if (imp.ShowDialog() == DialogResult.OK)
            {
                openFile = Importer.ImportedSlideSet;
                populate();
                checkSaveButton();
            }
        }

        private void cButton_Click(object sender, EventArgs e)
        {
            copyrightBox.Text += "©";
        }

        private void refreshLists()
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[slidePool];
            cm.Refresh();
            cm = (CurrencyManager)BindingContext[slideList];
            cm.Refresh();
        }

        private void updateSelection(bool[] toSelect)
        {
            for (int x = 0; x < toSelect.Length; x++)
            {
                slideOrder.SetSelected(x, toSelect[x]);
            }
        }

        private void defaultLinesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            localLinesPerSlide.Enabled = !defaultLinesCheckBox.Checked;
            localLinesLabel.Enabled = !defaultLinesCheckBox.Checked;
            if (defaultLinesCheckBox.Checked && slidePool[availableSlides.SelectedIndex].LinesPerSlide != 0)
            {
                localLinesPerSlide.Value = linesPerSlide.Value;
                slidePool[availableSlides.SelectedIndex].LinesPerSlide = 0;
            }
            if (!defaultLinesCheckBox.Checked && slidePool[availableSlides.SelectedIndex].LinesPerSlide == 0)
            {
                localLinesPerSlide.Value = linesPerSlide.Value;
                slidePool[availableSlides.SelectedIndex].LinesPerSlide = Decimal.ToInt32(localLinesPerSlide.Value);
            }
        }

        private void localLinesPerSlide_ValueChanged(object sender, EventArgs e)
        {
            slidePool[availableSlides.SelectedIndex].LinesPerSlide = Decimal.ToInt32(localLinesPerSlide.Value);
            checkSaveButton();
        }
    }
}