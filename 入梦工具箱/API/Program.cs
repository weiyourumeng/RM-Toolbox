using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace 入梦工具箱
{
    static class Program
    {
        [DllImport("kernel32")]
        //                        读配置文件方法的6个参数：所在的分区（section）、键值、     初始缺省值、     StringBuilder、   参数长度上限、配置文件路径
        private static extern int GetPrivateProfileString(string section, string key, string deVal, StringBuilder retVal,
  int size, string filePath);


        public static string 读配置项(string path, string section, string key)
        {
            StringBuilder sb = new StringBuilder(255);
            string strPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + path;//"\\bin\\RMbinconfig.ini"
            //最好初始缺省值设置为非空，因为如果配置文件不存在，取不到值，程序也不会报错
            GetPrivateProfileString(section, key, null, sb, 255, strPath);
            return sb.ToString();

        }

        [DllImport("User32.dll")]
        private static extern void ShowWindowAsync(int hWnd, int nCmdShow);
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            string processName = Process.GetCurrentProcess().ProcessName;
            Process[] processes = Process.GetProcessesByName(processName);
            //如果该数组长度大于1，说明多次运行
            if (processes.Length > 1)
            {
                string HWD1 = 读配置项( "\\Rmdict\\RMbinconfig.ini","Set", "Hwd");
                int HWD = int.Parse(HWD1);
                ShowWindowAsync(HWD, 1);//显示
                //MessageBox.Show("程序已运行，不能再次打开！");
                Environment.Exit(1);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}
