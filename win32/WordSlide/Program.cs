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
using System.Diagnostics;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Security.Principal;
using WordSlideEngine;

namespace WordSlide
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application. Checks for already running instances of the program, 
        /// checks for updates if auto updates are enabled, shows the main form, and opens the appropriate 
        /// sub-form when a button is pressed.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the program.</param>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            WordSlideApplicationContext applicationContext = new WordSlideApplicationContext(new Arguments(args));
            Application.Run(applicationContext);
        } 
    }
}