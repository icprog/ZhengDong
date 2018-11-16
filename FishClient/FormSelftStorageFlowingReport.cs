using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    /// <summary>
    /// 自营自制入库流水账
    /// </summary>
    public partial class FormSelftStorageFlowingReport : FormMenuBase
    {
        FishBll.Bll.SelfStorageFlowingReportBll _bll = new FishBll.Bll.SelfStorageFlowingReportBll();
        string _where = string.Empty;

        public FormSelftStorageFlowingReport()
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_SSFR");
            dataGridView1.BackgroundColor = this.BackColor;
            dataGridView1.AutoGenerateColumns = false;
            tmiAdd.Visible = tmiDelete.Visible = tmiModify.Visible = tmiPrevious.Visible = tmiNext.Visible = false;
            tmiSave.Visible = false;tmiCancel.Visible = false;
            dtpStart.Value = DateTime.Now.AddYears(-1);
            dtpEnd.Value = DateTime.Now.AddYears(1);
        }

        public override int Query()
        {
            DateTime startDate = dtpStart.Value.Date;
            DateTime endDate = dtpEnd.Value.Date;
            //_where += string.Format(" date >='{0}' and date<='{1}'" , startDate.ToString("yyyy-MM-01 00:00:00") , endDate.ToString("yyyy-MM-dd :23:59:59"));
            _where = string.Empty;

            decimal weight = 0;
            int package =0;
            List<FishEntity.SelfStorageFlowingReportVo> list = _bll.Report(_where,  startDate ,  endDate , out weight ,out package);
            //CalcData(list);
            dataGridView1.DataSource = list;

            label3.Text = weight.ToString("f2");
            label5.Text = package.ToString();

            return 1;
        }

        protected void CalcData(List<FishEntity.SelfStorageFlowingReportVo> list , DateTime startDate , DateTime endDate)
        {
        }


        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //纵向合并
            if (this.dataGridView1.Columns["productcode"].Index == e.ColumnIndex && e.RowIndex >= 0)
            {
                #region  纵向合并
                using (
                    Brush gridBrush = new SolidBrush(this.dataGridView1.GridColor),
                    backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                {
                    using (Pen gridLinePen = new Pen(gridBrush))
                    {
                        // 擦除原单元格背景
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                        ////绘制线条,这些线条是单元格相互间隔的区分线条,
                        ////因为我们只对列name做处理,所以datagridview自己会处理左侧和上边缘的线条
                        if (e.RowIndex != this.dataGridView1.RowCount - 1)
                        {
                            if (e.Value.ToString() != this.dataGridView1.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value.ToString())
                            {

                                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1,
                                e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);//下边缘的线
                                //绘制值
                                if (e.Value != null)
                                {
                                    e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
                                        Brushes.Black , e.CellBounds.X + 2,
                                        e.CellBounds.Y + 2, StringFormat.GenericDefault);
                                }
                            }
                        }
                        else
                        {
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1,
                                e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);//下边缘的线
                            //绘制值
                            if (e.Value != null)
                            {
                                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
                                    Brushes.Black , e.CellBounds.X + 2,
                                    e.CellBounds.Y + 2, StringFormat.GenericDefault);
                            }
                        }
                        //右侧的线
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                            e.CellBounds.Top, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom - 1);

                        e.Handled = true;
                    }
                }

                #endregion


                //横向合并
                if (this.dataGridView1.Columns["productname"].Index == e.ColumnIndex && e.RowIndex >= 0)
                {

                    using (
                        Brush gridBrush = new SolidBrush(this.dataGridView1.GridColor),
                        backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                    {
                        using (Pen gridLinePen = new Pen(gridBrush))
                        {
                            // 擦除原单元格背景
                            e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                            if (  e.Value.ToString() != this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString())
                            {

                                //右侧的线
                                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top,
                                    e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                                //绘制值
                                if (e.Value != null)
                                {
                                    e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
                                        Brushes.Black, e.CellBounds.X + 2,
                                        e.CellBounds.Y + 2, StringFormat.GenericDefault);
                                }
                            }

                            //下边缘的线
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1,
                                                        e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                            e.Handled = true;
                        }
                    }

                }  

            }

        }
      
        public override int Export()
        {
            List<FishEntity.SelfStorageFlowingReportVo> list = dataGridView1.DataSource as List<FishEntity.SelfStorageFlowingReportVo>;
            if (list == null || list.Count < 1) return 0;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.xls|*.xls";
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK) return 0;

            string filepath = dlg.FileName;
            ExportUtil.ExportSelfStorageFlowing(list, filepath);
            return 1;
        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_SSFR");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_SSFR");
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

        private void FormSelftStorageFlowingReport_Load(object sender, EventArgs e)
        {

        }
    }
}
