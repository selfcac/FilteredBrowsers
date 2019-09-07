using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CefSharp.WinForms.Example
{
    public partial class DownloadManager : Form
    {
        public static DownloadManager Instance = new DownloadManager();

        public DownloadManager()
        {
            InitializeComponent();
        }

        private void DownloadManager_Load(object sender, EventArgs e)
        {

        }

        Dictionary<int, DownloadItemProgress> allMyItems = new Dictionary<int, DownloadItemProgress>();

        public void addOrUpdateItem(DownloadItem di)
        {
            lstBoxDownload.Invoke(new Action(() =>
           {
               var progressItem = new DownloadItemProgress(di);
               if (!allMyItems.ContainsKey(progressItem.GetHashCode()))
               {
                   allMyItems.Add(progressItem.GetHashCode(), progressItem);
                   lstBoxDownload.Items.Add(progressItem);
               }
               else
               {
                   allMyItems[progressItem.GetHashCode()].updateItem(di);
               }
           }));
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            if (lstBoxDownload.Items.Count > 0)
                lstBoxDownload.Items[0] = lstBoxDownload.Items[0];
        }

        private void DownloadManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void tryOpenFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstBoxDownload.SelectedItem != null)
            {
                string filename = (lstBoxDownload.SelectedItem as DownloadItemProgress).Item().FullPath;
                string dir = Path.GetDirectoryName(filename);
                if (Directory.Exists(dir))
                {
                    Process.Start(dir);
                }
            }
        }
    }

    public class DownloadItemProgress
    {
        DownloadItem myItem = null;

        public DownloadItem Item()
        {
            return myItem;
        }

        public static string getByteSize(double len)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
            // show a single decimal place, and no space.
            string result = String.Format("{0:0.##} {1}", len, sizes[order]);
            return result;
        }

        public DownloadItemProgress(DownloadItem di)
        {
            this.myItem = di;
        }

        public override string ToString()
        {
            string result = "";
           
            if (myItem != null)
            {
                if (myItem.IsValid)
                {
                    if (myItem.IsCancelled)
                    {
                        result = "[Cancelled]";
                    }
                    else
                    {
                        if (myItem.IsComplete)
                        {
                            result = "[Done]";
                        }
                        else
                        {
                            if (myItem.IsInProgress)
                            {
                                string percent = (myItem.PercentComplete > -1 ? myItem.PercentComplete.ToString() : "??") + "%";
                                result = "[" + percent + " @ " + getByteSize(myItem.CurrentSpeed) + "]";
                            }
                            else
                            {
                                result = "[Unkown?]";
                            }
                        }
                    }
                }
                else
                {
                    result = "[Not-Valid]";
                }

                result += " " + myItem.OriginalUrl;
            }

            return result;
        }

        public override int GetHashCode()
        {
            int hash = -1;
            if (myItem != null)
                hash = myItem.Id;

            return hash;
        }

        public void updateItem(DownloadItem di)
        {
            myItem = di;
        }
    }
}
