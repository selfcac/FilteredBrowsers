using System;
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
            string blockedHTML = FilteredEdgeBrowser.Properties.Resources.BlockedPage;
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
            

            myHistory.Navigated(currentUri, wvMain.DocumentTitle);
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
            if (e.Uri != null )
            {
                string finalReason = "init final";
                if (MainForm.httpPolicy.getMode() == HTTPProtocolFilter.WorkingMode.ENFORCE)
                {
                    e.Cancel = true;

                    // TODO: Filter here
                    string urlReason = "init main reason";
                    if (MainForm.httpPolicy.isWhitelistedURL(e.Uri, out urlReason))
                    {
                        e.Cancel = false;
                    }
                    else // check the referer
                    {
                        if (myHistory.Size() > 0) // we add to history after dom completed, 0 mean none
                        {
                            string refererReason = "init ref reason";
                            if (MainForm.httpPolicy.isWhitelistedURL(myHistory.CurrentURI(), out refererReason))
                            {
                                if (MainForm.httpPolicy.findAllowedDomain(myHistory.CurrentURI().Host).AllowRefering)
                                {
                                    e.Cancel = false;
                                }
                                else
                                {
                                    finalReason = myHistory.CurrentURL() + " Is not allowed as referer. <br/><br/>" + urlReason;
                                }
                            }
                            else
                            {
                                finalReason = "<h3>Target:</h3></br>" 
                                    + urlReason + "<br /><h3>Referrer:</h3></br>" + refererReason;
                            }
                        }
                        else
                        {
                            finalReason = urlReason;
                        }
                    }
                }

                if (e.Cancel)
                {
                    myHistory.Navigated(e.Uri, "Page Blocked");
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
            (new Dialogs.frmDlgBookmark(wvMain.DocumentTitle, myHistory.CurrentURL())).ShowDialog();
        }

        private void changeUrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialogs.frmEditUrl dialog = new Dialogs.frmEditUrl();
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
                try
                {
                    string Header = await wvMain.InvokeScriptAsync("eval", new string[] {
                        "document.getElementsByTagName(\"head\")[0].innerText"
                    });

                     string content = await wvMain.InvokeScriptAsync("eval", new string[] {
                        "document.getElementsByTagName(\"body\")[0].innerText"
                    });

                    bool isBlocked = false;
                    string reason = "init body reason";
                    if (MainForm.httpPolicy.isBodyBlocked(Header, out reason) )
                    {
                        reason = "Body is blocked. </br>" + reason;
                        isBlocked = true;
                    } 
                    else if (MainForm.httpPolicy.isBodyBlocked(content, out reason))
                    {
                        reason = "Header is blocked. </br>" + reason;
                        isBlocked = true;
                    }
                    
                    if (isBlocked) { wvMain.NavigateToString(formatBlockpage(reason)); }
                }
                catch (Exception ex)
                {
                    setStatus("Content filter error: " + ex.Message);
                }
            }
        }
    }
   
}
