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
    partial class EditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.bylineLabel = new System.Windows.Forms.Label();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.bylineBox = new System.Windows.Forms.TextBox();
            this.availableSlides = new System.Windows.Forms.ListBox();
            this.slideOrder = new System.Windows.Forms.ListBox();
            this.addSlides = new System.Windows.Forms.Button();
            this.removeSlides = new System.Windows.Forms.Button();
            this.reorderUp = new System.Windows.Forms.Button();
            this.reorderDown = new System.Windows.Forms.Button();
            this.createSlide = new System.Windows.Forms.Button();
            this.destroySlide = new System.Windows.Forms.Button();
            this.chorusButton = new System.Windows.Forms.Button();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.copyrightBox = new System.Windows.Forms.TextBox();
            this.linesPerSlide = new System.Windows.Forms.NumericUpDown();
            this.linesLabel = new System.Windows.Forms.Label();
            this.cButton = new System.Windows.Forms.Button();
            this.defaultLinesCheckBox = new System.Windows.Forms.CheckBox();
            this.localLinesPerSlide = new System.Windows.Forms.NumericUpDown();
            this.localLinesLabel = new System.Windows.Forms.Label();
            this.slideContents = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.linesPerSlide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localLinesPerSlide)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(12, 39);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(27, 13);
            this.titleLabel.TabIndex = 16;
            this.titleLabel.Text = "Title";
            // 
            // bylineLabel
            // 
            this.bylineLabel.AutoSize = true;
            this.bylineLabel.Location = new System.Drawing.Point(12, 66);
            this.bylineLabel.Name = "bylineLabel";
            this.bylineLabel.Size = new System.Drawing.Size(35, 13);
            this.bylineLabel.TabIndex = 17;
            this.bylineLabel.Text = "Byline";
            // 
            // titleBox
            // 
            this.titleBox.Enabled = false;
            this.titleBox.Location = new System.Drawing.Point(70, 37);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(562, 20);
            this.titleBox.TabIndex = 0;
            this.titleBox.TextChanged += new System.EventHandler(this.titleBox_TextChanged);
            // 
            // bylineBox
            // 
            this.bylineBox.Enabled = false;
            this.bylineBox.Location = new System.Drawing.Point(70, 63);
            this.bylineBox.Name = "bylineBox";
            this.bylineBox.Size = new System.Drawing.Size(562, 20);
            this.bylineBox.TabIndex = 1;
            this.bylineBox.TextChanged += new System.EventHandler(this.bylineBox_TextChanged);
            // 
            // availableSlides
            // 
            this.availableSlides.Enabled = false;
            this.availableSlides.FormattingEnabled = true;
            this.availableSlides.Location = new System.Drawing.Point(230, 170);
            this.availableSlides.Name = "availableSlides";
            this.availableSlides.Size = new System.Drawing.Size(151, 121);
            this.availableSlides.TabIndex = 14;
            this.availableSlides.SelectedIndexChanged += new System.EventHandler(this.availableSlides_SelectedIndexChanged);
            this.availableSlides.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.availableSlides_DoubleClick);
            // 
            // slideOrder
            // 
            this.slideOrder.Enabled = false;
            this.slideOrder.FormattingEnabled = true;
            this.slideOrder.Location = new System.Drawing.Point(431, 170);
            this.slideOrder.Name = "slideOrder";
            this.slideOrder.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.slideOrder.Size = new System.Drawing.Size(157, 121);
            this.slideOrder.TabIndex = 15;
            this.slideOrder.SelectedIndexChanged += new System.EventHandler(this.slideOrder_SelectedIndexChanged);
            // 
            // addSlides
            // 
            this.addSlides.Enabled = false;
            this.addSlides.Location = new System.Drawing.Point(387, 170);
            this.addSlides.Name = "addSlides";
            this.addSlides.Size = new System.Drawing.Size(38, 23);
            this.addSlides.TabIndex = 8;
            this.addSlides.Text = "->";
            this.addSlides.UseVisualStyleBackColor = true;
            this.addSlides.Click += new System.EventHandler(this.addSlides_Click);
            // 
            // removeSlides
            // 
            this.removeSlides.Enabled = false;
            this.removeSlides.Location = new System.Drawing.Point(387, 199);
            this.removeSlides.Name = "removeSlides";
            this.removeSlides.Size = new System.Drawing.Size(38, 23);
            this.removeSlides.TabIndex = 9;
            this.removeSlides.Text = "<-";
            this.removeSlides.UseVisualStyleBackColor = true;
            this.removeSlides.Click += new System.EventHandler(this.removeSlides_Click);
            // 
            // reorderUp
            // 
            this.reorderUp.Enabled = false;
            this.reorderUp.Location = new System.Drawing.Point(594, 199);
            this.reorderUp.Name = "reorderUp";
            this.reorderUp.Size = new System.Drawing.Size(38, 23);
            this.reorderUp.TabIndex = 10;
            this.reorderUp.Text = "/\\";
            this.reorderUp.UseVisualStyleBackColor = true;
            this.reorderUp.Click += new System.EventHandler(this.reorderUp_Click);
            // 
            // reorderDown
            // 
            this.reorderDown.Enabled = false;
            this.reorderDown.Location = new System.Drawing.Point(594, 228);
            this.reorderDown.Name = "reorderDown";
            this.reorderDown.Size = new System.Drawing.Size(38, 23);
            this.reorderDown.TabIndex = 11;
            this.reorderDown.Text = "\\/";
            this.reorderDown.UseVisualStyleBackColor = true;
            this.reorderDown.Click += new System.EventHandler(this.reorderDown_Click);
            // 
            // createSlide
            // 
            this.createSlide.Enabled = false;
            this.createSlide.Location = new System.Drawing.Point(230, 141);
            this.createSlide.Name = "createSlide";
            this.createSlide.Size = new System.Drawing.Size(73, 23);
            this.createSlide.TabIndex = 3;
            this.createSlide.Text = "Create";
            this.createSlide.UseVisualStyleBackColor = true;
            this.createSlide.Click += new System.EventHandler(this.createSlide_Click);
            // 
            // destroySlide
            // 
            this.destroySlide.Enabled = false;
            this.destroySlide.Location = new System.Drawing.Point(309, 141);
            this.destroySlide.Name = "destroySlide";
            this.destroySlide.Size = new System.Drawing.Size(72, 23);
            this.destroySlide.TabIndex = 4;
            this.destroySlide.Text = "Delete";
            this.destroySlide.UseVisualStyleBackColor = true;
            this.destroySlide.Click += new System.EventHandler(this.destroySlide_Click);
            // 
            // chorusButton
            // 
            this.chorusButton.Enabled = false;
            this.chorusButton.Location = new System.Drawing.Point(16, 141);
            this.chorusButton.Name = "chorusButton";
            this.chorusButton.Size = new System.Drawing.Size(112, 23);
            this.chorusButton.TabIndex = 12;
            this.chorusButton.Text = "Set as Chorus";
            this.chorusButton.UseVisualStyleBackColor = true;
            this.chorusButton.Click += new System.EventHandler(this.chorusButton_Click);
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.Location = new System.Drawing.Point(13, 92);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(51, 13);
            this.copyrightLabel.TabIndex = 18;
            this.copyrightLabel.Text = "Copyright";
            // 
            // copyrightBox
            // 
            this.copyrightBox.Enabled = false;
            this.copyrightBox.Location = new System.Drawing.Point(70, 89);
            this.copyrightBox.Name = "copyrightBox";
            this.copyrightBox.Size = new System.Drawing.Size(481, 20);
            this.copyrightBox.TabIndex = 2;
            this.copyrightBox.TextChanged += new System.EventHandler(this.copyrightBox_TextChanged);
            // 
            // linesPerSlide
            // 
            this.linesPerSlide.Enabled = false;
            this.linesPerSlide.Location = new System.Drawing.Point(96, 115);
            this.linesPerSlide.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.linesPerSlide.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.linesPerSlide.Name = "linesPerSlide";
            this.linesPerSlide.Size = new System.Drawing.Size(47, 20);
            this.linesPerSlide.TabIndex = 19;
            this.linesPerSlide.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.linesPerSlide.ValueChanged += new System.EventHandler(this.linesPerSlide_ValueChanged);
            // 
            // linesLabel
            // 
            this.linesLabel.AutoSize = true;
            this.linesLabel.Location = new System.Drawing.Point(13, 117);
            this.linesLabel.Name = "linesLabel";
            this.linesLabel.Size = new System.Drawing.Size(77, 13);
            this.linesLabel.TabIndex = 21;
            this.linesLabel.Text = "Lines Per Slide";
            // 
            // cButton
            // 
            this.cButton.Enabled = false;
            this.cButton.Location = new System.Drawing.Point(557, 87);
            this.cButton.Name = "cButton";
            this.cButton.Size = new System.Drawing.Size(75, 23);
            this.cButton.TabIndex = 22;
            this.cButton.Text = "Insert ©";
            this.cButton.UseVisualStyleBackColor = true;
            this.cButton.Click += new System.EventHandler(this.cButton_Click);
            // 
            // defaultLinesCheckBox
            // 
            this.defaultLinesCheckBox.AutoSize = true;
            this.defaultLinesCheckBox.Checked = true;
            this.defaultLinesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.defaultLinesCheckBox.Enabled = false;
            this.defaultLinesCheckBox.Location = new System.Drawing.Point(387, 121);
            this.defaultLinesCheckBox.Name = "defaultLinesCheckBox";
            this.defaultLinesCheckBox.Size = new System.Drawing.Size(170, 17);
            this.defaultLinesCheckBox.TabIndex = 24;
            this.defaultLinesCheckBox.Text = "Use Default Lines Per Slide for";
            this.defaultLinesCheckBox.UseVisualStyleBackColor = true;
            this.defaultLinesCheckBox.CheckedChanged += new System.EventHandler(this.defaultLinesCheckBox_CheckedChanged);
            // 
            // localLinesPerSlide
            // 
            this.localLinesPerSlide.Enabled = false;
            this.localLinesPerSlide.Location = new System.Drawing.Point(583, 144);
            this.localLinesPerSlide.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.localLinesPerSlide.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.localLinesPerSlide.Name = "localLinesPerSlide";
            this.localLinesPerSlide.Size = new System.Drawing.Size(47, 20);
            this.localLinesPerSlide.TabIndex = 25;
            this.localLinesPerSlide.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.localLinesPerSlide.ValueChanged += new System.EventHandler(this.localLinesPerSlide_ValueChanged);
            // 
            // localLinesLabel
            // 
            this.localLinesLabel.AutoSize = true;
            this.localLinesLabel.Enabled = false;
            this.localLinesLabel.Location = new System.Drawing.Point(428, 146);
            this.localLinesLabel.Name = "localLinesLabel";
            this.localLinesLabel.Size = new System.Drawing.Size(92, 13);
            this.localLinesLabel.TabIndex = 26;
            this.localLinesLabel.Text = "Lines Per Slide for";
            // 
            // slideContents
            // 
            this.slideContents.Enabled = false;
            this.slideContents.Location = new System.Drawing.Point(16, 170);
            this.slideContents.Multiline = true;
            this.slideContents.Name = "slideContents";
            this.slideContents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.slideContents.Size = new System.Drawing.Size(208, 121);
            this.slideContents.TabIndex = 27;
            this.slideContents.TextChanged += new System.EventHandler(this.slideContents_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.importToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(642, 24);
            this.menuStrip1.TabIndex = 28;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newButton_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openbutton_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importButton_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 308);
            this.Controls.Add(this.slideContents);
            this.Controls.Add(this.localLinesLabel);
            this.Controls.Add(this.localLinesPerSlide);
            this.Controls.Add(this.defaultLinesCheckBox);
            this.Controls.Add(this.cButton);
            this.Controls.Add(this.linesLabel);
            this.Controls.Add(this.linesPerSlide);
            this.Controls.Add(this.copyrightBox);
            this.Controls.Add(this.copyrightLabel);
            this.Controls.Add(this.chorusButton);
            this.Controls.Add(this.destroySlide);
            this.Controls.Add(this.createSlide);
            this.Controls.Add(this.reorderDown);
            this.Controls.Add(this.reorderUp);
            this.Controls.Add(this.removeSlides);
            this.Controls.Add(this.addSlides);
            this.Controls.Add(this.slideOrder);
            this.Controls.Add(this.availableSlides);
            this.Controls.Add(this.bylineBox);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.bylineLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditorForm";
            this.Text = "Slide Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditorForm_Closing);
            this.Load += new System.EventHandler(this.EditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.linesPerSlide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localLinesPerSlide)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label bylineLabel;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.TextBox bylineBox;
        private System.Windows.Forms.ListBox availableSlides;
        private System.Windows.Forms.ListBox slideOrder;
        private System.Windows.Forms.Button addSlides;
        private System.Windows.Forms.Button removeSlides;
        private System.Windows.Forms.Button reorderUp;
        private System.Windows.Forms.Button reorderDown;
        private System.Windows.Forms.Button createSlide;
        private System.Windows.Forms.Button destroySlide;
        private System.Windows.Forms.Button chorusButton;
        private System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.TextBox copyrightBox;
        private System.Windows.Forms.NumericUpDown linesPerSlide;
        private System.Windows.Forms.Label linesLabel;
        private System.Windows.Forms.Button cButton;
        private System.Windows.Forms.CheckBox defaultLinesCheckBox;
        private System.Windows.Forms.NumericUpDown localLinesPerSlide;
        private System.Windows.Forms.Label localLinesLabel;
        private System.Windows.Forms.TextBox slideContents;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;

    }
}