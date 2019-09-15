﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedFlowRunner
{
    class Program
    {
        const string SDDL_AllowOnly_Format = "D:P(A;OICI;GA;;;{0})";

        static void Main(string[] args)
        {
            Console.WriteLine("Arguments:");
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(string.Format("* [{0}] {1}",i, args[i]));
            }

            string thisPath = System.Reflection.Assembly.GetEntryAssembly().Location;

            // this.exe <mode> <user> <pass>
            if (args.Length == 3)
            {
                int mode = -1;
                if (int.TryParse(args[0], out mode))
                {
                    if (mode > -1 && mode < 2)
                    {
                        if (mode == 0)
                        {
                            try
                            {
                                // Run as interactive use , with threads protected.
                                IntPtr security = ProcessSecurity.getSecurity(string.Format(
                                    SDDL_AllowOnly_Format, ProcessSecurity.getSidByUserName(args[1])
                                    ));
                                string startDir = Path.GetDirectoryName(thisPath);

                                murrayju.ProcessExtensions.ProcessExtensions.StartProcessAsCurrentUser(
                                    "",
                                    string.Format("\"{0}\" 1 {1} {2}", thisPath, args[1], args[2]), // Give it user\pass
                                    startDir, security, true);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }
                        else if (mode ==1)
                        {
                            // Run as a different user
                            try
                            {
                                murrayju.ProcessExtensions.ProcessExtensions.StartProcessAsUserInSameDesktop(
                                        ProtectedFlowRunner.Properties.Settings.Default.protectedExe,
                                        Path.GetDirectoryName(ProtectedFlowRunner.Properties.Settings.Default.protectedExe),
                                        "",
                                         args[1], args[2]
                                    );
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Mode must be: \n(0) Protected process from service \nOR \n(1) Process under another user !");
                    }

                }
                else
                {
                    Console.WriteLine("Can't parse mode!");
                }
            }
            else
            {
                Console.WriteLine("Expectign 3 args:  <mode> <user> <pass>");
            }

            Console.ReadLine();
        }
    }
}