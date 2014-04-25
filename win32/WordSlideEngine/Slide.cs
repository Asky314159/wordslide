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

namespace WordSlideEngine
{
    /// <summary>
    /// Generic Slide class to provide common functionality to EditableSlide and
    /// DisplaySlide.
    /// </summary>
    public abstract class Slide
    {
    }

    /// <summary>
    /// Editable Slide class used to populate the UI of the editor.
    /// </summary>
    public class EditableSlide : Slide
    {
        /// <summary>
        /// Stores the value of the position of the slide in the set it belongs to.
        /// </summary>
        private int index;

        /// <summary>
        /// Stores the value of the text of the slide.
        /// </summary>
        private string text;

        /// <summary>
        /// Indicates whether the text stored in this Slide is the chorus of the set it
        /// belongs to.
        /// </summary>
        private bool chorus;

        /// <summary>
        /// Indicates whether the set this slide belongs to contains a chorus slide.
        /// </summary>
        private bool songhaschorus;

        private int linesperslide;

        /// <summary>
        /// Stores the value of the position of the slide in the set it belongs to.
        /// </summary>
        public int Index { get { return index; } set { index = value; } }

        /// <summary>
        /// Stores the value of the text of the slide.
        /// </summary>
        public string Text { get { return text; } set { text = value; } }

        /// <summary>
        /// Indicates whether the text stored in this Slide is the chorus of the set it
        /// belongs to.
        /// </summary>
        public bool Chorus { get { return chorus; } set { chorus = value; } }

        /// <summary>
        /// Indicated whether the set this slide belongs to contains a chorus slide.
        /// </summary>
        public bool SongHasChorus { get { return songhaschorus; } set { songhaschorus = value; } }

        public int LinesPerSlide { get { return linesperslide; } set { linesperslide = value; } }

        /// <summary>
        /// Create a blank EditableSlide at a specified index.
        /// </summary>
        /// <param name="i">The position value of the slide within the set it belongs to.</param>
        public EditableSlide(int i) : this(i, "", false, false, 0) { }

        /// <summary>
        /// Create a EditableSlide at a specified index, containing a specified text.
        /// </summary>
        /// <param name="i">The position value of the slide within the set it belongs to.</param>
        /// <param name="t">The value of the text stored in this Slide.</param>
        /// <param name="c">Indicates whether or not the text stored in this Slide is the chorus of the set it belongs to.</param>
        /// <param name="s">Indicates whether or not the slide set this slide belongs to contains a chorus.</param>
        public EditableSlide(int i, string t, bool c, bool s, int l)
        {
            index = i;
            text = t;
            chorus = c;
            songhaschorus = s;
            linesperslide = l;
        }

        /// <summary>
        /// Returns a string identifying this EditableSlide. Used to populate the editor UI.
        /// </summary>
        /// <returns>Identifies the EditableSlide in a human-readable format.</returns>
        public override string ToString()
        {
            if (!chorus)
                return ("Verse " + (index + (songhaschorus ? 0 : 1)));
            else
                return "Chorus";
        }
    }

    /// <summary>
    /// Slide class used to store data used in the drawing of a slide during a slide show.
    /// </summary>
    public class DisplaySlide : Slide
    {
        /// <summary>
        /// Indicates whether the slide represented by this class is the first slide in a set.
        /// </summary>
        public bool firstslide;

        /// <summary>
        /// Indicates whether the slide represented by this class is the last slide in a set.
        /// </summary>
        public bool lastslide;

        /// <summary>
        /// Stores the value of the title of the set this Slide belongs to.
        /// </summary>
        public string title;

        /// <summary>
        /// Stores the value of the byline of the set this Slide belongs to.
        /// </summary>
        public string by;

        /// <summary>
        /// Stores that value of the text of the slide.
        /// </summary>
        public string text;

        /// <summary>
        /// Stores the value of the copyright notice of the set this Slide belongs to.
        /// </summary>
        public string copyright;

        /// <summary>
        /// Indicates whether the slide represented by this class is a blank slide.
        /// </summary>
        public bool blank;

        public int linesperslide;

        /// <summary>
        /// Create a generic DisplaySlide with no set properties.
        /// </summary>
        public DisplaySlide()
        {
        }
    }

    public class PlaceholderSlide : Slide
    {
        private int index;
        private bool chorus;
        private bool songhaschorus;
        public int Index { get { return index; } set { index = value; } }
        public bool Chorus { get { return chorus; } set { chorus = value; } }
        public bool SongHasChorus { get { return songhaschorus; } set { songhaschorus = value; } }

        public PlaceholderSlide(int i) : this(i,false,false) { }
        public PlaceholderSlide(int i, bool c, bool s)
        {
            index = i;
            chorus = c;
            songhaschorus = s;
        }

        public override string ToString()
        {
            if (!chorus)
                return ("Verse " + (index + (songhaschorus ? 0 : 1)));
            else
                return "Chorus";
        }
    }
}
