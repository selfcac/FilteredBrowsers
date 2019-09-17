﻿using System;
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
    public partial class frmDlgBookmark : Form
    {
        public string BookmarkName, URL;
        private Utils.LogFileHandler _BookmarkHandler;

        public frmDlgBookmark(Utils.LogFileHandler myBookmarkHandeler, string name, string url)
        {
            BookmarkName = name;
            URL = url;
            _BookmarkHandler = myBookmarkHandeler;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BookmarkName = txtName.Text;
            URL = txtURL.Text;
            _BookmarkHandler.SaveUrlToFile(BookmarkName, URL);
            DialogResult = DialogResult.OK;
        }

        private void frmDlgBookmark_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            txtName.Text = BookmarkName;
            txtURL.Text = URL;
        }
    }
}
