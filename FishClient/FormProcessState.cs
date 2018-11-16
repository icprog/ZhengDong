using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace FishClient
{
    //t_processState
    public partial class FormProcessState : FormMenuBase
    {
        FishEntity.ProcessStateEntity _list = null;
        FishBll.Bll.ProcessStateBll _bll = null;
        FishBll.Bll.SalerequisitionBll _createmanGet = new FishBll.Bll.SalerequisitionBll();
        FishEntity.SalesRequisitionEntity _createmanSet = new FishEntity.SalesRequisitionEntity();
        FishBll.Bll.SetReviewBll _Reviewbll= new FishBll.Bll.SetReviewBll();
        FishEntity.ReviewEntity _ReviewModel = new FishEntity.ReviewEntity();
        ProcessControl Authority = new ProcessControl();
        bool boolget=false;
        int i = 0;
        
        public FormProcessState()
        {
            InitializeComponent(); ReadColumnConfig(dataGridView1, "Set_125");

            _list = new FishEntity.ProcessStateEntity();
            _bll = new FishBll.Bll.ProcessStateBll();
            comCode.DataSource = _bll.getCode();
            comCode.DisplayMember = "code";
            comNumbering.DataSource = _bll.getNumbering();
            comNumbering.DisplayMember = "Numbering";
            DealDataGridViewHeader();
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.CustomFormat = "  ";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.CustomFormat = "  ";
            User();
            if (FishEntity.Variable.User.username == "admin" || FishEntity.Variable.User.username == "ceo" || FishEntity.Variable.User.username == "zd_lyk")
            {
                this.dataGridView1.ReadOnly = false;
            }
            else {
                this.dataGridView1.ReadOnly = true;
            }
            cmbeffect.SelectedItem = "全部";
            //DealDataGridViewHeader_One ();
            //DealDataGridViewHeader_two ();
        }

        protected void DealDataGridViewHeader()
        {
            UILibrary.TwoDimenDataGridView helper = new UILibrary.TwoDimenDataGridView(dataGridView1);
            UILibrary.TwoDimenDataGridView.TopHeader header1 = new UILibrary.TwoDimenDataGridView.TopHeader(2+3, 2, "销售申请单");
            UILibrary.TwoDimenDataGridView.TopHeader header2 = new UILibrary.TwoDimenDataGridView.TopHeader(4 + 3, 2, "销售合同");
            UILibrary.TwoDimenDataGridView.TopHeader header3 = new UILibrary.TwoDimenDataGridView.TopHeader(6 + 3, 2, "付款申请单");
            UILibrary.TwoDimenDataGridView.TopHeader header4 = new UILibrary.TwoDimenDataGridView.TopHeader(9 + 3, 1, "提货单");
            UILibrary.TwoDimenDataGridView.TopHeader header5 = new UILibrary.TwoDimenDataGridView.TopHeader(11 + 3, 2, "磅单");
            UILibrary.TwoDimenDataGridView.TopHeader header6 = new UILibrary.TwoDimenDataGridView.TopHeader(14 + 3, 2, "货物反馈单");
            UILibrary.TwoDimenDataGridView.TopHeader header7 = new UILibrary.TwoDimenDataGridView.TopHeader(17 + 3, 2, "问题反馈单");
            UILibrary.TwoDimenDataGridView.TopHeader header8 = new UILibrary.TwoDimenDataGridView.TopHeader(19 + 3, 2, "收款记录单");
            UILibrary.TwoDimenDataGridView.TopHeader header9 = new UILibrary.TwoDimenDataGridView.TopHeader(21 + 3, 2, "提成换算表");
            helper.Headers.Add(header1);
            helper.Headers.Add(header2);
            helper.Headers.Add(header3);
            helper.Headers.Add(header4);
            helper.Headers.Add(header5);
            helper.Headers.Add(header6);
            helper.Headers.Add(header7);
            helper.Headers.Add(header8);
            helper.Headers.Add(header9);
        }

        protected void DealDataGridViewHeader_One()
        {
            //UILibrary . TwoDimenDataGridView helper = new UILibrary . TwoDimenDataGridView ( dataGridView2 );
            //UILibrary . TwoDimenDataGridView . TopHeader header1 = new UILibrary . TwoDimenDataGridView . TopHeader ( 1 ,15 ,"付款申请单表" );
            //helper . Headers . Add ( header1 );
        }

        protected void DealDataGridViewHeader_two()
        {
            //UILibrary . TwoDimenDataGridView helper = new UILibrary . TwoDimenDataGridView ( dataGridView3 );
            //UILibrary . TwoDimenDataGridView . TopHeader header1 = new UILibrary . TwoDimenDataGridView . TopHeader ( 1 ,16 ,"收款记录单" );
            //helper . Headers . Add ( header1 );
        }

        private void comCode_TextChanged(object sender, System.EventArgs e)
        {


        }

        public override int Query()
        { 
            try
            {
                if (!string.IsNullOrEmpty(comNumbering.Text))
                {
                    _bll.GetFormSalesRequisition(comNumbering.Text);
                    _bll.GetFormSalesRContract(comNumbering.Text);
                    _bll.GetFormPaymentRequisition(comNumbering.Text);
                    _bll.GetFormBilloflading(comNumbering.Text);
                    _bll.GetFormOnepound(comNumbering.Text);
                    _bll.GetFormCargoFeedbackSheet(comNumbering.Text);
                    _bll.GetFormTheproblemsheet(comNumbering.Text);
                    _bll.GetFormReceiptRecord(comNumbering.Text);
                }
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteLog(ex.StackTrace);
                Utility.LogHelper.WriteLog(ex.Message);
            }
            finally
            {
                string strWhere = "1=1";
                if (!string.IsNullOrEmpty(comNumbering.Text))
                    strWhere = strWhere + " and a.Numbering='" + comNumbering.Text + "'";
                if (!string.IsNullOrEmpty(txtdemand.Text))
                    strWhere = strWhere + " and b.demand like '%" + txtdemand.Text + "%' ";
                if (!string.IsNullOrEmpty(txtPurchasecontractnumber.Text))
                {
                    strWhere = strWhere + " and b.Purchasecontractnumber like '%" + txtPurchasecontractnumber.Text + "%' ";
                }
                if (!string.IsNullOrEmpty(dtpStart.Text.Trim()))
                    strWhere = strWhere + " AND b.Signdate>='" + dtpStart.Text + "'";
                if (!string.IsNullOrEmpty(txtCode.Text.Trim()))
                    strWhere = strWhere + " AND b.code like'%" + txtCode.Text + "%'";
                if (!string.IsNullOrEmpty(dtpEnd.Text.Trim()))
                    strWhere = strWhere + " AND b.Signdate<='" + dtpEnd.Text + "'";
                if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
                {
                    strWhere += string.Format(" and b.createman='{0}' ", FishEntity.Variable.User.username);
                }
                else
                {
                    if (cmbTheperson.SelectedValue.ToString() != " ")
                    {
                        strWhere += string.Format(" and b.createman='{0}' ", cmbTheperson.SelectedValue.ToString());
                    }
                }
                switch (cmbeffect.SelectedItem.ToString())
                {
                    case "有效": strWhere += string.Format(" and effect IS NULL", cmbeffect.SelectedItem.ToString()); break;
                    case "无效": strWhere += string.Format(" and effect like '%{0}%'", cmbeffect.SelectedItem.ToString()); break;
                    case "全部":
                    default: break;
                }
                i = 0;
                List<FishEntity.ProcessStateEntity> modelList = _bll.getList(strWhere);
                if (modelList != null)
                {
                    dataGridView1.Rows.Clear();
                    foreach (FishEntity.ProcessStateEntity _list in modelList)
                    {
                        getValue(i, _list);
                        i++;
                    }
                }
                else {
                    MessageBox.Show("查无数据！");
                }
            }

            return base.Query();

        }

        void getValue(int i, FishEntity.ProcessStateEntity _list)
        {
            int idx = dataGridView1.Rows.Add();
            DataGridViewRow row = dataGridView1.Rows[idx];
            row.Cells["id"].Value = _list.id;
            row.Cells["code"].Value = _list.code;
            row.Cells["Numbering"].Value = _list.Numbering;
            switch (_list.Effect)
            {
                case "有效": row.Cells["effect"].Value= false;break;
                case "无效": row.Cells["effect"].Value = true;break;
                default: row.Cells["effect"].Value = false;break;
            }
            _createmanSet = _createmanGet.createmanGet(_list.Numbering);
            if (_createmanSet != null)
            {
                row.Cells["xssqBool"].Value = _createmanSet.createman.ToString();
                row.Cells["demand"].Value = _createmanSet.demand.ToString();
                row.Cells["Signdate"].Value = _createmanSet.Signdate.ToString();
                row.Cells["Purchasecontractnumber"].Value = _createmanSet.Purchasecontractnumber.ToString();
            }
            row.Cells["xssqExBool"].Value = string.Empty;
            //送审提交Name
            _ReviewModel = _Reviewbll.UserName(_list.Numbering);
            if (_ReviewModel != null)
            {
                row.Cells["xshtBool"].Value = _ReviewModel.userName.ToString();
            }
            row.Cells["xshtExBool"].Value = string.Empty;
            row.Cells["fksqBool"].Value = string.Empty;
            row.Cells["fksqExBool"].Value = string.Empty;
            row.Cells["thdCode"].Value = _list.ThdCode;
            row.Cells["thdBool"].Value = string.Empty;
            row.Cells["bdCode"].Value = _list.BdCode;
            row.Cells["bdBool"].Value = string.Empty;
            row.Cells["bdExBool"].Value = string.Empty;
            row.Cells["hwfkCode"].Value = _list.HwfkCode;
            row.Cells["hwfkBool"].Value = string.Empty;
            row.Cells["hwfkExBool"].Value = string.Empty;
            row.Cells["wtfkCode"].Value = _list.WtfkCode;
            row.Cells["wtfkBool"].Value = string.Empty;
            row.Cells["wtfkExBool"].Value = string.Empty;
            row.Cells["skjlBool"].Value = string.Empty;
            row.Cells["skjlExBool"].Value = string.Empty;
            row.Cells["tchsBool"].Value = string.Empty;
            row.Cells["tchsExBool"].Value = string.Empty;

            if (_list.xssqBool == true)
                dataGridView1.Rows[i].Cells["xssqBool"].Style.BackColor = Color.FromName("Red");
            else
                dataGridView1.Rows[i].Cells["xssqBool"].Style.BackColor = Color.FromName("Blue");
            if (_list.xssqExBool == true)
                dataGridView1.Rows[i].Cells["xssqExBool"].Style.BackColor = Color.FromName("Red");
            else
                dataGridView1.Rows[i].Cells["xssqExBool"].Style.BackColor = Color.FromName("Blue");
            if (_list.xshtBool == true)
                dataGridView1.Rows[i].Cells["xshtBool"].Style.BackColor = Color.FromName("Red");
            else
                dataGridView1.Rows[i].Cells["xshtBool"].Style.BackColor = Color.FromName("Blue");
            if (_list.xshtExBool == true)
                dataGridView1.Rows[i].Cells["xshtExBool"].Style.BackColor = Color.FromName("Red");
            else
                dataGridView1.Rows[i].Cells["xshtExBool"].Style.BackColor = Color.FromName("Blue");
            switch (_list.fksqBool)
            {
                case '1' :  dataGridView1.Rows[i].Cells["fksqBool"].Style.BackColor = Color.FromName("Red"); break;
                case '2' : dataGridView1.Rows[i].Cells["fksqBool"].Style.BackColor = Color.FromName("yellow"); break;
                case '0' : dataGridView1.Rows[i].Cells["fksqBool"].Style.BackColor = Color.FromName("Blue"); break;
                case '3': dataGridView1.Rows[i].Cells["fksqBool"].Style.BackColor = Color.FromName("green"); break;
                default:
                    /// <summary>
                    /// null
                    /// </summary>
                    dataGridView1.Rows[i].Cells["fksqBool"].Style.BackColor = Color.FromName("Blue");
                    break;
            }
            if (_list.fksqExBool == true)
                dataGridView1.Rows[i].Cells["fksqExBool"].Style.BackColor = Color.FromName("Red");
            else
                dataGridView1.Rows[i].Cells["fksqExBool"].Style.BackColor = Color.FromName("Blue");
            switch (_list.thdBool)
            {
                case '1': dataGridView1.Rows[i].Cells["thdBool"].Style.BackColor = Color.FromName("Red"); break;
                case '2': dataGridView1.Rows[i].Cells["thdBool"].Style.BackColor = Color.FromName("yellow"); break;
                case '0': dataGridView1.Rows[i].Cells["thdBool"].Style.BackColor = Color.FromName("Blue"); break;
                default:
                    /// <summary>
                    /// null
                    /// </summary>
                    dataGridView1.Rows[i].Cells["thdBool"].Style.BackColor = Color.FromName("Blue");
                    break;
            }
            switch (_list.bdBool)
            {
                case '1': dataGridView1.Rows[i].Cells["bdBool"].Style.BackColor = Color.FromName("Red"); break;
                case '2': dataGridView1.Rows[i].Cells["bdBool"].Style.BackColor = Color.FromName("yellow"); break;
                case '0': dataGridView1.Rows[i].Cells["bdBool"].Style.BackColor = Color.FromName("Blue"); break;
                default:
                    /// <summary>
                    /// null
                    /// </summary>
                    dataGridView1.Rows[i].Cells["bdBool"].Style.BackColor = Color.FromName("Blue");
                    break;
            }
            if (_list.bdExBool == true) { 
                dataGridView1.Rows[i].Cells["bdExBool"].Style.BackColor = Color.FromName("Red");
                dataGridView1.Rows[i].Cells["bdBool"].Style.BackColor = Color.FromName("Red");
            }
            else { 
                dataGridView1.Rows[i].Cells["bdExBool"].Style.BackColor = Color.FromName("Blue");
            }
            switch (_list.hwfkBool)
            {
                case '1': dataGridView1.Rows[i].Cells["hwfkBool"].Style.BackColor = Color.FromName("Red"); break;
                case '2': dataGridView1.Rows[i].Cells["hwfkBool"].Style.BackColor = Color.FromName("yellow"); break;
                case '0': dataGridView1.Rows[i].Cells["hwfkBool"].Style.BackColor = Color.FromName("Blue"); break;
                default:
                    /// <summary>
                    /// null
                    /// </summary>
                    dataGridView1.Rows[i].Cells["hwfkBool"].Style.BackColor = Color.FromName("Blue");
                    break;
            }
            if (_list.hwfkExBool == true)
                dataGridView1.Rows[i].Cells["hwfkExBool"].Style.BackColor = Color.FromName("Red");
            else
                dataGridView1.Rows[i].Cells["hwfkExBool"].Style.BackColor = Color.FromName("Blue");
            switch (_list.wtfkBool)
            {
                case '1': dataGridView1.Rows[i].Cells["wtfkBool"].Style.BackColor = Color.FromName("Red"); break;
                case '2': dataGridView1.Rows[i].Cells["wtfkBool"].Style.BackColor = Color.FromName("yellow"); break;
                case '0': dataGridView1.Rows[i].Cells["wtfkBool"].Style.BackColor = Color.FromName("Blue"); break;
                default:
                    /// <summary>
                    /// null
                    /// </summary>
                    dataGridView1.Rows[i].Cells["wtfkBool"].Style.BackColor = Color.FromName("Blue");
                break;
            }
            if (_list.wtfkExBool == true)
            {
                dataGridView1.Rows[i].Cells["wtfkExBool"].Style.BackColor = Color.FromName("Red");
            }
            else {
                dataGridView1.Rows[i].Cells["wtfkExBool"].Style.BackColor = Color.FromName("Blue");
            }
            switch (_list.skjlBool)
            {
                case '1': dataGridView1.Rows[i].Cells["skjlBool"].Style.BackColor = Color.FromName("Red"); break;
                case '2': dataGridView1.Rows[i].Cells["skjlBool"].Style.BackColor = Color.FromName("yellow"); break;
                case '0': dataGridView1.Rows[i].Cells["skjlBool"].Style.BackColor = Color.FromName("Blue"); break;
                default:
                    /// <summary>
                    /// null
                    /// </summary>
                    dataGridView1.Rows[i].Cells["skjlBool"].Style.BackColor = Color.FromName("Blue");
                    break;
            }
            if (_list.skjlExBool == true)
                dataGridView1.Rows[i].Cells["skjlExBool"].Style.BackColor = Color.FromName("Red");
            else
                dataGridView1.Rows[i].Cells["skjlExBool"].Style.BackColor = Color.FromName("Blue");
            if (_list.tchsBool == true)
                dataGridView1.Rows[i].Cells["tchsBool"].Style.BackColor = Color.FromName("Red");
            else
                dataGridView1.Rows[i].Cells["tchsBool"].Style.BackColor = Color.FromName("Blue");
            if (_list.tchsExBool == true)
                dataGridView1.Rows[i].Cells["tchsExBool"].Style.BackColor = Color.FromName("Red");
            else
                dataGridView1.Rows[i].Cells["tchsExBool"].Style.BackColor = Color.FromName("Blue");
        }

        //单击        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;            
            if (dataGridView1.Rows[e.RowIndex].Cells["Numbering"].Value != null)
            {
                _list.Numbering = dataGridView1.Rows[e.RowIndex].Cells["Numbering"].Value.ToString();
                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("xssqBool", StringComparison.OrdinalIgnoreCase) == true)
                {
                    if (Authority.ProcessControText("销售申请单") == true)
                    {
                        FormSalesRequisition Sales = new FormSalesRequisition(_list.Numbering);
                        Sales.ShowDialog();
                    }
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("xshtBool", StringComparison.OrdinalIgnoreCase) == true)
                {
                    if (Authority.ProcessControText("现货销售合同") == true)
                    {
                        FormSalesRContract SalesRCont = new FormSalesRContract(_list.Numbering);
                        SalesRCont.ShowDialog();
                    }
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("fksqBool", StringComparison.OrdinalIgnoreCase) == true)
                {
                    if (Authority.ProcessControText("付款申请单") == true)
                    {
                        FormPaymentTabie PaymentTabie = new FormPaymentTabie(_list.Numbering,"X");
                        PaymentTabie.ShowDialog();
                    }
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("thdBool", StringComparison.OrdinalIgnoreCase) == true)
                {
                    if (Authority.ProcessControText("提货单") == true)
                    {
                        FormBillofladingTable BillofladingTable = new FormBillofladingTable(_list.Numbering);
                        BillofladingTable.ShowDialog();
                    }
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("bdbool", StringComparison.OrdinalIgnoreCase) == true)
                {
                    if (Authority.ProcessControText("磅单") == true)
                    {
                        FormOnepoundTable BillofladingTable = new FormOnepoundTable(_list.Numbering,false);
                        BillofladingTable.ShowDialog();
                    }
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("hwfkBool", StringComparison.OrdinalIgnoreCase) == true)
                {
                    if (Authority.ProcessControText("货物反馈单") == true)
                    {
                        FormCargoFeedbackSheetTable CargoFeedbackSheetTable = new FormCargoFeedbackSheetTable(_list.Numbering);
                        CargoFeedbackSheetTable.ShowDialog();
                    }
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("wtfkBool", StringComparison.OrdinalIgnoreCase) == true)
                {
                    if (Authority.ProcessControText("公司问题反馈单") == true)
                    {
                        FormTheproblemsheetTable Theproblemsheet = new FormTheproblemsheetTable(_list.Numbering);
                        Theproblemsheet.ShowDialog();
                    }
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("skjlBool", StringComparison.OrdinalIgnoreCase) == true)
                {
                    if (Authority.ProcessControText("收款记录单") == true)
                    {
                        FormReceiptRecordtable ReceiptRecordtable = new FormReceiptRecordtable(_list.Numbering);
                        ReceiptRecordtable.ShowDialog();
                    }
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("effect", StringComparison.OrdinalIgnoreCase) == true)
                {
                    boolget = true;
                }
                else {
                    boolget = false;
                }
            }
        }

        string bill = string.Empty, billNum = string.Empty, path = string.Empty;

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            this.dtpEnd.CustomFormat = null;
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            this.dtpStart.CustomFormat = null;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            path = string.Empty;
            billNum = string.Empty;
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("xssqBool", StringComparison.OrdinalIgnoreCase) == true)
            {
                if (Authority.ProcessControText("销售申请单") == true)
                {
                    path = "FishClient.FormSalesRequisition";
                    billNum = dataGridView1.Rows[e.RowIndex].Cells["Numbering"].Value.ToString();
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("xshtBool", StringComparison.OrdinalIgnoreCase) == true)
            {
                if (Authority.ProcessControText("现货销售合同") == true)
                {
                    path = "FishClient.FormSalesRContract";
                    billNum = dataGridView1.Rows[e.RowIndex].Cells["Numbering"].Value.ToString();
                }
            }
            if (!string.IsNullOrEmpty(path))
                Reflected(path);
        }
        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (boolget == true)
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0) { } else { }
                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("effect", StringComparison.OrdinalIgnoreCase) == true)
                {
                    if (FishEntity.Variable.User.username == "admin" || FishEntity.Variable.User.username == "ceo" || FishEntity.Variable.User.username == "zd_lyk")
                    {
                        _list = new FishEntity.ProcessStateEntity();
                        _bll = new FishBll.Bll.ProcessStateBll();
                        _list.Numbering = dataGridView1.Rows[e.RowIndex].Cells["Numbering"].Value.ToString();
                        if (bool.Parse(dataGridView1.Rows[e.RowIndex].Cells["effect"].Value.ToString()))
                        {
                            _list.Effect = "无效";
                        }
                        else {
                            _list.Effect = "有效";
                        }
                        bool idx = _bll.update(_list.Effect, _list.Numbering);
                        if (idx)
                        {
                            MessageBox.Show("修改成功！");
                            boolget = false;
                        }
                        else {
                            MessageBox.Show("修改失败！");
                            boolget = false;
                        }
                    }
                }
            }
            else { return; }
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_125");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_125");
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
            doc.Show();
        }
        public void User() {
            if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
            {
                cmbTheperson.Enabled = false;
                cmbTheperson.Visible = false;
                label12.Visible = false;
            }
            FishBll.Bll.PersonBll bll = new FishBll.Bll.PersonBll();

            List<FishEntity.PersonEntity> list1 = bll.id_name();
            if (list1 == null)
            {
                list1 = new List<FishEntity.PersonEntity>();
            }
            FishEntity.PersonEntity tmep = new FishEntity.PersonEntity();

            //tmep.id = 0;
            tmep.username = " ";
            list1.Insert(0, tmep);

            cmbTheperson.DataSource = list1;
            cmbTheperson.DisplayMember = "username";
            cmbTheperson.ValueMember = "username";
        }
    }
}
