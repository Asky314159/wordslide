using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordSlideEngine
{
    public class Arguments
    {
        public Dictionary<string, string> Options { get; private set; }
        public List<string> Args { get; private set; }

        public Arguments(string[] args)
        {
            this.ParseArgs(args);
        }

        private void ParseArgs(string[] args)
        {
            this.Options = new Dictionary<string, string>();
            this.Args = new List<string>();
            foreach (string arg in args)
            {
                if (arg.StartsWith("--") || arg.StartsWith("/"))
                {
                    string[] option = arg.TrimStart(new char[] { '-', '/' }).Split(new char[] { '=' }, 2, StringSplitOptions.RemoveEmptyEntries);
                    this.Options.Add(option[0], option.Length > 1 ? option[1] : string.Empty);
                }
                else
                {
                    this.Args.Add(arg);
                }
            }
        }
    }
}
