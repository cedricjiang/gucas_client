using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace ATCNC
{
    class Network
    {
        public enum OnlineMode { Man = 0, Home, International };

        // 连线功能，mode提供连线模式，result返回连线结果信息，程序返回是否成功
        public static bool DoOnline(OnlineMode mode, out string result)
        {
            // 定义url，并获取相关信息
            string url = "https://auth.gucas.ac.cn/php/login_net.php?mode=" + ((int)mode).ToString(), got, err;
            DoGet(url, out got, out err);

            // 如果err为null，则说明在成功连上了这个url并获取了相关信息；否则err为失败原因
            if (err == null)
            {
                // 根据返回HTML页面的内容来判断是否连线成功，或失败原因
                if (got.IndexOf("连线成功") != -1)
                {
                    result = null;
                    return true;
                }
                if (got.IndexOf("用户被锁定") != -1)
                {
                    result = "您的帐户已经因流量超支而锁定。";
                    return false;
                }
                if (got.IndexOf("已经在此IP连线") != -1)
                {
                    result = "当前IP已经有帐号在线。";
                    return false;
                }
                if (got.IndexOf("已达到最大连线数") != -1)
                {
                    result = "您的帐号在其它IP上已连线，请先强制帐号离线。";
                    return false;
                }
                if (got.IndexOf("不在许可登录范围之内") != -1)
                {
                    result = "您的IP不在许可登录范围之内，请检查IP地址配置，以及代理使用情况。";
                    return false;
                }
                if (got.IndexOf("没有登录或已经超时") != -1)
                {
                    result = "您的用户名，密码或登录域信息有误，请检查。";
                    return false;
                }
                result = "错误原因不明。";
                return false;
            }
            else
            {
                result = "无法建立到认证服务器auth.gucas.ac.cn的连接，请检查网络连接，IP配置是否正确。提示信息：" + err;
                return false;
            }
        }

        // 离线功能，类似连线功能，只是没有mode
        public static bool DoOffline(out string result)
        {
            string url = "https://auth.gucas.ac.cn/php/logout_net.php", got, err;
            DoGet(url, out got, out err);

            if (err == null)
            {
                if (got.IndexOf("离线成功") != -1)
                {
                    result = null;
                    return true;
                }
                if (got.IndexOf("没有登录或已经超时") != -1)
                {
                    result = "您的用户名，密码或登录域信息有误，请检查。";
                    return false;
                }
                if (got.IndexOf("用户没有在此IP连线") != -1)
                {
                    result = "您还没有使用当前帐户信息在此IP连线网络。";
                    return false;
                }
                result = "错误原因不明。";
                return false;
            }
            else
            {
                result = "建立网络连接时出错，请检查网络连接，IP配置是否正确。提示信息：" + err;
                return false;
            }
        }

        // 流量查询，类似连线功能
        public static bool DoQueryTraffic(out string result)
        {
            string url = "https://auth.gucas.ac.cn/php/onlinestatus.php", got, err;
            DoGet(url, out got, out err);
            if (err == null)
            {
                if (got.IndexOf("您已经在本机连线网络") != -1)
                {
                    // 如果已经连线，则从页面上用正则表达式匹配出相关信息并以特定格式返回
                    Match m = Regex.Match(got, "连线时间.*?center\">(?<time>.*?)</div>.*?center.*?城域流量.*?right\">(?<manup>.*?)&nb.*?↑<br>(?<mandown>.*?)&nbsp;.*?连线方式.*?<div align=\"center\">(?<way>.*?)</div>.*?国内流量.*?right\">(?<homeup>.*?)&nb.*?↑<br>(?<homedown>.*?)&nb.*?总费用.*?center\">(?<money>.*?)</div>.*?国际流量.*?right\">(?<intup>.*?)&nb.*?↑<br>(?<intdown>.*?)&nbsp", RegexOptions.Singleline);
                    result = m.Result("${time}|${way}|${money}|${manup}|${mandown}|${homeup}|${homedown}|${intup}|${intdown}");
                    return true;
                }
                if (got.IndexOf("没有登录或已经超时") != -1)
                {
                    result = "您的用户名，密码或登录域信息有误，请检查。";
                    return false;
                }
                if (got.IndexOf("没有从本机登录网络") != -1)
                {
                    result = "您没有连线到网络，从而无法查询流量信息，请先连线。";
                    return false;
                }
                result = "错误原因不明。";
                return false;
            }
            else
            {
                result = "建立网络连接时出错，请检查网络连接，IP配置是否正确。提示信息：" + err;
                return false;
            }
        }

        // 余额查询，类似流量查询
        public static bool DoQueryFee(out string result)
        {
            string url = "https://auth.gucas.ac.cn/php/remain_fee.php", got, err;
            DoGet(url, out got, out err);
            if (err == null)
            {
                if (got.IndexOf("查询成功") != -1)
                {
                    Match m = Regex.Match(got, "当前余额<br><b>(?<money>.*?)</b>&nbsp;元");
                    result = m.Result("${money}");
                    return true;
                }
                if (got.IndexOf("没有登录或已经超时") != -1)
                {
                    result = "您的用户名，密码或登录域信息有误，请检查。";
                    return false;
                }
                result = "错误原因不明。";
                return false;
            }
            else
            {
                result = "建立网络连接时出错，请检查网络连接，IP配置是否正确。提示信息：" + err;
                return false;
            }
        }

        // 核心交互函数
        private static void DoGet(string url, out string html, out string err)
        {
            html = err = null;
            try
            {
                // 首先构造要POST到user_login页面的数据
                StringBuilder data = new StringBuilder();
                data.Append("loginuser=");
                data.Append(Utility.LoadSettingsAsStringWithEncoding("User", ""));
                data.Append("&password=");
                data.Append(Utility.LoadSettingsAsStringWithEncoding("Pass", ""));
                data.Append("&domainid=");
                data.Append(Utility.LoadSettingsAsInt("Domain", 0) + 1);

                // 建立WebClient，并设置请求头部为提供Web表单，设置编码为GB2312
                WebClient wc = new WebClient();
                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                wc.Encoding = Encoding.GetEncoding("GB2312");

                // 向该页面以POST方式提交数据，我们不关心返回的数据，只关心响应头部中的Cookie信息
                wc.UploadString("https://auth.gucas.ac.cn/php/user_login.php", data.ToString());

                // 从响应头部中获取Cookie信息并置入请求头部，以此获取得到的页面
                wc.Headers.Add("Cookie", wc.ResponseHeaders["Set-Cookie"]);
                html = wc.DownloadString(url);
            }
            catch (Exception e)
            {
                // 出错时，err置为错误信息
                err = e.Message;
            }
        }
    }
}
