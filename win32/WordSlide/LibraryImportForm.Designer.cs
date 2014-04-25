namespace WordSlide
{
    partial class LibraryImportForm
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
            this.libraryImportLabel = new System.Windows.Forms.Label();
            this.libraryContentsListBox = new System.Windows.Forms.CheckedListBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.allButton = new System.Windows.Forms.Button();
            this.noneButton = new System.Windows.Forms.Button();
            this.libraryImportPromptLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // libraryImportLabel
            // 
            this.libraryImportLabel.AutoSize = true;
            this.libraryImportLabel.Location = new System.Drawing.Point(12, 9);
            this.libraryImportLabel.Name = "libraryImportLabel";
            this.libraryImportLabel.Size = new System.Drawing.Size(89, 13);
            this.libraryImportLabel.TabIndex = 0;
            this.libraryImportLabel.Text = "libraryImportLabel";
            // 
            // libraryContentsListBox
            // 
            this.libraryContentsListBox.FormattingEnabled = true;
            this.libraryContentsListBox.Location = new System.Drawing.Point(12, 42);
            this.libraryContentsListBox.Name = "libraryContentsListBox";
            this.libraryContentsListBox.Size = new System.Drawing.Size(262, 124);
            this.libraryContentsListBox.TabIndex = 1;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(199, 179);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(280, 179);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // allButton
            // 
            this.allButton.Location = new System.Drawing.Point(280, 42);
            this.allButton.Name = "allButton";
            this.allButton.Size = new System.Drawing.Size(75, 23);
            this.allButton.TabIndex = 4;
            this.allButton.Text = "allButton";
            this.allButton.UseVisualStyleBackColor = true;
            this.allButton.Click += new System.EventHandler(this.allButton_Click);
            // 
            // noneButton
            // 
            this.noneButton.Location = new System.Drawing.Point(280, 71);
            this.noneButton.Name = "noneButton";
            this.noneButton.Size = new System.Drawing.Size(75, 23);
            this.noneButton.TabIndex = 5;
            this.noneButton.Text = "noneButton";
            this.noneButton.UseVisualStyleBackColor = true;
            this.noneButton.Click += new System.EventHandler(this.noneButton_Click);
            // 
            // libraryImportPromptLabel
            // 
            this.libraryImportPromptLabel.AutoSize = true;
            this.libraryImportPromptLabel.Location = new System.Drawing.Point(12, 23);
            this.libraryImportPromptLabel.Name = "libraryImportPromptLabel";
            this.libraryImportPromptLabel.Size = new System.Drawing.Size(122, 13);
            this.libraryImportPromptLabel.TabIndex = 6;
            this.libraryImportPromptLabel.Text = "libraryImportPromptLabel";
            // 
            // LibraryImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 212);
            this.Controls.Add(this.libraryImportPromptLabel);
            this.Controls.Add(this.noneButton);
            this.Controls.Add(this.allButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.libraryContentsListBox);
            this.Controls.Add(this.libraryImportLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LibraryImportForm";
            this.Text = "LibraryImportForm";
            this.Load += new System.EventHandler(this.LibraryImportForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label libraryImportLabel;
        private System.Windows.Forms.CheckedListBox libraryContentsListBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button allButton;
        private System.Windows.Forms.Button noneButton;
        private System.Windows.Forms.Label libraryImportPromptLabel;
    }
}