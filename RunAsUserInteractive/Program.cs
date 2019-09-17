using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunAsUserInteractive
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Arguments:");
            //for (int i = 0; i < args.Length; i++)
            //{
            //    Console.WriteLine("{0}) {1}", i, args[i]);
            //}
            //Console.WriteLine(" ");

            bool isValidCall = false;
            if (args.Length > 1) 
            {
                uint activeSessionId = murrayju.ProcessExtensions.ProcessExtensions.getActiveSession();
                string filename = Environment.ExpandEnvironmentVariables(args[0]);
                if (!File.Exists(filename))
                {
                    Console.WriteLine("[ERROR] Can't find file:\n" + filename);
                }
                else
                {
                    int sepIndex = Environment.CommandLine.IndexOf("--");
                    if (sepIndex == -1)
                    {
                        Console.WriteLine("[ERROR] Can't find seperator arg");
                    }
                    else
                    {
                        isValidCall = true;
                        Process.Start(filename, 
                            Environment.CommandLine.Substring(sepIndex + 2).Replace("{i}",activeSessionId.ToString())
                        );
                        Console.WriteLine("[OK] Process started.");
                    }
                }
            }
            
            if (!isValidCall)
            {
                Console.WriteLine(
                    "\n\nPlease pass target exe and seperator (args optional) \n" + 
                    "{i} will be replaced with active session id\n" +
                    "Example: RunAsUserInteractive.exe <ExeToRun> -- <args>"
                    );
            }

            Console.ReadLine();
        }
    }
}
