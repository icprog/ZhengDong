using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TCUtility;

namespace TCUILibrary
{
    public partial class LeftMenuControl : TCBaseControl
    {
        public event Action<string> ClickEvent = null;

        public LeftMenuControl():base()
        {
            InitializeComponent();
            LoadMenu();
        }

        protected void LoadMenu()
        {
            TCGlassButton menu1 = GetMenu("HIS");
            TCGlassButton menu3 = GetMenu("CRM");
            TCGlassButton menu4 = GetMenu("SCM");
            TCGlassButton menu5 = GetMenu("eYar门户");

            this.Controls.Clear();

            Point p = new Point();
            int xspace = 1;
            int yspace = 15;
            p.X = this.Location.X + xspace;
            p.Y = this.Location.Y + yspace;
            menu1.Location = p;
            MeasureTextSize(menu1);          
            this.Controls.Add(menu1);
            p.Y = p.Y + menu1.Height + yspace;
            menu3.Location = p;
            MeasureTextSize(menu3);
            this.Controls.Add(menu3);
            p.Y = p.Y + menu3.Height + yspace;
            menu4.Location = p;
            MeasureTextSize(menu4);
            this.Controls.Add(menu4);
            p.Y = p.Y + menu4.Height + yspace;
            menu5.Location = p;
            MeasureTextSize(menu5);
            this.Controls.Add(menu5);
        }

        private void  MeasureTextSize(TCGlassButton btn )
        {
            string text = btn.Text;
            int theight = (int)btn.Font.GetHeight()+25;
            int twidth = this.Width -20;
            int len = text.Length;
            int stidx = 0;
            for (int i = 1; i <= len; i++)
            {
                int slen = i - stidx-1;
                string str = text.Substring(stidx , slen );
                Size msize = TextRenderer.MeasureText(str , btn.Font );
                int h = msize.Height;
                int w = msize.Width;
                int wid = btn.Location.X * 2 + w;
                if (wid < this.Width)
                {
                    continue;
                }
                else
                {
                    theight += h+ 10;
                    stidx = i-1;
                }
            }

            btn.Width = twidth;
            btn.Height = theight;
            btn.Left =( Width - twidth)/2;
        }

        protected TCGlassButton GetMenu(string menuname)
        {       
            TCGlassButton menu = new TCGlassButton();            
            menu.Cursor = Cursors.Hand;          
            menu.Text = menuname;
            menu.AutoSize = false;
            menu.Tag = menuname;
            menu.Click += new EventHandler(menu_Click);

            return menu;
        }

        void menu_Click(object sender, EventArgs e)
        {
            if (ClickEvent != null)
            {
                if( (sender as Button ).Tag == null ) return;
                string menuname = (sender as Button).Tag.ToString();
                string section = "LeftMenu";
                string path = Application.StartupPath + "\\Config.ini";
                string url = IniUtil.ReadIniValue(path, section, menuname );
                ClickEvent( url );
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            DrawLine(e.Graphics, e.ClipRectangle);
        }
        /// <summary>
        /// 画右侧直线
        /// </summary>
        /// <param name="g"></param>
        protected void DrawLine(Graphics g , Rectangle rec )
        {
            Point point1 = new Point( rec.Right -1 , rec.Top);
            Point point2 = new Point(rec.Right -1  , rec.Bottom );
            g.DrawLine(new Pen(Color.Silver), point1, point2);
        }

        private void LeftMenuControl_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}

