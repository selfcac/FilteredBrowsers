namespace FilteredEdgeBrowser.Dialogs
{
    partial class frmEditUrl
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.txtFreeStyle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.pbHistory = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstBookmark = new System.Windows.Forms.ListBox();
            this.pbBookmark = new System.Windows.Forms.ProgressBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstGoogle = new System.Windows.Forms.ListBox();
            this.pbSuggestion = new System.Windows.Forms.ProgressBar();
            this.lstHTTP = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inline edit:";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(16, 29);
            this.txtURL.Multiline = true;
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(537, 53);
            this.txtURL.TabIndex = 2;
            // 
            // txtFreeStyle
            // 
            this.txtFreeStyle.Location = new System.Drawing.Point(16, 111);
            this.txtFreeStyle.Name = "txtFreeStyle";
            this.txtFreeStyle.Size = new System.Drawing.Size(597, 26);
            this.txtFreeStyle.TabIndex = 4;
            this.txtFreeStyle.TextChanged += new System.EventHandler(this.txtFreeStyle_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Freestyle Edit:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.lstHistory);
            this.groupBox1.Controls.Add(this.pbHistory);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 336);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "History search";
            // 
            // lstHistory
            // 
            this.lstHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.HorizontalScrollbar = true;
            this.lstHistory.ItemHeight = 18;
            this.lstHistory.Location = new System.Drawing.Point(3, 22);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(577, 288);
            this.lstHistory.TabIndex = 14;
            this.lstHistory.SelectedIndexChanged += new System.EventHandler(this.lstHistory_SelectedIndexChanged);
            // 
            // pbHistory
            // 
            this.pbHistory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbHistory.Location = new System.Drawing.Point(3, 310);
            this.pbHistory.Name = "pbHistory";
            this.pbHistory.Size = new System.Drawing.Size(577, 23);
            this.pbHistory.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.groupBox2.Controls.Add(this.lstBookmark);
            this.groupBox2.Controls.Add(this.pbBookmark);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(589, 342);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bookmark Search";
            // 
            // lstBookmark
            // 
            this.lstBookmark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBookmark.FormattingEnabled = true;
            this.lstBookmark.HorizontalScrollbar = true;
            this.lstBookmark.ItemHeight = 18;
            this.lstBookmark.Location = new System.Drawing.Point(3, 22);
            this.lstBookmark.Name = "lstBookmark";
            this.lstBookmark.Size = new System.Drawing.Size(583, 294);
            this.lstBookmark.TabIndex = 14;
            this.lstBookmark.SelectedIndexChanged += new System.EventHandler(this.lstBookmark_SelectedIndexChanged);
            // 
            // pbBookmark
            // 
            this.pbBookmark.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbBookmark.Location = new System.Drawing.Point(3, 316);
            this.pbBookmark.Name = "pbBookmark";
            this.pbBookmark.Size = new System.Drawing.Size(583, 23);
            this.pbBookmark.TabIndex = 13;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupBox3.Controls.Add(this.lstGoogle);
            this.groupBox3.Controls.Add(this.pbSuggestion);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(583, 336);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Google suggestion";
            // 
            // lstGoogle
            // 
            this.lstGoogle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstGoogle.FormattingEnabled = true;
            this.lstGoogle.HorizontalScrollbar = true;
            this.lstGoogle.ItemHeight = 18;
            this.lstGoogle.Location = new System.Drawing.Point(3, 22);
            this.lstGoogle.Name = "lstGoogle";
            this.lstGoogle.Size = new System.Drawing.Size(577, 288);
            this.lstGoogle.TabIndex = 13;
            this.lstGoogle.SelectedIndexChanged += new System.EventHandler(this.lstGoogle_SelectedIndexChanged);
            // 
            // pbSuggestion
            // 
            this.pbSuggestion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbSuggestion.Location = new System.Drawing.Point(3, 310);
            this.pbSuggestion.Name = "pbSuggestion";
            this.pbSuggestion.Size = new System.Drawing.Size(577, 23);
            this.pbSuggestion.TabIndex = 12;
            // 
            // lstHTTP
            // 
            this.lstHTTP.FormattingEnabled = true;
            this.lstHTTP.ItemHeight = 18;
            this.lstHTTP.Location = new System.Drawing.Point(16, 144);
            this.lstHTTP.Name = "lstHTTP";
            this.lstHTTP.Size = new System.Drawing.Size(597, 58);
            this.lstHTTP.TabIndex = 8;
            this.lstHTTP.SelectedIndexChanged += new System.EventHandler(this.lstHTTP_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(560, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 53);
            this.button1.TabIndex = 9;
            this.button1.Text = "◄ OK!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(16, 208);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(597, 373);
            this.tabControl1.TabIndex = 10;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(589, 342);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Suggestion";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(589, 342);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "History";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(589, 342);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Bookmark";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // frmEditUrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 593);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstHTTP);
            this.Controls.Add(this.txtFreeStyle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEditUrl";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit the url";
            this.Load += new System.EventHandler(this.frmEditUrl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.TextBox txtFreeStyle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstHTTP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox lstGoogle;
        private System.Windows.Forms.ProgressBar pbSuggestion;
        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.ProgressBar pbHistory;
        private System.Windows.Forms.ListBox lstBookmark;
        private System.Windows.Forms.ProgressBar pbBookmark;
    }
}