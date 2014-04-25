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
using System.Text;
using System.Xml;

namespace WordSlideEngine
{
    /// <summary>
    /// The DisplaySlideSet class is able to load and store data about a slide set for display on the
    /// screen. For the version of this class used in the editor, see EditableSlideSet.
    /// </summary>
    public class DisplaySlideSet : SlideSet
    {
        /// <summary>
        /// Stores the value of the index of the current slide. Used to determine which text to return 
        /// when the current slide is requested.
        /// </summary>
        private int slideindex = 0;

        /// <summary>
        /// Stores the value of the index of the current sub-slide. Used to determine which text to
        /// return when the current sub-slide is requested.
        /// </summary>
        private int subslideindex = 0;

        /// <summary>
        /// Determines whether the DisplaySlideSet contains actual slides, or is just a placeholder for
        /// a blank slide.
        /// </summary>
        private bool blank;

        /// <summary>
        /// Determines whether or not to return a generic chorus slide or the actual current slide when
        /// it is requested.
        /// </summary>
        private bool showchorus;

        /// <summary>
        /// Provides access to the path to the loaded slide set. Identifies this slide set uniquely when
        /// the user is setting up a slide show.
        /// </summary>
        public string Path { get { return path; } }

        /// <summary>
        /// Determines whether the DisplaySlideSet contains actual slides, or is just a placeholder for
        /// a blank slide.
        /// </summary>
        public bool Blank { get { return blank; } }

        /// <summary>
        /// Returns a DisplaySlide containing the contents of the current slide. Will display a generic
        /// chorus slide when the chorus override is enabled.
        /// </summary>
        public DisplaySlide currentSlide
        {
            get
            {
                if (showchorus)
                    return chorusSlide;
                else
                    return thisSlide;
            }
        }

        /// <summary>
        /// Returns a DisplaySlide containing the text of the song's chorus. Is returned from currentSlide
        /// when the chorus override is enabled.
        /// </summary>
        private DisplaySlide chorusSlide
        {
            get
            {
                DisplaySlide ret = new DisplaySlide();
                ret.firstslide = false;
                ret.title = "";
                ret.by = "";
                ret.copyright = "";
                ret.lastslide = false;
                ret.text = ((chorus == -1) ? "" : texts[chorus]);
                ret.blank = ((chorus == -1) ? true : false);
                return ret;
            }
        }

        /// <summary>
        /// Returns a DisplaySlide containing the contents of the current slide.
        /// </summary>
        private DisplaySlide thisSlide
        {
            get
            {
                DisplaySlide ret = new DisplaySlide();
                ret.firstslide = ((slideindex == 0) && (subslideindex == 0));
                ret.title = name;
                ret.by = byline;
                ret.copyright = copyright;
                ret.lastslide = ((slideindex + 1 == order.Length) && (subslideindex + 1 == getSubSlideCount()));
                ret.text = getSubSlide(); //texts[order[slideindex]];
                ret.blank = blank;
                return ret;
            }
        }

        /// <summary>
        /// Creates a generic DisplaySlideSet to act as a placeholder for a single blank slide.
        /// </summary>
        public DisplaySlideSet()
        {
            name = "";
            path = "";
            blank = true;
            showchorus = false;
        }

        /// <summary>
        /// Creates a DisplaySlideSet that is to be loaded from a SLD file located in the program's slide
        /// set folder.
        /// </summary>
        /// <param name="filepath">The full path to the SLD file to be loaded.</param>
        public DisplaySlideSet(string filepath)
        {
            blank = false;
            showchorus = false;
            path = filepath;
            getTitle();
        }

        /// <summary>
        /// Returns either the title of the slide set or text indicating the DisplaySlideSet contains a
        /// blank slide placeholer. Provided for UI functionality.
        /// </summary>
        /// <returns>The title of the slide set.</returns>
        public override string ToString()
        {
            if (!blank)
            {
                return base.ToString();
            }
            else
            {
                return "<Blank Slide>";
            }
        }

        /// <summary>
        /// Populates the properties of the DisplaySlideSet with either data from its SLD file or a set
        /// of placeholder data. Must be called before the DisplaySlideSet can be used.
        /// </summary>
        public new void loadFile()
        {
            if (!blank)
            {
                base.loadFile();
            }
            else
            {
                byline = "";
                texts = new string[1];
                texts[0] = "";
                order = new int[1];
                order[0] = 0;
            }
        }

        /// <summary>
        /// Increments the currently displayed slide index unless the current slide is the last slide
        /// in the set.
        /// </summary>
        /// <returns>False if the slide incremented normally, true if the current slide is the final one in the set.</returns>
        public bool incrementSlide()
        {
            showchorus = false;
            if (!incrementSubSlide())
            {
                if (slideindex + 1 > order.Length - 1)
                    return false;
                slideindex++;
                subslideindex = 0;
            }
            return true;
        }

        /// <summary>
        /// Decrements the currently displayed slide index unless the current slide is the first slide
        /// in the set.
        /// </summary>
        /// <returns>False is the slide decremented normally, true is the current slide is the first one in the set.</returns>
        public bool decrementSlide()
        {
            showchorus = false;
            if (!decrementSubSlide())
            {
                if (slideindex - 1 < 0)
                    return false;
                slideindex--;
                subslideindex = (getSubSlideCount() - 1);
            }
            return true;
        }

        /// <summary>
        /// Toggles the chorus override. When the override is active, the currentSlide property returns
        /// a generic chorus slide instead of the actual current slide.
        /// </summary>
        public void chorusOverride()
        {
            showchorus = !showchorus;
        }

        /// <summary>
        /// Determines which section of the current block of text to return, based on the slide set's
        /// number of lines per slide and the current sub-slide position.
        /// </summary>
        /// <returns>The string containing the text of the current sub-slide.</returns>
        private string getSubSlide()
        {
            string[] temp = texts[order[slideindex]].Split("\n".ToCharArray(), StringSplitOptions.None);
            string ret = "";
            int lps = this.getLinesPerSlide();
            for (int x = (lps * subslideindex); x < ((temp.Length < ((lps * subslideindex) + lps)) ? temp.Length : ((lps * subslideindex) + lps)); x++)
            {
                try
                {
                    ret += temp[x];
                }
                catch
                {
                    ret = temp.Length.ToString() + " " + lps + " " + subslideindex + " " + x.ToString();
                    x = 100;
                }
            }
            return ret;
        }

        /// <summary>
        /// Attempt to move to the next slide, unless the current slide is the final one in the set.
        /// </summary>
        /// <returns>Whether the attempted increment was successful.</returns>
        public bool incrementVerse()
        {
            showchorus = false;
            if (slideindex + 1 > order.Length - 1)
                return false;
            slideindex++;
            subslideindex = 0;
            return true;
        }

        /// <summary>
        /// Attempt to move to the previous slide, unless the current slide is the first one in the set.
        /// </summary>
        /// <returns>Whether the attemped decrement was successful.</returns>
        public bool decrementVerse()
        {
            showchorus = false;
            if (slideindex - 1 < 0)
                return false;
            slideindex--;
            subslideindex = 0;
            return true;
        }

        /// <summary>
        /// Attempt to move to the next sub-slide, unless the current sub-slide is the last one in the set.
        /// </summary>
        /// <returns>Whether the attemped increment was successful.</returns>
        private bool incrementSubSlide()
        {
            if (subslideindex < getSubSlideCount() - 1)
            {
                subslideindex++;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Attempt to move to the previous sub-slide, unless the current sub-slide is the first one
        /// in the set.
        /// </summary>
        /// <returns>Whether the attemped decrement was successful.</returns>
        private bool decrementSubSlide()
        {
            if (subslideindex > 0)
            {
                subslideindex--;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Based on the lines of text on the current slide and the set's number of lines per slide,
        /// calculate the number of subslides in the current slide.
        /// </summary>
        /// <returns>The number of sub-slides in the current slide.</returns>
        private int getSubSlideCount()
        {
            if (blank) return 0;
            int lines = 1;
            for (int x = 0; x < texts[order[slideindex]].Length; x++)
            {
                if(texts[order[slideindex]][x]=='\n')
                    lines++;
            }
            return (int)System.Math.Ceiling(((decimal)lines / this.getLinesPerSlide()));
        }

        private int getLinesPerSlide()
        {
            return (locallinesperslide[order[slideindex]] == 0 ? linesperslide : locallinesperslide[order[slideindex]]);
        }
    }
}
