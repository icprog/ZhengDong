using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient.UIForms
{
    public partial class FormGBList : FormBase
    {
        private List<FishEntity.DictEntity> _columns = null;
        private int _productid = 0;

        public FormGBList( int productid)
        {
            InitializeComponent();

            _productid = productid;

            dataGridView1.BackgroundColor = this.BackColor;
            InitDataGridViewColumns();
            ReadColumnConfig(dataGridView1, "Set_GBList");

            SetDetail();
        }

        protected void InitDataGridViewColumns()
        {
            dataGridView1.Columns.Clear();
            if (FishEntity.Variable.ProductDataTypeList == null) return;
            FishEntity.SystemDataType checkType = FishEntity.Variable.ProductDataTypeList.Find((i) => { return i.Code == FishEntity.Constant.CheckItem; });
            if (checkType == null) return;

            FishBll.Bll.DictBll bll = new FishBll.Bll.DictBll();
            _columns = bll.GetModelList(string.Format(" isdelete=0 and issystem=0 and pcode='{0}' order by pcode asc,orderid asc", checkType.Code));
            if (_columns == null || _columns.Count < 1) return;

            try
            {
                DataGridViewColumn col = null;

                foreach (FishEntity.DictEntity item in _columns)
                {
                    col = new DataGridViewTextBoxColumn();
                    col.HeaderText = item.name;
                    col.Name = item.code;
                    col.Width = 70;
                    dataGridView1.Columns.Add(col);

                    col = new DataGridViewTextBoxColumn();
                    col.HeaderText = item.name + "_id";
                    col.Name = item.code + "_id";
                    col.Visible = false;
                    dataGridView1.Columns.Add(col);
                }

                col = new DataGridViewTextBoxColumn();
                col.Name = "id";
                col.HeaderText = "id";
                dataGridView1.Columns.Add(col);
                col.Visible = false;

                col = new DataGridViewTextBoxColumn();
                col.Name = "line";
                col.HeaderText = "line";
                col.Visible = false;
                dataGridView1.Columns.Add(col);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        protected void SetDetail()
        {
            
            FishBll.Bll.CheckDetailBll detailbll = new FishBll.Bll.CheckDetailBll();
            List<FishEntity.CheckDetailEntity> details = detailbll.GetCheckDetailVo(_productid);
            SetDetail(details);
        }

        protected void SetDetail(List<FishEntity.CheckDetailEntity> details)
        {
            dataGridView1.Rows.Clear();
            if (details == null || details.Count < 1) return;

            SortedDictionary<int, List<FishEntity.CheckDetailEntity>> groups = Group(details);

            SortedDictionary<int, List<FishEntity.CheckDetailEntity>> lines = new SortedDictionary<int,List<FishEntity.CheckDetailEntity>>(); 

            foreach (KeyValuePair<int, List<FishEntity.CheckDetailEntity>> line in groups)
            {
                SortedDictionary<int, List<FishEntity.CheckDetailEntity>> datas = Lines(line.Value);
                AddRow(datas);
            }

           
        }

        protected void AddRow(SortedDictionary<int, List<FishEntity.CheckDetailEntity>> lines )
        {
            foreach (KeyValuePair<int, List<FishEntity.CheckDetailEntity>> item in lines)
            {
                int idx = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[idx];
                row.Cells["line"].Value = item.Key;

                foreach (FishEntity.CheckDetailEntity child in item.Value)
                {
                    FishEntity.DictEntity dict = _columns.Find((i) => { return i.code.Equals(child.checkkey); });
                    if (dict == null) continue;

                    if (dataGridView1.Columns.Contains(child.checkkey + "_id"))
                    {
                        row.Cells[child.checkkey + "_id"].Value = child.id;
                    }
                    if (dataGridView1.Columns.Contains(child.checkkey))
                    {
                        row.Cells[child.checkkey].Value = child.checkvalue;
                    }
                }
            }
        }

        protected SortedDictionary<int, List<FishEntity.CheckDetailEntity>> Group(List<FishEntity.CheckDetailEntity> details)
        {
            SortedDictionary<int, List<FishEntity.CheckDetailEntity>> groups = new SortedDictionary<int, List<FishEntity.CheckDetailEntity>>();
            foreach (FishEntity.CheckDetailEntity item in details)
            {
                if (groups.ContainsKey(item.mid) == false)
                {
                    List<FishEntity.CheckDetailEntity> array = new List<FishEntity.CheckDetailEntity>();
                    array.Add(item);
                    groups.Add(item.mid, array);
                }
                else
                {
                    List<FishEntity.CheckDetailEntity> array = groups[item.mid];
                    array.Add(item);
                }
            }
            return groups;
        }


        protected SortedDictionary<int, List<FishEntity.CheckDetailEntity>> Lines(List<FishEntity.CheckDetailEntity> details)
        {
            SortedDictionary<int, List<FishEntity.CheckDetailEntity>> lines = new SortedDictionary<int, List<FishEntity.CheckDetailEntity>>();
            foreach (FishEntity.CheckDetailEntity item in details)
            {
                if (lines.ContainsKey(item.line) == false)
                {
                    List<FishEntity.CheckDetailEntity> array = new List<FishEntity.CheckDetailEntity>();
                    array.Add(item);
                    lines.Add(item.line, array);
                }
                else
                {
                    List<FishEntity.CheckDetailEntity> array = lines[item.line];
                    array.Add(item);
                }
            }
            return lines;
        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_GBList");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_GBList");
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
