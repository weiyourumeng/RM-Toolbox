using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using SLID = System.Guid;

namespace 入梦语音包
{
    class API
    {
 
        [DllImport("bin//SystemTb.dll")]
        public static extern string Hwinfo(string txt, string txt1);
        public static string 文本_替换字符串(string input, string pattern, string replacement)
        {
            var str = System.Text.RegularExpressions.Regex.Replace(input, pattern, replacement);
            return str;
        }

        public static void 处理器写入路径()
        {
            if (Directory.Exists("tool\\处理器工具") == true)
            {
                取全部文件夹路径(API.默认我的文档() + "\\dict\\config1.ini", "tool//处理器工具");
                if (Directory.Exists("tool\\处理器工具\\CPUZ") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config1.ini", "tool//处理器工具//CPUZ");
                if (Directory.Exists("tool\\处理器工具\\Prime95") == true)
                {
                    取文件夹路径(API.默认我的文档() + "\\dict\\config1.ini", "tool//处理器工具//Prime95");
                    取文件夹路径(API.默认我的文档() + "\\dict\\config9.ini", "tool//处理器工具//Prime95");
                }
                if (Directory.Exists("tool\\处理器工具\\superpi") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config1.ini", "tool//处理器工具//superpi");
                if (Directory.Exists("tool\\处理器工具\\wPrime") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config1.ini", "tool//处理器工具//wPrime");
                if (Directory.Exists("tool\\处理器工具\\XIANGQI") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config1.ini", "tool//处理器工具//XIANGQI");
                if (Directory.Exists("tool\\处理器工具\\ThrottleStop") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config1.ini", "tool//处理器工具//ThrottleStop");
                if (Directory.Exists("tool\\处理器工具\\CoreTemp") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config1.ini", "tool//处理器工具//CoreTemp");
            } 
        }
        public static void 主板工具写入路径()
        {
            if (Directory.Exists("tool\\综合检测") == true)
            {
                //取文件夹路径(API.默认我的文档() + "\\dict\\config2.ini", "tool//综合检测");
                if (Directory.Exists("tool\\综合检测\\aida64") == true)
                {
                    取文件夹路径(API.默认我的文档() + "\\dict\\config2.ini", "tool//综合检测//aida64");
                }
            }
            if (Directory.Exists("tool\\主板工具") == true)
            {
                取全部文件夹路径(API.默认我的文档() + "\\dict\\config2.ini", "tool//主板工具");
         
            }
        }
        public static void 内存工具写入路径()
        {
            if (Directory.Exists("tool\\内存工具") == true)
            {
                取全部文件夹路径(API.默认我的文档() + "\\dict\\config3.ini", "tool//内存工具");
                if (Directory.Exists("tool\\内存工具\\memtest") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config3.ini", "tool//内存工具//memtest");
                if (Directory.Exists("tool\\内存工具\\tm5") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config3.ini", "tool//内存工具//tm5");
                if (Directory.Exists("tool\\内存工具\\Thaiphoon") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config3.ini", "tool//内存工具//Thaiphoon");
                if (Directory.Exists("tool\\内存工具\\魔方内存盘") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config3.ini", "tool//内存工具//魔方内存盘");
            }
        }
        public static void 显卡工具写入路径()
        {
            if (Directory.Exists("tool\\显卡工具") == true)
            {
                取全部文件夹路径(API.默认我的文档() + "\\dict\\config4.ini", "tool//显卡工具");
                if (Directory.Exists("tool\\显卡工具\\GPUZ") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config4.ini", "tool//显卡工具//GPUZ");
                if (Directory.Exists("tool\\显卡工具\\AMDGPUClockTool") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config4.ini", "tool//显卡工具//AMDGPUClockTool");
                if (Directory.Exists("tool\\显卡工具\\DDU v18.0.1.9") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config4.ini", "tool//显卡工具//DDU v18.0.1.9");
                if (Directory.Exists("tool\\显卡工具\\GpuTest_Windows x64") == true)
                {
                    取文件夹路径(API.默认我的文档() + "\\dict\\config4.ini", "tool//显卡工具//GpuTest_Windows x64");
                    取文件夹路径(API.默认我的文档() + "\\dict\\config9.ini", "tool//显卡工具//GpuTest_Windows x64");
                }
                if (Directory.Exists("tool\\显卡工具\\nvidiaInspector") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config4.ini", "tool//显卡工具//nvidiaInspector");
            }
        }
        public static void 硬盘工具写入路径()
        {
            if (Directory.Exists("tool\\硬盘工具") == true)
            {
                取全部文件夹路径(API.默认我的文档() + "\\dict\\config5.ini", "tool//硬盘工具");
                if (Directory.Exists("tool\\硬盘工具\\ASSSDBenchmark") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config5.ini", "tool//硬盘工具//ASSSDBenchmark");
                if (Directory.Exists("tool\\硬盘工具\\ATTODISKBENCHMARK") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config5.ini", "tool//硬盘工具//ATTODISKBENCHMARK");
                if (Directory.Exists("tool\\硬盘工具\\CrystalDiskInfo") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config5.ini", "tool//硬盘工具//CrystalDiskInfo");
                if (Directory.Exists("tool\\硬盘工具\\CrystalDiskMark") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config5.ini", "tool//硬盘工具//CrystalDiskMark");
                if (Directory.Exists("tool\\硬盘工具\\Defraggler") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config5.ini", "tool//硬盘工具//Defraggler");
                if (Directory.Exists("tool\\硬盘工具\\DiskGenius") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config5.ini", "tool//硬盘工具//DiskGenius");
                if (Directory.Exists("tool\\硬盘工具\\finaldata") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config5.ini", "tool//硬盘工具//finaldata");
                if (Directory.Exists("tool\\硬盘工具\\H2testw") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config5.ini", "tool//硬盘工具//H2testw");
                if (Directory.Exists("tool\\硬盘工具\\HDTune") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config5.ini", "tool//硬盘工具//HDTune");
                if (Directory.Exists("tool\\硬盘工具\\LLFTOOL") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config5.ini", "tool//硬盘工具//LLFTOOL");
                if (Directory.Exists("tool\\硬盘工具\\mydisktest") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config5.ini", "tool//硬盘工具//mydisktest");
                if (Directory.Exists("tool\\硬盘工具\\ssdlife") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config5.ini", "tool//硬盘工具//ssdlife");
                if (Directory.Exists("tool\\硬盘工具\\SSDZ") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config5.ini", "tool//硬盘工具//SSDZ");
                if (Directory.Exists("tool\\硬盘工具\\URWTEST") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config5.ini", "tool//硬盘工具//URWTEST");
                if (Directory.Exists("tool\\硬盘工具\\魔方数据恢复") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config5.ini", "tool//硬盘工具//魔方数据恢复");
                if (Directory.Exists("tool\\硬盘工具\\ChipGenius") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config5.ini", "tool//硬盘工具//ChipGenius");
            }
        }
        public static void 显示器工具写入路径()
        {
            if (Directory.Exists("tool\\显示器工具") == true)
            {
                取全部文件夹路径(API.默认我的文档() + "\\dict\\config6.ini", "tool//显示器工具");
                if (Directory.Exists("tool\\显示器工具\\displayx") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config6.ini", "tool//显示器工具//displayx");
                if (Directory.Exists("tool\\显示器工具\\色域检测") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config6.ini", "tool//显示器工具//色域检测");
            }
        }
        public static void 综合检测写入路径()
        { if (Directory.Exists("tool\\综合检测") == true)
            {
                取全部文件夹路径(API.默认我的文档() + "\\dict\\config7.ini", "tool//综合检测");
                if (Directory.Exists("tool\\综合检测\\aida64") == true)
                {
                    取文件夹路径(API.默认我的文档() + "\\dict\\config9.ini", "tool//综合检测//aida64");
                    取文件夹路径(API.默认我的文档() + "\\dict\\config1.ini", "tool//综合检测//aida64");
                    取文件夹路径(API.默认我的文档() + "\\dict\\config7.ini", "tool//综合检测//aida64");
                }
                if (Directory.Exists("tool\\综合检测\\OCCT") == true)
                {
                    取文件夹路径(API.默认我的文档() + "\\dict\\config7.ini", "tool//综合检测//OCCT");
                    取文件夹路径(API.默认我的文档() + "\\dict\\config9.ini", "tool//综合检测//OCCT");
                }
                if (Directory.Exists("tool\\综合检测\\hwinfo") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config7.ini", "tool//综合检测//hwinfo");
                if (Directory.Exists("tool\\综合检测\\RWEverything") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config7.ini", "tool//综合检测//RWEverything");
                if (Directory.Exists("tool\\综合检测\\speccy") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config7.ini", "tool//综合检测//speccy");
                if (Directory.Exists("tool\\综合检测\\HWMonitor") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config7.ini", "tool//综合检测//HWMonitor");
                if (Directory.Exists("tool\\综合检测\\OpenHardwareMonitor") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config7.ini", "tool//综合检测//OpenHardwareMonitor");


            }
      
        }
        public static void 外设工具写入路径()
        {
            if (Directory.Exists("tool\\外设工具") == true)
            {
                取全部文件夹路径(API.默认我的文档() + "\\dict\\config8.ini", "tool//外设工具");
                if (Directory.Exists("tool\\外设工具\\Keyboard Test Utility") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config8.ini", "tool//外设工具//Keyboard Test Utility");
                if (Directory.Exists("tool\\外设工具\\鼠标单机变双击测试器") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config8.ini", "tool//外设工具//鼠标单机变双击测试器");
                if (Directory.Exists("tool\\外设工具\\HuoRong") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config8.ini", "tool//外设工具//HuoRong");
                if (Directory.Exists("tool\\外设工具\\AresonMouseTest") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config8.ini", "tool//外设工具//AresonMouseTest");
                if (Directory.Exists("tool\\外设工具\\MOUSERATE") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config8.ini", "tool//外设工具//MOUSERATE");
             

            }
        }
        public static void 烤鸡工具写入路径()
        {
            if (Directory.Exists("tool\\烤鸡工具") == true)
            {
                取全部文件夹路径(API.默认我的文档() + "\\dict\\config9.ini", "tool//烤鸡工具");
                if (Directory.Exists("tool\\烤鸡工具\\FurMark") == true)
                {
                    取文件夹路径(API.默认我的文档() + "\\dict\\config4.ini", "tool//烤鸡工具//FurMark");
                    取文件夹路径(API.默认我的文档() + "\\dict\\config9.ini", "tool//烤鸡工具//FurMark");
                }
  
            }
        }
        public static void 其他工具写入路径()
        {
            if (Directory.Exists("tool\\其他工具") == true)
            {
                取全部文件夹路径(API.默认我的文档() + "\\dict\\config10.ini", "tool//其他工具");

                if (Directory.Exists("tool\\其他工具\\qudongjingling") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config10.ini", "tool//其他工具//qudongjingling");
                if (Directory.Exists("tool\\其他工具\\bluescreenview") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config10.ini", "tool//其他工具//bluescreenview");
                if (Directory.Exists("tool\\其他工具\\Dism++") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config10.ini", "tool//其他工具//Dism++");
                if (Directory.Exists("tool\\其他工具\\ULTRAISO") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config10.ini", "tool//其他工具//ULTRAISO");
                if (Directory.Exists("tool\\其他工具\\显卡天体图") == true)
                    取全部文件夹路径(API.默认我的文档() + "\\dict\\config4.ini", "tool//其他工具//显卡天体图");
                if (Directory.Exists("tool\\其他工具\\CPU天梯图") == true)
                    取全部文件夹路径(API.默认我的文档() + "\\dict\\config1.ini", "tool//其他工具//CPU天梯图");
                if (Directory.Exists("tool\\其他工具\\内存天梯图") == true)
                    取全部文件夹路径(API.默认我的文档() + "\\dict\\config3.ini", "tool//其他工具//内存天梯图");
                if (Directory.Exists("tool\\其他工具\\360") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config10.ini", "tool//其他工具//360");
                if (Directory.Exists("tool\\其他工具\\KMS") == true)
                    取文件夹路径(API.默认我的文档() + "\\dict\\config10.ini", "tool//其他工具//KMS");
            }
        }
        public static void 自定工具写入路径()
        {
            if (Directory.Exists("tool\\自定义工具") == true)
            {
                //取文件夹路径(API.默认我的文档() + "\\dict\\config11.ini", "tool//自定义工具");
                取全部文件夹路径(API.默认我的文档() + "\\dict\\config11.ini", "tool//自定义工具");
            }
        }
        //取exe文件夹路径
        private static void 取文件夹路径(string pathname, string path)
        {
            var dir = new DirectoryInfo(path);
            FileInfo[] fil = dir.GetFiles("*.exe");
            foreach (FileInfo f in fil)
            {
                FileStream fs = new FileStream(pathname, FileMode.Append);//文本加入不覆盖
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);//转码
                string a =  API.文本_取右边内容(f.FullName, "tool");
                sw.WriteLine(a);

                sw.Flush();//关闭流
                sw.Close();
                fs.Close();
            }
        }
        private static void 取全部文件夹路径(string pathname, string path)
        {
            var dir = new DirectoryInfo(path);
            FileInfo[] fil = dir.GetFiles();
            foreach (FileInfo f in fil)
            {
                //list.Add(f.FullName);//添加文件的bai路径到列表
                FileStream fs = new FileStream(pathname, FileMode.Append);//文本加入不覆盖
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);//转码               
               string a =  API.文本_取右边内容(f.FullName, "tool");
                sw.WriteLine(a);
                //System.Windows.Forms.MessageBox.Show(a);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
            }

        }
        public static void 文件夹_清空(string dir)
        {
            foreach (string d in Directory.GetFileSystemEntries(dir))
            {
                if (File.Exists(d))
                {
                    FileInfo fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        fi.Attributes = FileAttributes.Normal;
                    File.Delete(d);//直接删除其中的文件 
                }
                else
                {
                    DirectoryInfo d1 = new DirectoryInfo(d);
                    if (d1.GetFiles().Length != 0)
                    {
                        文件夹_清空(d1.FullName);////递归删除子文件夹
                    }
                    Directory.Delete(d);
                }
            }
        }
        [DllImport("Kernel32.dll", EntryPoint = "DeleteFileA")]
        public static extern bool 文件_删除(string hw);
        [DllImport("shell32.dll")]
        private static extern int ShellExecuteA(int hwd, string txt, string api, string name1, string name2, int nShowCmd);
        /// <summary>
        /// 执行文件夹或文件或命令(成功返回真,失败返回假)
        /// </summary>
        /// <param name="hwd">欲操作(文件)或(文件夹的名称)或(网址)</param>
        /// <param name="mingling">执行文件的命令行,没有则设为空</param>
        /// <param name="fangshi">0 隐藏窗口 1 普通激活 7 最小化窗口</param>
        public static bool 文件_执行(string name, string mingling, int fangshi)
        {
            if (ShellExecuteA(0, "open", name, mingling, "", fangshi) == 2)
            {
                return false;
            }
            else return true;
        }

        /// <summary>
        /// 运行(隐藏运行BAT)
        /// </summary>
        /// <param name="txt">Environment.CurrentDirectory + "\\tool\\综合检测\\aida64"</param>
        /// <param name="txt1">"FPU.bat"</param>
        public static void 运行(string txt, string txt1)
        {
            try
            {
                string targetDir = txt; //文件夹
                Process proc = new Process();
                proc.StartInfo.WorkingDirectory = targetDir;
                proc.StartInfo.FileName = txt1;
                //proc.StartInfo.Arguments = string.Format("10");//this is argument
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//这里设置DOS窗口不显示，经实践可行
                proc.Start();
                proc.WaitForExit();
            }
            catch 
            {
            }
         
        }
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
            GetPrivateProfileString(section, key, null, sb, 255, path);
            return sb.ToString();
        }


        #endregion
        #region 音频_系统音量
        /// <summary>
        /// 设置系统静音
        /// </summary>
        /// <param name="isMuted">true静音,flase不静音</param>
        public static void 音频_系统静音(bool isMuted)
        {
            IAudioEndpointVolume masterVol = null;
            try
            {
                masterVol = GetMasterVolumeObject();
                if (masterVol == null)
                    return;

                masterVol.SetMute(isMuted, Guid.Empty);
            }
            finally
            {
                if (masterVol != null)
                    Marshal.ReleaseComObject(masterVol);
            }
        }

        #region Abstracted COM interfaces from Windows CoreAudio API
        private static IAudioEndpointVolume GetMasterVolumeObject()
        {
            IMMDeviceEnumerator deviceEnumerator = null;
            IMMDevice speakers = null;
            try
            {
                deviceEnumerator = (IMMDeviceEnumerator)new MMDeviceEnumerator();
                deviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia, out speakers);

                Guid iidIAudioEndpointVolume = typeof(IAudioEndpointVolume).GUID;
                speakers.Activate(ref iidIAudioEndpointVolume, 0, IntPtr.Zero, out var o);
                IAudioEndpointVolume masterVol = (IAudioEndpointVolume)o;

                return masterVol;
            }
            finally
            {
                if (speakers != null) Marshal.ReleaseComObject(speakers);
                if (deviceEnumerator != null) Marshal.ReleaseComObject(deviceEnumerator);
            }
        }
        [ComImport]
        [Guid("BCDE0395-E52F-467C-8E3D-C4579291692E")]
        internal class MMDeviceEnumerator
        {
        }

        internal enum EDataFlow
        {
            eRender,
            eCapture,
            eAll,
            EDataFlow_enum_count
        }

        internal enum ERole
        {
            eConsole,
            eMultimedia,
            eCommunications,
            ERole_enum_count
        }

        [Guid("A95664D2-9614-4F35-A746-DE8DB63617E6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IMMDeviceEnumerator
        {
            int NotImpl1();

            [PreserveSig]
            int GetDefaultAudioEndpoint(EDataFlow dataFlow, ERole role, out IMMDevice ppDevice);

            // the rest is not implemented
        }

        [Guid("D666063F-1587-4E43-81F1-B948E807363F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IMMDevice
        {
            [PreserveSig]
            int Activate(ref Guid iid, int dwClsCtx, IntPtr pActivationParams, [MarshalAs(UnmanagedType.IUnknown)] out object ppInterface);

            // the rest is not implemented
        }



        [Guid("E2F5BB11-0570-40CA-ACDD-3AA01277DEE8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IAudioSessionEnumerator
        {
            [PreserveSig]
            int GetCount(out int SessionCount);

            [PreserveSig]
            int GetSession(int SessionCount, out IAudioSessionControl2 Session);
        }



        [Guid("bfb7ff88-7239-4fc9-8fa2-07c950be9c6d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IAudioSessionControl2
        {
            // IAudioSessionControl
            [PreserveSig]
            int NotImpl0();

            [PreserveSig]
            int GetDisplayName([MarshalAs(UnmanagedType.LPWStr)] out string pRetVal);

            [PreserveSig]
            int SetDisplayName([MarshalAs(UnmanagedType.LPWStr)] string Value, [MarshalAs(UnmanagedType.LPStruct)] Guid EventContext);

            [PreserveSig]
            int GetIconPath([MarshalAs(UnmanagedType.LPWStr)] out string pRetVal);

            [PreserveSig]
            int SetIconPath([MarshalAs(UnmanagedType.LPWStr)] string Value, [MarshalAs(UnmanagedType.LPStruct)] Guid EventContext);

            [PreserveSig]
            int GetGroupingParam(out Guid pRetVal);

            [PreserveSig]
            int SetGroupingParam([MarshalAs(UnmanagedType.LPStruct)] Guid Override, [MarshalAs(UnmanagedType.LPStruct)] Guid EventContext);

            [PreserveSig]
            int NotImpl1();

            [PreserveSig]
            int NotImpl2();

            // IAudioSessionControl2
            [PreserveSig]
            int GetSessionIdentifier([MarshalAs(UnmanagedType.LPWStr)] out string pRetVal);

            [PreserveSig]
            int GetSessionInstanceIdentifier([MarshalAs(UnmanagedType.LPWStr)] out string pRetVal);

            [PreserveSig]
            int GetProcessId(out int pRetVal);

            [PreserveSig]
            int IsSystemSoundsSession();

            [PreserveSig]
            int SetDuckingPreference(bool optOut);
        }

        [Guid("5CDF2C82-841E-4546-9722-0CF74078229A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IAudioEndpointVolume
        {
            [PreserveSig]
            int NotImpl1();

            [PreserveSig]
            int NotImpl2();

            /// <summary>
            /// Gets a count of the channels in the audio stream.
            /// </summary>
            /// <param name="channelCount">The number of channels.</param>
            /// <returns>An HRESULT code indicating whether the operation passed of failed.</returns>
            [PreserveSig]
            int GetChannelCount(
            [Out][MarshalAs(UnmanagedType.U4)] out UInt32 channelCount);

            /// <summary>
            /// Sets the master volume level of the audio stream, in decibels.
            /// </summary>
            /// <param name="level">The new master volume level in decibels.</param>
            /// <param name="eventContext">A user context value that is passed to the notification callback.</param>
            /// <returns>An HRESULT code indicating whether the operation passed of failed.</returns>
            [PreserveSig]
            int SetMasterVolumeLevel(
            [In][MarshalAs(UnmanagedType.R4)] float level,
            [In][MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);

            /// <summary>
            /// Sets the master volume level, expressed as a normalized, audio-tapered value.
            /// </summary>
            /// <param name="level">The new master volume level expressed as a normalized value between 0.0 and 1.0.</param>
            /// <param name="eventContext">A user context value that is passed to the notification callback.</param>
            /// <returns>An HRESULT code indicating whether the operation passed of failed.</returns>
            [PreserveSig]
            int SetMasterVolumeLevelScalar(
            [In][MarshalAs(UnmanagedType.R4)] float level,
            [In][MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);

            /// <summary>
            /// Gets the master volume level of the audio stream, in decibels.
            /// </summary>
            /// <param name="level">The volume level in decibels.</param>
            /// <returns>An HRESULT code indicating whether the operation passed of failed.</returns>
            [PreserveSig]
            int GetMasterVolumeLevel(
            [Out][MarshalAs(UnmanagedType.R4)] out float level);

            /// <summary>
            /// Gets the master volume level, expressed as a normalized, audio-tapered value.
            /// </summary>
            /// <param name="level">The volume level expressed as a normalized value between 0.0 and 1.0.</param>
            /// <returns>An HRESULT code indicating whether the operation passed of failed.</returns>
            [PreserveSig]
            int GetMasterVolumeLevelScalar(
            [Out][MarshalAs(UnmanagedType.R4)] out float level);

            /// <summary>
            /// Sets the volume level, in decibels, of the specified channel of the audio stream.
            /// </summary>
            /// <param name="channelNumber">The channel number.</param>
            /// <param name="level">The new volume level in decibels.</param>
            /// <param name="eventContext">A user context value that is passed to the notification callback.</param>
            /// <returns>An HRESULT code indicating whether the operation passed of failed.</returns>
            [PreserveSig]
            int SetChannelVolumeLevel(
            [In][MarshalAs(UnmanagedType.U4)] UInt32 channelNumber,
            [In][MarshalAs(UnmanagedType.R4)] float level,
            [In][MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);

            /// <summary>
            /// Sets the normalized, audio-tapered volume level of the specified channel in the audio stream.
            /// </summary>
            /// <param name="channelNumber">The channel number.</param>
            /// <param name="level">The new master volume level expressed as a normalized value between 0.0 and 1.0.</param>
            /// <param name="eventContext">A user context value that is passed to the notification callback.</param>
            /// <returns>An HRESULT code indicating whether the operation passed of failed.</returns>
            [PreserveSig]
            int SetChannelVolumeLevelScalar(
            [In][MarshalAs(UnmanagedType.U4)] UInt32 channelNumber,
            [In][MarshalAs(UnmanagedType.R4)] float level,
            [In][MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);

            /// <summary>
            /// Gets the volume level, in decibels, of the specified channel in the audio stream.
            /// </summary>
            /// <param name="channelNumber">The zero-based channel number.</param>
            /// <param name="level">The volume level in decibels.</param>
            /// <returns>An HRESULT code indicating whether the operation passed of failed.</returns>
            [PreserveSig]
            int GetChannelVolumeLevel(
            [In][MarshalAs(UnmanagedType.U4)] UInt32 channelNumber,
            [Out][MarshalAs(UnmanagedType.R4)] out float level);

            /// <summary>
            /// Gets the normalized, audio-tapered volume level of the specified channel of the audio stream.
            /// </summary>
            /// <param name="channelNumber">The zero-based channel number.</param>
            /// <param name="level">The volume level expressed as a normalized value between 0.0 and 1.0.</param>
            /// <returns>An HRESULT code indicating whether the operation passed of failed.</returns>
            [PreserveSig]
            int GetChannelVolumeLevelScalar(
            [In][MarshalAs(UnmanagedType.U4)] UInt32 channelNumber,
            [Out][MarshalAs(UnmanagedType.R4)] out float level);

            /// <summary>
            /// Sets the muting state of the audio stream.
            /// </summary>
            /// <param name="isMuted">True to mute the stream, or false to unmute the stream.</param>
            /// <param name="eventContext">A user context value that is passed to the notification callback.</param>
            /// <returns>An HRESULT code indicating whether the operation passed of failed.</returns>
            [PreserveSig]
            int SetMute(
            [In][MarshalAs(UnmanagedType.Bool)] Boolean isMuted,
            [In][MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);

            /// <summary>
            /// Gets the muting state of the audio stream.
            /// </summary>
            /// <param name="isMuted">The muting state. True if the stream is muted, false otherwise.</param>
            /// <returns>An HRESULT code indicating whether the operation passed of failed.</returns>
            [PreserveSig]
            int GetMute(
            [Out][MarshalAs(UnmanagedType.Bool)] out Boolean isMuted);

            /// <summary>
            /// Gets information about the current step in the volume range.
            /// </summary>
            /// <param name="step">The current zero-based step index.</param>
            /// <param name="stepCount">The total number of steps in the volume range.</param>
            /// <returns>An HRESULT code indicating whether the operation passed of failed.</returns>
            [PreserveSig]
            int GetVolumeStepInfo(
            [Out][MarshalAs(UnmanagedType.U4)] out UInt32 step,
            [Out][MarshalAs(UnmanagedType.U4)] out UInt32 stepCount);

            /// <summary>
            /// Increases the volume level by one step.
            /// </summary>
            /// <param name="eventContext">A user context value that is passed to the notification callback.</param>
            /// <returns>An HRESULT code indicating whether the operation passed of failed.</returns>
            [PreserveSig]
            int VolumeStepUp(
            [In][MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);

            /// <summary>
            /// Decreases the volume level by one step.
            /// </summary>
            /// <param name="eventContext">A user context value that is passed to the notification callback.</param>
            /// <returns>An HRESULT code indicating whether the operation passed of failed.</returns>
            [PreserveSig]
            int VolumeStepDown(
            [In][MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);

            /// <summary>
            /// Queries the audio endpoint device for its hardware-supported functions.
            /// </summary>
            /// <param name="hardwareSupportMask">A hardware support mask that indicates the capabilities of the endpoint.</param>
            /// <returns>An HRESULT code indicating whether the operation passed of failed.</returns>
            [PreserveSig]
            int QueryHardwareSupport(
            [Out][MarshalAs(UnmanagedType.U4)] out UInt32 hardwareSupportMask);

            /// <summary>
            /// Gets the volume range of the audio stream, in decibels.
            /// </summary>
            /// <param name="volumeMin">The minimum volume level in decibels.</param>
            /// <param name="volumeMax">The maximum volume level in decibels.</param>
            /// <param name="volumeStep">The volume increment level in decibels.</param>
            /// <returns>An HRESULT code indicating whether the operation passed of failed.</returns>
            [PreserveSig]
            int GetVolumeRange(
            [Out][MarshalAs(UnmanagedType.R4)] out float volumeMin,
            [Out][MarshalAs(UnmanagedType.R4)] out float volumeMax,
            [Out][MarshalAs(UnmanagedType.R4)] out float volumeStep);
        }

        #endregion

        #endregion

        [DllImport("user32", EntryPoint = "HideCaret")]
        public static extern bool HideCaret(IntPtr hWnd);
        public static string 默认我的文档()
        {   //C:\Users\ru'meng\Documents
            //return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Environment.CurrentDirectory;
        }
        public static string 文本_取右边内容(string str, string s)
        {
            string temp = str.Substring(str.IndexOf(s), str.Length - str.Substring(0, str.IndexOf(s)).Length);
            return temp;
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

        public static string 系统_时区()
        {
            ManagementObjectSearcher driveId = new ManagementObjectSearcher("Select * from Win32_TimeZone");
            foreach (ManagementObject o in driveId.Get())
            {
                return o["Caption"].ToString();
            }
            return null;
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
                return Encoding.UTF8.GetString(buffer);
            }
            catch
            {

            }

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
        [DllImportAttribute("user32.dll")]
        public static extern int FindWindow(string ClassName, string WindowName);

        [DllImport("user32.dll")]
        public static extern int ShowWindow(int handle, int cmdShow);


        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr ptr);
        [DllImport("gdi32.dll")]
        public static extern int GetDeviceCaps(
        IntPtr hdc, // handle to DC
        int nIndex // index of capability
        );
        /// <summary>
        /// 获取真实设置的桌面分辨率大小
        /// </summary>
        public static string 系统_取桌面分辨率()
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            string Width = GetDeviceCaps(hdc, 118).ToString();
            string Height = GetDeviceCaps(hdc, 117).ToString();
            return Width + " * " + Height;
        }
        public static IntPtr 窗口_标题找句柄(string title)
        {
            Process[] ps = Process.GetProcesses();
            foreach (Process p in ps)
            {
                if (p.MainWindowTitle.IndexOf(title) != -1)
                {
                    return p.MainWindowHandle;
                }
            }
            return IntPtr.Zero;
        }
        [DllImport("user32.dll")]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        [DllImport("User32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool 窗口_置焦点(IntPtr hWnd);
        public static bool 进程_是否存在(string newName)
        {
            string programName = newName.Replace(".exe", "");
            return Process.GetProcessesByName(programName).Length > 0 ? true : false;
        }
        public static IntPtr 窗口_标题取句柄(string title)
        {
            Process[] ps = Process.GetProcesses();
            foreach (Process p in ps)
            {
                if (p.MainWindowTitle.IndexOf(title) != -1)
                {
                    return p.MainWindowHandle;
                }
            }
            return IntPtr.Zero;
        }
        [DllImport("user32.dll", EntryPoint = "IsWindow")]
        public static extern int 窗口_是否存在(IntPtr hWnd);
  
        public static void 进程_结束1(string newName)
        {
            Process[] ps = Process.GetProcessesByName(newName);
            if (ps.Length > 0)
            {
                foreach (Process p in ps)
                    p.Kill();
            }
        }
        public static bool 网页_是否联网()
        {
            bool result = false;
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Proxy = null;
                    client.DownloadString("http://www.baidu.com/");
                    result = true;
                }
            }
            catch { }
            return result;
        }
        #region 检查系统激活
        public enum SL_GENUINE_STATE
        {
            SL_GEN_STATE_IS_GENUINE = 0,
            SL_GEN_STATE_INVALID_LICENSE = 1,
            SL_GEN_STATE_TAMPERED = 2,
            SL_GEN_STATE_LAST = 3
        }

        [DllImportAttribute("Slwga.dll", EntryPoint = "SLIsGenuineLocal", CharSet = CharSet.None, ExactSpelling = false, SetLastError = false, PreserveSig = true, CallingConvention = CallingConvention.Winapi, BestFitMapping = false, ThrowOnUnmappableChar = false)]
        [PreserveSigAttribute()]
        internal static extern uint SLIsGenuineLocal(ref SLID slid, [In, Out] ref SL_GENUINE_STATE genuineState, IntPtr val3);


        public static bool IsGenuineWindows()
        {
            bool _IsGenuineWindows = false;
            Guid ApplicationID = new Guid("55c92734-d682-4d71-983e-d6ec3f16059f"); //Application ID GUID http://technet.microsoft.com/en-us/library/dd772270.aspx
            SLID windowsSlid = (Guid)ApplicationID;
            try
            {
                SL_GENUINE_STATE genuineState = SL_GENUINE_STATE.SL_GEN_STATE_LAST;
                uint ResultInt = SLIsGenuineLocal(ref windowsSlid, ref genuineState, IntPtr.Zero);
                if (ResultInt == 0)
                {
                    _IsGenuineWindows = (genuineState == SL_GENUINE_STATE.SL_GEN_STATE_IS_GENUINE);
                }
                else
                {
                    Console.WriteLine("Error getting information {0}", ResultInt.ToString());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return _IsGenuineWindows;


        }


        #endregion
    }
}
