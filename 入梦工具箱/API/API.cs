using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;


namespace 入梦语音包
{
    class API
    {
        #region API取配置项
        [DllImport("kernel32")]
        //                        读配置文件方法的6个参数：所在的分区（section）、键值、     初始缺省值、     StringBuilder、   参数长度上限、配置文件路径
        private static extern int GetPrivateProfileString(string section, string key, string deVal, StringBuilder retVal,
    int size, string filePath);

        [DllImport("kernel32")]
        //                            写配置文件方法的4个参数：所在的分区（section）、  键值、     参数值、        配置文件路径
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        public static void 写配置项(string path, string section, string key, string value)
        {
           
            WritePrivateProfileString(section, key, value,  path);
        }

        public static string 读配置项(string path, string section, string key)
        {
            StringBuilder sb = new StringBuilder(255);
            //最好初始缺省值设置为非空，因为如果配置文件不存在，取不到值，程序也不会报错
            GetPrivateProfileString(section, key, null, sb, 255, path);
            return sb.ToString();

        }


        #endregion

        public static string 默认我的文档()
        {   //C:\Users\ru'meng\Documents
            return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        }
        [DllImport("user32.dll")]
        private static extern int MessageBoxTimeoutA(IntPtr hwnd, string lptex, string lpCaption, int uType, int wlange, int dwTimeout);
        public static void 信息框(string txt, string txt1, int dwTimeout)
        {
            MessageBoxTimeoutA(Process.GetCurrentProcess().MainWindowHandle, txt, txt1, 0, 0, dwTimeout);
        }
        public static string 系统_64位()
        {
            if (Environment.Is64BitOperatingSystem==true)
            {
                return "64";
            }
            else return "32";
        }
        public static string 系统_获取硬盘的大小()
        {
            ManagementClass mc = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection moj = mc.GetInstances();
            foreach (ManagementObject m in moj)
            {
                long.TryParse(m.Properties["Size"].Value.ToString(), out long size);

                if (size > 0)
                {
                    size = size / 1024 / 1024 / 1024;
                    return size.ToString() + " G";
                }

                return "-1";
            }
            return "-1";



        }


        public static string 取系统语言()
        {
            return System.Globalization.CultureInfo.InstalledUICulture.Name;
        }

        public static string 网页_访问(string webpath)
        {
            WebClient client = new WebClient();
            try
            {
                byte[] buffer = client.DownloadData(webpath);
                return Encoding.ASCII.GetString(buffer);
            }
            catch
            {

            }

            // string res = Encoding.ASCII.GetString(buffer);

            return null;
        }
   
        [DllImport("user32.dll")]
        private static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);
        public static int 窗口_置顶(IntPtr hWnd, bool is_activ)
        {
            int is_top;
            if (is_activ == true)
            {
                is_top = -1;
            }
            else is_top = -2;

            return SetWindowPos(hWnd, is_top, 0, 0, 0, 0, 1 | 2);
        }

 
    }
}
