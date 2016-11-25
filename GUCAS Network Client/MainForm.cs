using System;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ATCNC
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private bool first = true;

        // 实现程序启动时不显示主窗口
        protected override void SetVisibleCore(bool value)
        {
            if (first)
            {
                base.SetVisibleCore(false);
                first = false;
            }
            else
            {
                base.SetVisibleCore(value);
            }
        }

        // 实现启动时保证唯一实例，显示图标和自动连线功能
        private void startTimer_Tick(object sender, EventArgs e)
        {
            // 首先将自己禁用，防止重复连线
            startTimer.Enabled = false;

            //保证只有唯一的实例
            Process self = Process.GetCurrentProcess();
            Process[] proccesses = Process.GetProcessesByName(self.ProcessName);
            foreach (Process p in proccesses)
            {
                // 如果进程文件名相同，但ID不同，则理解成之前启动的一个本程序的实例，此时提示用户并退出
                if (p.MainModule.FileName == self.MainModule.FileName && p.Id != self.Id)
                {
                    MessageBox.Show("本程序只允许运行一个实例，请检查任务栏中是否已经存在控制中心图标。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }

            // 程序启动时该Icon为null，不能显示在任务栏中，赋值后即可显示
            notifyIcon.Icon = Properties.Resources.Offline;

            // 如果设置了自动连线
            if (Utility.LoadSettingsAsInt("AutoLogin", 0) != 0)
            {
                // 提示
                notifyIcon.ShowBalloonTip(3000, "连线中", "根据您的设置（启动后自动连线国际模式），正在为您连线到国际模式，请稍候。", ToolTipIcon.Info);

                // 进行连线操作，并设置Icon状态
                string result = null;
                Network.DoOffline(out result);
                if (Network.DoOnline(Network.OnlineMode.International, out result))
                {
                    notifyIcon.ShowBalloonTip(5000, "提示", "恭喜您以国际方式连线成功！", ToolTipIcon.Info);
                    notifyIcon.Icon = Properties.Resources.Online;
                }
                else
                {
                    notifyIcon.ShowBalloonTip(5000, "错误", "连线时出现错误。" + result, ToolTipIcon.Error);
                }
            }
            else
            {
                // 提示
                notifyIcon.ShowBalloonTip(3000, "欢迎", "本客户端软件已经成功启动，欢迎您的使用。", ToolTipIcon.Info);
            }
        }

        // 当关闭主窗口时，视为不保存设置（也不提示用户），但不退出程序
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        // 在点击保存按钮时保存设置并关闭主窗口
        private void saveButton_Click(object sender, EventArgs e)
        {
            Utility.SaveSettingsAsInt("Domain", domainComboBox.SelectedIndex);
            Utility.SaveSettingsAsString("User", usernameTextBox.Text);
            Utility.SaveSettingsAsString("Pass", passwordTextBox.Text);

            this.Hide();
        }

        // 左键双击时执行默认的查看流量信息功能
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // 这里判断了上下文菜单是否为null，因为在退出时会设置上下文菜单，我们不允许在退出过程中再查看流量信息
            if (e.Button == MouseButtons.Left && notifyIcon.ContextMenuStrip != null)
            {
                viewInfoToolStripMenuItem.PerformClick();
            }
        }

        // 打开菜单时读取设置
        private void notifyIconContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            autoLoginSetupToolStripMenuItem.Checked = Utility.LoadSettingsAsInt("AutoLogin", 0) != 0;
            autoLeaveSetupToolStripMenuItem.Checked = Utility.LoadSettingsAsInt("AutoLeave", 0) != 0;
            juniorModeSetupToolStripMenuItem.Checked = Utility.LoadSettingsAsInt("JuniorMode", 0) != 0;
            trafficWarningSetupToolStripMenuItem.Checked = Utility.LoadSettingsAsInt("TrafficWarning", 0) != 0;
            balanceAlarmSetupToolStripMenuItem.Checked = Utility.LoadSettingsAsInt("BalanceAlarm", 0) != 0;
        }

        // 打开主窗口（登记信息窗口）
        private void reloginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 提取当前设置并显示给用户
            domainComboBox.SelectedIndex = Utility.LoadSettingsAsInt("Domain", 0);
            usernameTextBox.Text = Utility.LoadSettingsAsString("User", "");
            passwordTextBox.Text = Utility.LoadSettingsAsString("Pass", "");

            this.Show();
        }

        // 连线国际模式
        private void internationalModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 类似于自动启动时的连线国际模式的代码，但提示不同，且不需要离线
            notifyIcon.ShowBalloonTip(3000, "连线中", "正在为您连线国际模式，请稍候。", ToolTipIcon.Info);

            // 在连线任何模式前都先尝试离线，但不关心离线是否成功，下同
            string result = null;
            Network.DoOffline(out result);
            if (Network.DoOnline(Network.OnlineMode.International, out result))
            {
                notifyIcon.ShowBalloonTip(5000, "提示", "恭喜您以国际方式连线成功！", ToolTipIcon.Info);
                notifyIcon.Icon = Properties.Resources.Online;
            }
            else
            {
                notifyIcon.ShowBalloonTip(5000, "错误", "连线时出现错误。" + result, ToolTipIcon.Error);
                notifyIcon.Icon = Properties.Resources.Offline;
            }
        }

        // 连线国内模式
        private void homeModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.ShowBalloonTip(3000, "连线中", "正在为您连线国内模式，请稍候。", ToolTipIcon.Info);

            string result = null;
            Network.DoOffline(out result);
            if (Network.DoOnline(Network.OnlineMode.Home, out result))
            {
                notifyIcon.ShowBalloonTip(5000, "提示", "恭喜您以国内方式连线成功！", ToolTipIcon.Info);
                notifyIcon.Icon = Properties.Resources.Online;
            }
            else
            {
                notifyIcon.ShowBalloonTip(5000, "错误", "连线时出现错误。" + result, ToolTipIcon.Error);
                notifyIcon.Icon = Properties.Resources.Offline;
            }
        }

        // 连线城域模式
        private void manModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.ShowBalloonTip(3000, "连线中", "正在为您连线城域模式，请稍候。", ToolTipIcon.Info);

            string result = null;
            Network.DoOffline(out result);
            if (Network.DoOnline(Network.OnlineMode.Man, out result))
            {
                notifyIcon.ShowBalloonTip(5000, "提示", "恭喜您以城域方式连线成功！", ToolTipIcon.Info);
                notifyIcon.Icon = Properties.Resources.Online;
            }
            else
            {
                notifyIcon.ShowBalloonTip(5000, "错误", "连线时出现错误。" + result, ToolTipIcon.Error);
                notifyIcon.Icon = Properties.Resources.Offline;
            }
        }

        // 离线
        private void offlineModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.ShowBalloonTip(3000, "离线中", "正在为您离线，请稍候。", ToolTipIcon.Info);

            string result = null;
            if (Network.DoOffline(out result))
            {
                notifyIcon.ShowBalloonTip(5000, "提示", "您已经成功离线！", ToolTipIcon.Info);
                notifyIcon.Icon = Properties.Resources.Offline;
            }
            else
            {
                notifyIcon.ShowBalloonTip(5000, "错误", "离线时出现错误。" + result, ToolTipIcon.Error);
            }
        }

        // 查询流量
        private void viewInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.ShowBalloonTip(3000, "查询中", "正在为您查询流量信息，请稍候。", ToolTipIcon.Info);

            string query = null;
            if (Network.DoQueryTraffic(out query))
            {
                // 成功的话，query为以竖线分割的查询信息项
                StringBuilder traffic = new StringBuilder();
                string[] subqueries = query.Split(new char[] { '|' });
                traffic.AppendLine("本次连线时间：" + subqueries[0]);
                traffic.AppendLine("本次连线方式：" + subqueries[1]);
                traffic.AppendLine("本月使用费用：" + subqueries[2]);
                traffic.AppendLine("本月城域流量：上行 " + subqueries[3] + "MB，下行 " + subqueries[4] + "MB");
                traffic.AppendLine("本月国内流量：上行 " + subqueries[5] + "MB，下行 " + subqueries[6] + "MB");
                traffic.AppendLine("本月国际流量：上行 " + subqueries[7] + "MB，下行 " + subqueries[8] + "MB");
                notifyIcon.ShowBalloonTip(5000, "流量信息", traffic.ToString(), ToolTipIcon.Info);
            }
            else
            {
                // 不成功的话，query为错误原因
                notifyIcon.ShowBalloonTip(5000, "流量信息", "当前无法查看流量信息，原因：" + query, ToolTipIcon.Error);
            }
        }

        // 查询余额
        private void viewFeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.ShowBalloonTip(3000, "查询中", "正在为您查询帐户余额，请稍候。", ToolTipIcon.Info);

            string query = null;
            if (Network.DoQueryFee(out query))
            {
                // 成功的话，query为余额信息
                notifyIcon.ShowBalloonTip(5000, "帐户余额", "帐户余额：" + query + "元", ToolTipIcon.Info);
            }
            else
            {
                // 不成功的话，query为错误原因
                notifyIcon.ShowBalloonTip(5000, "帐户余额", "当前无法查看帐户余额，原因：" + query, ToolTipIcon.Error);
            }
        }

        // 打开完整功能页面
        private void fullFunctionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 为防止重复打开该页面，使用如下方式
            switch (Utility.status)
            {
                case Utility.OpenStatus.Opening:
                    // 状态为Opening，说明在后台加载该页面但未加载完成，从而未显示，此时不允许再加载
                    notifyIcon.ShowBalloonTip(3000, "已在加载", "已经在为您加载完整功能页面，不允许重复打开，请耐心等待。", ToolTipIcon.Error);
                    break;
                case Utility.OpenStatus.Opened:
                    // 状态为Opened，说明已经加载完成该页面并已显示，此时不允许再加载
                    notifyIcon.ShowBalloonTip(3000, "已经打开", "已经打开了一个完整功能页面，不允许重复打开。", ToolTipIcon.Error);
                    break;
                case Utility.OpenStatus.None:
                    // 状态为None，说明未加载该页面（包括已经关闭），此时请状态改为Opening并开始加载
                    Utility.status = Utility.OpenStatus.Opening;
                    notifyIcon.ShowBalloonTip(3000, "加载中", "正在为您加载完整功能页面，请稍候。", ToolTipIcon.Info);

                    // DoInitialization方法会自动在后台加载页面并在加载完成后显示页面，同时与其它方法配合控制状态
                    WebForm f = new WebForm();
                    f.DoInitialization(notifyIcon);
                    break;
            }
        }

        // 切换自动登录设置
        private void autoLoginSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 点击时切换状态并保存设置，下周
            autoLoginSetupToolStripMenuItem.Checked = !autoLoginSetupToolStripMenuItem.Checked;
            Utility.SaveSettingsAsInt("AutoLogin", autoLoginSetupToolStripMenuItem.Checked ? 1 : 0);
        }

        // 切换退出离线设置
        private void autoLeaveSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoLeaveSetupToolStripMenuItem.Checked = !autoLeaveSetupToolStripMenuItem.Checked;
            Utility.SaveSettingsAsInt("AutoLeave", autoLeaveSetupToolStripMenuItem.Checked ? 1 : 0);
        }

        // 切换研一模式设置
        private void juniorModeSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            juniorModeSetupToolStripMenuItem.Checked = !juniorModeSetupToolStripMenuItem.Checked;
            Utility.SaveSettingsAsInt("JuniorMode", juniorModeSetupToolStripMenuItem.Checked ? 1 : 0);
        }

        // 切换余额报警设置
        private void balanceAlarmSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            balanceAlarmSetupToolStripMenuItem.Checked = !balanceAlarmSetupToolStripMenuItem.Checked;
            Utility.SaveSettingsAsInt("BalanceAlarm", balanceAlarmSetupToolStripMenuItem.Checked ? 1 : 0);
        }

        // 切换流量报警设置
        private void trafficWarningSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trafficWarningSetupToolStripMenuItem.Checked = !trafficWarningSetupToolStripMenuItem.Checked;
            Utility.SaveSettingsAsInt("TrafficWarning", trafficWarningSetupToolStripMenuItem.Checked ? 1 : 0);
        }

        // 显示帮助
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Properties.Resources.Help, "帮助信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 显示关于
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Properties.Resources.About, "关于本软件", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 退出功能
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 退出时按设置决定是否要离线
            if (Utility.LoadSettingsAsInt("AutoLeave", 0) != 0)
            {
                notifyIcon.ShowBalloonTip(3000, "检查在线状态", "根据您的设置（退出时自动离线），正在检查您的在线状态并准备离线，请稍候。", ToolTipIcon.Info);

                // 退出时关闭Icon上下文菜单
                notifyIcon.ContextMenuStrip = null;

                string result = null;
                if (!Network.DoOffline(out result))
                {
                    // 如果离线出错，但原因是没有在此IP连线，则不提示，否则提示离线不成功，需要手工检查在线状态
                    if (result != "您还没有使用当前帐户信息在此IP连线网络。")
                    {
                        MessageBox.Show("离线时出现问题，请在程序退出后手工检查在线状态以防止流量被他人使用。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            Application.Exit();
        }

        // 每15分钟运行一次，检查余额和流量信息
        private void alarmTimer_Tick(object sender, EventArgs e)
        {
            // 取当前时间，后面要用到
            DateTime now = DateTime.Now;

            // 如果打开了流量报警功能
            if (Utility.LoadSettingsAsInt("TrafficWarning", 0) != 0)
            {
                // 查询流量
                string query = null;
                if (Network.DoQueryTraffic(out query))
                {
                    // 只使用国内和国际下行流量，其它信息用不上
                    string[] subqueries = query.Split(new char[] { '|' });
                    double homedown = double.Parse(subqueries[6]);
                    double intdown = double.Parse(subqueries[8]);

                    // 根据是否为研一模式来决定上限是什么，然后乘以本月已经过去的天数占总天数的比例，为到此为止平均情况下能免费使用的流量上限
                    double homedownlimit = (Utility.LoadSettingsAsInt("JuniorMode", 0) == 0 ? 5120.0 : 2048.0) * now.Day / DateTime.DaysInMonth(now.Year, now.Month);
                    double intdownlimit = (Utility.LoadSettingsAsInt("JuniorMode", 0) == 0 ? 2048.0 : 1024.0) * now.Day / DateTime.DaysInMonth(now.Year, now.Month);

                    // 分别就国内和国际两个下行流量提出报警
                    StringBuilder alarm = new StringBuilder();
                    bool needAlarm = false;
                    if (homedown > homedownlimit)
                    {
                        alarm.AppendLine("您已经使用了国内下行流量为" + homedown.ToString() + "MB，超过了到本日为止的可免费使用流量" + homedownlimit.ToString() + "，请节约使用。");
                        needAlarm = true;
                    }
                    if (intdown > intdownlimit)
                    {
                        alarm.AppendLine("您已经使用了国际下行流量为" + intdown.ToString() + "MB，超过了到本日为止的可免费使用流量" + intdownlimit.ToString() + "，请节约使用。");
                        needAlarm = true;
                    }
                    if (needAlarm)
                    {
                        notifyIcon.ShowBalloonTip(3000, "平均流量警告", alarm.ToString(), ToolTipIcon.Warning);
                    }
                }
            }

            // 如果打开了余额提醒功能
            if (Utility.LoadSettingsAsInt("BalanceAlarm", 0) != 0)
            {
                // 对于研一模式，以及非当月最后5天的情况，即使打开了此功能也不提醒
                if (Utility.LoadSettingsAsInt("JuniorMode", 0) == 0 && now.AddDays(5).Month != now.Month)
                {
                    string query = null;
                    if (Network.DoQueryFee(out query))
                    {
                        // 小于50元则提醒
                        if (double.Parse(query) < 50.0)
                        {
                            notifyIcon.ShowBalloonTip(3000, "余额不足提醒", "您的余额已经不足50元，为保障您的正常使用，您可能需要及时交费。", ToolTipIcon.Warning);
                        }
                    }
                }
            }
        }
    }
}