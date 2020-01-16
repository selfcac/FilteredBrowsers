using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public XPathChooser(IFrame frame, string xpath)
        {
            _myFrame = frame;
            _originalXPATH = xpath;
            InitializeComponent();
        }

        private void XPathChooser_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHighlight_Click(object sender, EventArgs e)
        {
            string escapedXPATH = 
                "\"" +
                _originalXPATH
                    .Replace("\\", "\\\\") // MUST BE FIRST
                    .Replace("\"", "\\\"") +
                "\"";
            string script = Properties.Resources.HighlightElement
                .Replace("{xpath}", escapedXPATH )
                .Replace("{count}", ((int)numericUpDown1.Value).ToString());
            _myFrame.ExecuteJavaScriptAsync(script);
        }
    }
}
