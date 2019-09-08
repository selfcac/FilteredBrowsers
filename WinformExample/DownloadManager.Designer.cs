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
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstBoxDownload
            // 
            this.lstBoxDownload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBoxDownload.FormattingEnabled = true;
            this.lstBoxDownload.Location = new System.Drawing.Point(0, 24);
            this.lstBoxDownload.Name = "lstBoxDownload";
            this.lstBoxDownload.Size = new System.Drawing.Size(800, 426);
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
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tryOpenFolderToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tryOpenFolderToolStripMenuItem
            // 
            this.tryOpenFolderToolStripMenuItem.Name = "tryOpenFolderToolStripMenuItem";
            this.tryOpenFolderToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.tryOpenFolderToolStripMenuItem.Text = "Try Open Folder";
            this.tryOpenFolderToolStripMenuItem.Click += new System.EventHandler(this.tryOpenFolderToolStripMenuItem_Click);
            // 
            // DownloadManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstBoxDownload);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
    }
}