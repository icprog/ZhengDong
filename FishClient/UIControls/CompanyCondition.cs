using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FishEntity;
namespace FishClient.UIControls
{
    public partial class CompanyCondition : UserControl
    {
        public CompanyCondition()
        {
            InitializeComponent();

            if (this.DesignMode) return;

            BindCheckBoxComboBoxData(FishEntity.Constant.Type);

            InitDataUtil.BindComboBoxData(cmbGenerallevel, FishEntity.Constant.GeneralLevel, true);

            InitDataUtil.BindComboBoxData(cmbactivelevel, FishEntity.Constant.ActiveLevel, true);

            InitDataUtil.BindComboBoxData(cmbCreditlevel, FishEntity.Constant.CreditLevel, true);

            InitDataUtil.BindComboBoxData(cmbrequiredlevel, FishEntity.Constant.RequiredLevel, true);

            InitDataUtil.BindComboBoxData(cmbloyalty, FishEntity.Constant.Loyalty, true);

            InitDataUtil.BindComboBoxData(cmbproducts, FishEntity.Constant.Products, true);

            InitDataUtil.BindComboBoxData(cmbManageSpecificate, FishEntity.Constant.ManageSpecificateDegree, true);

            InitDataUtil.BindComboBoxData(cmbmanageprojects, FishEntity.Constant.ManageProjects, true);

            InitDataUtil.BindComboBoxData(cmbNature, FishEntity.Constant.CompanyNature, true);

            InitDataUtil.BindComboBoxData(cmbCustomerProperty, FishEntity.Constant.CustomerProperty, true);
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
            if (cmbproducts.SelectedValue == null) return;
            string pcode = cmbProvince.SelectedValue.ToString();
            FishEntity.DictEntity pModel = InitDataUtil.DictList.Find((i) => { return i.code == pcode && i.pcode.Equals(FishEntity.Constant.Province); });
            int pid = 0;
            if (pModel != null)
            {
                pid = pModel.id;
            }


            List<FishEntity.DictEntity> list = InitDataUtil.DictList.FindAll((i) => { return i.pid == pid && i.pcode.Equals(FishEntity.Constant.Area); });
            if (true)
            {
                if (list == null)
                {
                    list = new List<DictEntity>();
                }
                DictEntity empty = new DictEntity();
                empty.code = string.Empty;
                empty.name = string.Empty;
                list.Insert(0, empty);
            }

            cmbArea.DisplayMember = "name";
            cmbArea.ValueMember = "code";
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
        
        public string GetQueryCondition()
        {
            string where = "1=1";

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

            string orwhere = string.Empty;
            foreach (UILibrary.CheckBoxComboBox.CheckBoxComboBoxItem item in cmbType.CheckBoxItems)
            {
                if (item.Checked)
                {
                    FishEntity.DictEntity kv = ((UILibrary.CheckBoxComboBox.ObjectSelectionWrapper<FishEntity.DictEntity>)item.ComboBoxItem).Item;

                    if (String.IsNullOrEmpty(orwhere) == false) orwhere += " or "; 

                    orwhere += kv.code.Equals("供应商") ? " type_suppliers = 1" : "";
                    orwhere += kv.code.Equals("代理商") ? "  type_agents = 1" : "";
                    orwhere += kv.code.Equals("客户") ? "  type_customer=1" : "";
                    orwhere += kv.code.Equals("贸易商") ? "  type_merchants=1" : "";
                    orwhere += kv.code.Equals("货代商") ? "  type_goods=1" : "";
                    orwhere += kv.code.Equals("报盘商") ? "  type_quote=1" : "";
                }
            }
            if (string.IsNullOrEmpty(orwhere) == false)
            {
                where += " and ( " + orwhere + " ) ";
            }

            if ( null !=cmbGenerallevel.SelectedValue && false == string.IsNullOrEmpty(cmbGenerallevel.SelectedValue.ToString()))
            {
                where += string.Format(" and generallevel ='{0}'", cmbGenerallevel.SelectedValue.ToString());
            }
            if (null != cmbProvince.SelectedValue && false == string.IsNullOrEmpty(cmbProvince.SelectedValue.ToString()))
            {
                where += string.Format(" and province ='{0}'", cmbProvince.SelectedValue.ToString());
            }
            if (null != cmbArea.SelectedValue && false == string.IsNullOrEmpty(cmbArea.SelectedValue.ToString()))
            {
                where += string.Format(" and zone ='{0}'", cmbArea.SelectedValue.ToString());
            }
            if (null != cmbCreditlevel.SelectedValue && false == string.IsNullOrEmpty(cmbCreditlevel.SelectedValue.ToString()))
            {
                where += string.Format(" and creditlevel ='{0}'", cmbCreditlevel.SelectedValue.ToString());
            }

            if (null != cmbrequiredlevel.SelectedValue && false == string.IsNullOrEmpty(cmbrequiredlevel.SelectedValue.ToString()))
            {
                where += string.Format(" and requiredlevel ='{0}'", cmbrequiredlevel.SelectedValue.ToString());
            }

            if (null != cmbManageSpecificate.SelectedValue && false == string.IsNullOrEmpty(cmbManageSpecificate.SelectedValue.ToString()))
            {
                where += string.Format(" and managestandard ='{0}'", cmbManageSpecificate.SelectedValue.ToString());
            }

            if (null != cmbactivelevel.SelectedValue && false == string.IsNullOrEmpty(cmbactivelevel.SelectedValue.ToString()))
            {
                where += string.Format(" and activelevel ='{0}'", cmbactivelevel.SelectedValue.ToString());
            }

            if (null != cmbloyalty.SelectedValue && false == string.IsNullOrEmpty(cmbloyalty.SelectedValue.ToString()))
            {
                where += string.Format(" and loyalty ='{0}'", cmbloyalty.SelectedValue.ToString());
            }

            if (null != cmbproducts.SelectedValue && false == string.IsNullOrEmpty(cmbproducts.SelectedValue.ToString()))
            {
                where += string.Format(" and products ='{0}'", cmbproducts.SelectedValue.ToString());
            }

            if (false == string.IsNullOrEmpty( txtsalesman.Text ) )
            {
                where += string.Format(" and salesman like'%{0}%'", txtsalesman.Text.Trim());
            }

            if (false == string.IsNullOrEmpty(txtarea.Text))
            {
                where += string.Format(" and area like'%{0}%'", txtarea.Text.Trim());
            }

            if (false == string.IsNullOrEmpty(txtaddress.Text))
            {
                where += string.Format(" and address like'%{0}%'", txtaddress.Text.Trim());
            }

            if (null != cmbNature.SelectedValue && false == string.IsNullOrEmpty(cmbNature.SelectedValue.ToString()))
            {
                where += string.Format(" and nature ='{0}'", cmbNature.SelectedValue.ToString());
            }

            if (null != cmbmanageprojects.SelectedValue && false == string.IsNullOrEmpty(cmbmanageprojects.SelectedValue.ToString()))
            {
                where += string.Format(" and manageprojects ='{0}'", cmbmanageprojects.SelectedValue.ToString());
            }

            if (false == string.IsNullOrEmpty(txtregistermoney.Text))
            {
                where += string.Format(" and registermoney like '%{0}%'", txtregistermoney.Text.Trim());
            }

            if (false == string.IsNullOrEmpty(txtzip.Text))
            {
                where += string.Format(" and zip like '%{0}%'", txtzip.Text.Trim());
            }

            if (false == string.IsNullOrEmpty(txtfox.Text))
            {
                where += string.Format(" and fox like '%{0}%'", txtfox.Text.Trim());
            }

            if (null != cmbCustomerProperty.SelectedValue && false == string.IsNullOrEmpty(cmbCustomerProperty.SelectedValue.ToString()))
            {
                where += string.Format(" and customerproperty ='{0}'", cmbCustomerProperty.SelectedValue.ToString());
            }

            if (false == string.IsNullOrEmpty(txtCustomerGroup.Text))
            {
                where += string.Format(" and customergroup like '%{0}%'", txtCustomerGroup.Text.Trim());
            }

            if (false == string.IsNullOrEmpty(txtlinkman.Text))
            {
                where += string.Format(" and linkman like '%{0}%'", txtlinkman.Text.Trim());
            }

            return where;
        }

        private void CompanyCondition_Load(object sender, EventArgs e)
        {
           
        }
    }
}
