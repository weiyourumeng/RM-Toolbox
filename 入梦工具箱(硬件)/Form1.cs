using KeyHook;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using 入梦语音包;
using 入梦语音包.Properties;

namespace 入梦工具箱
{
    public partial class Form1 : Form
    {
        string lag = System.Globalization.CultureInfo.InstalledUICulture.Name.ToLower();//系统语言获取
        string 功能配置路径 = API.默认我的文档() + "\\dict\\RMbinconfig.ini";
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.Size = new Size(panel1.Size.Width + 2, panel1.Size.Height + 2);

        }
        #region 初始化
        API aPI = new API();
        KeyboardHook k_hook = new KeyboardHook();//实例化键盘钩子
        delegate void SetTextCallback(string text);
        private delegate void SetBut();

        public static void 程序_延时(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                Application.DoEvents();//转让控制权
            }
        }
        private void inthook(object sender, KeyEventArgs e)//消息循环
        {
            if (checkBox1.Checked == true)
            {
                if (e.KeyCode == Keys.F12)
                {
                    显示();
                }
            }
        }
        Color 前景 = Color.FromArgb(240, 240, 240);
        Color 背景 = Color.FromArgb(224, 224, 224);
        List<string> lines = new List<string>();
        List<string> lines2 = new List<string>();
        List<string> lines3 = new List<string>();
        List<string> lines4 = new List<string>();
        List<string> lines5 = new List<string>();
        List<string> lines6 = new List<string>();
        List<string> lines7 = new List<string>();
        List<string> lines8 = new List<string>();
        List<string> lines9 = new List<string>();
        List<string> lines10 = new List<string>();
        List<string> lines11 = new List<string>();
        //List<string> lines12 = new List<string>();
        //List<string> lines13 = new List<string>();

        private static bool IsDragging = false; //用于指示当前是不是在拖拽状态
        private Point StartPoint = new Point(0, 0); //记录鼠标按下去的坐标, new是为了拿到空间, 两个0无所谓的
        //记录动了多少距离,然后给窗体Location赋值,要设置Location,必须用一个Point结构体,不能直接给Location的X,Y赋值
        private Point OffsetPoint = new Point(0, 0);
        private void 窗口移动_鼠标按下(object sender, MouseEventArgs e)
        {   //如果按下去的按钮不是左键就return,节省运算资源
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            //按下鼠标后,进入拖动状态:
            IsDragging = true;
            //保存刚按下时的鼠标坐标
            StartPoint.X = e.X;
            StartPoint.Y = e.Y;

        }
        private void 窗口移动_鼠标移动(object sender, MouseEventArgs e)
        {//鼠标移动时调用,检测到IsDragging为真时
            if (IsDragging == true)
            {   //用当前坐标减去起始坐标得到偏移量Offset
                OffsetPoint.X = e.X - StartPoint.X;
                OffsetPoint.Y = e.Y - StartPoint.Y;
                //将Offset转化为屏幕坐标赋值给Location,设置Form在屏幕中的位置,如果不作PointToScreen转换,你自己看看效果就好
                Location = PointToScreen(OffsetPoint);
            }
        }

        private void 窗口移动_鼠标左键弹起(object sender, MouseEventArgs e)
        {   //左键抬起时,及时把拖动判定设置为false,否则,你也可以试试效果
            IsDragging = false;
        }
        private void 滑块条1_位置(object sender, EventArgs e)
        {
            listView1.Size = new Size(panel4.Size.Width - 2, panel4.Size.Height);
            listView1.Location = new Point(panel4.Location.X, pictureBox9.Location.Y);
            listView1.BackColor = Color.White;
            listView2.Size = new Size(panel4.Size.Width - 2, panel4.Size.Height);
            listView2.Location = new Point(panel4.Location.X, pictureBox9.Location.Y);
            listView2.BackColor = Color.White;
            listView3.Size = new Size(panel4.Size.Width - 2, panel4.Size.Height);
            listView3.Location = new Point(panel4.Location.X, pictureBox9.Location.Y);
            listView3.BackColor = Color.White;
            listView4.Size = new Size(panel4.Size.Width - 2, panel4.Size.Height);
            listView4.Location = new Point(panel4.Location.X, pictureBox9.Location.Y);
            listView4.BackColor = Color.White;
            listView5.Size = new Size(panel4.Size.Width - 2, panel4.Size.Height);
            listView5.Location = new Point(panel4.Location.X, pictureBox9.Location.Y);
            listView5.BackColor = Color.White;
            listView6.Size = new Size(panel4.Size.Width - 2, panel4.Size.Height);
            listView6.Location = new Point(panel4.Location.X, pictureBox9.Location.Y);
            listView6.BackColor = Color.White;
            listView7.Size = new Size(panel4.Size.Width - 2, panel4.Size.Height);
            listView7.Location = new Point(panel4.Location.X, pictureBox9.Location.Y);
            listView7.BackColor = Color.White;
            listView8.Size = new Size(panel4.Size.Width - 2, panel4.Size.Height);
            listView8.Location = new Point(panel4.Location.X, pictureBox9.Location.Y);
            listView8.BackColor = Color.White;
            listView9.Size = new Size(panel4.Size.Width - 2, panel4.Size.Height);
            listView9.Location = new Point(panel4.Location.X, pictureBox9.Location.Y);
            listView9.BackColor = Color.White;
            listView10.Size = new Size(panel4.Size.Width - 2, panel4.Size.Height);
            listView10.Location = new Point(panel4.Location.X, pictureBox9.Location.Y);
            listView10.BackColor = Color.White;

            listView11.Size = new Size(panel4.Size.Width - 2, panel4.Size.Height);
            listView11.Location = new Point(panel4.Location.X, pictureBox9.Location.Y);
            listView11.BackColor = Color.White;

            panel3.Location = new Point(panel4.Location.X + pictureBox14.Width + 1, panel4.Location.Y);
            panel3.Size = new Size(panel4.Size.Width, panel4.Size.Height);

            panel14.Location = new Point(panel4.Location.X + pictureBox14.Width + 1, panel4.Location.Y);
            panel14.Size = new Size(panel4.Size.Width, panel4.Size.Height);

            panel12.Location = new Point(panel4.Location.X + pictureBox14.Width + 1, panel4.Location.Y);
            panel12.Size = new Size(panel4.Size.Width, panel4.Size.Height);
            textBox14.Location = new Point(textBox1.Location.X - 30, textBox1.Location.Y + 5);
            textBox14.Size = new Size(textBox1.Size.Width, 457);

            textBox15.Location = new Point(panel4.Location.X + 1, label103.Location.Y + label103.Height + 1);
            textBox15.Size = new Size(panel12.Width, panel12.Height);
        }
        #endregion  
        #region API获取目录ICO

        [DllImport("shell32.dll", EntryPoint = "SHGetFileInfo")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttribute, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint Flags);
        [DllImport("User32.dll", EntryPoint = "DestroyIcon")]
        public static extern int DestroyIcon(IntPtr hIcon);
        public struct SHFILEINFO  //调用API获取目录ICO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        #endregion
        #region 初始化方法
        private void pictureBox14_Click(object sender, EventArgs e)
        { swichbox();
            滑块();
            滑标.Location = pictureBox14.Location;
            label27.BackColor = 背景;
            pictureBox14.BackColor = 背景;
            textBox15.Visible = false;
            if (语言选择框.SelectedIndex == 0)
            {
                if (label93.Text == "返回")
                {
                    label93.Text = "详细信息";

                    label93.Location = new Point(label103.Location.X - 147, label103.Location.Y);
                }
                else
                {
                    label93.Text = "返回";
                    label93.Location = new Point(label103.Location.X - 120, label103.Location.Y);
                }
            }
            else
            {
                if (label93.Text == "Return")
                {
                    label93.Text = "Detailed";
                    label93.Location = new Point(label103.Location.X - 147, label103.Location.Y);
                }
                else
                {
                    label93.Text = "Return";
                    label93.Location = new Point(label103.Location.X - 138, label103.Location.Y);
                }

            }
            if (checkBox2.Checked == true)
            {
                panel12.Visible = true;
                panel4.Visible = false;
            }
            else
            {

                panel12.Visible = false;
                panel4.Visible = true;
            }
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            swichbox();
            滑块();
            滑标.Location = pictureBox9.Location;
            label4.BackColor = 背景;
            pictureBox9.BackColor = 背景;
            listView1.Visible = true;

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            swichbox();
            滑块();
            滑标.Location = pictureBox1.Location;
            label5.BackColor = 背景;
            pictureBox1.BackColor = 背景;
            listView2.Visible = true;

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            swichbox();
            滑块();
            滑标.Location = pictureBox2.Location;
            label6.BackColor = 背景;
            pictureBox2.BackColor = 背景;
            listView3.Visible = true;

        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            swichbox();
            滑块();
            滑标.Location = pictureBox4.Location;
            label7.BackColor = 背景;
            pictureBox4.BackColor = 背景;
            listView4.Visible = true;

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            swichbox();
            滑块();
            滑标.Location = pictureBox3.Location;
            label8.BackColor = 背景;
            pictureBox3.BackColor = 背景;
            listView5.Visible = true;

        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            swichbox();
            滑块();
            滑标.Location = pictureBox8.Location;
            label9.BackColor = 背景;
            pictureBox8.BackColor = 背景;
            listView6.Visible = true;

        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            swichbox();
            滑块();
            滑标.Location = pictureBox7.Location;
            label10.BackColor = 背景;
            pictureBox7.BackColor = 背景;
            listView7.Visible = true;

        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            swichbox();
            滑块();
            滑标.Location = pictureBox6.Location;
            label11.BackColor = 背景;
            pictureBox6.BackColor = 背景;
            listView8.Visible = true;

        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            swichbox();
            滑块();
            滑标.Location = pictureBox5.Location;
            label12.BackColor = 背景;
            pictureBox5.BackColor = 背景;
            listView9.Visible = true;

        }
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            swichbox();
            滑块();
            滑标.Location = pictureBox12.Location;
            label13.BackColor = 背景;
            pictureBox12.BackColor = 背景;
            listView10.Visible = true;

        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            swichbox();
            滑块();
            滑标.Location = pictureBox11.Location;
            label14.BackColor = 背景;
            pictureBox11.BackColor = 背景;
            listView11.Visible = true;

        }
        private void label104_Click(object sender, EventArgs e)
        {
            pictureBox16_Click(sender, e);
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            swichbox();
            滑块();
            滑标.Location = pictureBox16.Location;
            label104.BackColor = 背景;
            pictureBox16.BackColor = 背景;
            panel3.Visible = true;
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            swichbox();
            滑块();
            滑标.Location = pictureBox10.Location;
            label15.BackColor = 背景;
            pictureBox10.BackColor = 背景;
            panel14.Visible = true;
        }
        private void label15_Click(object sender, EventArgs e)
        {
            pictureBox10_Click(sender, e);
        }
        private void label4_Click(object sender, EventArgs e)
        {
            pictureBox9_Click(sender, e);
        }
        private void label5_Click(object sender, EventArgs e)
        {
            pictureBox1_Click(sender, e);
        }
        private void label6_Click(object sender, EventArgs e)
        {
            pictureBox2_Click(sender, e);
        }
        private void label7_Click(object sender, EventArgs e)
        {
            pictureBox4_Click(sender, e);
        }
        private void label8_Click(object sender, EventArgs e)
        {
            pictureBox3_Click(sender, e);
        }
        private void label9_Click(object sender, EventArgs e)
        {
            pictureBox8_Click(sender, e);
        }
        private void label10_Click(object sender, EventArgs e)
        {
            pictureBox7_Click(sender, e);
        }
        private void label11_Click(object sender, EventArgs e)
        {
            pictureBox6_Click(sender, e);
        }
        private void label12_Click(object sender, EventArgs e)
        {
            pictureBox5_Click(sender, e);
        }
        private void label13_Click(object sender, EventArgs e)
        {
            pictureBox12_Click(sender, e);
        }
        private void label14_Click(object sender, EventArgs e)
        {
            pictureBox11_Click(sender, e);
        }
    
        private void label27_Click(object sender, EventArgs e)
        {
            pictureBox14_Click(sender, e);
        }
        private void swichbox()
        {
            listView1.SelectedItems.Clear();
            listView2.SelectedItems.Clear();
            listView3.SelectedItems.Clear();
            listView4.SelectedItems.Clear();
            listView5.SelectedItems.Clear();
            listView6.SelectedItems.Clear();
            listView7.SelectedItems.Clear();
            listView8.SelectedItems.Clear();
            listView9.SelectedItems.Clear();
            listView10.SelectedItems.Clear();
            listView11.SelectedItems.Clear();
            if (panel5.Visible == true)
            {
                panel5.Visible = false;
            }
            else if (panel6.Visible == true)
            {
                panel6.Visible = false;
            }
            else if (panel7.Visible == true)
            {
                panel7.Visible = false;
            }
            else if (panel8.Visible == true)
            {
                panel8.Visible = false;
            }
            else if (panel9.Visible == true)
            {
                panel9.Visible = false;
            }
            else if (panel10.Visible == true)
            {
                panel10.Visible = false;
            }
            else if (panel11.Visible == true)
            {
                panel11.Visible = false;
            }
            else if (panel12.Visible == true)
            {
                panel12.Visible = false;
            }


        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                API.写配置项(功能配置路径, "Set", "F12", "1");

            }
            else
            {
                API.写配置项(功能配置路径, "Set", "F12", "0");
            }
        }
        private void 初始化退出()
        {
            string zhong = null;
            if (API.读配置项(功能配置路径, "Set", "large") == "1")
            {
                zhong = "large";
            }
            if (API.读配置项(功能配置路径, "Set", "in") == "1")
            {
                zhong = "in";
            }
            if (API.读配置项(功能配置路径, "Set", "Small") == "1")
            {
                zhong = "Small";
            }
            //File.Delete(Environment.CurrentDirectory + "\\dict\\RMbinconfig.ini");
            API.文件夹_清空(API.默认我的文档() + "\\dict");
            程序_延时(10);
            if (语言选择框.SelectedIndex == 0)
            {
                API.信息框("初始化成功,重启软件后生效", "信息:", 5000);
            }
            else if (语言选择框.SelectedIndex == 1)
            {
                API.信息框("The initialization is successful and takes effect after restarting the software", "Tips:", 5000);
            }
            else API.信息框("The initialization is successful and takes effect after restarting the software", "Tips:", 5000);
            if (File.Exists(API.默认我的文档() + "\\dict\\RMbinconfig.ini") == false)
            {
                File.WriteAllText(API.默认我的文档() + "\\dict\\RMbinconfig.ini", null, Encoding.UTF8);
            }
            程序_延时(10);
            try
            {
                API.写配置项(功能配置路径, "Set", zhong, "1");
            }
            catch { }
            结束AD64();
            关闭程序();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            初始化退出();
        }
        private void 透明度_Scroll(object sender, EventArgs e)
        {
            this.Opacity = (float)透明度.Value / 100;
            if (语言选择框.SelectedIndex == 0)
            {
                label3.Text = "透明:" + 透明度.Value.ToString();
            }
            else if (语言选择框.SelectedIndex == 1)
            {
                label3.Text = "TRN:" + 透明度.Value.ToString();
            }
            else label3.Text = "透明:" + 透明度.Value.ToString();
        }
        private void 常规_离开(object sender, EventArgs e)
        {
            关闭.BackgroundImage = Resources.X常规;
        }
        private void 常规_点燃(object sender, EventArgs e)
        {
            关闭.BackgroundImage = Resources.X点燃;
        }
        private void 最小化_点燃(object sender, EventArgs e)
        {
            最小化.BackgroundImage = Resources.最小化点燃;
        }
        private void 最小化_MouseLeave(object sender, EventArgs e)
        {
            最小化.BackgroundImage = Resources.最小化常规;
        }
        private void 最小化托盘_MouseEnter(object sender, EventArgs e)
        {
            最小化托盘.BackgroundImage = Resources.最小化托盘点燃;
        }
        private void 最小化托盘_MouseLeave(object sender, EventArgs e)
        {
            最小化托盘.BackgroundImage = Resources.最小化托盘常规;
        }
        private void 最小化_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void 关闭_Click_1(object sender, EventArgs e)
        {
            关闭程序();
        }
        private void 结束AD64()
        {
            if (烤GPU.Checked == true)
            {
                API.进程_结束1("FurMark");
            }
            IntPtr HWD=  API.窗口_标题取句柄("System Stability Test - AIDA64");
            //Console.WriteLine("句柄"+HWD);
            //Console.WriteLine(API.窗口_是否存在(HWD));
            if (烤CPU.Checked==true)
            {
                if (API.窗口_是否存在(HWD) != 0)
                {
                    API.进程_结束1("aida64");
                    API.运行(Environment.CurrentDirectory + "\\bin", "aida_bench64.bat");
                }
               
            }           
        }
        private void 关闭程序()
        {
           结束AD64();
            if (API.进程_是否存在("RMtesting") == true)
            {
                API.进程_结束1("RMtesting");
            }
            if (API.进程_是否存在("RMwindow") == true)
            {
                API.进程_结束1("RMwindow");
            }
            if (notifyIcon1.Visible == true)
            {
                notifyIcon1.Visible = false;
            }
            Environment.Exit(0);
        }
        private void 显示托盘(object sender, MouseEventArgs e)
        {
            显示();
        }
        private void 最小化托盘_Click(object sender, EventArgs e)
        {
            显示();
        }
        private void 显示()
        {
            if (this.Visible == true)
            {
                this.Visible = false;
                if (notifyIcon1.Visible == false)
                {
                    notifyIcon1.Visible = true;//托盘按钮是否可见
                    notifyIcon1.Text = this.Text;
                }
            }
            else
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                //notifyIcon1.Visible = false;//托盘按钮是否可见
            }
        }
        private void 路径错误()
        {
            API.信息框("路径错误,请重启后再试", "信息:", 5000);
            API.文件夹_清空(API.默认我的文档() + "\\dict");
            结束AD64();
            关闭程序();
        }

        private void 选择夹1初始化()
        {
            lines.Clear();
            listView1.Clear();
            Size Bigimagsize;
            if (大图标ToolStripMenuItem.Checked == true)
            {
                Bigimagsize = datubiao;
            }
            else if (中图标ToolStripMenuItem.Checked == true)
            {
                Bigimagsize = zhongtubiao;
            }
            else Bigimagsize = xiaotubiao;
            imageList1.ImageSize = Bigimagsize;
            string line = string.Empty;
            using (StreamReader reader = new StreamReader(API.默认我的文档() + "\\dict\\config1.ini", Encoding.UTF8))
            {
                line = reader.ReadLine();
                while (line != "" && line != null)
                {
                    lines.Add(line);
                    line = reader.ReadLine();
                }
            }

            foreach (string fileText in lines)
            {
                Icon icon = null;
                if (File.Exists(fileText))//是文件
                {
                    icon = Icon.ExtractAssociatedIcon(fileText);//路径取ICO
                }
                else if (Directory.Exists(fileText))// 是文件夹
                {

                    SHFILEINFO shfi = new SHFILEINFO();
                    //DirectoryInfo dir = new DirectoryInfo(fileText);
                    SHGetFileInfo(fileText, (uint)0x80, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                    icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                    DestroyIcon(shfi.hIcon);
                }

                if (icon == null)
                {
                    listView1.Items.Clear();//清空
                    File.WriteAllText(API.默认我的文档() + "\\dict\\config1.ini", string.Empty);
                }

                ListViewItem iw = new ListViewItem();   //实例化ListViewItem
                try
                {
                    imageList1.Images.Add(icon.ToBitmap());  //图片存入imagelist   
                }
                catch
                {
                    listView1.Items.Clear();//清空
                    File.WriteAllText(API.默认我的文档() + "\\dict\\config1.ini", string.Empty);
                    API.处理器写入路径();
                    路径错误();
                    //Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                }
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileText);// 没有扩展名的文件名 “Default”
                iw.Text = fileNameWithoutExtension;//设置图片文本路径
                iw.Name = fileText;//设置图片文本路径
                listView1.LargeImageList = imageList1;//绑定图片

                for (int i = 0; i < imageList1.Images.Count; i++)  //遍历程序图标
                {
                    iw.ImageIndex = i;
                }
                listView1.Items.Add(iw);//添加图片显示

            }
        }
        private void 选择夹2初始化()
        {
            lines2.Clear();
            listView2.Clear();
            Size Bigimagsize = xiaotubiao;
            if (大图标ToolStripMenuItem.Checked == true)
            {
                Bigimagsize = datubiao;
            }
            else if (中图标ToolStripMenuItem.Checked == true)
            {
                Bigimagsize = zhongtubiao;
            }
            else Bigimagsize = xiaotubiao;
            imageList2.ImageSize = Bigimagsize;
            if (File.Exists(API.默认我的文档() + "\\dict\\config2.ini") == false)//是文件
            {
                string path = API.默认我的文档() + "\\dict\\config2.ini";
                File.WriteAllText(path, null);
                // File.WriteAllText(path, null, Encoding.UTF8);
            }
            else
            {
                string line = string.Empty;

                using (StreamReader reader = new StreamReader(API.默认我的文档() + "\\dict\\config2.ini", Encoding.UTF8))
                {
                    line = reader.ReadLine();
                    while (line != "" && line != null)
                    {
                        lines2.Add(line);
                        // MessageBox.Show(line);
                        line = reader.ReadLine();
                    }
                }
                foreach (string fileText in lines2)
                {
                    Icon icon = null;
                    if (File.Exists(fileText))//是文件
                    {
                        icon = Icon.ExtractAssociatedIcon(fileText);//路径取ICO
                        //Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileText);//路径取ICO                        
                    }
                    else if (Directory.Exists(fileText))// 是文件夹
                    {
                        SHFILEINFO shfi = new SHFILEINFO();
                        DirectoryInfo dir = new DirectoryInfo(fileText);
                        SHGetFileInfo(fileText, (uint)0x80, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                        icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                        DestroyIcon(shfi.hIcon);
                    }
                    if (icon == null)
                    {
                        listView2.Items.Clear();//清空
                        File.WriteAllText(API.默认我的文档() + "\\dict\\config2.ini", string.Empty);
                    }
                    ListViewItem iw = new ListViewItem();//实例化ListViewItem
                    try
                    {
                        imageList2.Images.Add(icon.ToBitmap());//图片存入imagelist  
                    }
                    catch
                    {
                        //API.写配置项(功能配置路径, "Set", "tabPage2", "0");
                        listView2.Items.Clear();//清空
                        File.WriteAllText(API.默认我的文档() + "\\dict\\config2.ini", string.Empty);
                        API.主板工具写入路径();
                        路径错误();
                        //Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                        //// System.Diagnostics.////Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    }
                    string filename = System.IO.Path.GetFileName(fileText);//文件名  “Default.aspx”
                    string extension = System.IO.Path.GetExtension(fileText);//扩展名 “.aspx”
                    string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fileText);// 没有扩展名的文件名 “Default”
                    iw.Text = fileNameWithoutExtension;//设置图片文本路径
                    iw.Name = fileText;//设置图片文本路径
                    listView2.LargeImageList = imageList2;//绑定图片

                    for (int i = 0; i < imageList2.Images.Count; i++)  //遍历程序图标
                    {
                        iw.ImageIndex = i;
                    }
                    listView2.Items.Add(iw);//添加图片显示
                }
            }
        }
        private void 选择夹3初始化()
        {
            lines3.Clear();
            listView3.Clear();
            Size Bigimagsize = xiaotubiao;
            if (大图标ToolStripMenuItem.Checked == true)
            {
                Bigimagsize = datubiao;
            }
            else if (中图标ToolStripMenuItem.Checked == true)
            {
                Bigimagsize = zhongtubiao;
            }
            else Bigimagsize = xiaotubiao;
            imageList3.ImageSize = Bigimagsize;

            if (File.Exists(API.默认我的文档() + "\\dict\\config3.ini") == false)//是文件
            {
                string path = API.默认我的文档() + "\\dict\\config3.ini";
                File.WriteAllText(path, null);
                // File.WriteAllText(path, null, Encoding.UTF8);
            }
            else
            {
                string line = string.Empty;

                using (StreamReader reader = new StreamReader(API.默认我的文档() + "\\dict\\config3.ini", Encoding.UTF8))
                {
                    line = reader.ReadLine();
                    while (line != "" && line != null)
                    {
                        lines3.Add(line);
                        // MessageBox.Show(line);
                        line = reader.ReadLine();
                    }
                }

                foreach (string fileText in lines3)
                {
                    Icon icon = null;

                    if (File.Exists(fileText))//是文件
                    {
                        icon = Icon.ExtractAssociatedIcon(fileText);//路径取ICO
                                                                    //Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileText);//路径取ICO                        
                    }
                    else if (Directory.Exists(fileText))// 是文件夹
                    {

                        SHFILEINFO shfi = new SHFILEINFO();
                        DirectoryInfo dir = new DirectoryInfo(fileText);
                        SHGetFileInfo(fileText, (uint)0x80, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                        icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                        DestroyIcon(shfi.hIcon);
                    }


                    if (icon == null)
                    {
                        listView3.Items.Clear();//清空
                        File.WriteAllText(API.默认我的文档() + "\\dict\\config3.ini", string.Empty);
                    }
                    ListViewItem iw = new ListViewItem();//实例化ListViewItem
                    try
                    {
                        imageList3.Images.Add(icon.ToBitmap());//图片存入imagelist  

                    }
                    catch
                    {
                        //API.写配置项(功能配置路径, "Set", "tabPage3", "0");
                        listView3.Items.Clear();//清空
                        File.WriteAllText(API.默认我的文档() + "\\dict\\config3.ini", string.Empty);
                        API.内存工具写入路径();
                        路径错误();
                        // System.Diagnostics.////Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                        //Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    }


                    string filename = System.IO.Path.GetFileName(fileText);//文件名  “Default.aspx”
                    string extension = System.IO.Path.GetExtension(fileText);//扩展名 “.aspx”
                    string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fileText);// 没有扩展名的文件名 “Default”
                    iw.Text = fileNameWithoutExtension;//设置图片文本路径
                    iw.Name = fileText;//设置图片文本路径
                    listView3.LargeImageList = imageList3;//绑定图片

                    for (int i = 0; i < imageList3.Images.Count; i++)  //遍历程序图标
                    {
                        iw.ImageIndex = i;
                    }
                    listView3.Items.Add(iw);//添加图片显示
                }
            }
        }
        private void 选择夹4初始化()
        {
            lines4.Clear();
            listView4.Clear();
            Size Bigimagsize = xiaotubiao;
            if (大图标ToolStripMenuItem.Checked == true)
            {
                Bigimagsize = datubiao;
            }
            else if (中图标ToolStripMenuItem.Checked == true)
            {
                Bigimagsize = zhongtubiao;
            }
            else Bigimagsize = xiaotubiao;
            imageList4.ImageSize = Bigimagsize;

            if (File.Exists(API.默认我的文档() + "\\dict\\config4.ini") == false)//是文件
            {
                string path = API.默认我的文档() + "\\dict\\config4.ini";
                File.WriteAllText(path, null);
                // File.WriteAllText(path, null, Encoding.UTF8);
            }
            else
            {
                string line = string.Empty;

                using (StreamReader reader = new StreamReader(API.默认我的文档() + "\\dict\\config4.ini", Encoding.UTF8))
                {
                    line = reader.ReadLine();
                    while (line != "" && line != null)
                    {
                        lines4.Add(line);
                        // MessageBox.Show(line);
                        line = reader.ReadLine();
                    }
                }

                foreach (string fileText in lines4)
                {
                    Icon icon = null;

                    if (File.Exists(fileText))//是文件
                    {
                        icon = Icon.ExtractAssociatedIcon(fileText);//路径取ICO
                                                                    //Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileText);//路径取ICO                        
                    }
                    else if (Directory.Exists(fileText))// 是文件夹
                    {

                        SHFILEINFO shfi = new SHFILEINFO();
                        DirectoryInfo dir = new DirectoryInfo(fileText);
                        SHGetFileInfo(fileText, (uint)0x80, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                        icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                        DestroyIcon(shfi.hIcon);
                    }


                    if (icon == null)
                    {
                        listView4.Items.Clear();//清空
                        File.WriteAllText(API.默认我的文档() + "\\dict\\config4.ini", string.Empty);
                    }
                    ListViewItem iw = new ListViewItem();//实例化ListViewItem
                    try
                    {
                        imageList4.Images.Add(icon.ToBitmap());//图片存入imagelist  

                    }
                    catch
                    {
                        //API.写配置项(功能配置路径, "Set", "tabPage4", "0");
                        listView4.Items.Clear();//清空
                        File.WriteAllText(API.默认我的文档() + "\\dict\\config4.ini", string.Empty);
                        API.显卡工具写入路径();
                        路径错误();
                        //Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);

                    }


                    string filename = Path.GetFileName(fileText);//文件名  “Default.aspx”
                    string extension = Path.GetExtension(fileText);//扩展名 “.aspx”
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileText);// 没有扩展名的文件名 “Default”
                    iw.Text = fileNameWithoutExtension;//设置图片文本路径
                    iw.Name = fileText;//设置图片文本路径
                    listView4.LargeImageList = imageList4;//绑定图片

                    for (int i = 0; i < imageList4.Images.Count; i++)  //遍历程序图标
                    {
                        iw.ImageIndex = i;
                    }
                    listView4.Items.Add(iw);//添加图片显示
                }
            }
        }
        private void 选择夹5初始化()
        {
            lines5.Clear();
            listView5.Clear();
            Size Bigimagsize = xiaotubiao;
            if (大图标ToolStripMenuItem.Checked == true)
            {
                Bigimagsize = datubiao;
            }
            else if (中图标ToolStripMenuItem.Checked == true)
            {
                Bigimagsize = zhongtubiao;
            }
            else Bigimagsize = xiaotubiao;
            imageList5.ImageSize = Bigimagsize;

            if (File.Exists(API.默认我的文档() + "\\dict\\config5.ini") == false)//是文件
            {
                string path = API.默认我的文档() + "\\dict\\config5.ini";
                File.WriteAllText(path, null);
                // File.WriteAllText(path, null, Encoding.UTF8);

            }
            else
            {
                string line = string.Empty;

                using (StreamReader reader = new StreamReader(API.默认我的文档() + "\\dict\\config5.ini", Encoding.UTF8))
                {
                    line = reader.ReadLine();
                    while (line != "" && line != null)
                    {
                        lines5.Add(line);
                        // MessageBox.Show(line);
                        line = reader.ReadLine();
                    }
                }

                foreach (string fileText in lines5)
                {
                    Icon icon = null;

                    if (File.Exists(fileText))//是文件
                    {
                        icon = Icon.ExtractAssociatedIcon(fileText);//路径取ICO
                                                                    //Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileText);//路径取ICO                        
                    }
                    else if (Directory.Exists(fileText))// 是文件夹
                    {

                        SHFILEINFO shfi = new SHFILEINFO();
                        DirectoryInfo dir = new DirectoryInfo(fileText);
                        SHGetFileInfo(fileText, (uint)0x80, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                        icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                        DestroyIcon(shfi.hIcon);
                    }


                    if (icon == null)
                    {
                        listView5.Items.Clear();//清空
                        File.WriteAllText(API.默认我的文档() + "\\dict\\config5.ini", string.Empty);
                    }
                    ListViewItem iw = new ListViewItem();//实例化ListViewItem
                    try
                    {
                        imageList5.Images.Add(icon.ToBitmap());//图片存入imagelist  

                    }
                    catch
                    {
                        //API.写配置项(功能配置路径, "Set", "tabPage5", "0");
                        listView5.Items.Clear();//清空
                        File.WriteAllText(API.默认我的文档() + "\\dict\\config5.ini", string.Empty);
                        API.硬盘工具写入路径();
                        路径错误();
                        //Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);

                    }


                    string filename = Path.GetFileName(fileText);//文件名  “Default.aspx”
                    string extension = Path.GetExtension(fileText);//扩展名 “.aspx”
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileText);// 没有扩展名的文件名 “Default”
                    iw.Text = fileNameWithoutExtension;//设置图片文本路径
                    iw.Name = fileText;//设置图片文本路径
                    listView5.LargeImageList = imageList5;//绑定图片

                    for (int i = 0; i < imageList5.Images.Count; i++)  //遍历程序图标
                    {
                        iw.ImageIndex = i;
                    }
                    listView5.Items.Add(iw);//添加图片显示
                }
            }
        }
        private void 选择夹6初始化()
        {
            lines6.Clear();
            listView6.Clear();
            Size Bigimagsize = xiaotubiao;
            if (大图标ToolStripMenuItem.Checked == true)
            {
                Bigimagsize = datubiao;
            }
            else if (中图标ToolStripMenuItem.Checked == true)
            {
                Bigimagsize = zhongtubiao;
            }
            else Bigimagsize = xiaotubiao;
            imageList6.ImageSize = Bigimagsize;
            if (File.Exists(API.默认我的文档() + "\\dict\\config6.ini") == false)//是文件
            {
                string path = API.默认我的文档() + "\\dict\\config6.ini";
                File.WriteAllText(path, null);
                // File.WriteAllText(path, null, Encoding.UTF8);
            }
            else
            {
                string line = string.Empty;

                using (StreamReader reader = new StreamReader(API.默认我的文档() + "\\dict\\config6.ini", Encoding.UTF8))
                {
                    line = reader.ReadLine();
                    while (line != "" && line != null)
                    {
                        lines6.Add(line);
                        // MessageBox.Show(line);
                        line = reader.ReadLine();
                    }
                }

                foreach (string fileText in lines6)
                {
                    Icon icon = null;

                    if (File.Exists(fileText))//是文件
                    {
                        icon = Icon.ExtractAssociatedIcon(fileText);//路径取ICO
                                                                    //Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileText);//路径取ICO                        
                    }
                    else if (Directory.Exists(fileText))// 是文件夹
                    {

                        SHFILEINFO shfi = new SHFILEINFO();
                        DirectoryInfo dir = new DirectoryInfo(fileText);
                        SHGetFileInfo(fileText, (uint)0x80, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                        icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                        DestroyIcon(shfi.hIcon);
                    }


                    if (icon == null)
                    {
                        listView6.Items.Clear();//清空
                        File.WriteAllText(API.默认我的文档() + "\\dict\\config6.ini", string.Empty);
                    }
                    ListViewItem iw = new ListViewItem();//实例化ListViewItem
                    try
                    {
                        imageList6.Images.Add(icon.ToBitmap());//图片存入imagelist  

                    }
                    catch
                    {
                        // API.写配置项(功能配置路径, "Set", "tabPage6", "0");
                        listView6.Items.Clear();//清空
                        File.WriteAllText(API.默认我的文档() + "\\dict\\config6.ini", string.Empty);
                        API.显示器工具写入路径();
                        路径错误();
                        //Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);

                    }


                    string filename = Path.GetFileName(fileText);//文件名  “Default.aspx”
                    string extension = Path.GetExtension(fileText);//扩展名 “.aspx”
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileText);// 没有扩展名的文件名 “Default”
                    iw.Text = fileNameWithoutExtension;//设置图片文本路径
                    iw.Name = fileText;//设置图片文本路径
                    listView6.LargeImageList = imageList6;//绑定图片

                    for (int i = 0; i < imageList6.Images.Count; i++)  //遍历程序图标
                    {
                        iw.ImageIndex = i;
                    }
                    listView6.Items.Add(iw);//添加图片显示
                }
            }
        }
        private void 选择夹7初始化()
        {
            lines7.Clear();
            listView7.Clear();
            Size Bigimagsize = xiaotubiao;
            if (大图标ToolStripMenuItem.Checked == true)
            {
                Bigimagsize = datubiao;
            }
            else if (中图标ToolStripMenuItem.Checked == true)
            {
                Bigimagsize = zhongtubiao;
            }
            else Bigimagsize = xiaotubiao;
            imageList7.ImageSize = Bigimagsize;
            if (File.Exists(API.默认我的文档() + "\\dict\\config7.ini") == false)//是文件
            {
                string path = API.默认我的文档() + "\\dict\\config7.ini";
                File.WriteAllText(path, null);
                // File.WriteAllText(path, null, Encoding.UTF8);
            }
            else
            {
                string line = string.Empty;

                using (StreamReader reader = new StreamReader(API.默认我的文档() + "\\dict\\config7.ini", Encoding.UTF8))
                {
                    line = reader.ReadLine();
                    while (line != "" && line != null)
                    {
                        lines7.Add(line);
                        line = reader.ReadLine();
                    }
                }
                foreach (string fileText in lines7)
                {
                    Icon icon = null;
                    if (File.Exists(fileText))//是文件
                    {
                        icon = Icon.ExtractAssociatedIcon(fileText);//路径取ICO                                                                    //Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileText);//路径取ICO                        
                    }
                    else if (Directory.Exists(fileText))// 是文件夹
                    {
                        SHFILEINFO shfi = new SHFILEINFO();
                        DirectoryInfo dir = new DirectoryInfo(fileText);
                        SHGetFileInfo(fileText, (uint)0x80, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                        icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                        DestroyIcon(shfi.hIcon);
                    }
                    if (icon == null)
                    {
                        listView7.Items.Clear();//清空
                        File.WriteAllText(API.默认我的文档() + "\\dict\\config7.ini", string.Empty);
                    }
                    ListViewItem iw = new ListViewItem();//实例化ListViewItem
                    try
                    {
                        imageList7.Images.Add(icon.ToBitmap());//图片存入imagelist  
                    }
                    catch
                    {
                        // API.写配置项(功能配置路径, "Set", "tabPage7", "0");
                        listView7.Items.Clear();//清空
                        File.WriteAllText(API.默认我的文档() + "\\dict\\config7.ini", string.Empty);
                        API.综合检测写入路径();
                        路径错误();
                        //Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    }
                    string filename = Path.GetFileName(fileText);//文件名  “Default.aspx”
                    string extension = Path.GetExtension(fileText);//扩展名 “.aspx”
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileText);// 没有扩展名的文件名 “Default”
                    iw.Text = fileNameWithoutExtension;//设置图片文本路径
                    iw.Name = fileText;//设置图片文本路径
                    listView7.LargeImageList = imageList7;//绑定图片
                    for (int i = 0; i < imageList7.Images.Count; i++)  //遍历程序图标
                    {
                        iw.ImageIndex = i;
                    }
                    listView7.Items.Add(iw);//添加图片显示
                }
            }
        }
        private void 选择夹8初始化()
        {
            lines8.Clear();
            listView8.Clear();
            Size Bigimagsize = xiaotubiao;
            if (大图标ToolStripMenuItem.Checked == true)
            {
                Bigimagsize = datubiao;
            }
            else if (中图标ToolStripMenuItem.Checked == true)
            {
                Bigimagsize = zhongtubiao;
            }
            else Bigimagsize = xiaotubiao;
            imageList8.ImageSize = Bigimagsize;
            if (File.Exists(API.默认我的文档() + "\\dict\\config8.ini") == false)//是文件
            {
                string path = API.默认我的文档() + "\\dict\\config8.ini";
                File.WriteAllText(path, null);
                // File.WriteAllText(path, null, Encoding.UTF8);
            }
            else
            {
                string line = string.Empty;

                using (StreamReader reader = new StreamReader(API.默认我的文档() + "\\dict\\config8.ini", Encoding.UTF8))
                {
                    line = reader.ReadLine();
                    while (line != "" && line != null)
                    {
                        lines8.Add(line);
                        line = reader.ReadLine();
                    }
                }
                foreach (string fileText in lines8)
                {
                    Icon icon = null;
                    if (File.Exists(fileText))//是文件
                    {
                        icon = Icon.ExtractAssociatedIcon(fileText);//路径取ICO                                                                    //Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileText);//路径取ICO                        
                    }
                    else if (Directory.Exists(fileText))// 是文件夹
                    {
                        SHFILEINFO shfi = new SHFILEINFO();
                        DirectoryInfo dir = new DirectoryInfo(fileText);
                        SHGetFileInfo(fileText, (uint)0x80, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                        icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                        DestroyIcon(shfi.hIcon);
                    }
                    if (icon == null)
                    {
                        listView8.Items.Clear();//清空
                        File.WriteAllText(API.默认我的文档() + "\\dict\\config8.ini", string.Empty);
                    }
                    ListViewItem iw = new ListViewItem();//实例化ListViewItem
                    try
                    {
                        imageList8.Images.Add(icon.ToBitmap());//图片存入imagelist  
                    }
                    catch
                    {
                        //API.写配置项(功能配置路径, "Set", "tabPage8", "0");
                        listView8.Items.Clear();//清空

                        File.WriteAllText(API.默认我的文档() + "\\dict\\config8.ini", string.Empty);

                        API.外设工具写入路径();
                        路径错误();
                        //Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    }
                    string filename = Path.GetFileName(fileText);//文件名  “Default.aspx”
                    string extension = Path.GetExtension(fileText);//扩展名 “.aspx”
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileText);// 没有扩展名的文件名 “Default”
                    iw.Text = fileNameWithoutExtension;//设置图片文本路径
                    iw.Name = fileText;//设置图片文本路径
                    listView8.LargeImageList = imageList8;//绑定图片
                    for (int i = 0; i < imageList8.Images.Count; i++)  //遍历程序图标
                    {
                        iw.ImageIndex = i;
                    }
                    listView8.Items.Add(iw);//添加图片显示
                }
            }
        }
        private void 选择夹9初始化()
        {
            lines9.Clear();
            listView9.Clear();
            Size Bigimagsize = xiaotubiao;
            if (大图标ToolStripMenuItem.Checked == true)
            {
                Bigimagsize = datubiao;
            }
            else if (中图标ToolStripMenuItem.Checked == true)
            {
                Bigimagsize = zhongtubiao;
            }
            else Bigimagsize = xiaotubiao;
            imageList9.ImageSize = Bigimagsize;
            if (File.Exists(API.默认我的文档() + "\\dict\\config9.ini") == false)//是文件
            {
                string path = API.默认我的文档() + "\\dict\\config9.ini";
                File.WriteAllText(path, null);
                // File.WriteAllText(path, null, Encoding.UTF8);
            }
            else
            {
                string line = string.Empty;

                using (StreamReader reader = new StreamReader(API.默认我的文档() + "\\dict\\config9.ini", Encoding.UTF8))
                {
                    line = reader.ReadLine();
                    while (line != "" && line != null)
                    {
                        lines9.Add(line);
                        line = reader.ReadLine();
                    }
                }
                foreach (string fileText in lines9)
                {
                    Icon icon = null;
                    if (File.Exists(fileText))//是文件
                    {
                        icon = Icon.ExtractAssociatedIcon(fileText);//路径取ICO                                                                    //Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileText);//路径取ICO                        
                    }
                    else if (Directory.Exists(fileText))// 是文件夹
                    {
                        SHFILEINFO shfi = new SHFILEINFO();
                        DirectoryInfo dir = new DirectoryInfo(fileText);
                        SHGetFileInfo(fileText, (uint)0x80, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                        icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                        DestroyIcon(shfi.hIcon);
                    }
                    if (icon == null)
                    {
                        listView9.Items.Clear();//清空
                        File.WriteAllText(API.默认我的文档() + "\\dict\\config9.ini", string.Empty);
                    }
                    ListViewItem iw = new ListViewItem();//实例化ListViewItem
                    try
                    {
                        imageList9.Images.Add(icon.ToBitmap());//图片存入imagelist  
                    }
                    catch
                    {
                        // API.写配置项(功能配置路径, "Set", "tabPage9", "0");
                        listView9.Items.Clear();//清空
                        File.WriteAllText(API.默认我的文档() + "\\dict\\config9.ini", string.Empty);
                        API.烤鸡工具写入路径();
                        路径错误();
                        //Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    }
                    string filename = Path.GetFileName(fileText);//文件名  “Default.aspx”
                    string extension = Path.GetExtension(fileText);//扩展名 “.aspx”
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileText);// 没有扩展名的文件名 “Default”
                    iw.Text = fileNameWithoutExtension;//设置图片文本路径
                    iw.Name = fileText;//设置图片文本路径
                    listView9.LargeImageList = imageList9;//绑定图片
                    for (int i = 0; i < imageList9.Images.Count; i++)  //遍历程序图标
                    {
                        iw.ImageIndex = i;
                    }
                    listView9.Items.Add(iw);//添加图片显示
                }
            }
        }
        private void 选择夹10初始化()
        {
            lines10.Clear();
            listView10.Clear();
            Size Bigimagsize = xiaotubiao;
            if (大图标ToolStripMenuItem.Checked == true)
            {
                Bigimagsize = datubiao;
            }
            else if (中图标ToolStripMenuItem.Checked == true)
            {
                Bigimagsize = zhongtubiao;
            }
            else Bigimagsize = xiaotubiao;
            imageList10.ImageSize = Bigimagsize;
            if (File.Exists(API.默认我的文档() + "\\dict\\config10.ini") == false)//是文件
            {
                string path = API.默认我的文档() + "\\dict\\config10.ini";
                File.WriteAllText(path, null);
                // File.WriteAllText(path, null, Encoding.UTF8);
            }
            else
            {
                string line = string.Empty;

                using (StreamReader reader = new StreamReader(API.默认我的文档() + "\\dict\\config10.ini", Encoding.UTF8))
                {
                    line = reader.ReadLine();
                    while (line != "" && line != null)
                    {
                        lines10.Add(line);
                        line = reader.ReadLine();
                    }
                }
                foreach (string fileText in lines10)
                {
                    Icon icon = null;
                    if (File.Exists(fileText))//是文件
                    {
                        icon = Icon.ExtractAssociatedIcon(fileText);//路径取ICO                                                                    //Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileText);//路径取ICO                        
                    }
                    else if (Directory.Exists(fileText))// 是文件夹
                    {
                        SHFILEINFO shfi = new SHFILEINFO();
                        DirectoryInfo dir = new DirectoryInfo(fileText);
                        SHGetFileInfo(fileText, 0x80, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                        icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                        DestroyIcon(shfi.hIcon);
                    }
                    if (icon == null)
                    {
                        listView10.Items.Clear();//清空
                        File.WriteAllText(API.默认我的文档() + "\\dict\\config10.ini", string.Empty);
                    }
                    ListViewItem iw = new ListViewItem();//实例化ListViewItem
                    try
                    {
                        imageList10.Images.Add(icon.ToBitmap());//图片存入imagelist  
                    }
                    catch
                    {
                        // API.写配置项(功能配置路径, "Set", "tabPage10", "0");
                        listView10.Items.Clear();//清空
                        File.WriteAllText(API.默认我的文档() + "\\dict\\config10.ini", string.Empty);
                        API.其他工具写入路径();
                        路径错误();
                        //Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    }
                    string filename = Path.GetFileName(fileText);//文件名  “Default.aspx”
                    string extension = Path.GetExtension(fileText);//扩展名 “.aspx”
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileText);// 没有扩展名的文件名 “Default”
                    iw.Text = fileNameWithoutExtension;//设置图片文本路径
                    iw.Name = fileText;//设置图片文本路径
                    listView10.LargeImageList = imageList10;//绑定图片
                    for (int i = 0; i < imageList10.Images.Count; i++)  //遍历程序图标
                    {
                        iw.ImageIndex = i;
                    }
                    listView10.Items.Add(iw);//添加图片显示
                }
            }
        }
        private void 选择夹11初始化()
        {
            lines11.Clear();
            listView11.Clear();
            Size Bigimagsize = xiaotubiao;
            if (大图标ToolStripMenuItem.Checked == true)
            {
                Bigimagsize = datubiao;
            }
            else if (中图标ToolStripMenuItem.Checked == true)
            {
                Bigimagsize = zhongtubiao;
            }
            else Bigimagsize = xiaotubiao;
            imageList11.ImageSize = Bigimagsize;
            if (File.Exists(API.默认我的文档() + "\\dict\\config11.ini") == false)//是文件
            {
                string path = API.默认我的文档() + "\\dict\\config11.ini";
                File.WriteAllText(path, null);
                // File.WriteAllText(path, null, Encoding.UTF8);
            }
            else
            {
                string line = string.Empty;
                using (StreamReader reader = new StreamReader(API.默认我的文档() + "\\dict\\config11.ini", Encoding.UTF8))
                {
                    line = reader.ReadLine();
                    while (line != "" && line != null)
                    {
                        lines11.Add(line);
                        line = reader.ReadLine();
                    }
                }
                foreach (string fileText in lines11)
                {
                    Icon icon = null;
                    if (File.Exists(fileText))//是文件
                    {
                        icon = Icon.ExtractAssociatedIcon(fileText);//路径取ICO                                                                    //Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileText);//路径取ICO                        
                    }
                    else if (Directory.Exists(fileText))// 是文件夹
                    {
                        SHFILEINFO shfi = new SHFILEINFO();
                        DirectoryInfo dir = new DirectoryInfo(fileText);
                        SHGetFileInfo(fileText, 0x80, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                        icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                        DestroyIcon(shfi.hIcon);
                    }
                    if (icon == null)
                    {
                        listView11.Items.Clear();//清空
                        File.WriteAllText(API.默认我的文档() + "\\dict\\config11.ini", string.Empty);
                    }
                    ListViewItem iw = new ListViewItem();//实例化ListViewItem
                    try
                    {
                        imageList11.Images.Add(icon.ToBitmap());//图片存入imagelist  
                    }
                    catch
                    {
                        //API.写配置项(功能配置路径, "Set", "tabPage11", "0");
                        listView11.Items.Clear();//清空
                        File.WriteAllText(API.默认我的文档() + "\\dict\\config11.ini", string.Empty);
                        API.自定工具写入路径();
                        路径错误();
                        //Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    }
                    string filename = Path.GetFileName(fileText);//文件名  “Default.aspx”
                    string extension = Path.GetExtension(fileText);//扩展名 “.aspx”
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileText);// 没有扩展名的文件名 “Default”
                    iw.Text = fileNameWithoutExtension;//设置图片文本路径
                    iw.Name = fileText;//设置图片文本路径
                    listView11.LargeImageList = imageList11;//绑定图片
                    for (int i = 0; i < imageList11.Images.Count; i++)  //遍历程序图标
                    {
                        iw.ImageIndex = i;
                    }
                    listView11.Items.Add(iw);//添加图片显示
                }
            }
        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {//双击打开文件
            string file = listView1.Items[listView1.SelectedItems[0].Index].Name;
            if (File.Exists(file) == true)
            {
                Process.Start(file); //打开文件夹 
            }
            else
            {
                int Index;
                if (this.listView1.SelectedItems.Count > 0)//判断listview有被选中项
                {
                    // MessageBox.Show(listView1.Items[Index].ToString());
                    lines.Remove(listView1.Items[listView1.SelectedItems[0].Index].Name);
                    Index = listView1.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                    listView1.Items[Index].Remove();
                    File.WriteAllText(API.默认我的文档() + "\\dict\\config1.ini", string.Empty);//清空
                    foreach (string line in lines)
                    {   //File.WriteAllText(API.默认我的文档()+"\\dict\\config1.ini",lines, Encoding.UTF8);
                        File.WriteAllLines(API.默认我的文档() + "\\dict\\config1.ini", lines, Encoding.UTF8);
                    }
                }
            }
        }
        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }
        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (Directory.Exists("tool") == true)
            {
                string fileText = (e.Data.GetData(DataFormats.FileDrop) as string[])[0];
                Icon icon = null;
                if (File.Exists(fileText))//是文件
                {
                    icon = Icon.ExtractAssociatedIcon(fileText);//路径取ICO
                }
                else if (Directory.Exists(fileText))// 是文件夹
                {
                    SHFILEINFO shfi = new SHFILEINFO();
                    DirectoryInfo dir = new DirectoryInfo(fileText);
                    SHGetFileInfo(fileText, (uint)0x80, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                    icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                    DestroyIcon(shfi.hIcon);
                }
                else
                {
                    MessageBox.Show("当前不支持此类文件");
                    return;
                }
                imageList1.Images.Add(icon.ToBitmap());//图片存入imagelist  
                ListViewItem iw = new ListViewItem();//实例化ListViewItem
                string filename = System.IO.Path.GetFileName(fileText);//文件名  “Default.aspx”
                string extension = System.IO.Path.GetExtension(fileText);//扩展名 “.aspx”
                string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fileText);// 没有扩展名的文件名 “Default”
                iw.Text = fileNameWithoutExtension;//设置图片文本路径
                iw.Name = fileText;//设置图片文本路径
                listView1.LargeImageList = imageList1;//绑定图片
                for (int i = 0; i < imageList1.Images.Count; i++)  //遍历程序图标
                {
                    iw.ImageIndex = i;
                }
                FileStream fs = new FileStream(API.默认我的文档() + "\\dict\\config1.ini", FileMode.Append);//文本加入不覆盖
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);//转码
                sw.WriteLine(fileText);
                sw.Flush();
                sw.Close();
                fs.Close();
                listView1.Items.Add(iw);//添加图片显示
            }
            else
            {
                文件不完整();
            }
        }
        private void 文件不完整()
        {
            API.信息框("软件不完整,请下载完整版本", "信息:", 5000);

        }
        private void listView2_DragDrop(object sender, DragEventArgs e)
        {
            if (Directory.Exists("tool") == true)
            {
                string fileText = (e.Data.GetData(DataFormats.FileDrop) as string[])[0];
                Icon icon = null;

                if (File.Exists(fileText))//是文件
                {
                    icon = Icon.ExtractAssociatedIcon(fileText);//路径取ICO
                                                                //Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileText);//路径取ICO

                }
                else if (Directory.Exists(fileText))// 是文件夹
                {

                    SHFILEINFO shfi = new SHFILEINFO();
                    DirectoryInfo dir = new DirectoryInfo(fileText);
                    SHGetFileInfo(fileText, (uint)0x80, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                    icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                    DestroyIcon(shfi.hIcon);
                }
                else
                {
                    MessageBox.Show("当前不支持此类文件");
                    return;
                }
                imageList2.Images.Add(icon.ToBitmap());//图片存入imagelist  

                ListViewItem iw = new ListViewItem();//实例化ListViewItem
                string filename = System.IO.Path.GetFileName(fileText);//文件名  “Default.aspx”
                string extension = System.IO.Path.GetExtension(fileText);//扩展名 “.aspx”
                string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fileText);// 没有扩展名的文件名 “Default”
                iw.Text = fileNameWithoutExtension;//设置图片文本路径
                iw.Name = fileText;//设置图片文本路径

                listView2.LargeImageList = imageList2;//绑定图片

                for (int i = 0; i < imageList2.Images.Count; i++)  //遍历程序图标
                {
                    iw.ImageIndex = i;

                }

                //SetValue("Set", iw.ImageIndex.ToString(), fileText);       //配置命令存路径                         

                FileStream fs = new FileStream(API.默认我的文档() + "\\dict\\config2.ini", FileMode.Append);//文本加入不覆盖

                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);//转码

                sw.WriteLine(fileText);

                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();

                listView2.Items.Add(iw);//添加图片显示
                                        //  lines.Add(listView2.Items[listView2.SelectedItems[0].Index].Text);
            }
            else 文件不完整();
        }
        private void listView2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;

        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string file = listView2.Items[listView2.SelectedItems[0].Index].Name;
            if (File.Exists(file) == true)
            {
                Process.Start(file); //打开文件夹 
            }
            else
            {
                if (this.listView2.SelectedItems.Count > 0)//判断listview有被选中项
                {
                    lines2.Remove(listView2.Items[listView2.SelectedItems[0].Index].Name);
                    int Index = listView2.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                    listView2.Items[Index].Remove();
                    File.WriteAllText(API.默认我的文档() + "\\dict\\config2.ini", string.Empty);//清空
                    foreach (string line in lines2)
                    {    //File.WriteAllText(API.默认我的文档()+"\\dict\\config2.ini",lines, Encoding.UTF8);
                        File.WriteAllLines(API.默认我的文档() + "\\dict\\config2.ini", lines2, Encoding.UTF8);
                    }
                }
            }

        }

        private void listView3_DragDrop(object sender, DragEventArgs e)
        {
            if (Directory.Exists("tool") == true)
            {
                string fileText = (e.Data.GetData(DataFormats.FileDrop) as string[])[0];
                Icon icon = null;

                if (File.Exists(fileText))//是文件
                {
                    icon = Icon.ExtractAssociatedIcon(fileText);//路径取ICO
                                                                //Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileText);//路径取ICO

                }
                else if (Directory.Exists(fileText))// 是文件夹
                {

                    SHFILEINFO shfi = new SHFILEINFO();
                    DirectoryInfo dir = new DirectoryInfo(fileText);
                    SHGetFileInfo(fileText, (uint)0x80, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                    icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                    DestroyIcon(shfi.hIcon);
                }
                else
                {
                    MessageBox.Show("当前不支持此类文件");
                    return;
                }
                imageList3.Images.Add(icon.ToBitmap());//图片存入imagelist  

                ListViewItem iw = new ListViewItem();//实例化ListViewItem
                string filename = System.IO.Path.GetFileName(fileText);//文件名  “Default.aspx”
                string extension = System.IO.Path.GetExtension(fileText);//扩展名 “.aspx”
                string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fileText);// 没有扩展名的文件名 “Default”
                iw.Text = fileNameWithoutExtension;//设置图片文本路径
                iw.Name = fileText;//设置图片文本路径

                listView3.LargeImageList = imageList3;//绑定图片

                for (int i = 0; i < imageList3.Images.Count; i++)  //遍历程序图标
                {
                    iw.ImageIndex = i;

                }

                //SetValue("Set", iw.ImageIndex.ToString(), fileText);       //配置命令存路径                         

                FileStream fs = new FileStream(API.默认我的文档() + "\\dict\\config3.ini", FileMode.Append);//文本加入不覆盖

                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);//转码

                sw.WriteLine(fileText);

                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();

                listView3.Items.Add(iw);//添加图片显示
            }
            else 文件不完整();
        }
        private void listView3_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listView3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string file = listView3.Items[listView3.SelectedItems[0].Index].Name;
            if (File.Exists(file) == true)
            {
                Process.Start(file); //打开文件夹 
            }
            else
            {
                int Index;
                if (this.listView3.SelectedItems.Count > 0)//判断listview有被选中项
                {
                    lines3.Remove(listView3.Items[listView3.SelectedItems[0].Index].Name);
                    Index = listView3.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                    listView3.Items[Index].Remove();
                    File.WriteAllText(API.默认我的文档() + "\\dict\\config3.ini", string.Empty);//清空
                    foreach (string line in lines3)
                    {
                        File.WriteAllLines(API.默认我的文档() + "\\dict\\config3.ini", lines3, Encoding.UTF8);
                    }
                }
            }
        }

        private void listView4_DragDrop(object sender, DragEventArgs e)
        {
            if (Directory.Exists("tool") == true)
            {
                string fileText = (e.Data.GetData(DataFormats.FileDrop) as string[])[0];
                Icon icon = null;

                if (File.Exists(fileText))//是文件
                {
                    icon = Icon.ExtractAssociatedIcon(fileText);//路径取ICO
                                                                //Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileText);//路径取ICO

                }
                else if (Directory.Exists(fileText))// 是文件夹
                {

                    SHFILEINFO shfi = new SHFILEINFO();
                    DirectoryInfo dir = new DirectoryInfo(fileText);
                    SHGetFileInfo(fileText, (uint)0x80, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                    icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                    DestroyIcon(shfi.hIcon);
                }
                else
                {
                    MessageBox.Show("当前不支持此类文件");
                    return;
                }
                imageList4.Images.Add(icon.ToBitmap());//图片存入imagelist  

                ListViewItem iw = new ListViewItem();//实例化ListViewItem
                string filename = System.IO.Path.GetFileName(fileText);//文件名  “Default.aspx”
                string extension = System.IO.Path.GetExtension(fileText);//扩展名 “.aspx”
                string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fileText);// 没有扩展名的文件名 “Default”
                iw.Text = fileNameWithoutExtension;//设置图片文本路径
                iw.Name = fileText;//设置图片文本路径

                listView4.LargeImageList = imageList4;//绑定图片

                for (int i = 0; i < imageList4.Images.Count; i++)  //遍历程序图标
                {
                    iw.ImageIndex = i;

                }

                //SetValue("Set", iw.ImageIndex.ToString(), fileText);       //配置命令存路径                         

                FileStream fs = new FileStream(API.默认我的文档() + "\\dict\\config4.ini", FileMode.Append);//文本加入不覆盖

                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);//转码

                sw.WriteLine(fileText);

                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();

                listView4.Items.Add(iw);//添加图片显示
            }
            else 文件不完整();
        }

        private void listView4_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listView4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string file = listView4.Items[listView4.SelectedItems[0].Index].Name;
            if (File.Exists(file) == true)
            {
                Process.Start(file); //打开文件夹 
            }
            else
            {
                int Index;
                if (this.listView4.SelectedItems.Count > 0)//判断listview有被选中项
                {
                    lines4.Remove(listView4.Items[listView4.SelectedItems[0].Index].Name);
                    Index = listView4.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                    listView4.Items[Index].Remove();
                    File.WriteAllText(API.默认我的文档() + "\\dict\\config4.ini", string.Empty);//清空
                    foreach (string line in lines4)
                    {
                        File.WriteAllLines(API.默认我的文档() + "\\dict\\config4.ini", lines4, Encoding.UTF8);
                    }
                }
            }

        }

        private void listView5_DragDrop(object sender, DragEventArgs e)
        {
            if (Directory.Exists("tool") == true)
            {
                string fileText = (e.Data.GetData(DataFormats.FileDrop) as string[])[0];
                Icon icon = null;

                if (File.Exists(fileText))//是文件
                {
                    icon = Icon.ExtractAssociatedIcon(fileText);//路径取ICO


                }
                else if (Directory.Exists(fileText))// 是文件夹
                {

                    SHFILEINFO shfi = new SHFILEINFO();
                    DirectoryInfo dir = new DirectoryInfo(fileText);
                    SHGetFileInfo(fileText, (uint)0x80, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                    icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                    DestroyIcon(shfi.hIcon);
                }
                else
                {
                    MessageBox.Show("当前不支持此类文件");
                    return;
                }
                imageList5.Images.Add(icon.ToBitmap());//图片存入imagelist  

                ListViewItem iw = new ListViewItem();//实例化ListViewItem
                string filename = Path.GetFileName(fileText);//文件名  “Default.aspx”
                string extension = Path.GetExtension(fileText);//扩展名 “.aspx”
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileText);// 没有扩展名的文件名 “Default”
                iw.Text = fileNameWithoutExtension;//设置图片文本路径
                iw.Name = fileText;//设置图片文本路径

                listView5.LargeImageList = imageList5;//绑定图片

                for (int i = 0; i < imageList5.Images.Count; i++)  //遍历程序图标
                {
                    iw.ImageIndex = i;

                }

                //SetValue("Set", iw.ImageIndex.ToString(), fileText);       //配置命令存路径                         

                FileStream fs = new FileStream(API.默认我的文档() + "\\dict\\config5.ini", FileMode.Append);//文本加入不覆盖

                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);//转码

                sw.WriteLine(fileText);

                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();

                listView5.Items.Add(iw);//添加图片显示
            }
            else 文件不完整();
        }

        private void listView5_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listView5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string file = listView5.Items[listView5.SelectedItems[0].Index].Name;
            if (File.Exists(file) == true)
            {
                Process.Start(file); //打开文件夹 
            }
            else
            {
                int Index;
                if (this.listView5.SelectedItems.Count > 0)//判断listview有被选中项
                {
                    lines5.Remove(listView5.Items[listView5.SelectedItems[0].Index].Name);
                    Index = listView5.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                    listView5.Items[Index].Remove();
                    File.WriteAllText(API.默认我的文档() + "\\dict\\config5.ini", string.Empty);//清空
                    foreach (string line in lines5)
                    {
                        File.WriteAllLines(API.默认我的文档() + "\\dict\\config5.ini", lines5, Encoding.UTF8);
                    }
                }
            }
        }

        private void listView6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string file = listView6.Items[listView6.SelectedItems[0].Index].Name;
            if (File.Exists(file) == true)
            {
                Process.Start(file); //打开文件夹 
            }
            else
            {
                int Index;
                if (this.listView6.SelectedItems.Count > 0)//判断listview有被选中项
                {
                    lines6.Remove(listView6.Items[listView6.SelectedItems[0].Index].Name);
                    Index = listView6.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                    listView6.Items[Index].Remove();
                    File.WriteAllText(API.默认我的文档() + "\\dict\\config6.ini", string.Empty);//清空
                    foreach (string line in lines6)
                    {
                        File.WriteAllLines(API.默认我的文档() + "\\dict\\config6.ini", lines6, Encoding.UTF8);
                    }
                }
            }
        }
        private void listView6_DragDrop(object sender, DragEventArgs e)
        {
            if (Directory.Exists("tool") == true)
            {
                string fileText = (e.Data.GetData(DataFormats.FileDrop) as string[])[0];
                Icon icon = null;

                if (File.Exists(fileText))//是文件
                {
                    icon = Icon.ExtractAssociatedIcon(fileText);//路径取ICO


                }
                else if (Directory.Exists(fileText))// 是文件夹
                {

                    SHFILEINFO shfi = new SHFILEINFO();
                    DirectoryInfo dir = new DirectoryInfo(fileText);
                    SHGetFileInfo(fileText, (uint)0x80, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                    icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                    DestroyIcon(shfi.hIcon);
                }
                else
                {
                    MessageBox.Show("当前不支持此类文件");
                    return;
                }
                imageList6.Images.Add(icon.ToBitmap());//图片存入imagelist  

                ListViewItem iw = new ListViewItem();//实例化ListViewItem
                string filename = Path.GetFileName(fileText);//文件名  “Default.aspx”
                string extension = Path.GetExtension(fileText);//扩展名 “.aspx”
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileText);// 没有扩展名的文件名 “Default”
                iw.Text = fileNameWithoutExtension;//设置图片文本路径
                iw.Name = fileText;//设置图片文本路径

                listView6.LargeImageList = imageList6;//绑定图片

                for (int i = 0; i < imageList6.Images.Count; i++)  //遍历程序图标
                {
                    iw.ImageIndex = i;

                }

                //SetValue("Set", iw.ImageIndex.ToString(), fileText);       //配置命令存路径                         

                FileStream fs = new FileStream(API.默认我的文档() + "\\dict\\config6.ini", FileMode.Append);//文本加入不覆盖

                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);//转码

                sw.WriteLine(fileText);

                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();

                listView6.Items.Add(iw);//添加图片显示
            }
            else 文件不完整();
        }

        private void listView6_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;

        }

        private void listView7_DragDrop(object sender, DragEventArgs e)
        {
            if (Directory.Exists("tool") == true)
            {
                string fileText = (e.Data.GetData(DataFormats.FileDrop) as string[])[0];
                Icon icon = null;
                if (File.Exists(fileText))//是文件
                {
                    icon = Icon.ExtractAssociatedIcon(fileText);//路径取ICO
                }
                else if (Directory.Exists(fileText))// 是文件夹
                {
                    SHFILEINFO shfi = new SHFILEINFO();
                    DirectoryInfo dir = new DirectoryInfo(fileText);
                    SHGetFileInfo(fileText, (uint)0x80, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                    icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                    DestroyIcon(shfi.hIcon);
                }
                else
                {
                    MessageBox.Show("当前不支持此类文件");
                    return;
                }
                imageList7.Images.Add(icon.ToBitmap());//图片存入imagelist  
                ListViewItem iw = new ListViewItem();//实例化ListViewItem
                string filename = Path.GetFileName(fileText);//文件名  “Default.aspx”
                string extension = Path.GetExtension(fileText);//扩展名 “.aspx”
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileText);// 没有扩展名的文件名 “Default”
                iw.Text = fileNameWithoutExtension;//设置图片文本路径
                iw.Name = fileText;//设置图片文本路径
                listView7.LargeImageList = imageList7;//绑定图片
                for (int i = 0; i < imageList7.Images.Count; i++)  //遍历程序图标
                {
                    iw.ImageIndex = i;

                }
                FileStream fs = new FileStream(API.默认我的文档() + "\\dict\\config7.ini", FileMode.Append);//文本加入不覆盖
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);//转码
                sw.WriteLine(fileText);
                sw.Flush();
                sw.Close();
                fs.Close();
                listView7.Items.Add(iw);//添加图片显示
            }
            else 文件不完整();

        }

        private void listView7_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listView7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string file = listView7.Items[listView7.SelectedItems[0].Index].Name;
            if (File.Exists(file) == true)
            {
                Process.Start(file); //打开文件夹 
            }
            else
            {
                int Index;
                if (this.listView7.SelectedItems.Count > 0)//判断listview有被选中项
                {
                    lines7.Remove(listView7.Items[listView7.SelectedItems[0].Index].Name);
                    Index = listView7.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                    listView7.Items[Index].Remove();
                    File.WriteAllText(API.默认我的文档() + "\\dict\\config7.ini", string.Empty);//清空
                    foreach (string line in lines7)
                    {
                        File.WriteAllLines(API.默认我的文档() + "\\dict\\config7.ini", lines7, Encoding.UTF8);
                    }
                }
            }
        }

        private void listView8_DragDrop(object sender, DragEventArgs e)
        {
            if (Directory.Exists("tool") == true)
            {
                string fileText = (e.Data.GetData(DataFormats.FileDrop) as string[])[0];
                Icon icon = null;
                if (File.Exists(fileText))//是文件
                {
                    icon = Icon.ExtractAssociatedIcon(fileText);//路径取ICO
                }
                else if (Directory.Exists(fileText))// 是文件夹
                {
                    SHFILEINFO shfi = new SHFILEINFO();
                    DirectoryInfo dir = new DirectoryInfo(fileText);
                    SHGetFileInfo(fileText, (uint)0x80, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                    icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                    DestroyIcon(shfi.hIcon);
                }
                else
                {
                    MessageBox.Show("当前不支持此类文件");
                    return;
                }
                imageList8.Images.Add(icon.ToBitmap());//图片存入imagelist  
                ListViewItem iw = new ListViewItem();//实例化ListViewItem
                string filename = Path.GetFileName(fileText);//文件名  “Default.aspx”
                string extension = Path.GetExtension(fileText);//扩展名 “.aspx”
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileText);// 没有扩展名的文件名 “Default”
                iw.Text = fileNameWithoutExtension;//设置图片文本路径
                iw.Name = fileText;//设置图片文本路径
                listView8.LargeImageList = imageList8;//绑定图片
                for (int i = 0; i < imageList8.Images.Count; i++)  //遍历程序图标
                {
                    iw.ImageIndex = i;

                }
                FileStream fs = new FileStream(API.默认我的文档() + "\\dict\\config8.ini", FileMode.Append);//文本加入不覆盖
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);//转码
                sw.WriteLine(fileText);
                sw.Flush();
                sw.Close();
                fs.Close();
                listView8.Items.Add(iw);//添加图片显示
            }
            else 文件不完整();
        }

        private void listView8_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;

        }

        private void listView8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string file = listView8.Items[listView8.SelectedItems[0].Index].Name;
            if (File.Exists(file) == true)
            {
                Process.Start(file); //打开文件夹 
            }
            else
            {
                int Index;
                if (this.listView8.SelectedItems.Count > 0)//判断listview有被选中项
                {
                    lines8.Remove(listView8.Items[listView8.SelectedItems[0].Index].Name);
                    Index = listView8.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                    listView8.Items[Index].Remove();
                    File.WriteAllText(API.默认我的文档() + "\\dict\\config8.ini", string.Empty);//清空
                    foreach (string line in lines8)
                    {
                        File.WriteAllLines(API.默认我的文档() + "\\dict\\config8.ini", lines8, Encoding.UTF8);
                    }
                }
            }

        }

        private void listView9_DragDrop(object sender, DragEventArgs e)
        {
            if (Directory.Exists("tool") == true)
            {
                string fileText = (e.Data.GetData(DataFormats.FileDrop) as string[])[0];
                Icon icon = null;
                if (File.Exists(fileText))//是文件
                {
                    icon = Icon.ExtractAssociatedIcon(fileText);//路径取ICO
                }
                else if (Directory.Exists(fileText))// 是文件夹
                {
                    SHFILEINFO shfi = new SHFILEINFO();
                    DirectoryInfo dir = new DirectoryInfo(fileText);
                    SHGetFileInfo(fileText, (uint)0x80, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                    icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                    DestroyIcon(shfi.hIcon);
                }
                else
                {
                    MessageBox.Show("当前不支持此类文件");
                    return;
                }
                imageList9.Images.Add(icon.ToBitmap());//图片存入imagelist  
                ListViewItem iw = new ListViewItem();//实例化ListViewItem
                string filename = Path.GetFileName(fileText);//文件名  “Default.aspx”
                string extension = Path.GetExtension(fileText);//扩展名 “.aspx”
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileText);// 没有扩展名的文件名 “Default”
                iw.Text = fileNameWithoutExtension;//设置图片文本路径
                iw.Name = fileText;//设置图片文本路径
                listView9.LargeImageList = imageList9;//绑定图片
                for (int i = 0; i < imageList9.Images.Count; i++)  //遍历程序图标
                {
                    iw.ImageIndex = i;

                }
                FileStream fs = new FileStream(API.默认我的文档() + "\\dict\\config9.ini", FileMode.Append);//文本加入不覆盖
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);//转码
                sw.WriteLine(fileText);
                sw.Flush();
                sw.Close();
                fs.Close();
                listView9.Items.Add(iw);//添加图片显示
            }
            else 文件不完整();
        }

        private void listView9_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;

        }

        private void listView9_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string file = listView9.Items[listView9.SelectedItems[0].Index].Name;
            if (File.Exists(file) == true)
            {
                Process.Start(file); //打开文件夹 
            }
            else
            {
                int Index;
                if (this.listView9.SelectedItems.Count > 0)//判断listview有被选中项
                {
                    lines9.Remove(listView9.Items[listView9.SelectedItems[0].Index].Name);
                    Index = listView9.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                    listView9.Items[Index].Remove();
                    File.WriteAllText(API.默认我的文档() + "\\dict\\config9.ini", string.Empty);//清空
                    foreach (string line in lines9)
                    {
                        File.WriteAllLines(API.默认我的文档() + "\\dict\\config9.ini", lines9, Encoding.UTF8);
                    }
                }
            }
        }

        private void listView10_DragDrop(object sender, DragEventArgs e)
        {
            if (Directory.Exists("tool") == true)
            {
                string fileText = (e.Data.GetData(DataFormats.FileDrop) as string[])[0];
                Icon icon = null;
                if (File.Exists(fileText))//是文件
                {
                    icon = Icon.ExtractAssociatedIcon(fileText);//路径取ICO
                }
                else if (Directory.Exists(fileText))// 是文件夹
                {
                    SHFILEINFO shfi = new SHFILEINFO();
                    DirectoryInfo dir = new DirectoryInfo(fileText);
                    SHGetFileInfo(fileText, (uint)0x80, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                    icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                    DestroyIcon(shfi.hIcon);
                }
                else
                {
                    MessageBox.Show("当前不支持此类文件");
                    return;
                }
                imageList10.Images.Add(icon.ToBitmap());//图片存入imagelist  
                ListViewItem iw = new ListViewItem();//实例化ListViewItem
                string filename = Path.GetFileName(fileText);//文件名  “Default.aspx”
                string extension = Path.GetExtension(fileText);//扩展名 “.aspx”
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileText);// 没有扩展名的文件名 “Default”
                iw.Text = fileNameWithoutExtension;//设置图片文本路径
                iw.Name = fileText;//设置图片文本路径
                listView10.LargeImageList = imageList10;//绑定图片
                for (int i = 0; i < imageList10.Images.Count; i++)  //遍历程序图标
                {
                    iw.ImageIndex = i;

                }
                FileStream fs = new FileStream(API.默认我的文档() + "\\dict\\config10.ini", FileMode.Append);//文本加入不覆盖
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);//转码
                sw.WriteLine(fileText);
                sw.Flush();
                sw.Close();
                fs.Close();
                listView10.Items.Add(iw);//添加图片显示
            }
            else 文件不完整();
        }

        private void listView10_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listView10_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string file = listView10.Items[listView10.SelectedItems[0].Index].Name;
            if (File.Exists(file) == true)
            {
                Process.Start(file); //打开文件夹 
            }
            else
            {
                int Index;
                if (this.listView10.SelectedItems.Count > 0)//判断listview有被选中项
                {
                    lines10.Remove(listView10.Items[listView10.SelectedItems[0].Index].Name);
                    Index = listView10.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                    listView10.Items[Index].Remove();
                    File.WriteAllText(API.默认我的文档() + "\\dict\\config10.ini", string.Empty);//清空
                    foreach (string line in lines10)
                    {
                        File.WriteAllLines(API.默认我的文档() + "\\dict\\config10.ini", lines10, Encoding.UTF8);
                    }
                }
            }
        }

        private void listView11_DragDrop(object sender, DragEventArgs e)
        {
            if (Directory.Exists("tool") == true)
            {
                string fileText = (e.Data.GetData(DataFormats.FileDrop) as string[])[0];
                Icon icon = null;
                if (File.Exists(fileText))//是文件
                {
                    icon = Icon.ExtractAssociatedIcon(fileText);//路径取ICO
                }
                else if (Directory.Exists(fileText))// 是文件夹
                {
                    SHFILEINFO shfi = new SHFILEINFO();
                    DirectoryInfo dir = new DirectoryInfo(fileText);
                    SHGetFileInfo(fileText, (uint)0x80, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                    icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                    DestroyIcon(shfi.hIcon);
                }
                else
                {
                    MessageBox.Show("当前不支持此类文件");
                    return;
                }
                imageList11.Images.Add(icon.ToBitmap());//图片存入imagelist  
                ListViewItem iw = new ListViewItem();//实例化ListViewItem
                string filename = Path.GetFileName(fileText);//文件名  “Default.aspx”
                string extension = Path.GetExtension(fileText);//扩展名 “.aspx”
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileText);// 没有扩展名的文件名 “Default”
                iw.Text = fileNameWithoutExtension;//设置图片文本路径
                iw.Name = fileText;//设置图片文本路径
                listView11.LargeImageList = imageList11;//绑定图片
                for (int i = 0; i < imageList11.Images.Count; i++)  //遍历程序图标
                {
                    iw.ImageIndex = i;

                }
                FileStream fs = new FileStream(API.默认我的文档() + "\\dict\\config11.ini", FileMode.Append);//文本加入不覆盖
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);//转码
                sw.WriteLine(fileText);
                sw.Flush();
                sw.Close();
                fs.Close();
                listView11.Items.Add(iw);//添加图片显示
            }
            else 文件不完整();
        }
        private void listView11_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }
        private void listView11_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string file = listView11.Items[listView11.SelectedItems[0].Index].Name;
            if (File.Exists(file) == true)
            {
                Process.Start(file); //打开文件夹 
            }
            else
            {
                if (this.listView11.SelectedItems.Count > 0)//判断listview有被选中项
                {
                    lines.Remove(listView11.Items[listView11.SelectedItems[0].Index].Name);
                    int Index = listView11.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                    listView11.Items[Index].Remove();
                    File.WriteAllText(API.默认我的文档() + "\\dict\\config11.ini", string.Empty);//清空
                    foreach (string line in lines)
                    {
                        File.WriteAllLines(API.默认我的文档() + "\\dict\\config11.ini", lines, Encoding.UTF8);
                    }
                }
            }
        }
        #endregion
        #region//菜单选项
        private void 打开文件目录toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)//判断listview有被选中项
            {
                string file1 = API.默认我的文档() + "\\" + listView1.Items[listView1.SelectedItems[0].Index].Name;
                if (File.Exists(file1) == true)
                {
                    Process.Start(Path.GetDirectoryName(file1));
                }
            }
            else if (this.listView2.SelectedItems.Count > 0)//判断listview有被选中项
            {
                string file2 = API.默认我的文档() + "\\" + listView2.Items[listView2.SelectedItems[0].Index].Name;
                if (File.Exists(file2) == true)
                {
                    Process.Start(Path.GetDirectoryName(file2));
                }
            }
            else if (this.listView3.SelectedItems.Count > 0)//判断listview有被选中项
            {
                string file3 = API.默认我的文档() + "\\" + listView3.Items[listView3.SelectedItems[0].Index].Name;
                if (File.Exists(file3) == true)
                {
                    Process.Start(Path.GetDirectoryName(file3));
                }
            }
            else if (this.listView4.SelectedItems.Count > 0)//判断listview有被选中项
            {
                string file4 = API.默认我的文档() + "\\" + listView4.Items[listView4.SelectedItems[0].Index].Name;
                if (File.Exists(file4) == true)
                {
                    Process.Start(Path.GetDirectoryName(file4));
                }
            }
            else if (this.listView5.SelectedItems.Count > 0)//判断listview有被选中项
            {
                string file5 = API.默认我的文档() + "\\" + listView5.Items[listView5.SelectedItems[0].Index].Name;
                if (File.Exists(file5) == true)
                {
                    Process.Start(Path.GetDirectoryName(file5));
                }
            }
            else if (this.listView6.SelectedItems.Count > 0)//判断listview有被选中项
            {
                string file6 = API.默认我的文档() + "\\" + listView6.Items[listView6.SelectedItems[0].Index].Name;
                if (File.Exists(file6) == true)
                {
                    Process.Start(Path.GetDirectoryName(file6));
                }
            }
            else if (this.listView7.SelectedItems.Count > 0)//判断listview有被选中项
            {
                string file7 = API.默认我的文档() + "\\" + listView7.Items[listView7.SelectedItems[0].Index].Name;
                if (File.Exists(file7) == true)
                {
                    Process.Start(Path.GetDirectoryName(file7));
                }
            }
            else if (this.listView8.SelectedItems.Count > 0)//判断listview有被选中项
            {
                string file8 = API.默认我的文档() + "\\" + listView8.Items[listView8.SelectedItems[0].Index].Name;
                if (File.Exists(file8) == true)
                {
                    Process.Start(Path.GetDirectoryName(file8));
                }
            }
            else if (this.listView9.SelectedItems.Count > 0)//判断listview有被选中项
            {
                string file9 = API.默认我的文档() + "\\" + listView9.Items[listView9.SelectedItems[0].Index].Name;
                if (File.Exists(file9) == true)
                {
                    Process.Start(Path.GetDirectoryName(file9));
                }
            }
            else if (this.listView10.SelectedItems.Count > 0)//判断listview有被选中项
            {
                string file10 = API.默认我的文档() + "\\" + listView10.Items[listView10.SelectedItems[0].Index].Name;
                if (File.Exists(file10) == true)
                {
                    Process.Start(Path.GetDirectoryName(file10));
                }
            }
            else if (this.listView11.SelectedItems.Count > 0)//判断listview有被选中项
            {
                string file11 = listView11.Items[listView11.SelectedItems[0].Index].Name;
                if (File.Exists(file11) == true)
                {
                    Process.Start(Path.GetDirectoryName(file11));
                }
            }
            //else
            //{
            //    API.信息框("未有选中项", "信息:", 5000);
            //}
        }
        private void 删除ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int Index;
            if (this.listView1.SelectedItems.Count > 0)//判断listview有被选中项
            {
                string file1 = listView1.Items[listView1.SelectedItems[0].Index].Name;
                lines.Remove(listView1.Items[listView1.SelectedItems[0].Index].Name);
                Index = listView1.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                listView1.Items[Index].Remove();
                File.WriteAllText(API.默认我的文档() + "\\dict\\config1.ini", string.Empty);//清空
                foreach (string line in lines)
                { 
                    File.WriteAllLines(API.默认我的文档() + "\\dict\\config1.ini", lines, Encoding.UTF8);
                }
                if (删除路径及文件toolStripMenuItem1.Checked == true)
                {
                    try
                    {
                        if (File.Exists(file1) == true)
                        {
                            File.Delete(file1);
                        }
                    }
                    catch
                    {
                    }                 
                }   
            }
            else if (this.listView2.SelectedItems.Count > 0)//判断listview有被选中项
            {
                string file2 = listView2.Items[listView2.SelectedItems[0].Index].Name;
                lines2.Remove(listView2.Items[listView2.SelectedItems[0].Index].Name);
                Index = listView2.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                listView2.Items[Index].Remove();
                File.WriteAllText(API.默认我的文档() + "\\dict\\config2.ini", string.Empty);//清空
                foreach (string line in lines2)
                {  
                    File.WriteAllLines(API.默认我的文档() + "\\dict\\config2.ini", lines2, Encoding.UTF8);
                }
                if (删除路径及文件toolStripMenuItem1.Checked == true)
                {
                    try
                    {
                        if (File.Exists(file2) == true)
                        {
                            File.Delete(file2);
                        }
                    }
                    catch
                    {
                    }
                }
                 
            }
            else if (this.listView3.SelectedItems.Count > 0)//判断listview有被选中项
            {
                string file3 = listView3.Items[listView3.SelectedItems[0].Index].Name;
                lines3.Remove(listView3.Items[listView3.SelectedItems[0].Index].Name);
                Index = listView3.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                listView3.Items[Index].Remove();
                File.WriteAllText(API.默认我的文档() + "\\dict\\config3.ini", string.Empty);//清空
                foreach (string line in lines3)
                {
                    File.WriteAllLines(API.默认我的文档() + "\\dict\\config3.ini", lines3, Encoding.UTF8);
                }
                if (删除路径及文件toolStripMenuItem1.Checked == true)
                {
                    try
                    {
                        if (File.Exists(file3) == true)
                    {
                        File.Delete(file3);
                    }
                    }
                    catch
                    {
                    }
                }
            }
            else if (this.listView4.SelectedItems.Count > 0)//判断listview有被选中项
            {
                string file4 = listView4.Items[listView4.SelectedItems[0].Index].Name;
                lines4.Remove(listView4.Items[listView4.SelectedItems[0].Index].Name);
                Index = listView4.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                listView4.Items[Index].Remove();
                File.WriteAllText(API.默认我的文档() + "\\dict\\config4.ini", string.Empty);//清空
                foreach (string line in lines4)
                {
                    File.WriteAllLines(API.默认我的文档() + "\\dict\\config4.ini", lines4, Encoding.UTF8);
                }
                if (删除路径及文件toolStripMenuItem1.Checked == true)
                {
                    try
                    {
                        if (File.Exists(file4) == true)
                    {
                        File.Delete(file4);
                    }
                    }
                    catch
                    {
                    }
                }
            
            }
            else if (this.listView5.SelectedItems.Count > 0)//判断listview有被选中项
            {
                string file5 = listView5.Items[listView5.SelectedItems[0].Index].Name;
                lines5.Remove(listView5.Items[listView5.SelectedItems[0].Index].Name);
                Index = listView5.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                listView5.Items[Index].Remove();
                File.WriteAllText(API.默认我的文档() + "\\dict\\config5.ini", string.Empty);//清空
                foreach (string line in lines5)
                {
                    File.WriteAllLines(API.默认我的文档() + "\\dict\\config5.ini", lines5, Encoding.UTF8);
                }
                if (删除路径及文件toolStripMenuItem1.Checked == true)
                {
                    try
                    {
                        if (File.Exists(file5) == true)
                        {
                            File.Delete(file5);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            else if (this.listView6.SelectedItems.Count > 0)//判断listview有被选中项
            {
                string file6 = listView6.Items[listView6.SelectedItems[0].Index].Name;
                lines6.Remove(listView6.Items[listView6.SelectedItems[0].Index].Name);
                Index = listView6.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                listView6.Items[Index].Remove();
                File.WriteAllText(API.默认我的文档() + "\\dict\\config6.ini", string.Empty);//清空
                foreach (string line in lines6)
                {
                    File.WriteAllLines(API.默认我的文档() + "\\dict\\config6.ini", lines6, Encoding.UTF8);
                }
                if (删除路径及文件toolStripMenuItem1.Checked == true)
                {
                    try
                    {
                        if (File.Exists(file6) == true)
                        {
                            File.Delete(file6);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            else if (this.listView7.SelectedItems.Count > 0)//判断listview有被选中项
            {
                string file7 = listView7.Items[listView7.SelectedItems[0].Index].Name;
                lines7.Remove(listView7.Items[listView7.SelectedItems[0].Index].Name);
                Index = listView7.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                listView7.Items[Index].Remove();
                File.WriteAllText(API.默认我的文档() + "\\dict\\config7.ini", string.Empty);//清空
                foreach (string line in lines7)
                {
                    File.WriteAllLines(API.默认我的文档() + "\\dict\\config7.ini", lines7, Encoding.UTF8);
                }
                if (删除路径及文件toolStripMenuItem1.Checked == true)
                {
                    try
                    {
                        if (File.Exists(file7) == true)
                        {
                            File.Delete(file7);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            else if (this.listView8.SelectedItems.Count > 0)//判断listview有被选中项
            {
                string file8 = listView8.Items[listView8.SelectedItems[0].Index].Name;
                lines8.Remove(listView8.Items[listView8.SelectedItems[0].Index].Name);
                Index = listView8.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                listView8.Items[Index].Remove();
                File.WriteAllText(API.默认我的文档() + "\\dict\\config8.ini", string.Empty);//清空
                foreach (string line in lines8)
                {
                    File.WriteAllLines(API.默认我的文档() + "\\dict\\config8.ini", lines8, Encoding.UTF8);
                }
                if (删除路径及文件toolStripMenuItem1.Checked == true)
                {
                    try
                    {
                        if (File.Exists(file8) == true)
                        {
                            File.Delete(file8);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            else if (this.listView9.SelectedItems.Count > 0)//判断listview有被选中项
            {
                string file9 = listView9.Items[listView9.SelectedItems[0].Index].Name;
                lines9.Remove(listView9.Items[listView9.SelectedItems[0].Index].Name);
                Index = listView9.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                listView9.Items[Index].Remove();
                File.WriteAllText(API.默认我的文档() + "\\dict\\config9.ini", string.Empty);//清空
                foreach (string line in lines9)
                {
                    File.WriteAllLines(API.默认我的文档() + "\\dict\\config9.ini", lines9, Encoding.UTF8);
                }
                if (删除路径及文件toolStripMenuItem1.Checked == true)
                {
                    try
                    {
                        if (File.Exists(file9) == true)
                        {
                            File.Delete(file9);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            else if (this.listView10.SelectedItems.Count > 0)//判断listview有被选中项
            {
                string file10 = listView10.Items[listView10.SelectedItems[0].Index].Name;
                lines10.Remove(listView10.Items[listView10.SelectedItems[0].Index].Name);
                Index = listView10.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                listView10.Items[Index].Remove();
                File.WriteAllText(API.默认我的文档() + "\\dict\\config10.ini", string.Empty);//清空
                foreach (string line in lines10)
                {
                    File.WriteAllLines(API.默认我的文档() + "\\dict\\config10.ini", lines10, Encoding.UTF8);
                }
                if (删除路径及文件toolStripMenuItem1.Checked == true)
                {
                    try
                    {
                        if (File.Exists(file10) == true)
                        {
                            File.Delete(file10);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            else if (this.listView11.SelectedItems.Count > 0)//判断listview有被选中项
            {
                string file11 = listView11.Items[listView11.SelectedItems[0].Index].Name;
                lines11.Remove(listView11.Items[listView11.SelectedItems[0].Index].Name);
                Index = listView11.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                listView11.Items[Index].Remove();
                File.WriteAllText(API.默认我的文档() + "\\dict\\config11.ini", string.Empty);//清空
                foreach (string line in lines11)
                {
                    File.WriteAllLines(API.默认我的文档() + "\\dict\\config11.ini", lines11, Encoding.UTF8);
                }
                if (删除路径及文件toolStripMenuItem1.Checked == true)
                {
                    try
                    {
                        if (File.Exists(file11) == true)
                        {
                            File.Delete(file11);
                        }
                    }
                    catch
                    {
                    }
                }
            }

        }
        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.Visible == true)//判断listview有被选中项
            {
                listView1.Items.Clear();//清空
                File.WriteAllText(API.默认我的文档() + "\\dict\\config1.ini", string.Empty);
            }
            else if (listView2.Visible == true)
            {
                listView2.Items.Clear();//清空
                File.WriteAllText(API.默认我的文档() + "\\dict\\config2.ini", string.Empty);

            }
            else if (listView3.Visible == true)
            {
                listView3.Items.Clear();//清空
                File.WriteAllText(API.默认我的文档() + "\\dict\\config3.ini", string.Empty);

            }
            else if (listView4.Visible == true)
            {
                listView4.Items.Clear();//清空
                File.WriteAllText(API.默认我的文档() + "\\dict\\config4.ini", string.Empty);

            }
            else if (listView5.Visible == true)
            {
                listView5.Items.Clear();//清空
                File.WriteAllText(API.默认我的文档() + "\\dict\\config5.ini", string.Empty);

            }
            else if (listView6.Visible == true)
            {
                listView6.Items.Clear();//清空
                File.WriteAllText(API.默认我的文档() + "\\dict\\config6.ini", string.Empty);

            }
            else if (listView7.Visible == true)
            {
                listView7.Items.Clear();//清空
                File.WriteAllText(API.默认我的文档() + "\\dict\\config7.ini", string.Empty);

            }
            else if (listView8.Visible == true)
            {
                listView8.Items.Clear();//清空
                File.WriteAllText(API.默认我的文档() + "\\dict\\config8.ini", string.Empty);

            }
            else if (listView9.Visible == true)
            {
                listView9.Items.Clear();//清空
                File.WriteAllText(API.默认我的文档() + "\\dict\\config9.ini", string.Empty);

            }
            else if (listView10.Visible == true)
            {
                listView10.Items.Clear();//清空
                File.WriteAllText(API.默认我的文档() + "\\dict\\config10.ini", string.Empty);

            }
            else if (listView11.Visible == true)
            {
                listView11.Items.Clear();//清空
                File.WriteAllText(API.默认我的文档() + "\\dict\\config11.ini", string.Empty);

            }

        }
        private void 菜单_Opening(object sender, CancelEventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)//判断listview有被选中项
            {
                if (this.listView1.SelectedItems.Count > 0)//判断listview有被选中项
                {
                    删除ToolStripMenuItem.Enabled = true;
                }
                else 删除ToolStripMenuItem.Enabled = false;

            }
            if (this.listView2.SelectedItems.Count > 0)//判断listview有被选中项
            {
                if (this.listView2.SelectedItems.Count > 0)//判断listview有被选中项
                {
                    删除ToolStripMenuItem.Enabled = true;
                }
                else 删除ToolStripMenuItem.Enabled = false;
            }
        }
        private void 窗口置顶_CheckedChanged(object sender, EventArgs e)
        {
            if (窗口置顶.Checked == true)
            {
                API.写配置项(功能配置路径, "Set", "Top", "1");
                this.TopMost = true;
                //窗口_置顶(取窗口句柄(), true);
            }
            else
            {
                this.TopMost = false;
                //窗口_置顶(取窗口句柄(), false);
                API.写配置项(功能配置路径, "Set", "Top", "0");
            }
        }
        #endregion
        private void 配置初始化()
        {
            if (Directory.Exists(API.默认我的文档() + "\\dict") == false)
            {
                Directory.CreateDirectory(API.默认我的文档() + "\\dict");//创建新路径
                File.WriteAllText(API.默认我的文档() + "\\dict\\config1.ini", null);
                File.WriteAllText(API.默认我的文档() + "\\dict\\RMbinconfig.ini", null, Encoding.UTF8);

                小图标ToolStripMenuItem.Checked = true;
                API.写配置项(功能配置路径, "Set", "Small", "1");
            }
            else
            {
                if (File.Exists(API.默认我的文档() + "\\dict\\RMbinconfig.ini") == false)
                {
                    File.WriteAllText(API.默认我的文档() + "\\dict\\RMbinconfig.ini", null, Encoding.UTF8);
                }
                if (File.Exists(API.默认我的文档() + "\\dict\\config1.ini") == false)//是文件
                {
                    File.WriteAllText(API.默认我的文档() + "\\dict\\config1.ini", null);
                }

                小图标ToolStripMenuItem.Checked = true;
                API.写配置项(功能配置路径, "Set", "Small", "1");
            }
            if (API.读配置项(功能配置路径, "Set", "comboBox6") != "")
            {
                comboBox6.Text = API.读配置项(功能配置路径, "Set", "comboBox6");
            }
            else comboBox6.Text = "0";
            if (API.读配置项(功能配置路径, "Set", "comboBox5") != "")
            {
                comboBox5.Text = API.读配置项(功能配置路径, "Set", "comboBox5");
            }
            else comboBox5.Text = "15";
            if (API.读配置项(功能配置路径, "Set", "comboBox4") != "")
            {
                comboBox4.Text = API.读配置项(功能配置路径, "Set", "comboBox4");
            }
            else comboBox4.Text = "0";
            if (API.读配置项(功能配置路径, "Set", "F12") == "1")
            {
                checkBox1.Checked = true;
            }
            if (API.读配置项(功能配置路径, "Set", "radioButton4") == "1")
            {
                radioButton4.Checked = true;
            }
            if (API.读配置项(功能配置路径, "Set", "烤CPU") == "1")
            {
                烤CPU.Checked = true;
            }
            if (API.读配置项(功能配置路径, "Set", "烤GPU") == "1")
            {
                烤GPU.Checked = true;
            }
            if (API.读配置项(功能配置路径, "Set", "Top") == "1")
            {
                窗口置顶.Checked = true;
                this.TopMost = true;
            }
            if (API.读配置项(功能配置路径, "Set", "TB") == "1")
            {
                if (File.Exists("bin\\SystemTb.dll") == true)
                {
                    checkBox2.Checked = true;
                }
                else checkBox2.Checked = false;
            }
            if (API.读配置项(功能配置路径, "Set", "FileD") == "1")
            {
                删除路径及文件toolStripMenuItem1.Checked = true;
            }
            else 删除路径及文件toolStripMenuItem1.Checked = false;
            if (API.读配置项(功能配置路径, "Set", "large") == "1")
            {
                大图标ToolStripMenuItem.Checked = true;
                中图标ToolStripMenuItem.Checked = false;
                小图标ToolStripMenuItem.Checked = false;
                API.写配置项(功能配置路径, "Set", "large", "1");
                API.写配置项(功能配置路径, "Set", "in", "0");
                API.写配置项(功能配置路径, "Set", "Small", "0");
            }
            if (API.读配置项(功能配置路径, "Set", "in") == "1")
            {
                中图标ToolStripMenuItem.Checked = true;
                大图标ToolStripMenuItem.Checked = false;
                小图标ToolStripMenuItem.Checked = false;
                API.写配置项(功能配置路径, "Set", "in", "1");
                API.写配置项(功能配置路径, "Set", "large", "0");
                API.写配置项(功能配置路径, "Set", "Small", "0");
            }
            if (API.读配置项(功能配置路径, "Set", "Small") == "1")
            {
                大图标ToolStripMenuItem.Checked = false;
                中图标ToolStripMenuItem.Checked = false;
                小图标ToolStripMenuItem.Checked = true;
                API.写配置项(功能配置路径, "Set", "Small", "1");
                API.写配置项(功能配置路径, "Set", "large", "0");
                API.写配置项(功能配置路径, "Set", "in", "0");
            }
            API.写配置项(功能配置路径, "Set", "Hwd", this.Handle.ToString());
            API.写配置项(功能配置路径, "Remember", "ver", number);
        }
        private void 初始化全部()
        {
            if (Directory.Exists("tool") == true)
            {
                if (API.读配置项(功能配置路径, "Set", "tabPage1") != "1")
                {
                    API.写配置项(功能配置路径, "Set", "tabPage1", "1");
                    API.处理器写入路径();
                    API.主板工具写入路径();
                    API.外设工具写入路径();
                    API.烤鸡工具写入路径();
                    API.其他工具写入路径();
                    API.内存工具写入路径();
                    API.显卡工具写入路径();
                    API.硬盘工具写入路径();
                    API.显示器工具写入路径();
                    API.综合检测写入路径();
                    API.自定工具写入路径();
                }
            }
        }
        private void GPUchushihua()
        {
            string Ee = null; double capacity33; double capacity22; string Cc3 = null; double capacity1; string Cc1 = null; string Cc2 = null; string Cc4 = null; string Cc5 = null; string Cc6 = null;
            //硬盘
            try
            {
                DriveInfo[] allDirves = DriveInfo.GetDrives();//检索计算机上的所有逻辑驱动器名称
                foreach (DriveInfo item in allDirves)
                {
                    if (item.IsReady)
                    {
                        capacity22 = Math.Round(Int64.Parse(item.TotalSize.ToString()) / 1024 / 1024 / 1024.0);
                        capacity33 = Math.Round(Int64.Parse(item.TotalFreeSpace.ToString()) / 1024 / 1024 / 1024.0);
                        if (语言选择框.SelectedIndex == 0)
                        {
                            Ee += item.Name + " 容量: " + capacity22.ToString() + "G , 可用大小: " + capacity33.ToString() + "G; \r\n";
                        }
                        else if (语言选择框.SelectedIndex == 1)
                        {
                            Ee += item.Name + " Capacity: " + capacity22.ToString() + "G , Size: " + capacity33.ToString() + "G; \r\n";
                        }
                        else
                        {
                            Ee += item.Name + " 容量: " + capacity22.ToString() + "G , 可用大小: " + capacity33.ToString() + "G; \r\n";
                        }
                    }
                }
                textBox9.Text = Ee;
                textBox11.Text = Ee;
                ManagementObjectSearcher searcherC = new ManagementObjectSearcher("Select * From Win32_DiskDrive");
                foreach (ManagementObject mo in searcherC.Get())
                {
                    capacity1 = Math.Round(Int64.Parse(mo.Properties["Size"].Value.ToString()) / 1024 / 1024 / 1024.0);
                    Cc1 += mo["model"].ToString().Trim() + capacity1.ToString() + "G; ";
                    Cc2 += capacity1.ToString().Trim() + "G; ";
                    Cc3 += mo["model"].ToString().Trim() + ";  \r\n";
                    Cc4 += mo["InterfaceType"].ToString().Trim() + ";  ";
                    Cc5 += mo["Status"].ToString().Trim() + ";  ";
                    Cc6 += mo["SerialNumber"].ToString().Trim() + ";  ";
                }
                searcherC.Dispose();
            }
            catch
            {
                if (语言选择框.SelectedIndex == 0)
                {
                    label2.Text = "未取到硬盘";
                }
                else if (语言选择框.SelectedIndex == 1)
                {
                    label2.Text = "No data obtained";
                }
                else
                {
                    label2.Text = "未取到硬盘";
                }
            }
            textBox8.Text = Cc1;//硬盘
            textBox10.Text = Cc3;
            if (语言选择框.SelectedIndex == 0)
            {
                label73.Text = "接口类型:      " + Cc4;
                label72.Text = "磁盘容量:      " + Cc2;
                label62.Text = "磁盘状态:      " + Cc5;
                label66.Text = "磁盘序列:      " + Cc6;
            }
            else if (语言选择框.SelectedIndex == 1)
            {
                label73.Text = "type:            " + Cc4;
                label72.Text = "Size:            " + Cc2;
                label62.Text = "Status:         " + Cc5;
                label66.Text = "Serial:          " + Cc6;

            }
            else
            {
                label73.Text = "接口类型:      " + Cc4;
                label72.Text = "磁盘容量:      " + Cc2;
                label62.Text = "磁盘状态:      " + Cc5;
                label66.Text = "磁盘序列:      " + Cc6;
            }
            //声卡
            string aa = null; //string aa1 = null;
            try
            {
                ManagementObjectSearcher searcherr = new ManagementObjectSearcher("Select * From Win32_SoundDevice");
                foreach (ManagementObject mo in searcherr.Get())
                {
                    aa += mo["Name"].ToString().Trim() + "; ";
                    // aa1 += mo["Name"].ToString().Trim() + "\r\n";
                }
                searcherr.Dispose();
            }
            catch
            {
                if (语言选择框.SelectedIndex == 0)
                {
                    label2.Text = "未取到声卡";
                    textBox7.Text = "未取到声卡";//取到声卡
                    textBox13.Text = textBox7.Text;//取到声卡
                }
                else if (语言选择框.SelectedIndex == 1)
                {
                    label2.Text = "No data obtained";
                    textBox7.Text = "No data obtained";//取到声卡
                    textBox13.Text = textBox7.Text;//取到声卡
                }
                else
                {
                    label2.Text = "未取到声卡";
                    textBox7.Text = "未取到声卡";//取到声卡
                    textBox13.Text = textBox7.Text;//取到声卡
                }

            }
            if (aa != null)
            {
                textBox7.Text = aa;//取到声卡           
                textBox13.Text = aa.Replace("; ", ";\r\n");//取到声卡
            }
            else
            {
                if (语言选择框.SelectedIndex == 0)
                {
                    textBox7.Text = "未取到声卡";//取到声卡
                    textBox13.Text = textBox7.Text;//取到声卡
                }
                else
                {
                    textBox7.Text = "No data obtained";//取到声卡
                    textBox13.Text = textBox7.Text;//取到声卡
                }

            }
            //网卡
            string bbb = null; string bb1 = null;
            try
            {
                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();//获取本地计算机上网络接口的对象 
                foreach (NetworkInterface adapter in adapters)
                {//";名称:" + adapter.Name  + ";速度:" + adapter.Speed * 0.001 * 0.001 + "M" +
                    bbb += adapter.Description + "; ";
                    if (语言选择框.SelectedIndex == 0)
                        bb1 += "型号:" + adapter.Description + "; " + "\r\n" + "名称:" + adapter.Name + "; " + "\r\n" + "速度:" + Math.Round(adapter.Speed * 0.001 * 0.001) + "M; " + "\r\n";
                    else if (语言选择框.SelectedIndex == 1)
                    {
                        bb1 += "Model:" + adapter.Description + "; " + "\r\n" + "Name:" + adapter.Name + "; " + "\r\n" + "Speed:" + Math.Round(adapter.Speed * 0.001 * 0.001) + "M; " + "\r\n";
                    }
                    else
                    {
                        bb1 += "型号:" + adapter.Description + "; " + "\r\n" + "名称:" + adapter.Name + "; " + "\r\n" + "速度:" + Math.Round(adapter.Speed * 0.001 * 0.001) + "M; " + "\r\n";
                    }
                }
            }
            catch
            {
                if (语言选择框.SelectedIndex == 0)
                {
                    label2.Text = "未取到网卡";
                    textBox6.Text = "未取到网卡";//取到网卡                             
                    textBox12.Text = textBox6.Text;//取到网卡 
                }
                else if (语言选择框.SelectedIndex == 1)
                {
                    label2.Text = "No data obtained";
                    textBox6.Text = "No data obtained";//取到网卡                             
                    textBox12.Text = textBox6.Text;//取到网卡 
                } else
                {
                    label2.Text = "未取到网卡";
                    textBox6.Text = "未取到网卡";//取到网卡                             
                    textBox12.Text = textBox6.Text;//取到网卡 
                }

            }
            if (bbb != null)
            {
                textBox6.Text = bbb;//取到网卡                             
                textBox12.Text = bb1;//取到网卡 
            }
            else
            {
                if (语言选择框.SelectedIndex == 0)
                {
                    textBox6.Text = "未取到网卡";//取到网卡                             
                    textBox12.Text = textBox6.Text;//取到网卡 
                }
                else
                {
                    textBox6.Text = "No data obtained";//取到网卡                             
                    textBox12.Text = textBox6.Text;//取到网卡 
                }
            }
            //显卡
            string c = null; string c2 = null; string c4 = null; string c1 = null; string c3 = null;
            try
            {
                ManagementObjectSearcher searcherd3 = new ManagementObjectSearcher("Select * From Win32_DisplayConfiguration");
                foreach (ManagementObject mo in searcherd3.Get())
                {
                    c += mo["DeviceName"].ToString().Trim() + "; ";
                    c1 += mo["DisplayFrequency"].ToString().Trim() + "; ";
                    c2 += mo["BitsPerPel"].ToString().Trim() + "; ";
                    c3 += mo["SpecificationVersion"].ToString().Trim() + "; ";
                    c4 += mo["DriverVersion"].ToString().Trim() + "; ";
                }
                searcherd3.Dispose();
            }
            catch
            {
                if (语言选择框.SelectedIndex == 0)
                {
                    label2.Text = "未取到显卡";
                }
                else if (语言选择框.SelectedIndex == 1)
                {
                    label2.Text = "No data obtained";
                }
                else
                {
                    label2.Text = "未取到显卡";
                }

            }

            if (语言选择框.SelectedIndex == 1)
            {
                textBox5.Text = c;
                label71.Text = "DeviceName:          " + c;
                label70.Text = "DisplayFrequency:  " + c1;
                label69.Text = "BitsPerPel:              " + c2;
                label67.Text = "Version:                 " + c3;
                if (c4 == null)
                    label68.Text = null;
                else label68.Text = "DriverVersion:        " + c4;
            }
            else
            {
                textBox5.Text = c;
                label71.Text = "显卡型号:     " + c;
                label70.Text = "显示频率:     " + c1;
                label69.Text = "显示像素:     " + c2;
                label67.Text = "规格型号:     " + c3;
                if (c4 == null)
                    label68.Text = null;
                else label68.Text = "驱动版本:     " + c4;
            }

        }
        private void 版本号()
        {
            textBox1.BorderStyle = BorderStyle.None;
            textBox2.BorderStyle = BorderStyle.None;
            textBox3.BorderStyle = BorderStyle.None;
            textBox4.BorderStyle = BorderStyle.None;
            textBox5.BorderStyle = BorderStyle.None;
            textBox6.BorderStyle = BorderStyle.None;
            textBox7.BorderStyle = BorderStyle.None;
            textBox8.BorderStyle = BorderStyle.None;
            textBox9.BorderStyle = BorderStyle.None;
            textBox10.BorderStyle = BorderStyle.None;
            textBox11.BorderStyle = BorderStyle.None;
            textBox13.BorderStyle = BorderStyle.None;
            textBox12.BorderStyle = BorderStyle.None;
            textBox14.BorderStyle = BorderStyle.None;
            textBox15.BorderStyle = BorderStyle.None;
 
      

            string Dd = null;
            string Dd2 = null;

            ManagementObjectSearcher searcherd = new ManagementObjectSearcher("Select * From Win32_OperatingSystem");
            foreach (ManagementObject mo in searcherd.Get())
            {
                Dd += mo["Caption"].ToString().Trim() + "; " + mo["BuildNumber"].ToString() + "; ";
                Dd2 += mo["Description"].ToString().Trim();
            }
            searcherd.Dispose();
            if (语言选择框.SelectedIndex == 1)
            {
                label19.Text = Dd + API.系统_64位();
                label28.Text = "Device: " + Environment.MachineName;
                label18.Text = "User: " + Environment.UserName;//获取当前用户
                label20.Text = "Lag: " + System.Globalization.CultureInfo.InstalledUICulture.Name;
                label85.Text = "Lag: ";
                textBox1.Text = "VGA:" + API.系统_取桌面分辨率() + ";      " + "Current:" + Screen.PrimaryScreen.Bounds.Width + " * " + Screen.PrimaryScreen.Bounds.Height + ";      ";
            }
            else
            {
                label19.Text = Dd + API.系统_64位() + " 位";
                label28.Text = "设备名: " + Environment.MachineName;
                label18.Text = "用户名: " + Environment.UserName;//获取当前用户

                if (System.Globalization.CultureInfo.InstalledUICulture.Name.ToLower()== "zh-cn")
                {
                    label20.Text = "系统语言: 中文" ;
                }
                else
                {
                    label20.Text = "系统语言: " + System.Globalization.CultureInfo.InstalledUICulture.Name;
                }
               
                label85.Text = "语言: ";
                textBox1.Text = "屏幕分辨率:" + API.系统_取桌面分辨率() + ";      " + "当前分辨率:" + Screen.PrimaryScreen.Bounds.Width + " * " + Screen.PrimaryScreen.Bounds.Height + ";      ";
            }
        }
        private void CPUZHANYONG()
        {
            //内存
            double capacity = 0; string D = null; string D2 = null; string D4 = null; string D5 = null; string D1 = null; string D3 = null; string D6 = null;
            try
            {
                ManagementObjectSearcher searcherd5 = new ManagementObjectSearcher("Select * From Win32_PhysicalMemory");
                foreach (ManagementObject mo in searcherd5.Get())
                {
                    try
                    {
                        capacity += Math.Round(Int64.Parse(mo.Properties["Capacity"].Value.ToString().Trim()) / 1024 / 1024 / 1024.0, 1);
                    }
                    catch (Exception)
                    {

                        capacity = 0;
                    }
                   // D += mo["manufacturer"].ToString().Trim() + " (" + Math.Round(Int64.Parse(mo.Properties["Capacity"].Value.ToString()) / 1024 / 1024 / 1024.0, 1).ToString() + "G)" + " (" + mo["Speed"].ToString() + "MHz) " + "; ";
                    D +=  Math.Round(Int64.Parse(mo.Properties["Capacity"].Value.ToString()) / 1024 / 1024 / 1024.0, 1).ToString() + "G" + " (" + mo["Speed"].ToString() + "MHz) " + "; ";
                    D1 += mo["manufacturer"].ToString().Trim() + "; ";
                    D2 += mo["Speed"].ToString().Trim() + "MHz; ";
                    D3 += Math.Round(Int64.Parse(mo.Properties["Capacity"].Value.ToString().Trim()) / 1024 / 1024 / 1024.0, 1).ToString() + "G; ";
                    D4 += mo["SerialNumber"].ToString().Trim() + "; ";
                    D5 += mo["DataWidth"].ToString().Trim() + "; ";
                    D6 += mo["DeviceLocator"].ToString().Trim() + "; ";
                }
                searcherd5.Dispose();
            }
            catch
            {
                if (语言选择框.SelectedIndex == 0)
                {
                    label2.Text = "未取到内存";
                }
                else if (语言选择框.SelectedIndex == 1)
                {
                    label2.Text = "No data obtained";
                }
                else
                {
                    label2.Text = "未取到内存";
                }
            }
            if (语言选择框.SelectedIndex == 1)
            {
                if (capacity != 0)
                {
                    textBox3.Text = D + capacity + "G; ";
                }
                else textBox3.Text = D;

                label59.Text = "MFR:             " + D1;
                label58.Text = "Speed:           " + D2;
                label57.Text = "Capacity:        " + D3;
                label54.Text = "Capacity:        " + capacity + "G; ";
                label55.Text = "S/N:               " + D4;
                label53.Text = "DataWidth:     " + D5;
                label50.Text = "Device:           " + D6;

            }
            else
            {
                try
                {
                    string systemboard = D1.ToUpper();
                    if (systemboard.IndexOf("GALAXY MICROSYSTEMS LTD") != -1)
                    {
                        label59.Text = "内存厂商:     " + systemboard.Replace("GALAXY MICROSYSTEMS LTD", "影驰");
                    }
                    else if (systemboard.IndexOf("SAMSUNG") != -1)
                    {
                        label59.Text = "内存厂商:     " + systemboard.Replace("SAMSUNG", "三星");
                    }
                    else if (systemboard.IndexOf("04CB") != -1)
                    {
                        label59.Text = "内存厂商:     " + systemboard.Replace("04CB", "威刚");
                    }
                    else label59.Text = "内存厂商:     " + D1;
                }
                catch (Exception)
                {
                    label59.Text = "内存厂商:     " + D1;
                }

                if (capacity != 0)
                {
                    textBox3.Text = D + "共" + capacity + "G; ";
                }
                else textBox3.Text = D;
                label58.Text = "内存频率:     " + D2;
                label57.Text = "内存容量:     " + D3;
                label54.Text = "内存总量:     " + capacity + "G; ";
                label55.Text = "序列号:        " + D4;
                label53.Text = "数据宽度:     " + D5;
                label50.Text = "控制器:        " + D6;
            }


            //主板
            string b = null; string b2 = null; string b4 = null;
            string b1 = null; string b3 = null; string b5 = null;
            try
            {
                ManagementObjectSearcher searcherd2 = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
                foreach (ManagementObject mo in searcherd2.Get())
                {
                    b += mo["Product"].ToString().Trim() + "; ";
                    b1 += mo["Manufacturer"].ToString().Trim() + "; ";
                    b2 += mo["SerialNumber"].ToString().Trim() + "; ";
                    b3 += mo["CreationClassName"].ToString().Trim() + "; ";
                    b4 += mo["HotSwappable"].ToString().Trim() + "; ";
                    b5 += mo["Status"].ToString().Trim() + "; ";
                }
                searcherd2.Dispose();
            }
            catch
            {
                if (语言选择框.SelectedIndex == 0)
                {
                    label2.Text = "未取到主板";
                }
                else if (语言选择框.SelectedIndex == 1)
                {
                    label2.Text = "No data obtained";
                } else
                {
                    label2.Text = "未取到主板";
                }
            }

            if (语言选择框.SelectedIndex == 1)
            {
                textBox4.Text = b;
                label65.Text = "MFR:                  " + b1;
                label64.Text = "Product:             " + b;
                label63.Text = "SerialNumber:    " + b2;
                label61.Text = "ClassName:        " + b3;
                label48.Text = "HotSwappable:   " + b4;
                label33.Text = "Status:               " + b5;
            }
            else
            {
                string systemboard = b1.ToUpper();
                if (systemboard.IndexOf("MICRO-STAR") != -1)
                    textBox4.Text = "微星 " + b;
                else if (systemboard.IndexOf("GALAX") != -1)
                    textBox4.Text = "影驰 " + b;
                else if (systemboard.IndexOf("LENOVO") != -1)
                    textBox4.Text = "联想 " + b;
                else if (systemboard.IndexOf("ASUS") != -1 || systemboard.IndexOf("ROG") != -1)
                    textBox4.Text = "华硕 " + b;
                else if (systemboard.IndexOf("ASROCK") != -1)
                    textBox4.Text = "华擎 " + b;
                else if (systemboard.IndexOf("GIGABYTE") != -1)
                    textBox4.Text = "技嘉 " + b;
                else if (systemboard.IndexOf("SAPPHIRE") != -1)
                    textBox4.Text = "蓝宝石 " + b;
                else if (systemboard.IndexOf("ACER") != -1)
                    textBox4.Text = "宏碁 " + b;
                else if (systemboard.IndexOf("COLORFUL") != -1)
                    textBox4.Text = "七彩虹 " + b;
                else if (systemboard.IndexOf("DELL") != -1)
                    textBox4.Text = "戴尔 " + b;
                else if (systemboard.IndexOf("ONDA") != -1)
                    textBox4.Text = "昂达 " + b;
                else if (systemboard.IndexOf("BIOSTAR") != -1)
                    textBox4.Text = "映泰 " + b;
                else if (systemboard.IndexOf("MAXSUN") != -1)
                    textBox4.Text = "铭瑄 " + b;
                else if (systemboard.IndexOf("SOYO") != -1)
                    textBox4.Text = "梅捷 " + b;
                else if (systemboard.IndexOf("TOPSTAR") != -1)
                    textBox4.Text = "顶星 " + b;
                else if (systemboard.IndexOf("CLEVO") != -1)
                    textBox4.Text = "蓝天 " + b;
                else if (systemboard.IndexOf("Quanta") != -1)
                    textBox4.Text = "广达 " + b;
                else if (systemboard.IndexOf("HASEE") != -1)
                    textBox4.Text = "磐英 " + b;
                else if (systemboard.IndexOf("HUANAN") != -1)
                    textBox4.Text = "华南 " + b;
                else if (systemboard.IndexOf("HP") != -1)
                    textBox4.Text = "惠普 " + b;
                else textBox4.Text = b;
                label65.Text = "主板厂家:     " + b1;
                label64.Text = "主板型号:     " + b;
                label63.Text = "主板序列:     " + b2;
                label61.Text = "主板类名:     " + b3;
                label48.Text = "热插拔:        " + b4;
                label33.Text = "主板状态:     " + b5;
            }
        }
        private void chushihua()
        {
            string a = null; string a2 = null; string a4 = null; string a5 = null; string a1 = null; string a3 = null;
            //string a8 = null; string a6 = null; string a7 = null; string a9 = null; string a10 = null;
            try
            {
                ManagementObjectSearcher searcherd1 = new ManagementObjectSearcher("Select * From Win32_Processor");
                foreach (ManagementObject mo in searcherd1.Get())
                {
                    a += mo["Name"].ToString().Trim() + "; ";
                    a1 += mo["NumberOfCores"].ToString().Trim();
                    a2 += mo["NumberOfLogicalProcessors"].ToString().Trim();
                    a3 += mo["CurrentClockSpeed"].ToString().Trim();
                    a4 += mo["DataWidth"].ToString().Trim() + "; ";
                    a5 += mo["ProcessorId"].ToString().Trim() + "; ";
                }
                searcherd1.Dispose();
                textBox2.Text = a;
                if (语言选择框.SelectedIndex == 0)
                {
                    label43.Text = "处理器:     " + textBox2.Text;
                    label42.Text = "核心:        " + a1 + "核心; ";
                    label41.Text = "线程:        " + a2 + "线程; ";
                    label38.Text = "主频:        " + a3.Substring(0, 1) + "." + a3.Substring(1, 2) + "Ghz; ";
                    label35.Text = "架构:           " + a4;
                    label40.Text = "CPUID:     " + a5;
                    label2.Text = "复制此页";
                }
                else if (语言选择框.SelectedIndex == 1)
                {
                    label43.Text = "CPU:              " + textBox2.Text;
                    label42.Text = "Core:              " + a1 + "C; ";
                    label41.Text = "Thread:          " + a2 + "T; ";
                    label38.Text = "Core Speed:   " + a3.Substring(0, 1) + "." + a3.Substring(1, 2) + "Ghz; ";
                    label35.Text = "Package:           " + a4;
                    label40.Text = "CPUID:           " + a5;
                    label2.Text = "Copy";
                }
                else
                {
                    label43.Text = "处理器:     " + textBox2.Text;
                    label42.Text = "核心:        " + a1 + "核心; ";
                    label41.Text = "线程:        " + a2 + "线程; ";
                    label38.Text = "主频:        " + a3.Substring(0, 1) + "." + a3.Substring(1, 2) + "Ghz; ";
                    label35.Text = "架构:           " + a4;
                    label40.Text = "CPUID:     " + a5;
                    label2.Text = "复制此页";
                }
            }
            catch
            {
                if (语言选择框.SelectedIndex == 0)
                {
                    label2.Text = "未取到CPU";
                }
                else if (语言选择框.SelectedIndex == 1)
                {
                    label2.Text = "CPU not fetched";
                }
                else
                {
                    label2.Text = "未取到CPU";
                }
            }
        }
        private void chushihua1()
        {
            string a8 = null; string a6 = null; string a7 = null; string a9 = null; string a10 = null;
            try
            {
                ManagementObjectSearcher searcherd1 = new ManagementObjectSearcher("Select * From Win32_Processor");
                foreach (ManagementObject mo in searcherd1.Get())
                {
                    a6 += mo["Caption"].ToString().Trim() + "; ";
                    a7 += mo["VirtualizationFirmwareEnabled"].ToString().Trim() + "; ";
                    a8 += mo["Manufacturer"].ToString().Trim() + "; ";
                    a9 += mo["L2CacheSize"].ToString().Trim() + "; ";
                    a10 += mo["L3CacheSize"].ToString().Trim() + "; ";
                }
                searcherd1.Dispose();
                if (语言选择框.SelectedIndex == 1)
                {
                    label39.Text = "Describe:        " + a6;
                    label37.Text = "VT-X:             " + a7;
                    label44.Text = "MFG:             " + a8;
                    label46.Text = "L2:                 " + a9;
                    label47.Text = "L3:                 " + a10;
                }
                else
                {
                    if (a8.IndexOf("GenuineIntel") != -1)
                        label44.Text = "制造商:      " + a8.Replace("GenuineIntel", "英特尔");
                    else if (a8.IndexOf("AuthenticAMD") != -1)
                        label44.Text = "制造商:      " + a8.Replace("AuthenticAMD", "AMD");
                    else label44.Text = "制造商:      " + a8;
                    label39.Text = "描述:         " + a6;
                    label37.Text = "虚拟化:      " + a7;
                    label46.Text = "L2:            " + a9;
                    label47.Text = "L3:            " + a10;
                }
            }
            catch
            {
                label39.Text = null;
                label37.Text = null;
                label44.Text = null;
                label46.Text = null;
                label47.Text = null;
            }
        }
        void textBox1_GotFocus(object sender, EventArgs e)
        {
            API.HideCaret((sender as TextBox).Handle);
        }
        void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            API.HideCaret((sender as TextBox).Handle);
        }
        Size datubiao = new Size(64, 64);
        Size zhongtubiao = new Size(48, 48);
        Size xiaotubiao = new Size(32, 32);
        const string number = "8.0";
        string severnumber = API.网页_访问("");//输入您的服务器版本号
        private void Form1_Load(object sender, EventArgs e)//程序被创建
        {
            if (Directory.Exists("tool") == true)
            {
                配置初始化();
                LanguageLnitialization();
            }
            timer1.Start();
            版本号();
            if (File.Exists("bin\\SystemTb.dll") == true)
            {
                Thread t3 = new Thread(图吧);
                t3.Start();
            }
            else label94.Visible = false;
            Thread t1 = new Thread(chushihua);
            t1.Start();
            Thread t2 = new Thread(chushihua1);
            t2.Start();
            CPUZHANYONG();
            GPUchushihua();
            if (checkBox2.Checked == true)
            {
                panel12.Visible = true;
            }

            k_hook.KeyDownEvent += new KeyEventHandler(inthook);//添加键盘事件
            k_hook.Start();//安装键盘钩子
            初始化();
            滑块条1_位置(sender, e);
            透明度_Scroll(sender, e);
            panel4.Visible = true;
            if (Directory.Exists("tool") == true)
            {
                初始化全部();
                Thread t = new Thread(选择夹初始化);
                t.Start();
                声卡检测初始化();

            }
        }

        private void 图吧()
        {
            string aa = API.Hwinfo(AppDomain.CurrentDomain.BaseDirectory + "\\bin\\hwinfo.ini", AppDomain.CurrentDomain.BaseDirectory + "\\bin");
            try
            {
                textBox14.Text = null;

                if (语言选择框.SelectedIndex == 1)
                {
                    aa = API.文本_替换字符串(aa, "处理器", "CPU");
                    aa = API.文本_替换字符串(aa, "主板", "Mobo");
                    aa = API.文本_替换字符串(aa, "内存", "Memory");
                    aa = API.文本_替换字符串(aa, "显卡", "GPU");
                    aa = API.文本_替换字符串(aa, "显示器", "LCD");
                    aa = API.文本_替换字符串(aa, "硬盘", "HDD");
                    aa = API.文本_替换字符串(aa, "声卡", "Audio");
                    aa = API.文本_替换字符串(aa, "网卡", "NIC");
                    aa = API.文本_替换字符串(aa, "英寸", "Inch");
                    aa = API.文本_替换字符串(aa, "未知", "Unknown");
                }
                textBox14.Text = aa;
                if (File.Exists(API.默认我的文档() + "\\bin\\hwinfo.ini") == true)
                {
                    StreamReader streamReader = new StreamReader(API.默认我的文档() + "\\bin\\hwinfo.ini", Encoding.GetEncoding("GB2312"));
                    textBox15.Text = streamReader.ReadToEnd();
                }
                else label93.Visible = false;
            }
            catch
            {
                textBox14.Text = aa;
                label94.Visible = false;
            }


        }
        private void 声卡检测初始化()
        {
            label86.Visible = false;
            label87.Visible = false;
            label88.Visible = false;
            textBox13.Location = new Point(190, 65);
            label82.Location = new Point(102, 65);
            textBox13.Size = new Size(562, 403);

        }
        private void 初始化()
        {
            label29.Text = "V" + number;
            if (语言选择框.SelectedIndex == 0)
            {
                当前版本.Text = "当前版本V" + number;
            }
            else if (语言选择框.SelectedIndex == 1)
            {
                当前版本.Text = "Current V" + number;
            }
            else
            {
                当前版本.Text = "当前版本V" + number;
            }
            JieShao.Text = null;
            label81.Text = null;
            label83.Text = null;
            JieShao.Location = new Point(panel4.Location.X + 15, pictureBox14.Location.Y);
            try
            {
                if (语言选择框.SelectedIndex == 0)
                {
                    label80.Text = API.网页_访问("");//输入服务器公告
                    label80.Visible = true;
                }
                else label80.Visible = false;
            }
            catch
            {
                label80.Visible = false;
            }
         
            if (API.网页_是否联网() == true)
            {
                if (severnumber != number)
                {
                    Console.WriteLine(severnumber+" / " +number);
                    if (Directory.Exists("tool") == false)
                    {
                        label83.Location = label81.Location;
                        if (语言选择框.SelectedIndex == 0)
                        {
                            label83.Text = "点此下载软件完整版";
                            最新版本.Text = "最新版本V" + severnumber;
                        }
                        else if (语言选择框.SelectedIndex == 1)
                        {
                            最新版本.Text = "Latest V" + severnumber;
                            label83.Text = "Latest version";
                        }
                        else
                        {
                            label83.Text = "点此下载软件完整版";
                            最新版本.Text = "最新版本V" + severnumber;
                        }
                        label85.Visible=false;
                        语言选择框.Visible = false;

                    }
                    else
                    {
                        if (severnumber !=null )
                        {
                            if (语言选择框.SelectedIndex == 0)
                            {
                                label81.Text = "检测到新版本可更新";
                            }
                            if (语言选择框.SelectedIndex == 1)
                            {
                                label81.Text = "Latest version";
                            }
                            else label81.Text = "检测到新版本可更新";
                        }
                    }
                }
                if (severnumber == null)
                {
                    if (语言选择框.SelectedIndex == 1)
                    {
                        最新版本.Text = "Unable to link server";
                    }
                    else
                    {
                        最新版本.Text = "无法链接服务器";
                    }
                }
                else
                {
                    if (语言选择框.SelectedIndex == 1)
                    {
                        最新版本.Text = "Latest V" + severnumber;
                    }
                    else
                    {
                        最新版本.Text = "最新版本V" + severnumber;
                    }
                }
                try
                {
                    if (Environment.OSVersion.Version.Major >= 6) //Version 6 can be Windows Vista, Windows Server 2008, or Windows 7
                    {
                        if (API.IsGenuineWindows())
                        {
                            if (语言选择框.SelectedIndex == 1)
                            {
                                系统状态.Text = "Activated";

                            }
                            else
                            {
                                系统状态.Text = "系统状态: 已激活";

                            }
                        }
                        else
                        {
                            if (语言选择框.SelectedIndex == 1)
                            {
                                系统状态.Text = "Not Active";

                            }
                            else
                            {
                                系统状态.Text = "系统状态: 未激活";
                            }

                        }
                        
                    }
                    else
                    {
                        if (语言选择框.SelectedIndex == 1)
                        {
                            系统状态.Text = "Not Support";
                        }
                        else
                        {
                            系统状态.Text = "系统状态: 不支持";
                        }
                        if (语言选择框.SelectedIndex == 1)
                        {
                            最新版本.Text = "Unable to link server";
                        }
                        else
                        {
                            最新版本.Text = "无法链接服务器";
                        }
                    }
                }
                catch
                {
                    系统状态.Visible = false;
                }
            }
            else
            {
                if (语言选择框.SelectedIndex == 1)
                {
                    系统状态.Text = "Not networked";
                    最新版本.Text = "Unable to link server";
                }
                else
                {
                    系统状态.Text = "系统状态: 未联网";
                    最新版本.Text = "无法链接服务器";
                }
            }
           

        }
        private void 选择夹初始化()
        {
            textBox1.GotFocus += textBox1_GotFocus;
            textBox1.MouseDown += textBox1_MouseDown;
            textBox2.GotFocus += textBox1_GotFocus;
            textBox2.MouseDown += textBox1_MouseDown;
            textBox3.GotFocus += textBox1_GotFocus;
            textBox3.MouseDown += textBox1_MouseDown;
            textBox4.GotFocus += textBox1_GotFocus;
            textBox4.MouseDown += textBox1_MouseDown;
            textBox5.GotFocus += textBox1_GotFocus;
            textBox5.MouseDown += textBox1_MouseDown;
            textBox6.GotFocus += textBox1_GotFocus;
            textBox6.MouseDown += textBox1_MouseDown;
            textBox7.GotFocus += textBox1_GotFocus;
            textBox7.GotFocus += textBox1_GotFocus;
            textBox8.GotFocus += textBox1_GotFocus;
            textBox8.MouseDown += textBox1_MouseDown;
            textBox9.GotFocus += textBox1_GotFocus;
            textBox9.MouseDown += textBox1_MouseDown;
            textBox10.GotFocus += textBox1_GotFocus;
            textBox10.MouseDown += textBox1_MouseDown;
            textBox11.GotFocus += textBox1_GotFocus;
            textBox11.MouseDown += textBox1_MouseDown;
            textBox12.GotFocus += textBox1_GotFocus;
            textBox12.MouseDown += textBox1_MouseDown;
            textBox13.GotFocus += textBox1_GotFocus;
            textBox13.MouseDown += textBox1_MouseDown;
            textBox14.GotFocus += textBox1_GotFocus;
            textBox14.MouseDown += textBox1_MouseDown;
            textBox15.GotFocus += textBox1_GotFocus;
            textBox15.MouseDown += textBox1_MouseDown;
            try
            {
                选择夹1初始化();
                选择夹2初始化();
                选择夹3初始化();
                选择夹4初始化();
                选择夹5初始化();
                选择夹6初始化();
                选择夹7初始化();
                选择夹8初始化();
                选择夹9初始化();
                选择夹10初始化();
                选择夹11初始化();
            }
            catch
            {
                初始化退出();
            }

        }
        private void 滑块()
        {
            JieShao.Text = null;
            listView1.Visible = false;
            listView2.Visible = false;
            listView3.Visible = false;
            listView4.Visible = false;
            listView5.Visible = false;
            listView6.Visible = false;
            listView7.Visible = false;
            listView8.Visible = false;
            listView9.Visible = false;
            listView10.Visible = false;
            listView11.Visible = false;
            panel3.Visible = false;
            panel14.Visible = false;
            panel4.Visible = false;
            label5.BackColor = 前景;
            pictureBox1.BackColor = 前景;
            label6.BackColor = 前景;
            pictureBox2.BackColor = 前景;
            label7.BackColor = 前景;
            pictureBox4.BackColor = 前景;
            label8.BackColor = 前景;
            pictureBox3.BackColor = 前景;
            label9.BackColor = 前景;
            pictureBox8.BackColor = 前景;
            label10.BackColor = 前景;
            pictureBox7.BackColor = 前景;
            label11.BackColor = 前景;
            pictureBox6.BackColor = 前景;
            label12.BackColor = 前景;
            pictureBox5.BackColor = 前景;
            label13.BackColor = 前景;
            pictureBox12.BackColor = 前景;
            label14.BackColor = 前景;
            pictureBox11.BackColor = 前景;
            label15.BackColor = 前景;
            pictureBox10.BackColor = 前景;
            label4.BackColor = 前景;
            pictureBox9.BackColor = 前景;
            label27.BackColor = 前景;
            pictureBox14.BackColor = 前景;
            label104.BackColor = 前景;
            pictureBox16.BackColor = 前景;
        }
        private void label2_Click(object sender, EventArgs e)
        {
            if (label2.Text != "......")
            {
                string txt = label23.Text + "     " + textBox2.Text + "\r\n" + label24.Text + "        " + textBox3.Text + "\r\n" + label25.Text + "        " + textBox4.Text + "\r\n" + label26.Text + "        " + textBox5.Text + "\r\n" + label30.Text + "        " + textBox8.Text + "\r\n" + label32.Text + "        " + textBox7.Text + "\r\n" + label31.Text + "        " + textBox6.Text;
                Clipboard.SetDataObject(txt);
                if (语言选择框.SelectedIndex == 0)
                {
                    label2.Text = "已复制";
                    程序_延时(1000);
                    label2.Text = "复制此页";
                }
                else if (语言选择框.SelectedIndex == 1)
                {
                    label2.Text = "Copied";
                    程序_延时(1000);
                    label2.Text = "Copy";
                }
                else
                {
                    label2.Text = "已复制";
                    程序_延时(1000);
                    label2.Text = "复制此页";
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("mmsys.cpl");//打开音频设置
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("control.exe");//控制面板
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("main.cpl");//鼠标属性
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("desk.cpl");//设置显示
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start("APPWIZ.cpl");//卸载
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Process.Start("tencent://Message/?Uin=59765729&websiteName=www.oicqzone.com&Menu=yes");
        }


        自定义列表 zhuce;
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (zhuce == null || zhuce.IsDisposed)
            {
                zhuce = new 自定义列表();
                zhuce.Show(this);
                //zhuce.skinButton1_Click(sender, e);
            }
            else
            {
                if (zhuce.Visible == false)
                {
                    //zhuce.skinButton1_Click(sender, e);
                    zhuce.Visible = true;

                }
                else
                {
                    zhuce.Visible = false;

                }
            }
        }
        private void button7_Click(object sender, EventArgs e)//任务管理器
        {
            Process.Start(@"C:\WINDOWS\system32\taskmgr.exe");
        }
        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            textBox2.Cursor = Cursors.Hand; ;
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            textBox2.Cursor = Cursors.Default;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {

        }
        private void label45_Click_1(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }

        private void label51_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
        }
        private void textBox3_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Cursor = Cursors.Hand; ;
        }

        private void textBox3_MouseLeave(object sender, EventArgs e)
        {
            textBox3.Cursor = Cursors.Default;
        }
        private void textBox3_Click(object sender, EventArgs e)
        {

        }
        private void textBox4_MouseEnter(object sender, EventArgs e)
        {
            textBox4.Cursor = Cursors.Hand; ;
        }

        private void textBox4_MouseLeave(object sender, EventArgs e)
        {
            textBox4.Cursor = Cursors.Default;
        }
        private void textBox4_Click(object sender, EventArgs e)
        {

        }

        private void label49_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
        }
        private void textBox5_MouseEnter(object sender, EventArgs e)
        {
            textBox5.Cursor = Cursors.Hand; ;
        }

        private void textBox5_MouseLeave(object sender, EventArgs e)
        {
            textBox5.Cursor = Cursors.Default;
        }
        private void textBox5_Click(object sender, EventArgs e)
        {

        }

        private void label60_Click(object sender, EventArgs e)
        {
            panel8.Visible = false;
        }
        private void textBox8_MouseEnter(object sender, EventArgs e)
        {
            textBox8.Cursor = Cursors.Hand; ;
        }

        private void textBox8_MouseLeave(object sender, EventArgs e)
        {
            textBox8.Cursor = Cursors.Default;
        }
        private void textBox8_Click(object sender, EventArgs e)
        {

        }

        private void label56_Click(object sender, EventArgs e)
        {
            panel9.Visible = false;
        }

        private void label77_Click(object sender, EventArgs e)
        {
            panel10.Visible = false;
        }
        private void textBox7_MouseEnter(object sender, EventArgs e)
        {
            textBox7.Cursor = Cursors.Hand; ;
        }

        private void textBox7_MouseLeave(object sender, EventArgs e)
        {
            textBox7.Cursor = Cursors.Default;
        }
        private void textBox7_Click(object sender, EventArgs e)
        {

        }

        private void label76_Click(object sender, EventArgs e)
        {
            panel11.Visible = false;
        }
        private void textBox6_MouseEnter(object sender, EventArgs e)
        {
            textBox6.Cursor = Cursors.Hand; ;
        }

        private void textBox6_MouseLeave(object sender, EventArgs e)
        {
            textBox6.Cursor = Cursors.Default;
        }
        private void textBox6_Click(object sender, EventArgs e)
        {

        }

        private void label45_MouseEnter(object sender, EventArgs e)
        {
            label45.ForeColor = Color.Blue;
        }

        private void label45_MouseLeave(object sender, EventArgs e)
        {
            label45.ForeColor = Color.Black;
        }
        private void label49_MouseEnter(object sender, EventArgs e)
        {
            label49.ForeColor = Color.Blue;
        }

        private void label49_MouseLeave(object sender, EventArgs e)
        {
            label49.ForeColor = Color.Black;
        }
        private void label56_MouseEnter(object sender, EventArgs e)
        {
            label56.ForeColor = Color.Blue;
        }

        private void label56_MouseLeave(object sender, EventArgs e)
        {
            label56.ForeColor = Color.Black;
        }
        private void label77_MouseEnter(object sender, EventArgs e)
        {
            label77.ForeColor = Color.Blue;
        }

        private void label77_MouseLeave(object sender, EventArgs e)
        {
            label77.ForeColor = Color.Black;
        }
        private void label76_MouseEnter(object sender, EventArgs e)
        {
            label76.ForeColor = Color.Blue;
        }

        private void label76_MouseLeave(object sender, EventArgs e)
        {
            label76.ForeColor = Color.Black;
        }
        private void label51_MouseEnter(object sender, EventArgs e)
        {
            label51.ForeColor = Color.Blue;
        }

        private void label51_MouseLeave(object sender, EventArgs e)
        {
            label51.ForeColor = Color.Black;
        }
        private void label60_MouseEnter(object sender, EventArgs e)
        {
            label60.ForeColor = Color.Blue;
        }

        private void label60_MouseLeave(object sender, EventArgs e)
        {
            label60.ForeColor = Color.Black;
        }
        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Blue;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }
        private void label103_MouseEnter(object sender, EventArgs e)
        {
            label103.ForeColor = Color.Blue;
        }

        private void labe103_MouseLeave(object sender, EventArgs e)
        {
            label103.ForeColor = Color.Black;
        }
        private void label93_MouseEnter(object sender, EventArgs e)
        {
            label93.ForeColor = Color.Blue;
        }

        private void label93_MouseLeave(object sender, EventArgs e)
        {
            label93.ForeColor = Color.Black;
        }
        private void label94_MouseEnter(object sender, EventArgs e)
        {
            label94.ForeColor = Color.Blue;
        }
        private void label94_MouseLeave(object sender, EventArgs e)
        {
            label94.ForeColor = Color.Black;
        }
        private void label95_MouseEnter(object sender, EventArgs e)
        {
            label95.ForeColor = Color.Blue;
        }

        private void label95_MouseLeave(object sender, EventArgs e)
        {
            label95.ForeColor = Color.Black;
        }
        private void label21_MouseEnter(object sender, EventArgs e)
        {
            label21.ForeColor = Color.Blue;
        }

        private void label21_MouseLeave(object sender, EventArgs e)
        {
            label21.ForeColor = Color.Black;
        }
        private void label17_MouseEnter(object sender, EventArgs e)
        {
            label17.ForeColor = Color.Blue;
        }

        private void label17_MouseLeave(object sender, EventArgs e)
        {
            label17.ForeColor = Color.Black;
        }
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Blue;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }
        private void labe34_MouseEnter(object sender, EventArgs e)
        {
            label34.ForeColor = Color.Blue;
        }
        private void label34_MouseLeave(object sender, EventArgs e)
        {
            label34.ForeColor = Color.Black;
        }

        private void label79_Click(object sender, EventArgs e)
        {
            Process.Start("http://space.bilibili.com/386420067");
        }

        private void label21_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.bianshengruanjian.com");
        }

        private void label34_Click(object sender, EventArgs e)//更新
        {
            if (API.网页_是否联网() == true)
            {
                if (severnumber == "")
                {
                    if (语言选择框.SelectedIndex == 0)
                    {
                        API.信息框("无法链接服务器......", "信息:", 5000);
                    }
                    else
                    {
                        API.信息框("Unable to link server......", "Tips:", 5000);
                    }
                }
                else
                {
                    if (severnumber != number)
                    {
                        if (语言选择框.SelectedIndex == 0)
                        {
                            if (MessageBox.Show("检测到新版本,是否更新?", "信息:", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                if (File.Exists("update.exe") == false)
                                {
                                    API.信息框("update.exe不存在,请在官网下载更新!", "信息:", 5000);
                                    Process.Start("http://www.bianshengruanjian.com");
                                }
                                else
                                {
                                    if (notifyIcon1.Visible == true)
                                    {
                                        notifyIcon1.Visible = false;
                                    }
                                    ProcessStartInfo psi = new ProcessStartInfo();
                                    psi.FileName = "update.exe";
                                    psi.UseShellExecute = false;
                                    psi.CreateNoWindow = true;
                                    Process.Start(psi);
                                    程序_延时(10);
                                    Environment.Exit(0);
                                }
                            }
                        }
                        else
                        {
                            if (MessageBox.Show("New version detected, update?", "Tips:", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                if (File.Exists("update.exe") == false)
                                {
                                    API.信息框("update.exe , Does not exist, please download the update on the official website!", "信息:", 5000);
                                    Process.Start("http://www.bianshengruanjian.com");
                                }
                                else
                                {
                                    if (notifyIcon1.Visible == true)
                                    {
                                        notifyIcon1.Visible = false;
                                    }
                                    ProcessStartInfo psi = new ProcessStartInfo();
                                    psi.FileName = "update.exe";
                                    psi.UseShellExecute = false;
                                    psi.CreateNoWindow = true;
                                    Process.Start(psi);
                                    程序_延时(10);
                                    Environment.Exit(0);
                                }
                            }
                        }

                    }
                    else
                    {
                        if (语言选择框.SelectedIndex == 0)
                        {
                            API.信息框("已经是最新版本!", "信息:", 5000);
                        }
                        else
                        {
                            API.信息框("It is already the latest version!", "Tips:", 5000);
                        }

                    }
                }
            }
            else
            {
                if (语言选择框.SelectedIndex == 0)
                {
                    API.信息框("无网络连接!", "信息:", 5000);
                }
                else
                {
                    API.信息框("No network connection", "Tips:", 5000);
                }
               
            }
             

        }

        private void label79_MouseEnter(object sender, EventArgs e)
        {
            label79.ForeColor = Color.Blue;
        }

        private void label79_MouseLeave(object sender, EventArgs e)
        {
            label79.ForeColor = Color.Black;
        }

        private void textBox2_DoubleClick(object sender, EventArgs e)
        {
            panel5.Location = new Point(panel4.Location.X + pictureBox14.Width, panel4.Location.Y);
            panel5.Size = new Size(panel4.Size.Width - 2, panel4.Size.Height);
            panel5.Visible = true;
        }

        private void textBox3_DoubleClick(object sender, EventArgs e)
        {
            panel6.Location = new Point(panel4.Location.X + pictureBox14.Width, panel4.Location.Y);
            panel6.Size = new Size(panel4.Size.Width - 2, panel4.Size.Height);
            panel6.Visible = true;
        }

        private void textBox4_DoubleClick(object sender, EventArgs e)
        {
            panel7.Location = new Point(panel4.Location.X + pictureBox14.Width, panel4.Location.Y);
            panel7.Size = new Size(panel4.Size.Width - 2, panel4.Size.Height);
            panel7.Visible = true;
        }

        private void textBox5_DoubleClick(object sender, EventArgs e)
        {
            panel8.Location = new Point(panel4.Location.X + pictureBox14.Width, panel4.Location.Y);
            panel8.Size = new Size(panel4.Size.Width - 2, panel4.Size.Height);
            panel8.Visible = true;
        }

        private void textBox8_DoubleClick(object sender, EventArgs e)
        {
            panel9.Location = new Point(panel4.Location.X + pictureBox14.Width, panel4.Location.Y);
            panel9.Size = new Size(panel4.Size.Width - 2, panel4.Size.Height);
            panel9.Visible = true;
        }

        private void textBox7_DoubleClick(object sender, EventArgs e)
        {
            panel10.Location = new Point(panel4.Location.X + pictureBox14.Width, panel4.Location.Y);
            panel10.Size = new Size(panel4.Size.Width - 2, panel4.Size.Height);
            panel10.Visible = true;
            声卡检测初始化();
        }

        private void textBox6_DoubleClick(object sender, EventArgs e)
        {
            panel11.Location = new Point(panel4.Location.X + pictureBox14.Width, panel4.Location.Y);
            panel11.Size = new Size(panel4.Size.Width - 2, panel4.Size.Height);
            panel11.Visible = true;

        }
        bool zhen2 = true;
        private void button8_Click(object sender, EventArgs e)
        {
            if (zhen2 == true)
            {
                zhen2 = false;
                if (语言选择框.SelectedIndex == 0)
                {
                    button8.Text = "静音开启";
                }
                else if (语言选择框.SelectedIndex == 1)
                {
                    button8.Text = "Mute on";
                }
                else button8.Text = "静音开启";
                try
                {
                    API.音频_系统静音(true);
                }
                catch
                {
                    if (语言选择框.SelectedIndex == 0)
                    {
                        button8.Text = "全局静音";
                    }
                    else if (语言选择框.SelectedIndex == 1)
                    {
                        button8.Text = "Mute";
                    }
                    else button8.Text = "全局静音";
                    zhen2 = true;
                }
                
            }
            else
            {
                if (语言选择框.SelectedIndex == 0)
                {
                    button8.Text = "全局静音";
                }
                else if (语言选择框.SelectedIndex == 1)
                {
                    button8.Text = "Mute";
                }
                else button8.Text = "全局静音";
                zhen2 = true;
                try
                {
                    API.音频_系统静音(false);
                }
                catch
                {
                    if (语言选择框.SelectedIndex == 0)
                    {
                        button8.Text = "全局静音";
                    }
                    else if (语言选择框.SelectedIndex == 1)
                    {
                        button8.Text = "Mute";
                    }
                    else button8.Text = "全局静音";
                    zhen2 = true;
                }
               
            }
        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)//CPU
        {
            string file = listView1.Items[listView1.SelectedItems[0].Index].Name;
            if (语言选择框.SelectedIndex == 0)
            {
                if (file.IndexOf("CPU天梯图") != -1)
                {
                    JieShao.Text = "CPU天梯图(2022年5月更新)";
                }
                else if (file.IndexOf("CPUZ") != -1)
                {
                    JieShao.Text = "当前最流行的CPU测试软件,附带基准测试功能";
                }
                else if (file.IndexOf("Prime95") != -1)
                {
                    JieShao.Text = "一款较为严格的CPU稳定性测试软件";
                }
                else if (file.IndexOf("superpi") != -1)
                {
                    JieShao.Text = "Superpi是计算圆周率的软件,后被发现可以用来测试CPU稳定性";
                }
                else if (file.IndexOf("wPrime") != -1)
                {
                    JieShao.Text = "一款通过质数来测试CPU运算能力的软件,最多支持8线程";
                }
                else if (file.IndexOf("Fritz Chess Benchmark") != -1)
                {
                    JieShao.Text = "一款原本用于国际象棋棋力测试的软件,现在更多用于测试CPU科学计算能力";
                }

                else if (file.IndexOf("aida64") != -1)
                {
                    JieShao.Text = "一款全能硬件工具,支持检测CPU型号和详细参数,也可也用于测试内存延迟和硬件温度";
                }
                else if (file.IndexOf("ThrottleStop") != -1)
                {
                    JieShao.Text = "一款硬核的CPU调教工具,用来解锁温度墙,功耗墙以及锁定频率";
                }
                else if (file.IndexOf("Core Temp") != -1)
                {
                    JieShao.Text = "一款CPU温度检测软件,可以精确到每个核心的温度,除此之外还会显示功率和负载";
                }
                else
                {
                    JieShao.Text = "本工具没有提示或说明";
                }
            }
            else
            {
                if (file.IndexOf("CPU天梯图") != -1)
                {
                    JieShao.Text = "CPU ladder diagram (updated in January 2022)";
                }
                else if (file.IndexOf("CPUZ") != -1)
                {
                    JieShao.Text = "The most popular CPU test software at present, with benchmark function";
                }
                else if (file.IndexOf("Prime95") != -1)
                {
                    JieShao.Text = "More stringent CPU stability test software";
                }
                else if (file.IndexOf("superpi") != -1)
                {
                    JieShao.Text = "The software for calculating pi was found to be used to test the stability of CPU";
                }
                else if (file.IndexOf("wPrime") != -1)
                {
                    JieShao.Text = "Software for testing CPU computing power through prime numbers";
                }
                else if (file.IndexOf("Fritz Chess Benchmark") != -1)
                {
                    JieShao.Text = "Used to test the scientific computing power of CPU";
                }

                else if (file.IndexOf("aida64") != -1)
                {
                    JieShao.Text = "Universal hardware tool, which supports the detection of CPU model and detailed parameters";
                }
                else if (file.IndexOf("ThrottleStop") != -1)
                {
                    JieShao.Text = "Unlock the temperature wall, power wall and locking frequency";
                }
                else if (file.IndexOf("Core Temp") != -1)
                {
                    JieShao.Text = "CPU temperature detection software";
                }
                else
                {
                    JieShao.Text = "There are no prompts or instructions for this tool";
                }
            }
        }
        private void listView2_MouseClick(object sender, MouseEventArgs e)//主板
        {
            string file = listView2.Items[listView2.SelectedItems[0].Index].Name;
            if (语言选择框.SelectedIndex == 0)
            {
                if (file.IndexOf("aida64") != -1)
                {
                    JieShao.Text = "一款全能硬件工具,支持检测CPU型号和详细参数,多用于测试内存延迟";
                }
                else
                {
                    JieShao.Text = "本工具没有提示或说明";
                }
            }
            else
            {
                if (file.IndexOf("aida64") != -1)
                {
                    JieShao.Text = "The detailed parameters of the motherboard can be detected";
                }
                else
                {
                    JieShao.Text = "There are no prompts or instructions for this tool";
                }
            }


        }

        private void listView3_MouseClick(object sender, MouseEventArgs e)//内存
        {
            string file = listView3.Items[listView3.SelectedItems[0].Index].Name;
            if (语言选择框.SelectedIndex == 0)
            {
                if (file.IndexOf("memtest") != -1)
                {
                    JieShao.Text = "一款可以在微软系统下测试内存稳定性的软件";
                }
                else if (file.IndexOf("Thaiphoon") != -1)
                {
                    JieShao.Text = "一款内存SPD查看及修改工具";
                }
                else if (file.IndexOf("ramdisk") != -1)
                {
                    JieShao.Text = "一款可以将部分内存作为硬盘使用的软件";
                }
                else if (file.IndexOf("TM5") != -1)
                {
                    JieShao.Text = "一款内存稳定性的测试工具,可以用来测试超频后的内存是否稳定";
                }
                else if (file.IndexOf("DDR4内存颗粒天梯图") != -1)
                {
                    JieShao.Text = "DDR4内存颗粒天梯图,内存不分品牌,只分颗粒质量和性能";
                }
                else
                {
                    JieShao.Text = "本工具没有提示或说明";
                }
            
            }
            else
            {
                if (file.IndexOf("memtest") != -1)
                {
                    JieShao.Text = "Software for testing memory stability";
                }
                else if (file.IndexOf("Thaiphoon") != -1)
                {
                    JieShao.Text = "Memory viewing and modifying tool";
                }
                else if (file.IndexOf("ramdisk") != -1)
                {
                    JieShao.Text = "Software that can use part of the memory as a hard disk";
                }
                else if (file.IndexOf("TM5") != -1)
                {
                    JieShao.Text = "Test whether the memory after overclocking is stable";
                }
                else if (file.IndexOf("DDR4内存颗粒天梯图") != -1)
                {
                    JieShao.Text = "DDR4 memory particle ladder diagram";
                }
                else
                {
                    JieShao.Text = "There are no prompts or instructions for this tool";
                }

            }
        }

        private void listView4_MouseClick(object sender, MouseEventArgs e)//显卡天梯图
        {
            string file = listView4.Items[listView4.SelectedItems[0].Index].Name;
            if (语言选择框.SelectedIndex == 0)
            {
                if (file.IndexOf("显卡天梯图") != -1)
                {
                    JieShao.Text = "显卡天梯图(2022年5月更新)";
                }
                else if (file.IndexOf("GPUZ") != -1)
                {
                    JieShao.Text = "一款可以在微软系统下测试GPU稳定性的软件";
                }
                else if (file.IndexOf("AMDGPUClockTool") != -1)
                {
                    JieShao.Text = "A卡超频工具,适用于老卡,新卡可以用显卡驱动面板代替";
                }
                else if (file.IndexOf("Display Driver Uninstaller") != -1)
                {
                    JieShao.Text = "简称DDU,一款显卡驱动卸载工具,可彻底卸载显卡驱动";
                }

                else if (file.IndexOf("GpuTest_GUI") != -1)
                {
                    JieShao.Text = "一款显卡性能及稳定性测试软件,慎用";
                }
                else if (file.IndexOf("nvidiaInspector") != -1)
                {
                    JieShao.Text = "N卡超频软件,慎用";
                }
                else if (file.IndexOf("cpuburner") != -1)
                {
                    JieShao.Text = "FurMark自带的CPU温度压力测试工具,配合甜甜圈使用";
                }
                else if (file.IndexOf("FurMark") != -1)
                {
                    JieShao.Text = "俗称甜甜圈,一款显卡压力测试软件,常用于测试显卡稳定性";
                }
                else
                {
                    JieShao.Text = "本工具没有提示或说明";
                }
            }
            else
            {
                if (file.IndexOf("显卡天梯图") != -1)
                {
                    JieShao.Text = "GPU ladder diagram (updated in January 2022)";
                }
                else if (file.IndexOf("GPUZ") != -1)
                {
                    JieShao.Text = "Tools that can view the detailed parameters of GPU";
                }
                else if (file.IndexOf("AMDGPUClockTool") != -1)
                {
                    JieShao.Text = "AMD card overclocking tool, suitable for old cards";
                }
                else if (file.IndexOf("Display Driver Uninstaller") != -1)
                {
                    JieShao.Text = "The graphics card driver unloading tool can completely unload the graphics card driver";
                }
                else if (file.IndexOf("GpuTest_GUI") != -1)
                {
                    JieShao.Text = "Graphics card performance and stability test software, use with caution";
                }
                else if (file.IndexOf("nvidiaInspector") != -1)
                {
                    JieShao.Text = "N card overclocking software, use with caution";
                }
                else if (file.IndexOf("cpuburner") != -1)
                {
                    JieShao.Text = "Furmark own CPU temperature and pressure test tool is used with doughnuts";
                }
                else if (file.IndexOf("FurMark") != -1)
                {
                    JieShao.Text = "Graphics card pressure test software is commonly used to test the stability of graphics card";
                }
                else JieShao.Text = "There are no prompts or instructions for this tool";

            }
        }

        private void listView5_MouseClick(object sender, MouseEventArgs e)//磁盘工具
        {
            string file = listView5.Items[listView5.SelectedItems[0].Index].Name;
            if (语言选择框.SelectedIndex == 0)
            {
                if (file.IndexOf("ASSSDBenchmark") != -1)
                {
                    JieShao.Text = "一款固态硬盘性能评测工具";
                }
                else if (file.IndexOf("ATTO 磁盘基准测试") != -1)
                {
                    JieShao.Text = "一款磁盘基准测试软件";
                }
                else if (file.IndexOf("DiskInfo") != -1)
                {
                    JieShao.Text = "一款磁盘参数检测软件";
                }
                else if (file.IndexOf("SSDZ") != -1)
                {
                    JieShao.Text = "一款磁盘参数检测软件";
                }
                else if (file.IndexOf("DiskMark") != -1)
                {
                    JieShao.Text = "一款硬盘检测软件";
                }
                else if (file.IndexOf("Defraggler") != -1)
                {
                    JieShao.Text = "一款机械硬盘碎片整理软件,固态硬盘无需使用";
                }
                else if (file.IndexOf("分区助手") != -1)
                {
                    JieShao.Text = "傲梅分区助手绿色版,快速给硬盘分区";
                }
                else if (file.IndexOf("DiskGenius") != -1)
                {
                    JieShao.Text = "DiskGenius是一款硬盘分区软件,支持坏道修复";
                }
                else if (file.IndexOf("FINALDATA") != -1)
                {
                    JieShao.Text = "一款数据恢复软件";
                }
                else if (file.IndexOf("FdWizard") != -1)
                {
                    JieShao.Text = "FdWizard的向导";
                }
                else if (file.IndexOf("h2testw") != -1)
                {
                    JieShao.Text = "一款扩容U盘检测工具,开业检测U盘R\\W速度,也适用于固态硬盘";
                }
                else if (file.IndexOf("urwtest") != -1)
                {
                    JieShao.Text = "一款扩容U盘检测工具,开业检测U盘R\\W速度,也适用于固态硬盘";
                }
                else if (file.IndexOf("HDTune") != -1)
                {
                    JieShao.Text = "一款硬盘信息检测软件";
                }
                else if (file.IndexOf("LLFTOOL") != -1)
                {
                    JieShao.Text = "一款硬盘低级格式化工具,可低格硬盘,U盘,SD内存卡";
                }
                else if (file.IndexOf("MyDiskTest") != -1)
                {
                    JieShao.Text = "一款U盘容量验证工具,用来检测U盘是否为扩容盘";
                }
                else if (file.IndexOf("ssdlife") != -1)
                {
                    JieShao.Text = "一款固态硬盘寿命检测软件";
                }
                else if (file.IndexOf("魔方数据恢复") != -1)
                {
                    JieShao.Text = "一款数据恢复软件";
                }
                else if (file.IndexOf("ChipGenius") != -1)
                {
                    JieShao.Text = "一款U盘检测工具,可以识别U盘的主控和闪存颗粒";
                }
                else if (file.IndexOf("FlashMaster") != -1)
                {
                    JieShao.Text = "一款非常不错的U盘闪存料号查询工具";
                }
                else
                {
                    JieShao.Text = "本工具没有提示或说明";
                }
            }
            else
            {
                if (file.IndexOf("ASSSDBenchmark") != -1)
                {
                    JieShao.Text = "Solid state disk performance evaluation tool";
                }
                else if (file.IndexOf("ATTO 磁盘基准测试") != -1)
                {
                    JieShao.Text = "Disk benchmark software";
                }
                else if (file.IndexOf("DiskInfo") != -1)
                {
                    JieShao.Text = "Disk parameter detection software";
                }
                else if (file.IndexOf("SSDZ") != -1)
                {
                    JieShao.Text = "Disk parameter detection software";
                }
                else if (file.IndexOf("DiskMark") != -1)
                {
                    JieShao.Text = "Hard disk performance evaluation tool";
                }
                else if (file.IndexOf("Defraggler") != -1)
                {
                    JieShao.Text = "Mechanical hard disk defragmentation software, solid state disk does not need to be used";
                }
                else if (file.IndexOf("分区助手") != -1)
                {
                    JieShao.Text = "Quickly partition the hard disk";
                }
                else if (file.IndexOf("DiskGenius") != -1)
                {
                    JieShao.Text = "Hard disk partition software, supporting bad channel repair";
                }
                else if (file.IndexOf("FINALDATA") != -1)
                {
                    JieShao.Text = "Data recovery software";
                }
                else if (file.IndexOf("FdWizard") != -1)
                {
                    JieShao.Text = "Fdwizard Wizard";
                }
                else if (file.IndexOf("h2testw") != -1)
                {
                    JieShao.Text = "Expansion USB flash disk detection tool to detect the R \\ W speed of USB flash disk";
                }
                else if (file.IndexOf("urwtest") != -1)
                {
                    JieShao.Text = "Expansion USB flash disk detection tool to detect the R\\ W speed of USB flash disk";
                }
                else if (file.IndexOf("HDTune") != -1)
                {
                    JieShao.Text = "Hard disk information detection software";
                }
                else if (file.IndexOf("LLFTOOL") != -1)
                {
                    JieShao.Text = "Hard disk low-level formatting tool, low-level hard disk, U disk, SD memory card";
                }
                else if (file.IndexOf("MyDiskTest") != -1)
                {
                    JieShao.Text = "Check whether the USB flash disk is an expansion disk";
                }
                else if (file.IndexOf("ssdlife") != -1)
                {
                    JieShao.Text = "Solid state disk life detection software";
                }
                else if (file.IndexOf("魔方数据恢复") != -1)
                {
                    JieShao.Text = "Data recovery software";
                }
                else if (file.IndexOf("ChipGenius") != -1)
                {
                    JieShao.Text = "Identify the master control and flash memory of USB flash disk";
                }
                else if (file.IndexOf("FlashMaster") != -1)
                {
                    JieShao.Text = "USB flash item No. query tool";
                }
                else JieShao.Text = "There are no prompts or instructions for this tool";
            }
        }
        private void listView6_MouseClick(object sender, MouseEventArgs e)
        {
            string file = listView6.Items[listView6.SelectedItems[0].Index].Name;
            if (语言选择框.SelectedIndex == 0)
            {
                if (file.IndexOf("DisplayX") != -1)
                {
                    JieShao.Text = "一款小巧的显示器常规检测和液晶显示器坏点、延迟时间检测软件";
                }
                else if (file.IndexOf("monitorinfo") != -1)
                {
                    JieShao.Text = "通过显示器EDID数据计算显示器色域,数据仅供参考";
                }
                else
                {
                    JieShao.Text = "本工具没有提示或说明";
                }
            }
            else
            {
                if (file.IndexOf("DisplayX") != -1)
                {
                    JieShao.Text = "Monitor routine detection and LCD bad point and delay time detection software";
                }
                else if (file.IndexOf("monitorinfo") != -1)
                {
                    JieShao.Text = "Calculate the display color gamut through the display EDID data,The data is for reference only";
                }
                else JieShao.Text = "There are no prompts or instructions for this tool";
            }
        }

        private void listView7_MouseClick(object sender, MouseEventArgs e)//综合检测
        {
            string file = listView7.Items[listView7.SelectedItems[0].Index].Name;
            if (语言选择框.SelectedIndex == 0)
            {
                if (file.IndexOf("aida64") != -1)
                {
                    JieShao.Text = "一款全能硬件工具,支持检测CPU型号和详细参数,多用于测试内存延迟";
                }
                else if (file.IndexOf("HWiNFO") != -1)
                {
                    JieShao.Text = "一款检测电脑内部所有的硬件性能和实时状态的软件";
                }
                else if (file.IndexOf("RWEverything") != -1)
                {
                    JieShao.Text = "RWEverything是一款出色的硬件读写工具";
                }
                else if (file.IndexOf("Speccy") != -1)
                {
                    JieShao.Text = "一款功能丰富的硬件检测工具";
                }
                else if (file.IndexOf("HWMonitor") != -1)
                {
                    JieShao.Text = "一款硬件温度检测工具";
                }
                else if (file.IndexOf("HWMonitor") != -1)
                {
                    JieShao.Text = "一款硬件温度检测工具";
                }
                else if (file.IndexOf("OCCT") != -1)
                {
                    JieShao.Text = "OCCT主要检测系统电源稳定性以及满负荷下CPU和主板芯片的温度,判断电脑是否能够超频";
                }
                else if (file.IndexOf("OpenHardwareMonitor") != -1)
                {
                    JieShao.Text = "OpenHardwareMonitor是一款开源的可以检测电脑硬件负载的工具";
                }
                else
                {
                    JieShao.Text = "本工具没有提示或说明";
                }
            }
            else
            {
                if (file.IndexOf("aida64") != -1)
                {
                    JieShao.Text = "Universal hardware tool, which supports the detection of detailed hardware parameters";
                }
                else if (file.IndexOf("HWiNFO") != -1)
                {
                    JieShao.Text = "Check the performance and real-time status of all hardware inside the computer";
                }
                else if (file.IndexOf("RWEverything") != -1)
                {
                    JieShao.Text = "Excellent hardware reading and writing tools";
                }
                else if (file.IndexOf("Speccy") != -1)
                {
                    JieShao.Text = "Functional hardware detection tools";
                }
                else if (file.IndexOf("HWMonitor") != -1)
                {
                    JieShao.Text = "Functional hardware detection tools";
                }
                else if (file.IndexOf("HWMonitor") != -1)
                {
                    JieShao.Text = "Hardware temperature detection tool";
                }
                else if (file.IndexOf("OCCT") != -1)
                {
                    JieShao.Text = "Detect the temperature of CPU and motherboard chip under full load";
                }
                else if (file.IndexOf("OpenHardwareMonitor") != -1)
                {
                    JieShao.Text = "Openhardwaremonitor is an open source tool that can detect the load of computer hardware";
                }
                else JieShao.Text = "There are no prompts or instructions for this tool";
            }
        }

        private void listView8_MouseClick(object sender, MouseEventArgs e)//外设工具
        {
            string file = listView8.Items[listView8.SelectedItems[0].Index].Name;
            if (语言选择框.SelectedIndex == 0)
            {
                if (file.IndexOf("AresonMouseTest") != -1)
                {
                    JieShao.Text = "鼠标测试工具,可以测试鼠标采样率(一般鼠标为125HZ)";
                }
                else if (file.IndexOf("MOUSERATE") != -1)
                {
                    JieShao.Text = "鼠标测试工具,可以测试鼠标采样率(一般鼠标为125HZ)";
                }
                else if (file.IndexOf("鼠标单击变双击测试器") != -1)
                {
                    JieShao.Text = "一款鼠标单机变成连击的工具";
                }
                else if (file.IndexOf("ContextMenuManager.NET.3.5") != -1)
                {
                    JieShao.Text = "管理鼠标右键的信息的工具,可以屏蔽许多不需要的功能,让右键菜单更清爽";
                }
                else if (file.IndexOf("右键管家") != -1)
                {
                    JieShao.Text = "清理鼠标右键的信息,支持目录右键,文件夹右键,图片文档右键等操作";
                }                   
                else if (file.IndexOf("火绒文件粉碎") != -1)
                {
                    JieShao.Text = "火绒安全提取的文件粉碎工具,可强制删除文件";
                }
                else if (file.IndexOf("火绒右键管理") != -1)
                {
                    JieShao.Text = "火绒安全提取的火绒右键管理工具,可修改鼠标右键选项";
                }
                else if (file.IndexOf("W11ClassicMenu") != -1)
                {
                    JieShao.Text = "可以把W11系统的鼠标样式修改成旧版W10样式,使用更方便,";
                }
                else if (file.IndexOf("Keyboard Test Utility") != -1)
                {
                    JieShao.Text = "一款检测键盘是否正常触发的工具";
                }
               
                else
                {
                    JieShao.Text = "本工具没有提示或说明";
                }
            }
            else
            {
                if (file.IndexOf("AresonMouseTest") != -1)
                {
                    JieShao.Text = "Mouse test tool, which can test the mouse sampling rate (generally 125Hz)";
                }
                else if (file.IndexOf("MOUSERATE") != -1)
                {
                    JieShao.Text = "Mouse test tool, which can test the mouse sampling rate (generally 125Hz)";
                }
                else if (file.IndexOf("鼠标单击变双击测试器") != -1)
                {
                    JieShao.Text = "Mouse click to double click tester";
                }
                else if (file.IndexOf("右键管家") != -1)
                {
                    JieShao.Text = "Clear the right mouse button information";
                }
                else if (file.IndexOf("火绒文件粉碎") != -1)
                {
                    JieShao.Text = "File shredding tool, which can forcibly delete files";
                }
                else if (file.IndexOf("火绒右键管理") != -1)
                {
                    JieShao.Text = "Right click the management tool to modify the right-click options";
                }
                else if (file.IndexOf("W11ClassicMenu") != -1)
                {
                    JieShao.Text = "Win11 classic context menu style";
                }
                else if (file.IndexOf("Keyboard Test Utility") != -1)
                {
                    JieShao.Text = "Tool for detecting whether the keyboard is triggered normally";
                }
              
                else JieShao.Text = "There are no prompts or instructions for this tool";

            }
        }

        private void listView9_MouseClick(object sender, MouseEventArgs e)//烤鸡工具
        {
            string file = listView9.Items[listView9.SelectedItems[0].Index].Name;
            if (语言选择框.SelectedIndex == 0)
            {
                if (file.IndexOf("aida64") != -1)
                {
                    JieShao.Text = "一款全能硬件工具,支持检测CPU型号和详细参数,多用于测试内存延迟";
                }
                else if (file.IndexOf("GpuTest_GUI") != -1)
                {
                    JieShao.Text = "一款显卡性能及稳定性测试软件,慎用";
                }
                else if (file.IndexOf("Prime95") != -1)
                {
                    JieShao.Text = "一款较为严格的CPU稳定性测试软件";
                }
                else if (file.IndexOf("cpuburner") != -1)
                {
                    JieShao.Text = "FurMark自带的CPU温度压力测试工具,配合甜甜圈(FurMark)使用";
                }
                else if (file.IndexOf("FurMark") != -1)
                {
                    JieShao.Text = "俗称甜甜圈,一款显卡压力测试软件,常用于测试显卡稳定性";
                }
                else if (file.IndexOf("OCCT") != -1)
                {
                    JieShao.Text = "OCCT主要检测系统电源稳定性以及满负荷下CPU和主板芯片的温度,判断电脑是否能够超频";
                }
                else JieShao.Text = "本工具没有提示或说明";
            }
            else
            {
                if (file.IndexOf("aida64") != -1)
                {
                    JieShao.Text = "Universal hardware tool, which supports the detection of CPU model and detailed parameters";
                }
                else if (file.IndexOf("GpuTest_GUI") != -1)
                {
                    JieShao.Text = "Graphics card performance and stability test software, use with caution";
                }
                else if (file.IndexOf("Prime95") != -1)
                {
                    JieShao.Text = "Strict CPU stability test software";
                }
 
                else if (file.IndexOf("FurMark") != -1)
                {
                    JieShao.Text = "Graphics card pressure test software is commonly used to test the stability of graphics card";
                }
                else if (file.IndexOf("OCCT") != -1)
                {
                    JieShao.Text = "Detect the temperature of CPU and motherboard chip under full load";
                }
                else JieShao.Text = "There are no prompts or instructions for this tool";

            }
        }

        private void listView10_MouseClick(object sender, MouseEventArgs e)//其他工具
        {
            string file = listView10.Items[listView10.SelectedItems[0].Index].Name;
            if (语言选择框.SelectedIndex == 0)
            {   
                if (file.IndexOf("360驱动大师") != -1)
                {
                    JieShao.Text = "360驱动大师,自动驱动安装更新驱动软件";
                }
                else if (file.IndexOf("360宽带测速器") != -1)
                {
                    JieShao.Text = "360宽带测速器单文件版,一键检测当前网速";
                }
                else if (file.IndexOf("BlueScreenViewx") != -1)
                {
                    JieShao.Text = "如果开启了将事件写入系统日志,这款工具可以查看蓝屏记录";
                }
            
                else if (file.IndexOf("Dism++") != -1)
                {
                    JieShao.Text = "Dism++是一款Windows系统优化工具,可以进行固化补丁、Installer清理、离线集成更新等操作";
                }
                else if (file.IndexOf("ULTRAISO") != -1)
                {
                    JieShao.Text = "UltraISO软碟通一款光盘影像制作工具";
                }            
                else if (file.IndexOf("MicroKMS") != -1)
                {
                    JieShao.Text = "MicroKMS神龙版激活工具,可以激活W10,W11系统";
                }
                else if (file.IndexOf("oem7") != -1)
                {
                    JieShao.Text = "小马W7激活工具,可以激活W7系统";
                }
                else if (file.IndexOf("暴风W7激活工具") != -1)
                {
                    JieShao.Text = "暴风W7激活工具,可以激活W7系统";
                }
                else if (file.IndexOf("tuladingKMS") != -1)
                {
                    JieShao.Text = "图吧KMS系统,可以用来激活W10系统,需要自己选择服务器激活";
                }
                else
                {
                    JieShao.Text = "本工具没有提示或说明";
                }
            }
            else
            {  if (file.IndexOf("360宽带测速器") != -1)
                {
                    JieShao.Text = "One click detection of current network speed";
                }
                else if (file.IndexOf("360驱动大师") != -1)
                {
                    JieShao.Text = "360 Driver, Automatically update the driver software";
                }
                else if (file.IndexOf("BlueScreenViewx") != -1)
                {
                    JieShao.Text = "Write events to the system log is enabled. This tool can view the blue screen records";
                }
                else if (file.IndexOf("Dism++") != -1)
                {
                    JieShao.Text = "Dism++ Windows system optimization tool";
                }
                else if (file.IndexOf("ULTRAISO") != -1)
                {
                    JieShao.Text = "UltraISO CD image making tool";
                }               
                else if (file.IndexOf("MicroKMS") != -1)
                {
                    JieShao.Text = "Microkms can activate W10 and W11 systems";
                }
                else if (file.IndexOf("oem7") != -1)
                {
                    JieShao.Text = "oem7 can activate W7 systems";
                }
                else if (file.IndexOf("暴风W7激活工具") != -1)
                {
                    JieShao.Text = "activate W7 systems";
                }
                else if (file.IndexOf("tuladingKMS") != -1)
                {
                    JieShao.Text = "tuladingKMS can activate W10 systems";
                }
                else JieShao.Text = "There are no prompts or instructions for this tool";
            }
        }

        private void label81_Click(object sender, EventArgs e)
        {
            label34_Click(sender, e);
        }
        private void label83_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.bianshengruanjian.com");
        }
        private void LanguageLnitialization()
        {
            if (API.读配置项(功能配置路径, "Set", "lag") == "")
            {
                if (lag.IndexOf("zh") != -1)//是中文
                {
                    语言选择框.Items.Add("中文");
                    语言选择框.Items.Add("English");
                    API.写配置项(功能配置路径, "Set", "lag", "Chinese");
                    中文();
                    语言选择框.SelectedIndex = 0;
                }
                else if (lag.IndexOf("en") != -1)//英文
                {
                    语言选择框.Items.Add("中文");
                    语言选择框.Items.Add("English");
                    API.写配置项(功能配置路径, "Set", "lag", "English");
                    英文();
                    语言选择框.SelectedIndex = 1;
                }
                else
                {
                    语言选择框.Items.Add("中文");
                    语言选择框.Items.Add("English");
                    API.写配置项(功能配置路径, "Set", "lag", "English");
                    英文();
                    语言选择框.SelectedIndex = 1;
                }
            }
            else if (API.读配置项(功能配置路径, "Set", "lag") == "Chinese")
            {
                语言选择框.Items.Add("中文");
                语言选择框.Items.Add("English");
                语言选择框.SelectedIndex = 0;
                中文();
            }
            else if (API.读配置项(功能配置路径, "Set", "lag") == "English")
            {
                语言选择框.Items.Add("中文");
                语言选择框.Items.Add("English");
                语言选择框.SelectedIndex = 1;
                英文();
            }
            else
            {
                语言选择框.Items.Add("中文");
                语言选择框.Items.Add("English");
                语言选择框.SelectedIndex = 1;
                英文();
            }
        }
        private void 语言选择框_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (语言选择框.SelectedIndex == 0)
            {
                语言选择框.SelectedIndex = 0;
                中文();
                API.写配置项(功能配置路径, "Set", "lag", "Chinese");

            }
            else if (语言选择框.SelectedIndex == 1)
            {
                语言选择框.SelectedIndex = 1;
                英文();
                API.写配置项(功能配置路径, "Set", "lag", "English");

            }
            else
            {
                语言选择框.SelectedIndex = 1;
                英文();
                API.写配置项(功能配置路径, "Set", "lag", "English");

            }
        }
        private void 中文()
        {
            label93.Visible = true;
            this.Text = "入梦工具箱";
            label16.Text = this.Text;
            label22.Text = "分辨率:";
            label23.Text = "处理器:";
            label24.Text = "内存:";
            label25.Text = "主板:";
            label26.Text = "显卡:";
            label30.Text = "硬盘:";
            label32.Text = "声卡:";
            label82.Text = "声卡型号:";
            label31.Text = "网卡:";
            label78.Text = label31.Text;
            label36.Text = "分区:";
            label27.Text = "硬件信息";
            label4.Text = "CPU工具";
            label5.Text = "主板工具";
            label6.Text = "内存工具";
            label7.Text = "显卡工具";
            label8.Text = "硬盘工具";
            label9.Text = "屏幕工具";
            label10.Text = "综合检测";
            label11.Text = "外设工具";
            label12.Text = "烤机工具";
            label13.Text = "其他工具";
            label14.Text = "自定工具";
            label15.Text = "工具大全";
            label104.Text = "选项设置";
            label60.Text = "返回";
            label56.Text = label60.Text;
            label77.Text = label60.Text;
            label45.Text = label60.Text;
            label51.Text = label60.Text;
            label49.Text = label60.Text;
            label67.Text = "规格形号:";
            窗口置顶.Text = "窗口置顶";
            checkBox1.Text = "F12显示/隐藏";
            //label3.Text = "透明度";
            button3.Text = "控制面板";
            button6.Text = "卸载软件";
            button16.Text = "设备管理器";
            button5.Text = "磁盘管理器";

            button4.Text = "鼠标属性";
            button7.Text = "任务管理器";
            button2.Text = "系统音频";
            button8.Text = "全局静音";
            label34.Text = "更新";
            label21.Text = "官网";
            label17.Text = "反馈";
            label1.Text = "初始化";
            label74.Text = "硬盘名称:";
            label75.Text = "磁盘分区:";
            label86.Text = "当前输入:";
            label87.Text = "当前输出:";
            button10.Text = "事件查看器";
            button11.Text = "注册表管理";
            button12.Text = "隐藏任务栏";
            button13.Text = "显示任务栏";
            button9.Text = "声卡检测";
            button14.Text = "我的文档";
            label91.Text = "QQ群:957997089";
            button15.Text = "电脑时间";
            button21.Text = "区域";
            label98.Text = "音频:";
            button17.Text = "字体";
            button18.Text = "键盘属性";
            button24.Text = "屏保";

            button19.Text = "电源管理";
            button20.Text = "打印机";
            button22.Text = "系统属性";
            button23.Text = "防火墙";
            button26.Text = "检测激活";
            label103.Text = "复制此页";
            checkBox2.Text = "插件识别";
            label93.Text = "详细信息";
            label95.Text = "默认识别";
            label94.Text = "插件识别";
            label93.Location = new Point(label103.Location.X - 147, label103.Location.Y);
            label95.Location = new Point(label103.Location.X - 73, label103.Location.Y);
            label94.Location = new Point(label2.Location.X - 73, label2.Location.Y);
            button27.Text = "桌面图标";
            label92.Text = "窗口:"; label90.Text = "面板:"; label89.Text = "设备:"; label96.Text = "系统:";
            button25.Text = "窗口工具";
            button1.Text = "一键烤机";
            label99.Text = "快捷:";
            烤CPU.Text = "烤CPU";
            烤GPU.Text = "烤GPU";
            radioButton4.Text = "倒计时";
            label102.Text = "时";
            label101.Text = "分";
            label100.Text = "秒";
            一键双烤.Text = "一键烤机";
        }
        private void 英文()
        {
            一键双烤.Text = "Toaster";
            label102.Text = "H";
            label101.Text = "M";
            label100.Text = "S";
            radioButton4.Text = "CDT";
            烤GPU.Text = "GPU";
            烤CPU.Text = "CPU";
            label99.Text = "Qk:";

            label93.Visible = false;
            this.Text = "RM Toolbox";
            label16.Text = "RM Tool";
            label22.Text = "VGA:";
            label23.Text = "CPU:";
            label24.Text = "Memory:";
            label25.Text = "Mobo:";
            label26.Text = "GPU:";
            label30.Text = "HDD:";
            label32.Text = "Audio:";
            label82.Text = label32.Text;
            label31.Text = "NIC:";
            label78.Text = label31.Text;
            label36.Text = "Pation:";
            label27.Text = "Information";
            label4.Text = "CPU tools";
            label5.Text = "Mainboard";
            label6.Text = "Memory";
            label7.Text = "GPU tools";
            label8.Text = "HDD tools";
            label9.Text = "Screen tools";
            label10.Text = "Synthetical";
            label11.Text = "Peripheral";
            label12.Text = "Test tools";
            label13.Text = "Other tools";
            label14.Text = "Custom tools";
            label15.Text = "Rm tools";
            label104.Text = "Settings";
            label60.Text = "Return";
            label56.Text = label60.Text;
            label77.Text = label60.Text;
            label45.Text = label60.Text;
            label51.Text = label60.Text;
            label49.Text = label60.Text;
            label67.Text = "Specifications:";
            窗口置顶.Text = "Win Top";
            checkBox1.Text = "F12Show/hide";
            //label3.Text = "Transparent";
            button3.Text = "Control panel";
            button6.Text = "Uninstall";
            label98.Text = "AU:";
            button4.Text = "Mouse";
            button7.Text = "Taskmgr";
            button2.Text = "Audio";
            button8.Text = "Mute";
            label34.Text = "Upd";
            label21.Text = "Web";
            label17.Text = "Fb";
            label1.Text = "Initial";
            label74.Text = "HddName:";
            label75.Text = "Partition:";
            label86.Text = "Recording:";
            label87.Text = "Playback:";
            button10.Text = "EventViewer";
            button11.Text = "Registry";
            button12.Text = "HidTaskbar";
            button13.Text = "ShowTaskbar";
            button9.Text = "Testing";
            button14.Text = "Documents";
            button15.Text = "Time";
            button21.Text = "Region";
            button16.Text = "Device";
            button5.Text = "Disk";
            button17.Text = "Typeface";
            button18.Text = "Keyboard";
            button24.Text = "Screensaver";
            button1.Text = "Toaster";
            button19.Text = "Power";
            button20.Text = "Printer";
            button22.Text = "System";
            button23.Text = "Firewall";
            label91.Text = "Q group:957997089";
            label103.Text = "Copy";
            button26.Text = "Activation";
            checkBox2.Text = "Detailed";

            label94.Text = "Discriminate";
            label95.Text = "Default";

            label93.Text = "Detailed";
            label93.Location = new Point(label103.Location.X - 147, label103.Location.Y);
            button25.Text = "Window";
            label94.Location = new Point(label2.Location.X - 100, label2.Location.Y);
            label95.Location = new Point(label103.Location.X - 73, label103.Location.Y);
            button27.Text = "Ico";
            label92.Text = "Window:"; label90.Text = "PNL:"; label89.Text = "DEV:"; label96.Text = "SYS:";
        }


        private void button10_Click(object sender, EventArgs e)//事件查看器
        {
            Process.Start("eventvwr.exe ");
        }

        private void button11_Click(object sender, EventArgs e)//打开注册表
        {
            Process.Start("regedit.exe ");
        }


        private void button12_Click(object sender, EventArgs e)//显示任务栏
        {
            API.ShowWindow(API.FindWindow("Shell_TrayWnd", null), 0);
        }

        private void button13_Click(object sender, EventArgs e)//隐藏任务栏
        {
            API.ShowWindow(API.FindWindow("Shell_TrayWnd", null), 6);
        }

        private void button14_Click(object sender, EventArgs e)//打开我的文档
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
        }

        private void button15_Click(object sender, EventArgs e)//时间
        {
            Process.Start("rundll32.exe", "shell32.dll,Control_RunDLL timedate.cpl");
        }



        private void button17_Click(object sender, EventArgs e)//字体
        {
            Process.Start("rundll32.exe", "shell32.dll,SHHelpShortcuts_RunDLL  FontsFolder");
        }

        private void button18_Click(object sender, EventArgs e)//键盘
        {
            Process.Start("rundll32.exe", "shell32.dll,Control_RunDLL main.cpl @1");
        }

        private void button19_Click(object sender, EventArgs e)//电源
        {
            Process.Start("rundll32.exe", "shell32.dll,Control_RunDLL powercfg.cpl");
        }

        private void button20_Click(object sender, EventArgs e)//打印机
        {
            Process.Start("rundll32.exe", "shell32.dll,SHHelpShortcuts_RunDLL PrintersFolder");
        }

        private void button21_Click(object sender, EventArgs e)//区域
        {
            Process.Start("rundll32.exe", "shell32.dll,Control_RunDLL intl.cpl");
        }

        private void button22_Click(object sender, EventArgs e)//系统属性
        {
            Process.Start("rundll32.exe", "shell32.dll,Control_RunDLL sysdm.cpl");
        }

        private void button23_Click(object sender, EventArgs e)//防火墙
        {
            Process.Start("rundll32.exe", "shell32.dll,Control_RunDLL firewall.cpl");
        }

        private void button24_Click(object sender, EventArgs e)//屏保
        {
            Process.Start("rundll32.exe", "desk.cpl,InstallScreenSaver");
        }



        private void button26_Click(object sender, EventArgs e)//检测系统激活
        {
            if (API.网页_是否联网() == true)
            {
                try
                {
                    if (Environment.OSVersion.Version.Major >= 6) //Version 6 can be Windows Vista, Windows Server 2008, or Windows 7
                    {
                        if (API.IsGenuineWindows())
                        {
                            if (语言选择框.SelectedIndex == 1)
                            {
                                系统状态.Text = "Activated";
                                API.信息框(系统状态.Text, "Tips:", 5000);
                            }
                            else
                            {
                                系统状态.Text = "系统状态: 已激活";
                                API.信息框(系统状态.Text, "信息:", 5000);
                            }
                        }
                        else
                        {
                            if (语言选择框.SelectedIndex == 1)
                            {
                                系统状态.Text = "Not Active";
                                API.信息框(系统状态.Text, "Tips:", 5000);
                            }
                            else
                            {
                                API.信息框(系统状态.Text, "信息:", 5000);
                                系统状态.Text = "系统状态: 未激活";
                            }

                        }
                    }
                    else
                    {
                        if (语言选择框.SelectedIndex == 1)
                        {
                            系统状态.Text = "Not Support";
                            API.信息框(系统状态.Text, "Tips:", 5000);

                        }
                        else
                        {
                            API.信息框(系统状态.Text, "信息:", 5000);
                            系统状态.Text = "系统状态: 不支持";
                        }

                    }
                }
                catch
                {
                    系统状态.Visible = false;
                }
            }
            else
            {
                if (语言选择框.SelectedIndex == 1)
                {
                    系统状态.Text = "Not networked";

                }
                else
                {
                    系统状态.Text = "系统状态: 未联网";
                }
            }

        }
        private void button27_Click(object sender, EventArgs e)//此电脑
        {
            Process.Start("rundll32.exe", "shell32.dll,Control_RunDLL desk.cpl,,0");
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (File.Exists("bin\\SystemTb.dll") == true)
            {
                if (checkBox2.Checked == true)
                {
                    API.写配置项(功能配置路径, "Set", "TB", "1");

                }
                else
                {
                    API.写配置项(功能配置路径, "Set", "TB", "0");


                }
            }
            else
            {
                if (语言选择框.SelectedIndex == 0)
                {
                    API.信息框("bin\\SystemTb.dll不存在,请重新安装软件", "信息:", 5000);
                }
                else if (语言选择框.SelectedIndex == 1)
                {
                    API.信息框("bin\\SystemTb. DLL does not exist, please reinstall the software", "Tips:", 5000);
                }
                else
                {
                    API.信息框("bin\\SystemTb.dll不存在,请重新安装软件", "信息:", 5000);
                }
                if (File.Exists("bin\\SystemTb.dll") == true)
                {
                    API.写配置项(功能配置路径, "Set", "TB", "0");
                }
                checkBox2.Checked = false;
            }
        }
        private void label103_Click(object sender, EventArgs e)
        {
            if (textBox15.Visible != true)
            {
                Clipboard.SetDataObject(textBox14.Text);
            }
            else Clipboard.SetDataObject(textBox15.Text);

            if (语言选择框.SelectedIndex == 0)
            {
                label103.Text = "已复制";
                程序_延时(1000);
                label103.Text = "复制此页";
            }
            else if (语言选择框.SelectedIndex == 1)
            {
                label103.Text = "Copied";
                程序_延时(1000);
                label103.Text = "Copy";
            }
            else
            {
                label103.Text = "已复制";
                程序_延时(1000);
                label103.Text = "复制此页";
            }
        }

        private void label93_Click(object sender, EventArgs e)
        {
            if (textBox15.Visible != true)
            {
                textBox15.Visible = true;
            }
            else
            {
                textBox15.Visible = false;
            }
            if (语言选择框.SelectedIndex == 0)
            {
                if (label93.Text == "返回")
                {
                    label93.Text = "详细信息";

                    label93.Location = new Point(label103.Location.X - 147, label103.Location.Y);
                }
                else
                {
                    label93.Text = "返回";
                    label93.Location = new Point(label103.Location.X - 120, label103.Location.Y);
                }
            }
            else
            {
                if (label93.Text == "Return")
                {
                    label93.Text = "Detailed";
                    label93.Location = new Point(label103.Location.X - 147, label103.Location.Y);
                }
                else
                {
                    label93.Text = "Return";
                    label93.Location = new Point(label103.Location.X - 138, label103.Location.Y);
                }

            }
        }

        private void label94_Click(object sender, EventArgs e)
        {
            if (语言选择框.SelectedIndex == 0)
            {
                label93.Text = "详细信息";
                label95.Location = new Point(label103.Location.X - 73, label103.Location.Y);
                label93.Location = new Point(label103.Location.X - 147, label103.Location.Y);
            }
            else
            {
                label93.Text = "Detailed";
                label95.Location = new Point(label103.Location.X - 73, label103.Location.Y);
                label93.Location = new Point(label103.Location.X - 147, label103.Location.Y);

            }
            textBox15.Visible = false;
            if (panel4.Visible == true)
            {
                panel12.Visible = true;
                panel4.Visible = false;
            }
            else
            {
                panel12.Visible = false;
                panel4.Visible = true;

            }


        }

        private void label95_Click(object sender, EventArgs e)
        {
            if (语言选择框.SelectedIndex == 0)
            {
                label93.Text = "详细信息";
                label94.Location = new Point(label2.Location.X - 73, label2.Location.Y);
            }
            else
            {
                label93.Text = "Detailed";
                label94.Location = new Point(label2.Location.X - 100, label2.Location.Y);
            }
            textBox15.Visible = false;
            if (panel12.Visible == false)
            {
                panel4.Visible = false;
                panel12.Visible = true;
            }
            else
            {
                panel4.Visible = true;
                panel12.Visible = false;

            }

        }
        private void 删除路径及文件toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (删除路径及文件toolStripMenuItem1.Checked == true)
            {
                删除路径及文件toolStripMenuItem1.Checked = false;
                API.写配置项(功能配置路径, "Set", "FileD", "0");
            }
            else
            {
                删除路径及文件toolStripMenuItem1.Checked = true;
                API.写配置项(功能配置路径, "Set", "FileD", "1");
            }
           
        }
        private void 大图标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            大图标ToolStripMenuItem.Checked = true;
            中图标ToolStripMenuItem.Checked = false;
            小图标ToolStripMenuItem.Checked = false;
            API.写配置项(功能配置路径, "Set", "large", "1");
            API.写配置项(功能配置路径, "Set", "in", "0");
            API.写配置项(功能配置路径, "Set", "Small", "0");
        }

        private void 中图标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            中图标ToolStripMenuItem.Checked = true;
            大图标ToolStripMenuItem.Checked = false;
            小图标ToolStripMenuItem.Checked = false;
            API.写配置项(功能配置路径, "Set", "in", "1");
            API.写配置项(功能配置路径, "Set", "large", "0");
            API.写配置项(功能配置路径, "Set", "Small", "0");
        }

        private void 小图标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            大图标ToolStripMenuItem.Checked = false;
            中图标ToolStripMenuItem.Checked = false;
            小图标ToolStripMenuItem.Checked = true;
            API.写配置项(功能配置路径, "Set", "Small", "1");
            API.写配置项(功能配置路径, "Set", "large", "0");
            API.写配置项(功能配置路径, "Set", "in", "0");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            int 起动总时间 = Environment.TickCount / 1000;
            int 起动小时 = 起动总时间 / 3600;
            int 剩余时间 = 起动总时间 % 3600;
            int 起动分钟 = 剩余时间 / 60;
            int 起动秒数 = 剩余时间 % 60;
            if (语言选择框.SelectedIndex == 1)
            {
                label97.Text = "Uptime: " + 起动小时.ToString() + "H " + 起动分钟.ToString() + "M " + 起动秒数.ToString() + "S";
            }
            else
            {
                label97.Text = "开机时间: " + 起动小时.ToString() + "小时 " + 起动分钟.ToString() + "分钟 " + 起动秒数.ToString() + "秒";
            }

        }
        private void button9_Click(object sender, EventArgs e)
        {
            声卡检测();
        }
        private void 声卡检测()
        {
            if (File.Exists("bin\\RMtesting.exe") == true)
            {
                if (API.进程_是否存在("RMtesting.exe") == false)
                {
                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = "bin\\RMtesting.exe";
                    psi.UseShellExecute = false;
                    psi.WorkingDirectory = "bin";
                    psi.CreateNoWindow = true;
                    Process.Start(psi);
                }
                else
                {
                    IntPtr hhw = (IntPtr)int.Parse(API.读配置项(API.默认我的文档() + "\\bin\\config.ini", "Set", "Hwd"));
                    if (this.TopMost == true)
                    {
                        API.窗口_置顶(hhw, true);
                    }
                    API.ShowWindow(hhw, 1);
                    API.窗口_置焦点(hhw);
                }

            }
            else
            {
                if (语言选择框.SelectedIndex == 0)
                {
                    API.信息框("检测声卡软件不存在,请重装软件", "信息:", 5000);
                }
                else if (语言选择框.SelectedIndex == 1)
                {
                    API.信息框("The software does not exist. Please reinstall", "Tips:", 5000);
                }
                else
                {
                    API.信息框("检测声卡软件不存在,请重装软件", "信息:", 5000);
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)//设备管理器
        {
           // API.运行(Environment.CurrentDirectory + "\\bin", "设备管理器.bat");
            // API.文件_执行(Environment.CurrentDirectory + "\\bin\\设备管理器.bat", null, 0);
            Process.Start("devmgmt.msc");
        }

        private void button5_Click_1(object sender, EventArgs e)//磁盘管理
        {
            Process.Start("diskmgmt.msc");
           // API.运行(Environment.CurrentDirectory + "\\bin", "磁盘管理.bat");
          //  API.文件_执行(Environment.CurrentDirectory + "\\bin\\磁盘管理.bat", null, 0);
        }
        private int flagNum = 0;
        private int dValue;
        private bool Flag = true;
        private void 一键双烤_Click(object sender, EventArgs e)//双烤
        {
            if (Directory.Exists("tool") == true)
            {
                if (烤CPU.Checked == false && 烤GPU.Checked == false)
                {
                    if (语言选择框.SelectedIndex == 0)
                    {
                        API.信息框("请选单烤CPU或GPU,也可也两者都选", "信息:", 5000);
                    }
                    else if (语言选择框.SelectedIndex == 1)
                    {
                        API.信息框("Please select CPU or GPU, or both", "Tips:", 5000);
                    }
                    else
                    {
                        API.信息框("请选单烤CPU或GPU,也可也两者都选", "信息:", 5000);
                    }
                }
                else
                {
                    if (radioButton4.Checked == true)
                    {
                        dValue = Convert.ToInt16(comboBox6.Text) * 3600 + Convert.ToInt16(comboBox5.Text) * 60 + Convert.ToInt16(comboBox4.Text);
                        if (dValue <= 0)
                        {
                            dValue = 24 * 3600 + dValue;
                        }
                        if (语言选择框.SelectedIndex == 0)
                        {
                            labl关机.Text = "剩余时间: ";
                            labl关机.Text += (dValue - flagNum) / 3600 + "时";
                            labl关机.Text += (dValue - flagNum) % 3600 / 60 + "分";
                            labl关机.Text += (dValue - flagNum) % 3600 % 60 + "秒 ";
                        }
                        else
                        {
                            labl关机.Text = "Time: ";
                            labl关机.Text += (dValue - flagNum) / 3600 + "H";
                            labl关机.Text += (dValue - flagNum) % 3600 / 60 + "M";
                            labl关机.Text += (dValue - flagNum) % 3600 % 60 + "S";
                        }
                        labl关机.Visible = true;
                        定时烤鸡.Interval = 1000;
                        if (Flag)
                        {
                            定时烤鸡.Start();
                            Flag = false;

                            flagNum = 0;
                        }
                        else
                        {
                            结束AD64();
                            定时烤鸡.Stop();
                            Flag = true;
                            labl关机.Visible = false;
                            flagNum = 0;
                        }

                    }
                    if (烤CPU.Checked == true)
                    {
                        if (API.进程_是否存在("aida64") == false)
                        {
                            程序_延时(500);
                            if (File.Exists(Environment.CurrentDirectory + "\\tool\\综合检测\\aida64\\FPU.bat") == true)
                            {
                                API.运行(Environment.CurrentDirectory + "\\tool\\综合检测\\aida64", "FPU.bat");
                            }
                            else
                            {
                                if (语言选择框.SelectedIndex == 0)
                                {
                                    API.信息框("FPU.bat不存在,请重新下载安装软件", "信息:", 5000);
                                }
                                else
                                {
                                    API.信息框("FPU.bat does not exist, please download and install the software again", "Tips:", 5000);
                                }
                            }
                        }
                    }
                    if (烤GPU.Checked == true)
                    {
                        if (API.进程_是否存在("FurMark") == false)
                        {
                            程序_延时(500);
                            if (File.Exists(Environment.CurrentDirectory + "\\tool\\烤鸡工具\\FurMark\\start.bat") == true)
                            {
                                API.运行(Environment.CurrentDirectory + "\\tool\\烤鸡工具\\FurMark", "start.bat");
                            }
                            else
                            {
                                if (语言选择框.SelectedIndex == 0)
                                {
                                    API.信息框("start.bat不存在,请重新下载安装软件", "信息:", 5000);
                                }
                                else
                                {
                                    API.信息框("start.bat does not exist, please download and install the software again", "Tips:", 5000);
                                }

                            }

                        }
                    }


                }
            }
            else
            {
                if (语言选择框.SelectedIndex == 0)
                {
                    API.信息框("未找到tool文件夹,请您安装完整版软件!", "信息:", 5000);
                }
                else if (语言选择框.SelectedIndex == 1)
                {
                    API.信息框("The file is corrupt. Please reinstall it", "Tips:", 5000);
                }
                else
                {
                    API.信息框("未找到tool文件夹,请您安装完整版软件!", "信息:", 5000);
                }
            }  
           
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                API.写配置项(功能配置路径, "Set", "radioButton4", "1");
            }
            else
            {
                API.写配置项(功能配置路径, "Set", "radioButton4", "0");
            }

        }

        private void 定时烤鸡_Tick(object sender, EventArgs e)
        {
            flagNum++;
            if (语言选择框.SelectedIndex == 0)
            {
                labl关机.Text = "剩余时间: ";
                labl关机.Text += (dValue - flagNum) / 3600 + "时";
                labl关机.Text += (dValue - flagNum) % 3600 / 60 + "分";
                labl关机.Text += (dValue - flagNum) % 3600 % 60 + "秒 ";
            }
            else
            {
                labl关机.Text = "Time: ";
                labl关机.Text += (dValue - flagNum) / 3600 + "H";
                labl关机.Text += (dValue - flagNum) % 3600 / 60 + "M";
                labl关机.Text += (dValue - flagNum) % 3600 % 60 + "S";
            }
            this.Text = API.文本_取右边内容(labl关机.Text, " ");
            if (flagNum >= dValue)
            {
                结束AD64();
                定时烤鸡.Stop();
                Flag = true;
                labl关机.Visible = false;
                flagNum = 0;
                if (语言选择框.SelectedIndex == 0)
                {
                    this.Text = "入梦工具箱";
                }
                else
                {
                    this.Text = "RM Toolbox";
                }                             
            }
            if (API.进程_是否存在("aida64") == false && API.进程_是否存在("FurMark") == false)
            {   结束AD64();
                定时烤鸡.Stop();
                Flag = true;
                labl关机.Visible = false;
                flagNum = 0;
                if (语言选择框.SelectedIndex == 0)
                {
                    this.Text = "入梦工具箱";
                }
                else
                {
                    this.Text = "RM Toolbox";
                }
            }          
        }
        private void 烤CPU_CheckedChanged(object sender, EventArgs e)
        {
            if (烤CPU.Checked == true)
            {
                API.写配置项(功能配置路径, "Set", "烤CPU", "1");
            }
            else
            {
                API.写配置项(功能配置路径, "Set", "烤CPU", "0");
            }
        }

        private void 烤GPU_CheckedChanged(object sender, EventArgs e)
        {
            if (烤GPU.Checked == true)
            {
                API.写配置项(功能配置路径, "Set", "烤GPU", "1");
            }
            else
            {
                API.写配置项(功能配置路径, "Set", "烤GPU", "0");
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            API.写配置项(功能配置路径, "Set", "comboBox6", comboBox6.SelectedItem.ToString());
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            API.写配置项(功能配置路径, "Set", "comboBox5", comboBox5.SelectedItem.ToString());
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            API.写配置项(功能配置路径, "Set", "comboBox4", comboBox4.SelectedItem.ToString());
        }

        private void button25_Click(object sender, EventArgs e) //RMwindow
        {
            if (File.Exists("bin\\RMwindow.exe") == true)
            {
                if (API.进程_是否存在("RMwindow.exe") == false)
                {
                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = "bin\\RMwindow.exe";
                    psi.UseShellExecute = false;
                    psi.WorkingDirectory = "bin";
                    psi.CreateNoWindow = true;
                    Process.Start(psi);
                }
                else
                {
                    IntPtr hhw = (IntPtr)int.Parse(API.读配置项(API.默认我的文档() + "\\bin\\RuMengRxing.ini", "Set", "Hwd"));
                    if (this.TopMost == true)
                    {
                        API.窗口_置顶(hhw, true);
                    }
                    API.ShowWindow(hhw, 1);
                    API.窗口_置焦点(hhw);
                }

            }
            else
            {
                if (语言选择框.SelectedIndex == 0)
                {
                    API.信息框("窗口工具不存在,请重装软件", "信息:", 5000);
                }
                else if (语言选择框.SelectedIndex == 1)
                {
                    API.信息框("The software does not exist. Please reinstall", "Tips:", 5000);
                }
                else
                {
                    API.信息框("窗口工具不存在,请重装软件", "信息:", 5000);
                }
            }
        }

    
    }
}
