using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormUser : FormMenuBase
    {
        public event Action<EventArgs> RefreshEvent = null;
        FishEntity.PersonEntity _person = null;
        public FormUser( string title , FishEntity.PersonEntity person )
        {
            InitializeComponent();

            menuStrip1.Visible = false;

            this.Text = title;
            _person = person;
            if (_person != null)
            {
                txtdepartment.Text = _person.department;
                txtemail.Text = _person.email;
                txtEname.Text = _person.ename;
                dtpEntryDate.Value = _person.entrytime;
                txtphone.Text = _person.phone;
                txtRealName.Text = _person.realname;
                txtTelephone.Text = _person.telephone;
                txtUserName.Text = _person.username;
                rbman.Checked = _person.sex.Equals("男") ? true : false;
                txtAge.Text = _person.age.ToString();

                string[] roles= _person.roletype .Split (',');
                foreach( string item in roles )
                {
                    if( item.Equals( FishEntity.Constant.Role_SalesMan ))
                    {
                        cbsalesman .Checked = true ;
                    }
                    else if( item.Equals( FishEntity.Constant.Role_SalesManager )){
                        cbsalesmanger.Checked = true ;
                    }
                    else if (item.Equals(FishEntity.Constant.Role_Admin))
                    {
                        ckadmin.Checked = true;
                    }
                    else if (item.Equals(FishEntity.Constant.Role_Finance))
                    {
                        cbFinance.Checked = true;
                    }
                    else if (item.Equals(FishEntity.Constant.Role_FinancialOfficer))
                    {
                        cbFinancialOfficer.Checked = true;
                    }
                    else if (item.Equals(FishEntity.Constant.Role_LogisticsStaff))
                    {
                        cbLogisticsStaff.Checked = true;
                    }
                    else if (item.Equals(FishEntity.Constant.Role_LogisticsDirector))
                    {
                        cbLogisticsDirector.Checked = true;
                    }
                }
            }

        }

        protected bool Check()
        {
            errorProvider1.Clear();
            bool isok = true;
            string username = txtUserName.Text.Trim();
            if (string.IsNullOrEmpty(username) == true )
            {
                errorProvider1 .SetError(txtUserName, "请输入用户名");
                isok = false;
            }

            int age=0;
            if (false == string.IsNullOrEmpty(txtAge.Text))
            {
                if (int.TryParse(txtAge.Text, out age) == false)
                {
                    errorProvider1.SetError(txtAge, "请输入正确的年龄");
                    isok = false;
                }
            }

            if (cbsalesman.Checked == false && cbsalesmanger.Checked == false && ckadmin.Checked == false&&cbFinance.Checked==false&&cbFinancialOfficer.Checked==false&& cbLogisticsStaff.Checked==false&&cbLogisticsDirector.Checked==false)
            {
                errorProvider1.SetError(ckadmin, "请选择操作类型");
                isok = false;
            }

            return isok;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Check() == false)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

            bool isAdd = false;
            if (_person == null)
            {
                string username = txtUserName.Text.Trim();
                FishBll.Bll.PersonBll bll = new FishBll.Bll.PersonBll();
                if (bll.Exists(username))
                {
                    MessageBox.Show("用户名已经存在，请使用其他名称。");
                    txtUserName.SelectAll();
                    txtUserName.Focus();
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                    return;
                }

                _person = new FishEntity.PersonEntity();
                _person.isdelete = 0;
                isAdd = true;

                _person.password = Utility.DesEncryptUtil.EncryptMD5("123456");
                _person.createman = FishEntity.Variable.User.username;
                _person.createtime = DateTime.Now;
                _person.modifyman = _person.createman;
                _person.modifytime = _person.createtime;
            }
            else
            {
                string username = txtUserName.Text.Trim();
                if (_person.username.Equals(username) == false)
                {
                    FishBll.Bll.PersonBll bll = new FishBll.Bll.PersonBll();
                    if (bll.Exists(username))
                    {
                        MessageBox.Show("用户名已经存在，请使用其他名称。");
                        txtUserName.SelectAll();
                        txtUserName.Focus();
                        this.DialogResult = System.Windows.Forms.DialogResult.None;
                        return;
                    }
                }

                _person.modifyman = FishEntity.Variable.User.username;
                _person.modifytime = DateTime.Now;
            }

            int temp = 0;
            int.TryParse(txtAge.Text, out temp);
            _person.age = temp;
         
            _person.department = txtdepartment.Text;
            _person.email = txtemail.Text;
            _person.ename = txtEname.Text;
            _person.entrytime = dtpEntryDate.Value;       
            
            _person.phone = txtphone.Text;
            _person.realname = txtRealName.Text;
            _person.roledate = string.Empty;

            string role= string.Empty;

            if(cbsalesman .Checked )
            {
                if(string.IsNullOrEmpty(role )== false )
                {
                    role +=",";
                }
                role += cbsalesman.Text;
            }
            if( cbsalesmanger.Checked )
            {
                if(  string.IsNullOrEmpty ( role )==false )
                {
                    role +=",";
                }
                role += cbsalesmanger.Text ;
            }
            if( ckadmin.Checked )
            {
                if(string .IsNullOrEmpty ( role ) ==false )
                {
                    role +=",";
                }
                role += ckadmin.Text;
            }
            if (cbFinance.Checked)
            {
                if (string.IsNullOrEmpty(role)==false)
                {
                    role += ",";
                }
                role += cbFinance.Text;
            }
            if (cbFinancialOfficer.Checked)
            {
                if (string.IsNullOrEmpty(role)==false)
                {
                    role += ",";
                }
                role += cbFinancialOfficer.Text;
            }
            if (cbLogisticsStaff.Checked)
            {
                if (string.IsNullOrEmpty(role)==false)
                {
                    role += ",";
                }
                role += cbLogisticsStaff.Text;
            }
            if (cbLogisticsDirector.Checked)
            {
                if (string.IsNullOrEmpty(role)==false)
                {
                    role += ",";
                }
                role += cbLogisticsDirector.Text;
            }


            _person.roletype = role;
            _person.sex = rbman.Checked ? "男":"女";
            _person.telephone = txtTelephone.Text;
            _person.username = txtUserName.Text;

            if (isAdd)
            {
                FishBll.Bll.PersonBll bll = new FishBll.Bll.PersonBll();
                bool isok =  bll.Add(_person);
                if (isok)
                {
                    OnRefresh();
                }
            }
            else
            {
                FishBll.Bll.PersonBll bll = new FishBll.Bll.PersonBll();
                bool isok =  bll.Update(_person);
                if (isok)
                {
                    OnRefresh();
                }
            }

        }

        protected void OnRefresh()
        {
            if (RefreshEvent != null)
            {
                RefreshEvent(EventArgs.Empty);
            }
        }
    }
}
