// Copyright © 2010-2015 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using CefSharp.MinimalExample.WinForms.Controls;
using CefSharp.MinimalExample.WinForms.FilteringAdditions;
using CefSharp.WinForms;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CefSharp.MinimalExample.WinForms
{
    public partial class BrowserForm : Form
    {
        private readonly ChromiumWebBrowser browser;

        MyRequestHandler myPageNavigationManager;

        public BrowserForm()
        {
            InitializeComponent();

            Text = "CefSharp";
            WindowState = FormWindowState.Maximized;

            // No proxy protection in Program.cs

            browser = new ChromiumWebBrowser("http://yoniwas.com/echo.php")
            {
                Dock = DockStyle.Fill,
            };
            toolStripContainer.ContentPanel.Controls.Add(browser);

            browser.IsBrowserInitializedChanged += OnIsBrowserInitializedChanged;
            browser.LoadingStateChanged += OnLoadingStateChanged;
            browser.ConsoleMessage += OnBrowserConsoleMessage;
            browser.StatusMessage += OnBrowserStatusMessage;
            browser.TitleChanged += OnBrowserTitleChanged;
            browser.AddressChanged += OnBrowserAddressChanged;

            // ==================  Filtering: =========================
            //  Block Poppups:
            browser.LifeSpanHandler = new FilteringAdditions.AntiPopupLifespan();
            // Add secet to bypass:
            myPageNavigationManager = new FilteringAdditions.MyRequestHandler();
            browser.RequestHandler = myPageNavigationManager;
            // Block print popup:
            browser.RegisterJsObject("print", new FilteringAdditions.EmptyObject());
            // Block context menu:
            browser.MenuHandler = new FilteringAdditions.SimpleContextMenu();
            // ==========================================================

            var version = string.Format("Chromium: {0}, CEF: {1}, CefSharp: {2}",
               Cef.ChromiumVersion, Cef.CefVersion, Cef.CefSharpVersion);

            // .NET Framework
            var bitness = Environment.Is64BitProcess ? "x64" : "x86";
            var environment = String.Format("Environment: {0}", bitness);

            DisplayOutput(string.Format("{0}, {1}", version, environment));
        }

        private void OnIsBrowserInitializedChanged(object sender, EventArgs e)
        {
            var b = ((ChromiumWebBrowser)sender);

            this.InvokeOnUiThreadIfRequired(() => b.Focus());
        }

        private void OnBrowserConsoleMessage(object sender, ConsoleMessageEventArgs args)
        {
            DisplayOutput(string.Format("Line: {0}, Source: {1}, Message: {2}", args.Line, args.Source, args.Message));
        }

        private void OnBrowserStatusMessage(object sender, StatusMessageEventArgs args)
        {
            //this.InvokeOnUiThreadIfRequired(() => statusLabel.Text = args.Value);
        }

        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {
            SetCanGoBack(args.CanGoBack);
            SetCanGoForward(args.CanGoForward);

            this.InvokeOnUiThreadIfRequired(() => SetIsLoading(!args.CanReload));
        }

        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => Text = args.Title);
        }


        string lastNaigatedURL = "about:blank";
        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => urlTextBox.Text = args.Address);
            if (args.Address.Contains(FilteringFlow.blockedDevUrl))
            {
                browser.GetMainFrame().ExecuteJavaScriptAsync(
                    FilteringFlow.evalReplaceHTML(
                        FilteringFlow.formatBlockpage(myPageNavigationManager.lastReason)
                        )
                    );
            }
            else
            {
                string lastUrl = lastNaigatedURL;
                bool isBlocked = FilteringAdditions.Common.shouldBlockNavigation(args.Address, lastUrl, ref myPageNavigationManager.lastReason);
                if (isBlocked)
                    LoadUrl(FilteringFlow.blockedDevUrl);
                else
                    lastNaigatedURL = args.Address;
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
            goButton.Text = isLoading ?
                "Stop" :
                "Go";
            goButton.Image = isLoading ?
                Properties.Resources.nav_plain_red :
                Properties.Resources.nav_plain_green;

            HandleToolStripLayout();
        }

        public void DisplayOutput(string output)
        {
           // this.InvokeOnUiThreadIfRequired(() => outputLabel.Text = output);
        }

        private void HandleToolStripLayout(object sender, LayoutEventArgs e)
        {
            HandleToolStripLayout();
        }

        private void HandleToolStripLayout()
        {
            var width = toolStrip1.Width;
            foreach (ToolStripItem item in toolStrip1.Items)
            {
                if (item != urlTextBox)
                {
                    width -= item.Width - item.Margin.Horizontal;
                }
            }
            urlTextBox.Width = Math.Max(0, width - urlTextBox.Margin.Horizontal - 18);
        }

        private void ExitMenuItemClick(object sender, EventArgs e)
        {
            browser.Dispose();
            Cef.Shutdown();
            Close();
        }

        private void GoButtonClick(object sender, EventArgs e)
        {
            LoadUrl(urlTextBox.Text);
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            browser.Back();
        }

        private void ForwardButtonClick(object sender, EventArgs e)
        {
            browser.Forward();
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
            if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                browser.Load(url);
            }
        }

        private void ShowDevToolsMenuItemClick(object sender, EventArgs e)
        {
            browser.ShowDevTools();
        }

        public static HTTPProtocolFilter.FilterPolicy httpPolicy = new HTTPProtocolFilter.FilterPolicy();
        public static TimeBlockFilter.TimeFilterObject timePolicy = new TimeBlockFilter.TimeFilterObject();


        bool isDebug = true;

        private void BrowserForm_Load(object sender, EventArgs e)
        {

            if (isDebug)
            {
                httpPolicy.proxyMode = HTTPProtocolFilter.WorkingMode.MAPPING;
                timePolicy.clearAllTo(true);
                MessageBox.Show("In debug mode! Filtering is off!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string httpPolicyPath = CefSharp.MinimalExample.WinForms.Properties.Settings.Default.httpPolicyPath;
                string timePolicyPath = CefSharp.MinimalExample.WinForms.Properties.Settings.Default.timePolicyPath;

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


            // Read bypass secret from file:
            FilteringAdditions.MyRequestHandler.BypassSecret = CefSharp.MinimalExample.WinForms.Properties.Settings.Default.bypassSecret;
        }

        private async System.Threading.Tasks.Task tmrBlockContent_TickAsync(object sender, EventArgs e)
        {
            TaskResult<string> isBlockedState = await FilteringAdditions.Common.FilterAllFramesHTML (browser, TimeSpan.FromSeconds(2));
            if (isBlockedState.Sucess)
            {
                myPageNavigationManager.lastReason = isBlockedState.Result;
                LoadUrl(FilteringFlow.blockedDevUrl);
            }
        }
    }
}
