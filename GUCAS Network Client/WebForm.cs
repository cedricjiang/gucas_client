using System.Windows.Forms;

namespace ATCNC
{
    public partial class WebForm : Form
    {
        public WebForm()
        {
            InitializeComponent();
        }

        // 取MainForm中的NotifyIcon，以便出错时提示
        private NotifyIcon notifier;

        // 加载页面
        public void DoInitialization(NotifyIcon icon)
        {
            notifier = icon;
            fullFunctionWebBrowser.Navigate("https://auth.gucas.ac.cn/");
        }

        // 在加载页面完成时触发一些动作，实现自动登录
        private void fullFunctionWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            switch (e.Url.OriginalString)
            {
                case "https://auth.gucas.ac.cn/":
                    // 如果加载的是首页，则看看是不是加载成功了
                    if (fullFunctionWebBrowser.Document.Title != "宽带计费系统")
                    {
                        // 如果页面标题不是“宽带计费系统”，说明加载失败
                        notifier.ShowBalloonTip(3000, "加载错误", "加载完整功能页面时出错，无法建立网络连接，请检查网络连接，IP配置是否正确。", ToolTipIcon.Error);
                        this.Close();
                    }
                    else
                    {
                        // 反之，加载成功后，遍历表单中的项，进行手工填写，并提交表单，此时将跳转到user_login页面
                        HtmlElement form = fullFunctionWebBrowser.Document.Forms[0];
                        foreach (HtmlElement ele in form.All)
                        {
                            switch (ele.Name)
                            {
                                case "loginuser":
                                    ele.SetAttribute("value", Utility.LoadSettingsAsString("User", ""));
                                    break;
                                case "password":
                                    ele.SetAttribute("value", Utility.LoadSettingsAsString("Pass", ""));
                                    break;
                                case "domainid":
                                    ele.All[Utility.LoadSettingsAsInt("Domain", 0) + 1].SetAttribute("selected", "selected");
                                    break;
                                case "logintype":
                                    ele.SetAttribute("value", "自服务");
                                    break;
                            }
                        }
                        form.InvokeMember("submit");
                    }
                    break;
                case "https://auth.gucas.ac.cn/php/user_login.php":
                    // 如果加载的是user_login页面，则说明是从首页跳转过来的，此时做类似的判断
                    if (fullFunctionWebBrowser.Document.Title != "欢迎您使用计费系统")
                    {
                        // 如果页面标题不是“欢迎您使用计费系统”，说明加载失败
                        notifier.ShowBalloonTip(3000, "加载错误", "加载完整功能页面时出错，请检查您的用户名，密码或登录域信息是否有误。", ToolTipIcon.Error);
                        this.Close();
                    }
                    else
                    {
                        this.Show();
                    }
                    break;
            }
        }

        // 截获一些用户操作
        private void fullFunctionWebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            // 如果用户点击了页面上的退出链接，则不退出，直接关闭窗口
            if (e.Url.OriginalString.StartsWith("https://auth.gucas.ac.cn/php/user_logoff"))
            {
                e.Cancel = true;
                this.Close();
            }
        }

        // 窗口关闭时将状态置为“未打开”
        private void WebForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utility.status = Utility.OpenStatus.None;
        }

        // 窗口关闭时将状态置为“已打开”
        private void WebForm_Shown(object sender, System.EventArgs e)
        {
            Utility.status = Utility.OpenStatus.Opened;
        }
    }
}
