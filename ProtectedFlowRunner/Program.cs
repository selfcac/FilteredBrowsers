using System;
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

            // this.exe <mode> <user> <pass>
            if (args.Length == 4)
            {
                int mode = -1;
                if (int.TryParse(args[1], out mode))
                {
                    if (mode > -1 && mode < 2)
                    {
                        if (mode == 0)
                        {
                            try
                            {
                                // Run as interactive use , with threads protected.
                                IntPtr security = ProcessSecurity.getSecurity(string.Format(
                                    SDDL_AllowOnly_Format, ProcessSecurity.getSidByUserName(args[2])
                                    ));
                                string thisPath = args[0];
                                string startDir = Path.GetDirectoryName(thisPath);

                                murrayju.ProcessExtensions.ProcessExtensions.StartProcessAsCurrentUser(
                                    "",
                                    string.Format("\"{0}\" 1 {1} {2}", thisPath, args[2], args[3]), // Give it user\pass
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
                                        "",
                                         args[2], args[3]
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
                Console.WriteLine("Expectign 4 args: <this> <mode> <user> <pass>");
            }

            Console.ReadLine();
        }
    }
}
