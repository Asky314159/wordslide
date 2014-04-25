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

namespace WordSlide
{
    partial class OptionsForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.applyButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.updateButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.libraryTab = new System.Windows.Forms.TabPage();
            this.intervalBox = new System.Windows.Forms.ComboBox();
            this.backupAgeLabel = new System.Windows.Forms.Label();
            this.restoreButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.autoBackupCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.noneButton = new System.Windows.Forms.Button();
            this.allButton = new System.Windows.Forms.Button();
            this.libraryCountLabel = new System.Windows.Forms.Label();
            this.libraryListBox = new System.Windows.Forms.CheckedListBox();
            this.keyTab = new System.Windows.Forms.TabPage();
            this.testLabel = new System.Windows.Forms.Label();
            this.testBox = new System.Windows.Forms.TextBox();
            this.keysLabel = new System.Windows.Forms.Label();
            this.helpBox = new System.Windows.Forms.TextBox();
            this.backwardVerseBox = new System.Windows.Forms.TextBox();
            this.forwardVerseBox = new System.Windows.Forms.TextBox();
            this.backwardSongBox = new System.Windows.Forms.TextBox();
            this.forwardSongBox = new System.Windows.Forms.TextBox();
            this.chorusBox = new System.Windows.Forms.TextBox();
            this.blankBox = new System.Windows.Forms.TextBox();
            this.backwardSlideBox = new System.Windows.Forms.TextBox();
            this.forwardSlideBox = new System.Windows.Forms.TextBox();
            this.exitBox = new System.Windows.Forms.TextBox();
            this.helpLabel = new System.Windows.Forms.Label();
            this.backwardVerseLabel = new System.Windows.Forms.Label();
            this.forwardVerseLabel = new System.Windows.Forms.Label();
            this.backwardSongLabel = new System.Windows.Forms.Label();
            this.forwardSongLabel = new System.Windows.Forms.Label();
            this.chorusLabel = new System.Windows.Forms.Label();
            this.blankLabel = new System.Windows.Forms.Label();
            this.backwardSlideLabel = new System.Windows.Forms.Label();
            this.forwardSlideLabel = new System.Windows.Forms.Label();
            this.exitLabel = new System.Windows.Forms.Label();
            this.appearanceTab = new System.Windows.Forms.TabPage();
            this.autoUpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.colorGroupBox = new System.Windows.Forms.GroupBox();
            this.backgroundButton = new System.Windows.Forms.Button();
            this.textButton = new System.Windows.Forms.Button();
            this.fontGroupBox = new System.Windows.Forms.GroupBox();
            this.titleFontButton = new System.Windows.Forms.Button();
            this.textFontButton = new System.Windows.Forms.Button();
            this.bylineFontButton = new System.Windows.Forms.Button();
            this.dotFontButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.showEndString = new System.Windows.Forms.TextBox();
            this.songEndString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.alignGroupBox = new System.Windows.Forms.GroupBox();
            this.defaultAlign = new System.Windows.Forms.RadioButton();
            this.topAlign = new System.Windows.Forms.RadioButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.libraryTab.SuspendLayout();
            this.keyTab.SuspendLayout();
            this.appearanceTab.SuspendLayout();
            this.colorGroupBox.SuspendLayout();
            this.fontGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.alignGroupBox.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(398, 234);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 6;
            this.applyButton.Text = "Apply";
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(318, 234);
            this.okButton.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(237, 234);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // fontDialog
            // 
            this.fontDialog.ScriptsOnly = true;
            this.fontDialog.ShowEffects = false;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(12, 234);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(117, 23);
            this.updateButton.TabIndex = 17;
            this.updateButton.Text = "Check for updates";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "SLL files|*.sll";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "sll";
            this.saveFileDialog.Filter = "SLL Files|*.sll";
            // 
            // libraryTab
            // 
            this.libraryTab.Controls.Add(this.intervalBox);
            this.libraryTab.Controls.Add(this.backupAgeLabel);
            this.libraryTab.Controls.Add(this.restoreButton);
            this.libraryTab.Controls.Add(this.saveButton);
            this.libraryTab.Controls.Add(this.autoBackupCheckBox);
            this.libraryTab.Controls.Add(this.deleteButton);
            this.libraryTab.Controls.Add(this.exportButton);
            this.libraryTab.Controls.Add(this.importButton);
            this.libraryTab.Controls.Add(this.noneButton);
            this.libraryTab.Controls.Add(this.allButton);
            this.libraryTab.Controls.Add(this.libraryCountLabel);
            this.libraryTab.Controls.Add(this.libraryListBox);
            this.libraryTab.Location = new System.Drawing.Point(4, 22);
            this.libraryTab.Name = "libraryTab";
            this.libraryTab.Size = new System.Drawing.Size(453, 177);
            this.libraryTab.TabIndex = 2;
            this.libraryTab.Text = "Library";
            this.libraryTab.UseVisualStyleBackColor = true;
            // 
            // intervalBox
            // 
            this.intervalBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.intervalBox.FormattingEnabled = true;
            this.intervalBox.Items.AddRange(new object[] {
            "once a day",
            "once a week",
            "once a month"});
            this.intervalBox.Location = new System.Drawing.Point(160, 144);
            this.intervalBox.Name = "intervalBox";
            this.intervalBox.Size = new System.Drawing.Size(93, 21);
            this.intervalBox.TabIndex = 18;
            // 
            // backupAgeLabel
            // 
            this.backupAgeLabel.AutoSize = true;
            this.backupAgeLabel.Location = new System.Drawing.Point(234, 9);
            this.backupAgeLabel.Name = "backupAgeLabel";
            this.backupAgeLabel.Size = new System.Drawing.Size(104, 13);
            this.backupAgeLabel.TabIndex = 17;
            this.backupAgeLabel.Text = "Last backup saved: ";
            // 
            // restoreButton
            // 
            this.restoreButton.Location = new System.Drawing.Point(354, 116);
            this.restoreButton.Name = "restoreButton";
            this.restoreButton.Size = new System.Drawing.Size(93, 23);
            this.restoreButton.TabIndex = 16;
            this.restoreButton.Text = "Restore backup";
            this.restoreButton.UseVisualStyleBackColor = true;
            this.restoreButton.Click += new System.EventHandler(this.restoreButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(255, 116);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(93, 23);
            this.saveButton.TabIndex = 15;
            this.saveButton.Text = "Save backup";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // autoBackupCheckBox
            // 
            this.autoBackupCheckBox.AutoSize = true;
            this.autoBackupCheckBox.Location = new System.Drawing.Point(6, 146);
            this.autoBackupCheckBox.Name = "autoBackupCheckBox";
            this.autoBackupCheckBox.Size = new System.Drawing.Size(153, 17);
            this.autoBackupCheckBox.TabIndex = 14;
            this.autoBackupCheckBox.Text = "Automatically save backup";
            this.autoBackupCheckBox.UseVisualStyleBackColor = true;
            this.autoBackupCheckBox.CheckedChanged += new System.EventHandler(this.autoBackupCheckBox_CheckedChanged);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(354, 29);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(93, 23);
            this.deleteButton.TabIndex = 13;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(354, 87);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(93, 23);
            this.exportButton.TabIndex = 12;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(255, 87);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(93, 23);
            this.importButton.TabIndex = 11;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // noneButton
            // 
            this.noneButton.Location = new System.Drawing.Point(255, 58);
            this.noneButton.Name = "noneButton";
            this.noneButton.Size = new System.Drawing.Size(93, 23);
            this.noneButton.TabIndex = 10;
            this.noneButton.Text = "Select None";
            this.noneButton.UseVisualStyleBackColor = true;
            this.noneButton.Click += new System.EventHandler(this.noneButton_Click);
            // 
            // allButton
            // 
            this.allButton.Location = new System.Drawing.Point(255, 29);
            this.allButton.Name = "allButton";
            this.allButton.Size = new System.Drawing.Size(93, 23);
            this.allButton.TabIndex = 9;
            this.allButton.Text = "Select All";
            this.allButton.UseVisualStyleBackColor = true;
            this.allButton.Click += new System.EventHandler(this.allButton_Click);
            // 
            // libraryCountLabel
            // 
            this.libraryCountLabel.AutoSize = true;
            this.libraryCountLabel.Location = new System.Drawing.Point(3, 9);
            this.libraryCountLabel.Name = "libraryCountLabel";
            this.libraryCountLabel.Size = new System.Drawing.Size(88, 13);
            this.libraryCountLabel.TabIndex = 8;
            this.libraryCountLabel.Text = "libraryCountLabel";
            // 
            // libraryListBox
            // 
            this.libraryListBox.CheckOnClick = true;
            this.libraryListBox.FormattingEnabled = true;
            this.libraryListBox.Location = new System.Drawing.Point(6, 29);
            this.libraryListBox.Name = "libraryListBox";
            this.libraryListBox.Size = new System.Drawing.Size(243, 109);
            this.libraryListBox.TabIndex = 7;
            // 
            // keyTab
            // 
            this.keyTab.Controls.Add(this.testLabel);
            this.keyTab.Controls.Add(this.testBox);
            this.keyTab.Controls.Add(this.keysLabel);
            this.keyTab.Controls.Add(this.helpBox);
            this.keyTab.Controls.Add(this.backwardVerseBox);
            this.keyTab.Controls.Add(this.forwardVerseBox);
            this.keyTab.Controls.Add(this.backwardSongBox);
            this.keyTab.Controls.Add(this.forwardSongBox);
            this.keyTab.Controls.Add(this.chorusBox);
            this.keyTab.Controls.Add(this.blankBox);
            this.keyTab.Controls.Add(this.backwardSlideBox);
            this.keyTab.Controls.Add(this.forwardSlideBox);
            this.keyTab.Controls.Add(this.exitBox);
            this.keyTab.Controls.Add(this.helpLabel);
            this.keyTab.Controls.Add(this.backwardVerseLabel);
            this.keyTab.Controls.Add(this.forwardVerseLabel);
            this.keyTab.Controls.Add(this.backwardSongLabel);
            this.keyTab.Controls.Add(this.forwardSongLabel);
            this.keyTab.Controls.Add(this.chorusLabel);
            this.keyTab.Controls.Add(this.blankLabel);
            this.keyTab.Controls.Add(this.backwardSlideLabel);
            this.keyTab.Controls.Add(this.forwardSlideLabel);
            this.keyTab.Controls.Add(this.exitLabel);
            this.keyTab.Location = new System.Drawing.Point(4, 22);
            this.keyTab.Name = "keyTab";
            this.keyTab.Padding = new System.Windows.Forms.Padding(3);
            this.keyTab.Size = new System.Drawing.Size(453, 190);
            this.keyTab.TabIndex = 1;
            this.keyTab.Text = "Keys";
            this.keyTab.UseVisualStyleBackColor = true;
            // 
            // testLabel
            // 
            this.testLabel.AutoSize = true;
            this.testLabel.Location = new System.Drawing.Point(6, 162);
            this.testLabel.Name = "testLabel";
            this.testLabel.Size = new System.Drawing.Size(58, 13);
            this.testLabel.TabIndex = 39;
            this.testLabel.Text = "Video Test";
            // 
            // testBox
            // 
            this.testBox.Location = new System.Drawing.Point(81, 159);
            this.testBox.Name = "testBox";
            this.testBox.ReadOnly = true;
            this.testBox.Size = new System.Drawing.Size(139, 20);
            this.testBox.TabIndex = 38;
            this.testBox.Click += new System.EventHandler(this.testBox_Click);
            // 
            // keysLabel
            // 
            this.keysLabel.AutoSize = true;
            this.keysLabel.Location = new System.Drawing.Point(4, 9);
            this.keysLabel.Name = "keysLabel";
            this.keysLabel.Size = new System.Drawing.Size(256, 13);
            this.keysLabel.TabIndex = 37;
            this.keysLabel.Text = "Click on the box next to the key you want to change.";
            // 
            // helpBox
            // 
            this.helpBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.helpBox.Location = new System.Drawing.Point(307, 133);
            this.helpBox.Name = "helpBox";
            this.helpBox.ReadOnly = true;
            this.helpBox.Size = new System.Drawing.Size(140, 20);
            this.helpBox.TabIndex = 36;
            this.helpBox.TabStop = false;
            this.helpBox.Click += new System.EventHandler(this.helpBox_Click);
            // 
            // backwardVerseBox
            // 
            this.backwardVerseBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.backwardVerseBox.Location = new System.Drawing.Point(307, 107);
            this.backwardVerseBox.Name = "backwardVerseBox";
            this.backwardVerseBox.ReadOnly = true;
            this.backwardVerseBox.Size = new System.Drawing.Size(140, 20);
            this.backwardVerseBox.TabIndex = 35;
            this.backwardVerseBox.TabStop = false;
            this.backwardVerseBox.Click += new System.EventHandler(this.backwardVerseBox_Click);
            // 
            // forwardVerseBox
            // 
            this.forwardVerseBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.forwardVerseBox.Location = new System.Drawing.Point(307, 81);
            this.forwardVerseBox.Name = "forwardVerseBox";
            this.forwardVerseBox.ReadOnly = true;
            this.forwardVerseBox.Size = new System.Drawing.Size(140, 20);
            this.forwardVerseBox.TabIndex = 34;
            this.forwardVerseBox.TabStop = false;
            this.forwardVerseBox.Click += new System.EventHandler(this.forwardVerseBox_Click);
            // 
            // backwardSongBox
            // 
            this.backwardSongBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.backwardSongBox.Location = new System.Drawing.Point(307, 55);
            this.backwardSongBox.Name = "backwardSongBox";
            this.backwardSongBox.ReadOnly = true;
            this.backwardSongBox.Size = new System.Drawing.Size(140, 20);
            this.backwardSongBox.TabIndex = 33;
            this.backwardSongBox.TabStop = false;
            this.backwardSongBox.Click += new System.EventHandler(this.backwardSongBox_Click);
            // 
            // forwardSongBox
            // 
            this.forwardSongBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.forwardSongBox.Location = new System.Drawing.Point(307, 30);
            this.forwardSongBox.Name = "forwardSongBox";
            this.forwardSongBox.ReadOnly = true;
            this.forwardSongBox.Size = new System.Drawing.Size(140, 20);
            this.forwardSongBox.TabIndex = 32;
            this.forwardSongBox.TabStop = false;
            this.forwardSongBox.Click += new System.EventHandler(this.forwardSongBox_Click);
            // 
            // chorusBox
            // 
            this.chorusBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.chorusBox.Location = new System.Drawing.Point(81, 133);
            this.chorusBox.Name = "chorusBox";
            this.chorusBox.ReadOnly = true;
            this.chorusBox.Size = new System.Drawing.Size(139, 20);
            this.chorusBox.TabIndex = 26;
            this.chorusBox.TabStop = false;
            this.chorusBox.Click += new System.EventHandler(this.chorusBox_Click);
            // 
            // blankBox
            // 
            this.blankBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.blankBox.Location = new System.Drawing.Point(81, 107);
            this.blankBox.Name = "blankBox";
            this.blankBox.ReadOnly = true;
            this.blankBox.Size = new System.Drawing.Size(139, 20);
            this.blankBox.TabIndex = 25;
            this.blankBox.TabStop = false;
            this.blankBox.Click += new System.EventHandler(this.blankBox_Click);
            // 
            // backwardSlideBox
            // 
            this.backwardSlideBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.backwardSlideBox.Location = new System.Drawing.Point(81, 81);
            this.backwardSlideBox.Name = "backwardSlideBox";
            this.backwardSlideBox.ReadOnly = true;
            this.backwardSlideBox.Size = new System.Drawing.Size(139, 20);
            this.backwardSlideBox.TabIndex = 24;
            this.backwardSlideBox.TabStop = false;
            this.backwardSlideBox.Click += new System.EventHandler(this.backwardSlideBox_Click);
            // 
            // forwardSlideBox
            // 
            this.forwardSlideBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.forwardSlideBox.Location = new System.Drawing.Point(81, 56);
            this.forwardSlideBox.Name = "forwardSlideBox";
            this.forwardSlideBox.ReadOnly = true;
            this.forwardSlideBox.Size = new System.Drawing.Size(139, 20);
            this.forwardSlideBox.TabIndex = 23;
            this.forwardSlideBox.TabStop = false;
            this.forwardSlideBox.Click += new System.EventHandler(this.forwardSlideBox_Click);
            // 
            // exitBox
            // 
            this.exitBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.exitBox.Location = new System.Drawing.Point(81, 30);
            this.exitBox.Name = "exitBox";
            this.exitBox.ReadOnly = true;
            this.exitBox.Size = new System.Drawing.Size(139, 20);
            this.exitBox.TabIndex = 22;
            this.exitBox.TabStop = false;
            this.exitBox.Click += new System.EventHandler(this.exitBox_Click);
            // 
            // helpLabel
            // 
            this.helpLabel.AutoSize = true;
            this.helpLabel.Location = new System.Drawing.Point(226, 136);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(29, 13);
            this.helpLabel.TabIndex = 31;
            this.helpLabel.Text = "Help";
            // 
            // backwardVerseLabel
            // 
            this.backwardVerseLabel.AutoSize = true;
            this.backwardVerseLabel.Location = new System.Drawing.Point(226, 111);
            this.backwardVerseLabel.Name = "backwardVerseLabel";
            this.backwardVerseLabel.Size = new System.Drawing.Size(62, 13);
            this.backwardVerseLabel.TabIndex = 30;
            this.backwardVerseLabel.Text = "Back Verse";
            // 
            // forwardVerseLabel
            // 
            this.forwardVerseLabel.AutoSize = true;
            this.forwardVerseLabel.Location = new System.Drawing.Point(226, 85);
            this.forwardVerseLabel.Name = "forwardVerseLabel";
            this.forwardVerseLabel.Size = new System.Drawing.Size(75, 13);
            this.forwardVerseLabel.TabIndex = 29;
            this.forwardVerseLabel.Text = "Forward Verse";
            // 
            // backwardSongLabel
            // 
            this.backwardSongLabel.AutoSize = true;
            this.backwardSongLabel.Location = new System.Drawing.Point(226, 59);
            this.backwardSongLabel.Name = "backwardSongLabel";
            this.backwardSongLabel.Size = new System.Drawing.Size(60, 13);
            this.backwardSongLabel.TabIndex = 28;
            this.backwardSongLabel.Text = "Back Song";
            // 
            // forwardSongLabel
            // 
            this.forwardSongLabel.AutoSize = true;
            this.forwardSongLabel.Location = new System.Drawing.Point(226, 33);
            this.forwardSongLabel.Name = "forwardSongLabel";
            this.forwardSongLabel.Size = new System.Drawing.Size(73, 13);
            this.forwardSongLabel.TabIndex = 27;
            this.forwardSongLabel.Text = "Forward Song";
            // 
            // chorusLabel
            // 
            this.chorusLabel.AutoSize = true;
            this.chorusLabel.Location = new System.Drawing.Point(4, 136);
            this.chorusLabel.Name = "chorusLabel";
            this.chorusLabel.Size = new System.Drawing.Size(40, 13);
            this.chorusLabel.TabIndex = 21;
            this.chorusLabel.Text = "Chorus";
            // 
            // blankLabel
            // 
            this.blankLabel.AutoSize = true;
            this.blankLabel.Location = new System.Drawing.Point(4, 110);
            this.blankLabel.Name = "blankLabel";
            this.blankLabel.Size = new System.Drawing.Size(34, 13);
            this.blankLabel.TabIndex = 20;
            this.blankLabel.Text = "Blank";
            // 
            // backwardSlideLabel
            // 
            this.backwardSlideLabel.AutoSize = true;
            this.backwardSlideLabel.Location = new System.Drawing.Point(4, 84);
            this.backwardSlideLabel.Name = "backwardSlideLabel";
            this.backwardSlideLabel.Size = new System.Drawing.Size(58, 13);
            this.backwardSlideLabel.TabIndex = 19;
            this.backwardSlideLabel.Text = "Back Slide";
            // 
            // forwardSlideLabel
            // 
            this.forwardSlideLabel.AutoSize = true;
            this.forwardSlideLabel.Location = new System.Drawing.Point(4, 59);
            this.forwardSlideLabel.Name = "forwardSlideLabel";
            this.forwardSlideLabel.Size = new System.Drawing.Size(71, 13);
            this.forwardSlideLabel.TabIndex = 18;
            this.forwardSlideLabel.Text = "Forward Slide";
            // 
            // exitLabel
            // 
            this.exitLabel.AutoSize = true;
            this.exitLabel.Location = new System.Drawing.Point(4, 33);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.Size = new System.Drawing.Size(24, 13);
            this.exitLabel.TabIndex = 17;
            this.exitLabel.Text = "Exit";
            // 
            // appearanceTab
            // 
            this.appearanceTab.Controls.Add(this.autoUpdateCheckBox);
            this.appearanceTab.Controls.Add(this.colorGroupBox);
            this.appearanceTab.Controls.Add(this.fontGroupBox);
            this.appearanceTab.Controls.Add(this.groupBox1);
            this.appearanceTab.Controls.Add(this.alignGroupBox);
            this.appearanceTab.Location = new System.Drawing.Point(4, 22);
            this.appearanceTab.Name = "appearanceTab";
            this.appearanceTab.Padding = new System.Windows.Forms.Padding(3);
            this.appearanceTab.Size = new System.Drawing.Size(453, 177);
            this.appearanceTab.TabIndex = 0;
            this.appearanceTab.Text = "Appearance";
            this.appearanceTab.UseVisualStyleBackColor = true;
            // 
            // autoUpdateCheckBox
            // 
            this.autoUpdateCheckBox.AutoSize = true;
            this.autoUpdateCheckBox.Location = new System.Drawing.Point(236, 150);
            this.autoUpdateCheckBox.Name = "autoUpdateCheckBox";
            this.autoUpdateCheckBox.Size = new System.Drawing.Size(177, 17);
            this.autoUpdateCheckBox.TabIndex = 18;
            this.autoUpdateCheckBox.Text = "Automatically check for updates";
            this.autoUpdateCheckBox.UseVisualStyleBackColor = true;
            // 
            // colorGroupBox
            // 
            this.colorGroupBox.Controls.Add(this.backgroundButton);
            this.colorGroupBox.Controls.Add(this.textButton);
            this.colorGroupBox.Location = new System.Drawing.Point(6, 6);
            this.colorGroupBox.Name = "colorGroupBox";
            this.colorGroupBox.Size = new System.Drawing.Size(218, 82);
            this.colorGroupBox.TabIndex = 23;
            this.colorGroupBox.TabStop = false;
            this.colorGroupBox.Text = "Modify Colors";
            // 
            // backgroundButton
            // 
            this.backgroundButton.Location = new System.Drawing.Point(6, 19);
            this.backgroundButton.Name = "backgroundButton";
            this.backgroundButton.Size = new System.Drawing.Size(206, 23);
            this.backgroundButton.TabIndex = 7;
            this.backgroundButton.Text = "Background";
            this.backgroundButton.UseVisualStyleBackColor = true;
            this.backgroundButton.Click += new System.EventHandler(this.backgroundButton_Click);
            // 
            // textButton
            // 
            this.textButton.Location = new System.Drawing.Point(6, 48);
            this.textButton.Name = "textButton";
            this.textButton.Size = new System.Drawing.Size(206, 23);
            this.textButton.TabIndex = 8;
            this.textButton.Text = "Text";
            this.textButton.UseVisualStyleBackColor = true;
            this.textButton.Click += new System.EventHandler(this.textButton_Click);
            // 
            // fontGroupBox
            // 
            this.fontGroupBox.Controls.Add(this.titleFontButton);
            this.fontGroupBox.Controls.Add(this.textFontButton);
            this.fontGroupBox.Controls.Add(this.bylineFontButton);
            this.fontGroupBox.Controls.Add(this.dotFontButton);
            this.fontGroupBox.Location = new System.Drawing.Point(230, 6);
            this.fontGroupBox.Name = "fontGroupBox";
            this.fontGroupBox.Size = new System.Drawing.Size(217, 82);
            this.fontGroupBox.TabIndex = 21;
            this.fontGroupBox.TabStop = false;
            this.fontGroupBox.Text = "Modify Fonts";
            // 
            // titleFontButton
            // 
            this.titleFontButton.Location = new System.Drawing.Point(6, 19);
            this.titleFontButton.Name = "titleFontButton";
            this.titleFontButton.Size = new System.Drawing.Size(100, 23);
            this.titleFontButton.TabIndex = 9;
            this.titleFontButton.Text = "Title";
            this.titleFontButton.UseVisualStyleBackColor = true;
            this.titleFontButton.Click += new System.EventHandler(this.titleFontButton_Click);
            // 
            // textFontButton
            // 
            this.textFontButton.Location = new System.Drawing.Point(112, 19);
            this.textFontButton.Name = "textFontButton";
            this.textFontButton.Size = new System.Drawing.Size(99, 23);
            this.textFontButton.TabIndex = 10;
            this.textFontButton.Text = "Text";
            this.textFontButton.UseVisualStyleBackColor = true;
            this.textFontButton.Click += new System.EventHandler(this.textFontButton_Click);
            // 
            // bylineFontButton
            // 
            this.bylineFontButton.Location = new System.Drawing.Point(6, 48);
            this.bylineFontButton.Name = "bylineFontButton";
            this.bylineFontButton.Size = new System.Drawing.Size(100, 23);
            this.bylineFontButton.TabIndex = 11;
            this.bylineFontButton.Text = "Byline";
            this.bylineFontButton.UseVisualStyleBackColor = true;
            this.bylineFontButton.Click += new System.EventHandler(this.bylineFontButton_Click);
            // 
            // dotFontButton
            // 
            this.dotFontButton.Location = new System.Drawing.Point(112, 48);
            this.dotFontButton.Name = "dotFontButton";
            this.dotFontButton.Size = new System.Drawing.Size(99, 23);
            this.dotFontButton.TabIndex = 12;
            this.dotFontButton.Text = "Dot";
            this.dotFontButton.UseVisualStyleBackColor = true;
            this.dotFontButton.Click += new System.EventHandler(this.dotFontButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.showEndString);
            this.groupBox1.Controls.Add(this.songEndString);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 73);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Strings";
            // 
            // showEndString
            // 
            this.showEndString.Location = new System.Drawing.Point(80, 45);
            this.showEndString.Name = "showEndString";
            this.showEndString.Size = new System.Drawing.Size(132, 20);
            this.showEndString.TabIndex = 14;
            // 
            // songEndString
            // 
            this.songEndString.Location = new System.Drawing.Point(80, 16);
            this.songEndString.Name = "songEndString";
            this.songEndString.Size = new System.Drawing.Size(132, 20);
            this.songEndString.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "End of song";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "End of show";
            // 
            // alignGroupBox
            // 
            this.alignGroupBox.Controls.Add(this.defaultAlign);
            this.alignGroupBox.Controls.Add(this.topAlign);
            this.alignGroupBox.Location = new System.Drawing.Point(230, 94);
            this.alignGroupBox.Name = "alignGroupBox";
            this.alignGroupBox.Size = new System.Drawing.Size(217, 50);
            this.alignGroupBox.TabIndex = 22;
            this.alignGroupBox.TabStop = false;
            this.alignGroupBox.Text = "Text Align";
            // 
            // defaultAlign
            // 
            this.defaultAlign.AutoSize = true;
            this.defaultAlign.Location = new System.Drawing.Point(6, 19);
            this.defaultAlign.Name = "defaultAlign";
            this.defaultAlign.Size = new System.Drawing.Size(85, 17);
            this.defaultAlign.TabIndex = 19;
            this.defaultAlign.TabStop = true;
            this.defaultAlign.Text = "Default Align";
            this.defaultAlign.UseVisualStyleBackColor = true;
            // 
            // topAlign
            // 
            this.topAlign.AutoSize = true;
            this.topAlign.Location = new System.Drawing.Point(112, 19);
            this.topAlign.Name = "topAlign";
            this.topAlign.Size = new System.Drawing.Size(70, 17);
            this.topAlign.TabIndex = 20;
            this.topAlign.TabStop = true;
            this.topAlign.Text = "Top Align";
            this.topAlign.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.appearanceTab);
            this.tabControl.Controls.Add(this.keyTab);
            this.tabControl.Controls.Add(this.libraryTab);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(461, 216);
            this.tabControl.TabIndex = 29;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 265);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.libraryTab.ResumeLayout(false);
            this.libraryTab.PerformLayout();
            this.keyTab.ResumeLayout(false);
            this.keyTab.PerformLayout();
            this.appearanceTab.ResumeLayout(false);
            this.appearanceTab.PerformLayout();
            this.colorGroupBox.ResumeLayout(false);
            this.fontGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.alignGroupBox.ResumeLayout(false);
            this.alignGroupBox.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TabPage libraryTab;
        private System.Windows.Forms.ComboBox intervalBox;
        private System.Windows.Forms.Label backupAgeLabel;
        private System.Windows.Forms.Button restoreButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox autoBackupCheckBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button noneButton;
        private System.Windows.Forms.Button allButton;
        private System.Windows.Forms.Label libraryCountLabel;
        private System.Windows.Forms.CheckedListBox libraryListBox;
        private System.Windows.Forms.TabPage keyTab;
        private System.Windows.Forms.Label keysLabel;
        private System.Windows.Forms.TextBox helpBox;
        private System.Windows.Forms.TextBox backwardVerseBox;
        private System.Windows.Forms.TextBox forwardVerseBox;
        private System.Windows.Forms.TextBox backwardSongBox;
        private System.Windows.Forms.TextBox forwardSongBox;
        private System.Windows.Forms.TextBox chorusBox;
        private System.Windows.Forms.TextBox blankBox;
        private System.Windows.Forms.TextBox backwardSlideBox;
        private System.Windows.Forms.TextBox forwardSlideBox;
        private System.Windows.Forms.TextBox exitBox;
        private System.Windows.Forms.Label helpLabel;
        private System.Windows.Forms.Label backwardVerseLabel;
        private System.Windows.Forms.Label forwardVerseLabel;
        private System.Windows.Forms.Label backwardSongLabel;
        private System.Windows.Forms.Label forwardSongLabel;
        private System.Windows.Forms.Label chorusLabel;
        private System.Windows.Forms.Label blankLabel;
        private System.Windows.Forms.Label backwardSlideLabel;
        private System.Windows.Forms.Label forwardSlideLabel;
        private System.Windows.Forms.Label exitLabel;
        private System.Windows.Forms.TabPage appearanceTab;
        private System.Windows.Forms.CheckBox autoUpdateCheckBox;
        private System.Windows.Forms.GroupBox colorGroupBox;
        private System.Windows.Forms.Button backgroundButton;
        private System.Windows.Forms.Button textButton;
        private System.Windows.Forms.GroupBox fontGroupBox;
        private System.Windows.Forms.Button titleFontButton;
        private System.Windows.Forms.Button textFontButton;
        private System.Windows.Forms.Button bylineFontButton;
        private System.Windows.Forms.Button dotFontButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox showEndString;
        private System.Windows.Forms.TextBox songEndString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox alignGroupBox;
        private System.Windows.Forms.RadioButton defaultAlign;
        private System.Windows.Forms.RadioButton topAlign;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Label testLabel;
        private System.Windows.Forms.TextBox testBox;
    }
}