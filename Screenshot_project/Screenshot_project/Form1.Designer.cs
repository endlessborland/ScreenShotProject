namespace Screenshot_project
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeAScreenshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(90, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "Screenshot!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "This thing screenshots, yeah.";
            this.notifyIcon1.BalloonTipTitle = "Screenshot";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ScreenShot";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.makeAScreenshotToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(165, 70);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // makeAScreenshotToolStripMenuItem
            // 
            this.makeAScreenshotToolStripMenuItem.Name = "makeAScreenshotToolStripMenuItem";
            this.makeAScreenshotToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.makeAScreenshotToolStripMenuItem.Text = "Make a screenshot";
            this.makeAScreenshotToolStripMenuItem.Click += new System.EventHandler(this.makeAScreenshotToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(90, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(227, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Upload URL";
            // 
            // Form1
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 102);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "ScreenShotTool";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeAScreenshotToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}

