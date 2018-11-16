using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FishClient
{
    public partial class FormLogin : FormBase
    {
        public FormLogin()
        {
            InitializeComponent();

            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            tcCheckBox1.BackColor = Color.Transparent;
            lblTipInfo.BackColor = Color.Transparent;
            lblTipPwd.BackColor = Color.Transparent;
            lblTipUser.BackColor = Color.Transparent;

            btnOk.DrawType = UILibrary.DrawStyle.Img;
            btnCancel.DrawType = UILibrary.DrawStyle.Img;

            //string imagePath = Application.StartupPath + "\\Images\\blue_button_normal.png";
            //if (File.Exists(imagePath))
            //{
            //    btnOk.NormlBack = Image.FromFile(imagePath);
            //}
            //string downPath = Application.StartupPath + "\\Images\\blue_button_down.png";
            //if (File.Exists(downPath))
            //{
            //    btnOk.DownBack = Image.FromFile(downPath);
            //}
            //string hoverPath = Application.StartupPath + "\\Images\\blue_button_hover.png";
            //if (File.Exists(downPath))
            //{
            //    btnOk.MouseBack = Image.FromFile(downPath);
            //}

            SetButtomImage(btnOk);

            SetButtomImageGray(btnCancel);

            

            //imagePath = Application.StartupPath + "\\Images\\gray_button_normal.png";
            //if (File.Exists(imagePath))
            //{
            //    btnCancel.NormlBack = Image.FromFile(imagePath);
            //}
            //downPath = Application.StartupPath + "\\Images\\gray_button_down.png";
            //if (File.Exists(downPath))
            //{
            //    btnCancel.DownBack = Image.FromFile(downPath);
            //}
            //hoverPath = Application.StartupPath + "\\Images\\gray_button_hover.png";
            //if (File.Exists(downPath))
            //{
            //    btnCancel.MouseBack = Image.FromFile(downPath);
            //}

            //string logoPath = Application.StartupPath + "\\Images\\logo.jpg";
            //if (File.Exists(logoPath))
            //{
            //    pictureBox1.Image = Image.FromFile(logoPath);
            //}

            //string bgPath = Application.StartupPath + "\\Images\\bg.png";
            //if (File.Exists(bgPath))
            //{
            //    this.BackgroundImage = Image.FromFile(bgPath);
            //}

            //string ipath = Application.StartupPath + "\\Images\\btn_mini_down.png";
            //if (File.Exists(ipath))
            //{
            //    this.MiniDownBack = Image.FromFile(ipath);
            //}
            //ipath = Application.StartupPath + "\\Images\\btn_mini_hover.png";
            //if (File.Exists(ipath))
            //{
            //    this.MiniMouseBack = Image.FromFile(ipath);
            //}
            //ipath = Application.StartupPath + "\\Images\\btn_mini_normal.png";
            //if (File.Exists(ipath))
            //{
            //    this.MiniNormlBack = Image.FromFile(ipath);
            //}

            //ipath = Application.StartupPath + "\\Images\\close_btn_down.png";
            //if (File.Exists(ipath))
            //{
            //    this.CloseDownBack = Image.FromFile(ipath);
            //}
            //ipath = Application.StartupPath + "\\Images\\close_btn_hover.png";
            //if (File.Exists(ipath))
            //{
            //    this.CloseMouseBack = Image.FromFile(ipath);
            //}
            //ipath = Application.StartupPath + "\\Images\\close_btn_normal.png";
            //if (File.Exists(ipath))
            //{
            //    this.CloseNormlBack = Image.FromFile(ipath);
            //}

            lblTipPwd.Visible = false;
            lblTipUser.Visible = false;
            lblTipInfo.Visible = false;
            lblTipUser.Text = lblTipPwd.Text = lblTipInfo.Text = string.Empty;

            FishEntity.PersonEntity u = UserManager.LoadUsers();
            if (u != null)
            {
                txtUserName.Text = u.username;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            lblTipInfo.Visible = lblTipPwd.Visible = lblTipUser.Visible = false;
            bool isOk = true;
            if( string.IsNullOrEmpty( txtUserName.Text ))
            {
                lblTipUser.Text = "请输入用户名";
                lblTipUser.Visible = true;
                isOk = false;
                txtUserName.Focus();
            }
            if( string.IsNullOrEmpty( txtPassword.Text ))
            {
                lblTipPwd.Text = "请输入密码";
                lblTipPwd.Visible = true;
                isOk = false;
                txtPassword.Focus();
            }

            if( isOk == false )
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

            string username = txtUserName.Text.Trim ();
            string password = txtPassword.Text;
            string pwdMD5 = Utility.DesEncryptUtil.EncryptMD5( password );
             
            FishBll.Bll.PersonBll bll = new FishBll.Bll.PersonBll();
            FishEntity.PersonEntity entity = bll.Login(username, pwdMD5);

            if (entity == null)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                lblTipInfo.Text = "登录失败，用户名或密码错误";
                lblTipInfo.Visible = true;
            }

            FishEntity.Variable.User = entity;

            SaveUser(entity);
        }

        protected void SaveUser( FishEntity.PersonEntity u )
        {
            if (tcCheckBox1.Checked)
            {
                UserManager.SaveUser(u);
            }
            else
            {
                UserManager.Delete(u);
            }
        }

        private void FormLogin_SysBottomClick(object sender)
        {
            VisPanel();
        }

        protected bool Check()
        {
            string ip = txtIP.Text.Trim();
            string port = txtPort.Text.Trim();
            string dbusername = txtDBUserName.Text.Trim();
            string dbpassword = txtDBPassword.Text.Trim();

            lblTipDBIP.Visible = lblTipDBUserName.Visible = lblTipDBPassword.Visible = lblTipDBPort.Visible = false;

            string msg = string.Empty;

            bool pass = true;
            bool isok = Utility.ValidateUtil.ValidateIP(ip, ref msg);
            if (isok == false)
            {
                lblTipDBIP.Visible = true;
                lblTipDBIP.Text = msg;
                pass = false;
            }

            isok = Utility.ValidateUtil.ValidatePort(port, ref msg);
            if (isok == false)
            {
                lblTipDBPort.Visible = true;
                lblTipDBPort.Text = msg;
                pass = false;
            }

            if (string.IsNullOrEmpty(dbusername))
            {
                lblTipDBUserName.Visible = true;
                lblTipDBUserName.Text = "请输入数据库用户名";
                pass = false;
            }
            if (string.IsNullOrEmpty(dbpassword))
            {
                lblTipDBPassword.Visible = true;
                lblTipDBPassword.Text = "请输入数据库密码";
                pass = false;
            }

            return pass;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.None;

            if (Check() == false)
            {
                return;
            }

            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Config.ini";
            string ip = txtIP.Text.Trim();
            string port = txtPort.Text.Trim();
            string dbusername = txtDBUserName.Text.Trim();
            string dbpassword = txtDBPassword.Text.Trim();
            string dbpasswordEx = Utility.DesEncryptUtil.EncryptDES(dbpassword, FishEntity.Constant.KEY);

            Utility.IniUtil.WriteIniValue(path, "DB", "host",ip);
            Utility.IniUtil.WriteIniValue(path, "DB", "port",port );
            Utility.IniUtil.WriteIniValue(path, "DB", "dbname","fish" );
            Utility.IniUtil.WriteIniValue(path, "DB", "user", dbusername);
            Utility.IniUtil.WriteIniValue(path, "DB", "password", dbpasswordEx );

            VisPanel();
        }

        protected void VisPanel()
        {
            bool vis = panel1.Visible;
            panel1.Visible = panel2.Visible;
            panel2.Visible = vis;
        }

        private void btnSetCancel_Click(object sender, EventArgs e)
        {
            VisPanel();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {                
            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Config.ini";         
            string ip = Utility.IniUtil.ReadIniValue(path, "DB", "host");
            string port = Utility.IniUtil.ReadIniValue(path, "DB", "port");
            string user = Utility.IniUtil.ReadIniValue(path, "DB", "user");
            string password = Utility.IniUtil.ReadIniValue(path, "DB", "password");

            string passwordEx = Utility.DesEncryptUtil.DecryptDES(password, FishEntity.Constant.KEY);

            txtIP.Text = ip;
            txtPort.Text = string.IsNullOrEmpty ( port)? "3306": port ;
            txtDBUserName.Text = user;
            txtDBPassword.Text = passwordEx;
        }
    }
}
