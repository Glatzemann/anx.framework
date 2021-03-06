using System;
using System.Reflection;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace StockShaderCodeGenerator
{
    class Program
    {
        internal static ConsoleTraceListener TraceListener = new ConsoleTraceListener();

        static void Main(string[] args)
        {
            foreach (string arg in args)
            {
                if (String.Equals(arg, "/silent", StringComparison.InvariantCultureIgnoreCase))
                {
                    ConsoleTraceListener.Silence = true;
                }
            }

            TraceListener.WriteLine("ANX.Framework StockShaderCodeGenerator (sscg) Version " +
                Assembly.GetExecutingAssembly().GetName().Version);

            string buildFile;

            if (args.Length < 1)
            {
                TraceListener.WriteLine("No command line arguments provided. Trying to load build.xml from current directory.");
                buildFile = "build.xml";
            }
            else
            {
                buildFile = args[0];
            }

            TraceListener.WriteLine("Creating configuration using '{0}' configuration file.", buildFile);

            Configuration.LoadConfiguration(buildFile);

            if (Configuration.ConfigurationValid)
            {
                if (Compiler.GenerateShaders())
                {
                    CodeGenerator.Generate();
                }
                else
                {
                    TraceListener.WriteLine("error while compiling shaders. Code generation skipped...");
                }
            }
        }
    }
}
