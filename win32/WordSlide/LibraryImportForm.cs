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

namespace WordSlide
{
    public partial class LibraryImportForm : Form
    {
        private string[] libraryContents;

        public LibraryImportForm()
        {
            InitializeComponent();
        }

        public void PopulateLibraryContentsListBox(string[] sets)
        {
            libraryContents = sets;
            Array.Sort<string>(libraryContents);
            for (int x = 0; x < libraryContents.Length; x++)
            {
                libraryContentsListBox.Items.Add(libraryContents[x], true);
            }
            libraryImportLabel.Text = String.Format(Resources.LibraryImportLabel, libraryContents.Length);
        }

        public string[] GetSelectedSets()
        {
            ArrayList ret = new ArrayList();
            foreach (string s in libraryContentsListBox.CheckedItems)
            {
                ret.Add(s);
            }
            return (string[])ret.ToArray(typeof(string));
        }

        private void LibraryImportForm_Load(object sender, EventArgs e)
        {
            this.Text = Resources.LibraryImportForm;
            libraryImportPromptLabel.Text = Resources.LibraryImportPrompt;
            allButton.Text = Resources.AllButton;
            noneButton.Text = Resources.NoneButton;
            okButton.Text = Resources.OkButton;
            cancelButton.Text = Resources.CancelButton;
        }

        private void allButton_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < libraryContentsListBox.Items.Count; x++)
            {
                libraryContentsListBox.SetItemChecked(x, true);
            }
        }

        private void noneButton_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < libraryContentsListBox.Items.Count; x++)
            {
                libraryContentsListBox.SetItemChecked(x, false);
            }
        }
    }
}
