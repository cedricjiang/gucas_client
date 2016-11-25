namespace ATCNC
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
            this.components = new System.ComponentModel.Container();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reloginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homeModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offlineModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.viewInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewFeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullFunctionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoLoginSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoLeaveSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.juniorModeSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trafficWarningSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.balanceAlarmSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.domainLabel = new System.Windows.Forms.Label();
            this.domainComboBox = new System.Windows.Forms.ComboBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.startTimer = new System.Windows.Forms.Timer(this.components);
            this.alarmTimer = new System.Windows.Forms.Timer(this.components);
            this.notifyIconContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyIconContextMenuStrip;
            this.notifyIcon.Text = "GUCAS Network Client";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // notifyIconContextMenuStrip
            // 
            this.notifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloginToolStripMenuItem,
            this.modeToolStripMenuItem,
            this.barToolStripMenuItem,
            this.viewInfoToolStripMenuItem,
            this.viewFeeToolStripMenuItem,
            this.fullFunctionToolStripMenuItem,
            this.setupToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.notifyIconContextMenuStrip.Name = "notifyIconContextMenuStrip";
            this.notifyIconContextMenuStrip.Size = new System.Drawing.Size(172, 208);
            this.notifyIconContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.notifyIconContextMenuStrip_Opening);
            // 
            // reloginToolStripMenuItem
            // 
            this.reloginToolStripMenuItem.Name = "reloginToolStripMenuItem";
            this.reloginToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.reloginToolStripMenuItem.Text = "登记用户信息(&L)...";
            this.reloginToolStripMenuItem.Click += new System.EventHandler(this.reloginToolStripMenuItem_Click);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.internationalModeToolStripMenuItem,
            this.homeModeToolStripMenuItem,
            this.manModeToolStripMenuItem,
            this.offlineModeToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.modeToolStripMenuItem.Text = "登录和离线(&M)";
            // 
            // internationalModeToolStripMenuItem
            // 
            this.internationalModeToolStripMenuItem.Name = "internationalModeToolStripMenuItem";
            this.internationalModeToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.internationalModeToolStripMenuItem.Text = "国际模式(&I)";
            this.internationalModeToolStripMenuItem.Click += new System.EventHandler(this.internationalModeToolStripMenuItem_Click);
            // 
            // homeModeToolStripMenuItem
            // 
            this.homeModeToolStripMenuItem.Name = "homeModeToolStripMenuItem";
            this.homeModeToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.homeModeToolStripMenuItem.Text = "国内模式(&H)";
            this.homeModeToolStripMenuItem.Click += new System.EventHandler(this.homeModeToolStripMenuItem_Click);
            // 
            // manModeToolStripMenuItem
            // 
            this.manModeToolStripMenuItem.Name = "manModeToolStripMenuItem";
            this.manModeToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.manModeToolStripMenuItem.Text = "城域模式(&M)";
            this.manModeToolStripMenuItem.Click += new System.EventHandler(this.manModeToolStripMenuItem_Click);
            // 
            // offlineModeToolStripMenuItem
            // 
            this.offlineModeToolStripMenuItem.Name = "offlineModeToolStripMenuItem";
            this.offlineModeToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.offlineModeToolStripMenuItem.Text = "离线(&O)";
            this.offlineModeToolStripMenuItem.Click += new System.EventHandler(this.offlineModeToolStripMenuItem_Click);
            // 
            // barToolStripMenuItem
            // 
            this.barToolStripMenuItem.Name = "barToolStripMenuItem";
            this.barToolStripMenuItem.Size = new System.Drawing.Size(168, 6);
            // 
            // viewInfoToolStripMenuItem
            // 
            this.viewInfoToolStripMenuItem.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.viewInfoToolStripMenuItem.Name = "viewInfoToolStripMenuItem";
            this.viewInfoToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.viewInfoToolStripMenuItem.Text = "查看流量信息(&I)";
            this.viewInfoToolStripMenuItem.Click += new System.EventHandler(this.viewInfoToolStripMenuItem_Click);
            // 
            // viewFeeToolStripMenuItem
            // 
            this.viewFeeToolStripMenuItem.Name = "viewFeeToolStripMenuItem";
            this.viewFeeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.viewFeeToolStripMenuItem.Text = "查看帐户余额(&R)";
            this.viewFeeToolStripMenuItem.Click += new System.EventHandler(this.viewFeeToolStripMenuItem_Click);
            // 
            // fullFunctionToolStripMenuItem
            // 
            this.fullFunctionToolStripMenuItem.Name = "fullFunctionToolStripMenuItem";
            this.fullFunctionToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.fullFunctionToolStripMenuItem.Text = "完整功能(&F)...";
            this.fullFunctionToolStripMenuItem.Click += new System.EventHandler(this.fullFunctionToolStripMenuItem_Click);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoLoginSetupToolStripMenuItem,
            this.autoLeaveSetupToolStripMenuItem,
            this.juniorModeSetupToolStripMenuItem,
            this.trafficWarningSetupToolStripMenuItem,
            this.balanceAlarmSetupToolStripMenuItem});
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.setupToolStripMenuItem.Text = "设置(&S)";
            // 
            // autoLoginSetupToolStripMenuItem
            // 
            this.autoLoginSetupToolStripMenuItem.Name = "autoLoginSetupToolStripMenuItem";
            this.autoLoginSetupToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.autoLoginSetupToolStripMenuItem.Text = "启动后自动连线国际模式(&A)";
            this.autoLoginSetupToolStripMenuItem.Click += new System.EventHandler(this.autoLoginSetupToolStripMenuItem_Click);
            // 
            // autoLeaveSetupToolStripMenuItem
            // 
            this.autoLeaveSetupToolStripMenuItem.Name = "autoLeaveSetupToolStripMenuItem";
            this.autoLeaveSetupToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.autoLeaveSetupToolStripMenuItem.Text = "退出时自动离线(&L)";
            this.autoLeaveSetupToolStripMenuItem.Click += new System.EventHandler(this.autoLeaveSetupToolStripMenuItem_Click);
            // 
            // juniorModeSetupToolStripMenuItem
            // 
            this.juniorModeSetupToolStripMenuItem.Name = "juniorModeSetupToolStripMenuItem";
            this.juniorModeSetupToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.juniorModeSetupToolStripMenuItem.Text = "使用研究生院模式(&G)";
            this.juniorModeSetupToolStripMenuItem.Click += new System.EventHandler(this.juniorModeSetupToolStripMenuItem_Click);
            // 
            // trafficWarningSetupToolStripMenuItem
            // 
            this.trafficWarningSetupToolStripMenuItem.Name = "trafficWarningSetupToolStripMenuItem";
            this.trafficWarningSetupToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.trafficWarningSetupToolStripMenuItem.Text = "开启平均流量警告(&W)";
            this.trafficWarningSetupToolStripMenuItem.Click += new System.EventHandler(this.trafficWarningSetupToolStripMenuItem_Click);
            // 
            // balanceAlarmSetupToolStripMenuItem
            // 
            this.balanceAlarmSetupToolStripMenuItem.Name = "balanceAlarmSetupToolStripMenuItem";
            this.balanceAlarmSetupToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.balanceAlarmSetupToolStripMenuItem.Text = "开启余额不足提醒(&B)";
            this.balanceAlarmSetupToolStripMenuItem.Click += new System.EventHandler(this.balanceAlarmSetupToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.helpToolStripMenuItem.Text = "帮助(&H)...";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.aboutToolStripMenuItem.Text = "关于(&A)...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.exitToolStripMenuItem.Text = "退出(&X)";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // domainLabel
            // 
            this.domainLabel.AutoSize = true;
            this.domainLabel.Location = new System.Drawing.Point(12, 10);
            this.domainLabel.Name = "domainLabel";
            this.domainLabel.Size = new System.Drawing.Size(43, 13);
            this.domainLabel.TabIndex = 1;
            this.domainLabel.Text = "登录域";
            // 
            // domainComboBox
            // 
            this.domainComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.domainComboBox.FormattingEnabled = true;
            this.domainComboBox.Items.AddRange(new object[] {
            "gucas.ac.cn",
            "mails.gucas.ac.cn"});
            this.domainComboBox.Location = new System.Drawing.Point(59, 7);
            this.domainComboBox.Name = "domainComboBox";
            this.domainComboBox.Size = new System.Drawing.Size(196, 21);
            this.domainComboBox.TabIndex = 2;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(59, 35);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(196, 20);
            this.usernameTextBox.TabIndex = 3;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(59, 64);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(196, 20);
            this.passwordTextBox.TabIndex = 4;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(12, 38);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(43, 13);
            this.usernameLabel.TabIndex = 5;
            this.usernameLabel.Text = "用户名";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(12, 67);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(37, 13);
            this.passwordLabel.TabIndex = 6;
            this.passwordLabel.Text = "密  码";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(14, 93);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(241, 25);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "保存设置(下次登录时才会使用)";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // startTimer
            // 
            this.startTimer.Enabled = true;
            this.startTimer.Interval = 1;
            this.startTimer.Tick += new System.EventHandler(this.startTimer_Tick);
            // 
            // alarmTimer
            // 
            this.alarmTimer.Enabled = true;
            this.alarmTimer.Interval = 900000;
            this.alarmTimer.Tick += new System.EventHandler(this.alarmTimer_Tick);
            // 
            // MainForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 125);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.domainLabel);
            this.Controls.Add(this.domainComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "登录信息";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.notifyIconContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyIconContextMenuStrip;
        private System.Windows.Forms.ToolStripSeparator barToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homeModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offlineModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem juniorModeSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem balanceAlarmSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trafficWarningSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoLoginSetupToolStripMenuItem;
        private System.Windows.Forms.Label domainLabel;
        private System.Windows.Forms.ComboBox domainComboBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ToolStripMenuItem autoLeaveSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewFeeToolStripMenuItem;
        private System.Windows.Forms.Timer startTimer;
        private System.Windows.Forms.ToolStripMenuItem fullFunctionToolStripMenuItem;
        private System.Windows.Forms.Timer alarmTimer;
    }
}