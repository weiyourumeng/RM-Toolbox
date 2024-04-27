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
using static UsbDemo.WmiHelper;

namespace 入梦工具箱
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.Size = new Size(952, 603);
        }
        #region 初始化
        API aPI = new API();
        KeyboardHook k_hook = new KeyboardHook();//实例化键盘钩子
    
        delegate void SetTextCallback(string text);
        private delegate void SetBut();
        MachineNumber usb = new MachineNumber();
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
  
     
        string 功能配置路径 = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Rmdict\\RMbinconfig.ini";

        public void 取全部文件夹路径(string pathname, string path)
        {
            var dir = new DirectoryInfo(path);
            FileInfo[] fil = dir.GetFiles();
            //DirectoryInfo[] dii = dir.GetDirectories();
            foreach (FileInfo f in fil)
            {
                //list.Add(f.FullName);//添加文件的bai路径到列表
                FileStream fs = new FileStream(pathname, FileMode.Append);//文本加入不覆盖
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);//转码
                sw.WriteLine(f.FullName);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
            }
        }//取文件夹路径
        public  void 取文件夹路径(string pathname,string path)
        {
            var dir = new DirectoryInfo(path);
            FileInfo[] fil = dir.GetFiles("*.exe");
            //DirectoryInfo[] dii = dir.GetDirectories();
            foreach (FileInfo f in fil)
            {
                //list.Add(f.FullName);//添加文件的bai路径到列表
                FileStream fs = new FileStream(pathname, FileMode.Append);//文本加入不覆盖
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);//转码
                sw.WriteLine(f.FullName);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
            }
        }//取文件夹路径
 
        private void 滑块条1_位置(object sender, EventArgs e)
        {

            listView1.Size = new Size(767, 483);
            listView1.Location = new Point(6, 130);
            listView1.BackColor = Color.White;
            listView2.Size = new Size(767, 483);
            listView2.Location = new Point(6, 130);
            listView2.BackColor = Color.White;
            listView3.Size = new Size(767, 483);
            listView3.Location = new Point(6, 130);
            listView3.BackColor = Color.White;
            listView4.Size = new Size(767, 483);
            listView4.Location = new Point(6, 130);
            listView4.BackColor = Color.White;
            listView5.Size = new Size(767, 483);
            listView5.Location = new Point(6, 130);
            listView5.BackColor = Color.White;
            listView6.Size = new Size(767, 483);
            listView6.Location = new Point(6, 130);
            listView6.BackColor = Color.White;
            listView7.Size = new Size(767, 483);
            listView7.Location = new Point(6, 130);
            listView7.BackColor = Color.White;
            listView8.Size = new Size(767, 483);
            listView8.Location = new Point(6, 130);
            listView8.BackColor = Color.White;
            listView9.Size = new Size(767, 483);
            listView9.Location = new Point(6, 130);
            listView9.BackColor = Color.White;
            listView10.Size = new Size(767, 483);
            listView10.Location = new Point(6, 130);
            listView10.BackColor = Color.White;
            listView11.Size = new Size(767, 483);
            listView11.Location = new Point(6, 130);
            listView11.BackColor = Color.White;
            panel3.Location = new Point(176, 140);
            panel3.Size = new Size(774, 450);
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
        public static void 程序_延时(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                Application.DoEvents();//转让控制权
            }
        }
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            滑块();
            滑标.Location = new Point(0, 132);
            label27.BackColor = 背景;
            pictureBox14.BackColor = 背景;
            panel4.Visible = true;
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            滑块();
            滑标.Location = new Point(0, 168);
            label4.BackColor = 背景;
            pictureBox9.BackColor = 背景;
            listView1.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            滑块();
            滑标.Location = new Point(0, 204);
            label5.BackColor = 背景;
            pictureBox1.BackColor = 背景;
            listView2.Visible = true;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            滑块();
            滑标.Location = new Point(0, 240);
            label6.BackColor = 背景;
            pictureBox2.BackColor = 背景;
            listView3.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            滑块();
            滑标.Location = new Point(0, 276);
            label7.BackColor = 背景;
            pictureBox4.BackColor = 背景;
            listView4.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            滑块();
            滑标.Location = new Point(0, 312);
            label8.BackColor = 背景;
            pictureBox3.BackColor = 背景;
            listView5.Visible = true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            滑块();
            滑标.Location = new Point(0, 348);
            label9.BackColor = 背景;
            pictureBox8.BackColor = 背景;
            listView6.Visible = true;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            滑块();
            滑标.Location = new Point(0, 384);
            label10.BackColor = 背景;
            pictureBox7.BackColor = 背景;
            listView7.Visible = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            滑块();
            滑标.Location = new Point(0, 420);
            label11.BackColor = 背景;
            pictureBox6.BackColor = 背景;
            listView8.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            滑块();
            滑标.Location = new Point(0, 456);
            label12.BackColor = 背景;
            pictureBox5.BackColor = 背景;
            listView9.Visible = true;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            滑块();
            滑标.Location = new Point(0, 492);
            label13.BackColor = 背景;
            pictureBox12.BackColor = 背景;
            listView10.Visible = true;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            滑块();
            滑标.Location = new Point(0, 528);
            label14.BackColor = 背景;
            pictureBox11.BackColor = 背景;
            listView11.Visible = true;
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            滑块();
            滑标.Location = new Point(0, 565);
            label15.BackColor = 背景;
            pictureBox10.BackColor = 背景;
            panel3.Visible = true;
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

        private void label15_Click(object sender, EventArgs e)
        {
            pictureBox10_Click(sender, e);
        }

        private void label27_Click(object sender, EventArgs e)
        {
            pictureBox14_Click(sender, e);
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

        private void label1_Click(object sender, EventArgs e)
        {
            Directory.Delete(API.默认我的文档() + "\\Rmdict", true);
            API.信息框("初始化成功,重启软件后生效", "信息:", 5000);
            Application.Exit();
        }
        private void 更新_Click(object sender, EventArgs e)
        {
           
        }
       
        private void 透明度_Scroll(object sender, EventArgs e)
        {
            this.Opacity = (float)透明度.Value / 100;
            label3.Text = "透明:" + 透明度.Value.ToString();
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

        private void 选择夹1初始化()
        {
            lines.Clear();
            listView1.Clear();
            Size Bigimagsize = new Size(32, 32);

            imageList1.ImageSize = Bigimagsize;
       
   
                string line = string.Empty;

                using (StreamReader reader = new StreamReader(API.默认我的文档()+"\\Rmdict\\config1.ini", Encoding.UTF8))
                {
                    line = reader.ReadLine();
                    while (line != "" && line != null)
                    {
                        lines.Add(line);
                        line = reader.ReadLine();
                    }
                }

                foreach (string  fileText in lines)
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
                        //DirectoryInfo dir = new DirectoryInfo(fileText);
                        SHGetFileInfo(fileText, (uint)0x80, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 | 0x400));
                        icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
                        DestroyIcon(shfi.hIcon);
                    }

                    if (icon == null)
                    {
                        listView1.Items.Clear();//清空
                        File.WriteAllText(API.默认我的文档() + "\\Rmdict\\config1.ini", string.Empty);
                    }

                    ListViewItem iw = new ListViewItem();   //实例化ListViewItem
                    try
                    {
                        imageList1.Images.Add(icon.ToBitmap());  //图片存入imagelist   
                    }
                    catch
                    {
                       listView1.Items.Clear();//清空
                      File.WriteAllText(API.默认我的文档() + "\\Rmdict\\RMbinconfig.ini", string.Empty);
                  
                    Application.Exit();
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
            Size Bigimagsize = new Size(32, 32);

            imageList2.ImageSize = Bigimagsize;
            if (File.Exists(API.默认我的文档()+"\\Rmdict\\config2.ini") == false)//是文件
            {
                string path = API.默认我的文档()+"\\Rmdict\\config2.ini";
                File.WriteAllText(path, null);
                // File.WriteAllText(path, null, Encoding.UTF8);
            }
            else
            {
                string line = string.Empty;

                using (StreamReader reader = new StreamReader(API.默认我的文档()+"\\Rmdict\\config2.ini", Encoding.UTF8))
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
                        File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config2.ini", string.Empty);
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
                          File.WriteAllText(API.默认我的文档() + "\\Rmdict\\RMbinconfig.ini", string.Empty);
                        Application.Exit();
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
            Size 图片大小 = new Size(32, 32);

            imageList3.ImageSize = 图片大小;

            if (File.Exists(API.默认我的文档()+"\\Rmdict\\config3.ini") == false)//是文件
            {
                string path = API.默认我的文档()+"\\Rmdict\\config3.ini";
               File.WriteAllText(path, null);  
                  // File.WriteAllText(path, null, Encoding.UTF8);
            }
            else
            {
                string line = string.Empty;

                using (StreamReader reader = new StreamReader(API.默认我的文档()+"\\Rmdict\\config3.ini", Encoding.UTF8))
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
                        File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config3.ini", string.Empty);
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
                         File.WriteAllText(API.默认我的文档() + "\\Rmdict\\RMbinconfig.ini", string.Empty);
                       Application.Exit();
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
            Size 图片大小 = new Size(32, 32);

            imageList4.ImageSize = 图片大小;

            if (File.Exists(API.默认我的文档()+"\\Rmdict\\config4.ini") == false)//是文件
            {
                string path = API.默认我的文档()+"\\Rmdict\\config4.ini";
               File.WriteAllText(path, null);  
                  // File.WriteAllText(path, null, Encoding.UTF8);
            }
            else
            {
                string line = string.Empty;

                using (StreamReader reader = new StreamReader(API.默认我的文档()+"\\Rmdict\\config4.ini", Encoding.UTF8))
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
                        File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config4.ini", string.Empty);
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
                         File.WriteAllText(API.默认我的文档() + "\\Rmdict\\RMbinconfig.ini", string.Empty);
                       Application.Exit();
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
            Size 图片大小 = new Size(32, 32);

            imageList5.ImageSize = 图片大小;

            if (File.Exists(API.默认我的文档()+"\\Rmdict\\config5.ini") == false)//是文件
            {
                string path = API.默认我的文档()+"\\Rmdict\\config5.ini";
               File.WriteAllText(path, null);  
                  // File.WriteAllText(path, null, Encoding.UTF8);
              
            }
            else
            {
                string line = string.Empty;

                using (StreamReader reader = new StreamReader(API.默认我的文档()+"\\Rmdict\\config5.ini", Encoding.UTF8))
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
                        File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config5.ini", string.Empty);
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
                         File.WriteAllText(API.默认我的文档() + "\\Rmdict\\RMbinconfig.ini", string.Empty);
                       Application.Exit();
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
            Size 图片大小 = new Size(32, 32);

            imageList6.ImageSize = 图片大小;
            if (File.Exists(API.默认我的文档()+"\\Rmdict\\config6.ini") == false)//是文件
            {
                string path = API.默认我的文档()+"\\Rmdict\\config6.ini";
                File.WriteAllText(path, null);
                // File.WriteAllText(path, null, Encoding.UTF8);
            }
            else
            {
                string line = string.Empty;

                using (StreamReader reader = new StreamReader(API.默认我的文档()+"\\Rmdict\\config6.ini", Encoding.UTF8))
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
                        File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config6.ini", string.Empty);
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
                          File.WriteAllText(API.默认我的文档() + "\\Rmdict\\RMbinconfig.ini", string.Empty);
                        Application.Exit();
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
            Size 图片大小 = new Size(32, 32);
            imageList7.ImageSize = 图片大小;
            if (File.Exists(API.默认我的文档()+"\\Rmdict\\config7.ini") == false)//是文件
            {
                string path = API.默认我的文档()+"\\Rmdict\\config7.ini";
               File.WriteAllText(path, null);  
                  // File.WriteAllText(path, null, Encoding.UTF8);
            }
            else
            {
                string line = string.Empty;

                using (StreamReader reader = new StreamReader(API.默认我的文档()+"\\Rmdict\\config7.ini", Encoding.UTF8))
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
                        File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config7.ini", string.Empty);
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
                         File.WriteAllText(API.默认我的文档() + "\\Rmdict\\RMbinconfig.ini", string.Empty);
                       Application.Exit();
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
            Size 图片大小 = new Size(32, 32);
            imageList8.ImageSize = 图片大小;
            if (File.Exists(API.默认我的文档()+"\\Rmdict\\config8.ini") == false)//是文件
            {
                string path = API.默认我的文档()+"\\Rmdict\\config8.ini";
               File.WriteAllText(path, null);  
                  // File.WriteAllText(path, null, Encoding.UTF8);
            }
            else
            {
                string line = string.Empty;

                using (StreamReader reader = new StreamReader(API.默认我的文档()+"\\Rmdict\\config8.ini", Encoding.UTF8))
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
                        File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config8.ini", string.Empty);
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
                         File.WriteAllText(API.默认我的文档() + "\\Rmdict\\RMbinconfig.ini", string.Empty);
                       Application.Exit();
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
            Size 图片大小 = new Size(32, 32);
            imageList9.ImageSize = 图片大小;
            if (File.Exists(API.默认我的文档()+"\\Rmdict\\config9.ini") == false)//是文件
            {
                string path = API.默认我的文档()+"\\Rmdict\\config9.ini";
               File.WriteAllText(path, null);  
                  // File.WriteAllText(path, null, Encoding.UTF8);
            }
            else
            {
                string line = string.Empty;

                using (StreamReader reader = new StreamReader(API.默认我的文档()+"\\Rmdict\\config9.ini", Encoding.UTF8))
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
                        File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config9.ini", string.Empty);
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
                         File.WriteAllText(API.默认我的文档() + "\\Rmdict\\RMbinconfig.ini", string.Empty);
                       // Application.Exit();
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
            Size 图片大小 = new Size(32, 32);
            imageList10.ImageSize = 图片大小;
            if (File.Exists(API.默认我的文档()+"\\Rmdict\\config10.ini") == false)//是文件
            {
                string path = API.默认我的文档()+"\\Rmdict\\config10.ini";
               File.WriteAllText(path, null);  
                  // File.WriteAllText(path, null, Encoding.UTF8);
            }
            else
            {
                string line = string.Empty;

                using (StreamReader reader = new StreamReader(API.默认我的文档()+"\\Rmdict\\config10.ini", Encoding.UTF8))
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
                        File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config10.ini", string.Empty);
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
                         File.WriteAllText(API.默认我的文档() + "\\Rmdict\\RMbinconfig.ini", string.Empty);
                       Application.Exit();
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
            Size 图片大小 = new Size(32, 32);
            imageList11.ImageSize = 图片大小;
            if (File.Exists(API.默认我的文档()+"\\Rmdict\\config11.ini") == false)//是文件
            {
                string path = API.默认我的文档()+"\\Rmdict\\config11.ini";
               File.WriteAllText(path, null);  
                  // File.WriteAllText(path, null, Encoding.UTF8);
            }
            else
            {
                string line = string.Empty;

                using (StreamReader reader = new StreamReader(API.默认我的文档()+"\\Rmdict\\config11.ini", Encoding.UTF8))
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
                        File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config11.ini", string.Empty);
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
                         File.WriteAllText(API.默认我的文档() + "\\Rmdict\\RMbinconfig.ini", string.Empty);
                       Application.Exit();
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
 
  
        //延迟系统时间，但系统又能同时能执行其它任务，不卡屏延时方法
        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                Application.DoEvents();//转让控制权
            }
        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {//双击打开文件
            string 文件 = listView1.Items[listView1.SelectedItems[0].Index].Name;
            Process.Start(文件); //打开文件夹 
        }
        private void listView1_DragDrop(object sender, DragEventArgs e)
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

            //SetValue("Set", iw.ImageIndex.ToString(), fileText);       //配置命令存路径                         

            FileStream fs = new FileStream(API.默认我的文档()+"\\Rmdict\\config1.ini", FileMode.Append);//文本加入不覆盖

            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);//转码

            sw.WriteLine(fileText);
            
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();

            listView1.Items.Add(iw);//添加图片显示
           
        }

        private void listView2_DragDrop(object sender, DragEventArgs e)
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

            FileStream fs = new FileStream(API.默认我的文档()+"\\Rmdict\\config2.ini", FileMode.Append);//文本加入不覆盖

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
        private void listView2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;

        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string 文件 = listView2.Items[listView2.SelectedItems[0].Index].Name;
           Process.Start(文件); //打开文件夹 

        }

        private void listView3_DragDrop(object sender, DragEventArgs e)
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

            FileStream fs = new FileStream(API.默认我的文档()+"\\Rmdict\\config3.ini", FileMode.Append);//文本加入不覆盖

            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);//转码

            sw.WriteLine(fileText);

            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();

            listView3.Items.Add(iw);//添加图片显示
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
            string 文件 = listView3.Items[listView3.SelectedItems[0].Index].Name;
            Process.Start(文件); //打开文件夹 

        }

        private void listView4_DragDrop(object sender, DragEventArgs e)
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
            imageList4.Images.Add(icon.ToBitmap());//图片存入imagelist  

            ListViewItem iw = new ListViewItem();//实例化ListViewItem
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

            //SetValue("Set", iw.ImageIndex.ToString(), fileText);       //配置命令存路径                         

            FileStream fs = new FileStream(API.默认我的文档()+"\\Rmdict\\config4.ini", FileMode.Append);//文本加入不覆盖

            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);//转码

            sw.WriteLine(fileText);

            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();

            listView4.Items.Add(iw);//添加图片显示

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
            string 文件 = listView4.Items[listView4.SelectedItems[0].Index].Name;
             Process.Start(文件); //打开文件夹 

        }

        private void listView5_DragDrop(object sender, DragEventArgs e)
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

            FileStream fs = new FileStream(API.默认我的文档()+"\\Rmdict\\config5.ini", FileMode.Append);//文本加入不覆盖

            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);//转码

            sw.WriteLine(fileText);

            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();

            listView5.Items.Add(iw);//添加图片显示

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
            string 文件 = listView5.Items[listView5.SelectedItems[0].Index].Name;
           Process.Start(文件); //打开文件夹 
        }

        private void listView6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string 文件 = listView6.Items[listView6.SelectedItems[0].Index].Name;
            Process.Start(文件); //打开文件夹 
        }
        private void listView6_DragDrop(object sender, DragEventArgs e)
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

            FileStream fs = new FileStream(API.默认我的文档()+"\\Rmdict\\config6.ini", FileMode.Append);//文本加入不覆盖

            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);//转码

            sw.WriteLine(fileText);

            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();

            listView6.Items.Add(iw);//添加图片显示

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
            FileStream fs = new FileStream(API.默认我的文档()+"\\Rmdict\\config7.ini", FileMode.Append);//文本加入不覆盖
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);//转码
            sw.WriteLine(fileText);
            sw.Flush();
            sw.Close();
            fs.Close();
            listView7.Items.Add(iw);//添加图片显示

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
            string 文件 = listView7.Items[listView7.SelectedItems[0].Index].Name;
             Process.Start(文件); //打开文件夹 
        }

        private void listView8_DragDrop(object sender, DragEventArgs e)
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
            FileStream fs = new FileStream(API.默认我的文档()+"\\Rmdict\\config8.ini", FileMode.Append);//文本加入不覆盖
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);//转码
            sw.WriteLine(fileText);
            sw.Flush();
            sw.Close();
            fs.Close();
            listView8.Items.Add(iw);//添加图片显示

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
            string 文件 = listView8.Items[listView8.SelectedItems[0].Index].Name;
            Process.Start(文件); //打开文件夹 

        }

        private void listView9_DragDrop(object sender, DragEventArgs e)
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
            FileStream fs = new FileStream(API.默认我的文档()+"\\Rmdict\\config9.ini", FileMode.Append);//文本加入不覆盖
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);//转码
            sw.WriteLine(fileText);
            sw.Flush();
            sw.Close();
            fs.Close();
            listView9.Items.Add(iw);//添加图片显示

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
            string 文件 = listView9.Items[listView9.SelectedItems[0].Index].Name;
           
            Process.Start(文件); //打开文件夹 
        }

        private void listView10_DragDrop(object sender, DragEventArgs e)
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
            FileStream fs = new FileStream(API.默认我的文档()+"\\Rmdict\\config10.ini", FileMode.Append);//文本加入不覆盖
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);//转码
            sw.WriteLine(fileText);
            sw.Flush();
            sw.Close();
            fs.Close();
            listView10.Items.Add(iw);//添加图片显示
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
            string 文件 = listView10.Items[listView10.SelectedItems[0].Index].Name;
             Process.Start(文件); //打开文件夹 
        }

        private void listView11_DragDrop(object sender, DragEventArgs e)
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
            FileStream fs = new FileStream(API.默认我的文档()+"\\Rmdict\\config11.ini", FileMode.Append);//文本加入不覆盖
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);//转码
            sw.WriteLine(fileText);
            sw.Flush();
            sw.Close();
            fs.Close();
            listView11.Items.Add(iw);//添加图片显示
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
            string 文件 = listView11.Items[listView11.SelectedItems[0].Index].Name;
            Process.Start(文件); //打开文件夹 

        }

  

        #endregion
        #region//菜单选项
        private void 删除ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {   
            int Index = 0;
            if (this.listView1.SelectedItems.Count > 0)//判断listview有被选中项
            {
               // MessageBox.Show(listView1.Items[Index].ToString());
                lines.Remove(listView1.Items[listView1.SelectedItems[0].Index].Name);
                Index = listView1.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                listView1.Items[Index].Remove();
                File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config1.ini", string.Empty);//清空
               foreach (string line in lines)
                {   //File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config1.ini",lines, Encoding.UTF8);
                    File.WriteAllLines(API.默认我的文档()+"\\Rmdict\\config1.ini", lines, Encoding.UTF8);
                }
            }
            else if (this.listView2.SelectedItems.Count > 0)//判断listview有被选中项
            {
                lines2.Remove(listView2.Items[listView2.SelectedItems[0].Index].Name);
                Index = listView2.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                listView2.Items[Index].Remove();
                File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config2.ini", string.Empty);//清空
                foreach (string line in lines2)
                {    //File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config2.ini",lines, Encoding.UTF8);
                    File.WriteAllLines(API.默认我的文档()+"\\Rmdict\\config2.ini", lines2, Encoding.UTF8);
                }
            }
            else if (this.listView3.SelectedItems.Count > 0)//判断listview有被选中项
            {
                lines3.Remove(listView3.Items[listView3.SelectedItems[0].Index].Name);
                Index = listView3.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                listView3.Items[Index].Remove();
                File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config3.ini", string.Empty);//清空
                foreach (string line in lines3)
                {  
                    File.WriteAllLines(API.默认我的文档()+"\\Rmdict\\config3.ini", lines3, Encoding.UTF8);
                }
            }
            else if (this.listView4.SelectedItems.Count > 0)//判断listview有被选中项
            {
                lines4.Remove(listView4.Items[listView4.SelectedItems[0].Index].Name);
                Index = listView4.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                listView4.Items[Index].Remove();
                File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config4.ini", string.Empty);//清空
                foreach (string line in lines4)
                {
                    File.WriteAllLines(API.默认我的文档()+"\\Rmdict\\config4.ini", lines4, Encoding.UTF8);
                }
            }
            else if (this.listView5.SelectedItems.Count > 0)//判断listview有被选中项
            {
                lines5.Remove(listView5.Items[listView5.SelectedItems[0].Index].Name);
                Index = listView5.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                listView5.Items[Index].Remove();
                File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config5.ini", string.Empty);//清空
                foreach (string line in lines5)
                {
                    File.WriteAllLines(API.默认我的文档()+"\\Rmdict\\config5.ini", lines5, Encoding.UTF8);
                }
            }
            else if (this.listView6.SelectedItems.Count > 0)//判断listview有被选中项
            {
                lines6.Remove(listView6.Items[listView6.SelectedItems[0].Index].Name);
                Index = listView6.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                listView6.Items[Index].Remove();
                File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config6.ini", string.Empty);//清空
                foreach (string line in lines6)
                {
                    File.WriteAllLines(API.默认我的文档()+"\\Rmdict\\config6.ini", lines6, Encoding.UTF8);
                }
            }
            else if (this.listView7.SelectedItems.Count > 0)//判断listview有被选中项
            {
                lines7.Remove(listView7.Items[listView7.SelectedItems[0].Index].Name);
                Index = listView7.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                listView7.Items[Index].Remove();
                File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config7.ini", string.Empty);//清空
                foreach (string line in lines7)
                {
                    File.WriteAllLines(API.默认我的文档()+"\\Rmdict\\config7.ini", lines7, Encoding.UTF8);
                }
            }
            else if (this.listView8.SelectedItems.Count > 0)//判断listview有被选中项
            {
                lines8.Remove(listView8.Items[listView8.SelectedItems[0].Index].Name);
                Index = listView8.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                listView8.Items[Index].Remove();
                File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config8.ini", string.Empty);//清空
                foreach (string line in lines8)
                {
                    File.WriteAllLines(API.默认我的文档()+"\\Rmdict\\config8.ini", lines8, Encoding.UTF8);
                }
            }
            else if (this.listView9.SelectedItems.Count > 0)//判断listview有被选中项
            {
                lines9.Remove(listView9.Items[listView9.SelectedItems[0].Index].Name);
                Index = listView9.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                listView9.Items[Index].Remove();
                File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config9.ini", string.Empty);//清空
                foreach (string line in lines9)
                {
                    File.WriteAllLines(API.默认我的文档()+"\\Rmdict\\config9.ini", lines9, Encoding.UTF8);
                }
            }
            else if (this.listView10.SelectedItems.Count > 0)//判断listview有被选中项
            {
                lines10.Remove(listView10.Items[listView10.SelectedItems[0].Index].Name);
                Index = listView10.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                listView10.Items[Index].Remove();
                File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config10.ini", string.Empty);//清空
                foreach (string line in lines10)
                {
                    File.WriteAllLines(API.默认我的文档()+"\\Rmdict\\config10.ini", lines10, Encoding.UTF8);
                }
            }
            else if (this.listView11.SelectedItems.Count > 0)//判断listview有被选中项
            {
                lines11.Remove(listView11.Items[listView11.SelectedItems[0].Index].Name);
                Index = listView11.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0       
                listView11.Items[Index].Remove();
                File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config11.ini", string.Empty);//清空
                foreach (string line in lines11)
                {
                    File.WriteAllLines(API.默认我的文档()+"\\Rmdict\\config11.ini", lines11, Encoding.UTF8);
                }
            }

        }
        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {  if (listView1.Visible==true)//判断listview有被选中项
            {
                listView1.Items.Clear();//清空
                File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config1.ini", string.Empty);
            }
            else if (listView2.Visible == true)
            {
                listView2.Items.Clear();//清空
                File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config2.ini", string.Empty);
               
            }
            else if (listView3.Visible == true)
            {
                listView3.Items.Clear();//清空
               File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config3.ini", string.Empty);
              
            }
            else if (listView4.Visible == true)
            {
                listView4.Items.Clear();//清空
                File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config4.ini", string.Empty);
               
            }
            else if (listView5.Visible == true)
            {
                listView5.Items.Clear();//清空
                File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config5.ini", string.Empty);
             
            }
            else if (listView6.Visible == true)
            {
                listView6.Items.Clear();//清空
                File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config6.ini", string.Empty);
                
            }
            else if (listView7.Visible == true)
            {
                listView7.Items.Clear();//清空
               File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config7.ini", string.Empty);
                
            }
            else if (listView8.Visible == true)
            {
                listView8.Items.Clear();//清空
                File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config8.ini", string.Empty);
            
            }
            else if (listView9.Visible == true)
            {
                listView9.Items.Clear();//清空
               File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config9.ini", string.Empty);
            
            }
            else if (listView10.Visible == true)
            {
                listView10.Items.Clear();//清空
                File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config10.ini", string.Empty);
           
            }
            else if (listView11.Visible == true)
            {
                listView11.Items.Clear();//清空
                File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config11.ini", string.Empty);
                
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

        private void CPUZHANYONG()
        {
            string D = null;
            string D2 = null;
            ManagementObjectSearcher searcherd = new ManagementObjectSearcher("Select * From Win32_OperatingSystem");
            foreach (ManagementObject mo in searcherd.Get())
            {
                D += mo["Caption"].ToString() + "; "+ mo["BuildNumber"].ToString() + "; ";        
                D2 += mo["Description"].ToString() ;
            }
            searcherd.Dispose();
            label19.Text = D   + API.系统_64位() + " 位";
            label33.Text = "计算机名: " + D2;
            label28.Text = "设备名: " + Environment.MachineName;
            label18.Text = "用户: " + Environment.UserName;//获取当前用户
            label20.Text = "语言: " + System.Globalization.CultureInfo.InstalledUICulture.Name;
       
        }
        private void 配置初始化()
        {
            if (Directory.Exists(API.默认我的文档() + "\\Rmdict") == false)
            {
                Directory.CreateDirectory(API.默认我的文档() + "\\Rmdict");//创建新路径
                File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config1.ini", null);
                File.WriteAllText(API.默认我的文档() + "\\Rmdict\\RMbinconfig.ini", null, Encoding.UTF8);
               
            }
            else
            {
                if (File.Exists(API.默认我的文档() + "\\Rmdict\\RMbinconfig.ini") == false)
                {
                    File.WriteAllText(API.默认我的文档() + "\\Rmdict\\RMbinconfig.ini", null, Encoding.UTF8);
                 
                }
                if (File.Exists(API.默认我的文档()+"\\Rmdict\\config1.ini") == false)//是文件
                {
                    File.WriteAllText(API.默认我的文档()+"\\Rmdict\\config1.ini", null);
                    API.写配置项(功能配置路径, "Set", "tabPage1", "0");
                }
            } 
            if (API.读配置项(功能配置路径, "Set", "F12") == "1")
            {
                checkBox1.Checked = true;
            }

            if (API.读配置项(功能配置路径, "Set", "Top") == "1")
            {
                窗口置顶.Checked = true;
                this.TopMost = true;
            }
            API.写配置项(功能配置路径, "Set", "Hwd", this.Handle.ToString());


        }
        private void 初始化全部()
        {
            if (Directory.Exists( "tool") ==true)
            {
                if (API.读配置项(功能配置路径, "Set", "tabPage1") != "1")
                {
                    API.写配置项(功能配置路径, "Set", "tabPage1", "1");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config1.ini", "tool//处理器工具//CPUZ");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config1.ini", "tool//处理器工具//Prime95");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config1.ini", "tool//处理器工具//superpi");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config1.ini", "tool//处理器工具//wPrime");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config1.ini", "tool//处理器工具//XIANGQI");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config1.ini", "tool//处理器工具//线程炸弹");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config1.ini", "tool//处理器工具//cinebenchr23pjbxz");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config1.ini", "tool//综合检测//aida64");
                    取全部文件夹路径(API.默认我的文档()+"\\Rmdict\\config1.ini", "tool//其他工具//CPU天梯图");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config2.ini", "tool//综合检测//aida64");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config3.ini", "tool//内存工具//memtest");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config3.ini", "tool//内存工具//memtestpro");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config3.ini", "tool//内存工具//Thaiphoon");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config3.ini", "tool//内存工具//魔方内存盘");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config4.ini", "tool//显卡工具//GPUZ");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config4.ini", "tool//显卡工具//AMDGPUClockTool");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config4.ini", "tool//显卡工具//DDU v18.0.1.9");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config4.ini", "tool//显卡工具//gpuinfo");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config4.ini", "tool//显卡工具//GpuTest_Windows x64");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config4.ini", "tool//显卡工具//nvidiaInspector");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config4.ini", "tool//烤鸡工具//FurMark");
                    取全部文件夹路径(API.默认我的文档()+"\\Rmdict\\config4.ini", "tool//其他工具//显卡天体图");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config5.ini", "tool//硬盘工具//ASSSDBenchmark");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config5.ini", "tool//硬盘工具//ATTODISKBENCHMARK");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config5.ini", "tool//硬盘工具//CrystalDiskInfo");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config5.ini", "tool//硬盘工具//CrystalDiskMark");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config5.ini", "tool//硬盘工具//Defraggler");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config5.ini", "tool//硬盘工具//DiskGenius");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config5.ini", "tool//硬盘工具//finaldata");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config5.ini", "tool//硬盘工具//H2testw");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config5.ini", "tool//硬盘工具//HDTune");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config5.ini", "tool//硬盘工具//LLFTOOL");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config5.ini", "tool//硬盘工具//mydisktest");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config5.ini", "tool//硬盘工具//ssdlife");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config5.ini", "tool//硬盘工具//SSDZ");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config5.ini", "tool//硬盘工具//URWTEST");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config5.ini", "tool//硬盘工具//魔方数据恢复");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config6.ini", "tool//显示器工具//displayx");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config6.ini", "tool//显示器工具//色域检测");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config7.ini", "tool//综合检测//aida64");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config7.ini", "tool//综合检测//hwinfo");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config7.ini", "tool//综合检测//RWEverything");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config7.ini", "tool//综合检测//speccy");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config7.ini", "tool//综合检测//图拉丁硬件检测");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config8.ini", "tool//外设工具//Keyboard Test Utility");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config8.ini", "tool//外设工具//鼠标单机变双击测试器");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config9.ini", "tool//烤鸡工具//FurMark");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config9.ini", "tool//综合检测//aida64");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config9.ini", "tool//处理器工具//Prime95");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config9.ini", "tool//处理器工具//cinebenchr23pjbxz");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config10.ini", "tool//其他工具//bluescreenview");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config10.ini", "tool//其他工具//ChipGenius");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config10.ini", "tool//其他工具//CoreTemp");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config10.ini", "tool//其他工具//Dism++");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config10.ini", "tool//其他工具//ULTRAISO");
                    取文件夹路径(API.默认我的文档()+"\\Rmdict\\config10.ini", "tool//其他工具//图拉丁KMS");
                    //取文件夹路径(API.默认我的文档()+"\\Rmdict\\config10.ini", "tool//其他工具//base");
                    //取文件夹路径(API.默认我的文档()+"\\Rmdict\\config10.ini", "tool//其他工具//ExeinfoPE");
                    //取文件夹路径(API.默认我的文档()+"\\Rmdict\\config10.ini", "tool//其他工具//HAPEiD_jb51");
                }
            }
          
        }
        private void chushihua()
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
            try
            {
                
                textBox2.Text =  MachineNumber.系统_CPU名称信息() ;
                textBox1.Text = Screen.PrimaryScreen.Bounds.Width + " * " + Screen.PrimaryScreen.Bounds.Height;
                string D = null;
                double capacity = 0;
                ManagementObjectSearcher searcherd = new ManagementObjectSearcher("Select * From Win32_PhysicalMemory");
                foreach (ManagementObject mo in searcherd.Get())
                {
                    capacity = Math.Round(Int64.Parse(mo.Properties["Capacity"].Value.ToString()) / 1024 / 1024 / 1024.0, 1);
                    D += mo["manufacturer"].ToString()+"; "+ capacity.ToString() + "G" + " (" + mo["Speed"].ToString() + "MHz) " + "; ";
                    
                }
                searcherd.Dispose();
                textBox3.Text = D  + "共"  + MachineNumber.获取内存条大小() + "G ";                
                textBox4.Text = MachineNumber.系统_主板型号();
                textBox5.Text = MachineNumber.取显卡信息();             
                string C = null;
                double capacity1 = 0;
                ManagementObjectSearcher searcherC = new ManagementObjectSearcher("Select * From Win32_DiskDrive");
                foreach (ManagementObject mo in searcherC.Get())
                {  capacity1 = Math.Round(Int64.Parse(mo.Properties["Size"].Value.ToString()) / 1024 / 1024 / 1024.0);
                    C += mo["model"].ToString() + "; 容量:"+ capacity1.ToString() + "G; ";
                }
                searcherC.Dispose();
                textBox8.Text = C;//硬盘
                string a = null;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_SoundDevice");
            foreach (ManagementObject mo in searcher.Get())
            { a += mo["Name"].ToString() + "; ";
                }
                searcher.Dispose();
                textBox7.Text =  a ;//取到声卡
                string b = null;
                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();//获取本地计算机上网络接口的对象 
                foreach (NetworkInterface adapter in adapters)
                {//";名称:" + adapter.Name  + ";速度:" + adapter.Speed * 0.001 * 0.001 + "M" +
                    b += adapter.Description + "; ";                    
                }
                textBox6.Text =  b ;//取到网卡
                label2.Text="复制此页";
            }
            catch
            {
                label2.Text = "未取到信息";
            }
            DriveInfo[] allDirves = DriveInfo.GetDrives();//检索计算机上的所有逻辑驱动器名称
            string E = null;
            double capacity2;
            double capacity3 ;
            foreach (DriveInfo item in allDirves)
            {
                //Fixed 硬盘
                //Removable 可移动存储设备，如软盘驱动器或USB闪存驱动器。
                //Console.Write(item.Name + "---" + item.DriveType);
                if (item.IsReady)
                {
                    capacity2 = Math.Round(Int64.Parse(item.TotalSize.ToString()) / 1024 / 1024 / 1024.0);
                    capacity3= Math.Round(Int64.Parse(item.TotalFreeSpace.ToString()) / 1024 / 1024 / 1024.0);
                    E += item.Name + " 容量: " + capacity2.ToString() + "G , 可用大小: " + capacity3.ToString() +"G"+ "\r\n";
                }
            }
            textBox9.Text = E;
            //label35.Text = "时区:           " + MachineNumber.系统_时区();

        }
        const string 版本 = "1";       
        private void Form1_Load(object sender, EventArgs e)//程序被创建
        {
            Thread t1 = new Thread(chushihua);
            t1.Start();
            Thread t2 = new Thread(CPUZHANYONG);
            t2.Start();
            k_hook.KeyDownEvent += new KeyEventHandler(inthook);//添加键盘事件
            k_hook.Start();//安装键盘钩子
            滑块条1_位置(sender, e);
            透明度_Scroll(sender, e);
            配置初始化();
            初始化全部();
            选择夹1初始化();
            label29.Text = "V" + 版本 + ".0";
            panel4.Visible = true;
            Thread t = new Thread(选择夹初始化);
            t.Start();
        }
        private void 选择夹初始化()
        {
            string 服务器版本 = API.网页_访问("http://a.bianshengruanjian.com/入梦工具箱/Ver.txt");
            当前版本.Text = "当前版本V" + 版本 + ".0";
            
            if (服务器版本 == null)
            {
                最新版本.Text = "无法链接服务器";
            }
            else 最新版本.Text = "最新版本V" + 服务器版本 + ".0";
            
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
        private void 滑块()
        {
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
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (label2.Text != "......")
            {
                string txt = label23.Text + "     " + textBox2.Text + "\r\n" + label24.Text + "        " + textBox3.Text + "\r\n" + label25.Text + "        " + textBox4.Text + "\r\n" + label26.Text + "        " + textBox5.Text + "\r\n" + label30.Text + "        " + textBox8.Text + "\r\n" + label32.Text + "        " + textBox7.Text + "\r\n" + label31.Text + "        " + textBox6.Text ;               
                Clipboard.SetDataObject(txt);
                label2.Text = "已复制";
                程序_延时(1000);
                label2.Text = "复制此页";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

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

        private void label21_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.bianshengruanjian.com/html/yuanchuangruanjian/2021/1010/47.html");
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
    }
}
