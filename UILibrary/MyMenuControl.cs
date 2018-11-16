using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TCHISEntity;
using TCUtility;

namespace TCUILibrary
{
    public partial class MyMenuControl : TCBaseControl
    {
        SkinButtom menu1 = null;
        SkinButtom menu2 = null;
        SkinButtom menu3 = null;
        SkinButtom menu4 = null;
        public event Action<string> ClickEvent = null;
        //string configPath = Application.StartupPath + "\\Config.ini";
        //string urlConfigPath = Application.StartupPath + "UrlConfig.ini";

        public MyMenuControl():base()
        {
            InitializeComponent();
            LoadMyMenu();
        }

        protected void LoadMyMenu()
        {            
            try
            {
                this.Margin = new System.Windows.Forms.Padding(0);
                this.Padding = new System.Windows.Forms.Padding(0);
                //string section = "MyMenu";
                //string path = Application.StartupPath + "\\Config.ini";
                //string url = TCUtility.IniUtil.ReadIniValue(path, section, Constant.MYMENU_PATIENT);
                string url = Variable.Config.MyPatientsUrl;
                menu1 = GetButton(Constant.MYMENU_PATIENT, url );
                menu1.MouseBack = Image_Over;
                menu1.NormlBack = Image_Normal;
                menu1.DownBack = Image_Down;
                menu1.TextAlign = ContentAlignment.MiddleCenter;
                menu1.Text = Constant.MYMENU_PATIENT;
                //url = TCUtility.IniUtil.ReadIniValue(path, section, Constant.MYMENU_APPOINTMENT);
                url = Variable.Config.MyOrderUrl;
                menu2 = GetButton(Constant.MYMENU_APPOINTMENT , url );
                menu2.MouseBack = Image_Over;
                menu2.NormlBack = Image_Normal;
                menu2.DownBack = Image_Down;
                menu2.Text = Constant.MYMENU_APPOINTMENT;
                menu2.TextAlign = ContentAlignment.MiddleCenter;
                //url = TCUtility.IniUtil.ReadIniValue(path, section, Constant.MYMENU_VISIT);
                url = Variable.Config.MyVisitUrl;
                menu3 = GetButton(Constant.MYMENU_VISIT , url );
                menu3.MouseBack = Image_Down;
                menu3.NormlBack = Image_Normal;
                menu3.DownBack = Image_Down;
                menu3.Text = Constant.MYMENU_VISIT;
                menu3.TextAlign = ContentAlignment.MiddleCenter;
                //url = TCUtility.IniUtil.ReadIniValue(path, section, Constant.MYMENU_CONSULT);
                url = Variable.Config.MyConsultUrl;
                menu4 = GetButton(Constant.MYMENU_CONSULT , url );
                menu4.MouseBack = Image_Down;
                menu4.NormlBack = Image_Normal;
                menu4.DownBack = Image_Down;
                menu4.Text = Constant.MYMENU_CONSULT;
                menu4.TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Clear();
                this.Controls.Add(menu1);
                this.Controls.Add(menu2);
                this.Controls.Add(menu3);
                this.Controls.Add(menu4);
                this.Height = menu1.Height + 5;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
            }
        }


        protected SkinButtom GetButton(string name , string url )
        {
            SkinButtom menu1 = null;
            try
            {
                menu1 = new SkinButtom();
                menu1.DrawType = DrawStyle.Img;
                menu1.Height = 32;
                menu1.Text = name;
                menu1.Margin = new System.Windows.Forms.Padding(0);
                menu1.Padding = new System.Windows.Forms.Padding(0);
                menu1.Cursor = Cursors.Hand;
                menu1.TextAlign = ContentAlignment.MiddleCenter;               
                menu1.Click += new EventHandler(menu1_Click);
                //menu1.Tag = name;
                menu1.Tag = url;
            }
            catch (Exception ex)
            {
                TCUtility.LogHelper.WriteException(ex);
            }
            return menu1;
        }

        void menu1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClickEvent != null)
                {
                    if ((sender as SkinButtom).Tag == null) return;
                    //string menuname = (sender as SkinButtom).Tag.ToString();
                    //string section = "MyMenu";
                    //string path = Application.StartupPath + "\\Config.ini";
                    //string url = TCUtility.IniUtil.ReadIniValue(path, section, menuname);
                    string url = (sender as SkinButtom).Tag.ToString();
                    string menuname = (sender as SkinButtom).Text;

                    if (menuname.Equals("我的预约"))
                    {
                        if (url.LastIndexOf("?") >= 0)
                        {
                            url = url + "&doctorId=" + TCHISEntity.Variable.Employee.userId + "&officeId=" + TCHISEntity.Variable.Employee.officeId;
                        }
                        else
                        {
                            url = url + "?doctorId=" + TCHISEntity.Variable.Employee.userId + "&officeId=" + TCHISEntity.Variable.Employee.officeId;
                        }
                    }

                    ClickEvent(url);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
            }
        }

        private void MyMenuControl_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (menu1 == null || menu2 == null || menu3 == null || menu4 == null) return;
                menu1.Width = menu2.Width = menu3.Width = menu4.Width = this.Width / 4;
                int mwidth = menu1.Width;
                menu1.Width = mwidth;
                int mHeight = menu1.Height;
                int xspace = 0;
                int yspace = 4;
                int x = 0;
                int y = 0;
                Point p = new Point();
                p.X = x + xspace;
                p.Y = y + yspace;
                menu1.Location = p;

                p.X = p.X + mwidth + xspace;
                menu2.Location = p;

                p.X = p.X + mwidth + xspace;
                menu3.Location = p;

                p.X = p.X + mwidth + xspace;
                menu4.Location = p;
            }
            catch (Exception ex)
            {
                TCUtility.LogHelper.WriteException(ex);
            }
        }

        #region Image

        protected Image Image_Normal
        {
            get
            {
                string path = Application.StartupPath + "\\Images\\tab_common_notext.png";
                if (File.Exists(path) == false) return null;
                return Image.FromFile(path);
            }
        }
        protected Image Image_Over
        {
            get
            {
                string path = Application.StartupPath + "\\Images\\tab_over_notext.png";
                if (File.Exists(path) == false) return null;
                return Image.FromFile(path);
            }
        }

        protected Image Image_Down
        {
            get
            {
                string path = Application.StartupPath + "\\Images\\tab_on_notext.png";
                if (File.Exists(path) == false) return null;
                return Image.FromFile(path);
            }
        }

        #endregion 
    }

  
}
