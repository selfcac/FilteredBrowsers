using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilteredEdgeBrowser.Dialogs
{
    public partial class frmTabHistory : Form
    {
        LocalHistoryManager myManger;
        public Uri URL;

        public frmTabHistory(LocalHistoryManager MyManger)
        {
            this.myManger = MyManger;
            InitializeComponent();
        }

        private void lstUrls_DoubleClick(object sender, EventArgs e)
        {
            int newIndex = lstUrls.SelectedIndex;
            if (newIndex  > -1 )
            {
                myManger.NavigatedIndex(newIndex);
                this.URL = myManger[newIndex].URL;
                DialogResult = DialogResult.OK;
            }
        }

        public static string  formatURLHelper(string name, string url)
        {
            return name + " • " + url;
        }

        private void frmTabHistory_Load(object sender, EventArgs e)
        {

            int currentIndex = myManger.HistoryPosition();
            int historySize = myManger.Size();
            for (int i = 0; i < historySize; i++)
            {
                string prefix = (currentIndex == i) ? "╠► " : "║ ";
                lstUrls.Items.Add(prefix + formatURLHelper(myManger[i].Title,
                    formatURLHelper(myManger[i].URL.Host, myManger[i].URL.PathAndQuery)
                    ));
            }
        }
    }
}
