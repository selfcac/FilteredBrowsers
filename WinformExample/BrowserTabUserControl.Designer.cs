namespace CefSharp.WinForms.Example
{
    partial class BrowserTabUserControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserTabUserControl));
            this.stripFind = new System.Windows.Forms.ToolStrip();
            this.findTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.findPreviousButton = new System.Windows.Forms.ToolStripButton();
            this.findNextButton = new System.Windows.Forms.ToolStripButton();
            this.findCloseButton = new System.Windows.Forms.ToolStripButton();
            this.stripMenu = new System.Windows.Forms.ToolStrip();
            this.backButton = new System.Windows.Forms.ToolStripButton();
            this.forwardButton = new System.Windows.Forms.ToolStripButton();
            this.stripBTNHistory = new System.Windows.Forms.ToolStripButton();
            this.stripBTNBookmark = new System.Windows.Forms.ToolStripButton();
            this.urlTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.goButton = new System.Windows.Forms.ToolStripButton();
            this.devToolsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.browserPanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrBlockContent = new System.Windows.Forms.Timer(this.components);
            this.stripBtnBlockElement = new System.Windows.Forms.ToolStripButton();
            this.stripFind.SuspendLayout();
            this.stripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.devToolsSplitContainer)).BeginInit();
            this.devToolsSplitContainer.Panel1.SuspendLayout();
            this.devToolsSplitContainer.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // stripFind
            // 
            this.stripFind.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.stripFind.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.stripFind.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findTextBox,
            this.findPreviousButton,
            this.findNextButton,
            this.findCloseButton});
            this.stripFind.Location = new System.Drawing.Point(0, 506);
            this.stripFind.Name = "stripFind";
            this.stripFind.Size = new System.Drawing.Size(925, 25);
            this.stripFind.TabIndex = 0;
            this.stripFind.Visible = false;
            // 
            // findTextBox
            // 
            this.findTextBox.Name = "findTextBox";
            this.findTextBox.Size = new System.Drawing.Size(100, 25);
            this.findTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FindTextBoxKeyDown);
            // 
            // findPreviousButton
            // 
            this.findPreviousButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.findPreviousButton.Image = global::CefSharp.WinForms.Example.Properties.Resources.nav_left_green;
            this.findPreviousButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.findPreviousButton.Name = "findPreviousButton";
            this.findPreviousButton.Size = new System.Drawing.Size(23, 22);
            this.findPreviousButton.Text = "Find Previous";
            this.findPreviousButton.Click += new System.EventHandler(this.FindPreviousButtonClick);
            // 
            // findNextButton
            // 
            this.findNextButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.findNextButton.Image = global::CefSharp.WinForms.Example.Properties.Resources.nav_right_green;
            this.findNextButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.findNextButton.Name = "findNextButton";
            this.findNextButton.Size = new System.Drawing.Size(23, 22);
            this.findNextButton.Text = "Find Next";
            this.findNextButton.Click += new System.EventHandler(this.FindNextButtonClick);
            // 
            // findCloseButton
            // 
            this.findCloseButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.findCloseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.findCloseButton.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.findCloseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.findCloseButton.Name = "findCloseButton";
            this.findCloseButton.Size = new System.Drawing.Size(23, 22);
            this.findCloseButton.Text = "X";
            this.findCloseButton.Click += new System.EventHandler(this.FindCloseButtonClick);
            // 
            // stripMenu
            // 
            this.stripMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.stripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backButton,
            this.forwardButton,
            this.stripBTNHistory,
            this.stripBTNBookmark,
            this.stripBtnBlockElement,
            this.urlTextBox,
            this.goButton});
            this.stripMenu.Location = new System.Drawing.Point(0, 0);
            this.stripMenu.Name = "stripMenu";
            this.stripMenu.Padding = new System.Windows.Forms.Padding(0);
            this.stripMenu.Size = new System.Drawing.Size(925, 25);
            this.stripMenu.Stretch = true;
            this.stripMenu.TabIndex = 0;
            this.stripMenu.Layout += new System.Windows.Forms.LayoutEventHandler(this.HandleToolStripLayout);
            // 
            // backButton
            // 
            this.backButton.Enabled = false;
            this.backButton.Image = global::CefSharp.WinForms.Example.Properties.Resources.nav_left_green;
            this.backButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(52, 22);
            this.backButton.Text = "Back";
            this.backButton.Click += new System.EventHandler(this.BackButtonClick);
            // 
            // forwardButton
            // 
            this.forwardButton.Enabled = false;
            this.forwardButton.Image = global::CefSharp.WinForms.Example.Properties.Resources.nav_right_green;
            this.forwardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(70, 22);
            this.forwardButton.Text = "Forward";
            this.forwardButton.Click += new System.EventHandler(this.ForwardButtonClick);
            // 
            // stripBTNHistory
            // 
            this.stripBTNHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stripBTNHistory.Image = ((System.Drawing.Image)(resources.GetObject("stripBTNHistory.Image")));
            this.stripBTNHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripBTNHistory.Name = "stripBTNHistory";
            this.stripBTNHistory.Size = new System.Drawing.Size(23, 22);
            this.stripBTNHistory.Text = "toolStripButton2";
            this.stripBTNHistory.Click += new System.EventHandler(this.stripBTNHistory_Click);
            // 
            // stripBTNBookmark
            // 
            this.stripBTNBookmark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stripBTNBookmark.Image = ((System.Drawing.Image)(resources.GetObject("stripBTNBookmark.Image")));
            this.stripBTNBookmark.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripBTNBookmark.Name = "stripBTNBookmark";
            this.stripBTNBookmark.Size = new System.Drawing.Size(23, 22);
            this.stripBTNBookmark.Text = "toolStripButton1";
            this.stripBTNBookmark.Click += new System.EventHandler(this.stripBTNBookmark_Click);
            // 
            // urlTextBox
            // 
            this.urlTextBox.AutoSize = false;
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.ReadOnly = true;
            this.urlTextBox.Size = new System.Drawing.Size(500, 25);
            this.urlTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UrlTextBoxKeyUp);
            this.urlTextBox.Click += new System.EventHandler(this.GoButtonClick);
            // 
            // goButton
            // 
            this.goButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.goButton.Image = global::CefSharp.WinForms.Example.Properties.Resources.nav_plain_green;
            this.goButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(23, 22);
            this.goButton.Text = "Go";
            // 
            // devToolsSplitContainer
            // 
            this.devToolsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.devToolsSplitContainer.Location = new System.Drawing.Point(0, 25);
            this.devToolsSplitContainer.Name = "devToolsSplitContainer";
            // 
            // devToolsSplitContainer.Panel1
            // 
            this.devToolsSplitContainer.Panel1.Controls.Add(this.browserPanel);
            this.devToolsSplitContainer.Panel2Collapsed = true;
            this.devToolsSplitContainer.Size = new System.Drawing.Size(925, 484);
            this.devToolsSplitContainer.SplitterDistance = 481;
            this.devToolsSplitContainer.TabIndex = 2;
            // 
            // browserPanel
            // 
            this.browserPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserPanel.Location = new System.Drawing.Point(0, 0);
            this.browserPanel.Name = "browserPanel";
            this.browserPanel.Size = new System.Drawing.Size(925, 484);
            this.browserPanel.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 509);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(925, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(118, 17);
            this.statusLabel.Text = "toolStripStatusLabel1";
            // 
            // tmrBlockContent
            // 
            this.tmrBlockContent.Enabled = true;
            this.tmrBlockContent.Interval = 2000;
            this.tmrBlockContent.Tick += new System.EventHandler(this.tmrBlockContent_Tick);
            // 
            // stripBtnBlockElement
            // 
            this.stripBtnBlockElement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stripBtnBlockElement.Image = ((System.Drawing.Image)(resources.GetObject("stripBtnBlockElement.Image")));
            this.stripBtnBlockElement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripBtnBlockElement.Name = "stripBtnBlockElement";
            this.stripBtnBlockElement.Size = new System.Drawing.Size(23, 22);
            this.stripBtnBlockElement.Text = "toolStripButton1";
            this.stripBtnBlockElement.Click += new System.EventHandler(this.stripBtnBlockElement_Click);
            // 
            // BrowserTabUserControl
            // 
            this.Controls.Add(this.devToolsSplitContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.stripMenu);
            this.Controls.Add(this.stripFind);
            this.Name = "BrowserTabUserControl";
            this.Size = new System.Drawing.Size(925, 531);
            this.Load += new System.EventHandler(this.BrowserTabUserControl_Load);
            this.stripFind.ResumeLayout(false);
            this.stripFind.PerformLayout();
            this.stripMenu.ResumeLayout(false);
            this.stripMenu.PerformLayout();
            this.devToolsSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.devToolsSplitContainer)).EndInit();
            this.devToolsSplitContainer.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip stripMenu;
        private System.Windows.Forms.ToolStripButton backButton;
        private System.Windows.Forms.ToolStripButton forwardButton;
        private System.Windows.Forms.ToolStripTextBox urlTextBox;
        private System.Windows.Forms.ToolStripButton goButton;

        private System.Windows.Forms.ToolStrip stripFind;
        private System.Windows.Forms.ToolStripButton findPreviousButton;
        private System.Windows.Forms.ToolStripTextBox findTextBox;
        private System.Windows.Forms.ToolStripButton findNextButton;
        private System.Windows.Forms.ToolStripButton findCloseButton;
        private System.Windows.Forms.SplitContainer devToolsSplitContainer;
        private System.Windows.Forms.Panel browserPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripButton stripBTNHistory;
        private System.Windows.Forms.ToolStripButton stripBTNBookmark;
        private System.Windows.Forms.Timer tmrBlockContent;
        private System.Windows.Forms.ToolStripButton stripBtnBlockElement;
    }
}
