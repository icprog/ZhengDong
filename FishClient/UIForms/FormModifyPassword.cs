using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient.UIForms
{
    public partial class FormModifyPassword : FormMenuBase
    {
        FishEntity.PersonEntity _user = null;

        public FormModifyPassword(FishEntity.PersonEntity user)
        {
            InitializeComponent();

            this.BackColor = Color.White;
            this.menuStrip1.Visible = false;

            if (user == null) return;
            _user = user;
            lblname.Text = _user.username;
            txtpwd1.Text = txtpwd2.Text = string.Empty;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {           

            string pwd1 = txtpwd1.Text.Trim();
            string pwd2 = txtpwd2.Text .Trim();
            if(string.IsNullOrEmpty(pwd1 ) || string.IsNullOrEmpty(pwd2 )){
                MessageBox.Show("请输入密码。");
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

            if (pwd1 != pwd2)
            {
                MessageBox.Show("两次密码输入不一致，请重新设置");
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

            string pwdstr = Utility.DesEncryptUtil.EncryptMD5(pwd1);

            FishBll.Bll.PersonBll bll = new FishBll.Bll.PersonBll();
            bool isok = bll.ModifyPassword(_user.id, pwdstr );
            if (isok)
            {
                MessageBox.Show("修改密码成功。");
            }            
        }
    }
}
