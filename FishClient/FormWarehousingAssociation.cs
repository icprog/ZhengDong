using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormWarehousingAssociation : FormMenuBase
    {
        FishBll.Bll.StorageOfRequisitionBll _bll = null;
        string name = string.Empty;
        public FormWarehousingAssociation()
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_147");
        }
        public FormWarehousingAssociation(string codeNum)
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_147");
            tmiQuery.Visible = false;
            tmiSave.Visible = false;
            tmiReview.Visible = false;
            tmiprint.Visible = false;
            tmiPrevious.Visible = false;
            tmiNext.Visible = false;
            tmiModify.Visible = false;
            tmiExport.Visible = false;
            tmiDelete.Visible = false;
            tmiClose.Visible = false;
            tmiCancel.Visible = false;
            tmiAdd.Visible = true;
            _bll = new FishBll.Bll.StorageOfRequisitionBll();
            name = codeNum;
            Query();
        }
        public override int Add()
        {
            if (name!=""&&name!=null)
            {
                FormStorageOfRequisition form = new FormStorageOfRequisition(name);
                form.ShowDialog();
                Query();
            }
            return base.Add();
        }
        public override int Query()
        {
            if (name != "" && name != null)
            {
                DataTable table = _bll.getTable(" codeNum= '" + name + "' ");
                if (table != null && table.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        int idx = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[idx];
                        row.Cells["id"].Value = table.Rows[i]["id"].ToString();
                        row.Cells["code"].Value = table.Rows[i]["code"].ToString();
                        row.Cells["fishId"].Value = table.Rows[i]["fishId"].ToString();

                        row.Cells["liWeight"].Value = table.Rows[i]["liWeight"].ToString();
                        row.Cells["price"].Value = table.Rows[i]["price"].ToString();
                        row.Cells["shipName"].Value = table.Rows[i]["shipName"].ToString();

                        row.Cells["country"].Value = table.Rows[i]["country"].ToString();
                        row.Cells["billName"].Value = table.Rows[i]["billName"].ToString();
                        row.Cells["proName"].Value = table.Rows[i]["proName"].ToString();

                        row.Cells["za"].Value = table.Rows[i]["za"].ToString();
                        row.Cells["zf"].Value = table.Rows[i]["zf"].ToString();
                        row.Cells["sand"].Value = table.Rows[i]["sand"].ToString();

                        row.Cells["db"].Value = table.Rows[i]["db"].ToString();
                        row.Cells["applyDate"].Value = table.Rows[i]["applyDate"].ToString();
                        row.Cells["thCodeNum"].Value = table.Rows[i]["thCodeNum"].ToString();

                        row.Cells["supply"].Value = table.Rows[i]["supply"].ToString();
                        row.Cells["saWeight"].Value = table.Rows[i]["saWeight"].ToString();
                        row.Cells["brand"].Value = table.Rows[i]["brand"].ToString();

                        row.Cells["pileNum"].Value = table.Rows[i]["pileNum"].ToString();
                        row.Cells["qualitySpe"].Value = table.Rows[i]["qualitySpe"].ToString();
                        row.Cells["tvn"].Value = table.Rows[i]["tvn"].ToString();

                        row.Cells["hf"].Value = table.Rows[i]["hf"].ToString();
                        row.Cells["sf"].Value = table.Rows[i]["sf"].ToString();
                        row.Cells["shy"].Value = table.Rows[i]["shy"].ToString();

                        row.Cells["remark"].Value = table.Rows[i]["remark"].ToString();
                        row.Cells["codeNum"].Value = table.Rows[i]["codeNum"].ToString();
                        row.Cells["codeNumContract"].Value = table.Rows[i]["codeNumContract"].ToString();

                        row.Cells["jcCode"].Value = table.Rows[i]["jcCode"].ToString();
                        row.Cells["createUser"].Value = table.Rows[i]["createUser"].ToString();
                    }
                }
            }
            return base.Query();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            billNum = dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
            Reflected("FishClient.FormStorageOfRequisition");
        }
        string bill = string.Empty, billNum = string.Empty, path = string.Empty;

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_147");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_147");
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
        void Reflected(string path)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Form doc = (Form)asm.CreateInstance(path);
            Megres.oddNum = billNum;
            doc.Owner = this;
            doc.Show();
        }
        //SELECT id,`code`,fishId,liWeight,price,shipName,country,billName,proName,za,zf,sand,db,applyDate,thCodeNum,supply,saWeight,brand,pileNum,qualitySpe,tvn,hf,sf,shy,remark,codeNum,codeNumContract,jcCode,createUser from t_storageofrequisition
    }
}
