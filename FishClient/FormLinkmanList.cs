using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormLinkmanList : FormMenuBase
    {
        private FishBll.Bll.CustomerBll _bll = new FishBll.Bll.CustomerBll();

        public FormLinkmanList()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            ReadColumnConfig(dataGridView1, "Set_LinkmanList");
        }

        public FishEntity.CustomerEntity SelectedCustomer
        {
            get
            {
                if (dataGridView1.CurrentRow != null)
                {
                    return dataGridView1.CurrentRow.DataBoundItem as FishEntity.CustomerEntity;
                }
                return null;
            }
        }

        protected string GetWhere()
        {
            string where = " 1=1 ";
            if ( false == string.IsNullOrEmpty(txtCode.Text))
            {
                where += string.Format(" and code like %{0}%", txtCode.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtName.Text))
            {
                where += string.Format(" and name like '%{0}%'", txtName.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtTelephone.Text))
            {
                where += string.Format(" and telephone like '%{0}%'", txtTelephone.Text .Trim ());
            }
            if (false == string.IsNullOrEmpty(txtPhone.Text))
            {
                where += string.Format(" and ( phone1 like '%{0}%' or phone2 like '{1}' or phone3 like '{2}' ) ", txtPhone.Text.Trim(), txtPhone.Text.Trim(), txtPhone.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtPost.Text))
            {
                where += string.Format(" and post like '%{0}%' " , txtPost.Text.Trim() );
            }
            if (false == string.IsNullOrEmpty(txtQQ.Text))
            {
                where += string.Format(" and qq like '%{0}%'" , txtQQ.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtWeixin.Text))
            {
                where += string.Format(" and weixin like'%{0}%'" , txtWeixin.Text .Trim () );
            } 
            if (false == string.IsNullOrEmpty(txtEmail.Text))
            {
                where += string.Format(" and email like'%{0}%'", txtEmail.Text.Trim());
            }
            return where;
        }

        public override int Query()
        {
            string where = GetWhere();
            List<FishEntity.CustomerEntity> list = _bll.GetModelList(where);

            dataGridView1.DataSource = list;
            return 1;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FormLinkmanList_Load(object sender, EventArgs e)
        {
            dataGridView1.BackgroundColor = this.BackColor;
        }

        public override int Add()
        {
            //return base.Add();
            FormLinkman form = new FormLinkman();
            form.ShowDialog();
            return 0;
        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_LinkmanList");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_LinkmanList");
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

    }
}
