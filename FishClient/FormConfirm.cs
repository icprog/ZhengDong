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
    /// 确盘
    /// </summary>
    public partial class FormConfirm : FormMenuBase
    {
        FishBll.Bll.ProductConfirmBll _confirmBll = new FishBll.Bll.ProductConfirmBll();
        public event EventHandler ClickFishEvent = null;
        UILibrary.TwoDimenDataGridView helper = null;
        List<FishEntity.ProductConfirmVo> _list = null;

        bool boolget = false;
        protected void OnClickFish()
        {
            if (ClickFishEvent != null)
            {
                ClickFishEvent(this, EventArgs.Empty);
            }
        }

        public FormConfirm()
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_Confirm");
            //tmiModify.Visible = false;
            //tmiDelete.Visible = false;
            //tmiPrevious.Visible = false;
            //tmiNext.Visible = false;
            //tmiSave.Visible = false;
            //tmiCancel.Visible = false;
            //tmiAdd.Visible = false;

            dtpStart.Value = DateTime.Now.AddYears(-1);
            dtpEnd.Value = DateTime.Now.AddYears(1);

            UIControls.ToolStripMenuItemEx tmiQuoteImage = new UIControls.ToolStripMenuItemEx();
            tmiQuoteImage.Text = "报盘附件";
            tmiQuoteImage.FunCode = "50";
            tmiQuoteImage.Click += tmiQuoteImage_Click;
            menuStrip1.Items.Insert(menuStrip1.Items.IndexOf(tmiClose), tmiQuoteImage);

            UIControls.ToolStripMenuItemEx tmiAddFish = new UIControls.ToolStripMenuItemEx();
            tmiAddFish.Text = "新增鱼粉";
            tmiAddFish.FunCode = "51";
            tmiAddFish.Click += tmiAddFish_Click;
            menuStrip1.Items.Insert(menuStrip1.Items.IndexOf(tmiClose), tmiAddFish);

            FishEntity.SystemDataType item = new FishEntity.SystemDataType(string.Empty , string .Empty );
            List<FishEntity.SystemDataType> list = FishEntity.Variable.StateList.GetRange(0, FishEntity.Variable.StateList.Count);
            list.Insert(0, item);
            cmbCountry.DataSource = list;
            cmbCountry.DisplayMember = "name";
            cmbCountry.ValueMember = "code";
            InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CountryType, true);//
            InitDataUtil.BindComboBoxData(cmbPZ, FishEntity.Constant.Specification, true);
            InitDataUtil.BindComboBoxData(cmbPort, FishEntity.Constant.port, true);
            DealDataGridViewHeader();

            if (FishEntity.Variable.User.username == "admin" || FishEntity.Variable.User.username == "ceo" || FishEntity.Variable.User.username == "zd_lyk")
            {
                this.dataGridView1.ReadOnly = false;
            }
            else
            {
                this.dataGridView1.ReadOnly = true;
            }

        }

        protected void DealDataGridViewHeader()
        {
            helper = new UILibrary.TwoDimenDataGridView(dataGridView1);
            UILibrary.TwoDimenDataGridView.TopHeader header1 = new UILibrary.TwoDimenDataGridView.TopHeader(20, 3, "船期(月)");
            UILibrary.TwoDimenDataGridView.TopHeader header2 = new UILibrary.TwoDimenDataGridView.TopHeader(13, 3, "报盘指标");
            UILibrary.TwoDimenDataGridView.TopHeader header3 = new UILibrary.TwoDimenDataGridView.TopHeader(26,3,"SGS指标");
            //UILibrary.TwoDimenDataGridView.TopHeader header4 = new UILibrary.TwoDimenDataGridView.TopHeader(26, 3, "确盘");

            helper.Headers.Add(header1 );
            helper.Headers.Add(header2);
            helper.Headers .Add(header3);
            //helper.Headers.Add(header4);
        }

        void tmiQuoteImage_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("请选择报盘记录。");
                return;
            }

            int productid = 0;
            object obj = dataGridView1.CurrentRow.Cells["id"].Value;
            if (obj == null) return;
            if (int.TryParse(obj.ToString(), out productid) == false) return;

            FormImage form = new FormImage(productid, FishEntity.ImageTypeEnum.SGS);
            form.StartPosition = FormStartPosition.CenterParent;
            form.SetData(productid, FishEntity.ImageTypeEnum.SGS);
            form.ShowDialog();
        }

        void tmiAddFish_Click(object sender, EventArgs e)
        {
            //OnClickFish();
            FormNewFish form = new FormNewFish();
            form.ShowDialog();
        }

        private void FormQuote_Load(object sender, EventArgs e)
        {
            dataGridView1.BackgroundColor = this.BackColor;

            cmbValidate.Text = "有效";
        }

        protected string GetWhereCondition()
        {
            string where = string.Format(" 1= 1 ");
            if (false == string.IsNullOrEmpty(txtSupplier.Text))
            {
                where += string.Format(" and confirmagent like '%{0}%'", txtSupplier.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtFishCode.Text))
            {
                where += string.Format(" and a.code like '%{0}%'" ,txtFishCode.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtLinkMan.Text))
            {
                where += string.Format(" and confirmlinkman like '%{0}%'", txtLinkMan.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtquote_amine.Text))
            {
                where += string.Format(" and quote_amine like '%{0}%'", txtquote_amine.Text.Trim());
            }
            if (false==string.IsNullOrEmpty(txtbillofgoods.Text))
            {
                where += string.Format(" and billofgoods like '%{0}%' ", txtbillofgoods.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtquote_protein.Text))
            {
                where += string.Format(" and quote_protein like '%{0}%'", txtquote_protein.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtquote_tvn.Text))
            {
                where += string.Format(" and quote_tvn like '%{0}%'", txtquote_tvn.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(cmbCountry.SelectedValue.ToString()))
            {
                where += string.Format(" and nature like '%{0}%'", cmbCountry.SelectedValue.ToString().Trim());
            }
            if (false == string.IsNullOrEmpty(txtQuality.Text))
            {
                where += string.Format(" and quality like '%{0}%'", txtQuality.Text.Trim());
            }
            if (cmbPZ.SelectedValue != null && string.IsNullOrEmpty(cmbPZ.SelectedValue.ToString()) == false)
            {
                where += " and specification = '" + cmbPZ.SelectedValue.ToString() + "'";
            }
            if (cmbPort.SelectedValue != null && string.IsNullOrEmpty(cmbPort.SelectedValue.ToString()) == false)
            {
                where += " and port = '" + cmbPort.SelectedValue.ToString() + "'";
            }
            if (cmbValidate.Text.Equals("有效"))
            {
                where += string.Format(" and isdelete1 =1");
            }
            else if (cmbValidate.Text.Equals("无效"))
            {
                where += string.Format(" and isdelete1 = 0 ");
            }

            where += string.Format(" and a.createtime>='{0}' and a.createtime<='{1}'",
                dtpStart.Value.ToString("yyyy-MM-dd 00:00:00"),
                dtpEnd.Value.ToString("yyyy-MM-dd 23:59:59"));
           
            return where;
        }

        public override int Query()
        {
            menuStrip1.Focus();
            panel2.Controls.Clear();
            string where = GetWhereCondition();
            //List<FishEntity.ProductEntity> list = _bll.GetModelList(where);
            _list = _confirmBll.GetConfirm(where);
            huizong.Text = _list.Count.ToString();
            AddGroupRow(_list);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _list;
            if (!FishEntity.Variable.User.roletype.Contains("业务主管"))
            {
                dataGridView1.Columns["quotedollars"].Visible = false;
                dataGridView1.Columns["quotermb"].Visible = false;
            }
            if (_list == null || _list.Count < 1) return 0;

            Add();

            return 1;
        }

        protected void AddGroupRow(List<FishEntity.ProductConfirmVo> list)
        {
            if (list == null || list .Count <1 ) return;
            IDictionary<string, FishEntity.ProductConfirmVo> groups = new Dictionary<string, FishEntity.ProductConfirmVo>();
            string specification = list[0].specification;
            foreach (FishEntity.ProductConfirmVo vo in list)
            {
                if (groups.ContainsKey(vo.specification))
                {
                    FishEntity.ProductConfirmVo group = groups[vo.specification];
                    group.confirmsgsweight += vo.confirmsgsweight;
                }
                else
                {
                    FishEntity.ProductConfirmVo newvo = new FishEntity.ProductConfirmVo();
                    newvo.specification = vo.specification;
                    newvo.confirmsgsweight = vo.confirmsgsweight;//分组小计 SGS重量
                    newvo.code = "分组小计";
                    groups.Add(vo.specification, newvo );
                }
            }

            foreach (KeyValuePair<string,FishEntity.ProductConfirmVo> pair in groups)
            {
               int idx =  list.FindLastIndex( (i) => {return i.specification.Equals(pair.Key); });
               if (idx >= 0)
               {
                   list.Insert(idx+1, pair.Value);
               }
            }
        }
        
        public override int Add()
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("请选择要确盘的记录。");
                return 0;
            }

            if (dataGridView1.CurrentRow.Cells["code"].Value !=null && dataGridView1.CurrentRow.Cells["code"].Value.ToString().Equals("分组小计"))
            {
                panel2.Controls.Clear();   
                return 0;
            }


            int productid = 0;

            //object obj = dataGridView1.CurrentRow.Cells["quotesuppliercode"].Value;
            //if (obj == null) return 0;
            //if ( string.IsNullOrEmpty( obj.ToString()) == true ) return 0;

            //obj = dataGridView1.CurrentRow.Cells["quotelinkmancode"].Value;
            //if (obj == null) return 0;
            //if ( string.IsNullOrEmpty( obj.ToString() ) == true ) return 0;

           object obj = dataGridView1.CurrentRow.Cells["id"].Value;
            if (obj == null) return 0;
            if (int.TryParse(obj.ToString(), out productid) == false) return 0;

            //companycode = dataGridView1.CurrentRow.Cells["quotesuppliercode"].Value.ToString();
            //linkmancode = dataGridView1.CurrentRow.Cells["quotelinkmancode"].Value.ToString();

            //string companyNameStr = dataGridView1.CurrentRow.Cells["quotesupplier"].Value.ToString();
            //string productcode = dataGridView1.CurrentRow.Cells["code"].Value.ToString();

            FormQuoteDetail form = new FormQuoteDetail(productid);
            form.ShowMenu(false);
            form.SetDataGridView(true);
            form.RefreshDataEvent += form_RefreshDataEvent;
            //form.ShowDialog();  
            form.TopLevel = false;
            //form.CaptionHeight = 0;
            form.ControlBox = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panel2.Controls.Clear();
            panel2.Controls.Add(form);
            form.Show();

            return 1;
        }

        void form_RefreshDataEvent(object sender, ProductIdEventArgs e)
        {
            //if (dataGridView1.CurrentRow == null) return;

            //if (dataGridView1.CurrentRow.Cells["id"].Value == null) return;

            //if( dataGridView1.CurrentRow.Cells["id"].Value .ToString().Equals( e.productid.ToString())==false ) return;

            //dataGridView1.CurrentRow.Cells["latestquote"].Value = e.latestedprice;

            //dataGridView1.CurrentRow.Cells["quotedollars"].Value = e.dollars;
            //dataGridView1.CurrentRow.Cells["quotermb"].Value = e.rmb;
            //dataGridView1.CurrentRow.Cells["rate"].Value = e.rate;
            //dataGridView1.CurrentRow.Cells["quotedate"].Value = e.latequotedate;
        }

        public override int Export()
        {
            List<FishEntity.ProductConfirmVo> list = dataGridView1.DataSource as List<FishEntity.ProductConfirmVo>;
            if (list == null || list.Count < 1) return 0;

            SaveFileDialog dlg = new SaveFileDialog ();
            dlg.Filter = "*.xls|*.xls";
            if(dlg.ShowDialog()  != System.Windows.Forms.DialogResult.OK ) return 0;

            string filepath = dlg.FileName;
            ExportUtil.ExportConfirm(list,filepath );


            return 1;
        }

        private void txtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Query();
            }
        }
        FishEntity.ProductQuoteVo _model = null;
        public FishEntity.ProductQuoteVo getModel
        {
            get
            {
                return _model;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString() == "分组小计")
            {
                return;
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("isdelete1", StringComparison.OrdinalIgnoreCase) == true)
            {
                boolget = true;
            }
            else
            {
                boolget = false;
                Add();
                SeeFishDetail(e.ColumnIndex, e.RowIndex);
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("code", StringComparison.OrdinalIgnoreCase) == false)
            {
                this.DialogResult = DialogResult.Cancel;
                _model = new FishEntity.ProductQuoteVo();
                _model.code = dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
                _model.specification = dataGridView1.Rows[e.RowIndex].Cells["specification"].Value.ToString();
                _model.nature = dataGridView1.Rows[e.RowIndex].Cells["nature"].Value.ToString();
                _model.brand = dataGridView1.Rows[e.RowIndex].Cells["brand"].Value.ToString();
                _model.billofgoods = dataGridView1.Rows[e.RowIndex].Cells["billofgoods"].Value.ToString();
                
                if (dataGridView1.Rows[e.RowIndex].Cells["quote_protein"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["quote_protein"].Value.ToString() != "")
                {
                    _model.quote_protein = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["quote_protein"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["quote_tvn"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["quote_tvn"].Value.ToString() != "")
                {
                    _model.quote_tvn = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["quote_tvn"].Value.ToString());
                }

                if (dataGridView1.Rows[e.RowIndex].Cells["quote_amine"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["quote_amine"].Value.ToString() != "")
                {
                    _model.quote_amine = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["quote_amine"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["quote_ffa"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["quote_ffa"].Value.ToString() != "")
                {
                    _model.quote_ffa = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["quote_ffa"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["quote_sandsalt"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["quote_sandsalt"].Value.ToString() != "")
                {
                    _model.quote_sandsalt = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["quote_sandsalt"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["quote_graypart"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["quote_graypart"].Value.ToString() != "")
                {
                    _model.quote_graypart = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["quote_graypart"].Value.ToString());
                }
                
                _model.quotermb = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["quotermb"].Value.ToString());
                //_model.quotedollars = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["quotedollars"].Value.ToString());
                this.DialogResult = DialogResult.OK;
            }
        }


        private void SeeFishDetail(int colidx, int rowidx)
        {
            if (colidx < 0 || rowidx < 0) return;
            if (dataGridView1.Columns[colidx].Name.Equals("code"))
            {
                string productidStr = dataGridView1.Rows[rowidx].Cells["id"].Value.ToString();
                int productid = 0;
                int.TryParse(productidStr, out productid);
                if (productid < 1) return;
                FormNewFish form = new FormNewFish(productid);
                form.MenuCode = "M007";
                form.ShowDialog();
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dataGridView1.Rows[e.RowIndex].Cells["code"].Value == null) return;
            if (dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString().Equals("分组小计"))
            {
                e.CellStyle.BackColor = Color.LightPink;
                e.CellStyle.SelectionBackColor = Color.LightPink;
                e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;                         
            }
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                foreach (UILibrary.TwoDimenDataGridView.TopHeader header in helper.Headers)
                {
                    for (int i = 0; i < header.Span; i++)
                    {
                        dataGridView1.Invalidate(dataGridView1.GetCellDisplayRectangle(header.Index+ i , -1, true));
                    }
                }
            }
        }

        private void SetValue(int rowidx, string code)
        {            
            if (_list == null) return;
            FishEntity.ProductConfirmVo vo = _list.Find((i) => { return i.code == code; });
            if (vo == null) return;

            dataGridView1.Rows[rowidx].Cells["quote_protein"].Value = vo.quote_protein == 0 ? "" : vo.quote_protein.ToString();
            dataGridView1.Rows[rowidx].Cells["quote_tvn"].Value = vo.quote_tvn == 0 ? "" : vo.quote_tvn.ToString();
            dataGridView1.Rows[rowidx].Cells["quote_amine"].Value = vo.quote_amine == 0 ? "" : vo.quote_amine.ToString();
            dataGridView1.Rows[rowidx].Cells["quote_sandsalt"].Value = vo.quote_sandsalt == 0 ? "" : vo.quote_sandsalt.ToString();
            dataGridView1.Rows[rowidx].Cells["quote_ffa"].Value = vo.quote_ffa == 0 ? "" : vo.quote_ffa.ToString();
            dataGridView1.Rows[rowidx].Cells["quote_graypart"].Value = vo.quote_graypart == 0 ? "" : vo.quote_graypart.ToString();
            //dataGridView1.Rows[rowidx].Cells["quote_fat"].Value = vo.quote_fat == 0 ? "" : vo.quote_fat.ToString();
            //dataGridView1.Rows[rowidx].Cells["quote_water"].Value = vo.quote_water == 0 ? "" : vo.quote_water.ToString();
            //dataGridView1.Rows[rowidx].Cells["quote_sand"].Value = vo.quote_sand == 0 ? "" : vo.quote_sand.ToString();

            dataGridView1.Rows[rowidx].Cells["sgs_protein"].Value = vo.sgs_protein == 0 ? "" : vo.sgs_protein.ToString();
            dataGridView1.Rows[rowidx].Cells["sgs_tvn"].Value = vo.sgs_tvn == 0 ? "" : vo.sgs_tvn.ToString();
            dataGridView1.Rows[rowidx].Cells["sgs_amine"].Value = vo.sgs_amine == 0 ? "" : vo.sgs_amine.ToString();
            dataGridView1.Rows[rowidx].Cells["sgs_sandsalt"].Value = vo.sgs_sandsalt == 0 ? "" : vo.sgs_sandsalt.ToString();
            dataGridView1.Rows[rowidx].Cells["sgs_ffa"].Value = vo.sgs_ffa == 0 ? "" : vo.sgs_ffa.ToString();
            dataGridView1.Rows[rowidx].Cells["sgs_graypart"].Value = vo.sgs_graypart == 0 ? "" : vo.sgs_graypart.ToString();
            
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("nature"))
            {
                if (e.Value != null)
                {
                    string natureid = e.Value.ToString();
                    FishEntity.DictEntity entity = InitDataUtil.DictList.Find((i) => { return i.code == natureid && i.pcode == FishEntity.Constant.CountryType; });
                    if (entity != null)
                    {
                        e.Value = entity.name;
                    }
                }
            }

            string fishcode = dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
            if (fishcode.Equals("分组小计") == false)
            {
                SetValue(e.RowIndex, fishcode);
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["Quote_id"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["Quote_id"].Value.ToString() != "")
            {
                string num1 = dataGridView1.Rows[e.RowIndex].Cells["Quote_id"].Value.ToString();
                if (num1 != "")
                {
                    dataGridView1.Rows[e.RowIndex].Cells["Quote_id"].Style.BackColor = Color.LightGreen;
                    dataGridView1.Rows[e.RowIndex].Cells["Quote_id"].Value = "";
                }
            }


        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_Confirm");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_Confirm");
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

        private void txtSupplier_Click_1(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtSupplier.Text = form.SelectCompany.fullname;
            txtSupplier.Tag = form.SelectCompany.code;
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (boolget == true)
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0) { } else { }
                if (dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString() == "分组小计")
                {
                    return;
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("isdelete1", StringComparison.OrdinalIgnoreCase) == true)
                {
                    if (FishEntity.Variable.User.username == "admin" || FishEntity.Variable.User.username == "ceo" || FishEntity.Variable.User.username == "zd_lyk")
                    {
                        FishEntity.ProductEntity _fish = new FishEntity.ProductEntity();
                        FishBll.Bll.FinishBll fishbll = new FishBll.Bll.FinishBll();
                        _fish.code = dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
                        System.Console.WriteLine(dataGridView1.Rows[e.RowIndex].Cells["isdelete1"].Value.ToString());
                        if (("0").Equals(dataGridView1.Rows[e.RowIndex].Cells["isdelete1"].Value.ToString()))
                        {
                            _fish.isdelete = 1;
                        }
                        else if (("1").Equals(dataGridView1.Rows[e.RowIndex].Cells["isdelete1"].Value.ToString()))
                        {
                            _fish.isdelete = 0;
                        }
                        string names = "isdelete1";
                        bool idx = fishbll.update(_fish, names);
                        if (idx)
                        {
                            MessageBox.Show("修改成功！");
                            boolget = false;
                        }
                        else
                        {
                            MessageBox.Show("修改失败！");
                            boolget = false;
                        }
                    }
                }
            }
            else { return; }
        }
    }
}
