using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormProductDataSet : FormMenuBase
    {

        public FormProductDataSet()
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_ProductDataSet");
            tmiPrevious.Visible = false;
            tmiNext.Visible = false;
            tmiExport.Visible = false;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;
        }

        public override int Add()
        {
            FormEditDict form = new FormEditDict("新增数据", FishEntity.DataTypeEnum.BUSINESS , null );
            form.ShowInTaskbar = false;
            form.RefreshEvent += form_RefreshEvent;
            form.ShowDialog();
            return 0;
        }

        void form_RefreshEvent(EventArgs obj)
        {
            Query();
        }

        public override int Modify()
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("请选择要编辑的行");
                return 0;
            }
            FishEntity.DictEntity entity = dataGridView1.CurrentRow.DataBoundItem as FishEntity.DictEntity;
            if (entity == null)
            {
                MessageBox.Show("请选择要编辑的行");
                return 0;
            }
            FormEditDict form = new  FormEditDict("编辑数据", FishEntity.DataTypeEnum.BUSINESS, entity);
            form.ShowInTaskbar = false;
            form.RefreshEvent+=form_RefreshEvent;
            form.ShowDialog();
            return 0;
        }

        public override int Delete()
        {
            //return base.Delete();
            if (dataGridView1.SelectedRows == null)
            {
                MessageBox.Show("请选择要删除的行记录");
                return 0;
            }

            string ids = string.Empty;
            foreach( DataGridViewRow row in dataGridView1.SelectedRows )
            {
                if( string.IsNullOrEmpty ( ids ) == false )
                {
                    ids +=",";
                }
                ids += row.Cells["id"].Value .ToString();
            }
            if (string.IsNullOrEmpty(ids))
            {
                MessageBox.Show("请选择要删除的行记录");
                return 0;
            }

            if (MessageBox.Show("您确定要删除选中的记录吗?", "询问", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return 0;


            FishBll.Bll.DictBll bll = new FishBll.Bll.DictBll();
            if (bll.DeleteList(ids))
            {
                Query();
            }
            return 1;
        }

        
        public override  int Query()
        {
            FishBll.Bll.DictBll bll = new FishBll.Bll.DictBll();
            List<FishEntity.DictEntity> list = bll.GetModelList("isdelete=0 and issystem=0 order by pcode asc ,orderid asc");

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = list;

            return 1;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ) return;
            Modify();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            Modify();
        }

        private void FormProductDataSet_Load(object sender, EventArgs e)
        {
            dataGridView1.BackgroundColor = this.BackColor;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("type"))
            {
                if (e.Value == null) return;
                string type = e.Value.ToString();
                FishEntity.SystemDataType item = FishEntity.Variable.ProductDataTypeList.Find((i) => { return i.Code.Equals(type); });
                if (item != null)
                {
                    e.Value = item.Name;
                }
            }

        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_ProductDataSet");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_ProductDataSet");
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
