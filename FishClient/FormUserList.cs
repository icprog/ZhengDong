using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormUserList : FormMenuBase
    {
        protected bool _isSelectMode = false;

        public FormUserList():this(false)
        {

        }
        public FormUserList( bool isSelectMode)
        {
            InitializeComponent();

            _isSelectMode = isSelectMode;
            tmiExport.Visible = false;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;
            tmiNext.Visible = tmiPrevious.Visible = false;

            UIControls.ToolStripMenuItemEx tmimodifyPassword = new UIControls.ToolStripMenuItemEx();
            tmimodifyPassword.Text = "修改密码";
            tmimodifyPassword.FunCode = "50";
            tmimodifyPassword.Click += tmimodifyPassword_Click;
            menuStrip1.Items.Insert(menuStrip1.Items.IndexOf(tmiClose), tmimodifyPassword);

            UIControls.ToolStripMenuItemEx tmiRole = new UIControls.ToolStripMenuItemEx();
            tmiRole.Text = "设置权限";
            tmiRole.FunCode = "51";
            tmiRole.Click += tmiRole_Click;
            menuStrip1.Items.Insert(menuStrip1.Items.IndexOf(tmiClose), tmiRole);
            ReadColumnConfig(dataGridView1, "Set_UserList");
            Query();
        }

        void tmiRole_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            FishEntity.PersonEntity person = dataGridView1.CurrentRow.DataBoundItem as FishEntity.PersonEntity;
            if (person == null) return;

            FormUserRole form = new FormUserRole( person );
            form.ShowDialog();
        }

        void tmimodifyPassword_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            if (FishEntity.Variable.User == null) return;

            FishEntity.PersonEntity person = dataGridView1.CurrentRow.DataBoundItem as FishEntity.PersonEntity;
            if (person == null) return;

            if ( person.id != FishEntity.Variable.User.id &&
                FishEntity.Variable.User.roletype.Contains(FishEntity.Constant.Role_Admin) ==false )
            {
                MessageBox.Show("你无权修改密码。");
                return;
            }

            if (person == null) return;
            UIForms.FormModifyPassword form = new UIForms.FormModifyPassword( person );
            form.ShowDialog();
        }

        public override int Add()
        {
            FormUser form = new FormUser("新增数据",null);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowInTaskbar = false;
            form.RefreshEvent += form_RefreshEvent;
            form.ShowDialog();
            return 1;
        }

        public override int Modify()
        {
            //return base.Modify();
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("请选择要编辑的行");
                return 0;
            }
            FishEntity.PersonEntity entity = dataGridView1.CurrentRow.DataBoundItem as FishEntity.PersonEntity;
            if (entity == null)
            {
                MessageBox.Show("请选择要编辑的行");
                return 0;
            }
            FormUser form = new FormUser("编辑数据", entity);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowInTaskbar = false;
            form.RefreshEvent += form_RefreshEvent;
            form.ShowDialog();
            return 0;
        }

        public override int Delete()
        {
            //return base.Delete();
            if (
               FishEntity.Variable.User.roletype.Contains(FishEntity.Constant.Role_Admin) == false)
            {
                MessageBox.Show("你无权删除。");
                return 0;
            }


            if (dataGridView1.SelectedRows == null || dataGridView1.SelectedRows.Count <1)
            {
                MessageBox.Show("请选择要删除的行记录");
                return 0;
            }

            int id =0;

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                id += int.Parse( row.Cells["id"].Value.ToString());      
            }       

            if (MessageBox.Show("您确定要删除选中的记录吗?", "询问", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return 0;

            FishBll.Bll.PersonBll bll = new FishBll.Bll.PersonBll();
            if (bll.FlagDelete(id))
            {
                Query();
            }
            else
            {
                MessageBox.Show("删除失败。");
            }
            return 1;
        }

        public override int Query()
        {
            FishBll.Bll.PersonBll bll = new FishBll.Bll.PersonBll();
            string where=" isdelete=0 ";
            if( string.IsNullOrEmpty ( txtUserName .Text )==false )
            {
                where +=" and username like '%"+ txtUserName.Text.Trim ()+"%'";
            }
            List<FishEntity.PersonEntity > list  = bll.GetModelList(where);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = list;
            return 1;
        }

        void form_RefreshEvent(EventArgs obj)
        {
            //throw new NotImplementedException();
            Query();
        }

        public FishEntity.PersonEntity SelectedPersion
        {
            get
            {
                if (dataGridView1.CurrentRow != null)
                {
                    return dataGridView1.CurrentRow.DataBoundItem as FishEntity.PersonEntity;
                }
                return null;
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            //this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FormUserList_Load(object sender, EventArgs e)
        {
            dataGridView1.BackgroundColor = this.BackColor;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            //this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            if (_isSelectMode)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                Modify();
            }
        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_UserList");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_UserList");
        }
        protected void ReadColumnConfig(DataGridView dgv, string section)
        {
            string path = Application.StartupPath + "\\listconfig.ini";
            if (System.IO.File.Exists(path) == true)
            {
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    string wstr = Utility.IniUtil.ReadIniValue(path, section, col.HeaderText);
                    int w = 0;
                    if (int.TryParse(wstr, out w))
                    {
                        col.Width = w;
                    }
                }
            }
        }

        //选择需要送审的人员
        private void dataGridView1_CellClick ( object sender ,DataGridViewCellEventArgs e )
        {
            if ( e . ColumnIndex < 0 || e . RowIndex < 0 )
                return;
            DataGridViewCheckBoxCell checkCell = ( DataGridViewCheckBoxCell ) dataGridView1 . Rows [ e . RowIndex ] . Cells [ 0 ];
            Boolean flag = Convert . ToBoolean ( checkCell . Value );
            if ( flag )
                dataGridView1 . Rows [ e . RowIndex ] . Cells [ 0 ] . Value = false;
            else
                dataGridView1 . Rows [ e . RowIndex ] . Cells [ 0 ] . Value = true;
        }

        string allOfPerson=string.Empty;
        private void dataGridView1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            allOfPerson = string . Empty;
            if ( e . KeyChar == 13 )
            {
                int count = dataGridView1 . Rows . Count;
                for ( int i = 0 ; i < count ; i++ )
                {
                    DataGridViewCheckBoxCell checkCell = ( DataGridViewCheckBoxCell ) dataGridView1 . Rows [ i ] . Cells [ 0 ];
                    Boolean flag = Convert . ToBoolean ( checkCell . Value );
                    if ( flag )
                    {
                        if ( allOfPerson == string . Empty )
                            allOfPerson = dataGridView1 . Rows [ i ] . Cells [ 1 ] . Value . ToString ( ) + " " + dataGridView1 . Rows [ i ] . Cells [ 2 ] . Value . ToString ( );
                        else
                            allOfPerson = allOfPerson + " | " + dataGridView1 . Rows [ i ] . Cells [ 1 ] . Value . ToString ( ) + " " + dataGridView1 . Rows [ i ] . Cells [ 2 ] . Value . ToString ( );
                    }
                }
            }

            if ( allOfPerson != string . Empty )
                this . DialogResult = DialogResult . OK;
        }

        public string getStr
        {
            get
            {
                return allOfPerson;
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            allOfPerson = string.Empty;
                int count = dataGridView1.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                    Boolean flag = Convert.ToBoolean(checkCell.Value);
                    if (flag)
                    {
                        if (allOfPerson == string.Empty)
                            allOfPerson = dataGridView1.Rows[i].Cells[1].Value.ToString() + " " + dataGridView1.Rows[i].Cells[2].Value.ToString();
                        else
                            allOfPerson = allOfPerson + " | " + dataGridView1.Rows[i].Cells[1].Value.ToString() + " " + dataGridView1.Rows[i].Cells[2].Value.ToString();
                    }
                }

            if (allOfPerson != string.Empty)
                this.DialogResult = DialogResult.OK;
        }
    }
}
