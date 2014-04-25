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

namespace WordSlide
{
    public partial class ImportForm : Form
    {
        private const string webPrompt = "Enter a search term or the url to the page of the song to import.";
        private bool changetext = true;

        public ImportForm()
        {
            InitializeComponent();
        }

        private void sourceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (sourceBox.SelectedIndex)
            {
                default: if (changetext) textBox.Text = webPrompt;
                    textBox.Width = 332;
                    browseButton.Visible = false;
                    break;
                case 2: if (changetext) textBox.Text = "";
                    textBox.Width = 251;
                    browseButton.Visible = true;
                    openFileDialog.Filter = "SLD Files|*.sld";
                    openFileDialog.FileName = "";
                    break;
                case 3: if (changetext) textBox.Text = "";
                    textBox.Width = 251;
                    browseButton.Visible = true;
                    openFileDialog.Filter = "PPT Files|*.ppt";
                    openFileDialog.FileName = "";
                    break;
            }
            changetext = true;
        }

        private void ImportForm_Load(object sender, EventArgs e)
        {
            sourceBox.SelectedIndex = 0;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = openFileDialog.FileName;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            okButton.Enabled = false;
            cancelButton.Enabled = false;
            sourceBox.Enabled = false;
            textBox.Enabled = false;
            browseButton.Enabled = false;

            Importer.ImporterErrorCode success = Importer.ImporterErrorCode.Unset;
            switch (sourceBox.SelectedIndex)
            {
                case 0: success = Importer.importRHO(textBox.Text);
                    break;
                case 1: success = Importer.importCH(textBox.Text);
                    break;
                case 2: success = Importer.importSLD(textBox.Text);
                    break;
                case 3: success = Importer.importPPT(textBox.Text);
                    break;
            }
            switch (success)
            {
                case Importer.ImporterErrorCode.CompletedSucessfully: DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                default: MessageBox.Show("The import failed. Please ensure that the entered data or selected file is valid.", "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Importer.ImporterErrorCode.SearchTermNotFound: MessageBox.Show("The search term could not be found. Try removing leading articles. If it is intended to be a URL, please ensure it ends with the correct extension.", "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            okButton.Enabled = true;
            cancelButton.Enabled = true;
            sourceBox.Enabled = true;
            textBox.Enabled = true;
            browseButton.Enabled = true;
        }

        private void textBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox.SelectionLength < textBox.Text.Length)
                textBox.SelectAll();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (textBox.Text.Contains("igracemusic.com"))
            {
                changetext = false;
                sourceBox.SelectedIndex = 0;
            }
            if (textBox.Text.Contains("cyberhymnal.org"))
            {
                changetext = false;
                sourceBox.SelectedIndex = 1;
            }
        }
    }
}