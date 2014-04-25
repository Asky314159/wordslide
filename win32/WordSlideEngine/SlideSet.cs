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
    /// Generic SlideSet class used to provide common functionality to EditableSlideSet
    /// and DisplaySlideSet.
    /// </summary>
    public abstract class SlideSet
    {
        protected string name;
        protected string byline;
        protected string copyright;
        protected string[] texts;
        protected int[] order;
        protected int[] locallinesperslide;
        protected string path;
        protected int chorus;
        protected int linesperslide;
        protected XmlDocument source;

        protected void getTitle()
        {
            source = new XmlDocument();
            source.Load(path);
            XmlNodeList title = source.GetElementsByTagName("title");
            name = title[0].InnerText;
        }

        public override string ToString()
        {
            return name;
        }

        public void loadFile()
        {
            source = new XmlDocument();
            source.Load(path);
            readSource();
        }

        public void loadString(string xmlFile)
        {
            source = new XmlDocument();
            source.LoadXml(xmlFile);
            readSource();
        }

        private void readSource()
        {
            XmlNodeList by = source.GetElementsByTagName("by");
            byline = by[0].InnerText;

            XmlNodeList cr = source.GetElementsByTagName("copyright");
            if (cr.Count > 0)
            {
                copyright = cr[0].InnerText;
            }
            else
            {
                copyright = "";
            }

            XmlNodeList chi = source.GetElementsByTagName("chorus");
            if (chi.Count > 0)
            {
                chorus = Int32.Parse(chi[0].InnerText);
            }
            else
            {
                chorus = -1;
            }

            XmlNodeList lps = source.GetElementsByTagName("lps");
            if (lps.Count > 0)
            {
                linesperslide = Int32.Parse(lps[0].InnerText);
            }
            else
            {
                linesperslide = 4;
            }

            XmlNodeList txt = source.GetElementsByTagName("text");
            texts = new string[txt.Count];
            for (int x = 0; x < texts.Length; x++)
            {
                texts[x] = txt[x].InnerText;
            }
            XmlNodeList ord = source.GetElementsByTagName("order");
            string[] list = ord[0].InnerText.Split(':');
            order = new int[list.Length];
            for (int x = 0; x < order.Length; x++)
            {
                order[x] = Int32.Parse(list[x]);
            }
            XmlNodeList llps = source.GetElementsByTagName("llps");
            if (llps.Count == 0)
            {
                locallinesperslide = new int[txt.Count];
                for (int x = 0; x < txt.Count; x++)
                {
                    locallinesperslide[x] = 0;
                }
            }
            else
            {
                string[] llpslist = llps[0].InnerText.Split(':');
                if (llpslist.Length != txt.Count)
                {
                    locallinesperslide = new int[txt.Count];
                    for (int x = 0; x < txt.Count; x++)
                    {
                        locallinesperslide[x] = 0;
                    }
                }
                else
                {
                    locallinesperslide = new int[llpslist.Length];
                    for (int x = 0; x < llpslist.Length; x++)
                    {
                        locallinesperslide[x] = Int32.Parse(llpslist[x]);
                    }
                }
            }
        }
    }
}
