using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormPurchaseRequisition : FormMenuBase
    {
        List<FishEntity.PurchaseRequisitionEntity> _list = new List<FishEntity.PurchaseRequisitionEntity>();
        FishEntity.PurchaseRequisitionEntity _fish = null;
        FishBll.Bll.PurchaseRequisitionBll _bll = new FishBll.Bll.PurchaseRequisitionBll();
        public string GetContractNo=string.Empty;
        public FormPurchaseRequisition()
        {
            MenuCode = "M432"; ControlButtomRoles();
            InitializeComponent();
            InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CountryType, true);
            dtpdatebefore.Value = DateTime.Now.AddYears(-1);
            cmbvalidate.Text = "有效";
        }
        public override int Add()
        {
            PurchaseRequisitionEdit form = new PurchaseRequisitionEdit("采购申请单", null);
            form.ShowInTaskbar = false;
            form.RefreshEvent += form_RefreshEvent;
            form.Show();
            return 0;
        }
        void form_RefreshEvent(EventArgs obj)
        {
            Query();
        }
        public override int Query()
        {
            string strwhere = " 1=1 ";
            if (!string.IsNullOrEmpty(txtContractNo.Text))
            {
                strwhere += "and ContractNo like '%" + txtContractNo.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtsupplier.Text))
            {
                strwhere += "and supplier like '%" + txtsupplier.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtDemandSide.Text))
            {
                strwhere += "and DemandSide like '%" + txtDemandSide.Text + "%'";
            }
            if (cmbCountry.SelectedValue != null && cmbCountry.SelectedValue.ToString() != string.Empty)
            {
                strwhere += string.Format(" and Country like '%{0}%'", cmbCountry.SelectedValue.ToString());
            }
            switch (cmbvalidate.SelectedItem.ToString()) {
                case "有效": strwhere += string.Format(" and validate like '%{0}%'", cmbvalidate.SelectedItem.ToString());break;
                case "无效": strwhere += string.Format(" and validate like '%{0}%'", cmbvalidate.SelectedItem.ToString()); break;
                case "全部": 
                default: break;
            }
            strwhere += string.Format(" and DateOfSigni>='{0}' and DateOfSigni<='{1}'",
                dtpdatebefore.Value.ToString("yyyy-MM-dd 00:00:00"),
                dtpdateRear.Value.ToString("yyyy-MM-dd 23:59:59"));
            _list = _bll.GetList(strwhere);
            if (_list != null)
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = _list;
            }
            else {
                MessageBox.Show("查无数据！");
            }
            return base.Query();
        }
        public override int Modify()
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("请选择要编辑的行");
                return 0;
            }
            FishEntity.PurchaseRequisitionEntity entity = dataGridView1.CurrentRow.DataBoundItem as FishEntity.PurchaseRequisitionEntity;
            if (entity == null)
            {
                MessageBox.Show("请选择需要编辑的行");
                return 0;
            }

            PurchaseRequisitionEdit inven = new PurchaseRequisitionEdit("采购申请单", entity);
            inven.RefreshEvent += form_RefreshEvent;
            inven.Show();

            return 0;
        }
        private void txtsupplier_Click(object sender, EventArgs e)
        {
            FormCompanyList Form = new FormCompanyList();
            Form.StartPosition = FormStartPosition.CenterParent;
            if (Form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            if (Form.SelectCompany == null)
            {
                return;
            }
            txtsupplier.Text = Form.SelectCompany.fullname;
            txtsupplier.Tag = Form.SelectCompany.code;
        }

        private void txtDemandSide_Click(object sender, EventArgs e)
        {
            FormCompanyList Form = new FormCompanyList();
            Form.StartPosition = FormStartPosition.CenterParent;
            if (Form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            if (Form.SelectCompany == null)
            {
                return;
            }
            txtDemandSide.Text = Form.SelectCompany.fullname;
            txtDemandSide.Tag = Form.SelectCompany.code;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; Modify();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _fish = new FishEntity.PurchaseRequisitionEntity();
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["ContractNo"].Value != null)
            {
                _fish.ContractNo = dataGridView1.Rows[e.RowIndex].Cells["ContractNo"].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells["supplier"].Value!=null&& dataGridView1.Rows[e.RowIndex].Cells["supplier"].Value.ToString()!="")
                {
                    _fish.Supplier = dataGridView1.Rows[e.RowIndex].Cells["supplier"].Value.ToString();
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["Purchasingcontacts"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["Purchasingcontacts"].Value.ToString() != "")
                {
                    _fish.Purchasingcontacts = dataGridView1.Rows[e.RowIndex].Cells["Purchasingcontacts"].Value.ToString();
                } 
                _fish.Openbank = dataGridView1.Rows[e.RowIndex].Cells["Openbank"].Value.ToString();
                _fish.Accountnumber = dataGridView1.Rows[e.RowIndex].Cells["accountnumber"].Value.ToString();
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        public FishEntity.PurchaseRequisitionEntity fish
        {
            get
            {
                return _fish;
            }
        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _fish = new FishEntity.PurchaseRequisitionEntity();
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["ContractNo"].Value != null&&dataGridView1.Rows[e.RowIndex].Cells["FishmealId"].Value != null)
            {
                _fish.ContractNo = dataGridView1.Rows[e.RowIndex].Cells["ContractNo"].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells["supplier"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["supplier"].Value.ToString() != "")
                {
                    _fish.Supplier = dataGridView1.Rows[e.RowIndex].Cells["supplier"].Value.ToString();
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["Purchasingcontacts"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["Purchasingcontacts"].Value.ToString() != "")
                {
                    _fish.Purchasingcontacts = dataGridView1.Rows[e.RowIndex].Cells["Purchasingcontacts"].Value.ToString();
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["SupplierId"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["SupplierId"].Value.ToString() != "")
                {
                    _fish.SupplierId = dataGridView1.Rows[e.RowIndex].Cells["SupplierId"].Value.ToString();
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["DemandSideId"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["DemandSideId"].Value.ToString() != "")
                {
                    _fish.DemandSideId = dataGridView1.Rows[e.RowIndex].Cells["DemandSideId"].Value.ToString();
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["PurchasingcontactsId"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["PurchasingcontactsId"].Value.ToString() != "")
                {
                    _fish.PurchasingcontactsId = dataGridView1.Rows[e.RowIndex].Cells["PurchasingcontactsId"].Value.ToString();
                }
                _fish.Numbering = dataGridView1.Rows[e.RowIndex].Cells["Numbering"].Value.ToString();
                _fish.FishmealId = dataGridView1.Rows[e.RowIndex].Cells["FishmealId"].Value.ToString();
                _fish.Openbank = dataGridView1.Rows[e.RowIndex].Cells["Openbank"].Value.ToString();
                _fish.Accountnumber = dataGridView1.Rows[e.RowIndex].Cells["accountnumber"].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells["NameOfTheShip"].Value != null)
                    _fish.NameOfTheShip = dataGridView1.Rows[e.RowIndex].Cells["NameOfTheShip"].Value.ToString();
                else
                    _fish.NameOfTheShip = string.Empty;
                if (dataGridView1.Rows[e.RowIndex].Cells["BillOfLadingNumber"].Value != null)
                    _fish.BillOfLadingNumber = dataGridView1.Rows[e.RowIndex].Cells["BillOfLadingNumber"].Value.ToString();
                else
                    _fish.BillOfLadingNumber = string.Empty;
                if (dataGridView1.Rows[e.RowIndex].Cells["Country"].Value != null)
                    _fish.Country = dataGridView1.Rows[e.RowIndex].Cells["Country"].Value.ToString();
                else
                    _fish.Country = string.Empty;
                if (dataGridView1.Rows[e.RowIndex].Cells["Brand"].Value != null)
                    _fish.Brand = dataGridView1.Rows[e.RowIndex].Cells["Brand"].Value.ToString();
                else
                    _fish.Brand = string.Empty;
                if (dataGridView1.Rows[e.RowIndex].Cells["Variety"].Value != null)
                    _fish.Variety = dataGridView1.Rows[e.RowIndex].Cells["Variety"].Value.ToString();
                else
                    _fish.Variety = string.Empty;
                if (dataGridView1.Rows[e.RowIndex].Cells["Specification"].Value != null)
                    _fish.Specification = dataGridView1.Rows[e.RowIndex].Cells["Specification"].Value.ToString();
                else
                    _fish.Specification = string.Empty;
                if (dataGridView1.Rows[e.RowIndex].Cells["Protein"].Value != null)
                    _fish.Protein = dataGridView1.Rows[e.RowIndex].Cells["Protein"].Value.ToString();
                else
                    _fish.Protein = string.Empty;
                if (dataGridView1.Rows[e.RowIndex].Cells["TVN"].Value != null)
                    _fish.TVN = dataGridView1.Rows[e.RowIndex].Cells["TVN"].Value.ToString();
                else
                    _fish.TVN = string.Empty;
                if (dataGridView1.Rows[e.RowIndex].Cells["Histamine"].Value != null)
                    _fish.Histamine = dataGridView1.Rows[e.RowIndex].Cells["Histamine"].Value.ToString();
                else
                    _fish.Histamine = string.Empty;
                if (dataGridView1.Rows[e.RowIndex].Cells["FFA"].Value != null)
                    _fish.FFA = dataGridView1.Rows[e.RowIndex].Cells["FFA"].Value.ToString();
                else
                    _fish.FFA = string.Empty;
                if (dataGridView1.Rows[e.RowIndex].Cells["Fat"].Value != null)
                    _fish.Fat = dataGridView1.Rows[e.RowIndex].Cells["Fat"].Value.ToString();
                else
                    _fish.Fat = string.Empty;
                if (dataGridView1.Rows[e.RowIndex].Cells["Moisture"].Value != null)
                    _fish.Moisture = dataGridView1.Rows[e.RowIndex].Cells["Moisture"].Value.ToString();
                else
                    _fish.Moisture = string.Empty;
                if (dataGridView1.Rows[e.RowIndex].Cells["SandAndSalt"].Value != null)
                    _fish.SandAndSalt = dataGridView1.Rows[e.RowIndex].Cells["SandAndSalt"].Value.ToString();
                else
                    _fish.SandAndSalt = string.Empty;
                if (dataGridView1.Rows[e.RowIndex].Cells["Sand"].Value != null)
                    _fish.Sand = dataGridView1.Rows[e.RowIndex].Cells["Sand"].Value.ToString();
                else
                    _fish.Sand = string.Empty;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void dataGridView1_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            _fish = new FishEntity.PurchaseRequisitionEntity();
            
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
