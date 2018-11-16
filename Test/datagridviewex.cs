using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Runtime;
using System.ComponentModel;

namespace Test
{
    public static class datagridviewex
    {
    #region 显示统计列
        /// <summary>
        /// 显示DataGridView的统计信息
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="SummaryColumns">要统计的列名称或数据源绑定列名称</param>
        public static void ShowSummary( DataGridView dgv,string[] SummaryColumns)
        {
            SummaryControlContainer summaryControl = new SummaryControlContainer(dgv,SummaryColumns);
            dgv.Controls.Add(summaryControl);
            //dgv.Tag = summaryControl;
            summaryControl.BringToFront();
            summaryControl.Show();
        }
        /// <summary>
        /// 显示DataGridView的统计信息
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="DisplaySumRowHeader">是否显示合计行标题</param>
        /// <param name="SumRowHeaderText">合计列标题</param>
        /// <param name="SumRowHeaderTextBold">合计列标题用粗体显示</param>
        /// <param name="SummaryColumns">要统计的列名称或数据源绑定列名称</param>
        public static void ShowSummary( DataGridView dgv, bool DisplaySumRowHeader, string SumRowHeaderText, bool SumRowHeaderTextBold, string[] SummaryColumns)
        {
            SummaryControlContainer summaryControl = new SummaryControlContainer(dgv, DisplaySumRowHeader, SumRowHeaderText, SumRowHeaderTextBold, SummaryColumns);
            dgv.Controls.Add(summaryControl);
            //dgv.Tag = summaryControl;
            summaryControl.BringToFront();
            summaryControl.Show();
        }
        #endregion

  
    }


    internal class SummaryControlContainer : UserControl
    {
        #region 公有属性

        private bool _DisplaySumRowHeader;
        /// <summary>
        /// 是否显示合计行标题
        /// </summary>
        public bool DisplaySumRowHeader
        {
            get { return _DisplaySumRowHeader; }
            set { _DisplaySumRowHeader = value; }
        }


        private string _SumRowHeaderText = "合计";
        /// <summary>
        /// 合计列标题
        /// </summary>
        public string SumRowHeaderText
        {
            get
            {
                if (_DisplaySumRowHeader)
                {
                    return _SumRowHeaderText;
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _SumRowHeaderText = "合计";
                }
                else
                {
                    _SumRowHeaderText = value;
                }
            }
        }


        private bool _SumRowHeaderTextBold;
        /// <summary>
        /// 合计列标题用粗体显示
        /// </summary>
        public bool SumRowHeaderTextBold
        {
            get { return _SumRowHeaderTextBold; }
            set { _SumRowHeaderTextBold = value; }
        }

        private string[] _SummaryColumns;
        /// <summary>
        /// 要统计的列名称或数据源绑定列名称
        /// </summary>
        public string[] SummaryColumns
        {
            get { return _SummaryColumns; }
            set
            {
                _SummaryColumns = value;
            }
        }

        private string _FormatString = "F02";
        public string FormatString
        {
            get { return _FormatString; }
            set { _FormatString = value; }
        }
        #endregion

        #region 私有变量
        private Hashtable sumBoxHash;
        private DataGridView dgv;
        private Label sumRowHeaderLabel;
        #endregion

        #region 构造函数
        public SummaryControlContainer(DataGridView dgv, string[] summaryColumns)
            : this(dgv, true, "合计", false, summaryColumns)
        {
        }
        public SummaryControlContainer(DataGridView dgv, bool displaySumRowHeader, string sumRowHeaderText,
            bool sumRowHeaderTextBold, string[] summaryColumns)
        {
            if (dgv == null)
            {
                throw new Exception("DataGridView 不能为空!");
            }

            this.dgv = dgv;
            _DisplaySumRowHeader = displaySumRowHeader;
            _SumRowHeaderText = sumRowHeaderText;
            _SumRowHeaderTextBold = sumRowHeaderTextBold;
            _SummaryColumns = summaryColumns;


            this.Visible = true;
            this.Height = dgv.RowTemplate.Height;
            this.Top = dgv.Height - this.Height;
            this.Left = dgv.Left;
            this.BackColor = dgv.RowHeadersDefaultCellStyle.BackColor;

            sumBoxHash = new Hashtable();
            sumRowHeaderLabel = new Label();
            sumRowHeaderLabel.Height = this.Height;
            sumRowHeaderLabel.Width = dgv.RowHeadersWidth;
            sumRowHeaderLabel.BackColor = dgv.RowHeadersDefaultCellStyle.BackColor;

            this.dgv.Resize += new EventHandler(dgv_Resize);
            this.dgv.Scroll += new ScrollEventHandler(dgv_Scroll);
            this.dgv.ColumnWidthChanged += new DataGridViewColumnEventHandler(dgv_ColumnWidthChanged);
            this.dgv.RowHeadersWidthChanged += new EventHandler(dgv_RowHeadersWidthChanged);

            this.dgv.RowsAdded += new DataGridViewRowsAddedEventHandler(dgv_RowsAdded);
            this.dgv.RowsRemoved += new DataGridViewRowsRemovedEventHandler(dgv_RowsRemoved);
            this.dgv.CellValueChanged += new DataGridViewCellEventHandler(dgv_CellValueChanged);
            this.dgv.DataSourceChanged += new EventHandler(dgv_DataSourceChanged);

            this.dgv.ColumnAdded += new DataGridViewColumnEventHandler(dgv_ColumnAdded);
            this.dgv.ColumnRemoved += new DataGridViewColumnEventHandler(dgv_ColumnRemoved);
            this.dgv.ColumnStateChanged += new DataGridViewColumnStateChangedEventHandler(dgv_ColumnStateChanged);
            this.dgv.ColumnDisplayIndexChanged += new DataGridViewColumnEventHandler(dgv_ColumnDisplayIndexChanged);

            reCreateSumBoxes();

        }
        #endregion

        #region 私有方法

        /// <summary>
        /// Checks if passed object is of type of integer
        /// </summary>
        /// <param name="o">object</param>
        /// <returns>true/ false</returns>
        protected bool IsInteger(object o)
        {
            if (o is Int64)
            {
                return true;
            }
            if (o is Int32)
            {
                return true;
            }
            if (o is Int16)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if passed object is of type of decimal/ double
        /// </summary>
        /// <param name="o">object</param>
        /// <returns>true/ false</returns>
        protected bool IsDecimal(object o)
        {
            if (o is Decimal)
            {
                return true;
            }
            if (o is Single)
            {
                return true;
            }
            if (o is Double)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Calculate the Sums of the summary columns
        /// </summary>
        private void calcSummaries()
        {
            foreach (ReadOnlyTextBox roTextBox in sumBoxHash.Values)
            {
                if (roTextBox.IsSummary)
                {
                    roTextBox.Tag = 0;
                    roTextBox.Text = "0";
                    roTextBox.Invalidate();
                }
            }
            if (SummaryColumns != null && SummaryColumns.Length > 0 && sumBoxHash.Count > 0)
            {
                foreach (DataGridViewRow dgvRow in dgv.Rows)
                {
                    foreach (DataGridViewCell dgvCell in dgvRow.Cells)
                    {
                        foreach (DataGridViewColumn dgvColumn in sumBoxHash.Keys)
                        {
                            if (dgvCell.OwningColumn.Equals(dgvColumn))
                            {
                                ReadOnlyTextBox sumBox = (ReadOnlyTextBox)sumBoxHash[dgvColumn];

                                if (sumBox != null && sumBox.IsSummary)
                                {
                                    if (dgvCell.Value != null && !(dgvCell.Value is DBNull))
                                    {
                                        if (IsInteger(dgvCell.Value))
                                        {
                                            sumBox.Tag = Convert.ToInt64(sumBox.Tag) + Convert.ToInt64(dgvCell.Value);
                                        }
                                        else if (IsDecimal(dgvCell.Value))
                                        {
                                            sumBox.Tag = Convert.ToDecimal(sumBox.Tag) + Convert.ToDecimal(dgvCell.Value);
                                        }

                                        sumBox.Text = string.Format("{0}", sumBox.Tag);
                                        sumBox.Invalidate();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Create summary boxes for each Column of the DataGridView        
        /// </summary>
        private void reCreateSumBoxes()
        {
            foreach (Control control in sumBoxHash.Values)
            {
                this.Controls.Remove(control);
            }
            sumBoxHash.Clear();

            int iCnt = 0;

            ReadOnlyTextBox sumBox;
            List<DataGridViewColumn> sortedColumns = SortedColumns;
            foreach (DataGridViewColumn dgvColumn in sortedColumns)
            {
                sumBox = new ReadOnlyTextBox();
                sumBoxHash.Add(dgvColumn, sumBox);

                sumBox.Top = 0;
                sumBox.Height = dgv.RowTemplate.Height;
                sumBox.BorderColor = dgv.GridColor;
                sumBox.BackColor = dgv.DefaultCellStyle.BackColor;
                sumBox.ForeColor = dgv.DefaultCellStyle.ForeColor;
                sumBox.BringToFront();

                if (dgv.ColumnCount - iCnt == 1)
                {
                    sumBox.IsLastColumn = true;
                }

                if (SummaryColumns != null && SummaryColumns.Length > 0)
                {
                    for (int iCntX = 0; iCntX < SummaryColumns.Length; iCntX++)
                    {
                        if (SummaryColumns[iCntX] == dgvColumn.DataPropertyName ||
                            SummaryColumns[iCntX] == dgvColumn.Name)
                        {
                            sumBox.TextAlign = TextHelper.TranslateGridColumnAligment(dgvColumn.DefaultCellStyle.Alignment);
                            sumBox.IsSummary = true;
                            sumBox.FormatString = dgvColumn.DefaultCellStyle.Format;

                            if (dgvColumn.ValueType == typeof(System.Int32) || dgvColumn.ValueType == typeof(System.Int16) ||
                                dgvColumn.ValueType == typeof(System.Int64) || dgvColumn.ValueType == typeof(System.Single) ||
                                dgvColumn.ValueType == typeof(System.Double) || dgvColumn.ValueType == typeof(System.Single) ||
                                dgvColumn.ValueType == typeof(System.Decimal))
                            {
                                sumBox.Tag = System.Activator.CreateInstance(dgvColumn.ValueType);
                            }
                        }
                    }
                }

                sumBox.BringToFront();
                this.Controls.Add(sumBox);

                iCnt++;
            }

            sumRowHeaderLabel.Font = new Font(dgv.DefaultCellStyle.Font, SumRowHeaderTextBold ? FontStyle.Bold : FontStyle.Regular);
            sumRowHeaderLabel.Anchor = AnchorStyles.Left;
            sumRowHeaderLabel.TextAlign = ContentAlignment.MiddleRight;
            sumRowHeaderLabel.Height = this.Height;
            sumRowHeaderLabel.Width = dgv.RowHeadersWidth;
            sumRowHeaderLabel.Top = 0;
            sumRowHeaderLabel.Text = DisplaySumRowHeader ? SumRowHeaderText : string.Empty;
            sumRowHeaderLabel.ForeColor = dgv.DefaultCellStyle.ForeColor;
            sumRowHeaderLabel.Margin = new Padding(0);
            sumRowHeaderLabel.Padding = new Padding(0);
            this.Controls.Add(sumRowHeaderLabel);
            calcSummaries();
            resizeSumBoxes();
        }

        /// <summary>
        /// Order the columns in the way they are displayed
        /// </summary>
        private List<DataGridViewColumn> SortedColumns
        {
            get
            {
                List<DataGridViewColumn> result = new List<DataGridViewColumn>();
                DataGridViewColumn column = dgv.Columns.GetFirstColumn(DataGridViewElementStates.None);
                if (column == null)
                {
                    return result;
                }
                result.Add(column);
                while ((column = dgv.Columns.GetNextColumn(column, DataGridViewElementStates.None, DataGridViewElementStates.None)) != null)
                {
                    result.Add(column);
                }

                return result;
            }
        }

        /// <summary>
        /// Resize the summary Boxes depending on the 
        /// width of the Columns of the DataGridView
        /// </summary>
        private void resizeSumBoxes()
        {
            try
            {
                this.SuspendLayout();
                if (sumBoxHash != null && sumBoxHash.Count > 0)
                    try
                    {
                        int rowHeaderWidth = dgv.RowHeadersVisible ? dgv.RowHeadersWidth - 1 : 0;
                        int sumLabelWidth = dgv.RowHeadersVisible ? dgv.RowHeadersWidth - 1 : 0;
                        int curPos = rowHeaderWidth;

                        if (DisplaySumRowHeader && sumLabelWidth > 0)
                        {
                            sumRowHeaderLabel.Visible = true;
                            sumRowHeaderLabel.Width = sumLabelWidth;
                            if (dgv.RightToLeft == RightToLeft.Yes)
                            {
                                if (sumRowHeaderLabel.Dock != DockStyle.Right)
                                {
                                    sumRowHeaderLabel.Dock = DockStyle.Right;
                                }
                            }
                            else
                            {
                                if (sumRowHeaderLabel.Dock != DockStyle.Left)
                                {
                                    sumRowHeaderLabel.Dock = DockStyle.Left;
                                }
                            }
                        }
                        else
                        {
                            if (sumRowHeaderLabel.Visible)
                            {
                                sumRowHeaderLabel.Visible = false;
                            }
                        }

                        int iCnt = 0;
                        Rectangle oldBounds;

                        foreach (DataGridViewColumn dgvColumn in SortedColumns)
                        {
                            ReadOnlyTextBox sumBox = (ReadOnlyTextBox)sumBoxHash[dgvColumn];
                            if (sumBox != null)
                            {
                                oldBounds = sumBox.Bounds;
                                if (!dgvColumn.Visible)
                                {
                                    sumBox.Visible = false;
                                    continue;
                                }


                                int from = dgvColumn.Frozen ? curPos : curPos - dgv.HorizontalScrollingOffset;

                                int width = dgvColumn.Width + (iCnt == 0 ? 0 : 0);

                                if (from < rowHeaderWidth)
                                {
                                    width -= rowHeaderWidth - from;
                                    from = rowHeaderWidth;
                                }

                                if (from + width > this.Width)
                                {
                                    width = this.Width - from;
                                }

                                if (width < 4)
                                {
                                    if (sumBox.Visible)
                                    {
                                        sumBox.Visible = false;
                                    }
                                }
                                else
                                {
                                    if (this.RightToLeft == RightToLeft.Yes)
                                    {
                                        from = this.Width - from - width;
                                    }


                                    if (sumBox.Left != from || sumBox.Width != width)
                                    {
                                        sumBox.SetBounds(from, 0, width, 0, BoundsSpecified.X | BoundsSpecified.Width);
                                    }

                                    if (!sumBox.Visible)
                                    {
                                        sumBox.Visible = true;
                                    }
                                }

                                curPos += dgvColumn.Width + (iCnt == 0 ? 0 : 0);
                                if (oldBounds != sumBox.Bounds)
                                {
                                    sumBox.Invalidate();
                                }
                            }
                            iCnt++;
                        }
                    }
                    finally
                    {
                        this.ResumeLayout();
                    }
            }
#if (DEBUG)
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                System.Diagnostics.Debug.WriteLine(ee.ToString());
            }

#else
            catch
            { }
#endif
        }

        #endregion

        #region 事件处理程序
        void dgv_DataSourceChanged(object sender, EventArgs e)
        {
            calcSummaries();
        }
        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ReadOnlyTextBox roTextBox = (ReadOnlyTextBox)sumBoxHash[dgv.Columns[e.ColumnIndex]];
            if (roTextBox != null)
            {
                if (roTextBox.IsSummary)
                {
                    calcSummaries();
                }
            }
        }
        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            calcSummaries();
        }
        private void dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calcSummaries();
        }

        private void dgv_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //resizeSumBoxes();
            reCreateSumBoxes();
        }
        private void dgv_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            resizeSumBoxes();
        }
        private void dgv_Scroll(object sender, ScrollEventArgs e)
        {
            resizeSumBoxes();
        }
        private void dgv_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            resizeSumBoxes();
        }
        private void dgv_RowHeadersWidthChanged(object sender, EventArgs e)
        {
            int columnsWidth = 0;
            for (int iCnt = 0; iCnt < dgv.Columns.Count; iCnt++)
            {
                if (dgv.Columns[iCnt].Visible)
                {
                    if (dgv.Columns[iCnt].AutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
                    {
                        columnsWidth += dgv.Columns[iCnt].MinimumWidth;
                    }
                    else
                        columnsWidth += dgv.Columns[iCnt].Width;
                }
            }
            this.Width = columnsWidth;
            resizeSumBoxes();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            resizeSumBoxes();
        }
        private void dgv_Resize(object sender, EventArgs e)
        {
            adjustSumControlToGrid();

            resizeSumBoxes();
        }
        private void adjustSumControlToGrid()
        {
            ScrollBar horizontalScrollBar = (ScrollBar)typeof(DataGridView).GetProperty("HorizontalScrollBar", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).GetValue(dgv, null);
            ScrollBar verticalScrollBar = (ScrollBar)typeof(DataGridView).GetProperty("VerticalScrollBar", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).GetValue(dgv, null);


            if (horizontalScrollBar.Visible)
            {
                this.Top = dgv.Height - this.Height - horizontalScrollBar.Height;
            }
            else
            {
                this.Top = dgv.Height - this.Height;
            }
            this.Left = dgv.Left;
            if (verticalScrollBar.Visible)
            {
                this.Width = dgv.Width - verticalScrollBar.Width;
            }
            else
            {
                this.Width = dgv.Width;
            }
        }


        private void dgv_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            reCreateSumBoxes();
        }
        private void dgv_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            reCreateSumBoxes();
        }
        #endregion
    }

    internal partial class ReadOnlyTextBox : Control
    {

        StringFormat format;
        public ReadOnlyTextBox()
        {
            //InitializeComponent();

            format = new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces);
            format.LineAlignment = StringAlignment.Center;

            this.Height = 10;
            this.Width = 10;

            this.Padding = new Padding(2);
        }

        public ReadOnlyTextBox(IContainer container)
        {
            container.Add(this);
            //InitializeComponent();

            this.TextChanged += new EventHandler(ReadOnlyTextBox_TextChanged);
        }

        private void ReadOnlyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(formatString) && !string.IsNullOrEmpty(Text))
            {
                Text = string.Format(formatString, Text);
            }
        }

        private Color borderColor = Color.Black;

        private bool isSummary;
        public bool IsSummary
        {
            get { return isSummary; }
            set { isSummary = value; }
        }

        private bool isLastColumn;
        public bool IsLastColumn
        {
            get { return isLastColumn; }
            set { isLastColumn = value; }
        }

        private string formatString;
        public string FormatString
        {
            get { return formatString; }
            set { formatString = value; }
        }


        private HorizontalAlignment textAlign = HorizontalAlignment.Left;
        [DefaultValue(HorizontalAlignment.Left)]
        public HorizontalAlignment TextAlign
        {
            get { return textAlign; }
            set
            {
                textAlign = value;
                setFormatFlags();
            }
        }

        private StringTrimming trimming = StringTrimming.None;
        [DefaultValue(StringTrimming.None)]
        public StringTrimming Trimming
        {
            get { return trimming; }
            set
            {
                trimming = value;
                setFormatFlags();
            }
        }

        private void setFormatFlags()
        {
            format.Alignment = TextHelper.TranslateAligment(TextAlign);
            format.Trimming = trimming;
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int subWidth = 0;
            Rectangle textBounds;

            if (!string.IsNullOrEmpty(formatString) && !string.IsNullOrEmpty(Text))
            {
                Text = String.Format("{0:" + formatString + "}", Convert.ToDecimal(Text));
            }

            textBounds = new Rectangle(this.ClientRectangle.X + 2, this.ClientRectangle.Y + 2, this.ClientRectangle.Width - 2, this.ClientRectangle.Height - 2);
            using (Pen pen = new Pen(borderColor))
            {
                if (isLastColumn)
                    subWidth = 1;

                e.Graphics.FillRectangle(new SolidBrush(this.BackColor), this.ClientRectangle);
                e.Graphics.DrawRectangle(pen, this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width - subWidth, this.ClientRectangle.Height - 1);
                e.Graphics.DrawString(Text, Font, Brushes.Black, textBounds, format);
            }
        }
    }
    internal static class TextHelper
    {
        public static StringAlignment TranslateAligment(HorizontalAlignment aligment)
        {
            if (aligment == HorizontalAlignment.Left)
                return StringAlignment.Near;
            else if (aligment == HorizontalAlignment.Right)
                return StringAlignment.Far;
            else
                return StringAlignment.Center;
        }

        public static HorizontalAlignment TranslateGridColumnAligment(DataGridViewContentAlignment aligment)
        {
            if (aligment == DataGridViewContentAlignment.BottomLeft || aligment == DataGridViewContentAlignment.MiddleLeft || aligment == DataGridViewContentAlignment.TopLeft)
                return HorizontalAlignment.Left;
            else if (aligment == DataGridViewContentAlignment.BottomRight || aligment == DataGridViewContentAlignment.MiddleRight || aligment == DataGridViewContentAlignment.TopRight)
                return HorizontalAlignment.Right;
            else
                return HorizontalAlignment.Center;
        }

        public static TextFormatFlags TranslateAligmentToFlag(HorizontalAlignment aligment)
        {
            if (aligment == HorizontalAlignment.Left)
                return TextFormatFlags.Left;
            else if (aligment == HorizontalAlignment.Right)
                return TextFormatFlags.Right;
            else
                return TextFormatFlags.HorizontalCenter;
        }

        public static TextFormatFlags TranslateTrimmingToFlag(StringTrimming trimming)
        {
            if (trimming == StringTrimming.EllipsisCharacter)
                return TextFormatFlags.EndEllipsis;
            else if (trimming == StringTrimming.EllipsisPath)
                return TextFormatFlags.PathEllipsis;
            if (trimming == StringTrimming.EllipsisWord)
                return TextFormatFlags.WordEllipsis;
            if (trimming == StringTrimming.Word)
                return TextFormatFlags.WordBreak;
            else
                return TextFormatFlags.Default;
        }
    }

}
