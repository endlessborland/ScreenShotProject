namespace ScreenShot
{
    partial class TestWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestWindow));
            this.url_label = new System.Windows.Forms.Label();
            this.urlinput = new System.Windows.Forms.TextBox();
            this.notificationIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.restoreDefaults = new System.Windows.Forms.Button();
            this.path = new System.Windows.Forms.TextBox();
            this.pathlabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // url_label
            // 
            this.url_label.AutoSize = true;
            this.url_label.Location = new System.Drawing.Point(12, 12);
            this.url_label.Name = "url_label";
            this.url_label.Size = new System.Drawing.Size(29, 13);
            this.url_label.TabIndex = 1;
            this.url_label.Text = "URL";
            // 
            // urlinput
            // 
            this.urlinput.Location = new System.Drawing.Point(48, 9);
            this.urlinput.Name = "urlinput";
            this.urlinput.Size = new System.Drawing.Size(328, 20);
            this.urlinput.TabIndex = 2;
            // 
            // notificationIcon
            // 
            this.notificationIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notificationIcon.BalloonTipText = "This thing screenshots, yeah.";
            this.notificationIcon.BalloonTipTitle = "Screenshot";
            this.notificationIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notificationIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notificationIcon.Icon")));
            this.notificationIcon.Text = "ScreenShot";
            this.notificationIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notificationIcon_MouseDoubleClick_1);
            // 
            // restoreDefaults
            // 
            this.restoreDefaults.Location = new System.Drawing.Point(15, 61);
            this.restoreDefaults.Name = "restoreDefaults";
            this.restoreDefaults.Size = new System.Drawing.Size(361, 25);
            this.restoreDefaults.TabIndex = 3;
            this.restoreDefaults.Text = "Restore Defaults";
            this.restoreDefaults.UseVisualStyleBackColor = true;
            this.restoreDefaults.Click += new System.EventHandler(this.restoreDefaults_button_Click);
            // 
            // path
            // 
            this.path.Location = new System.Drawing.Point(48, 35);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(328, 20);
            this.path.TabIndex = 5;
            this.path.Click += new System.EventHandler(this.path_Click);
            // 
            // pathlabel
            // 
            this.pathlabel.AutoSize = true;
            this.pathlabel.Location = new System.Drawing.Point(12, 38);
            this.pathlabel.Name = "pathlabel";
            this.pathlabel.Size = new System.Drawing.Size(29, 13);
            this.pathlabel.TabIndex = 4;
            this.pathlabel.Text = "Path";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 70);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // TestWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 98);
            this.Controls.Add(this.path);
            this.Controls.Add(this.pathlabel);
            this.Controls.Add(this.restoreDefaults);
            this.Controls.Add(this.urlinput);
            this.Controls.Add(this.url_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "TestWindow";
            this.Text = "Settings";
            this.Resize += new System.EventHandler(this.TestWindow_Resize);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label url_label;
        private System.Windows.Forms.TextBox urlinput;
        private System.Windows.Forms.NotifyIcon notificationIcon;
        private System.Windows.Forms.Button restoreDefaults;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Label pathlabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

