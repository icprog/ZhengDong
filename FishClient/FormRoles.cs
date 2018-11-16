using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormRoles : FormMenuBase
    {
        private FishBll.Bll.RoleBll _bll = new FishBll.Bll.RoleBll();
        private List<FishEntity.RoleEntity> _list = null;

        public FormRoles()
        {
            InitializeComponent();



            tmiPrevious.Visible = false;
            tmiNext.Visible = false;
            tmiExport.Visible = false;
            tmiCancel.Visible = false;
            tmiQuery.Visible = false;
            //tmiSave.Visible = false;

            UIControls.ToolStripMenuItemEx tmiFunc = new UIControls.ToolStripMenuItemEx();
            tmiFunc.FunCode = "50";
            tmiFunc.Text = "添加功能";
            tmiFunc.Click += tmiFunc_Click;
            menuStrip1.Items.Insert(menuStrip1.Items.IndexOf(tmiClose), tmiFunc);
        }

        protected void BindFuncode()
        {
            FishBll.Bll.FunCodeBll bll = new FishBll.Bll.FunCodeBll();
            List<FishEntity.FunCodeEntity> data = bll.GetModelList(" 1=1 ");
            treeViewFunCode.Nodes.Clear();
            if (data == null || data.Count < 1) return;

            BindTreeView(0, data, null);


            BindHasFunCode();

            
        }
        protected void BindHasFunCode()
        {
            FishEntity.RoleEntity role = treeViewRoles.SelectedNode.Tag as FishEntity.RoleEntity;
            if( role ==null ) return;
            FishBll.Bll.RoleFunBll bll = new FishBll.Bll.RoleFunBll();
            List<FishEntity.RoleFunEntity> func = bll.GetModelList(" roleid = " + role.roleid);
            if (func == null || func.Count < 1) return;

            BindHasFunCode(func, treeViewFunCode.Nodes);
        }

        protected void BindHasFunCode(List<FishEntity.RoleFunEntity> func , TreeNodeCollection nodes )
        {
            if (nodes == null || nodes.Count < 1) return;
            foreach (TreeNode node in nodes)
            {
                FishEntity.FunCodeEntity entity = node.Tag as FishEntity.FunCodeEntity;
                if (entity == null) continue;
                bool isExist =  func.Exists((i) => { return i.funid == entity.funid; });
                if (isExist)
                {
                    node.Checked = true;
                }
                else
                {
                    node.Checked = false;
                }

                BindHasFunCode(func, node.Nodes);
            }
        }
        

        protected void BindTreeView( int pid , List<FishEntity.FunCodeEntity> data , TreeNode currentNode )
        {
            List<FishEntity.FunCodeEntity> items = data.FindAll((i) => { return i.pid == pid; });
            if (items == null || items.Count < 1) return;

            items.Sort( new FunCodeComparer() );

            foreach (FishEntity.FunCodeEntity item in items)
            {
                TreeNode node = new TreeNode(item.funname);
                node.Tag = item;
                if (currentNode == null)
                {
                    treeViewFunCode.Nodes.Add(node);
                }
                else
                {
                    currentNode.Nodes.Add(node);
                }

                BindTreeView(item.funid , data, node);
            }
        }

        void tmiFunc_Click(object sender, EventArgs e)
        {
            FormAddFunCode formfuncode = new FormAddFunCode(null);
            formfuncode.RefreshData += formfuncode_RefreshData;
            formfuncode.ShowDialog();
        }

        public override int Modify()
        {
            if (treeViewRoles.SelectedNode == null)
            {
                MessageBox.Show("请选择需要修改的权限名称");
                return 0;
            }

            FishEntity.RoleEntity role = treeViewRoles.SelectedNode.Tag as FishEntity.RoleEntity;
            if (role == null) return 0;

            FormAddRole form = new FormAddRole( role );
            form.RefreshData+=form_RefreshData;
            form.ShowDialog();
            return base.Modify();
        }

        public override int Add()
        {
            FormAddRole form = new FormAddRole(null);
            form.RefreshData += form_RefreshData;
            form.ShowDialog();

            return base.Add();
        }

        public override int Query()
        {
           _list =  _bll.GetModelList("");

           treeViewRoles.Nodes.Clear();

            if( _list==null || _list.Count<1 ) return 0;

            foreach (FishEntity.RoleEntity item in _list)
            {
                TreeNode node = new TreeNode(item.rolename);
                node.Tag = item;
                treeViewRoles.Nodes.Add(node);
            }

            treeViewRoles.SelectedNode = treeViewRoles.Nodes[0];

            return base.Query();
        }

        public override void Save()
        {
            if (treeViewRoles.SelectedNode == null) return;

            FishEntity.RoleEntity role = treeViewRoles.SelectedNode.Tag as FishEntity.RoleEntity;
            if (role == null) return;

            List<FishEntity.FunCodeEntity> newfunc = new List<FishEntity.FunCodeEntity>();
            GetFuncodes(newfunc);

            FishBll.Bll.RoleFunBll bll = new FishBll.Bll.RoleFunBll();
            List<FishEntity.RoleFunEntity> oldFunc = bll.GetModelList("roleid=" + role.roleid);

            foreach (FishEntity.RoleFunEntity item in oldFunc)
            {
                bool isexist = newfunc.Exists((i) => { return i.funid == item.funid; });
                if (isexist == false)
                {
                    bll.Delete(item.id);
                }
            }
            
            foreach (FishEntity.FunCodeEntity item in newfunc )
            {
                bool isexist = oldFunc.Exists(i => { return i.funid == item.funid; });
                if (isexist == false)
                {
                    FishEntity.RoleFunEntity entity = new FishEntity.RoleFunEntity();
                    entity.funid = item.funid;
                    entity.roleid = role.roleid;
                    bll.Add(entity);
                }
            }

            MessageBox.Show("保存成功");

            base.Save();
        }

        public override int Delete()
        {
            if (treeViewRoles.SelectedNode == null) return 0;
            FishEntity.RoleEntity role = treeViewRoles.SelectedNode.Tag as FishEntity.RoleEntity;
            if (role == null) return 0;
            if (MessageBox.Show("你确定要删除权限为【" + role.rolename + "】吗？", "询问", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
            {
                return 0;
            }

            _bll.Delete(role.roleid);
            MessageBox.Show("删除成功");

            treeViewFunCode.Nodes.Clear();

            Query();

            return base.Delete();
        }

        protected void GetFuncodes(List<FishEntity.FunCodeEntity> data)
        {
            GetFuncodes(data, treeViewFunCode.Nodes);
        }

        protected void GetFuncodes(List<FishEntity.FunCodeEntity> data, TreeNodeCollection nodes  )
        {
            //List<FishEntity.FunCodeEntity> data = new List<FishEntity.FunCodeEntity>();
            if (nodes == null || nodes.Count<1 ) return;
                foreach (TreeNode item in nodes )
                {
                    if (item.Checked)
                    {
                        FishEntity.FunCodeEntity fun = item.Tag as FishEntity.FunCodeEntity;
                        if (fun == null) continue;
                        data.Add(fun);
                    }

                    GetFuncodes(data, item.Nodes);
                }                      
            
        }


        void form_RefreshData(object sender, EventArgs e)
        {
            Query();
        }

        private void FormRoles_Load(object sender, EventArgs e)
        {
            Query();
        }

        private void treeViewRoles_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void treeViewFunCode_AfterSelect(object sender, TreeViewEventArgs e)
        {
   
        }

        private void treeViewRoles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            BindFuncode();
        }

        private void treeViewFunCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (treeViewFunCode.SelectedNode == null) return;
                FishEntity.FunCodeEntity entity = treeViewFunCode.SelectedNode.Tag as FishEntity.FunCodeEntity;
                if (entity == null) return;
                FormAddFunCode formfuncode = new FormAddFunCode(entity);
                formfuncode.RefreshData += formfuncode_RefreshData;
                formfuncode.ShowDialog();
            }
        }

        void formfuncode_RefreshData(object sender, EventArgs e)
        {
            BindFuncode();
        }

        private void treeViewFunCode_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            //if (e.Node.Checked)
            //{
                //if (e.Node.Parent != null&& e.Node.Parent .Checked ==false )
                //{
                //    e.Node.Parent.Checked = true;
                //}
                if (e.Node.Nodes != null && e.Node.Nodes.Count > 0)
                {
                    foreach (TreeNode item in e.Node.Nodes)
                    {
                        item.Checked = e.Node.Checked;
                    }
                }
            //}
        }
    }

    class FunCodeComparer : IComparer<FishEntity.FunCodeEntity>
    {
        public int Compare(FishEntity.FunCodeEntity obj1, FishEntity.FunCodeEntity obj2)
        {
            return obj1.sortid.CompareTo(obj2.sortid);
        }
    }
}
