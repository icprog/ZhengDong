using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms;

using FishEntity;
using TCUtility;

namespace UILibrary
{
    /// <summary>
    /// 登录控件
    /// </summary>
    public partial class TCLoginControl : TCBaseControl
    {
        public event EventHandler<LoginEventArgs> LoginEvent = null;
        public event EventHandler NetSettingEvent = null;
        List<UserEntity> _list = null;
        UserDropDownControl.UserInfoDropDown _dropdown = null;

        public TCLoginControl()
        {
            try
            {
                InitializeComponent();

                LoadItems();
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
            }
        }

        public void LoadItems()
        {
            Image img = ImageUtil.GetImage("blue_button_down.png");
            if ( img !=null )
            {
                btnLogin.DownBack = img;
            }
            img = ImageUtil.GetImage("blue_button_hover.png");
            if (img !=null )
            {
                btnLogin.MouseBack = img;
            }
            img = ImageUtil.GetImage("blue_button_normal.png");
            if (img !=null )
            {
                btnLogin.NormlBack = img;
                btnLogin.ForeColor = Color.White;
            }

            img = ImageUtil.GetImage("key-ico.png");
            if (img != null)
            {
                txtPwd.LeftIcon = img;
            }
            img = ImageUtil.GetImage("id-ico.png");
            if (img != null)
            {
                txtUser.LeftIcon = img;
            }
            img = ImageUtil.GetImage("exten-normal-ico.png");
            if (img != null)
            {
                txtUser.Icon = img;
                txtUser.IconIsButton = true;
            }

            avatarControl1.SetAvatar(ImageUtil.GetDoctorDefaultImage());
            _list = UserMessage.LoadUsers();
            if (_list == null || _list.Count < 1) return;

            menuUser.Items.Clear();
            List<string> usernameList = new List<string>();
            foreach (UserEntity u in _list)
            {
                ToolStripMenuItem menu = new ToolStripMenuItem(u.UserCode + "\n" + u.UserName);
                menu.AutoSize = false;
                menu.Size = new System.Drawing.Size(this.Width, 45);
                menu.Tag = u;
                menu.Click += new EventHandler(menu_Click);
                menuUser.Height += 45;
                if (u.Photo != null) menu.Image = u.Photo;
                menuUser.Items.Add(menu);

                usernameList.Add(u.UserCode);
            }

            InitUserDropDownControl(usernameList);   
          
        }

        protected void InitUserDropDownControl(List<string> usernameList)
        {
            _dropdown = new UserDropDownControl.UserInfoDropDown(_list);
            _dropdown.ParentControl = this;
            _dropdown.UserClick += new EventHandler<LoginEventArgs>(_dropdown_UserClick);
            txtUser.AutoCompleteMode = AutoCompleteMode.Append;
            txtUser.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection nameCollection = new AutoCompleteStringCollection();
            nameCollection.AddRange(usernameList.ToArray());
            txtUser.AutoCompleteCustomSource = nameCollection;
        }

        void _dropdown_UserClick(object sender, LoginEventArgs e)
        {
            SetInfo(e.User);
        }

        void menu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = sender as ToolStripMenuItem;
            UserEntity u = menu.Tag as UserEntity;
            SetInfo(u);
        }

        protected void SetInfo(UserEntity user)
        {
            if (user != null)
            {
                txtUser.Text = user.UserCode;
                if (user.Remember)
                {
                    txtPwd.Text = user.Password;
                }
                chkRemember.Checked = user.Remember;
                chkAuto.Checked = user.AutoLogin;
                avatarControl1.SetAvatar( user.Photo);

                if (user.AutoLogin) Login();
            }
        }

        private void TCLoginControl_SizeChanged(object sender, EventArgs e)
        {
            ChangeLocation();
        }

        protected void ChangeLocation()
        { 
            Point p = new Point();
            p.X = (this.Width - avatarControl1.Width) / 2;
            p.Y = 25;
            avatarControl1.Location = p;
            //
            p.X = (this.Width - this.txtUser.Width) / 2;
            p.Y = p.Y + avatarControl1.Height + 30;
            tcLabelUSER.Location = p;
            //
            p.X = (this.Width - this.txtUser.Width) / 2;
            p.Y = p.Y + tcLabelUSER.Height + 10;
            txtUser.Location = p;
            //
            p.X = (this.Width - this.txtPwd.Width) / 2;
            p.Y = p.Y + txtUser.Height + 10;
            tcLabelPWD.Location = p;
            //
            p.X = (this.Width - this.txtPwd.Width) / 2;
            p.Y = p.Y + tcLabelPWD.Height + 10;
            txtPwd.Location = p;
            //
            p.X = (this.Width - chkRemember.Width - 20 - chkAuto.Width) / 2;
            p.Y = p.Y + txtPwd.Height + 20;
            chkRemember.Location = p;
            //
            p.X = p.X + chkRemember.Width + 20;
            chkAuto.Location = p;
            //
            p.X = (this.Width - btnLogin.Width) / 2;
            p.Y = p.Y + chkRemember.Height + 30;
            btnLogin.Location = p;

            //
            int totalheight = p.Y + btnLogin.Height + 30 + lblRegister.Height + 10 + lblSetting.Height + 10;
            if (totalheight < this.Height)
            {
                p.Y = this.Height - lblSetting.Height - 10 - 10 - lblRegister.Height;
            }
            else
            {
                p.Y = p.Y + btnLogin.Height + 30;
            }

            p.X = (this.Width - this.lblRegister.Width - 5 - lblFindPwd.Width) / 2;
            lblRegister.Location = p;

            //
            p.X = p.X + this.lblRegister.Width + 5;
            lblFindPwd.Location = p;
            //
            p.X = (this.Width - this.lblSetting.Width - 5 - lblHelp.Width) / 2;
            p.Y = p.Y + lblRegister.Height + 10;
            lblSetting.Location = p;
            //
            p.X = p.X + this.lblSetting.Width + 5;
            lblHelp.Location = p;
            //           

            lblFindPwd.Visible = lblHelp.Visible = lblRegister.Visible = lblSetting.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        protected void Login()
        {
            try
            {
                pnlTipUser.Visible = pnlTipPwd.Visible = false;
                bool isok = true;
                if (string.IsNullOrEmpty(txtUser.Text.Trim()))
                {
                    pnlTipUser.Visible = true;
                    pnlTipUser.Width = txtUser.Width-2;
                    lblTipUser.Text = "请输入账号。";
                    pnlTipUser.Left = txtUser.Left;
                    pnlTipUser.Top = txtUser.Bottom;                     
                    txtUser.Focus();
                    isok = false;
                }
                if (string.IsNullOrEmpty(txtPwd.Text.Trim()))
                {
                    pnlTipPwd.Visible = true;
                    pnlTipPwd.Width = txtPwd.Width;
                    lblTipPwd.Text = "请输入密码。";
                    pnlTipPwd.Left = txtPwd.Left;
                    pnlTipPwd.Top = txtPwd.Bottom;
                    txtPwd.Focus();
                    isok = false;
                }
                if (isok == false) return;

                if (LoginEvent != null)
                {
                    UserEntity user = GetUser(txtUser.Text.Trim());
                    user.UserCode = txtUser.Text.Trim();
                    user.UserName = user.UserCode;
                    user.Password = txtPwd.Text.Trim();
                    user.Remember = chkRemember.Checked;
                    user.AutoLogin = chkAuto.Checked;              
                    LoginEvent(this, new LoginEventArgs(user));
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
            }
        }

        protected UserEntity GetUser(string usercode)
        {
            UserEntity user = null;
            if (_list != null)
            {
                foreach (UserEntity entity in _list)
                {
                    if (entity.UserCode.Equals(usercode))
                    {
                        user = entity;
                        break;
                    }
                }
            }
            if (user == null)
            {
                user = new UserEntity();
                user.Photo = ImageUtil.GetDoctorDefaultImage();
            }
            return user;
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected void SetItemSelectState()
        {
            string code = txtUser.Text.Trim();
            foreach (ToolStripMenuItem item in menuUser.Items)
            {
                if (item.Tag is UserEntity)
                {
                    if ((item.Tag as UserEntity).UserCode.Equals(code))
                    {
                        item.Select();
                    }
                }
            }
        }

        private void TCLoginControl_Load(object sender, EventArgs e)
        {
            if (_list != null && _list.Count > 0)
            {
                SetInfo(_list[0]);
            }
        }
        /// <summary>
        /// 网络设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblSetting_Click(object sender, EventArgs e)
        {
            if (NetSettingEvent != null)
            {
                NetSettingEvent(this, EventArgs.Empty);
            }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
            else if (e.KeyCode == Keys.Down)
            {
                _dropdown.Show(txtUser.Text.Trim(), txtUser);
            }
        }

        private void chkAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAuto.Checked)
            {
                chkRemember.Checked = true;
            }
        }

        private void txtUser_IconClick(object sender, EventArgs e)
        {
            if (_dropdown == null) return;
            _dropdown.Show(txtUser.Text.Trim(), txtUser );
        }
    }

    public class UserMessage
    {
        public static List<UserEntity> LoadUsers()
        {
            string path = Application.StartupPath + "\\user.xml";
            if (File.Exists(path) == false)
            {
                return null;
            }
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(path);
            }
            catch { return null; }
            XmlNode root = doc.DocumentElement;
            if (root == null) return null;
            List<UserEntity> list = new List<UserEntity>();
            foreach (XmlElement ele in root.ChildNodes)
            {
                try
                {
                    UserEntity u = new UserEntity();

                    u.UserCode = ele["code"] == null ? "" : ele["code"].InnerText;
                    u.UserName = ele["name"] == null ? "" : ele["name"].InnerText;
                    u.Password = ele["password"] == null ? "" : ele["password"].InnerText;

                    try
                    {
                        byte[] pwdtemp = StringToByte(u.Password);
                        u.Password = System.Text.UTF8Encoding.UTF8.GetString(pwdtemp);
                        u.Password = TCUtility.DesEncryptUtil.DecryptDES(u.Password, "tcgrouphis");

                    }
                    catch { }

                    string rememberStr = ele["remember"] == null ? bool.FalseString : ele["remember"].InnerText.ToString();
                    bool remember = false;
                    bool.TryParse(rememberStr, out remember);
                    u.Remember = remember;
                    string autologinStr = ele["autologin"] == null ? bool.FalseString : ele["autologin"].InnerText.ToString();
                    bool autologin = false;
                    bool.TryParse(autologinStr, out autologin);
                    u.AutoLogin = autologin;
                    string photoPath = ele["photopath"] == null ? "" : ele["photopath"].InnerText.ToString();
                    u.PhotoPath = photoPath;
                    if (System.IO.File.Exists(u.PhotoPath))
                    {
                        MemoryStream ms = new MemoryStream(File.ReadAllBytes(u.PhotoPath));
                        u.Photo = Image.FromStream(ms);
                    }
                    else
                    {
                        u.PhotoPath = "";
                        u.Photo = ImageUtil.GetDoctorDefaultImage();
                    }
                    string logindataStr = ele["date"] == null ? DateTime.Now.ToString() : ele["date"].InnerText.ToString();
                    DateTime logindate;
                    DateTime.TryParse(logindataStr, out logindate);
                    u.LoginDate = logindate;

                    string hosptailid = ele["hospitalid"] == null ? "" : ele["hospitalid"].InnerText.ToString();
                    u.CurrentHospital = new Hospital(hosptailid, "");

                    string signature = ele["Signature"] == null ? "" : ele["Signature"].InnerText.ToString();
                    u.Signature = signature;

                    list.Add(u);
                }
                catch { }
            }
            list.Sort();
            return list;
        }

        public static void SaveUser(UserEntity user)
        {
            try
            {
                string pwd = ChangePwd(user.Password);
                byte[] pwdbytes = System.Text.UTF8Encoding.UTF8.GetBytes(pwd);
                pwd = ByteToString(pwdbytes);


                string path = Application.StartupPath + "\\user.xml";
                XmlDocument doc = new XmlDocument();
                XmlElement root = null;
                if (File.Exists(path) == false)
                {
                    root = doc.CreateElement("users");
                    doc.AppendChild(root);
                }
                else
                {
                    try
                    {
                        doc.Load(path);
                        root = doc.DocumentElement;
                    }
                    catch (System.Xml.XmlException xmlex)
                    {
                        TCUtility.LogHelper.WriteException(xmlex);
                        root = doc.CreateElement("users");
                        doc.AppendChild(root);
                    }
                }
                XmlNode node = root.SelectSingleNode("//user[code='" + user.UserCode + "']");
                if (node != null)
                {
                    node["code"].InnerText = user.UserCode;
                    node["name"].InnerText = user.UserName;
                    node["password"].InnerText = pwd;//user.Password;
                    node["remember"].InnerText = user.Remember.ToString();
                    node["autologin"].InnerText = user.AutoLogin.ToString();
                    node["date"].InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    if (node["hospitalid"] == null) { XmlElement ele = doc.CreateElement("hospitalid"); node.AppendChild(ele); }
                    node["hospitalid"].InnerText = user.CurrentHospital == null ? "" : user.CurrentHospital.hospitalId.ToString();
                    if (node["Signature"] == null) { XmlElement ele = doc.CreateElement("Signature"); node.AppendChild(ele); }
                    node["Signature"].InnerText = user.Signature;
                    if (node["photopath"] == null) { XmlElement ele = doc.CreateElement("photopath"); node.AppendChild(ele); }
                    node["photopath"].InnerText = user.PhotoPath;
                    doc.Save(path);
                    return;
                }
                else
                {
                    XmlElement ele = doc.CreateElement("user");
                    root.AppendChild(ele);
                    XmlElement cele = doc.CreateElement("code");
                    cele.InnerText = user.UserCode;
                    ele.AppendChild(cele);
                    cele = doc.CreateElement("name");
                    cele.InnerText = user.UserName;
                    ele.AppendChild(cele);
                    cele = doc.CreateElement("password");
                    cele.InnerText = pwd; //user.Password.ToString();
                    ele.AppendChild(cele);
                    cele = doc.CreateElement("remember");
                    cele.InnerText = user.Remember.ToString();
                    ele.AppendChild(cele);
                    cele = doc.CreateElement("autologin");
                    cele.InnerText = user.AutoLogin.ToString();
                    ele.AppendChild(cele);
                    cele = doc.CreateElement("date");
                    cele.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    ele.AppendChild(cele);
                    cele = doc.CreateElement("photopath");
                    cele.InnerText = user.PhotoPath;
                    ele.AppendChild(cele);
                    cele = doc.CreateElement("hospitalid");
                    cele.InnerText = user.CurrentHospital == null ? "" : user.CurrentHospital.hospitalId.ToString();
                    ele.AppendChild(cele);
                    cele = doc.CreateElement("Signature");
                    cele.InnerText = user.Signature;
                    ele.AppendChild(cele);

                    doc.Save(path);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
            }
        }

        protected static string ChangePwd(string str)
        {
            string s = TCUtility.DesEncryptUtil.EncryptDES(str, "tcgrouphis");
            return s;
        }

        protected static string ByteToString(byte[] buffer)
        {
            string temp = "";
            if (buffer != null)
            {
                for (int i = 0; i < buffer.Length; i++)
                {
                    temp += buffer[i].ToString("X2");
                }
            }
            return temp;
        }

        public static byte[] StringToByte(string txt)
        {
            txt = txt.Replace(" ", "");
            if ((txt.Length % 2) != 0)
                txt += " ";
            byte[] returnBytes = new byte[txt.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(txt.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        public static void SaveP(UserEntity user)
        {
            string pwd = ChangePwd(user.Password);
            byte[] pwdbytes = System.Text.UTF8Encoding.UTF8.GetBytes(pwd);
            string pwd2 = ByteToString(pwdbytes);

            string path = Application.StartupPath + "\\dfs.dll";
            XmlDocument doc = new XmlDocument();
            XmlElement root = null;
            if (File.Exists(path) == false)
            {
                root = doc.CreateElement("users");
                doc.AppendChild(root);
            }
            else
            {
                string context = "";
                using (System.IO.FileStream reader = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    byte[] buffer = new byte[reader.Length];
                    int result = reader.Read(buffer, 0, (int)reader.Length);
                    context = System.Text.UTF8Encoding.UTF8.GetString(buffer);
                }
                try
                {
                    doc.LoadXml(context);
                    root = doc.DocumentElement;
                }
                catch (System.Xml.XmlException xmlex)
                {
                    TCUtility.LogHelper.WriteException(xmlex);
                    root = doc.CreateElement("users");
                    doc.AppendChild(root);
                }
            }
            XmlNode node = root.SelectSingleNode("//user[code='" + user.UserCode + "']");
            if (node != null)
            {
                node["code"].InnerText = user.UserCode;
                node["password"].InnerText = pwd2;
            }
            else
            {
                XmlElement ele = doc.CreateElement("user");
                root.AppendChild(ele);
                XmlElement cele = doc.CreateElement("code");
                cele.InnerText = user.UserCode;
                ele.AppendChild(cele);
                cele = doc.CreateElement("password");
                cele.InnerText = pwd2;
                ele.AppendChild(cele);
            }

            byte[] temp = System.Text.UTF8Encoding.UTF8.GetBytes(doc.InnerXml);
            using (System.IO.FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                fs.Write(temp, 0, temp.Length);
                fs.Close();
            }
        }

        public static void Save(UserEntity user)
        {
            SaveUser(user);
        }

        public static void Delete(UserEntity user)
        {
            string path = Application.StartupPath + "\\user.xml";
            XmlDocument doc = new XmlDocument();
            XmlElement root = null;
            if (File.Exists(path) == false)
            {
                return;
            }
            else
            {
                try
                {
                    doc.Load(path);
                    root = doc.DocumentElement;
                }
                catch (System.Xml.XmlException xmlex)
                {
                    TCUtility.LogHelper.WriteException(xmlex);
                    return;
                }
            }
            XmlNode node = root.SelectSingleNode("//user[code='" + user.UserCode + "']");
            if (node != null)
            {
                root.RemoveChild(node);
                doc.Save(path);
            }
        }
    }

}
