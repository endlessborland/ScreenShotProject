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
            this.url_input = new System.Windows.Forms.TextBox();
            this.Notification_Icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.Screenshot_button = new System.Windows.Forms.Button();
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
            // url_input
            // 
            this.url_input.Location = new System.Drawing.Point(48, 9);
            this.url_input.Name = "url_input";
            this.url_input.Size = new System.Drawing.Size(328, 20);
            this.url_input.TabIndex = 2;
            // 
            // Notification_Icon
            // 
            this.Notification_Icon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.Notification_Icon.BalloonTipText = "This thing screenshots, yeah.";
            this.Notification_Icon.BalloonTipTitle = "Screenshot";
            this.Notification_Icon.Icon = ((System.Drawing.Icon)(resources.GetObject("Notification_Icon.Icon")));
            this.Notification_Icon.Text = "ScreenShot";
            this.Notification_Icon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Notification_Icon_MouseDoubleClick_1);
            // 
            // Screenshot_button
            // 
            this.Screenshot_button.Location = new System.Drawing.Point(15, 35);
            this.Screenshot_button.Name = "Screenshot_button";
            this.Screenshot_button.Size = new System.Drawing.Size(361, 67);
            this.Screenshot_button.TabIndex = 3;
            this.Screenshot_button.Text = "ScreenShot!";
            this.Screenshot_button.UseVisualStyleBackColor = true;
            this.Screenshot_button.Click += new System.EventHandler(this.Screenshot_button_Click);
            // 
            // TestWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 112);
            this.Controls.Add(this.Screenshot_button);
            this.Controls.Add(this.url_input);
            this.Controls.Add(this.url_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "TestWindow";
            this.Text = "Settings";
            this.Resize += new System.EventHandler(this.TestWindow_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label url_label;
        private System.Windows.Forms.TextBox url_input;
        private System.Windows.Forms.NotifyIcon Notification_Icon;
        private System.Windows.Forms.Button Screenshot_button;
    }
}

