// Copyright © 2010 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.Example;
using CefSharp.Example.Callback;
using CefSharp.Example.Handlers;
//using FilteredCommon.DataStructure;
using FilteredEdgeBrowser.Utils;


namespace CefSharp.WinForms.Example
{
    public partial class BrowserForm : Form
    {
        private const string DefaultUrlForAddedTabs = "https://www.google.com";

        // Default to a small increment:
        private const double ZoomIncrement = 0.10;

        private bool multiThreadedMessageLoopEnabled;

        public BrowserForm(bool multiThreadedMessageLoopEnabled)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            Load += BrowserFormLoad;

            //Only perform layout when control has completly finished resizing
            ResizeBegin += (s, e) => SuspendLayout();
            ResizeEnd += (s, e) => ResumeLayout(true);

            this.multiThreadedMessageLoopEnabled = multiThreadedMessageLoopEnabled;
        }

        public IContainer Components
        {
            get
            {
                if (components == null)
                {
                    components = new Container();
                }

                return components;
            }
        }

        private void BrowserFormLoad(object sender, EventArgs e)
        {
            AddTab(DefaultUrlForAddedTabs);
        }

        /// <summary>
        /// Used to add a Popup browser as a Tab
        /// </summary>
        /// <param name="browserHostControl"></param>
        public void AddTab(Control browserHostControl, string url)
        {
            browserTabControl.SuspendLayout();

            var tabPage = new TabPage(BrowserTabUserControl.CroppedText(url))
            {
                Dock = DockStyle.Fill
            };

            tabPage.Controls.Add(browserHostControl);

            browserTabControl.TabPages.Add(tabPage);

            //Make newly created tab active
            browserTabControl.SelectedTab = tabPage;

            browserTabControl.ResumeLayout(true);
        }

        private void AddTab(string url, int? insertIndex = null)
        {
            browserTabControl.SuspendLayout();

            var browser = new BrowserTabUserControl(AddTab, url, multiThreadedMessageLoopEnabled)
            {
                Dock = DockStyle.Fill,
            };

            var tabPage = new TabPage(BrowserTabUserControl.CroppedText(url))
            {
                Dock = DockStyle.Fill
            };

            //This call isn't required for the sample to work. 
            //It's sole purpose is to demonstrate that #553 has been resolved.
            browser.CreateControl();

            tabPage.Controls.Add(browser);

            if (insertIndex == null)
            {
                browserTabControl.TabPages.Add(tabPage);
            }
            else
            {
                browserTabControl.TabPages.Insert(insertIndex.Value, tabPage);
            }

            //Make newly created tab active
            browserTabControl.SelectedTab = tabPage;

            browserTabControl.ResumeLayout(true);
        }

        private void ExitMenuItemClick(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void ExitApplication()
        {
            Close();
        }

        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        public void RemoveTab(IntPtr windowHandle)
        {
            var parentControl = FromChildHandle(windowHandle);
            if (!parentControl.IsDisposed)
            {
                if (parentControl.Parent is TabPage tabPage)
                {
                    browserTabControl.TabPages.Remove(tabPage);
                }
                else if (parentControl.Parent is Panel panel)
                {
                    var browserTabUserControl = (BrowserTabUserControl)panel.Parent;

                    var tab = (TabPage)browserTabUserControl.Parent;
                    browserTabControl.TabPages.Remove(tab);
                }
            }
        }

        private void FindMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.ShowFind();
            }
        }

        private void CopySourceToClipBoardAsyncClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.CopySourceToClipBoardAsync();
            }
        }

        private BrowserTabUserControl GetTabControl(int index)
        {
            if (index < 0 || browserTabControl.TabCount <= index)
            {
                return null;
            }

            var tabPage = browserTabControl.Controls[index];
            var control = tabPage.Controls[0] as BrowserTabUserControl;

            return control;
        }

        private BrowserTabUserControl GetCurrentTabControl()
        {
            return GetTabControl(browserTabControl.SelectedIndex);
        }

        private void NewTabToolStripMenuItemClick(object sender, EventArgs e)
        {
            AddTab(DefaultUrlForAddedTabs);
        }

        private void CloseTabToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (browserTabControl.TabPages.Count == 0)
            {
                return;
            }

            var currentIndex = browserTabControl.SelectedIndex;
            DisposeTab(currentIndex);

            browserTabControl.SelectedIndex = Math.Max(currentIndex - 1,0);

            if (browserTabControl.TabPages.Count == 0)
            {
                ExitApplication();
            }
        }

        private void DisposeTab(int tabIndex)
        {
            if (tabIndex < 0 || tabIndex >= browserTabControl.TabCount)
                return;

            var tabPage = browserTabControl.TabPages[tabIndex];

            var control = GetTabControl(tabIndex);
            if (control != null && !control.IsDisposed)
            {
                control.Dispose();
            }
            browserTabControl.TabPages.Remove(tabPage);

            tabPage.Dispose();
        }

        private void UndoMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.Undo();
            }
        }

        private void RedoMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.Redo();
            }
        }

        private void CutMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.Cut();
            }
        }

        private void CopyMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.Copy();
            }
        }

        private void PasteMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.Paste();
            }
        }

        private void DeleteMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.Delete();
            }
        }

        private void SelectAllMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.SelectAll();
            }
        }

        private void PrintToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.Print();
            }
        }

        private async void ShowDevToolsMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                var isDevToolsOpen = await control.CheckIfDevToolsIsOpenAsync();
                if (!isDevToolsOpen)
                {
                    control.Browser.ShowDevTools();
                }
            }
        }

        private async void ShowDevToolsDockedMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                var isDevToolsOpen = await control.CheckIfDevToolsIsOpenAsync();
                if (!isDevToolsOpen)
                {
                    if (control.Browser.LifeSpanHandler != null)
                    {
                        control.ShowDevToolsDocked();
                    }
                }
            }
        }

        private async void CloseDevToolsMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                //Check if DevTools is open before closing, this isn't strictly required
                //If DevTools isn't open and you call CloseDevTools it's a No-Op, so prefectly
                //safe to call without checking
                var isDevToolsOpen = await control.CheckIfDevToolsIsOpenAsync();
                if (isDevToolsOpen)
                {
                    control.Browser.CloseDevTools();
                }
            }
        }

        private void ZoomInToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                var task = control.Browser.GetZoomLevelAsync();

                task.ContinueWith(previous =>
                {
                    if (previous.Status == TaskStatus.RanToCompletion)
                    {
                        var currentLevel = previous.Result;
                        control.Browser.SetZoomLevel(currentLevel + ZoomIncrement);
                    }
                    else
                    {
                        throw new InvalidOperationException("Unexpected failure of calling CEF->GetZoomLevelAsync", previous.Exception);
                    }
                }, TaskContinuationOptions.ExecuteSynchronously);
            }
        }

        private void ZoomOutToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                var task = control.Browser.GetZoomLevelAsync();
                task.ContinueWith(previous =>
                {
                    if (previous.Status == TaskStatus.RanToCompletion)
                    {
                        var currentLevel = previous.Result;
                        control.Browser.SetZoomLevel(currentLevel - ZoomIncrement);
                    }
                    else
                    {
                        throw new InvalidOperationException("Unexpected failure of calling CEF->GetZoomLevelAsync", previous.Exception);
                    }
                }, TaskContinuationOptions.ExecuteSynchronously);
            }
        }

        private void CurrentZoomLevelToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                var task = control.Browser.GetZoomLevelAsync();
                task.ContinueWith(previous =>
                {
                    if (previous.Status == TaskStatus.RanToCompletion)
                    {
                        var currentLevel = previous.Result;
                        MessageBox.Show("Current ZoomLevel: " + currentLevel.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Unexpected failure of calling CEF->GetZoomLevelAsync: " + previous.Exception.ToString());
                    }
                }, TaskContinuationOptions.HideScheduler);
            }
        }

        private void DoesActiveElementAcceptTextInputToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                var frame = control.Browser.GetFocusedFrame();

                //Execute extension method
                frame.ActiveElementAcceptsTextInput().ContinueWith(task =>
                {
                    string message;
                    var icon = MessageBoxIcon.Information;
                    if (task.Exception == null)
                    {
                        var isText = task.Result;
                        message = string.Format("The active element is{0}a text entry element.", isText ? " " : " not ");
                    }
                    else
                    {
                        message = string.Format("Script evaluation failed. {0}", task.Exception.Message);
                        icon = MessageBoxIcon.Error;
                    }

                    MessageBox.Show(message, "Does active element accept text input", MessageBoxButtons.OK, icon);
                });
            }
        }

        private void DoesElementWithIdExistToolStripMenuItemClick(object sender, EventArgs e)
        {
            // This is the main thread, it's safe to create and manipulate form
            // UI controls.
            var dialog = new InputBox
            {
                Instructions = "Enter an element ID to find.",
                Title = "Find an element with an ID"
            };

            dialog.OnEvaluate += (senderDlg, eDlg) =>
            {
                // This is also the main thread.
                var control = GetCurrentTabControl();
                if (control != null)
                {
                    var frame = control.Browser.GetFocusedFrame();

                    //Execute extension method
                    frame.ElementWithIdExists(dialog.Value).ContinueWith(task =>
                    {
                        // Now we're not on the main thread, perhaps the
                        // Cef UI thread. It's not safe to work with
                        // form UI controls or to block this thread.
                        // Queue up a delegate to be executed on the
                        // main thread.
                        BeginInvoke(new Action(() =>
                        {
                            string message;
                            if (task.Exception == null)
                            {
                                message = task.Result.ToString();
                            }
                            else
                            {
                                message = string.Format("Script evaluation failed. {0}", task.Exception.Message);
                            }

                            dialog.Result = message;
                        }));
                    });
                }
            };

            dialog.Show(this);
        }

        private void GoToDemoPageToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.Load("custom://cefsharp/ScriptedMethodsTest.html");
            }
        }

        private void InjectJavascriptCodeToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                var frame = control.Browser.GetFocusedFrame();

                //Execute extension method
                frame.ListenForEvent("test-button", "click");
            }
        }

        private static readonly Regex removeInvalidChars = new Regex($"[{Regex.Escape(new string(Path.GetInvalidFileNameChars()))}]",
            RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);

        public static string SanitizedFileName(string fileName, string replacement = "_")
        {
            if (string.IsNullOrEmpty(fileName))
                return fileName;
            return removeInvalidChars.Replace(fileName, replacement);
        }

        private async void PrintToPdfToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                var filename = SanitizedFileName((browserTabControl.SelectedTab?.Text ?? "No title") + "_" + DateTime.Now)  + ".pdf";
                filename = Path.Combine(CefSharp.WinForms.Example.Properties.Settings.Default.saveFolder, filename);

                var success = await control.Browser.PrintToPdfAsync(filename, new PdfPrintSettings
                {
                    BackgroundsEnabled = includeBackgroundToolStripMenuItem.Checked,
                    SelectionOnly = selectionOnlyToolStripMenuItem1.Checked
                });

                if (success)
                {
                    MessageBox.Show("Pdf was saved to\n" + filename);
                }
                else
                {
                    MessageBox.Show("Unable to save Pdf, check you have write permissions to\n" + filename);
                }
            }
        }

        private void OpenDataUrlToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                const string html = "<html><head><title>Test</title></head><body><h1>Html Encoded in URL!</h1></body></html>";
                control.Browser.LoadHtml(html, false);
            }
        }

        private void OpenHttpBinOrgToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.Load("https://httpbin.org/");
            }
        }

        private void RunFileDialogToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.GetBrowserHost().RunFileDialog(CefFileDialogMode.Open, "Open", null, new List<string> { "*.*" }, 0, new RunFileDialogCallback());
            }
        }

        private void LoadExtensionsToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                //The sample extension only works for http(s) schemes
                if (control.Browser.Address.StartsWith("http"))
                {
                    var requestContext = control.Browser.GetBrowserHost().RequestContext;

                    var dir = Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\CefSharp.Example\Extensions");
                    dir = Path.GetFullPath(dir);
                    if (!Directory.Exists(dir))
                    {
                        throw new DirectoryNotFoundException("Unable to locate example extensions folder - " + dir);
                    }

                    var extensionHandler = new ExtensionHandler
                    {
                        LoadExtensionPopup = (url) =>
                        {
                            BeginInvoke(new Action(() =>
                            {
                                var extensionForm = new Form();

                                var extensionBrowser = new ChromiumWebBrowser(url);
                                //extensionBrowser.IsBrowserInitializedChanged += (s, args) =>
                                //{
                                //    extensionBrowser.ShowDevTools();
                                //};

                                extensionForm.Controls.Add(extensionBrowser);

                                extensionForm.Show(this);
                            }));
                        },
                        GetActiveBrowser = (extension, isIncognito) =>
                        {
                            //Return the active browser for which the extension will act upon
                            return control.Browser.GetBrowser();
                        }
                    };

                    requestContext.LoadExtensionsFromDirectory(dir, extensionHandler);
                }
                else
                {
                    MessageBox.Show("The sample extension only works with http(s) schemes, please load a different website and try again", "Unable to load Extension");
                }
            }
        }

        private void JavascriptBindingStressTestToolStripMenuItemClick(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.Load(CefExample.BindingTestUrl);
                control.Browser.LoadingStateChanged += (o, args) =>
                {
                    if (args.IsLoading == false)
                    {
                        Task.Delay(10000).ContinueWith(t =>
                        {
                            if (control.Browser != null)
                            {
                                control.Browser.Reload();
                            }
                        });
                    }
                };
            }
        }

        private void downloadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DownloadManager.Instance.Show();
        }


        private void BrowserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DownloadManager.Instance.Close();
        }

        private void addTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab(DefaultUrlForAddedTabs);
        }


        private void CloseToLeft(int currentIndex)
        {
            if (currentIndex > -1)
            {
                for (int i = 0; i < currentIndex; i++)
                {
                    DisposeTab(0);
                }
            }
        }

        private void CloseToRight(int currentIndex)
        {

            if (currentIndex > -1)
            {
                for (int i = browserTabControl.TabPages.Count - 1; i > currentIndex; i--) // reverse 
                {
                    DisposeTab(i);
                }
            }
        }


        private void closeTabIconMenuItem1_Click(object sender, EventArgs e)
        {
            if (browserTabControl.TabPages.Count == 0)
            {
                return;
            }

            var currentIndex = browserTabControl.SelectedIndex;
            DisposeTab(currentIndex);
            browserTabControl.SelectedIndex = Math.Max(currentIndex - 1, 0);

            if (browserTabControl.TabPages.Count == 0)
            {
                ExitApplication();
            }
        }

        private void closeToLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (browserTabControl.TabPages.Count == 0)
            {
                return;
            }

            int tabIndex = browserTabControl.SelectedIndex; // remember because might change
            CloseToLeft(tabIndex);
        }

        private void closeToRightToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (browserTabControl.TabPages.Count == 0)
            {
                return;
            }

            int tabIndex = browserTabControl.SelectedIndex; // remember because might change
            CloseToRight(tabIndex);
        }

        private void closeOthersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (browserTabControl.TabPages.Count == 0)
            {
                return;
            }

            if (browserTabControl.SelectedIndex > -1)
            {
                CloseToLeft(browserTabControl.SelectedIndex);
                CloseToRight(0);
            }
        }



        public static HTTPProtocolFilter.FilterPolicy httpPolicy = new HTTPProtocolFilter.FilterPolicy();
        public static TimeBlockFilter.TimeFilterObject timePolicy = new TimeBlockFilter.TimeFilterObject();

        public static LogFileHandler historyLog, bookmarkLog;

        private void resetZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var control = GetCurrentTabControl();
            if (control != null)
            {
                control.Browser.SetZoomLevel(0.0);
            }
        }

        bool isDebug = false;

        private void entirePAgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectionOnlyToolStripMenuItem1.Checked = false;
        }

        private void selectionOnlyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            entirePAgeToolStripMenuItem.Checked = false;
        }

        private void BrowserForm_Load(object sender, EventArgs e)
        {
            // Init download window:
            DownloadManager.Instance.Show();
            DownloadManager.Instance.Hide();

            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string historyPath = Path.Combine(appdata, "FilteredChromeBrowser", "history.log.txt");
            if (!File.Exists(historyPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(historyPath));
                File.AppendAllText(historyPath, "");
            }

            string bookmarkPath = Path.Combine(appdata, "FilteredChromeBrowser", "bookmark.log.txt");
            if (!File.Exists(bookmarkPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(bookmarkPath));
                File.AppendAllText(bookmarkPath, "");
            }

            historyLog = new LogFileHandler(historyPath);
            bookmarkLog = new LogFileHandler(bookmarkPath);

            if (isDebug)
            {
                httpPolicy.proxyMode = HTTPProtocolFilter.WorkingMode.MAPPING;
                timePolicy.clearAllTo(true);
                MessageBox.Show("In debug mode! Filtering is off!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string httpPolicyPath = CefSharp.WinForms.Example.Properties.Settings.Default.httpPolicyPath;
                string timePolicyPath = CefSharp.WinForms.Example.Properties.Settings.Default.timePolicyPath;

                if (!File.Exists(httpPolicyPath))
                {
                    MessageBox.Show("Can't open http policy\n" + httpPolicyPath);
                    Process.GetCurrentProcess().Kill();
                }
                else if (!File.Exists(timePolicyPath))
                {
                    MessageBox.Show("Can't open time policy\n" + timePolicyPath);
                    Process.GetCurrentProcess().Kill();
                }

                httpPolicy.reloadPolicy(httpPolicyPath);
                timePolicy.reloadPolicy(timePolicyPath);
            }


            string saveFolderPath = CefSharp.WinForms.Example.Properties.Settings.Default.saveFolder;
            if (!Directory.Exists(saveFolderPath))
            {
                MessageBox.Show("Can't access save folder\n" + saveFolderPath);
                Process.GetCurrentProcess().Kill();
            }
           

            var bitness = Environment.Is64BitProcess ? "x64" : "x86";
            Text += " - " + bitness;

            // Read bypass secret from file:
            AddSecretHandler.BypassSecret = CefSharp.WinForms.Example.Properties.Settings.Default.bypassSecret;
        }
    }
}
