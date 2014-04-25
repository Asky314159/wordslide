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
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Net;
using System.Threading;
using System.Security.Cryptography;
using System.Xml;
using WordSlideEngine;

namespace WordSlide
{
    public delegate void CheckForUpdatesComplete(bool success, string availableVersion);
    public delegate void DownloadUpdateComplete(bool success, string downloadPath);
    public delegate void ProgressChanged(int progress);

    static class Updater
    {
        private static WebClient Client = null;
        private static string UpdateCheckUrl { get { return "http://www.jrayri.com/vercheck/wordslide.php?version={0}&platform={1}"; } }
        private static string DownloadUrl = string.Empty;
        private static string DownloadChecksum = string.Empty;

        private static CheckForUpdatesComplete CompletedCheckCallback = null;
        private static DownloadUpdateComplete CompletedDownloadCallback = null;
        private static ProgressChanged ProgressChangedCallback = null;

        public static void CheckForUpdates(CheckForUpdatesComplete checkComplete, ProgressChanged progressChanged)
        {
            if (Client == null)
            {
                InitializeClient();
            }
            CompletedCheckCallback = checkComplete;
            ProgressChangedCallback = progressChanged;
            Client.DownloadStringAsync(new Uri(string.Format(UpdateCheckUrl, Engine.Version.ToString(), "win32")));
        }

        public static void DownloadUpdate(DownloadUpdateComplete downloadComplete, ProgressChanged progressChanged)
        {
            if (Client == null)
            {
                InitializeClient();
            }
            CompletedDownloadCallback = downloadComplete;
            ProgressChangedCallback = progressChanged;
            string destination = Path.Combine(Path.GetTempPath(), "WordSlide.exe");
            if (File.Exists(destination))
            {
                File.Delete(destination);
            }
            Client.DownloadFileAsync(new Uri(DownloadUrl), destination, destination);
        }

        private static void InitializeClient()
        {
            Client = new WebClient();
            Client.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(client_DownloadFileCompleted);
            Client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            Client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
        }

        private static void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            bool success = false;
            string newVersion = string.Empty;
            if (e.Error == null)
            {
                XmlDocument response = new XmlDocument();
                response.LoadXml(e.Result);
                if (response["update"] != null)
                {
                    if (response["update"]["version"] != null)
                    {
                        newVersion = response["update"]["version"].InnerText;
                    }
                    if (response["update"]["url"] != null)
                    {
                        DownloadUrl = response["update"]["url"].InnerText;
                    }
                    if (response["update"]["checksum"] != null)
                    {
                        DownloadChecksum = response["update"]["checksum"].InnerText;
                    }
                }
                success = (!string.IsNullOrEmpty(newVersion) && !string.IsNullOrEmpty(DownloadUrl) && !string.IsNullOrEmpty(DownloadChecksum));
            }
            if (CompletedCheckCallback != null)
            {
                CompletedCheckCallback(success, newVersion);
            }
        }

        private static void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (ProgressChangedCallback != null)
            {
                ProgressChangedCallback(e.ProgressPercentage);
            }
        }

        private static void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            bool success = false;
            string path = string.Empty;
            if (e.Error == null)
            {
                string downloadedFile = e.UserState.ToString();
                string downloadedFileHash = string.Empty;
                using (FileStream fileStream = File.Open(downloadedFile, FileMode.Open, FileAccess.Read))
                {
                    MD5CryptoServiceProvider hasher = new MD5CryptoServiceProvider();
                    byte[] hash = hasher.ComputeHash(fileStream);
                    downloadedFileHash = BitConverter.ToString(hash).Replace("-", "").ToLower();
                }
                if (downloadedFileHash == DownloadChecksum)
                {
                    string tempFolder = Path.Combine(Path.GetTempPath(), "WordSlide");
                    if (Directory.Exists(tempFolder))
                    {
                        Directory.Delete(tempFolder, true);
                    }
                    Directory.CreateDirectory(tempFolder);
                    Process extractProcess = new Process();
                    ProcessStartInfo extractProcessStartInfo = new ProcessStartInfo();
                    extractProcessStartInfo.FileName = downloadedFile;
                    extractProcessStartInfo.Arguments = string.Format("x -o\"{0}\" -y", tempFolder);
                    extractProcessStartInfo.CreateNoWindow = true;
                    extractProcessStartInfo.UseShellExecute = false;
                    extractProcess.StartInfo = extractProcessStartInfo;
                    extractProcess.Start();
                    extractProcess.WaitForExit();
                    File.Delete(downloadedFile);
                    path = tempFolder;
                    success = (extractProcess.ExitCode == 0);
                }
            }
            if (CompletedDownloadCallback != null)
            {
                CompletedDownloadCallback(success, path);
            }
        }
    }
}
