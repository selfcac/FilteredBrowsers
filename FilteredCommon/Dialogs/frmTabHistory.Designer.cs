namespace FilteredEdgeBrowser.Dialogs
{
    partial class frmTabHistory
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
            this.lstUrls = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstUrls
            // 
            this.lstUrls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstUrls.FormattingEnabled = true;
            this.lstUrls.HorizontalScrollbar = true;
            this.lstUrls.ItemHeight = 18;
            this.lstUrls.Location = new System.Drawing.Point(0, 0);
            this.lstUrls.Margin = new System.Windows.Forms.Padding(4);
            this.lstUrls.Name = "lstUrls";
            this.lstUrls.Size = new System.Drawing.Size(607, 303);
            this.lstUrls.TabIndex = 0;
            this.lstUrls.DoubleClick += new System.EventHandler(this.lstUrls_DoubleClick);
            // 
            // frmTabHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 303);
            this.Controls.Add(this.lstUrls);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTabHistory";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tab history";
            this.Load += new System.EventHandler(this.frmTabHistory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstUrls;
    }
}