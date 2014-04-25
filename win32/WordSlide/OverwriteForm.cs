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

namespace WordSlide
{
    public partial class OverwriteForm : Form
    {
        public OverwriteForm()
        {
            InitializeComponent();
            this.Text = Resources.OverwriteForm;
            yesButton.Text = Resources.YesButton;
            ytaButton.Text = Resources.YtaButton;
            noButton.Text = Resources.NoButton;
            ntaButton.Text = Resources.NtaButton;
        }

        public void setSongName(string name)
        {
            warningLabel.Text = String.Format(Resources.OverwriteWarning, name);
            warningLabel2.Text = Resources.OverwriteWarningQuestion;
        }
    }
}
