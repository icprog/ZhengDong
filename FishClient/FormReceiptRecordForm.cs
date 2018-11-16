using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormReceiptRecordForm : FormMenuBase
    {
        FishEntity.ReceiptRecordEntity _list = new FishEntity.ReceiptRecordEntity();
        FishBll.Bll.ReceiptRecordBll _bll = new FishBll.Bll.ReceiptRecordBll();
        public FormReceiptRecordForm()
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView3, "Set_136");
        }
        public override int Query()
        {
            string strwhere = "1=1 ";
            if (!string.IsNullOrEmpty(txtcodeContract.Text))
            {
                strwhere += " and codeOfYu  like '%" + txtcodeContract.Text + "%'";
            }
            if (!string.IsNullOrEmpty(textunit.Text))
            {
                strwhere += " and fuKuanDanWei like '%" + textunit.Text + "%'";
            }
            strwhere += string.Format(" and date>='{0}' and date<='{1}'",
                dtpdateBefore.Value.ToString("yyyy-MM-dd 00:00:00"),
                dtpdateRear.Value.ToString("yyyy-MM-dd 23:59:59"));
            DataTable queryDatatble = _bll.getTable(strwhere);
            if (queryDatatble != null && queryDatatble.Rows.Count > 0)
            {
                dataGridView3.Rows.Clear();
                for (int i = 0; i < queryDatatble.Rows.Count; i++)
                {
                    int idx = dataGridView3.Rows.Add();
                    DataGridViewRow row = dataGridView3.Rows[idx];
                    row.Cells["codeContract"].Value = queryDatatble.Rows[i]["codeContract"].ToString();
                    row.Cells["code"].Value = queryDatatble.Rows[i]["code"].ToString();
                    row.Cells["fuKuanOther"].Value = queryDatatble.Rows[i]["fuKuanOther"].ToString();
                    row.Cells["date"].Value = queryDatatble.Rows[i]["date"].ToString();
                    row.Cells["codePrice"].Value = queryDatatble.Rows[i]["codePrice"].ToString();
                    row.Cells["codeYunFei"].Value = queryDatatble.Rows[i]["codeYunFei"].ToString();
                    row.Cells["codeHuiKou"].Value = queryDatatble.Rows[i]["codeHuiKou"].ToString();
                    row.Cells["fuKuanDanWei"].Value = queryDatatble.Rows[i]["fuKuanDanWei"].ToString();
                    row.Cells["fuKuanZhangHao"].Value = queryDatatble.Rows[i]["fuKuanZhangHao"].ToString();
                    row.Cells["price"].Value = queryDatatble.Rows[i]["price"].ToString();
                    row.Cells["weight"].Value = queryDatatble.Rows[i]["weight"].ToString();
                    row.Cells["fuKuanType"].Value = queryDatatble.Rows[i]["fuKuanType"].ToString();
                    row.Cells["fuKuanMethod"].Value = queryDatatble.Rows[i]["fuKuanMethod"].ToString();
                    row.Cells["RMB"].Value = queryDatatble.Rows[i]["RMB"].ToString();
                    row.Cells["invoiceType"].Value = queryDatatble.Rows[i]["invoiceType"].ToString();
                    row.Cells["remark"].Value = queryDatatble.Rows[i]["remark"].ToString();
                    row.Cells["DemaUndnit"].Value = queryDatatble.Rows[i]["DemaUndnit"].ToString();
                    row.Cells["DemaUndnitId"].Value = queryDatatble.Rows[i]["DemaUndnitId"].ToString();
                    row.Cells["DemandSideContact"].Value = queryDatatble.Rows[i]["DemandSideContact"].ToString();
                    row.Cells["DemandSideContactId"].Value = queryDatatble.Rows[i]["DemandSideContactId"].ToString();
                }
            }
            else {
                MessageBox.Show("查无数据！");
            }
            return base.Query();
        }
        private void textunit_Click(object sender, EventArgs e)
        {
            FormCompanyList Form = new FormCompanyList();
            Form.StartPosition = FormStartPosition.CenterParent;
            if (Form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            if (Form.SelectCompany == null)
            {
                return;
            }
            textunit.Text = Form.SelectCompany.fullname;
            textunit.Tag = Form.SelectCompany.code;
        }

        private void FormReceiptRecordForm_Load ( object sender ,EventArgs e )
        {
            if ( Megres . oddNum != "" )
            {
                Query ( );
            }
            Megres . oddNum = string . Empty;
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView3.Columns, "Set_136");
            form.ShowDialog();

            ReadColumnConfig(dataGridView3, "Set_136");
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
