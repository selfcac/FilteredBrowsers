namespace FilteredEdgeBrowser
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabViews = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.minMaxViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToRightToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeOthersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabViews
            // 
            this.tabViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabViews.Location = new System.Drawing.Point(0, 24);
            this.tabViews.Margin = new System.Windows.Forms.Padding(4);
            this.tabViews.Name = "tabViews";
            this.tabViews.SelectedIndex = 0;
            this.tabViews.Size = new System.Drawing.Size(816, 693);
            this.tabViews.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minMaxViewToolStripMenuItem,
            this.addTabToolStripMenuItem,
            this.closeTabToolStripMenuItem,
            this.closeToRightToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(816, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // minMaxViewToolStripMenuItem
            // 
            this.minMaxViewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("minMaxViewToolStripMenuItem.Image")));
            this.minMaxViewToolStripMenuItem.Name = "minMaxViewToolStripMenuItem";
            this.minMaxViewToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.minMaxViewToolStripMenuItem.Text = "Min\\Max View";
            this.minMaxViewToolStripMenuItem.Click += new System.EventHandler(this.minMaxViewToolStripMenuItem_Click);
            // 
            // addTabToolStripMenuItem
            // 
            this.addTabToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addTabToolStripMenuItem.Image")));
            this.addTabToolStripMenuItem.Name = "addTabToolStripMenuItem";
            this.addTabToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.addTabToolStripMenuItem.Text = "Add Tab";
            this.addTabToolStripMenuItem.Click += new System.EventHandler(this.addTabToolStripMenuItem_Click);
            // 
            // closeTabToolStripMenuItem
            // 
            this.closeTabToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeTabToolStripMenuItem.Image")));
            this.closeTabToolStripMenuItem.Name = "closeTabToolStripMenuItem";
            this.closeTabToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.closeTabToolStripMenuItem.Text = "Close Tab";
            this.closeTabToolStripMenuItem.Click += new System.EventHandler(this.closeTabToolStripMenuItem_Click);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 717);
            this.Controls.Add(this.tabViews);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtered Edge Browser";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabViews;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToRightToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeOthersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minMaxViewToolStripMenuItem;
    }
}