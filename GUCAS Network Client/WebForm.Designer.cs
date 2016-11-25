namespace ATCNC
{
    partial class WebForm
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
            this.fullFunctionWebBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // fullFunctionWebBrowser
            // 
            this.fullFunctionWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fullFunctionWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.fullFunctionWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.fullFunctionWebBrowser.Name = "fullFunctionWebBrowser";
            this.fullFunctionWebBrowser.Size = new System.Drawing.Size(792, 566);
            this.fullFunctionWebBrowser.TabIndex = 0;
            this.fullFunctionWebBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.fullFunctionWebBrowser_Navigating);
            this.fullFunctionWebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.fullFunctionWebBrowser_DocumentCompleted);
            // 
            // WebForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.fullFunctionWebBrowser);
            this.MinimizeBox = false;
            this.Name = "WebForm";
            this.ShowInTaskbar = false;
            this.Text = "完整功能 (https://auth.gucas.ac.cn/php/user_login.php)";
            this.Shown += new System.EventHandler(this.WebForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WebForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser fullFunctionWebBrowser;
    }
}