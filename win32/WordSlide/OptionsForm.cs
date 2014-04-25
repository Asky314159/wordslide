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
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using WordSlideEngine;

namespace WordSlide
{
    partial class OptionsForm : Form
    {
        private WordSlideEngine.Font textFont;
        private WordSlideEngine.Font titleFont;
        private WordSlideEngine.Font bylineFont;
        private WordSlideEngine.Font dotFont;
        private Color textColor;
        private Color backColor;
        private Keys[] keyList;
        private KeyChangeForm keyChangeForm;
        private LibraryImportForm libraryImportForm;
        private DateTime lastUpdated;
        private Engine engine;

        public OptionsForm(Engine wordslideEngine)
        {
            InitializeComponent();
            engine = wordslideEngine;
            loadSettings();
            updateLibraryList();
            checkExistingBackup();
            keyChangeForm = new KeyChangeForm();
        }

        private void loadSettings()
        {
            autoUpdateCheckBox.Checked = engine.Options.AutoUpdate;
            titleFont = engine.Options.TitleFont;
            textFont = engine.Options.TextFont;
            bylineFont = engine.Options.BylineFont;
            dotFont = engine.Options.DotFont;
            backColor = Color.FromArgb(engine.Options.BackgroundColor);
            textColor = Color.FromArgb(engine.Options.TextColor);
            songEndString.Text = engine.Options.SongEnd;
            showEndString.Text = engine.Options.ShowEnd;
            defaultAlign.Checked = (engine.Options.TextStart == Options.TextStartDefault);
            topAlign.Checked = !defaultAlign.Checked;
            keyList = new Keys[11];
            keyList[0] = (Keys)Enum.Parse(typeof(Keys), engine.Options.ExitKey, true);
            keyList[1] = (Keys)Enum.Parse(typeof(Keys), engine.Options.ForwardKey, true);
            keyList[2] = (Keys)Enum.Parse(typeof(Keys), engine.Options.BackwardKey, true);
            keyList[3] = (Keys)Enum.Parse(typeof(Keys), engine.Options.BlankKey, true);
            keyList[4] = (Keys)Enum.Parse(typeof(Keys), engine.Options.ChorusKey, true);
            keyList[5] = (Keys)Enum.Parse(typeof(Keys), engine.Options.SongForwardKey, true);
            keyList[6] = (Keys)Enum.Parse(typeof(Keys), engine.Options.SongBackwardKey, true);
            keyList[7] = (Keys)Enum.Parse(typeof(Keys), engine.Options.VerseForwardKey, true);
            keyList[8] = (Keys)Enum.Parse(typeof(Keys), engine.Options.VerseBackwardKey, true);
            keyList[9] = (Keys)Enum.Parse(typeof(Keys), engine.Options.HelpKey, true);
            keyList[10] = (Keys)Enum.Parse(typeof(Keys), engine.Options.TestKey, true);
            exitBox.Text = keyList[0].ToString();
            forwardSlideBox.Text = keyList[1].ToString();
            backwardSlideBox.Text = keyList[2].ToString();
            blankBox.Text = keyList[3].ToString();
            chorusBox.Text = keyList[4].ToString();
            forwardSongBox.Text = keyList[5].ToString();
            backwardSongBox.Text = keyList[6].ToString();
            forwardVerseBox.Text = keyList[7].ToString();
            backwardVerseBox.Text = keyList[8].ToString();
            helpBox.Text = keyList[9].ToString();
            testBox.Text = keyList[10].ToString();
            autoBackupCheckBox.Checked = engine.Options.AutoBackup;
            intervalBox.SelectedIndex = engine.Options.BackupInterval;
            intervalBox.Enabled = autoBackupCheckBox.Checked;
            checkExistingBackup();
        }

        private void saveSettings()
        {
            engine.Options.AutoUpdate = autoUpdateCheckBox.Checked;
            engine.Options.TitleFont = titleFont;
            engine.Options.TextFont = textFont;
            engine.Options.BylineFont = bylineFont;
            engine.Options.DotFont = dotFont;
            engine.Options.BackgroundColor = backColor.ToArgb();
            engine.Options.TextColor = textColor.ToArgb();
            engine.Options.SongEnd = songEndString.Text;
            engine.Options.ShowEnd = showEndString.Text;
            if (defaultAlign.Checked)
            {
                engine.Options.TextStart = Options.TextStartDefault;
                engine.Options.TitleStart = Options.TitleStartDefault;
                engine.Options.TitleTextSpace = Options.TitleTextSpaceDefault;
            }
            else
            {
                engine.Options.TextStart = Options.TextStartTop;
                engine.Options.TitleStart = Options.TitleStartTop;
                engine.Options.TitleTextSpace = Options.TitleTextSpaceTop;
            }
            engine.Options.ExitKey = keyList[0].ToString();
            engine.Options.ForwardKey = keyList[1].ToString();
            engine.Options.BackwardKey = keyList[2].ToString();
            engine.Options.BlankKey = keyList[3].ToString();
            engine.Options.ChorusKey = keyList[4].ToString();
            engine.Options.SongForwardKey = keyList[5].ToString();
            engine.Options.SongBackwardKey = keyList[6].ToString();
            engine.Options.VerseForwardKey = keyList[7].ToString();
            engine.Options.VerseBackwardKey = keyList[8].ToString();
            engine.Options.HelpKey = keyList[9].ToString();
            engine.Options.TestKey = keyList[10].ToString();
            engine.Options.AutoBackup = autoBackupCheckBox.Checked;
            engine.Options.BackupInterval = intervalBox.SelectedIndex;
            engine.Options.saveFile();
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = backColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                backColor = colorDialog.Color;
            }
        }

        private void textButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = textColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textColor = colorDialog.Color;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            saveSettings();
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            saveSettings();
            //applyButton.Enabled = false;
        }

        private void titleFontButton_Click(object sender, EventArgs e)
        {
            fontDialog.Font = new System.Drawing.Font(titleFont.family, titleFont.size);
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                titleFont = new WordSlideEngine.Font { family = fontDialog.Font.FontFamily.Name, size = (int)fontDialog.Font.Size };
            }
        }

        private void textFontButton_Click(object sender, EventArgs e)
        {
            fontDialog.Font = new System.Drawing.Font(textFont.family, textFont.size);
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                textFont = new WordSlideEngine.Font { family = fontDialog.Font.FontFamily.Name, size = (int)fontDialog.Font.Size };
            }
        }

        private void bylineFontButton_Click(object sender, EventArgs e)
        {
            fontDialog.Font = new System.Drawing.Font(bylineFont.family, bylineFont.size);
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                bylineFont = new WordSlideEngine.Font { family = fontDialog.Font.FontFamily.Name, size = (int)fontDialog.Font.Size };
            }
        }

        private void dotFontButton_Click(object sender, EventArgs e)
        {
            fontDialog.Font = new System.Drawing.Font(dotFont.family, dotFont.size);
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                dotFont = new WordSlideEngine.Font { family = fontDialog.Font.FontFamily.Name, size = (int)fontDialog.Font.Size };
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdaterForm updaterForm = new UpdaterForm(engine);
            updaterForm.checkForUpdate();
            if (updaterForm.ShowDialog() == DialogResult.Yes)
            {
                DialogResult = DialogResult.Abort;
                Close();
            }
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            loadSettings();
            updateLibraryList();
        }

        private void exitBox_Click(object sender, EventArgs e)
        {
            keyChangeForm.ShowDialog();
            keyList[0] = keyChangeForm.newKey;
            exitBox.Text = keyList[0].ToString();
        }

        private void forwardSlideBox_Click(object sender, EventArgs e)
        {
            keyChangeForm.ShowDialog();
            keyList[1] = keyChangeForm.newKey;
            forwardSlideBox.Text = keyList[1].ToString();
        }

        private void backwardSlideBox_Click(object sender, EventArgs e)
        {
            keyChangeForm.ShowDialog();
            keyList[2] = keyChangeForm.newKey;
            backwardSlideBox.Text = keyList[2].ToString();
        }

        private void blankBox_Click(object sender, EventArgs e)
        {
            keyChangeForm.ShowDialog();
            keyList[3] = keyChangeForm.newKey;
            blankBox.Text = keyList[3].ToString();
        }

        private void chorusBox_Click(object sender, EventArgs e)
        {
            keyChangeForm.ShowDialog();
            keyList[4] = keyChangeForm.newKey;
            chorusBox.Text = keyList[4].ToString();
        }

        private void forwardSongBox_Click(object sender, EventArgs e)
        {
            keyChangeForm.ShowDialog();
            keyList[5] = keyChangeForm.newKey;
            forwardSongBox.Text = keyList[5].ToString();
        }

        private void backwardSongBox_Click(object sender, EventArgs e)
        {
            keyChangeForm.ShowDialog();
            keyList[6] = keyChangeForm.newKey;
            backwardSongBox.Text = keyList[6].ToString();
        }

        private void forwardVerseBox_Click(object sender, EventArgs e)
        {
            keyChangeForm.ShowDialog();
            keyList[7] = keyChangeForm.newKey;
            forwardVerseBox.Text = keyList[7].ToString();
        }

        private void backwardVerseBox_Click(object sender, EventArgs e)
        {
            keyChangeForm.ShowDialog();
            keyList[8] = keyChangeForm.newKey;
            backwardVerseBox.Text = keyList[8].ToString();
        }

        private void helpBox_Click(object sender, EventArgs e)
        {
            keyChangeForm.ShowDialog();
            keyList[9] = keyChangeForm.newKey;
            helpBox.Text = keyList[9].ToString();
        }

        private void testBox_Click(object sender, EventArgs e)
        {
            keyChangeForm.ShowDialog();
            keyList[10] = keyChangeForm.newKey;
            testBox.Text = keyList[10].ToString();
        }

        private void updateLibraryList()
        {
            string[] list = Library.getCurrentLibraryList();
            libraryListBox.Items.Clear();
            for (int x = 0; x < list.Length; x++)
            {
                libraryListBox.Items.Add(list[x]);
            }
            updateCount();
        }

        private void updateCount()
        {
            libraryCountLabel.Text = String.Format(Resources.LibraryCountLabel, libraryListBox.Items.Count);
        }

        private void allButton_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < libraryListBox.Items.Count; x++)
            {
                libraryListBox.SetItemChecked(x, true);
            }
        }

        private void noneButton_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < libraryListBox.Items.Count; x++)
            {
                libraryListBox.SetItemChecked(x, false);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (libraryListBox.CheckedItems.Count > 0)
            {
                string prompt = "Are you sure you want to delete ";
                if (libraryListBox.CheckedItems.Count == 1)
                {
                    prompt += libraryListBox.CheckedItems[0].ToString();
                }
                else
                {
                    prompt += libraryListBox.CheckedItems.Count + " items";
                }
                prompt += "?";
                if (MessageBox.Show(prompt, "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    for (int x = 0; x < libraryListBox.CheckedItems.Count; x++)
                    {
                        Library.removeFromLibrary((string)libraryListBox.CheckedItems[x]);
                        File.Delete(EditableSlideSet.getNewPath((string)libraryListBox.CheckedItems[x]));
                    }
                    updateLibraryList();
                }
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                importLibrary(openFileDialog.FileName);
            }
        }

        public void importLibrary(string fileName)
        {
            try
            {
                libraryImportForm = new LibraryImportForm();
                libraryImportForm.PopulateLibraryContentsListBox(Library.ReadLibraryContents(fileName));
                if (libraryImportForm.ShowDialog() == DialogResult.OK)
                {
                    Library.ImportSetsFromLibrary(fileName, libraryImportForm.GetSelectedSets());
                    updateLibraryList();
                }
            }
            catch (Exception e)
            {
                //Program.ReportError(e);
                MessageBox.Show(String.Format(Resources.InvalidFileError, Path.GetFileName(fileName)), Resources.InvalidFileTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (libraryListBox.CheckedIndices.Count != 0)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] files = new string[libraryListBox.CheckedItems.Count];
                    for (int x = 0; x < libraryListBox.CheckedItems.Count; x++)
                    {
                        files[x] = EditableSlideSet.getNewPath((string)libraryListBox.CheckedItems[x]);
                    }
                    Library.ExportLibrary(saveFileDialog.FileName, files);
                    updateLibraryList();
                }
            }
            else
            {
                MessageBox.Show("You must select at least one song to export.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkExistingBackup()
        {
            if (!File.Exists(Path.Combine(Engine.DataDirectory, "backup.sll")))
            {
                backupAgeLabel.Text = "Last backup saved: Never";
                restoreButton.Enabled = false;
                if (engine.Options.AutoBackup)
                {
                    saveBackup();
                }
            }
            else
            {
                restoreButton.Enabled = true;
                updateTimeLabel();
                if (engine.Options.AutoBackup)
                {
                    TimeSpan ts = DateTime.Now - lastUpdated;
                    switch (intervalBox.SelectedIndex)
                    {
                        case 0: if (ts.Days > 0)
                            {
                                saveBackup();
                            }
                            break;
                        case 1: if (ts.Days > 6)
                            {
                                saveBackup();
                            }
                            break;
                        case 2: if (ts.Days > 30)
                            {
                                saveBackup();
                            }
                            break;
                    }
                }
            }
        }

        private void saveBackup()
        {
            Library.ExportLibrary(Path.Combine(Engine.DataDirectory, "backup.sll"), Directory.GetFiles(Engine.SlideDirectory, "*.sld"));
            updateTimeLabel();
            restoreButton.Enabled = true;
        }

        private void updateTimeLabel()
        {
            lastUpdated = File.GetLastWriteTime(Path.Combine(Engine.DataDirectory, "backup.sll"));
            backupAgeLabel.Text = "Last backup saved: " + lastUpdated.ToString();
        }

        private void autoBackupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            intervalBox.Enabled = autoBackupCheckBox.Checked;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveBackup();
        }

        private void restoreButton_Click(object sender, EventArgs e)
        {
            Library.ImportLibrary(Path.Combine(Engine.DataDirectory, "backup.sll"));
        }
    }
}