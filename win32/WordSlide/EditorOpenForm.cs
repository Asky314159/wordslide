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
    public partial class EditorOpenForm : Form
    {
        private List<string> slidePool;
        private List<string> limitedPool;

        public EditableSlideSet selectedSet
        {
            get
            {
                if (openButton.Enabled)
                {
                    return new EditableSlideSet(EditableSlideSet.getNewPath(limitedPool[slidesList.SelectedIndex]));
                }
                else
                {
                    return null;
                }
            }
        }

        public EditorOpenForm()
        {
            InitializeComponent();
            slidePool = new List<string>();
            limitedPool = new List<string>();
            slidesList.DataSource = limitedPool;
        }

        private void EditorOpenForm_Shown(object sender, EventArgs e)
        {
            slidePool.Clear();
            string[] slides = Library.getCurrentLibraryList();
            for (int x = 0; x < slides.Length; x++)
            {
                slidePool.Add(slides[x]);
            }
            fillLimitedPool();
            refreshLists();
            checkOpenButton();
        }

        private void slidesList_DoubleClick(object sender, MouseEventArgs e)
        {
            if (slidesList.SelectedItem != null)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
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
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            fillLimitedPool();
            refreshLists();
            checkOpenButton();
        }

        private void checkOpenButton()
        {
            openButton.Enabled = (limitedPool.Count > 0 && slidesList.SelectedIndex >= 0);
        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            if (e.KeyCode == Keys.Up)
            {
                if (slidesList.SelectedIndex > 0)
                {
                    int index = slidesList.SelectedIndices[0] - 1;
                    slidesList.SelectedIndices.Clear();
                    slidesList.SelectedIndices.Add(index);
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (slidesList.SelectedIndex < slidePool.Count - 1)
                {
                    int index = slidesList.SelectedIndices[0] + 1;
                    slidesList.SelectedIndices.Clear();
                    slidesList.SelectedIndices.Add(index);
                }
            }
        }
    }
}