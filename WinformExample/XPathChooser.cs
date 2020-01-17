using CefSharp.WinForms.Example.FilteringChrome;
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

namespace CefSharp.WinForms.Example
{
    public partial class XPathChooser : Form
    {
        IFrame _myFrame = null;
        string _originalXPATH = "";
        Uri _Uri = null;

        public XPathChooser(IFrame frame, string xpath, Uri uri)
        {
            _myFrame = frame;
            _originalXPATH = xpath;
            _Uri = uri;
            InitializeComponent();
        }

        private void XPathChooser_Load(object sender, EventArgs e)
        {
            txtDomain.Text = _Uri.Host;
            txtEp.Text = _Uri.PathAndQuery;
            txtXpath.Text = _originalXPATH;
        }

        private void btnHighlight_Click(object sender, EventArgs e)
        {
            string escapedXPATH = EscapeXpath(txtXpath.Text);
            string script = Properties.Resources.HighlightElement
                .Replace("{xpath}", escapedXPATH)
                .Replace("{count}", ((int)numericUpDown1.Value).ToString());
            _myFrame.ExecuteJavaScriptAsync(script);
        }

        public static  string EscapeXpath(string xpath)
        {
            string escapedXPATH =
                "\"" +
                    xpath
                    .Replace("\\", "\\\\") // MUST BE FIRST
                    .Replace("\"", "\\\"") +
                "\"";
            return escapedXPATH;
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            XPathHelpers.XpathItem item = new XPathHelpers.XpathItem();
            item.domainPattern = txtDomain.Text;
            item.epPattern = txtEp.Text;
            item.parentCount = (int)numericUpDown1.Value;
            item.xpath = txtXpath.Text;

            File.AppendAllLines(
                Properties.Settings.Default.xpathPolicyPath,
                new[] { item.toLine() }
            );

            BrowserForm.xpathPolicy.AddItem(item);

            this.Close();
        }
    }

   

    
}
