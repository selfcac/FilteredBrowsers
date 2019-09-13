using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NamedPipesHelper
{
    public class Server
    {
        public const string pipeName = "mitm-secret-dispatch";
        private int maxUsers;

        Action<string> log, errorLog;
        public Server(Action<string> LogFunc, Action<string> ErrorLogFunc, int MaxUsers = 100)
        {
            log = LogFunc;
            errorLog = ErrorLogFunc;
            maxUsers = MaxUsers;
        }

        PipeSecurity getSecurity()
        {
            var sid = WindowsIdentity.GetCurrent().User;  // new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            var rule = new PipeAccessRule(sid, PipeAccessRights.FullControl, AccessControlType.Allow);
            var sec = new PipeSecurity();
            sec.AddAccessRule(rule);
            return sec;
        }

        NamedPipeServerStream getServerHandler()
        {
            return new NamedPipeServerStream(
                pipeName,
                PipeDirection.Out,
                maxUsers,
                PipeTransmissionMode.Byte,
                PipeOptions.Asynchronous,
                0, 0,
                getSecurity());
        }

        private bool isRunning = false;
        public void Start()
        {
            isRunning = true;
            acceptNewClientNonBlocking();
        }

        /// <summary>
        /// Open pipes will still wait for client to read. (Pipe impl. not mine!)
        /// </summary>
        public void StopAccepting()
        {
            isRunning = false;
        }

        void acceptNewClientNonBlocking()
        {
            if (!isRunning)
                return;

            log("Waiting for clients...");
            var serverHandler = getServerHandler();
            serverHandler.BeginWaitForConnection(onConnection, serverHandler);
        }

        async void onConnection(IAsyncResult ar)
        {

            this.log("Got new client!");

            NamedPipeServerStream myServer = ar.AsyncState as NamedPipeServerStream;
            if (myServer == null)
                return;

            var logFormat = new Action<string, Action<string>>((text, func) => {
                func(string.Format("[{0}] {1}\t {2}", myServer.GetHashCode(), DateTime.Now, text));
            });
            var log = new Action<string>((text) => logFormat(text, this.log));
            var errorLog = new Action<string>((text) => logFormat(text, this.errorLog));

            try
            {
                myServer.EndWaitForConnection(ar);
                acceptNewClientNonBlocking(); // Make new handlers for upcoming clients

                if (!isRunning)
                    return;

                StreamWriter sw = new StreamWriter(myServer);
                sw.WriteLine("Hello!");
                sw.Flush();
                log("Data sent!");

                await Task.Delay(1000 * 4); // Wait for 4 second 

                if (myServer.IsConnected)
                {
                    log("Closing client after 4 sec.");
                }

                myServer.Disconnect();
                myServer.Close();
            }
            catch (Exception ex)
            {
                errorLog(ex.ToString());
            }
        }
    }
}
