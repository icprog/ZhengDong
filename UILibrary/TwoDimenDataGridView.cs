using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UILibrary
{
    public class TwoDimenDataGridView 
    {
            public TwoDimenDataGridView(DataGridView gridview)
            {
                gridview.CellPainting += new DataGridViewCellPaintingEventHandler(gridview_CellPainting);
            }

            int top = 0;
            int left = 0;
            int height = 0;
            int width1 = 0;
            public void gridview_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
            {
                #region 重绘datagridview表头
                DataGridView dgv = (DataGridView)(sender);

                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    DrawCell(e, dgv);
                }


                if (e.RowIndex != -1) return;
                foreach (TopHeader item in Headers)
                {
                    if (e.ColumnIndex >= item.Index && e.ColumnIndex < item.Index + item.Span)
                    {
                        if (e.ColumnIndex == item.Index)
                        {
                            top = e.CellBounds.Top;
                            left = e.CellBounds.Left;
                            height = e.CellBounds.Height;
                        }
                        int width = 0;
                        for (int i = item.Index; i < item.Span + item.Index; i++)
                        {
                            width += dgv.Columns[i].Width;
                        }
                        Rectangle rect = new Rectangle(left, top, width, e.CellBounds.Height-1);
                        using (Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                        {
                            //抹去原来的cell背景
                            e.Graphics.FillRectangle(backColorBrush, rect);
                        }

                        using (Pen gridLinePen = new Pen(dgv.GridColor))
                        {
                            e.Graphics.DrawLine(gridLinePen, left, top, left + width, top);
                            
                            e.Graphics.DrawLine(gridLinePen, left, top + height / 2, left + width, top + height / 2);

                            e.Graphics.DrawLine(gridLinePen, left + width-1 , top, left + width-1, top + height / 2);
                            
                            e.Graphics.DrawLine(gridLinePen, left, top + height-1, left + width, top + height-1);

                            width1 = 0;
                            //e.Graphics.DrawLine(gridLinePen, left, top, left, top + height);
                            for (int i = item.Index; i < item.Span + item.Index; i++)
                            {
                                width1 += dgv.Columns[i].Width;
                                e.Graphics.DrawLine(gridLinePen, left + width1-1, top + height / 2, left + width1-1, top + height);
                            }
                            SizeF sf = e.Graphics.MeasureString(item.Text, e.CellStyle.Font);
                            float lstr = (width - sf.Width) / 2;
                            float rstr = (height / 2 - sf.Height) / 2;
                            //画出文本框
                            if (item.Text != "")
                            {
                                e.Graphics.DrawString(item.Text, e.CellStyle.Font,
                                                           new SolidBrush(e.CellStyle.ForeColor),
                                                             left + lstr,
                                                             top + rstr,
                                                             StringFormat.GenericDefault);
                            }
                            width = 0;
                            width1 = 0;
                            for (int i = item.Index; i < item.Span + item.Index; i++)
                            {
                                string columnValue = dgv.Columns[i].HeaderText;
                                width1 = dgv.Columns[i].Width;
                                sf = e.Graphics.MeasureString(columnValue, e.CellStyle.Font);
                                lstr = (width1 - sf.Width) / 2;
                                rstr = (height / 2 - sf.Height) / 2;
                                if (columnValue != "")
                                {
                                    e.Graphics.DrawString(columnValue, e.CellStyle.Font,
                                                               new SolidBrush(e.CellStyle.ForeColor),
                                                                 left + width + lstr,
                                                                 top + height / 2 + rstr,
                                                                 StringFormat.GenericDefault);
                                }
                                width += dgv.Columns[i].Width;
                            }
                        }
                        e.Handled = true;
                    }
                }
                #endregion
            }

            #region 自定义方法
            /// <summary>
            /// 画单元格
            /// </summary>
            /// <param name="e"></param>
            private void DrawCell(DataGridViewCellPaintingEventArgs e , DataGridView dgv)
            {
                if (dgv.CurrentRow == null) return;

                if (e.CellStyle.Alignment == DataGridViewContentAlignment.NotSet)
                {
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                Brush gridBrush = new SolidBrush( dgv.GridColor);
                SolidBrush backBrush = new SolidBrush(e.CellStyle.BackColor);
                SolidBrush fontBrush = new SolidBrush(e.CellStyle.ForeColor);
                int cellwidth;
                //上面相同的行数
                int UpRows = 0;
                //下面相同的行数
                int DownRows = 0;
                //总行数
                int count = 0;
                if (this.MergeColumnNames.Contains(dgv.Columns[e.ColumnIndex].Name) && e.RowIndex != -1)
                {
                    cellwidth = e.CellBounds.Width;
                    Pen gridLinePen = new Pen(gridBrush);
                    string curValue = e.Value == null ? "" : e.Value.ToString().Trim();
                    string curSelected = dgv.CurrentRow.Cells[e.ColumnIndex].Value == null ? "" : dgv.CurrentRow.Cells[e.ColumnIndex].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(curValue))
                    {
                        #region 获取下面的行数
                        for (int i = e.RowIndex; i < dgv.Rows.Count; i++)
                        {
                            if (dgv.Rows[i].Cells[e.ColumnIndex].Value.ToString().Equals(curValue))
                            {
                                //this.Rows[i].Cells[e.ColumnIndex].Selected = this.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected;

                                DownRows++;
                                if (e.RowIndex != i)
                                {
                                    cellwidth = cellwidth < dgv.Rows[i].Cells[e.ColumnIndex].Size.Width ? cellwidth : dgv.Rows[i].Cells[e.ColumnIndex].Size.Width;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        #endregion
                        #region 获取上面的行数
                        for (int i = e.RowIndex; i >= 0; i--)
                        {
                            if (dgv.Rows[i].Cells[e.ColumnIndex].Value.ToString().Equals(curValue))
                            {
                                //this.Rows[i].Cells[e.ColumnIndex].Selected = this.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected;
                                UpRows++;
                                if (e.RowIndex != i)
                                {
                                    cellwidth = cellwidth < dgv.Rows[i].Cells[e.ColumnIndex].Size.Width ? cellwidth : dgv.Rows[i].Cells[e.ColumnIndex].Size.Width;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        #endregion
                        count = DownRows + UpRows - 1;
                        if (count < 2)
                        {
                            return;
                        }
                    }
                    if (dgv.Rows[e.RowIndex].Selected)
                    {
                        backBrush.Color = e.CellStyle.SelectionBackColor;
                        fontBrush.Color = e.CellStyle.SelectionForeColor;
                    }
                    //以背景色填充
                    e.Graphics.FillRectangle(backBrush, e.CellBounds);
                    //画字符串
                    PaintingFont(e, cellwidth, UpRows, DownRows, count);
                    if (DownRows == 1)
                    {
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                        count = 0;
                    }
                    // 画右边线
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);

                    e.Handled = true;
                }
            }

            /// <summary>
            /// 画字符串
            /// </summary>
            /// <param name="e"></param>
            /// <param name="cellwidth"></param>
            /// <param name="UpRows"></param>
            /// <param name="DownRows"></param>
            /// <param name="count"></param>
            private void PaintingFont(System.Windows.Forms.DataGridViewCellPaintingEventArgs e, int cellwidth, int UpRows, int DownRows, int count)
            {
                SolidBrush fontBrush = new SolidBrush(e.CellStyle.ForeColor);
                int fontheight = (int)e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Height;
                int fontwidth = (int)e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Width;
                int cellheight = e.CellBounds.Height;

                if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomCenter)
                {
                    e.Graphics.DrawString((String)e.Value.ToString(), e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y + cellheight * DownRows - fontheight);
                }
                else if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomLeft)
                {
                    e.Graphics.DrawString((String)e.Value.ToString(), e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y + cellheight * DownRows - fontheight);
                }
                else if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomRight)
                {
                    e.Graphics.DrawString((String)e.Value.ToString(), e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y + cellheight * DownRows - fontheight);
                }
                else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter)
                {
                    e.Graphics.DrawString((String)e.Value.ToString(), e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
                }
                else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleLeft)
                {
                    e.Graphics.DrawString((String)e.Value.ToString(), e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
                }
                else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleRight)
                {
                    e.Graphics.DrawString((String)e.Value.ToString(), e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
                }
                else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopCenter)
                {
                    e.Graphics.DrawString((String)e.Value.ToString(), e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1));
                }
                else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopLeft)
                {
                    e.Graphics.DrawString((String)e.Value.ToString(), e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y - cellheight * (UpRows - 1));
                }
                else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopRight)
                {
                    e.Graphics.DrawString((String)e.Value.ToString(), e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y - cellheight * (UpRows - 1));
                }
                else
                {
                    e.Graphics.DrawString((String)e.Value.ToString(), e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
                }
            }
            #endregion

            private List<TopHeader> _headers = new List<TopHeader>();
            public List<TopHeader> Headers
            {
                get { return _headers; }
            }

            public struct TopHeader
            {
                public TopHeader(int index, int span, string text)
                {
                    this.Index = index;
                    this.Span = span;
                    this.Text = text;
                }
                public int Index;
                public int Span;
                public string Text;
            }

            private  List<string> _mergecolumnnames = new List<string>();

            public List<string> MergeColumnNames
            {
                get { return _mergecolumnnames; }
                set { _mergecolumnnames = value; }
            }

    }
}
