using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormCheck : FormMenuBase
    {
        protected int _productId = 0;
        protected string _productName = string.Empty;
        protected string _productCode = string.Empty;
        protected FishBll.Bll.CheckRecordBll _bll = new FishBll.Bll.CheckRecordBll();
        protected List<FishEntity.CheckRecordEntity> _records = null;
        public event EventHandler RefreshDataEvent = null;

        public FormCheck()
        {
            InitializeComponent();

            txtFish.Enabled = true;
            _productId = 0;
            _productCode = string.Empty;
            _productName = string.Empty;

            InitMenu();
        }

        protected void InitMenu()
        {
            tmiAdd.Visible = true;
            tmiDelete.Visible = false;
            tmiQuery.Visible = false;
            tmiCancel.Visible = false;
            tmiExport.Visible = false;
            tmiModify.Visible = true;
            tmiNext.Visible = false;
            tmiPrevious.Visible = false;
            tmiSave.Visible = true;

        }
        
        public FormCheck(int productid,string productcode, string productname)
        {
            InitializeComponent();

            _productId = productid;
            _productCode = productcode;
            _productName = productname;
            _records = null;

            InitMenu();
          
            txtFish.Text = _productName;
            txtFish.Tag = _productId;
            txtFish.Enabled = false;
            lblFishCode.Text = _productCode;

            Query();
        }

        public override int Query()
        {
            Clear();
            _records = _bll.GetModelList("productid=" + _productId);
            if (_records == null || _records.Count < 1) return 1;

            _records.Sort(new Comparison<FishEntity.CheckRecordEntity>((i, j) => { return i.recordno.CompareTo(j.recordno); }));

            foreach (FishEntity.CheckRecordEntity item in _records)
            {
                int startCol = 3;
                int startRow=0;
                SetValue(startCol + (item.recordno - 1), startRow, item.checkdate,null );
                SetValue(startCol + (item.recordno - 1), startRow + 1, item.testdate,null );
                SetValue(startCol + (item.recordno - 1), startRow + 2, item.Sendsamplename, item.testcompanyid);
                SetValue(startCol + (item.recordno - 1), startRow + 3, item.testcompanyname , item.testcompanyid);
                SetValue(startCol + (item.recordno - 1), startRow + 4, item.testperiod.ToString() ,null );

                SetValue(startCol + (item.recordno - 1), startRow + 7, item.regularindex1.HasValue ? item.regularindex1.Value.ToString():"",null );
                SetValue(startCol + (item.recordno - 1), startRow + 8, item.regularindex2.HasValue ? item.regularindex2.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 9, item.regularindex3.HasValue ? item.regularindex3.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 10, item.regularindex4.HasValue? item.regularindex4.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 11,item.regularindex5.HasValue? item.regularindex5.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 12, item.regularindex6.HasValue? item.regularindex6.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 13, item.regularindex7.HasValue? item.regularindex7.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 14, item.regularindex8.HasValue? item.regularindex8.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 15, item.Digestibility.HasValue ? item.Digestibility.Value.ToString() : "", null);

                SetValue(startCol + (item.recordno - 1), startRow + 16, item.aminoindex1.HasValue? item.aminoindex1.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 17, item.aminoindex2.HasValue? item.aminoindex2.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 18, item.aminoindex3.HasValue? item.aminoindex3.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 19, item.aminoindex4.HasValue? item.aminoindex4.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 20, item.aminoindex5.HasValue?item.aminoindex5.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 21, item.aminoindex6.HasValue?item.aminoindex6.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 22, item.aminoindex7.HasValue? item.aminoindex7.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 23, item.aminoindex8.HasValue? item.aminoindex8.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 24, item.aminoindex9.HasValue? item.aminoindex9.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 25, item.aminoindex10.HasValue? item.aminoindex10.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 26, item.aminoindex11.HasValue? item.aminoindex11.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 27,item.aminoindex12.HasValue? item.aminoindex12.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 28,item.aminoindex13.HasValue? item.aminoindex13.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 29, item.aminoindex14.HasValue? item.aminoindex14.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 30, item.aminoindex15.HasValue?item.aminoindex15.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 31, item.aminoindex16.HasValue?item.aminoindex16.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 32, item.aminoindex17.HasValue?item.aminoindex17.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 33, item.aminoindex18.HasValue ? item.aminoindex18.Value.ToString() : "", null);
                SetValue(startCol + (item.recordno - 1), startRow + 34, item.aminoindex19.HasValue?item.aminoindex19.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 35, item.specialindex1, null);
                SetValue(startCol + (item.recordno - 1), startRow + 36, item.fee.HasValue? item.fee.Value.ToString():"", null);
                SetValue(startCol + (item.recordno - 1), startRow + 37, item.Describe, null);

            }
            return 1;
        }

        protected void Clear()
        {
            for (int i = 0; i < 6; i++)
            {
                SetEmpty(3 + i, 0);
                SetEmpty(3+i, 1);
                SetEmpty(3+i, 2);
                SetEmpty(3 + i, 3);
                for (int k = 0; k < 29; k++)
                {
                    SetEmpty(3 + i, 6+k);
                }
            }
        }

        protected void SetEmpty(int col, int row)
        {
            Control ctl = tableLayoutPanel1.GetControlFromPosition(col, row);
            if (ctl == null) return;
            TextBox txt = ctl as TextBox;
            if (txt == null) return;
            txt.Text = string.Empty;
        }

        protected void SetValue(int col ,int row , string value ,object tag)
        {
            Control ctl= tableLayoutPanel1.GetControlFromPosition(col, row);
            if (ctl == null) return;
            TextBox txt = ctl as TextBox;
            if (txt == null) return;
            txt.Text = value;
            txt.Tag = tag;
        }
        
        protected bool Check()
        {
            errorProvider1.Clear();

            bool isok = true;

            if( string.IsNullOrEmpty( txtFish.Text.Trim()))
            {
                errorProvider1.SetError(txtFish,"请选择鱼粉。");
                isok = false;
            }

            DateTime dt1 = DateTime.Now;
            if (CheckDate(3, 0, ref dt1) == false)
            {
                isok = false;
            }

            return isok;
        }

        protected bool CheckDate( int col,int row,ref DateTime dt )
        {
            Control ctl = tableLayoutPanel1.GetControlFromPosition(col, row);
            if (ctl == null) return true;
            TextBox txt = ctl as TextBox;
            if (txt == null) return true;
            if (string.IsNullOrEmpty(txt.Text.Trim())) return true;
            bool isok=  DateTime.TryParseExact(txt.Text.Trim(), "yyyy.MM.dd", null, System.Globalization.DateTimeStyles.None, out dt);
            if (isok == false)
            {
                errorProvider1.SetError(txt, "请输入正确的日期(YYYY.MM.DD)");
            }
            return isok;
        }

        protected string GetString(int col, int row)
        {
            Control ctl= tableLayoutPanel1.GetControlFromPosition(col, row);
            if (ctl == null) return string.Empty;
            TextBox txt = ctl as TextBox;
            if (txt == null) return string.Empty;
            return txt.Text.Trim();
        }

        protected decimal GetDecimal(int col, int row)
        {
            Control ctl = tableLayoutPanel1.GetControlFromPosition(col, row);
            if (ctl == null) return 0;
            TextBox txt = ctl as TextBox;
            if (txt == null) return 0;
            decimal temp = 0;
            decimal.TryParse(txt.Text.Trim(), out temp);
            return temp;
        }

        protected decimal? GetDecimalNull(int col, int row)
        {
            Control ctl = tableLayoutPanel1.GetControlFromPosition(col, row);
            if (ctl == null) return null;
            TextBox txt = ctl as TextBox;
            if (txt == null) return null;
            decimal temp = 0;
            if (decimal.TryParse(txt.Text.Trim(), out temp) == false)
            {
                return null;
            }
            return temp;
        }

        protected void GetValue(int col, int row, ref int id , ref string value)
        {
            Control ctl = tableLayoutPanel1.GetControlFromPosition(col, row);
            if (ctl == null) return ;
            TextBox txt = ctl as TextBox;
            if (txt == null) return ;
            if (txt.Tag == null) return;
            int temp = 0;
            int.TryParse(txt.Tag.ToString().Trim(), out temp);
            id = temp;
            value = txt.Text.Trim();
        }

        public override void Save()
        {
            if (Check() == false) return;

            int startcol = 3;
            int startrow = 0;
            DateTime lateDate = DateTime.MinValue;
            FishEntity.CheckRecordEntity lateRecord = null;

            for (int i = 0; i < 6; i++)
            {
                FishEntity.CheckRecordEntity vo = null;// new FishEntity.CheckRecordEntity();
                if (_records == null || _records.Count < 1)
                {
                    vo = new FishEntity.CheckRecordEntity();
                    vo.recordno = i + 1;
                    vo.productid = _productId;
                    vo.productcode = _productCode;
                    vo.productname = _productName;                          
                }
                else
                {
                    vo = _records.Find((m ) => { return m.recordno == (i + 1); });
                    if (vo == null)
                    {
                        vo = new FishEntity.CheckRecordEntity();
                        vo.recordno = i + 1;
                        vo.productid = _productId;
                        vo.productcode = _productCode;
                        vo.productname = _productName;
                    }
                }

                vo.checkdate = GetString(startcol + i, startrow);
               
                vo.testdate = GetString(startcol + i, startrow + 1);
                int companyid = 0;
                string companyname = string.Empty;
                string sends = string.Empty;
                GetValue(startcol + i, startrow + 2, ref companyid, ref sends);
                GetValue(startcol + i, startrow + 3, ref companyid, ref companyname);
                vo.testcompanyid = companyid;
                vo.testcompanyname = companyname;
                vo.Sendsamplename = sends;
                vo.regularindex1 = GetDecimalNull(startcol + i, startrow + 7);
                vo.regularindex2 = GetDecimalNull(startcol + i, startrow + 8);
                vo.regularindex3 = GetDecimalNull(startcol + i, startrow + 9);
                vo.regularindex4 = GetDecimalNull(startcol + i, startrow +10);
                vo.regularindex5 = GetDecimalNull(startcol + i, startrow + 11);
                vo.regularindex6 = GetDecimalNull(startcol + i, startrow + 12);
                vo.regularindex7 = GetDecimalNull(startcol + i, startrow + 13);
                vo.regularindex8 = GetDecimalNull(startcol + i, startrow + 14);
                vo.Digestibility = GetDecimalNull(startcol + i, startrow + 15);

                vo.aminoindex1 = GetDecimalNull(startcol + i, startrow + 16);
                vo.aminoindex2 = GetDecimalNull(startcol + i, startrow + 17);
                vo.aminoindex3 = GetDecimalNull(startcol + i, startrow + 18);
                vo.aminoindex4 = GetDecimalNull(startcol + i, startrow + 19);
                vo.aminoindex5 = GetDecimalNull(startcol + i, startrow + 20);
                vo.aminoindex6 = GetDecimalNull(startcol + i, startrow + 21);
                vo.aminoindex7 = GetDecimalNull(startcol + i, startrow + 22);
                vo.aminoindex8 = GetDecimalNull(startcol + i, startrow + 23);
                vo.aminoindex9 = GetDecimalNull(startcol + i, startrow + 24);
                vo.aminoindex10 = GetDecimalNull(startcol + i, startrow + 25);
                vo.aminoindex11 = GetDecimalNull(startcol + i, startrow + 26);
                vo.aminoindex12 = GetDecimalNull(startcol + i, startrow + 27);
                vo.aminoindex13 = GetDecimalNull(startcol + i, startrow + 28);
                vo.aminoindex14 = GetDecimalNull(startcol + i, startrow + 29);
                vo.aminoindex15 = GetDecimalNull(startcol + i, startrow + 30);
                vo.aminoindex16 = GetDecimalNull(startcol + i, startrow + 31);
                vo.aminoindex17 = GetDecimalNull(startcol + i, startrow + 32);
                vo.aminoindex18 = GetDecimalNull(startcol + i, startrow + 33);
                vo.aminoindex19 = GetDecimalNull(startcol + i, startrow + 34);

                vo.specialindex1 = GetString(startcol + i, startrow + 35);

                vo.fee = GetDecimalNull(startcol + i, startrow + 36);
                vo.Describe = GetString(startcol + i, startrow + 37);
                if (vo.id > 0)
                {
                    bool isUpdate = _bll.Update(vo);
                }
                else
                {
                    int id = _bll.Add(vo);
                    vo.id = id;
                    if (_records == null)
                    {
                        _records = new List<FishEntity.CheckRecordEntity>();
                    }
                    _records.Add(vo);
                }

                               
                DateTime tempDate = DateTime.MinValue;
                if (DateTime.TryParseExact(vo.checkdate, "yyyy.MM.dd", null, System.Globalization.DateTimeStyles.None, out tempDate))
                {
                    if (lateDate < tempDate)
                    {
                        lateDate = tempDate;
                        lateRecord = vo;
                    }
                }
                
            }

            //更新鱼粉的 国检指标，和送样日期
            if( lateRecord !=null )
            {
                FishBll.Bll.ProductBll productBll = new FishBll.Bll.ProductBll();
                productBll.UpdateCheckRecord(lateRecord);
            }
            MessageBox.Show("保存成功。");

            if (RefreshDataEvent != null)
            {
                RefreshDataEvent(this, EventArgs.Empty);
            }
        }

        private void txtFish_Click(object sender, EventArgs e)
        {
            UIForms.FormSelectFish form = new UIForms.FormSelectFish(-1);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowInTaskbar = false;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectedProduct == null) return;

            txtFish.Text = form.SelectedProduct.name;
            txtFish.Tag = form.SelectedProduct.id;
            lblFishCode.Text = form.SelectedProduct.code;
            _productId = form.SelectedProduct.id;
            _productName = form.SelectedProduct.name;
            _productCode = form.SelectedProduct.code;

            Query();
        }

        private void txtCompany_Click(object sender, EventArgs e)
        {
            SelectCompany(sender as TextBox);
        }

        protected void SelectCompany(TextBox txt)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txt.Tag = form.SelectCompany.code;
            txt.Text = form.SelectCompany.shortname; 
        }
        
        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (sender as TextBox);
            if (string.IsNullOrEmpty(txt.Text )) return;
            DateTime dt = new DateTime();
            bool isok = DateTime.TryParseExact(txt.Text, "yyyy.MM.dd", null, System.Globalization.DateTimeStyles.None, out dt);
            if (isok == false)
            {
                errorProvider1.SetError(txt, "请输入正确的日期。");
                return;
            }
            else
            {
                errorProvider1.SetError(txt, "");
            }
            
            int row =   tableLayoutPanel1.GetRow( txt);
            int col = tableLayoutPanel1.GetColumn(txt);

            if ( col == 4 || col == 5 || col == 6 || col == 7 || col == 8)
            {
                CalcPeriod(col, 0);
            }
        }

        protected void CalcPeriod( int col , int row )
        {
            DateTime dt1 =new DateTime ();
            DateTime dt2 =new DateTime ();
            bool isok1 = false;
            TextBox txt1 = tableLayoutPanel1.GetControlFromPosition( col , row ) as TextBox;
            isok1 = DateTime.TryParseExact(txt1.Text, "yyyy.MM.dd", null, System.Globalization.DateTimeStyles.None, out dt1);
            TextBox txt2 = tableLayoutPanel1.GetControlFromPosition(col , row+1) as TextBox;
            bool isok2 = DateTime.TryParseExact(txt2.Text, "yyyy.MM.dd", null, System.Globalization.DateTimeStyles.None, out dt2);

            if (isok1 && isok2)
            {
                int days = dt2.Subtract(dt1).Days;
                TextBox txt = tableLayoutPanel1.GetControlFromPosition( col , row+4) as TextBox;
                txt.Text = days.ToString();
            }

        }

        private void FormCheck_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void describe_txt_MouseClick(object sender, MouseEventArgs e)
        {
            //if (Check() == false) return;
            //int startcol = 3;
            //int startrow = 0;
            //DateTime lateDate = DateTime.MinValue;
            //FishEntity.CheckRecordEntity lateRecord = null;

            //for (int i = 0; i < 6; i++)
            //{
            //    FishEntity.CheckRecordEntity vo = null;// new FishEntity.CheckRecordEntity();
            //    if (_records == null || _records.Count < 1)
            //    {
            //        vo = new FishEntity.CheckRecordEntity();
            //        vo.recordno = i + 1;
            //        vo.productid = _productId;
            //        vo.productcode = _productCode;
            //        vo.productname = _productName;
            //    }
            //    else
            //    {
            //        vo = _records.Find((m) => { return m.recordno == (i + 1); });
            //        if (vo == null)
            //        {
            //            vo = new FishEntity.CheckRecordEntity();
            //            vo.recordno = i + 1;
            //            vo.productid = _productId;
            //            vo.productcode = _productCode;
            //            vo.productname = _productName;
            //        }
            //    }
            //    vo.checkdate = GetString(startcol + i, startrow);

            //    vo.testdate = GetString(startcol + i, startrow + 1);
            //    int companyid = 0;
            //    string companyname = string.Empty;
            //    GetValue(startcol + i, startrow + 2, ref companyid, ref companyname);
            //    vo.testcompanyid = companyid;
            //    vo.testcompanyname = companyname;
            //    vo.regularindex1 = GetDecimalNull(startcol + i, startrow + 7);
            //    MessageBox.Show(vo.regularindex1.ToString());
            }
    }
    }

