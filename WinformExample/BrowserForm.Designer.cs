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
            this.printToPdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
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
            this.currentZoomLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browserTabControl = new System.Windows.Forms.TabControl();
            this.addTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeTabIconMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToRightToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeOthersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.zoomLevelToolStripMenuItem,
            this.downloadsToolStripMenuItem,
            this.addTabToolStripMenuItem,
            this.closeTabIconMenuItem1,
            this.closeToRightToolStripMenuItem});
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
            this.printToPdfToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newTabToolStripMenuItem
            // 
            this.newTabToolStripMenuItem.Name = "newTabToolStripMenuItem";
            this.newTabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.newTabToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newTabToolStripMenuItem.Text = "&New Tab";
            this.newTabToolStripMenuItem.Click += new System.EventHandler(this.NewTabToolStripMenuItemClick);
            // 
            // closeTabToolStripMenuItem
            // 
            this.closeTabToolStripMenuItem.Name = "closeTabToolStripMenuItem";
            this.closeTabToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeTabToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeTabToolStripMenuItem.Text = "&Close Tab";
            this.closeTabToolStripMenuItem.Click += new System.EventHandler(this.CloseTabToolStripMenuItemClick);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItemClick);
            // 
            // printToPdfToolStripMenuItem
            // 
            this.printToPdfToolStripMenuItem.Name = "printToPdfToolStripMenuItem";
            this.printToPdfToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.printToPdfToolStripMenuItem.Text = "Print To Pdf";
            this.printToPdfToolStripMenuItem.Click += new System.EventHandler(this.PrintToPdfToolStripMenuItemClick);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            this.currentZoomLevelToolStripMenuItem});
            this.zoomLevelToolStripMenuItem.Name = "zoomLevelToolStripMenuItem";
            this.zoomLevelToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.zoomLevelToolStripMenuItem.Text = "Zoom Level";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom In";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.ZoomInToolStripMenuItemClick);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.ZoomOutToolStripMenuItemClick);
            // 
            // currentZoomLevelToolStripMenuItem
            // 
            this.currentZoomLevelToolStripMenuItem.Name = "currentZoomLevelToolStripMenuItem";
            this.currentZoomLevelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.currentZoomLevelToolStripMenuItem.Text = "Current Zoom Level";
            this.currentZoomLevelToolStripMenuItem.Click += new System.EventHandler(this.CurrentZoomLevelToolStripMenuItemClick);
            // 
            // downloadsToolStripMenuItem
            // 
            this.downloadsToolStripMenuItem.Name = "downloadsToolStripMenuItem";
            this.downloadsToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.downloadsToolStripMenuItem.Text = "[Downloads]";
            this.downloadsToolStripMenuItem.Click += new System.EventHandler(this.downloadsToolStripMenuItem_Click);
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
            // addTabToolStripMenuItem
            // 
            this.addTabToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addTabToolStripMenuItem.Image")));
            this.addTabToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addTabToolStripMenuItem.Name = "addTabToolStripMenuItem";
            this.addTabToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.addTabToolStripMenuItem.Text = "Add Tab";
            this.addTabToolStripMenuItem.Click += new System.EventHandler(this.addTabToolStripMenuItem_Click);
            // 
            // closeTabIconMenuItem1
            // 
            this.closeTabIconMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("closeTabIconMenuItem1.Image")));
            this.closeTabIconMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.closeTabIconMenuItem1.Name = "closeTabIconMenuItem1";
            this.closeTabIconMenuItem1.Size = new System.Drawing.Size(86, 20);
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
            this.closeToLeftToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToLeftToolStripMenuItem.Text = "Close to left";
            this.closeToLeftToolStripMenuItem.Click += new System.EventHandler(this.closeToLeftToolStripMenuItem_Click);
            // 
            // closeToRightToolStripMenuItem1
            // 
            this.closeToRightToolStripMenuItem1.Name = "closeToRightToolStripMenuItem1";
            this.closeToRightToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.closeToRightToolStripMenuItem1.Text = "Close to right";
            this.closeToRightToolStripMenuItem1.Click += new System.EventHandler(this.closeToRightToolStripMenuItem1_Click);
            // 
            // closeOthersToolStripMenuItem
            // 
            this.closeOthersToolStripMenuItem.Name = "closeOthersToolStripMenuItem";
            this.closeOthersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeOthersToolStripMenuItem.Text = "Close others";
            this.closeOthersToolStripMenuItem.Click += new System.EventHandler(this.closeOthersToolStripMenuItem_Click);
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
            this.Text = "Filtered Chrome (CefSharp)";
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
        private System.Windows.Forms.ToolStripMenuItem currentZoomLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToPdfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeTabIconMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToRightToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeOthersToolStripMenuItem;
    }
}
