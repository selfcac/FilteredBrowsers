using FilteredEdgeBrowser.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilteredEdgeBrowser
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        bool shouldHide = true;
        private void minMaxViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shouldHide = !shouldHide;
            foreach (TabPage tab in tabViews.TabPages)
            {
                (tab.Controls[0] as MyWebTab).SetToolbarVisibility(shouldHide);
            }
        }


        void addNewTab (string url = "https://www.google.com")
        {
            TabPage tab = new TabPage("Loading...");

            MyWebTab view = new MyWebTab(url);
            view.SetToolbarVisibility(shouldHide);
            view.Dock = DockStyle.Fill;
            view.setMyPage(tab);
            view.onTitleChange += View_onTitleChange;
            view.onNewPage += View_onNewPage;

            tab.Controls.Add(view);

            tabViews.TabPages.Add(tab);
        }

        private void addTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNewTab();
        }

        private void View_onNewPage(Uri referer, Uri url)
        {
            // Todo: User referer for filtering
            addNewTab(url.ToString());
        }

        private void View_onTitleChange(TabPage page, string title)
        {
            if (page != null)
            {
                page.Text = (title.Length > 25) ? title.Substring(0, 25) + " ..." : title;
            }
        }

        public void closeTab(int index)
        {
            (tabViews.TabPages[index].Controls[0] as MyWebTab).closePage();
            tabViews.TabPages.RemoveAt(index);
        }

        private void closeTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabViews.SelectedIndex > -1)
            {
                closeTab(tabViews.SelectedIndex);
            }
        }

        private void closeToLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int tabIndex = tabViews.SelectedIndex; // remember because might change
            CloseToLeft(tabIndex);
        }

        private void CloseToLeft(int currentIndex)
        {  
            if (currentIndex > -1)
            {
                for (int i = 0; i < currentIndex; i++)
                {
                    closeTab(0);
                }
            }
        }

        private void closeToRightToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int tabIndex = tabViews.SelectedIndex;
            CloseToRight(tabIndex);
        }

        private void CloseToRight(int currentIndex)
        {
            
            if (currentIndex > -1)
            {
                for (int i = tabViews.TabPages.Count-1; i > currentIndex; i--) // reverse 
                {
                    closeTab(i);
                }
            }
        }

        private void closeOthersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabViews.SelectedIndex > -1)
            {
                CloseToLeft(tabViews.SelectedIndex);
                CloseToRight(0);
            }
        }

        public static HTTPProtocolFilter.FilterPolicy httpPolicy = new HTTPProtocolFilter.FilterPolicy();
        public static TimeBlockFilter.TimeFilterObject timePolicy = new TimeBlockFilter.TimeFilterObject();

        public static LogFileHandler historyLog, bookmarkLog;
        private void MainForm_Load(object sender, EventArgs e)
        {
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string historyPath = Path.Combine(appdata, "FilteredEdgeBrowser", "history.log.txt");
            if (!File.Exists(historyPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(historyPath));
            }

            string bookmarkPath = Path.Combine(appdata, "FilteredEdgeBrowser", "bookmark.log.txt");
            if (!File.Exists(bookmarkPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(bookmarkPath));
            }
             
            historyLog = new LogFileHandler(historyPath);
            bookmarkLog = new LogFileHandler(bookmarkPath);

            httpPolicy.reloadPolicy(FilteredEdgeBrowser.Properties.Settings.Default.WebPolicyPath);
            timePolicy.reloadPolicy(FilteredEdgeBrowser.Properties.Settings.Default.TimePolicyPath);
        }
    }
}
