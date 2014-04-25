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
    partial class OverwriteForm
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
            this.yesButton = new System.Windows.Forms.Button();
            this.ytaButton = new System.Windows.Forms.Button();
            this.ntaButton = new System.Windows.Forms.Button();
            this.noButton = new System.Windows.Forms.Button();
            this.warningLabel = new System.Windows.Forms.Label();
            this.warningLabel2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // yesButton
            // 
            this.yesButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.yesButton.Location = new System.Drawing.Point(23, 58);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(75, 23);
            this.yesButton.TabIndex = 0;
            this.yesButton.Text = "Yes";
            this.yesButton.UseVisualStyleBackColor = true;
            // 
            // ytaButton
            // 
            this.ytaButton.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.ytaButton.Location = new System.Drawing.Point(103, 58);
            this.ytaButton.Name = "ytaButton";
            this.ytaButton.Size = new System.Drawing.Size(75, 23);
            this.ytaButton.TabIndex = 1;
            this.ytaButton.Text = "Yes to All";
            this.ytaButton.UseVisualStyleBackColor = true;
            // 
            // ntaButton
            // 
            this.ntaButton.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.ntaButton.Location = new System.Drawing.Point(184, 58);
            this.ntaButton.Name = "ntaButton";
            this.ntaButton.Size = new System.Drawing.Size(75, 23);
            this.ntaButton.TabIndex = 2;
            this.ntaButton.Text = "No to All";
            this.ntaButton.UseVisualStyleBackColor = true;
            // 
            // noButton
            // 
            this.noButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.noButton.Location = new System.Drawing.Point(265, 58);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(75, 23);
            this.noButton.TabIndex = 3;
            this.noButton.Text = "No";
            this.noButton.UseVisualStyleBackColor = true;
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Location = new System.Drawing.Point(20, 9);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(35, 13);
            this.warningLabel.TabIndex = 4;
            this.warningLabel.Text = "label1";
            // 
            // warningLabel2
            // 
            this.warningLabel2.AutoSize = true;
            this.warningLabel2.Location = new System.Drawing.Point(20, 28);
            this.warningLabel2.Name = "warningLabel2";
            this.warningLabel2.Size = new System.Drawing.Size(35, 13);
            this.warningLabel2.TabIndex = 5;
            this.warningLabel2.Text = "label1";
            // 
            // OverwriteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 89);
            this.Controls.Add(this.warningLabel2);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.ntaButton);
            this.Controls.Add(this.ytaButton);
            this.Controls.Add(this.yesButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OverwriteForm";
            this.Text = "Overwrite";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Button ytaButton;
        private System.Windows.Forms.Button ntaButton;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Label warningLabel2;
    }
}