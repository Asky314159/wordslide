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
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WordSlideEngine;


namespace WordSlide
{
    partial class ScreenSaverForm : Form
    {
        private bool blank = false;
        private bool help = false;
        private bool test = false;
        private DisplaySlideSet[] slideSet;
        private int slideindex = 0;
        private int screenNumber;
        private string[] helpstrings;
        private Engine engine;

        private DisplaySlide currentSlide
        {
            get { return slideSet[slideindex].currentSlide; }
        }

        public ScreenSaverForm(int screen, DisplaySlideSet[] ss, Engine wordslideEngine)
        {
            engine = wordslideEngine;
            slideSet = ss;
            for (int x = 0; x < slideSet.Length; x++)
            {
                slideSet[x].loadFile();
            }

            helpstrings = new string[11];
            helpstrings[0] = string.Format(Resources.Help_exitButton, engine.Options.ExitKey.ToString());
            helpstrings[1] = string.Format(Resources.Help_forwardButton, engine.Options.ForwardKey.ToString());
            helpstrings[2] = string.Format(Resources.Help_backwardButton, engine.Options.BackwardKey.ToString());
            helpstrings[3] = string.Format(Resources.Help_blankButton, engine.Options.BlankKey.ToString());
            helpstrings[4] = string.Format(Resources.Help_chorusButton, engine.Options.ChorusKey.ToString());
            helpstrings[5] = string.Format(Resources.Help_forwardSongButton, engine.Options.SongForwardKey.ToString());
            helpstrings[6] = string.Format(Resources.Help_backwardSongButton, engine.Options.SongBackwardKey.ToString());
            helpstrings[7] = string.Format(Resources.Help_forwardVerseButton, engine.Options.VerseForwardKey.ToString());
            helpstrings[8] = string.Format(Resources.Help_backwardVerseButton, engine.Options.VerseBackwardKey.ToString());
            helpstrings[9] = string.Format(Resources.Help_videoTestButton, engine.Options.TestKey.ToString());
            helpstrings[10] = string.Format(Resources.Help_helpButton, engine.Options.HelpKey.ToString());

            screenNumber = screen;

            InitializeComponent();
            //SetupScreenSaver();
        }

        private void ScreenSaverForm_Load(object sender, EventArgs e)
        {
            SetupScreenSaver();
        }

        /// <summary>
        /// Set up the main form as a full screen screensaver.
        /// </summary>
        private void SetupScreenSaver()
        {
            // Use double buffering to improve drawing performance
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            // Capture the mouse
            this.Capture = true;

            // Set the application to full screen mode and hide the mouse
            Cursor.Hide();
            //Bounds = Screen.PrimaryScreen.Bounds;
            Bounds = Screen.AllScreens[screenNumber].Bounds;
            WindowState = FormWindowState.Maximized;
            ShowInTaskbar = false;
            DoubleBuffered = true;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        public void setSlideSet(DisplaySlideSet[] ss)
        {
            slideSet = ss;
        }

        private void ScreenSaverForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == engine.Options.TestKey)
            {
                test = false;
                this.Refresh();
            }
        }

        private void ScreenSaverForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == engine.Options.TestKey)
            {
                test = true;
                this.Refresh();
            }
            if (e.KeyCode.ToString() == engine.Options.ExitKey)
            {
                this.Close();
            }
            if (e.KeyCode.ToString() == engine.Options.BackwardKey)
            {
                if (!slideSet[slideindex].decrementSlide())
                {
                    if (slideindex > 0)
                        slideindex--;
                }
                this.Refresh();
            }
            if (e.KeyCode.ToString() == engine.Options.ForwardKey)// || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                if (!slideSet[slideindex].incrementSlide())
                {
                    if (slideindex < slideSet.Length - 1)
                        slideindex++;
                }
                this.Refresh();
            }
            if (e.KeyCode.ToString() == engine.Options.BlankKey)
            {
                blank = !blank;
                this.Refresh();
            }
            if (e.KeyCode.ToString() == engine.Options.SongForwardKey)
            {
                if (slideindex < slideSet.Length - 1)
                {
                    while (slideSet[slideindex].incrementSlide()) ;
                    slideindex++;
                    this.Refresh();
                }
            }
            if (e.KeyCode.ToString() == engine.Options.SongBackwardKey)
            {
                bool next = false;
                while (slideSet[slideindex].decrementSlide()) next = true;
                if (!next && slideindex > 0)
                {
                    slideindex--;
                    while (slideSet[slideindex].decrementSlide()) ;
                }
                this.Refresh();
            }
            if (e.KeyCode.ToString() == engine.Options.ChorusKey)
            {
                slideSet[slideindex].chorusOverride();
                this.Refresh();
            }
            if (e.KeyCode.ToString() == engine.Options.VerseForwardKey)
            {
                if (!slideSet[slideindex].incrementVerse())
                {
                    if (slideindex < slideSet.Length - 1)
                        slideindex++;
                }
                this.Refresh();
            }
            if (e.KeyCode.ToString() == engine.Options.VerseBackwardKey)
            {
                if (!slideSet[slideindex].decrementVerse())
                {
                    if (slideindex > 0)
                        slideindex--;
                }
                this.Refresh();
            }
            if (e.KeyCode.ToString() == engine.Options.HelpKey)
            {
                help = !help;
                this.Refresh();
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.FromArgb(engine.Options.BackgroundColor));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DisplaySlide displaySlide = currentSlide;
            if (test)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(engine.Options.TextColor)), this.Bounds.Left, this.Bounds.Top, 15, 15);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(engine.Options.TextColor)), this.Bounds.Left, this.Bounds.Height - 15, 15, 15);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(engine.Options.TextColor)), this.Bounds.Width - 15, this.Bounds.Top, 15, 15);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(engine.Options.TextColor)), this.Bounds.Width - 15, this.Bounds.Height - 15, 15, 15);
            }
            if (!blank && !displaySlide.blank)
            {
                string[] lines = displaySlide.text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.None);
                float textstart = Bounds.Top + engine.Options.TextStart;
                float titlestart = Bounds.Top + engine.Options.TitleStart;
                float helpstart = Bounds.Top + Options.TitleStartDefault;

                if (!help)
                {
                    if (displaySlide.firstslide)
                    {
                        textstart += engine.Options.TitleTextSpace;
                        SizeF titlesize = e.Graphics.MeasureString(displaySlide.title, new System.Drawing.Font(engine.Options.TitleFont.family, engine.Options.TitleFont.size));
                        SizeF bylinesize = e.Graphics.MeasureString(displaySlide.by, new System.Drawing.Font(engine.Options.BylineFont.family, engine.Options.BylineFont.size));
                        SizeF copyrightsize = e.Graphics.MeasureString(displaySlide.copyright, new System.Drawing.Font(engine.Options.DotFont.family, engine.Options.DotFont.size));
                        e.Graphics.DrawString(displaySlide.title, new System.Drawing.Font(engine.Options.TitleFont.family, engine.Options.TitleFont.size), new SolidBrush(Color.FromArgb(engine.Options.TextColor)), new PointF(((this.Bounds.Width - titlesize.Width) / 2) + Bounds.Left, titlestart));
                        e.Graphics.DrawString(displaySlide.by, new System.Drawing.Font(engine.Options.BylineFont.family, engine.Options.BylineFont.size), new SolidBrush(Color.FromArgb(engine.Options.TextColor)), new PointF(((this.Bounds.Width - bylinesize.Width) / 2) + Bounds.Left, titlestart + titlesize.Height));
                        e.Graphics.DrawString(displaySlide.copyright, new System.Drawing.Font(engine.Options.DotFont.family, engine.Options.DotFont.size), new SolidBrush(Color.FromArgb(engine.Options.TextColor)), new PointF(((this.Bounds.Width - copyrightsize.Width) / 2) + Bounds.Left, titlestart + titlesize.Height + bylinesize.Height));
                    }

                    if (displaySlide.lastslide)
                    {
                        if (slideindex < slideSet.Length - 1 && !slideSet[slideindex + 1].Blank)
                        {
                            SizeF dotsize = e.Graphics.MeasureString(engine.Options.SongEnd, new System.Drawing.Font(engine.Options.DotFont.family, engine.Options.DotFont.size));
                            e.Graphics.DrawString(engine.Options.SongEnd, new System.Drawing.Font(engine.Options.DotFont.family, engine.Options.DotFont.size), new SolidBrush(Color.FromArgb(engine.Options.TextColor)), new PointF(((this.Bounds.Width - dotsize.Width) / 2) + Bounds.Left, this.Bounds.Bottom - 50));
                        }
                        else
                        {
                            SizeF dotsize = e.Graphics.MeasureString(engine.Options.ShowEnd, new System.Drawing.Font(engine.Options.DotFont.family, engine.Options.DotFont.size));
                            e.Graphics.DrawString(engine.Options.ShowEnd, new System.Drawing.Font(engine.Options.DotFont.family, engine.Options.DotFont.size), new SolidBrush(Color.FromArgb(engine.Options.TextColor)), new PointF(((this.Bounds.Width - dotsize.Width) / 2) + Bounds.Left, this.Bounds.Bottom - 50));
                        }
                    }

                    for (int x = 0; x < lines.Length; x++)
                    {
                        SizeF textsize = e.Graphics.MeasureString(lines[x], new System.Drawing.Font(engine.Options.TextFont.family, engine.Options.TextFont.size));
                        string[] sublines;
                        if (textsize.Width < Bounds.Width)
                        {
                            sublines = new string[1];
                            sublines[0] = lines[x];
                        }
                        else
                        {
                            string[] words = lines[x].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            sublines = new string[((int)(textsize.Width / Bounds.Width)) + 1];
                            int sublineindex = 0;
                            for (int z = 0; z < words.Length; z++)
                            {
                                float wordwidth = e.Graphics.MeasureString(words[z], new System.Drawing.Font(engine.Options.TextFont.family, engine.Options.TextFont.size)).Width;
                                float linewidth = e.Graphics.MeasureString(sublines[sublineindex], new System.Drawing.Font(engine.Options.TextFont.family, engine.Options.TextFont.size)).Width;
                                if (wordwidth < Bounds.Width)
                                {
                                    if ((linewidth + wordwidth + 1) < Bounds.Width)
                                    {
                                        if (linewidth != 0) sublines[sublineindex] += " ";
                                    }
                                    else
                                    {
                                        sublineindex++;
                                    }
                                    sublines[sublineindex] += words[z];
                                }
                            }
                        }
                        for (int y = 0; y < sublines.Length; y++)
                        {
                            textsize = e.Graphics.MeasureString(sublines[y], new System.Drawing.Font(engine.Options.TextFont.family, engine.Options.TextFont.size));
                            e.Graphics.DrawString(sublines[y], new System.Drawing.Font(engine.Options.TextFont.family, engine.Options.TextFont.size), new SolidBrush(Color.FromArgb(engine.Options.TextColor)), new PointF(((this.Bounds.Width - textsize.Width) / 2) + Bounds.Left, textstart));
                            textstart += textsize.Height;
                        }
                    }
                }
                else
                {
                    for (int x = 0; x < helpstrings.Length; x++)
                    {
                        SizeF linesize = e.Graphics.MeasureString(helpstrings[x], new System.Drawing.Font(engine.Options.TextFont.family, engine.Options.TextFont.size));
                        e.Graphics.DrawString(helpstrings[x], new System.Drawing.Font(engine.Options.TextFont.family, engine.Options.TextFont.size), new SolidBrush(Color.FromArgb(engine.Options.TextColor)), new PointF(((this.Bounds.Width - linesize.Width) / 2) + Bounds.Left, helpstart));
                        helpstart += linesize.Height;
                    }
                }
            }
        }
    }
}
