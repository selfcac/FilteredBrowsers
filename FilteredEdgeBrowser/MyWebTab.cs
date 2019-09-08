﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilteredEdgeBrowser
{
    public partial class MyWebTab : UserControl
    {
        TabPage myPage;
        LocalHistoryManager myHistory = new LocalHistoryManager();

        public delegate void titleEvent(TabPage page, string title);
        public event titleEvent onTitleChange;

        public delegate void newPage(Uri referer, Uri url);
        public event newPage onNewPage;

        string initialUrl = "";
        public MyWebTab(string url = "https://www.google.com")
        {
            initialUrl = url;
            InitializeComponent();
        }

        public string DocumentTitle { get { return wvMain.DocumentTitle; } }

        private void MyWebTab_Load(object sender, EventArgs e)
        {
            wvMain.NavigationStarting += WvMain_NavigationStarting;
            wvMain.NavigationCompleted += WvMain_NavigationCompleted;
            wvMain.DOMContentLoaded += WvMain_DOMContentLoaded;
            wvMain.NewWindowRequested += WvMain_NewWindowRequested;
            wvMain.FrameNavigationStarting += WvMain_FrameNavigationStarting;
            wvMain.FrameDOMContentLoaded += WvMain_FrameDOMContentLoaded;
            

            wvMain.Navigate(initialUrl);
        }

        public string formatBlockpage(string reason)
        {
            string blockedHTML = FilteredCommon.Resources.SharedResources.getBlockedPage();
            return blockedHTML.Replace("{0}",
                ("<br/>" + reason )
                .Replace("<*", "<b>").Replace("*>", "</b>")
                .Replace("_<", "<u>").Replace(">_", "</u>"));
        }

        private void WvMain_FrameDOMContentLoaded(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlDOMContentLoadedEventArgs e)
        {
            //setStatus("Frame content loaded.");
            //isHTMLContentLoaded = true;
        }

        private void WvMain_FrameNavigationStarting(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlNavigationStartingEventArgs e)
        {
            //setStatus("Frame started navigating");
            //isHTMLContentLoaded = false;
        }

        public void setStatus(string text)
        {
            lblStatus.Text = string.Format("[{0}] {1}", DateTime.Now, text);
        }

        public void setMyPage(TabPage page)
        {
            myPage = page;
        }

        public void closePage()
        {
            wvMain.Dispose();
        }

        private void WvMain_NewWindowRequested(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlNewWindowRequestedEventArgs e)
        {
            onNewPage?.Invoke(e.Referrer, e.Uri);   
            e.Handled = true;
        }

        bool isHTMLContentLoaded = false;
        private void WvMain_DOMContentLoaded(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlDOMContentLoadedEventArgs e)
        {
            Uri currentUri = (e.Uri != null) ? e.Uri : new Uri("https://blocked.content/");
            

            myHistory.Navigated(MainForm.historyLog ,currentUri, wvMain.DocumentTitle);
            string newURL = currentUri.ToString();
            txtURL.BackColor = (newURL.StartsWith("https")) ? Color.FromArgb(192, 255, 192) : Color.FromArgb(255, 192, 192);
            txtURL.Text = newURL;
            
            lblTitle.Text = wvMain.DocumentTitle;
            onTitleChange?.Invoke(myPage, wvMain.DocumentTitle);

            isHTMLContentLoaded = (e.Uri != null); // only on real websites
            setStatus("DOM Content Loaded");
        }
        
        private void WvMain_NavigationStarting(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlNavigationStartingEventArgs e)
        {
            if (e.Uri != null && MainForm.httpPolicy.getMode() == HTTPProtocolFilter.WorkingMode.ENFORCE )
            {
                string finalReason = "";
                bool isBlocked = FilteredCommon.Filtering.FilteringFlow
                    .isTimeBlocked(MainForm.timePolicy, DateTime.Now, ref finalReason);

               if (!isBlocked) // Time is ok!
               {
                    Uri referer = null;
                    if (myHistory.Size() > 0)
                        referer = myHistory.CurrentURI();  // we add to history after dom completed


                    bool isHTTPBlocked =
                        FilteredCommon.Filtering.FilteringFlow
                        .isNavigationBlocked(MainForm.httpPolicy, referer, e.Uri, out finalReason);
                }

                e.Cancel = isBlocked;

                if (e.Cancel)
                {
                    myHistory.Navigated(MainForm.historyLog, e.Uri, "Page Blocked");
                    wvMain.NavigateToString(formatBlockpage(finalReason));
                }
                else
                {
                    setStatus("Navigate to " + e.Uri.ToString());
                }
            }

            if (!e.Cancel) isHTMLContentLoaded = false;
        }

        

        private void navigateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialogs.frmTabHistory chooseHistory = new Dialogs.frmTabHistory(myHistory);
            if (chooseHistory.ShowDialog() == DialogResult.OK)
            {
                wvMain.Navigate(chooseHistory.URL);
            }
        }

        private void WvMain_NavigationCompleted(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlNavigationCompletedEventArgs e)
        {
            // Final event per page
            setStatus("Navigation Complete");
        }

        public void SetToolbarVisibility(bool visible)
        {
            gbMenu.Visible = visible;
        }

        private void bookmarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Dialogs.frmDlgBookmark(MainForm.bookmarkLog, wvMain.DocumentTitle, myHistory.CurrentURL())).ShowDialog();
        }

        private void changeUrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialogs.frmEditUrl dialog = new Dialogs.frmEditUrl(MainForm.bookmarkLog, MainForm.historyLog);
            dialog.URL = txtURL.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                wvMain.Navigate(dialog.URL);
            }
        }

        private async void tmrCheckFilter_Tick(object sender, EventArgs e)
        {
            if (
                isHTMLContentLoaded &&
                MainForm.httpPolicy.getMode() == HTTPProtocolFilter.WorkingMode.ENFORCE
                )
            {
                string finalReason = "";
                bool isBlocked = FilteredCommon.Filtering.FilteringFlow
                    .isTimeBlocked(MainForm.timePolicy, DateTime.Now, ref finalReason);

                if (!isBlocked)
                {
                    try
                    {
                        string Header = await wvMain.InvokeScriptAsync("eval", new string[] {
                        FilteredCommon.Filtering.FilteringFlow.evalHead
                    });

                        string content = await wvMain.InvokeScriptAsync("eval", new string[] {
                        FilteredCommon.Filtering.FilteringFlow.evalBody
                    });


                        isBlocked = FilteredCommon.Filtering.FilteringFlow.
                            isHTMLPageBlocked(MainForm.httpPolicy, Header, content, out finalReason);

                    }
                    catch (Exception ex)
                    {
                        setStatus("Content filter error: " + ex.Message);
                    }
                }

                if (isBlocked) { wvMain.NavigateToString(formatBlockpage(finalReason)); }
            }
        }
    }
   
}