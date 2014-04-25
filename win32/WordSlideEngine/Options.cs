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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WordSlideEngine
{
    public struct Font
    {
        public string family;
        public int size;
    }

    public class Options
    {
        private string filePath;
        
        public int BackgroundColor { get; set; }
        public int TextColor { get; set; }
        public string SongEnd { get; set; }
        public string ShowEnd { get; set; }
        public bool AutoUpdate { get; set; }
        public Font TitleFont { get; set; }
        public Font TextFont { get; set; }
        public Font BylineFont { get; set; }
        public Font DotFont { get; set; }
        public int TextStart { get; set; }
        public int TitleStart { get; set; }
        public int TitleTextSpace { get; set; }
        public string ExitKey { get; set; }
        public string ForwardKey { get; set; }
        public string BackwardKey { get; set; }
        public string BlankKey { get; set; }
        public string ChorusKey { get; set; }
        public string SongForwardKey { get; set; }
        public string SongBackwardKey { get; set; }
        public string VerseForwardKey { get; set; }
        public string VerseBackwardKey { get; set; }
        public string HelpKey { get; set; }
        public string TestKey { get; set; }
        public Version SkippedVersion { get; set; }
        public bool AutoBackup { get; set; }
        public int BackupInterval { get; set; }
        public bool ReportErrors { get; set; }

        public static int BackgroundColorDefault { get { return -16777216; } }
        public static int TextColorDefault { get { return -1; } }
        public static string SongEndDefault { get { return ".."; } }
        public static string ShowEndDefault { get { return "..."; } }
        public static bool AutoUpdateDefault { get { return true; } }
        public static Font TitleFontDefault { get { return new Font { family = "Microsoft Sans Serif", size = 42 }; } }
        public static Font TextFontDefault { get { return new Font { family = "Microsoft Sans Serif", size = 36 }; } }
        public static Font BylineFontDefault { get { return new Font { family = "Microsoft Sans Serif", size = 16 }; } }
        public static Font DotFontDefault { get { return new Font { family = "Microsoft Sans Serif", size = 14 }; } }
        public static int TextStartDefault { get { return 200; } }
        public static int TitleStartDefault { get { return 100; } }
        public static int TitleTextSpaceDefault { get { return 50; } }
        public static int TextStartTop { get { return 50; } }
        public static int TitleStartTop { get { return 0; } }
        public static int TitleTextSpaceTop { get { return 100; } }
        public static string ExitKeyDefault { get { return "Escape"; } }
        public static string ForwardKeyDefault { get { return "Right"; } }
        public static string BackwardKeyDefault { get { return "Left"; } }
        public static string BlankKeyDefault { get { return "B"; } }
        public static string ChorusKeyDefault { get { return "C"; } }
        public static string SongForwardKeyDefault { get { return "S"; } }
        public static string SongBackwardKeyDefault { get { return "A"; } }
        public static string VerseForwardKeyDefault { get { return "X"; } }
        public static string VerseBackwardKeyDefault { get { return "Z"; } }
        public static string HelpKeyDefault { get { return "F1"; } }
        public static string TestKeyDefault { get { return "F12"; } }
        public static Version SkippedVersionDefault { get { return new Version(0, 0, 0, 0); } }
        public static bool AutoBackupDefault { get { return false; } }
        public static int BackupIntervalDefault { get { return 0; } }
        public static bool ReportErrorsDefault { get { return true; } }

        public Options(string fileName)
        {
            filePath = fileName;
        }

        public void loadFile()
        {
            try
            {
                setDefaults();
                using (StreamReader reader = new StreamReader(new FileStream(filePath, FileMode.Open)))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] line = reader.ReadLine().Split(new char[] { '=' }, 2);
                        if (line.Length != 2) continue;
                        switch (line[0].ToLower())
                        {
                            case "backgroundcolor":
                                this.BackgroundColor = int.Parse(line[1]);
                                break;
                            case "textcolor":
                                this.TextColor = int.Parse(line[1]);
                                break;
                            case "titlefontfamily":
                                this.TitleFont = new Font { family = line[1], size = this.TitleFont.size };
                                break;
                            case "titlefontsize":
                                this.TitleFont = new Font { family = this.TitleFont.family, size = int.Parse(line[1]) };
                                break;
                            case "textfontfamily":
                                this.TextFont = new Font { family = line[1], size = this.TextFont.size };
                                break;
                            case "textfontsize":
                                this.TextFont = new Font { family = this.TextFont.family, size = int.Parse(line[1]) };
                                break;
                            case "bylinefontfamily":
                                this.BylineFont = new Font { family = line[1], size = this.BylineFont.size };
                                break;
                            case "bylinefontsize":
                                this.BylineFont = new Font { family = this.BylineFont.family, size = int.Parse(line[1]) };
                                break;
                            case "dotfontfamily":
                                this.DotFont = new Font { family = line[1], size = this.DotFont.size };
                                break;
                            case "dotfontsize":
                                this.DotFont = new Font { family = this.DotFont.family, size = int.Parse(line[1]) };
                                break;
                            case "songend":
                                this.SongEnd = line[1];
                                break;
                            case "showend":
                                this.ShowEnd = line[1];
                                break;
                            case "autoupdate":
                                this.AutoUpdate = bool.Parse(line[1]);
                                break;
                            case "textstart":
                                this.TextStart = int.Parse(line[1]);
                                break;
                            case "titlestart":
                                this.TitleStart = int.Parse(line[1]);
                                break;
                            case "titletextspace":
                                this.TitleTextSpace = int.Parse(line[1]);
                                break;
                            case "exitkey":
                                this.ExitKey = line[1];
                                break;
                            case "forwardkey":
                                this.ForwardKey = line[1];
                                break;
                            case "backwardkey":
                                this.BackwardKey = line[1];
                                break;
                            case "blankkey":
                                this.BlankKey = line[1];
                                break;
                            case "choruskey":
                                this.ChorusKey = line[1];
                                break;
                            case "songforwardkey":
                                this.SongForwardKey = line[1];
                                break;
                            case "songbackwardkey":
                                this.SongBackwardKey = line[1];
                                break;
                            case "verseforwardkey":
                                this.VerseForwardKey = line[1];
                                break;
                            case "versebackwardkey":
                                this.VerseBackwardKey = line[1];
                                break;
                            case "helpkey":
                                this.HelpKey = line[1];
                                break;
                            case "testkey":
                                this.TestKey = line[1];
                                break;
                            case "skippedversion":
                                this.SkippedVersion = new Version(line[1]);
                                break;
                            case "autobackup":
                                this.AutoBackup = bool.Parse(line[1]);
                                break;
                            case "backupinterval":
                                this.BackupInterval = int.Parse(line[1]);
                                break;
                            case "reporterrors":
                                this.ReportErrors = bool.Parse(line[1]);
                                break;
                        }
                    }
                }
            }
            catch
            {
                setDefaults();
            }
        }

        private void setDefaults()
        {
            this.BackgroundColor = BackgroundColorDefault;
            this.TextColor = TextColorDefault;
            this.TitleFont = TitleFontDefault;
            this.TextFont = TextFontDefault;
            this.BylineFont = BylineFontDefault;
            this.DotFont = DotFontDefault;
            this.SongEnd = SongEndDefault;
            this.ShowEnd = ShowEndDefault;
            this.AutoUpdate = AutoUpdateDefault;
            this.TextStart = TextStartDefault;
            this.TitleStart = TitleStartDefault;
            this.TitleTextSpace = TitleTextSpaceDefault;
            this.ExitKey = ExitKeyDefault;
            this.ForwardKey = ForwardKeyDefault;
            this.BackwardKey = BackwardKeyDefault;
            this.BlankKey = BlankKeyDefault;
            this.ChorusKey = ChorusKeyDefault;
            this.SongForwardKey = SongForwardKeyDefault;
            this.SongBackwardKey = SongBackwardKeyDefault;
            this.VerseForwardKey = VerseForwardKeyDefault;
            this.VerseBackwardKey = VerseBackwardKeyDefault;
            this.HelpKey = HelpKeyDefault;
            this.TestKey = TestKeyDefault;
            this.SkippedVersion = SkippedVersionDefault;
            this.AutoBackup = AutoBackupDefault;
            this.BackupInterval = BackupIntervalDefault;
            this.ReportErrors = ReportErrorsDefault;
        }

        public void saveFile()
        {
            using (StreamWriter writer = new StreamWriter(new FileStream(filePath, FileMode.Create)))
            {
                writer.WriteLine(string.Join("=", "BackgroundColor", this.BackgroundColor));
                writer.WriteLine(string.Join("=", "TextColor", this.TextColor));
                writer.WriteLine(string.Join("=", "TitleFontFamily", this.TitleFont.family));
                writer.WriteLine(string.Join("=", "TitleFontSize", (int)this.TitleFont.size));
                writer.WriteLine(string.Join("=", "TextFontFamily", this.TextFont.family));
                writer.WriteLine(string.Join("=", "TextFontSize", (int)this.TextFont.size));
                writer.WriteLine(string.Join("=", "BylineFontFamily", this.BylineFont.family));
                writer.WriteLine(string.Join("=", "BylineFontSize", (int)this.BylineFont.size));
                writer.WriteLine(string.Join("=", "DotFontFamily", this.DotFont.family));
                writer.WriteLine(string.Join("=", "DotFontSize", (int)this.DotFont.size));
                writer.WriteLine(string.Join("=", "SongEnd", this.SongEnd));
                writer.WriteLine(string.Join("=", "ShowEnd", this.ShowEnd));
                writer.WriteLine(string.Join("=", "AutoUpdate", this.AutoUpdate));
                writer.WriteLine(string.Join("=", "TextStart", this.TextStart));
                writer.WriteLine(string.Join("=", "TitleStart", this.TitleStart));
                writer.WriteLine(string.Join("=", "TitleTextSpace", this.TitleTextSpace));
                writer.WriteLine(string.Join("=", "ExitKey", this.ExitKey));
                writer.WriteLine(string.Join("=", "ForwardKey", this.ForwardKey));
                writer.WriteLine(string.Join("=", "BackwardKey", this.BackwardKey));
                writer.WriteLine(string.Join("=", "BlankKey", this.BlankKey));
                writer.WriteLine(string.Join("=", "ChorusKey", this.ChorusKey));
                writer.WriteLine(string.Join("=", "SongForwardKey", this.SongForwardKey));
                writer.WriteLine(string.Join("=", "SongBackwardKey", this.SongBackwardKey));
                writer.WriteLine(string.Join("=", "VerseForwardKey", this.VerseForwardKey));
                writer.WriteLine(string.Join("=", "VerseBackwardKey", this.VerseBackwardKey));
                writer.WriteLine(string.Join("=", "HelpKey", this.HelpKey));
                writer.WriteLine(string.Join("=", "TestKey", this.TestKey));
                writer.WriteLine(string.Join("=", "SkippedVersion", this.SkippedVersion.ToString()));
                writer.WriteLine(string.Join("=", "AutoBackup", this.AutoBackup));
                writer.WriteLine(string.Join("=", "BackupInterval", this.BackupInterval));
                writer.WriteLine(string.Join("=", "ReportErrors", this.ReportErrors));
                writer.WriteLine(string.Join("=", "Path", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)));
                writer.WriteLine(string.Join("=", "Version", Engine.Version.ToString()));
            }
        }
    }
}
