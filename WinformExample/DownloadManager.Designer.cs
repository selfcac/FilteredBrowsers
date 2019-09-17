namespace CefSharp.WinForms.Example
{
    partial class DownloadManager
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
            this.components = new System.ComponentModel.Container();
            this.lstBoxDownload = new System.Windows.Forms.ListBox();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tryOpenFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSavePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstBoxDownload
            // 
            this.lstBoxDownload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBoxDownload.FormattingEnabled = true;
            this.lstBoxDownload.ItemHeight = 16;
            this.lstBoxDownload.Location = new System.Drawing.Point(0, 28);
            this.lstBoxDownload.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstBoxDownload.Name = "lstBoxDownload";
            this.lstBoxDownload.Size = new System.Drawing.Size(1067, 526);
            this.lstBoxDownload.TabIndex = 0;
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Enabled = true;
            this.tmrRefresh.Interval = 1000;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tryOpenFolderToolStripMenuItem,
            this.showSavePathToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tryOpenFolderToolStripMenuItem
            // 
            this.tryOpenFolderToolStripMenuItem.Name = "tryOpenFolderToolStripMenuItem";
            this.tryOpenFolderToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            this.tryOpenFolderToolStripMenuItem.Text = "Try Open Folder";
            this.tryOpenFolderToolStripMenuItem.Click += new System.EventHandler(this.tryOpenFolderToolStripMenuItem_Click);
            // 
            // showSavePathToolStripMenuItem
            // 
            this.showSavePathToolStripMenuItem.Name = "showSavePathToolStripMenuItem";
            this.showSavePathToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            this.showSavePathToolStripMenuItem.Text = "Show Save path";
            this.showSavePathToolStripMenuItem.Click += new System.EventHandler(this.showSavePathToolStripMenuItem_Click);
            // 
            // DownloadManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.lstBoxDownload);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DownloadManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DownloadManager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloadManager_FormClosing);
            this.Load += new System.EventHandler(this.DownloadManager_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBoxDownload;
        private System.Windows.Forms.Timer tmrRefresh;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tryOpenFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSavePathToolStripMenuItem;
    }
}