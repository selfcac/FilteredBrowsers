namespace CefSharp.WinForms.Example
{
    partial class BrowserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scopeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectionOnlyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.entirePAgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToPdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.popupsInSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allUrlsInPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.copySourceToClipBoardAsyncMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeTabIconMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToRightToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeOthersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devtoolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browserTabControl = new System.Windows.Forms.TabControl();
            this.gitInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.zoomLevelToolStripMenuItem,
            this.downloadsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.addTabToolStripMenuItem,
            this.closeTabIconMenuItem1,
            this.closeToRightToolStripMenuItem,
            this.devtoolToolStripMenuItem,
            this.gitInfoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(730, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTabToolStripMenuItem,
            this.closeTabToolStripMenuItem,
            this.printToolStripMenuItem,
            this.printOptionsToolStripMenuItem,
            this.printToPdfToolStripMenuItem,
            this.popupsInSelectedToolStripMenuItem,
            this.allUrlsInPageToolStripMenuItem,
            this.toolStripMenuItem3,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newTabToolStripMenuItem
            // 
            this.newTabToolStripMenuItem.Name = "newTabToolStripMenuItem";
            this.newTabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.newTabToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.newTabToolStripMenuItem.Text = "&New Tab";
            this.newTabToolStripMenuItem.Click += new System.EventHandler(this.NewTabToolStripMenuItemClick);
            // 
            // closeTabToolStripMenuItem
            // 
            this.closeTabToolStripMenuItem.Name = "closeTabToolStripMenuItem";
            this.closeTabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeTabToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.closeTabToolStripMenuItem.Text = "&Close Tab";
            this.closeTabToolStripMenuItem.Click += new System.EventHandler(this.CloseTabToolStripMenuItemClick);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Enabled = false;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItemClick);
            // 
            // printOptionsToolStripMenuItem
            // 
            this.printOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scopeToolStripMenuItem,
            this.includeBackgroundToolStripMenuItem});
            this.printOptionsToolStripMenuItem.Name = "printOptionsToolStripMenuItem";
            this.printOptionsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.printOptionsToolStripMenuItem.Text = "Print Options";
            // 
            // scopeToolStripMenuItem
            // 
            this.scopeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectionOnlyToolStripMenuItem1,
            this.entirePAgeToolStripMenuItem});
            this.scopeToolStripMenuItem.Name = "scopeToolStripMenuItem";
            this.scopeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.scopeToolStripMenuItem.Text = "Scope";
            // 
            // selectionOnlyToolStripMenuItem1
            // 
            this.selectionOnlyToolStripMenuItem1.CheckOnClick = true;
            this.selectionOnlyToolStripMenuItem1.Name = "selectionOnlyToolStripMenuItem1";
            this.selectionOnlyToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.selectionOnlyToolStripMenuItem1.Text = "Selection Only";
            this.selectionOnlyToolStripMenuItem1.Click += new System.EventHandler(this.selectionOnlyToolStripMenuItem1_Click);
            // 
            // entirePAgeToolStripMenuItem
            // 
            this.entirePAgeToolStripMenuItem.Checked = true;
            this.entirePAgeToolStripMenuItem.CheckOnClick = true;
            this.entirePAgeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.entirePAgeToolStripMenuItem.Name = "entirePAgeToolStripMenuItem";
            this.entirePAgeToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.entirePAgeToolStripMenuItem.Text = "Entire Page";
            this.entirePAgeToolStripMenuItem.Click += new System.EventHandler(this.entirePAgeToolStripMenuItem_Click);
            // 
            // includeBackgroundToolStripMenuItem
            // 
            this.includeBackgroundToolStripMenuItem.Checked = true;
            this.includeBackgroundToolStripMenuItem.CheckOnClick = true;
            this.includeBackgroundToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeBackgroundToolStripMenuItem.Name = "includeBackgroundToolStripMenuItem";
            this.includeBackgroundToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.includeBackgroundToolStripMenuItem.Text = "Include Background";
            // 
            // printToPdfToolStripMenuItem
            // 
            this.printToPdfToolStripMenuItem.Name = "printToPdfToolStripMenuItem";
            this.printToPdfToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.printToPdfToolStripMenuItem.Text = "Print To Pdf";
            this.printToPdfToolStripMenuItem.Click += new System.EventHandler(this.PrintToPdfToolStripMenuItemClick);
            // 
            // popupsInSelectedToolStripMenuItem
            // 
            this.popupsInSelectedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allowToolStripMenuItem,
            this.blockToolStripMenuItem});
            this.popupsInSelectedToolStripMenuItem.Name = "popupsInSelectedToolStripMenuItem";
            this.popupsInSelectedToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.popupsInSelectedToolStripMenuItem.Text = "Popups In Selected >";
            // 
            // allowToolStripMenuItem
            // 
            this.allowToolStripMenuItem.Name = "allowToolStripMenuItem";
            this.allowToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.allowToolStripMenuItem.Text = "Allow";
            this.allowToolStripMenuItem.Click += new System.EventHandler(this.allowToolStripMenuItem_Click);
            // 
            // blockToolStripMenuItem
            // 
            this.blockToolStripMenuItem.Name = "blockToolStripMenuItem";
            this.blockToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.blockToolStripMenuItem.Text = "Block";
            this.blockToolStripMenuItem.Click += new System.EventHandler(this.blockToolStripMenuItem_Click);
            // 
            // allUrlsInPageToolStripMenuItem
            // 
            this.allUrlsInPageToolStripMenuItem.Name = "allUrlsInPageToolStripMenuItem";
            this.allUrlsInPageToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.allUrlsInPageToolStripMenuItem.Text = "All urls in page";
            this.allUrlsInPageToolStripMenuItem.Click += new System.EventHandler(this.allUrlsInPageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(182, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitMenuItemClick);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoMenuItem,
            this.redoMenuItem,
            this.findMenuItem,
            this.toolStripMenuItem2,
            this.cutMenuItem,
            this.copyMenuItem,
            this.pasteMenuItem,
            this.deleteMenuItem,
            this.selectAllMenuItem,
            this.toolStripSeparator1,
            this.copySourceToClipBoardAsyncMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoMenuItem
            // 
            this.undoMenuItem.Name = "undoMenuItem";
            this.undoMenuItem.Size = new System.Drawing.Size(251, 22);
            this.undoMenuItem.Text = "Undo";
            this.undoMenuItem.Click += new System.EventHandler(this.UndoMenuItemClick);
            // 
            // redoMenuItem
            // 
            this.redoMenuItem.Name = "redoMenuItem";
            this.redoMenuItem.Size = new System.Drawing.Size(251, 22);
            this.redoMenuItem.Text = "Redo";
            this.redoMenuItem.Click += new System.EventHandler(this.RedoMenuItemClick);
            // 
            // findMenuItem
            // 
            this.findMenuItem.Name = "findMenuItem";
            this.findMenuItem.Size = new System.Drawing.Size(251, 22);
            this.findMenuItem.Text = "Find";
            this.findMenuItem.Click += new System.EventHandler(this.FindMenuItemClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(248, 6);
            // 
            // cutMenuItem
            // 
            this.cutMenuItem.Name = "cutMenuItem";
            this.cutMenuItem.Size = new System.Drawing.Size(251, 22);
            this.cutMenuItem.Text = "Cut";
            this.cutMenuItem.Click += new System.EventHandler(this.CutMenuItemClick);
            // 
            // copyMenuItem
            // 
            this.copyMenuItem.Name = "copyMenuItem";
            this.copyMenuItem.Size = new System.Drawing.Size(251, 22);
            this.copyMenuItem.Text = "Copy";
            this.copyMenuItem.Click += new System.EventHandler(this.CopyMenuItemClick);
            // 
            // pasteMenuItem
            // 
            this.pasteMenuItem.Name = "pasteMenuItem";
            this.pasteMenuItem.Size = new System.Drawing.Size(251, 22);
            this.pasteMenuItem.Text = "Paste";
            this.pasteMenuItem.Click += new System.EventHandler(this.PasteMenuItemClick);
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Size = new System.Drawing.Size(251, 22);
            this.deleteMenuItem.Text = "Delete";
            this.deleteMenuItem.Click += new System.EventHandler(this.DeleteMenuItemClick);
            // 
            // selectAllMenuItem
            // 
            this.selectAllMenuItem.Name = "selectAllMenuItem";
            this.selectAllMenuItem.Size = new System.Drawing.Size(251, 22);
            this.selectAllMenuItem.Text = "Select All";
            this.selectAllMenuItem.Click += new System.EventHandler(this.SelectAllMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(248, 6);
            // 
            // copySourceToClipBoardAsyncMenuItem
            // 
            this.copySourceToClipBoardAsyncMenuItem.Name = "copySourceToClipBoardAsyncMenuItem";
            this.copySourceToClipBoardAsyncMenuItem.Size = new System.Drawing.Size(251, 22);
            this.copySourceToClipBoardAsyncMenuItem.Text = "Copy Source to Clipboard (async)";
            this.copySourceToClipBoardAsyncMenuItem.Click += new System.EventHandler(this.CopySourceToClipBoardAsyncClick);
            // 
            // zoomLevelToolStripMenuItem
            // 
            this.zoomLevelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.resetZoomToolStripMenuItem});
            this.zoomLevelToolStripMenuItem.Name = "zoomLevelToolStripMenuItem";
            this.zoomLevelToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.zoomLevelToolStripMenuItem.Text = "Zoom Level";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom In";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.ZoomInToolStripMenuItemClick);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.ZoomOutToolStripMenuItemClick);
            // 
            // resetZoomToolStripMenuItem
            // 
            this.resetZoomToolStripMenuItem.Name = "resetZoomToolStripMenuItem";
            this.resetZoomToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemPeriod)));
            this.resetZoomToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.resetZoomToolStripMenuItem.Text = "Reset Zoom";
            this.resetZoomToolStripMenuItem.Click += new System.EventHandler(this.resetZoomToolStripMenuItem_Click);
            // 
            // downloadsToolStripMenuItem
            // 
            this.downloadsToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.downloadsToolStripMenuItem.Name = "downloadsToolStripMenuItem";
            this.downloadsToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.downloadsToolStripMenuItem.Text = "[Downloads]";
            this.downloadsToolStripMenuItem.Click += new System.EventHandler(this.downloadsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(49, 20);
            this.toolStripMenuItem1.Text = "    |     ";
            // 
            // addTabToolStripMenuItem
            // 
            this.addTabToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addTabToolStripMenuItem.Image")));
            this.addTabToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addTabToolStripMenuItem.Name = "addTabToolStripMenuItem";
            this.addTabToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.addTabToolStripMenuItem.Text = "Add Tab";
            this.addTabToolStripMenuItem.Click += new System.EventHandler(this.addTabToolStripMenuItem_Click);
            // 
            // closeTabIconMenuItem1
            // 
            this.closeTabIconMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("closeTabIconMenuItem1.Image")));
            this.closeTabIconMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.closeTabIconMenuItem1.Name = "closeTabIconMenuItem1";
            this.closeTabIconMenuItem1.Size = new System.Drawing.Size(85, 20);
            this.closeTabIconMenuItem1.Text = "Close Tab";
            this.closeTabIconMenuItem1.Click += new System.EventHandler(this.closeTabIconMenuItem1_Click);
            // 
            // closeToRightToolStripMenuItem
            // 
            this.closeToRightToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToLeftToolStripMenuItem,
            this.closeToRightToolStripMenuItem1,
            this.closeOthersToolStripMenuItem});
            this.closeToRightToolStripMenuItem.Name = "closeToRightToolStripMenuItem";
            this.closeToRightToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.closeToRightToolStripMenuItem.Text = "Close ....";
            // 
            // closeToLeftToolStripMenuItem
            // 
            this.closeToLeftToolStripMenuItem.Name = "closeToLeftToolStripMenuItem";
            this.closeToLeftToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.closeToLeftToolStripMenuItem.Text = "Close to left";
            this.closeToLeftToolStripMenuItem.Click += new System.EventHandler(this.closeToLeftToolStripMenuItem_Click);
            // 
            // closeToRightToolStripMenuItem1
            // 
            this.closeToRightToolStripMenuItem1.Name = "closeToRightToolStripMenuItem1";
            this.closeToRightToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.closeToRightToolStripMenuItem1.Text = "Close to right";
            this.closeToRightToolStripMenuItem1.Click += new System.EventHandler(this.closeToRightToolStripMenuItem1_Click);
            // 
            // closeOthersToolStripMenuItem
            // 
            this.closeOthersToolStripMenuItem.Name = "closeOthersToolStripMenuItem";
            this.closeOthersToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.closeOthersToolStripMenuItem.Text = "Close others";
            this.closeOthersToolStripMenuItem.Click += new System.EventHandler(this.closeOthersToolStripMenuItem_Click);
            // 
            // devtoolToolStripMenuItem
            // 
            this.devtoolToolStripMenuItem.Enabled = false;
            this.devtoolToolStripMenuItem.Name = "devtoolToolStripMenuItem";
            this.devtoolToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.devtoolToolStripMenuItem.Text = "Devtool";
            this.devtoolToolStripMenuItem.Click += new System.EventHandler(this.ShowDevToolsDockedMenuItemClick);
            // 
            // browserTabControl
            // 
            this.browserTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserTabControl.Location = new System.Drawing.Point(0, 24);
            this.browserTabControl.Name = "browserTabControl";
            this.browserTabControl.SelectedIndex = 0;
            this.browserTabControl.Size = new System.Drawing.Size(730, 466);
            this.browserTabControl.TabIndex = 2;
            // 
            // gitInfoToolStripMenuItem
            // 
            this.gitInfoToolStripMenuItem.Name = "gitInfoToolStripMenuItem";
            this.gitInfoToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.gitInfoToolStripMenuItem.Text = "<Git Info>";
            this.gitInfoToolStripMenuItem.Click += new System.EventHandler(this.gitInfoToolStripMenuItem_Click);
            // 
            // BrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 490);
            this.Controls.Add(this.browserTabControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BrowserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtered Chrome (CefSharp) v1-9.9.1157";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BrowserForm_FormClosing);
            this.Load += new System.EventHandler(this.BrowserForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem findMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem copySourceToClipBoardAsyncMenuItem;
        private System.Windows.Forms.TabControl browserTabControl;
        private System.Windows.Forms.ToolStripMenuItem newTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToPdfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeTabIconMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToRightToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeOthersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem resetZoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devtoolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scopeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectionOnlyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem entirePAgeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeBackgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allUrlsInPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem popupsInSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gitInfoToolStripMenuItem;
    }
}
