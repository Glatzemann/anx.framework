#region Using Statements
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ProjectConverter.GUI;
using ProjectConverter.Platforms;

#endregion

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ProjectConverter
{
    static class Program
    {
        public static Converter[] Converters;

        public static IEnumerable<string> Switches
        {
            get
            {
                return switches;
            }
        }

        public static IEnumerable<KeyValuePair<string, string>> KeyValueParameters
        {
            get
            {
                return keyValueParameters;
            }
        }

        private static readonly List<string> switches = new List<string>();
        private static readonly Dictionary<string, string> keyValueParameters = new Dictionary<string, string>();
        private static readonly List<string> files = new List<string>();

        [STAThread]
        static void Main(string[] args)
        {
            Converters = new Converter[]
            {
                new LinuxConverter(),
                new MetroConverter(),
                new PsVitaConverter(),
                new AnxConverter(),
                new XnaConverter(),
                new XnaContentProjectConverter(),
                new AnxContentProjectConverter(),
            };

            //
            // To restore "old" behaviour use:
            //   ProjectConverter /linux /psvita /windowsmetro ../../ANX.Framework.sln
            //

            Directory.SetCurrentDirectory(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location));

            if (args.Length == 0)
            {
                using (var gui = new MainWindow())
                {
                    Application.EnableVisualStyles();
                    gui.ShowDialog();
                }
                return;
            }

            foreach (string arg in args)
            {
                string larg = arg.Trim();
                if (larg.StartsWith("/") || larg.StartsWith("-"))
                {
                    larg = larg.Substring(1);
                    if (larg.Contains("="))
                    {
                        string[] parts = larg.Split('=');
                        keyValueParameters[parts[0].Trim().ToLowerInvariant()] = parts[1].Trim().ToLowerInvariant();
                    }
                    else
                    {
                        switches.Add(larg.Trim().ToLowerInvariant());
                    }
                }
                else if (File.Exists(larg))
                {
                    files.Add(larg);
                }
            }

            foreach (string file in files)
            {
                string fileExt = Path.GetExtension(file).ToLowerInvariant();
                foreach (Converter converter in Converters)
                {
                    if (switches.Contains(converter.Name.ToLowerInvariant()))
                    {
                        switch (fileExt)
                        {
                            case ".sln":
                                converter.ConvertAllProjects(file, TryGetDestinationPath());
                                break;
                            case ".csproj":
                            case ".contentproj":
                                converter.ConvertProject(file, TryGetDestinationPath());
                                break;
                            case ".cproj":
                                converter.ConvertAnxContentProject(file, TryGetDestinationPath());
                                break;
                            default:
                                throw new NotImplementedException("unsupported file type '" + fileExt + "'");
                        }
                    }
                }
            }
        }

        private static string TryGetDestinationPath()
        {
            foreach (KeyValuePair<string, string> kvp in keyValueParameters)
            {
                if (string.Equals(kvp.Key, "O", StringComparison.InvariantCultureIgnoreCase))
                {
                    return Path.GetDirectoryName(kvp.Value);
                }
            }

            return string.Empty;
        }
    }
}
