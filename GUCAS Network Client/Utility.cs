using System.Text;
using System.Web;
using Microsoft.Win32;

namespace ATCNC
{
    class Utility
    {
        // 配合实现WebForm不重复显示
        public enum OpenStatus { Opening, Opened, None };
        public static OpenStatus status = OpenStatus.None;

        // 带有URL编码功能的加载字符串设置，用于解决URL中含有特殊符号时的错误问题
        public static string LoadSettingsAsStringWithEncoding(string key, string def)
        {
            RegistryKey reg = Registry.LocalMachine.OpenSubKey("Software", true).CreateSubKey("ATCNC");
            return HttpUtility.UrlEncode(reg.GetValue(key, def) as string, Encoding.GetEncoding("GB2312"));
        }

        // 从注册表中读取信息
        public static string LoadSettingsAsString(string key, string def)
        {
            RegistryKey reg = Registry.LocalMachine.OpenSubKey("Software", true).CreateSubKey("ATCNC");
            return (string)reg.GetValue(key, def);
        }

        public static int LoadSettingsAsInt(string key, int def)
        {
            RegistryKey reg = Registry.LocalMachine.OpenSubKey("Software", true).CreateSubKey("ATCNC");
            return (int)reg.GetValue(key, def);
        }

        public static void SaveSettingsAsString(string key, string value)
        {
            RegistryKey reg = Registry.LocalMachine.OpenSubKey("Software", true).CreateSubKey("ATCNC");
            reg.SetValue(key, value, RegistryValueKind.String);
        }

        // 向注册表中写入信息
        public static void SaveSettingsAsInt(string key, int value)
        {
            RegistryKey reg = Registry.LocalMachine.OpenSubKey("Software", true).CreateSubKey("ATCNC");
            reg.SetValue(key, value, RegistryValueKind.DWord);
        }
    }
}
