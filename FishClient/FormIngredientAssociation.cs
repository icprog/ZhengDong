﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormIngredientAssociation : FormMenuBase
    {
        FishBll.Bll.BatchSheetBll _bll = null;
        string strWhere = string.Empty;
        string getcode = string.Empty;
        string name = string.Empty;
        public FormIngredientAssociation()
        {
            InitializeComponent(); ReadColumnConfig(dataGridView1, "Set_111"); ReadColumnConfig(dataGridView2, "Set_112");
        }
        public FormIngredientAssociation(string CodeNum)
        {
            InitializeComponent(); ReadColumnConfig(dataGridView1, "Set_111"); ReadColumnConfig(dataGridView2, "Set_112");
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
            name = CodeNum; Query();
        }
        public override int Add()
        {
            FormBatchSheet form = new FormBatchSheet();
            form.ShowDialog();
            return base.Add();
        }
        public override int Query()
        {
            _bll = new FishBll.Bll.BatchSheetBll();
            if (name != "" && name != null)
            {
                strWhere += " 1= 1 and codeNum='"+ name+ "' ";
                DataTable table = _bll.getTable(strWhere);
                strWhere = string.Empty;
                if (table != null && table.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        int idx = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[idx];
                        row.Cells["id"].Value = table.Rows[i]["id"].ToString();
                        row.Cells["id1"].Value = table.Rows[i]["id1"].ToString();
                        row.Cells["CODE"].Value = table.Rows[i]["CODE"].ToString();
                        row.Cells["productionDate"].Value = table.Rows[i]["productionDate"].ToString();
                        row.Cells["fishId"].Value = table.Rows[i]["fishId"].ToString();
                        row.Cells["codeNum"].Value = table.Rows[i]["codeNum"].ToString();
                        row.Cells["codeNumContract"].Value = table.Rows[i]["codeNumContract"].ToString();
                        row.Cells["qualitySpe"].Value = table.Rows[i]["qualitySpe"].ToString();
                        row.Cells["country"].Value = table.Rows[i]["country"].ToString();
                        row.Cells["brand"].Value = table.Rows[i]["brand"].ToString();
                        row.Cells["goods"].Value = table.Rows[i]["goods"].ToString();
                        row.Cells["tons"].Value = table.Rows[i]["tons"].ToString();
                        row.Cells["protein"].Value = table.Rows[i]["protein"].ToString();
                        row.Cells["tvn"].Value = table.Rows[i]["tvn"].ToString();
                        row.Cells["salt"].Value = table.Rows[i]["salt"].ToString();
                        row.Cells["acid"].Value = table.Rows[i]["acid"].ToString();
                        row.Cells["ash"].Value = table.Rows[i]["ash"].ToString();
                        row.Cells["histamine"].Value = table.Rows[i]["histamine"].ToString();
                        row.Cells["das"].Value = table.Rows[i]["das"].ToString();
                        row.Cells["price"].Value = table.Rows[i]["price"].ToString();
                        row.Cells["cost"].Value = table.Rows[i]["cost"].ToString();
                        row.Cells["rkCode"].Value = table.Rows[i]["rkCode"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("查无数据！");
                }
            }
            else {
                MessageBox.Show("采购编号没有带入！");
            }
            return base.Query();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridView1.CurrentRow == null) return;
            if (dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString() != null)
            {
                getcode = " isSum = 1 and a.code=" + dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
                _bll = new FishBll.Bll.BatchSheetBll();
                DataTable table = _bll.getTable(getcode);
                strWhere = string.Empty;
                if (table != null && table.Rows.Count > 0)
                {
                    dataGridView2.Rows.Clear();
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        int idx = dataGridView2.Rows.Add();
                        DataGridViewRow row = dataGridView2.Rows[idx];
                        row.Cells["id2"].Value = table.Rows[i]["id"].ToString();
                        row.Cells["id12"].Value = table.Rows[i]["id1"].ToString();
                        row.Cells["CODE2"].Value = table.Rows[i]["CODE"].ToString();
                        row.Cells["productionDate2"].Value = table.Rows[i]["productionDate"].ToString();
                        row.Cells["fishId2"].Value = table.Rows[i]["fishId"].ToString();
                        row.Cells["codeNum2"].Value = table.Rows[i]["codeNum"].ToString();
                        row.Cells["codeNumContract2"].Value = table.Rows[i]["codeNumContract"].ToString();
                        row.Cells["qualitySpe2"].Value = table.Rows[i]["qualitySpe"].ToString();
                        row.Cells["country2"].Value = table.Rows[i]["country"].ToString();
                        row.Cells["brand2"].Value = table.Rows[i]["brand"].ToString();
                        row.Cells["goods2"].Value = table.Rows[i]["goods"].ToString();
                        row.Cells["tons2"].Value = table.Rows[i]["tons"].ToString();
                        row.Cells["protein2"].Value = table.Rows[i]["protein"].ToString();
                        row.Cells["tvn2"].Value = table.Rows[i]["tvn"].ToString();
                        row.Cells["salt2"].Value = table.Rows[i]["salt"].ToString();
                        row.Cells["acid2"].Value = table.Rows[i]["acid"].ToString();
                        row.Cells["ash2"].Value = table.Rows[i]["ash"].ToString();
                        row.Cells["histamine2"].Value = table.Rows[i]["histamine"].ToString();
                        row.Cells["das2"].Value = table.Rows[i]["das"].ToString();
                        row.Cells["price2"].Value = table.Rows[i]["price"].ToString();
                        row.Cells["cost2"].Value = table.Rows[i]["cost"].ToString();
                        row.Cells["rkCode2"].Value = table.Rows[i]["rkCode"].ToString();

                    }
                }
            }
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_111");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_111");
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_112");
            form.ShowDialog();

            ReadColumnConfig(dataGridView2, "Set_112");
        }
    }
}
