// Copyright © 2010 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.Example;
using CefSharp.Example.Handlers;
using CefSharp.Example.JavascriptBinding;
using CefSharp.WinForms.Example.FilteringChrome;
using CefSharp.WinForms.Example.Handlers;
using CefSharp.WinForms.Internals;
using FilteredEdgeBrowser;

namespace CefSharp.WinForms.Example
{
    public partial class BrowserTabUserControl : UserControl
    {
        public IWinFormsWebBrowser Browser { get; private set; }
        private IntPtr browserHandle;
        private ChromeWidgetMessageInterceptor messageInterceptor;
        private bool multiThreadedMessageLoopEnabled;

        public LifeSpanHandler myLifeSpanHandler;
        private WinFormsRequestHandler myPageNavigationManager;
        private string initialURL = "about:blank";

        public BrowserTabUserControl(Action<string, int?> openNewTab, string url, bool multiThreadedMessageLoopEnabled)
        {
            InitializeComponent();
            initialURL = url;


            //add an if statement to initialize the settings once. else the app is going to crash
            if (CefSharp.Cef.IsInitialized == false)
            {
                string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string cachePath = Path.Combine(appdata, "FilteredChromeBrowser", "cache");
                if (!Directory.Exists(cachePath))
                {
                    Directory.CreateDirectory(cachePath);
                }

                CefSettings Settings = new CefSettings();
                Settings.CachePath = cachePath;  //always set the cachePath, else this wont work
                Settings.CefCommandLineArgs.Add("no-proxy-server", "1");


                CefSharp.Cef.Initialize(Settings);
            }

            var browser = new ChromiumWebBrowser("about:blank")
            {
                Dock = DockStyle.Fill
            };

            browserPanel.Controls.Add(browser);
            Browser = browser;

            browser.MenuHandler = new MenuHandler(new Action(()=> {
                this.InvokeOnUiThreadIfRequired(() => { ToggleBottomToolStrip(); });
            }));
            myPageNavigationManager = new WinFormsRequestHandler(openNewTab);
            browser.RequestHandler = myPageNavigationManager;
            browser.JsDialogHandler = new JsDialogHandler();
            
            var dm = new DownloadHandler(CefSharp.WinForms.Example.Properties.Settings.Default.saveFolder);
            dm.OnDownloadUpdatedFired += Dm_OnDownloadUpdatedFired;
            browser.DownloadHandler = dm;


            if (multiThreadedMessageLoopEnabled)
            {
                browser.KeyboardHandler = new KeyboardHandler();
            }
            else
            {
                //When MultiThreadedMessageLoop is disabled we don't need the
                //CefSharp focus handler implementation.
                browser.FocusHandler = null;
            }

            //Handling DevTools docked inside the same window requires 
            //an instance of the LifeSpanHandler all the window events,
            //e.g. creation, resize, moving, closing etc.
            myLifeSpanHandler = new LifeSpanHandler(openPopupsAsTabs: true);
            browser.LifeSpanHandler = myLifeSpanHandler;
                

            browser.LoadingStateChanged += OnBrowserLoadingStateChanged;
            browser.ConsoleMessage += OnBrowserConsoleMessage;
            browser.TitleChanged += OnBrowserTitleChanged;
            browser.AddressChanged += OnBrowserAddressChanged;
            browser.StatusMessage += OnBrowserStatusMessage;
            browser.IsBrowserInitializedChanged += OnIsBrowserInitializedChanged;
            browser.LoadError += OnLoadError;

            browser.FrameLoadEnd += Browser_FrameLoadEnd;

            browser.IsBrowserInitializedChanged += Browser_IsBrowserInitializedChanged;



            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            browser.RegisterJsObject("print", new EmptyObject());




            browser.RenderProcessMessageHandler = new RenderProcessMessageHandler();
            browser.DisplayHandler = new DisplayHandler();
            //browser.MouseDown += OnBrowserMouseClick;
            browser.HandleCreated += OnBrowserHandleCreated;
            //browser.ResourceHandlerFactory = new FlashResourceHandlerFactory();
            this.multiThreadedMessageLoopEnabled = multiThreadedMessageLoopEnabled;

            
            //CefExample.RegisterTestResources(browser);
            

            var version = String.Format("Chromium: {0}, CEF: {1}, CefSharp: {2}", Cef.ChromiumVersion, Cef.CefVersion, Cef.CefSharpVersion);
            DisplayOutput(version);

        }

        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            
        }

        private void Browser_IsBrowserInitializedChanged(object sender, EventArgs e)
        {
           
        }

        private void Dm_OnDownloadUpdatedFired(object sender, DownloadItem e)
        {
            DownloadManager.Instance.addOrUpdateItem(e);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                    components = null;
                }

                if (messageInterceptor != null)
                {
                    messageInterceptor.ReleaseHandle();
                    messageInterceptor = null;
                }
            }
            base.Dispose(disposing);
        }

        private void OnBrowserHandleCreated(object sender, EventArgs e)
        {
            browserHandle = ((ChromiumWebBrowser)Browser).Handle;
        }

        private void OnBrowserMouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("Mouse Clicked" + e.X + ";" + e.Y + ";" + e.Button);
        }

        private void OnLoadError(object sender, LoadErrorEventArgs args)
        {
            //Don't display an error for external protocols that we allow the OS to
            //handle in OnProtocolExecution().
            if (args.ErrorCode == CefErrorCode.UnknownUrlScheme && args.Frame.Url.StartsWith("mailto"))
            {
                return;
            }

            DisplayOutput("Load Error:" + args.ErrorCode + ";" + args.ErrorText);
        }

        private void OnBrowserConsoleMessage(object sender, ConsoleMessageEventArgs args)
        {
            DisplayOutput(string.Format("Line: {0}, Source: {1}, Message: {2}", args.Line, args.Source, args.Message));
        }

        private void OnBrowserStatusMessage(object sender, StatusMessageEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => statusLabel.Text = args.Value);
        }

        private void OnBrowserLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {
            SetCanGoBack(args.CanGoBack);
            SetCanGoForward(args.CanGoForward);

            this.InvokeOnUiThreadIfRequired(() => SetIsLoading(args.IsLoading));
        }

        public static string CroppedText(string source, int max = 28)
        {
            return (source.Length > max) ? source.Substring(0, max -3 ) + " ..." : source;
        }

        string lastTitle = "";
        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs args)
        {
            lastTitle = args.Title;
            myHistory.Navigated(BrowserForm.historyLog, new Uri(Browser.Address), args.Title);
            this.InvokeOnUiThreadIfRequired(() => Parent.Text = CroppedText(args.Title));
        }

        
        
        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => urlTextBox.Text = args.Address);

            if (args.Address.Contains(FilteredCommon.Filtering.FilteringFlow.blockedDevUrl))
            {
                Browser.GetMainFrame().ExecuteJavaScriptAsync(
                    FilteredCommon.Filtering.FilteringFlow.evalReplaceHTML(
                        FilteredCommon.Filtering.FilteringFlow.formatBlockpage(myPageNavigationManager.lastReason)
                        )
                    );
            }
            else
            {
                string lastUrl = myHistory.CurrentURL();
                bool isBlocked = FilteringChrome.Common.shouldBlockNavigation(args.Address, lastUrl, ref myPageNavigationManager.lastReason);
                if (isBlocked)
                    LoadUrl(FilteredCommon.Filtering.FilteringFlow.blockedDevUrl);
            }
        }

        private static void OnJavascriptEventArrived(string eventName, object eventData)
        {
            switch (eventName)
            {
                //case "click":
                //{
                //    var message = eventData.ToString();
                //    var dataDictionary = eventData as Dictionary<string, object>;
                //    if (dataDictionary != null)
                //    {
                //        var result = string.Join(", ", dataDictionary.Select(pair => pair.Key + "=" + pair.Value));
                //        message = "event data: " + result;
                //    }
                //    MessageBox.Show(message, "Javascript event arrived", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    break;
                //}
            }
        }

        private void SetCanGoBack(bool canGoBack)
        {
            this.InvokeOnUiThreadIfRequired(() => backButton.Enabled = canGoBack);
        }

        private void SetCanGoForward(bool canGoForward)
        {
            this.InvokeOnUiThreadIfRequired(() => forwardButton.Enabled = canGoForward);
        }

        private void SetIsLoading(bool isLoading)
        {
            if (!isLoading && initialURL != "")
            {
                LoadUrl(initialURL);
                initialURL = "";
            }

            goButton.Text = isLoading ?
                "Stop" :
                "Go";
            goButton.Image = isLoading ?
                Properties.Resources.nav_plain_red :
                Properties.Resources.nav_plain_green;

            HandleToolStripLayout();
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private void OnIsBrowserInitializedChanged(object sender, EventArgs e)
        {
            //Get the underlying browser host wrapper
            var browserHost = Browser.GetBrowser().GetHost();
            var requestContext = browserHost.RequestContext;
            string errorMessage;
            // Browser must be initialized before getting/setting preferences
            var success = requestContext.SetPreference("enable_do_not_track", true, out errorMessage);
            if (!success)
            {
                this.InvokeOnUiThreadIfRequired(() => MessageBox.Show("Unable to set preference enable_do_not_track errorMessage: " + errorMessage));
            }

            //Example of disable spellchecking
            //success = requestContext.SetPreference("browser.enable_spellchecking", false, out errorMessage);

            var preferences = requestContext.GetAllPreferences(true);
            //var doNotTrack = (bool)preferences["enable_do_not_track"];

            //Use this to check that settings preferences are working in your code
            //success = requestContext.SetPreference("webkit.webprefs.minimum_font_size", 24, out errorMessage);

            //If we're using CefSetting.MultiThreadedMessageLoop (the default) then to hook the message pump,
            // which running in a different thread we have to use a NativeWindow
            if (multiThreadedMessageLoopEnabled)
            {
                SetupMessageInterceptor();
            }
        }

        /// <summary>
        /// The ChromiumWebBrowserControl does not fire MouseEnter/Move/Leave events, because Chromium handles these.
        /// This method provides a demo of hooking the Chrome_RenderWidgetHostHWND handle to receive low level messages.
        /// You can likely hook other window messages using this technique, drag/drog etc
        /// </summary>
        private void SetupMessageInterceptor()
        {
            if (messageInterceptor != null)
            {
                messageInterceptor.ReleaseHandle();
                messageInterceptor = null;
            }

            Task.Run(async () =>
            {
                try
                {
                    while (true)
                    {
                        IntPtr chromeWidgetHostHandle;
                        if (ChromeWidgetHandleFinder.TryFindHandle(browserHandle, out chromeWidgetHostHandle))
                        {
                            messageInterceptor = new ChromeWidgetMessageInterceptor((Control)Browser, chromeWidgetHostHandle, message =>
                            {
                                const int WM_MOUSEACTIVATE = 0x0021;
                                const int WM_NCLBUTTONDOWN = 0x00A1;
                                const int WM_DESTROY = 0x0002;

                                // Render process switch happened, need to find the new handle
                                if (message.Msg == WM_DESTROY)
                                {
                                    SetupMessageInterceptor();
                                    return;
                                }

                                if (message.Msg == WM_MOUSEACTIVATE)
                                {
                                    // The default processing of WM_MOUSEACTIVATE results in MA_NOACTIVATE,
                                    // and the subsequent mouse click is eaten by Chrome.
                                    // This means any .NET ToolStrip or ContextMenuStrip does not get closed.
                                    // By posting a WM_NCLBUTTONDOWN message to a harmless co-ordinate of the
                                    // top-level window, we rely on the ToolStripManager's message handling
                                    // to close any open dropdowns:
                                    // http://referencesource.microsoft.com/#System.Windows.Forms/winforms/Managed/System/WinForms/ToolStripManager.cs,1249
                                    var topLevelWindowHandle = message.WParam;
                                    PostMessage(topLevelWindowHandle, WM_NCLBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
                                }
                                //Forward mouse button down message to browser control
                                //else if(message.Msg == WM_LBUTTONDOWN)
                                //{
                                //    PostMessage(browserHandle, WM_LBUTTONDOWN, message.WParam, message.LParam);
                                //}

                                // The ChromiumWebBrowserControl does not fire MouseEnter/Move/Leave events, because Chromium handles these.
                                // However we can hook into Chromium's messaging window to receive the events.
                                //
                                //const int WM_MOUSEMOVE = 0x0200;
                                //const int WM_MOUSELEAVE = 0x02A3;
                                //
                                //switch (message.Msg) {
                                //    case WM_MOUSEMOVE:
                                //        Console.WriteLine("WM_MOUSEMOVE");
                                //        break;
                                //    case WM_MOUSELEAVE:
                                //        Console.WriteLine("WM_MOUSELEAVE");
                                //        break;
                                //}
                            });

                            break;
                        }
                        else
                        {
                            // Chrome hasn't yet set up its message-loop window.
                            await Task.Delay(10);
                        }
                    }
                }
                catch
                {
                    // Errors are likely to occur if browser is disposed, and no good way to check from another thread
                }
            });
        }

        private void DisplayOutput(string output)
        {
            //this.InvokeOnUiThreadIfRequired(() => statusLabel.Text = output);
        }

        private void HandleToolStripLayout(object sender, LayoutEventArgs e)
        {
            HandleToolStripLayout();
        }

        private void HandleToolStripLayout()
        {
            var width = stripMenu.Width;
            foreach (ToolStripItem item in stripMenu.Items)
            {
                if (item != urlTextBox)
                {
                    width -= item.Width - item.Margin.Horizontal;
                }
            }
            urlTextBox.Width = Math.Max(0, width - urlTextBox.Margin.Horizontal - 18);
        }

        private void GoButtonClick(object sender, EventArgs e)
        {
            FilteredEdgeBrowser.Dialogs.frmEditUrl dialog =
                new FilteredEdgeBrowser.Dialogs.frmEditUrl(BrowserForm.bookmarkLog, BrowserForm.historyLog);
            dialog.URL = urlTextBox.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadUrl(dialog.URL);
            }
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            Browser.Back();
        }

        private void ForwardButtonClick(object sender, EventArgs e)
        {
            Browser.Forward();
        }

        private void UrlTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            LoadUrl(urlTextBox.Text);
        }

        private void LoadUrl(string url)
        {
            url = Uri.EscapeUriString(url);
            if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                Browser.Load(url);
            }
        }

        public async void CopySourceToClipBoardAsync()
        {
            var htmlSource = await Browser.GetSourceAsync();

            Clipboard.SetText(htmlSource);
            DisplayOutput("HTML Source copied to clipboard");
        }

        private void ToggleBottomToolStrip()
        {
            if (stripFind.Visible)
            {
                Browser.StopFinding(true);
                stripFind.Visible = false;
            }
            else
            {
                stripFind.Visible = true;
                findTextBox.Focus();
            }
        }

        private void FindNextButtonClick(object sender, EventArgs e)
        {
            Find(true);
        }

        private void FindPreviousButtonClick(object sender, EventArgs e)
        {
            Find(false);
        }

        private void Find(bool next)
        {
            if (!string.IsNullOrEmpty(findTextBox.Text))
            {
                Browser.Find(0, findTextBox.Text, next, false, false);
            }
        }

        private void FindTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            Find(true);
        }

        public void ShowFind()
        {
            ToggleBottomToolStrip();
        }

        private void FindCloseButtonClick(object sender, EventArgs e)
        {
            ToggleBottomToolStrip();
        }

        //Example of DevTools docked within the existing UserControl,
        //in this example it's hosted in a Panel with a SplitContainer
        public void ShowDevToolsDocked()
        {
            if (devToolsSplitContainer.Panel2Collapsed)
            {
                devToolsSplitContainer.Panel2Collapsed = false;
            }

            //Find devToolsPanel in Controls collection
            Panel devToolsPanel = null;
            devToolsPanel = devToolsSplitContainer.Panel2.Controls.Find(nameof(devToolsPanel), false).FirstOrDefault() as Panel;

            if (devToolsPanel == null || devToolsPanel.IsDisposed)
            {
                devToolsPanel = new Panel()
                {
                    Name = nameof(devToolsPanel),
                    Dock = DockStyle.Fill
                };

                EventHandler devToolsPanelDisposedHandler = null;
                devToolsPanelDisposedHandler = (s, e) =>
                {
                    devToolsSplitContainer.Panel2.Controls.Remove(devToolsPanel);
                    devToolsSplitContainer.Panel2Collapsed = true;
                    devToolsPanel.Disposed -= devToolsPanelDisposedHandler;
                };

                //Subscribe for devToolsPanel dispose event
                devToolsPanel.Disposed += devToolsPanelDisposedHandler;

                //Add new devToolsPanel instance to Controls collection
                devToolsSplitContainer.Panel2.Controls.Add(devToolsPanel);
            }

            if (!devToolsPanel.IsHandleCreated)
            {
                //It's very important the handle for the control is created prior to calling
                //SetAsChild, if the hasn't hasn't been created then manually call CreateControl();
                //This code is not required for this example, it's left here for demo purposes.
                devToolsPanel.CreateControl();
            }

            //Devtools will be a child of the DevToolsPanel
            var rect = devToolsPanel.ClientRectangle;
            var windowInfo = new WindowInfo();
            windowInfo.SetAsChild(devToolsPanel.Handle, rect.Left, rect.Top, rect.Right, rect.Bottom);
            Browser.GetBrowserHost().ShowDevTools(windowInfo);
        }

        public Task<bool> CheckIfDevToolsIsOpenAsync()
        {
            return Cef.UIThreadTaskFactory.StartNew(() =>
            {
                return Browser.GetBrowserHost().HasDevTools;
            });
        }

        LocalHistoryManager myHistory = new LocalHistoryManager();
        private void stripBTNHistory_Click(object sender, EventArgs e)
        {
            FilteredEdgeBrowser.Dialogs.frmTabHistory chooseHistory = 
                new FilteredEdgeBrowser.Dialogs.frmTabHistory(myHistory);

            if (chooseHistory.ShowDialog() == DialogResult.OK)
            {
                LoadUrl(chooseHistory.URL.ToString());
            }
        }

        private void stripBTNBookmark_Click(object sender, EventArgs e)
        {
            (new FilteredEdgeBrowser.Dialogs
                .frmDlgBookmark(BrowserForm.bookmarkLog, lastTitle, Browser.Address))
                .ShowDialog();
        }

        private void BrowserTabUserControl_Load(object sender, EventArgs e)
        {
           
        }

        private async void tmrBlockContent_Tick(object sender, EventArgs e)
        {
            TaskResult<string> isBlockedState = await FilteringChrome.Common.FilterAllFramesHTML(Browser, TimeSpan.FromSeconds(2));
            if (isBlockedState.Sucess)
            {
                myPageNavigationManager.lastReason = isBlockedState.Result;
                LoadUrl(FilteredCommon.Filtering.FilteringFlow.blockedDevUrl);
            }
        }



    }
}
