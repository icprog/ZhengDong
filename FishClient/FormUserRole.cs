using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormUserRole : FormMenuBase
    {
        private FishEntity.PersonEntity _user;
        private List<FishEntity.UserRoleEntity> _oldRoles;

        public FormUserRole( FishEntity.PersonEntity user)
        {
            InitializeComponent();

            //tmiAdd.Visible = false;
            //tmiCancel.Visible = false;
            //tmiDelete.Visible = false;
            //tmiExport.Visible = false;
            //tmiModify.Visible = false;
            //tmiNext.Visible = false;
            //tmiPrevious.Visible = false;
            //tmiQuery.Visible = false;
            tmiReview.Visible = false;
            tmiprint.Visible = false;
             _user = user;
            label1.Text = _user.username;

            FishBll.Bll.RoleBll bll = new FishBll.Bll.RoleBll();
            List<FishEntity.RoleEntity> roles = bll.GetModelList("1=1");
            if (roles == null || roles.Count < 1) return;

            foreach( FishEntity.RoleEntity item in roles )
            {
                TreeNode node = new TreeNode( item.rolename );
                node.Tag = item;
                treeView1.Nodes.Add(node);
            }

            FishBll.Bll.UserRoleBll rolebll = new FishBll.Bll.UserRoleBll();

            _oldRoles = rolebll.GetModelList("userid=" + _user.id);
            if (_oldRoles == null || _oldRoles.Count < 1) return;

            foreach (TreeNode node in treeView1.Nodes)
            {
                FishEntity.RoleEntity r = node.Tag as FishEntity.RoleEntity;
                if (r == null) continue;
                bool isexist = _oldRoles.Exists((i) => { return i.roleid == r.roleid; });
                if (isexist == true)
                {
                    node.Checked = true;
                }
            }
        }

        public override void Save()
        {
            if (treeView1.Nodes.Count < 1)
            {
                MessageBox.Show("没有权限需要保存");
                return;
            }

            treeView1.EndUpdate();

            List<FishEntity.UserRoleEntity> newRoles = new List<FishEntity.UserRoleEntity>();

            foreach (TreeNode node in treeView1.Nodes)
            {
                FishEntity.RoleEntity role = node.Tag as FishEntity.RoleEntity;
                if (role == null) continue;
                if (node.Checked)
                {
                    FishEntity.UserRoleEntity uRole = new FishEntity.UserRoleEntity();
                    uRole.roleid = role.roleid;
                    uRole.userid = _user.id;
                    newRoles.Add(uRole);
                }
            }

            FishBll.Bll.UserRoleBll bll = new FishBll.Bll.UserRoleBll();
            if (newRoles == null || newRoles.Count == 0)
            {
                bll.DeleteByUserId(_user.id);
                return;
            }

            _oldRoles = bll.GetModelList("userid=" + _user.id);

            if (_oldRoles != null)
            {
                foreach (FishEntity.UserRoleEntity item in _oldRoles)
                {
                    bool isExist = newRoles.Exists((i) => { return i.roleid == item.roleid; });
                    if (false == isExist)
                    {
                        bll.Delete(item.id);
                    }
                }
            }

            foreach (FishEntity.UserRoleEntity item in newRoles)
            {
                bool isExist =_oldRoles == null ? false : _oldRoles.Exists((i) => { return i.roleid == item.roleid; });
                if (isExist == false)
                {
                    bll.Add(item);
                }
            }

            MessageBox.Show("设置成功");

        }

        private void FormUserRole_Load(object sender, EventArgs e)
        {
            menuStrip1.Visible = true;
            tmiAdd.Visible = false;
            tmiCancel.Visible = false;
            tmiDelete.Visible = false;
            tmiExport.Visible = false;
            tmiModify.Visible = false;
            tmiNext.Visible = false;
            tmiPrevious.Visible = false;
            tmiQuery.Visible = false;
            tmiReview.Visible = false;
            tmiprint.Visible = false;
        }
    
    }
}
