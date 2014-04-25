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
using System.IO;

namespace WordSlideEngine
{
    /// <summary>
    /// The EditableSlideSet class is able to load and store data about a slide set for editing in the
    /// editor. For the version of this class used in the slideshow, see DisplaySlideSet.
    /// </summary>
    public class EditableSlideSet : SlideSet
    {
        /// <summary>
        /// Provides access to the text of the name of the slide set.
        /// </summary>
        public string Name { get { return name; } set { name = value.Trim(); } }

        /// <summary>
        /// Provides access to the text of the byline of the slide set.
        /// </summary>
        public string Byline { get { return byline; } set { byline = value.Trim(); } }

        /// <summary>
        /// Provides access to the text of the copyright line of the slide set.
        /// </summary>
        public string Copyright { get { return copyright; } set { copyright = value.Trim(); } }

        /// <summary>
        /// Provides access to the value of the lines per slide property of the slide set.
        /// </summary>
        public int LinesPerSlide { get { return linesperslide; } set { linesperslide = value; } }

        /// <summary>
        /// Provides access to the index of the chorus text of the slide set.
        /// </summary>
        public int Chorus { get { return chorus; } set { chorus = value; } }

        public string Path { get { return path; } }

        /// <summary>
        /// Provides access to the texts of the slides of the slide set.
        /// </summary>
        public string[] Texts { get { return texts; } }

        /// <summary>
        /// Provides access to the order of the indices of the texts of the slides of the slide set.
        /// </summary>
        public int[] Order { get { return order; } }

        public int[] LocalLinesPerSlide { get { return locallinesperslide; } }

        /// <summary>
        /// This constructor creates a new, empty EditableSlideSet, ready to be filled with data.
        /// </summary>
        public EditableSlideSet()
        {
            path = "";
            name = "";
            byline = "";
            copyright = "";
            texts = new string[1];
            texts[0] = "";
            order = new int[1];
            order[0] = 0;
            locallinesperslide = new int[1];
            locallinesperslide[0] = 0;
            chorus = -1;
            linesperslide = 4;
        }

        /// <summary>
        /// This constructor, used in the open box of the editor, opens the requested slide set file
        /// and gets the name of the file, leaving the other properties uninitialized. Intended to
        /// fill in the other properties with the loadFile function.
        /// </summary>
        /// <param name="filepath">The path to the desired slide set.</param>
        public EditableSlideSet(string filepath)
        {
            path = filepath;
            getTitle();
        }

        public static string getNewPath(string name)
        {
            string filename = "";
            char[] namearray = name.ToCharArray();
            for (int x = 0; x < namearray.Length; x++)
            {
                if (Char.IsLetterOrDigit(namearray[x]))
                {
                    filename += namearray[x];
                }
            }
            return System.IO.Path.Combine(Engine.SlideDirectory, filename + ".sld");
        }

        /// <summary>
        /// Rebuilds the value of the path of the slide set. To be called when the slide set is
        /// renamed, and a new file needs to be generated with the new title.
        /// </summary>
        public void resetPath()
        {
            path = getNewPath(name);
        }

        /// <summary>
        /// Initialize the arrays holding the slide texts and the order of slides.
        /// </summary>
        /// <param name="tcount">The number of unique slides in the set.</param>
        /// <param name="ocount">The number of slides in the order of the set.</param>
        public void setupTexts(int tcount, int ocount)
        {
            texts = new string[tcount];
            order = new int[ocount];
            locallinesperslide = new int[tcount];
        }

        /// <summary>
        /// Set the text of the indicated slide to the indicated text.
        /// </summary>
        /// <param name="index">The index of the slide text to overwrite.</param>
        /// <param name="text">The new text of the indicated slide.</param>
        public void addText(int index, string text, int llps)
        {
            texts[index] = text.Trim();
            locallinesperslide[index] = llps;
        }

        /// <summary>
        /// Set the value of the slide order to the provided value.
        /// </summary>
        /// <param name="index">The index of the slide order value to overwrite.</param>
        /// <param name="slide">The new value of the indicated slide order value.</param>
        public void addOrder(int index, int slide)
        {
            order[index] = slide;
        }

        private void generateXmlDocument(bool delete)
        {
            source = new XmlDocument();
            if (delete && path.StartsWith(Engine.SlideDirectory))
            {
                System.IO.File.Delete(path);
            }
            resetPath();
            XmlNode setnode = source.CreateNode(XmlNodeType.Element, "set", "");
            XmlNode title = source.CreateElement("title");
            title.InnerText = name;
            XmlNode by = source.CreateElement("by");
            by.InnerText = byline;
            XmlNode cr = source.CreateElement("copyright");
            cr.InnerText = copyright;
            XmlNode lps = source.CreateElement("lps");
            lps.InnerText = linesperslide.ToString();
            setnode.AppendChild(title);
            setnode.AppendChild(by);
            setnode.AppendChild(cr);
            setnode.AppendChild(lps);
            if (chorus != -1)
            {
                XmlNode chi = source.CreateElement("chorus");
                chi.InnerText = chorus.ToString();
                setnode.AppendChild(chi);
            }
            for (int x = 0; x < texts.Length; x++)
            {
                XmlNode frame = source.CreateElement("frame");
                XmlNode frameid = source.CreateElement("id");
                frameid.InnerText = x.ToString();
                XmlNode frametext = source.CreateElement("text");
                frametext.InnerText = texts[x];
                frame.AppendChild(frameid);
                frame.AppendChild(frametext);
                setnode.AppendChild(frame);
            }
            XmlNode frameorder = source.CreateElement("order");
            string ordertext = "";
            for (int x = 0; x < order.Length; x++)
            {
                ordertext += order[x];
                if (x < order.Length - 1)
                {
                    ordertext += ":";
                }
            }
            frameorder.InnerText = ordertext;
            setnode.AppendChild(frameorder);
            XmlNode llps = source.CreateElement("llps");
            string llpstext = "";
            for (int x = 0; x < locallinesperslide.Length; x++)
            {
                llpstext += locallinesperslide[x];
                if (x < locallinesperslide.Length - 1)
                {
                    llpstext += ":";
                }
            }
            llps.InnerText = llpstext;
            setnode.AppendChild(llps);
            source.AppendChild(setnode);
        }

        public string getWriteText()
        {
            generateXmlDocument(false);
            StringWriter sw = new StringWriter();
            XmlTextWriter xtw = new XmlTextWriter(sw);
            source.WriteTo(xtw);
            return sw.ToString();
        }

        /// <summary>
        /// Write the current slide set to file.
        /// </summary>
        public void Write()
        {
            generateXmlDocument(true);
            source.Save(path);
        }
    }
}
