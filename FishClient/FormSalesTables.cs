using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormSalesTables : FormMenuBase
    {
        FishEntity.SalesRequisitionEntity _fish = null;
        string strWhere = string.Empty;
        public FishEntity.SalesRequisitionEntity fish
        {
            get
            {
                return _fish;
            }
        }
        public FormSalesTables()
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_143");
            menuStrip1.Items.Remove(tmiprint);
            menuStrip1.Items.Remove(tmiReview);
            tmiAdd.Visible = false;
            tmiModify.Visible = false;
            tmiDelete.Visible = false;
            tmiExport.Visible = false;
            tmiNext.Visible = false;
            tmiPrevious.Visible = false;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;
            tmiClose.Visible = false;
            User();
        }
        public void User()
        {
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

        FishBll.Bll.SalerequisitionBll _bll = new FishBll.Bll.SalerequisitionBll();

        private void FormSalesTables_Load(object sender, System.EventArgs e)
        {

            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.CustomFormat = "  ";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.CustomFormat = "  ";

            InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CountryType, true);

            cmbId.DataSource = _bll.getCode();
            cmbId.DisplayMember = "code";
            cobCodeNum.DataSource = _bll.getCodeNum();
            cobCodeNum.DisplayMember = "code";
            menuStrip1.Visible = true;
            tmiAdd.Visible = false;
            tmiModify.Visible = false;
            tmiDelete.Visible = false;
            tmiExport.Visible = false;
            tmiNext.Visible = false;
            tmiPrevious.Visible = false;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;
            tmiClose.Visible = true;
            tmiQuery.Visible = true;
            cmbId.SelectedIndex = -1;
            cobCodeNum.SelectedIndex = -1;
            DealDataGridViewHeader();
        }

        void DealDataGridViewHeader()
        {
            UILibrary.TwoDimenDataGridView helper = new UILibrary.TwoDimenDataGridView(dataGridView1);
            UILibrary.TwoDimenDataGridView.TopHeader header1 = new UILibrary.TwoDimenDataGridView.TopHeader(26, 3, "SGS指标");
            UILibrary.TwoDimenDataGridView.TopHeader header2 = new UILibrary.TwoDimenDataGridView.TopHeader(32, 9, "国内检测指标");
            helper.Headers.Add(header1);
            helper.Headers.Add(header2);
        }

        private void dtpStart_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x8)
            {
                this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                this.dtpStart.CustomFormat = "  ";
            }
        }

        private void dtpStart_ValueChanged(object sender, System.EventArgs e)
        {
            this.dtpStart.CustomFormat = null;
        }

        private void dtpEnd_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x8)
            {
                this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                this.dtpEnd.CustomFormat = "  ";
            }
        }

        private void dtpEnd_ValueChanged(object sender, System.EventArgs e)
        {
            this.dtpEnd.CustomFormat = null;
        }

        private void cmbCountry_TextChanged(object sender, System.EventArgs e)
        {
            BindCountryBrandData();
        }

        private void BindCountryBrandData()
        {
            if (cmbCountry.Text == string.Empty)
                return;
            string pcode = cmbCountry.Text.ToString();
            FishEntity.DictEntity pModel = InitDataUtil.DictList.Find((i) =>
            {
                return i.code == pcode && i.pcode.Equals(FishEntity.Constant.CountryType);
            });
            int pid = 0;
            if (pModel != null)
            {
                pid = pModel.id;
            }

            List<FishEntity.DictEntity> list = InitDataUtil.DictList.FindAll((i) =>
            {
                return i.pid == pid && i.pcode.Equals(FishEntity.Constant.Brand);
            });
            if (true)
            {
                if (list == null)
                {
                    list = new List<FishEntity.DictEntity>();
                }
                FishEntity.DictEntity empty = new FishEntity.DictEntity();
                empty.code = "-1";
                empty.name = "";
                list.Insert(0, empty);
            }

            cmbBrand.DataSource = list;
            cmbBrand.DisplayMember = "name";
            cmbBrand.ValueMember = "code";
        }

        public override int Query()
        {
             strWhere += " 1=1 ";
            if (!string.IsNullOrEmpty(cmbId.Text))
                strWhere = strWhere + " AND product_id like '%" + cmbId.Text + "%'";
            if (txtsupplier.Tag != null && !string.IsNullOrEmpty(txtsupplier.Tag.ToString()))
                strWhere = strWhere + " AND demandId='" + txtsupplier.Tag.ToString() + "'";
            if (!string.IsNullOrEmpty(cmbCountry.Text))
                strWhere = strWhere + " AND Country='" + cmbCountry.Text + "'";
            if (!string.IsNullOrEmpty(cmbBrand.Text))
                strWhere = strWhere + " AND pp='" + cmbBrand.Text + "'";
            if (!string.IsNullOrEmpty(cobCodeNum.Text))
                strWhere = strWhere + " AND a.code like'%" + cobCodeNum.Text + "%'";
            if (!string.IsNullOrEmpty(dtpStart.Text.Trim()))
                strWhere = strWhere + " AND Signdate>='" + dtpStart.Text + "'";
            if (!string.IsNullOrEmpty(dtpEnd.Text.Trim()))
                strWhere = strWhere + " AND Signdate<='" + dtpEnd.Text + "'";
            if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
            {
                strWhere += string.Format(" and a.createman='{0}' ", FishEntity.Variable.User.username);
            }
            else
            {
                if (cmbTheperson.SelectedValue.ToString() != " ")
                {
                    strWhere += string.Format(" and a.createman='{0}' ", cmbTheperson.SelectedValue.ToString());
                }
            }
            DataTable queryTable = _bll.getTable(strWhere);
            strWhere = string.Empty;
            if (queryTable != null && queryTable.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < queryTable.Rows.Count; i++)
                {
                    int idx = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[idx];
                    row.Cells["Numbering"].Value = queryTable.Rows[i]["Numbering"].ToString();
                    row.Cells["product_id"].Value = queryTable.Rows[i]["product_id"].ToString();
                    row.Cells["code"].Value = queryTable.Rows[i]["code"].ToString();                    
                    row.Cells["Signdate"].Value = queryTable.Rows[i]["Signdate"].ToString();
                    row.Cells["Signplace"].Value = queryTable.Rows[i]["Signplace"].ToString();
                    row.Cells["SupplierAbbreviation"].Value = queryTable.Rows[i]["SupplierAbbreviation"].ToString();
                    row.Cells["DemandAbbreviation"].Value = queryTable.Rows[i]["DemandAbbreviation"].ToString();
                    row.Cells["supplier"].Value = queryTable.Rows[i]["supplier"].ToString();
                    row.Cells["XFshortname"].Value = queryTable.Rows[i]["XFshortname"].ToString();
                    row.Cells["GFshortname"].Value = queryTable.Rows[i]["GFshortname"].ToString();
                    row.Cells["demand"].Value = queryTable.Rows[i]["demand"].ToString();
                    row.Cells["productname"].Value = queryTable.Rows[i]["productname"].ToString();
                    row.Cells["Funit"].Value = queryTable.Rows[i]["Funit"].ToString();
                    row.Cells["Variety"].Value = queryTable.Rows[i]["Variety"].ToString();
                    row.Cells["Quantity"].Value = queryTable.Rows[i]["Quantity"].ToString();
                    row.Cells["unitprice"].Value = queryTable.Rows[i]["unitprice"].ToString();
                    row.Cells["Amonut"].Value = queryTable.Rows[i]["Amonut"].ToString();
                    row.Cells["Freight"].Value = queryTable.Rows[i]["Freight"].ToString();
                    row.Cells["Purchasingunits"].Value = queryTable.Rows[i]["Purchasingunits"].ToString();
                    row.Cells["Purchasingcontacts"].Value = queryTable.Rows[i]["Purchasingcontacts"].ToString();
                    row.Cells["Purchasecontractnumber"].Value = queryTable.Rows[i]["Purchasecontractnumber"].ToString();
                    row.Cells["db"].Value = queryTable.Rows[i]["db"].ToString();
                    row.Cells["tvn"].Value = queryTable.Rows[i]["tvn"].ToString();
                    row.Cells["za"].Value = queryTable.Rows[i]["za"].ToString();
                    row.Cells["ffa"].Value = queryTable.Rows[i]["ffa"].ToString();
                    row.Cells["zf"].Value = queryTable.Rows[i]["zf"].ToString();
                    row.Cells["sf"].Value = queryTable.Rows[i]["sf"].ToString();
                    row.Cells["shy"].Value = queryTable.Rows[i]["shy"].ToString();
                    row.Cells["sz"].Value = queryTable.Rows[i]["sz"].ToString();
                    row.Cells["cdb"].Value = queryTable.Rows[i]["cdb"].ToString();
                    row.Cells["tvnOne"].Value = queryTable.Rows[i]["tvnOne"].ToString();
                    row.Cells["hf"].Value = queryTable.Rows[i]["hf"].ToString();
                    row.Cells["cm"].Value = queryTable.Rows[i]["cm"].ToString();
                    row.Cells["zjh"].Value = queryTable.Rows[i]["zjh"].ToString();
                    row.Cells["tdh"].Value = queryTable.Rows[i]["tdh"].ToString();
                    row.Cells["rebate"].Value = queryTable.Rows[i]["rebate"].ToString();
                    row.Cells["WithSkin"].Value = queryTable.Rows[i]["WithSkin"].ToString();
                    row.Cells["Portprice"].Value = queryTable.Rows[i]["Portprice"].ToString();
                    row.Cells["Country"].Value = queryTable.Rows[i]["Country"].ToString();
                    row.Cells["pp"].Value = queryTable.Rows[i]["pp"].ToString();
                    row.Cells["transport"].Value = queryTable.Rows[i]["transport"].ToString();
                    row.Cells["deadline"].Value = queryTable.Rows[i]["deadline"].ToString();
                    row.Cells["Settlementmethod"].Value = queryTable.Rows[i]["Settlementmethod"].ToString();
                    row.Cells["payment"].Value = queryTable.Rows[i]["payment"].ToString();
                    row.Cells["Bank"].Value = queryTable.Rows[i]["Bank"].ToString();
                    row.Cells["Receipt"].Value = queryTable.Rows[i]["Receipt"].ToString();
                    row.Cells["accountnumber"].Value = queryTable.Rows[i]["accountnumber"].ToString();
                    row.Cells["createman"].Value = queryTable.Rows[i]["createman"].ToString();
                    row.Cells["DemandSideBank"].Value = queryTable.Rows[i]["DemandSideBank"].ToString();
                    row.Cells["PaymentUnit"].Value = queryTable.Rows[i]["PaymentUnit"].ToString();
                    row.Cells["RequiredAccount"].Value = queryTable.Rows[i]["RequiredAccount"].ToString();
                    row.Cells["SupplierContact"].Value = queryTable.Rows[i]["SupplierContact"].ToString();
                    row.Cells["SupplierContactId"].Value = queryTable.Rows[i]["SupplierContactId"].ToString();
                    row.Cells["DemandContact"].Value = queryTable.Rows[i]["DemandContact"].ToString();
                    row.Cells["DemandContactId"].Value = queryTable.Rows[i]["DemandContactId"].ToString();
                    row.Cells["zaOne"].Value = queryTable.Rows[i]["zaOne"].ToString();
                    row.Cells["ffaOne"].Value = queryTable.Rows[i]["ffaOne"].ToString();
                    row.Cells["zfOne"].Value = queryTable.Rows[i]["zfOne"].ToString();
                    row.Cells["sfOne"].Value = queryTable.Rows[i]["sfOne"].ToString();
                    row.Cells["shyOne"].Value = queryTable.Rows[i]["shyOne"].ToString();
                    row.Cells["szOne"].Value = queryTable.Rows[i]["szOne"].ToString();
                    row.Cells["supplierId"].Value = queryTable.Rows[i]["supplierId"].ToString();
                    row.Cells["demandId"].Value = queryTable.Rows[i]["demandId"].ToString();
                    row.Cells["PurchasingunitsId"].Value = queryTable.Rows[i]["PurchasingunitsId"].ToString();
                    row.Cells["PurchasingcontactsId"].Value = queryTable.Rows[i]["PurchasingcontactsId"].ToString();
                    row.Cells["CNumbering"].Value = queryTable.Rows[i]["CNumbering"].ToString();
                    row.Cells["delivery"].Value = queryTable.Rows[i]["delivery"].ToString();
                    //row . Cells [ "moneyYFK" ] . Value = queryTable . Rows [ i ] [ "moneyYFK" ] . ToString ( );
                }
            }
            else {
                MessageBox.Show("查无数据！");
            }

            return base.Query();
        }

        private void txtsupplier_Click(object sender, System.EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            if (form.SelectCompany == null)
                return;
            txtsupplier.Text = form.SelectCompany.fullname;
            txtsupplier.Tag = form.SelectCompany.code;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _fish = new FishEntity.SalesRequisitionEntity();
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["code"].Value != null)
            {
                _fish.code = dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
                _fish.rebate = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["rebate"].Value.ToString());
                _fish.HeTongDanJia = dataGridView1.Rows[e.RowIndex].Cells["unitprice"].Value.ToString();
                _fish.Freight = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["Freight"].Value.ToString());
                _fish.demand = dataGridView1.Rows[e.RowIndex].Cells["demand"].Value.ToString();
                _fish.Purchasingunits = dataGridView1.Rows[e.RowIndex].Cells["Purchasingunits"].Value.ToString();
                _fish.Purchasecontractnumber = dataGridView1.Rows[e.RowIndex].Cells["Purchasecontractnumber"].Value.ToString();
                _fish.accountnumber = dataGridView1.Rows[e.RowIndex].Cells["accountnumber"].Value.ToString();
                _fish.Bank = dataGridView1.Rows[e.RowIndex].Cells["Bank"].Value.ToString();
                _fish.supplier = dataGridView1.Rows[e.RowIndex].Cells["supplier"].Value.ToString();
                _fish.SupplierContact = dataGridView1.Rows[e.RowIndex].Cells["SupplierContact"].Value.ToString();
                _fish.supplierId = dataGridView1.Rows[e.RowIndex].Cells["supplierId"].Value.ToString();
                _fish.SupplierContactId = dataGridView1.Rows[e.RowIndex].Cells["SupplierContactId"].Value.ToString();
                _fish.demandId = dataGridView1.Rows[e.RowIndex].Cells["demandId"].Value.ToString();
                _fish.DemandContact = dataGridView1.Rows[e.RowIndex].Cells["DemandContact"].Value.ToString();
                _fish.DemandContactId = dataGridView1.Rows[e.RowIndex].Cells["DemandContactId"].Value.ToString();
                _fish.Purchasingcontacts = dataGridView1.Rows[e.RowIndex].Cells["Purchasingcontacts"].Value.ToString();
                _fish.PurchasingcontactsId = dataGridView1.Rows[e.RowIndex].Cells["PurchasingcontactsId"].Value.ToString();
                _fish.PurchasingunitsId = dataGridView1.Rows[e.RowIndex].Cells["PurchasingunitsId"].Value.ToString();
                _fish.CNumbering = dataGridView1.Rows[e.RowIndex].Cells["CNumbering"].Value.ToString();
                _fish.Numbering = dataGridView1.Rows[e.RowIndex].Cells["Numbering"].Value.ToString();
                _fish.Product_id = dataGridView1.Rows[e.RowIndex].Cells["product_id"].Value.ToString();
                _fish.Country = dataGridView1.Rows[e.RowIndex].Cells["Country"].Value.ToString();
                _fish.pp = dataGridView1.Rows[e.RowIndex].Cells["pp"].Value.ToString();
                _fish.Productname = dataGridView1.Rows[e.RowIndex].Cells["productname"].Value.ToString();
                _fish.Funit = dataGridView1.Rows[e.RowIndex].Cells["Funit"].Value.ToString();
                _fish.Variety = dataGridView1.Rows[e.RowIndex].Cells["Variety"].Value.ToString();
                _fish.Quantity = dataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
                _fish.Amonut = dataGridView1.Rows[e.RowIndex].Cells["amonut"].Value.ToString(); 
                _fish.DemandAbbreviation = dataGridView1.Rows[e.RowIndex].Cells["XFshortname"].Value.ToString();
                _fish.SupplierAbbreviation = dataGridView1.Rows[e.RowIndex].Cells["GFshortname"].Value.ToString();
                _fish . MoneyYFK = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "moneyYFK" ] . Value == null ? 0 : ( string . IsNullOrEmpty ( dataGridView1 . Rows [ e . RowIndex ] . Cells [ "moneyYFK" ] . Value . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dataGridView1 . Rows [ e . RowIndex ] . Cells [ "moneyYFK" ] . Value ) );

                _fish .delivery = dataGridView1.Rows[e.RowIndex].Cells["delivery"].Value.ToString();
                _fish.Db = dataGridView1.Rows[e.RowIndex].Cells["db"].Value.ToString();
                _fish.Za = dataGridView1.Rows[e.RowIndex].Cells["za"].Value.ToString();
                _fish.Sz = dataGridView1.Rows[e.RowIndex].Cells["sz"].Value.ToString();
                _fish.Tvn = dataGridView1.Rows[e.RowIndex].Cells["tvn"].Value.ToString();
                _fish.Hf = dataGridView1.Rows[e.RowIndex].Cells["Hf"].Value.ToString();
                _fish.Sf = dataGridView1.Rows[e.RowIndex].Cells["Sf"].Value.ToString();
                _fish.Shy = dataGridView1.Rows[e.RowIndex].Cells["Shy"].Value.ToString();
                _fish.Zf = dataGridView1.Rows[e.RowIndex].Cells["Zf"].Value.ToString();
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_143");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_143");
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
