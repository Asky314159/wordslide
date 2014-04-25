using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WordSlideEngine;

namespace WordSlide
{
    class WordSlideApplicationContext : ApplicationContext
    {
        private Mutex wordslideMutex;

        private LauncherForm launcherForm;
        private OptionsForm optionsForm;
        private UpdaterForm updaterForm;
        private EditorForm editorForm;
        private SetupForm setupForm;
        private ScreenSaverForm screenSaverForm;
        private Engine engine;

        public WordSlideApplicationContext(Arguments args)
        {
            if (args.Options.ContainsKey("selfUpdate") && args.Args.Count > 1)
            {
                this.SelfUpdate(args.Args[0], args.Args[1]);
                ExitThread();
            }
            else if (args.Options.ContainsKey("selfUpdateFinish"))
            {
                DateTime startTime = DateTime.Now;
                while (Process.GetProcessesByName("WordSlide").Length > 1 && (DateTime.Now - startTime) < TimeSpan.FromSeconds(20))
                {
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                if (Process.GetProcessesByName("WordSlide").Length > 1)
                {
                    MessageBox.Show("Timed out waiting for previous instance to exit.", "WordSlide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Directory.Exists(args.Options["selfUpdateFinish"]))
                {
                    Directory.Delete(args.Options["selfUpdateFinish"], true);
                }
            }
            bool firstrunning = false;
            this.wordslideMutex = new System.Threading.Mutex(false, "Local\\WordSlide", out firstrunning);
            if (!firstrunning) { ExitThread(); }
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            this.engine = new Engine();
            if (!System.IO.File.Exists(Path.Combine(Engine.DataDirectory, "options.ini")))
            {
                this.engine.Options.AutoUpdate = (MessageBox.Show(string.Format("WordSlide can check for updates automatically on launch.{0}Would you like to enable auto updates?", Environment.NewLine), "WordSlide", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes);
                this.engine.Options.saveFile();
            }
            
            if (args.Args.Count > 0 && File.Exists(args.Args[0]))
            {
                this.optionsForm = new OptionsForm(engine);
                this.optionsForm.importLibrary(args.Args[0]);
            }
            if (this.engine.Options.AutoUpdate)
            {
                this.updaterForm = new UpdaterForm(engine);
                this.updaterForm.checkForUpdate(new AutoUpdateDelegate(AutoUpdateFinished));
            }

            this.ShowLauncherForm();
        }

        private void launcherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (this.launcherForm.DialogResult)
            {
                case DialogResult.OK:
                    this.setupForm = new SetupForm();
                    this.setupForm.FormClosing += new FormClosingEventHandler(setupForm_FormClosing);
                    this.setupForm.Show();
                    break;
                case DialogResult.Yes:
                    this.editorForm = new EditorForm();
                    this.editorForm.FormClosing += new FormClosingEventHandler(editorForm_FormClosing);
                    this.editorForm.Show();
                    break;
                case DialogResult.No:
                    this.optionsForm = new OptionsForm(engine);
                    this.optionsForm.FormClosing += new FormClosingEventHandler(optionsForm_FormClosing);
                    this.optionsForm.Show();
                    break;
                default:
                    ExitThread();
                    break;
            }
            this.launcherForm.DialogResult = DialogResult.None;
        }

        private void setupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.setupForm.DialogResult == DialogResult.OK)
            {
                this.screenSaverForm = new ScreenSaverForm(0, this.setupForm.selectedslideslist, this.engine);
                this.screenSaverForm.FormClosing += new FormClosingEventHandler(screenSaverForm_FormClosing);
                this.screenSaverForm.Show();
            }
            else
            {
                this.ShowLauncherForm();
            }
        }

        private void screenSaverForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cursor.Show();
            this.ShowLauncherForm();
        }

        private void editorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ShowLauncherForm();
        }

        private void optionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.optionsForm.DialogResult == DialogResult.Abort)
            {
                this.CloseForUpdate();
            }
            else
            {
                this.ShowLauncherForm();
            }
        }

        private void ShowLauncherForm()
        {
            this.launcherForm = new LauncherForm();
            this.launcherForm.FormClosing += new FormClosingEventHandler(launcherForm_FormClosing);
            this.launcherForm.Show();
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            Library.writeCurrentLibrary();
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            this.ReportError(e.ExceptionObject as Exception);
        }

        private void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            this.ReportError(e.Exception);
        }

        private void ReportError(Exception e)
        {
            File.AppendAllText(Path.Combine(Engine.DataDirectory, "crashlog"), string.Format("WordSlide {1} - {2}{0}------------------------------{0}{3}{0}", Environment.NewLine, Engine.Version.ToString(), DateTime.Now.ToString("MMMM d yyyy HH mm"), (e != null ? e.ToString() : "Unknown exception")));
        }

        private void CloseForUpdate()
        {
            Process updateProcess = new Process();
            ProcessStartInfo updateProcessStartInfo = new ProcessStartInfo();
            if (IsUacEnabled() && !IsRunningElevated())
            {
                updateProcessStartInfo.Verb = "runas";
            }
            updateProcessStartInfo.FileName = Path.Combine(this.engine.UpdatePath, "WordSlide.exe");
            updateProcessStartInfo.Arguments = string.Format("--selfUpdate \"{0}\" \"{1}\"", this.engine.UpdatePath, Engine.ProgramDirectory);
            updateProcess.StartInfo = updateProcessStartInfo;
            updateProcess.Start();
            ExitThread();
        }

        private void AutoUpdateFinished()
        {
            if (this.updaterForm.ShowDialog() == DialogResult.OK)
            {
                this.CloseForUpdate();
            }
        }

        private static bool IsUacEnabled()
        {
            return Convert.ToInt32(Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry64).OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System").GetValue("EnableLUA", 0)) != 0;
        }

        private static bool IsRunningElevated()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void SelfUpdate(string source, string destination)
        {
            DateTime startTime = DateTime.Now;
            while (Process.GetProcessesByName("WordSlide").Length > 1 && (DateTime.Now - startTime) < TimeSpan.FromSeconds(20))
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            if (Process.GetProcessesByName("WordSlide").Length > 1)
            {
                MessageBox.Show("Timed out waiting for previous instance to exit.", "WordSlide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (string file in Directory.EnumerateFiles(source))
                {
                    File.Copy(file, Path.Combine(destination, Path.GetFileName(file)), true);
                }
                Process relaunchProcess = new Process();
                ProcessStartInfo relaunchProcessStartInfo = new ProcessStartInfo();
                relaunchProcessStartInfo.FileName = Path.Combine(destination, "WordSlide.exe");
                relaunchProcessStartInfo.Arguments = string.Format("--selfUpdateFinish=\"{0}\"", source);
                relaunchProcess.StartInfo = relaunchProcessStartInfo;
                relaunchProcess.Start();
            }
        }
    }
}
