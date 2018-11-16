using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormAddRole : FormBase
    {
        public FishBll.Bll.RoleBll _bll = new FishBll.Bll.RoleBll();
        public event EventHandler RefreshData = null;
        public FishEntity.RoleEntity _role = null;

        public FormAddRole( FishEntity.RoleEntity role )
        {
            InitializeComponent();

            SetButtomImage(btnOk);
            SetButtomImage(btnCancel);

            _role = role;

            if (_role != null)
            {
                txtRoleName.Text = _role.rolename;
                txtRemark.Text = _role.remarks;
                this.Text = "修改权限";
            }
        }

        protected void Save()
        {
            if ( string.IsNullOrEmpty( txtRoleName.Text) ==true )
            {
                MessageBox.Show("请输入权限名称");
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

            if (_role == null)
            {
                FishEntity.RoleEntity entity = new FishEntity.RoleEntity();
                entity.rolename = txtRoleName.Text.Trim();
                entity.remarks = txtRemark.Text.Trim();

                bool isexist = _bll.Exists(entity.rolename);
                if (isexist)
                {
                    MessageBox.Show("名称重复，请重新输入。");
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                    return;
                }

                _bll.Add(entity);
                MessageBox.Show("添加成功");
            }
            else
            {
                string newrolename = txtRoleName.Text.Trim();
                if (newrolename.Equals(_role.rolename) == false)
                {
                    bool isexist =  _bll.Exists(newrolename);
                    if (isexist)
                    {
                        MessageBox.Show("名称重复，请重新输入。");
                        this.DialogResult = System.Windows.Forms.DialogResult.None;
                        return;
                    }
                }

                _role.rolename = txtRoleName.Text.Trim();
                _role.remarks = txtRemark.Text.Trim();
                _bll.Update(_role);
                MessageBox.Show("修改成功");
            }


            if (RefreshData != null)
            {
                RefreshData(this, EventArgs.Empty);
            }
        }
            

        private void btnOk_Click(object sender, EventArgs e)
        {
            Save ();
        }

        private void txtRoleName_KeyDown(object sender, KeyEventArgs e)
        {
            if( e.KeyCode == Keys.Enter)
            {
                Save ();
            }
        }
    }
}
