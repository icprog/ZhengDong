using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TCUILibrary
{
    public partial class TCPopupForm : Form
    {
        public const Int32 AW_HOR_POSITIVE = 0x00000001;//从左到右打开窗口  
        public const Int32 AW_HOR_NEGATIVE = 0x00000002;//从右到左打开窗口
        public const Int32 AW_VER_POSITIVE = 0x00000004;//从上到下打开窗口
        public const Int32 AW_VER_NEGATIVE = 0x00000008;//从下到上打开窗口
        public const Int32 AW_CENTER = 0x00000010;
        public const Int32 AW_HIDE = 0x00010000;
        public const Int32 AW_ACTIVATE = 0x00020000;//在窗体打开后不失去焦点
        public const Int32 AW_SLIDE = 0x00040000;
        public const Int32 AW_BLEND = 0x00080000;//淡入淡出效果
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        private string information = null;//要在窗体中显示的信息
        public TCPopupForm(string info)
        {
            InitializeComponent();
            information = info;
            this.timer2.Enabled = true;//启动时间
        }
        private void TCPopupForm_Load(object sender, EventArgs e)
        {
            try
            {
                int x = Screen.PrimaryScreen.WorkingArea.Size.Width - this.Width;
                int y = Screen.PrimaryScreen.WorkingArea.Size.Height - this.Height;
                this.SetDesktopLocation(x, y);
                this.tcLabel1.Text = information;
                AnimateWindow(this.Handle, 1000, AW_VER_NEGATIVE | AW_ACTIVATE);//从下到上且不占其它程序焦点
                this.timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
            }
        }
        int count = 0;//计数器
        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if (count == 50)//5s关闭提示窗体
            {
                count = 0;
                AnimateWindow(this.Handle, 1000, AW_BLEND | AW_HIDE);
                this.Close();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.tcLabel2.Text = DateTime.Now.ToString("F");
        }
        private void barForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//左键点击
            {
                if (Screen.PrimaryScreen.WorkingArea.Size.Width - e.X < 10 &&
                Screen.PrimaryScreen.WorkingArea.Size.Height - e.Y < 10)//有效范围判断
                {
                    AnimateWindow(this.Handle, 1000, AW_BLEND | AW_HIDE);
                    this.Close();
                }
            }
        }
    }
}
