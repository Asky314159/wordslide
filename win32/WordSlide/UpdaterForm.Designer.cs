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
    partial class UpdaterForm
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
            this.currentLabel = new System.Windows.Forms.Label();
            this.newLabel = new System.Windows.Forms.Label();
            this.messageLabel1 = new System.Windows.Forms.Label();
            this.yesButton = new System.Windows.Forms.Button();
            this.noButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.skipVersionBox = new System.Windows.Forms.CheckBox();
            this.messageLabel2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // currentLabel
            // 
            this.currentLabel.AutoSize = true;
            this.currentLabel.Location = new System.Drawing.Point(12, 9);
            this.currentLabel.Name = "currentLabel";
            this.currentLabel.Size = new System.Drawing.Size(81, 13);
            this.currentLabel.TabIndex = 0;
            this.currentLabel.Text = "Current version:";
            // 
            // newLabel
            // 
            this.newLabel.AutoSize = true;
            this.newLabel.Location = new System.Drawing.Point(182, 9);
            this.newLabel.Name = "newLabel";
            this.newLabel.Size = new System.Drawing.Size(77, 13);
            this.newLabel.TabIndex = 1;
            this.newLabel.Text = "Latest Version:";
            // 
            // messageLabel1
            // 
            this.messageLabel1.AutoSize = true;
            this.messageLabel1.Location = new System.Drawing.Point(12, 27);
            this.messageLabel1.Name = "messageLabel1";
            this.messageLabel1.Size = new System.Drawing.Size(50, 13);
            this.messageLabel1.TabIndex = 2;
            this.messageLabel1.Text = "Message";
            // 
            // yesButton
            // 
            this.yesButton.Location = new System.Drawing.Point(236, 88);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(73, 23);
            this.yesButton.TabIndex = 3;
            this.yesButton.Text = "Yes";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Visible = false;
            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            // 
            // noButton
            // 
            this.noButton.Location = new System.Drawing.Point(315, 88);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(73, 23);
            this.noButton.TabIndex = 4;
            this.noButton.Text = "Close";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 59);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(373, 23);
            this.progressBar.TabIndex = 5;
            // 
            // skipVersionBox
            // 
            this.skipVersionBox.AutoSize = true;
            this.skipVersionBox.Location = new System.Drawing.Point(15, 92);
            this.skipVersionBox.Name = "skipVersionBox";
            this.skipVersionBox.Size = new System.Drawing.Size(212, 17);
            this.skipVersionBox.TabIndex = 6;
            this.skipVersionBox.Text = "Do not ask me about this update again.";
            this.skipVersionBox.UseVisualStyleBackColor = true;
            // 
            // messageLabel2
            // 
            this.messageLabel2.AutoSize = true;
            this.messageLabel2.Location = new System.Drawing.Point(12, 41);
            this.messageLabel2.Name = "messageLabel2";
            this.messageLabel2.Size = new System.Drawing.Size(50, 13);
            this.messageLabel2.TabIndex = 7;
            this.messageLabel2.Text = "Message";
            // 
            // UpdaterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 122);
            this.Controls.Add(this.messageLabel2);
            this.Controls.Add(this.skipVersionBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.messageLabel1);
            this.Controls.Add(this.newLabel);
            this.Controls.Add(this.currentLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdaterForm";
            this.Text = "Check for updates";
            this.Load += new System.EventHandler(this.UpdaterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label currentLabel;
        private System.Windows.Forms.Label newLabel;
        private System.Windows.Forms.Label messageLabel1;
        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.CheckBox skipVersionBox;
        private System.Windows.Forms.Label messageLabel2;
    }
}