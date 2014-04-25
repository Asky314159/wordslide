using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordSlideEngine
{
    public class Engine
    {
        public static string ProgramDirectory { get; private set; }
        public static string DataDirectory { get; private set; }
        public static string SlideDirectory { get; private set; }
        public static Version Version { get; private set; }

        //Dirty hacks, ahoy!
        public string UpdatePath { get; set; }

        public static string UpdateServer { get { return "http://wordslide.googlecode.com/svn/vercheck/"; } }

        private string OptionsFile { get { return Path.Combine(DataDirectory, "options.ini"); } }

        public Options Options { get; private set; }

        public Engine()
        {
            this.Initialize();
        }

        private void Initialize()
        {
            ProgramDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            DataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "WordSlide");
            SlideDirectory = Path.Combine(DataDirectory, "slides");
            Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            if (!Directory.Exists(DataDirectory))
                Directory.CreateDirectory(DataDirectory);
            if (!Directory.Exists(SlideDirectory))
                Directory.CreateDirectory(SlideDirectory);
            this.LoadOptions();
        }

        private void LoadOptions()
        {
            this.Options = new Options(this.OptionsFile);
            this.Options.loadFile();
        }

        public static int ShowConfirmDialog(string name)
        {
            //TODO: IMPLEMENT (see Library.cs)
            return 0;
        }
    }
}
