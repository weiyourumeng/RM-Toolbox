using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 入梦工具箱;

namespace 入梦语音包
{
    public partial class 自定义列表 : Form
    {
        #region 图片移动

        private void 常规_离开(object sender, EventArgs e)
        {
            关闭.BackgroundImage = Properties.Resources.X常规;
        }
        private void 常规_点燃(object sender, EventArgs e)
        {
            关闭.BackgroundImage = Properties.Resources.X点燃;
        }
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
        #endregion
        public 自定义列表()
        {
            InitializeComponent();
        }

        private void 关闭_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void 自定义列表_Load(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            label4.Text= form1.label4.Text;
            label5.Text = form1.label5.Text;
            label6.Text = form1.label6.Text;
            label7.Text = form1.label7.Text;
            label8.Text = form1.label8.Text;
            label9.Text = form1.label9.Text;
            label10.Text = form1.label10.Text;
            label11.Text = form1.label11.Text;
            label12.Text = form1.label12.Text;
            label13.Text = form1.label13.Text;
            label14.Text = form1.label14.Text;

        }
    }
}
