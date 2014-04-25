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
using System.Net;
using System.IO;
using WordSlideEngine;

namespace WordSlide
{
    public delegate void AutoUpdateDelegate();

    public partial class UpdaterForm : Form
    {
        private Version newVersionNumber;
        private bool runningAuto = false;
        private Engine engine;

        private AutoUpdateDelegate autoUpdateFinished;

        private delegate void UpdateMessage(string m1, string m2);

        public UpdaterForm(Engine wordslideEngine)
        {
            InitializeComponent();
            engine = wordslideEngine;
        }

        private void UpdaterForm_Load(object sender, EventArgs e)
        {
            
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            try
            {
                Updater.DownloadUpdate(new DownloadUpdateComplete(DownloadUpdateComplete), new ProgressChanged(updateProgress));
            }
            catch (Exception ex)
            {
                //Program.ReportError(ex);
                updateMessage("The update server could not be contacted.", "Please try again later.");
            }
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            if (skipVersionBox.Checked)
            {
                engine.Options.SkippedVersion = newVersionNumber;
                engine.Options.saveFile();
            }
            DialogResult = DialogResult.No;
            Close();
        }

        public void checkForUpdate(AutoUpdateDelegate auto = null)
        {
            runningAuto = (auto == null);
            autoUpdateFinished = auto;
            skipVersionBox.Visible = runningAuto;
            currentLabel.Text = "Current version: " + Engine.Version.Major + "." + Engine.Version.Minor + "." + Engine.Version.Build + (Engine.Version.Revision == 0 ? "" : "." + Engine.Version.Revision);
            yesButton.Visible = false;
            Updater.CheckForUpdates(new CheckForUpdatesComplete(CheckForUpdatesComplete), new ProgressChanged(updateProgress));
        }

        private void updateProgress(int p)
        {
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new ProgressChanged(updateProgress), p);
            }
            else
            {
                progressBar.Value = p;
            }
        }

        private void updateMessage(string m1, string m2)
        {
            if (messageLabel1.InvokeRequired)
            {
                messageLabel1.Invoke(new UpdateMessage(updateMessage), m1, m2);
            }
            else
            {
                messageLabel1.Text = m1;
                messageLabel2.Text = m2;
            }
        }

        private void CheckForUpdatesComplete(bool success, string newVersion)
        {
            if (success)
            {
                Version v = null;
                if (Version.TryParse(newVersion, out v))
                {
                    SetNewVersion(v);
                }
                else
                {
                    updateMessage("The update server could not be contacted.", "Please try again later.");
                }
            }
            else
            {
                updateMessage("The update server could not be contacted.", "Please try again later.");
            }
        }

        private void DownloadUpdateComplete(bool success, string path)
        {
            if (success)
            {
                this.engine.UpdatePath = path;
                DialogResult = DialogResult.Yes;
                Close();
            }
            else
            {
                updateMessage("The update server could not be contacted.", "Please try again later.");
            }
        }

        private void SetNewVersion(Version v)
        {
            newVersionNumber = v;
            newLabel.Text = "Latest version: " + v.Major + "." + v.Minor + "." + v.Build + (v.Revision == 0 ? "" : "." + v.Revision);
            switch (Engine.Version.CompareTo(v))
            {
                case -1: caseNegOne();
                    break;
                case 0: caseZero();
                    break;
                case 1: caseOne();
                    break;
            }
        }

        private void caseNegOne()
        {
            updateMessage("There is a new version available. Would you like to update now?", "The program will restart when the update is complete.");
            yesButton.Visible = true;
            noButton.Text = "No";
            if (runningAuto && !engine.Options.SkippedVersion.Equals(newVersionNumber))
                autoUpdateFinished();
        }

        private void caseZero()
        {
            updateMessage("You are currently running the latest version.", "You do not need to update.");
        }

        private void caseOne()
        {
            updateMessage("You appear to be running a version newer than the newest offered by", "the server. Needless to say, you do not need to update.");
        }
    }
}