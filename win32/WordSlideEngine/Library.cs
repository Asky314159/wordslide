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
using System.IO;
using WordSlideEngine;

namespace WordSlideEngine
{
    public class Library
    {
        private static string[] currentLibrary;
        private static bool libraryLoaded = false;
        private const byte slmFileVersion = 2;

        public static string[] ReadLibraryContents(string libraryPath)
        {
            BinaryReader reader = new BinaryReader(new FileStream(libraryPath, FileMode.Open));
            reader.ReadByte();
            int count = reader.ReadInt32();
            string[] names = new string[count];
            for (int x = 0; x < count; x++)
            {
                names[x] = reader.ReadString();
            }
            reader.Close();
            return names;
        }

        public static void ImportSetsFromLibrary(string libraryPath, string[] sets)
        {
            BinaryReader reader = new BinaryReader(new FileStream(libraryPath, FileMode.Open));
            reader.ReadByte();
            int count = reader.ReadInt32();
            //The contents table has already been read, so we can skip it.
            for (int x = 0; x < count; x++)
            {
                reader.ReadString();
            }
            string[] xml = new string[count];
            for (int x = 0; x < count; x++)
            {
                xml[x] = reader.ReadString();
            }
            reader.Close();
            bool yes = false;
            bool no = false;
            //OverwriteForm of = new OverwriteForm();
            string temppath = Path.Combine(Engine.DataDirectory, "temp.sld");
            for (int x = 0; x < count; x++)
            {
                StreamWriter tempout = new StreamWriter(new FileStream(temppath, FileMode.Create));
                tempout.Write(xml[x]);
                tempout.Flush();
                tempout.Close();
                EditableSlideSet tempess = new EditableSlideSet(temppath);
                tempess.loadFile();
                tempess.resetPath();
                if (((IList<string>)sets).Contains(tempess.Name))
                {
                    if (File.Exists(tempess.Path))
                    {
                        if (yes)
                        {
                            tempess.Write();
                            addToLibrary(tempess.Name);
                        }
                        else if (no)
                        {
                        }
                        else
                        {
                            //of.setSongName(tempess.Name);
                            switch (Engine.ShowConfirmDialog(tempess.Name))//of.ShowDialog())
                            {
                                case 0://System.Windows.Forms.DialogResult.Retry:
                                    yes = true;
                                    tempess.Write();
                                    addToLibrary(tempess.Name);
                                    break;
                                case 1://System.Windows.Forms.DialogResult.Yes:
                                    tempess.Write();
                                    addToLibrary(tempess.Name);
                                    break;
                                case 2://System.Windows.Forms.DialogResult.Abort:
                                    no = true;
                                    break;
                                case 3://System.Windows.Forms.DialogResult.No:
                                    break;
                            }
                        }
                    }
                    else
                    {
                        tempess.Write();
                        addToLibrary(tempess.Name);
                    }
                }
                File.Delete(temppath);
            }
        }

        public static void ImportLibrary(string libraryPath)
        {
            ImportSetsFromLibrary(libraryPath, ReadLibraryContents(libraryPath));
        }

        public static void ExportLibrary(string libraryPath, string[] fileToInclude)
        {
            BinaryWriter writer = new BinaryWriter(new FileStream(libraryPath, FileMode.Create));
            writer.Write(slmFileVersion);
            writer.Write(fileToInclude.Length);
            EditableSlideSet[] temp = new EditableSlideSet[fileToInclude.Length];
            for (int x = 0; x < fileToInclude.Length; x++)
            {
                temp[x] = new EditableSlideSet(fileToInclude[x]);
                writer.Write(temp[x].Name);
            }
            for (int x = 0; x < fileToInclude.Length; x++)
            {
                temp[x].loadFile();
                writer.Write(temp[x].getWriteText());
            }
            writer.Flush();
            writer.Close();
        }

        public static string[] getCurrentLibraryList()
        {
            if (!libraryLoaded)
            {
                if (File.Exists(Path.Combine(Engine.DataDirectory, "current.slm")))
                {
                    BinaryReader reader = new BinaryReader(new FileStream(Path.Combine(Engine.DataDirectory, "current.slm"), FileMode.Open));
                    int count = reader.ReadInt32();
                    if (count == Directory.GetFiles(Engine.SlideDirectory, "*.sld", SearchOption.TopDirectoryOnly).Length)
                    {
                        currentLibrary = new string[count];
                        for (int x = 0; x < count; x++)
                        {
                            currentLibrary[x] = reader.ReadString();
                        }
                    }
                    else
                    {
                        loadCurrentLibrary();
                    }
                    reader.Close();
                }
                else
                {
                    loadCurrentLibrary();
                }
                libraryLoaded = true;
                Array.Sort(currentLibrary);
            }
            return currentLibrary;
        }

        private static void loadCurrentLibrary()
        {
            string[] files = Directory.GetFiles(Engine.SlideDirectory, "*.sld", SearchOption.TopDirectoryOnly);
            currentLibrary = new string[files.Length];
            EditableSlideSet temp;
            for (int x = 0; x < files.Length; x++)
            {
                temp = new EditableSlideSet(files[x]);
                currentLibrary[x] = temp.ToString();
            }
        }

        public static void addToLibrary(string name)
        {
            if (Array.FindIndex<string>(currentLibrary, name.Equals) == -1)
            {
                Array.Resize<string>(ref currentLibrary, currentLibrary.Length + 1);
                currentLibrary[currentLibrary.Length - 1] = name;
                Array.Sort(currentLibrary);
            }
        }

        public static void removeFromLibrary(string name)
        {
            int index = -1;
            for (int x = 0; x < currentLibrary.Length; x++)
            {
                if (currentLibrary[x].Equals(name))
                {
                    index = x;
                    break;
                }
            }
            if (index != -1)
            {
                for (int x = index; x < currentLibrary.Length - 1; x++)
                {
                    currentLibrary[x] = currentLibrary[x + 1];
                }
                Array.Resize<string>(ref currentLibrary, currentLibrary.Length - 1);
            }
        }

        public static void writeCurrentLibrary()
        {
            if (libraryLoaded)
            {
                BinaryWriter writer = new BinaryWriter(new FileStream(Path.Combine(Engine.DataDirectory, "current.slm"), FileMode.Create));
                writer.Write(currentLibrary.Length);
                for (int x = 0; x < currentLibrary.Length; x++)
                {
                    writer.Write(currentLibrary[x]);
                }
                writer.Flush();
                writer.Close();
            }
        }
    }
}
