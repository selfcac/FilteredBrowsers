// Copyright © 2010-2015 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using CefSharp.WinForms;
using System;
using System.IO;
using System.Windows.Forms;

namespace CefSharp.MinimalExample.WinForms
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            //System.Diagnostics.Debugger.Launch();

            //Monitor parent process exit and close subprocesses if parent process exits first
            //This will at some point in the future becomes the default
            //CefSharpSettings.SubprocessExitIfParentProcessClosed = true;

            //For Windows 7 and above, best to include relevant app.manifest entries as well
            //Cef.EnableHighDPISupport();
            CefSettings Settings = new CefSettings();

            try
            {
                string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string cachePath = Path.Combine(appdata, "FilteredChromeBrowser62", "cache");
                if (!Directory.Exists(cachePath))
                {
                    Directory.CreateDirectory(cachePath);
                }

                Settings.CachePath = cachePath;  //always set the cachePath, else this wont work
                Settings.CefCommandLineArgs.Add("no-proxy-server", "1");

                //Example of setting a command line argument
                //Enables WebRTC
                Settings.CefCommandLineArgs.Add("enable-media-stream", "1");
            }
            catch (Exception ex) 
            {
                
            }

            //Perform dependency check to make sure all relevant resources are in our output directory.
            Cef.Initialize(Settings, performDependencyCheck: true, browserProcessHandler: null);

            var browser = new BrowserForm();
            Application.Run(browser);
        }
    }
}
