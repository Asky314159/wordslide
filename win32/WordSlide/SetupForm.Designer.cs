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
    partial class SetupForm
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
            this.allSlides = new System.Windows.Forms.ListBox();
            this.selectedSlides = new System.Windows.Forms.ListBox();
            this.addSlides = new System.Windows.Forms.Button();
            this.removeSlides = new System.Windows.Forms.Button();
            this.reorderUp = new System.Windows.Forms.Button();
            this.reorderDown = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.addblankButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // allSlides
            // 
            this.allSlides.FormattingEnabled = true;
            this.allSlides.Location = new System.Drawing.Point(12, 38);
            this.allSlides.Name = "allSlides";
            this.allSlides.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.allSlides.Size = new System.Drawing.Size(184, 134);
            this.allSlides.TabIndex = 11;
            this.allSlides.KeyDown += new System.Windows.Forms.KeyEventHandler(this.allSlides_KeyDown);
            this.allSlides.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.allSlides_DoubleClick);
            this.allSlides.MouseDown += new System.Windows.Forms.MouseEventHandler(this.allSlides_MouseDown);
            // 
            // selectedSlides
            // 
            this.selectedSlides.AllowDrop = true;
            this.selectedSlides.FormattingEnabled = true;
            this.selectedSlides.Location = new System.Drawing.Point(268, 12);
            this.selectedSlides.Name = "selectedSlides";
            this.selectedSlides.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.selectedSlides.Size = new System.Drawing.Size(184, 160);
            this.selectedSlides.TabIndex = 1;
            this.selectedSlides.DragDrop += new System.Windows.Forms.DragEventHandler(this.selectedSlides_DragDrop);
            this.selectedSlides.DragEnter += new System.Windows.Forms.DragEventHandler(this.selectedSlides_DragEnter);
            this.selectedSlides.MouseDown += new System.Windows.Forms.MouseEventHandler(this.selectedSlides_MouseDown);
            // 
            // addSlides
            // 
            this.addSlides.Location = new System.Drawing.Point(212, 12);
            this.addSlides.Name = "addSlides";
            this.addSlides.Size = new System.Drawing.Size(38, 23);
            this.addSlides.TabIndex = 2;
            this.addSlides.Text = "->";
            this.addSlides.UseVisualStyleBackColor = true;
            this.addSlides.Click += new System.EventHandler(this.addSlides_Click);
            // 
            // removeSlides
            // 
            this.removeSlides.Location = new System.Drawing.Point(212, 41);
            this.removeSlides.Name = "removeSlides";
            this.removeSlides.Size = new System.Drawing.Size(38, 23);
            this.removeSlides.TabIndex = 3;
            this.removeSlides.Text = "<-";
            this.removeSlides.UseVisualStyleBackColor = true;
            this.removeSlides.Click += new System.EventHandler(this.removeSlides_Click);
            // 
            // reorderUp
            // 
            this.reorderUp.Location = new System.Drawing.Point(458, 41);
            this.reorderUp.Name = "reorderUp";
            this.reorderUp.Size = new System.Drawing.Size(42, 23);
            this.reorderUp.TabIndex = 4;
            this.reorderUp.Text = "/\\";
            this.reorderUp.UseVisualStyleBackColor = true;
            this.reorderUp.Click += new System.EventHandler(this.reorderUp_Click);
            // 
            // reorderDown
            // 
            this.reorderDown.Location = new System.Drawing.Point(458, 70);
            this.reorderDown.Name = "reorderDown";
            this.reorderDown.Size = new System.Drawing.Size(42, 23);
            this.reorderDown.TabIndex = 5;
            this.reorderDown.Text = "\\/";
            this.reorderDown.UseVisualStyleBackColor = true;
            this.reorderDown.Click += new System.EventHandler(this.reorderDown_Click);
            // 
            // acceptButton
            // 
            this.acceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptButton.Location = new System.Drawing.Point(295, 178);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 6;
            this.acceptButton.Text = "OK";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(377, 178);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 7;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // addblankButton
            // 
            this.addblankButton.Location = new System.Drawing.Point(183, 178);
            this.addblankButton.Name = "addblankButton";
            this.addblankButton.Size = new System.Drawing.Size(106, 23);
            this.addblankButton.TabIndex = 8;
            this.addblankButton.Text = "Add Blank Slide";
            this.addblankButton.UseVisualStyleBackColor = true;
            this.addblankButton.Click += new System.EventHandler(this.addblankButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(458, 138);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(42, 34);
            this.clearButton.TabIndex = 10;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(12, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(184, 20);
            this.searchBox.TabIndex = 0;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchBox_KeyDown);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 211);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.addblankButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.reorderDown);
            this.Controls.Add(this.reorderUp);
            this.Controls.Add(this.removeSlides);
            this.Controls.Add(this.addSlides);
            this.Controls.Add(this.selectedSlides);
            this.Controls.Add(this.allSlides);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.Text = "Set Up Slides";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox allSlides;
        private System.Windows.Forms.ListBox selectedSlides;
        private System.Windows.Forms.Button addSlides;
        private System.Windows.Forms.Button removeSlides;
        private System.Windows.Forms.Button reorderUp;
        private System.Windows.Forms.Button reorderDown;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button addblankButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.TextBox searchBox;
    }
}