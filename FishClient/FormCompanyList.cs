using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FishEntity;
namespace FishClient
{
    public partial class FormCompanyList : FormMenuBase
    {
        private FishEntity.CompanyEntity _selectCompany = null;

        public FishEntity.CompanyEntity SelectCompany
        {
            get
            {
                return _selectCompany;
            }
        }

        private  FishEntity.PurchaseApplicationEntity _model=null;
        public FishEntity . PurchaseApplicationEntity getModel
        {
            get
            {
                return _model;
            }
        }

        private FishEntity.WarehouseReceiptEntity Ware = null;
        public FishEntity.WarehouseReceiptEntity getModelWare
        {
            get
            {
                return Ware;
            }
        }

        public FormCompanyList()
        {
            InitializeComponent();
            menuStrip1.Items.Remove(tmiprint);
            menuStrip1.Items.Remove(tmiReview);
            ReadColumnConfig(dataGridView1, "Set_CompanyList");
            if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
            {
                cmbTheperson.Enabled = false;
            }
            FishBll.Bll.PersonBll bll = new FishBll.Bll.PersonBll();

            List<FishEntity.PersonEntity> list1 = bll.id_name();
            if (list1 == null)
            {
                list1 = new List<FishEntity.PersonEntity>();
            }
            FishEntity.PersonEntity tmep = new FishEntity.PersonEntity();


            tmep.username = "";
            list1.Insert(0, tmep);

            cmbTheperson.DataSource = list1;
            cmbTheperson.DisplayMember = "username";
            cmbTheperson.ValueMember = "username";
        }

        protected void AddMenuItem()
        {
            dataGridView1.BackgroundColor = this.BackColor;
            dataGridView1.AutoGenerateColumns = false;
        }

        protected void InitData()
        {
            BindCheckBoxComboBoxData( FishEntity.Constant.Type);

            //BindData(cmbType, FishEntity.Constant.Type);

           InitDataUtil.BindComboBoxData(cmbGenerallevel, FishEntity.Constant.GeneralLevel, true  );

           InitDataUtil.BindComboBoxData(cmbCreditlevel, FishEntity.Constant.CreditLevel , true );

          InitDataUtil.BindComboBoxData(cmbmanageprojects, FishEntity.Constant.ManageProjects,true);

          InitDataUtil.BindComboBoxData(cmbCustomerProperty, FishEntity.Constant.CustomerProperty,true );
          cmbProvince.SelectedValueChanged -= cmbCountry_SelectedValueChanged;
            InitDataUtil.BindComboBoxData(cmbProvince, FishEntity.Constant.Province, true);
          cmbProvince.SelectedValueChanged += cmbCountry_SelectedValueChanged;
        }
        void cmbCountry_SelectedValueChanged(object sender, EventArgs e)
        {
            BindCountryBrandData();
        }
        private void BindCountryBrandData()
        {
            //cmbBand.DataSource = null;
            if (cmbProvince.SelectedValue == null) return;
            string pcode = cmbProvince.SelectedValue.ToString();
            FishEntity.DictEntity pModel = InitDataUtil.DictList.Find((i) => { return i.code == pcode && i.pcode.Equals(FishEntity.Constant.Province); });
            int pid = 0;
            if (pModel != null)
            {
                pid = pModel.id;
            }


            List<FishEntity.DictEntity> list = InitDataUtil.DictList.FindAll((i) => { return i.pid == pid && i.pcode.Equals(FishEntity.Constant.Area); });
            if (list == null)
            {
                list = new List<FishEntity.DictEntity>();
            }

            FishEntity.DictEntity empty = new FishEntity.DictEntity();
            empty.code = "";
            empty.name = "";
            list.Insert(0, empty);


            cmbArea.ValueMember = "code";
            cmbArea.DisplayMember = "name";
            cmbArea.DataSource = list;
        }
        protected void BindCheckBoxComboBoxData(string key)
        {
            cmbType.Click += cmbType_Click;
            List<FishEntity.DictEntity> list = InitDataUtil.DictList.FindAll((i) => { return i.pcode.Equals(key); });
            UILibrary.CheckBoxComboBox.ListSelectionWrapper<FishEntity.DictEntity> listWraper = new UILibrary.CheckBoxComboBox.ListSelectionWrapper<FishEntity.DictEntity>(list, "name");
            cmbType.DataSource = listWraper;
            cmbType.DisplayMember = "nameConcatenated";
            cmbType.DisplayMemberSingleItem = "name";
            cmbType.ValueMember = "Selected";
        }

        void cmbType_Click(object sender, EventArgs e)
        {
            cmbType.Focus();
        }

        protected void BindData(ComboBox cmb, string key)
        {
            List<FishEntity.DictEntity> list = InitDataUtil.DictList.FindAll((i) => { return i.pcode.Equals( key ); });
            cmb.DisplayMember = "name";
            cmb.ValueMember = "code";
            cmb.DataSource = list;
        }

        private void FormCompanyList_Load(object sender, EventArgs e)
        {
            AddMenuItem();

            InitData();

            menuStrip1.Visible = true;
            tmiAdd.Visible = true;
            tmiDelete.Visible = false;
            tmiModify.Visible = false;
            tmiExport.Visible = false;
            tmiNext.Visible = false;
            tmiPrevious.Visible = false;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;
        }

        protected string GetQueryCondition()
        {
            string where = "1=1";

            //if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
            //{//控制权限
            //    where += string.Format(" and salesmancode ='{0}'", FishEntity.Variable.User.id);
            //}
            //if (string.IsNullOrEmpty(cmbType.SelectedText)==false)
            //{

            //}
            if (string.IsNullOrEmpty(txtcode.Text) == false)
            {
                where += string.Format(" and code like '%{0}%'", txtcode.Text.Trim());
            }

            if (string.IsNullOrEmpty(txtfullname.Text) == false)
            {
                where += string.Format(" and fullname like '%{0}%'", txtfullname.Text.Trim());
            }
            if (string.IsNullOrEmpty(txtShortName.Text) == false)
            {
                where += string.Format(" and shortname like'%{0}%'", txtShortName.Text.Trim());
            }
            if (null != cmbProvince.SelectedValue && false == string.IsNullOrEmpty(cmbProvince.SelectedValue.ToString()))
            {
                where += string.Format(" and province ='{0}'", cmbProvince.SelectedValue.ToString());
            }
            if (null != cmbArea.SelectedValue && false == string.IsNullOrEmpty(cmbArea.SelectedValue.ToString()))
            {
                where += string.Format(" and zone ='{0}'", cmbArea.SelectedValue.ToString());
            }
            foreach (UILibrary.CheckBoxComboBox.CheckBoxComboBoxItem item in cmbType.CheckBoxItems)
            {
                if (item.Checked)
                {
                    FishEntity.DictEntity kv = ((UILibrary.CheckBoxComboBox.ObjectSelectionWrapper<FishEntity.DictEntity>)item.ComboBoxItem).Item;

                    where += kv.code.Equals("国内供应商") ? " and type_suppliers = 1" : "";
                    where += kv.code.Equals("代理商") ? " and type_agents = 1" : "";
                    where += kv.code.Equals("客户") ? " and type_customer=1" : "";
                    where += kv.code.Equals("贸易商") ? " and type_merchants=1" : "";
                    where += kv.code.Equals("货代商") ? " and type_goods=1" : "";
                    where += kv.code.Equals("报盘商") ? " and type_quote=1" : "";
                    where += kv.code.Equals("物流运输") ? " and Logistics=1" : "";
                }
            }

           
            if( cmbGenerallevel .SelectedValue !=null && cmbGenerallevel.SelectedValue.ToString() != string.Empty)
            {
                where += string.Format(" and generallevel='" + cmbGenerallevel.SelectedValue.ToString() +"'" );
            }
            if (cmbCreditlevel.SelectedValue != null && string.IsNullOrEmpty( cmbCreditlevel .SelectedValue.ToString() ) == false )
            {
                where += string.Format(" and creditlevel='" + cmbCreditlevel.SelectedValue.ToString() + "'");
            }
            if ( string.IsNullOrEmpty ( txtarea.Text ) == false )
            {
                where += string.Format(" and area like'%" + txtarea.Text.Trim() + "%'");
            }
             if ( string.IsNullOrEmpty ( txtaddress.Text ) == false )
            {
                where += string.Format(" and address like'%" + txtaddress.Text.Trim() + "%'");
            }
             if ( cmbmanageprojects.SelectedValue !=null  && string.IsNullOrEmpty( cmbmanageprojects.SelectedValue.ToString() ) ==false )
            {
                where += string.Format(" and manageprojects ='" + cmbmanageprojects.SelectedValue.ToString () + "'");
            }
            if (cmbTheperson.SelectedValue.ToString() != "")
            {
                where += string.Format(" and createman='{0}' ", cmbTheperson.SelectedValue.ToString());
            }
            if ( string.IsNullOrEmpty ( txtzip.Text ) == false )
            {
                where += string.Format(" and zip like '%" + txtzip.Text.Trim() + "%'");
            }
               if ( string.IsNullOrEmpty ( txtfox.Text ) == false )
            {
                where += string.Format(" and fox like '%" + txtfox.Text.Trim() + "%'");
            }
              if ( cmbCustomerProperty.SelectedValue !=null && string.IsNullOrEmpty( cmbCustomerProperty.SelectedValue.ToString() ) == false  )
            {
                where += string.Format(" and customerproperty ='" + cmbCustomerProperty.SelectedValue.ToString () + "'");
            }
                if ( string.IsNullOrEmpty ( txtCustomerGroup.Text ) == false )
            {
                where += string.Format(" and customergroup like '%" + txtCustomerGroup.Text.Trim() + "%'");
            }

            return where;
        }

        public override int Query()
        {
            int sum=0;
            string where = GetQueryCondition();
            FishBll.Bll.CompanyBll bll = new FishBll.Bll.CompanyBll();
            List<FishEntity.CompanyEntity> list = bll.GetModelList( where );

            dataGridView1.DataSource = list;
            sum += int.Parse(this.dataGridView1.RowCount.ToString());
            txtnumber.Text = sum.ToString();
            return 1;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            string code = string.Empty;

            if (dataGridView1.Rows[e.RowIndex].Cells["code"].Value == null)
            {
                return;
            }
            code = dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
            FormCompany form = new FormCompany(code);
            form.MenuCode = "M005";
            form.ShowDialog();
        }

        public override int Add()
        {
            FormCompany form = new FormCompany();
            form.ShowDialog();

            return 1;
        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_CompanyList");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_CompanyList");
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            this._selectCompany = dataGridView1.CurrentRow.DataBoundItem as FishEntity.CompanyEntity;
            _model = new PurchaseApplicationEntity ( );
            Ware = new WarehouseReceiptEntity();
            _model . supplier = txtfullname . Text;
            _model . supplierAbb = txtShortName . Text;
            _model . supplierUser = cmbTheperson . Text;
            _model.account = _selectCompany.account;
            _model.Bank = _selectCompany.bank;
            Ware.shipMent =Ware.Receive=Ware.SupCom = Ware.AnalysisUnit= _model . buyer = _selectCompany . fullname;
            _model . buyerAbb = _selectCompany . shortname;
            Ware.shipMentUser= _model . buyerUser = _selectCompany . linkman;
            _model.shipName = _selectCompany.shortname;
            this .DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
