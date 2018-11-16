using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient.UIForms
{
    public partial class FormFishCondition : FormBase
    {
        public FormFishCondition()
        {
            InitializeComponent();


            FishEntity.SystemDataType item = new FishEntity.SystemDataType(string.Empty, string.Empty);
            List<FishEntity.SystemDataType> list = FishEntity.Variable.StateList.GetRange(0, FishEntity.Variable.StateList.Count);
            list.Insert(0, item);
            cmbState.DataSource = list;
            cmbState.DisplayMember = "name";
            cmbState.ValueMember = "name";

            InitDataUtil.BindComboBoxData(cmbBand, FishEntity.Constant.Brand, true);
            InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CountryType, true);
            InitDataUtil.BindComboBoxData(cmbFishType, FishEntity.Constant.FishClass, true);
            InitDataUtil.BindComboBoxData(cmborigin, FishEntity.Constant.Origin, true);
            InitDataUtil.BindComboBoxData(cmbTechClass, FishEntity.Constant.TechClass, true);
            InitDataUtil.BindComboBoxData(cmbProvince, FishEntity.Constant.Province, true);
            this.SetButtomImage(btnQuery);          
        }

        public string GetWhere()
        {
            string where = " 1=1 ";
           
            if (false == string.IsNullOrEmpty(txtCode.Text))
            {
                where += string.Format(" and code like'%{0}%'", txtCode.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtName.Text))
            {
                where += string.Format(" and name like'%{0}%'", txtName.Text.Trim());
            }

            if (cmbBand.SelectedValue != null && cmbBand.SelectedValue.ToString() != string.Empty)
            {
                where += string.Format(" and brand='{0}'", cmbBand.SelectedValue.ToString());
            }
            if (cmbState.SelectedValue != null && cmbState.SelectedValue.ToString() != string.Empty)
            {
                switch (cmbState.SelectedValue.ToString()) {
                    case"现货": where += string.Format(" AND (state = 3 OR state2 = 3 and isdelete2 = 1) "); break;
                    case"自营": where += string.Format(" AND (state = 4 OR state3 = 4 and isdelete3 = 1) "); break;
                    case"自制": where += string.Format(" AND (state = 5 OR state4 = 5 and isdelete4 = 1) "); break;
                }
            }
            if (cmbCountry.SelectedValue != null && cmbCountry.SelectedValue.ToString() != string.Empty)
            {
                where += string.Format(" and nature ='{0}'", cmbCountry.SelectedValue.ToString());
            }
            if (cmborigin.SelectedValue != null && cmborigin.SelectedValue.ToString() != string.Empty)
            {
                where += string.Format(" and origin ='{0}'", cmborigin.SelectedValue.ToString());
            }
            if (cmbFishType.SelectedValue != null && cmbFishType.SelectedValue.ToString() != string.Empty)
            {
                where += string.Format(" and type ='{0}'", cmbFishType.SelectedValue.ToString());
            }
            if (cmbTechClass.SelectedValue != null && cmbTechClass.SelectedValue.ToString() != string.Empty)
            {
                where += string.Format(" and techtype ='{0}'", cmbTechClass.SelectedValue.ToString());
            }
            if (false == string.IsNullOrEmpty(txtSpecifacation.Text))
            {
                where += string.Format(" and specification like'%{0}%'", txtSpecifacation.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtmanufacturers.Text))
            {
                where += string.Format(" and manufacturers like'%{0}%'", txtmanufacturers.Text.Trim());
            }

            if (false == string.IsNullOrEmpty(txtagentcompany.Text))
            {
                where += string.Format(" and agentifcompany like'%{0}%'" ,txtagentcompany.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtOwnerName.Text))
            {
                where += string.Format(" and ownername like'%{0}%'", txtOwnerName.Text.Trim());
            }
            if (where==" 1=1 ")
            {
                where += " and  (state = 3 OR state2 = 3 or isdelete2 = 1)and(state = 4 OR state3 = 4 or isdelete3 = 1)and(state = 5 or state4 = 5 or isdelete4=1)order by state3 desc ";
            }
            return where;
        }
    }
}
