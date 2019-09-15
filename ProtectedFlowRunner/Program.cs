using SimpleImpersonation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProtectedFlowRunner
{
    class Program
    {
        //http://csharptest.net/1043/how-to-prevent-users-from-killing-your-service-process/index.html
        //PROCESS_CREATE_PROCESS =0x0080
        static string SDDL_AllowOnly_Format = ProtectedFlowRunner.Properties.Settings.Default.SDDL;

        static void Main(string[] args)
        {
            Console.WriteLine("Arguments:");
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(string.Format("* [{0}] {1}",i, args[i]));
            }

            string thisPath =
             System.Reflection.Assembly.GetEntryAssembly().Location;
            //@"C:\WINDOWS\system32\cmd.exe"; 
            
            Console.WriteLine("This exe path: \"" + thisPath +"\"");
            Console.WriteLine("Start dir: \"" + Path.GetDirectoryName(thisPath) + "\"");

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
                                IntPtr security_process = ProcessSecurity.getSecurity(string.Format(
                                    SDDL_AllowOnly_Format, ProcessSecurity.getSidByUserName(args[1])
                                    ));
                                string startDir = Path.GetDirectoryName(thisPath);

                                murrayju.ProcessExtensions.ProcessExtensions.StartProcessAsCurrentUser(
                                    thisPath,
                                    string.Format("\"{0}\" 1 {1} {2}", thisPath, args[1], args[2]), // Give it user\pass
                                    startDir, security_process, null , true);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }
                        else if (mode ==1)
                        {
                            // Run as a different user

                            Console.ReadLine();

                            try
                            {

                                Console.WriteLine("Current user: " + WindowsIdentity.GetCurrent().Name);
                                WrapperImpersonationContext context = new WrapperImpersonationContext(".", "adminusb", "6666");
                                context.Enter();
                                // Execute code under other uses context

                                Console.WriteLine("Current user: " + WindowsIdentity.GetCurrent().Name);
                                SecureString s = new SecureString();
                                foreach (char c in "6666") s.AppendChar(c);
                                var p = Process.Start(ProtectedFlowRunner.Properties.Settings.Default.protectedExe,"adminusb",s,".");
                                p.WaitForExit();

                                context.Leave();
                                Console.WriteLine("Current user: " + WindowsIdentity.GetCurrent().Name);

                                //murrayju.ProcessExtensions.ProcessExtensions.StartProcessAsUserInSameDesktop(
                                //        ProtectedFlowRunner.Properties.Settings.Default.protectedExe,
                                //        Path.GetDirectoryName(ProtectedFlowRunner.Properties.Settings.Default.protectedExe),
                                //        "",
                                //         args[1], args[2]
                                //    );
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
