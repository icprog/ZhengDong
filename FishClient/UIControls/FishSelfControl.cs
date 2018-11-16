using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FishClient.UIControls
{
    public partial class FishSelfControl : UILibrary.TCBaseControl
    {
        protected FishEntity.ProductExEntity _entity = null;

        public FishSelfControl()
        {
            InitializeComponent();
        }
        public void SetFishEx(FishEntity.ProductExEntity entity)
        {
            _entity = entity;

            if (_entity == null)
            {
                txtSelfDate.Text = string.Empty;
                txtSelfCompany.Text = string.Empty;
                txtSelfCompany.Tag = string.Empty;
                txtSelfDollars.Text = string.Empty;
                txtSelfLinkman.Text = string.Empty;
                txtSelfLinkman.Tag = string.Empty;
                txtSelfQuantity.Text = string.Empty;
                txtSelfrmb.Text = string.Empty;
                txtSelfStorageDate.Text = string.Empty;
                txtSelfWeight.Text = string.Empty;
                rdbYes.Checked = true;
            }
            else
            {
                txtSelfCompany.Tag = _entity.selftradercode;
                txtSelfCompany.Text = _entity.selftrader;
                txtSelfDate.Text = _entity.selfdate;
                if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
                {
                    txtSelfDollars.PasswordChar = '*';
                    txtSelfrmb.PasswordChar = '*';
                }
                txtSelfDollars.Text = _entity.selfdollars.HasValue ? _entity.selfdollars.Value.ToString("f2") : "0.00";
                txtSelfLinkman.Text = _entity.selflinkman;
                txtSelfLinkman.Tag = _entity.selflinkmancode;
                txtSelfQuantity.Text = _entity.selfstoragequantity.HasValue ? _entity.selfstoragequantity.Value.ToString() : "0";
                txtSelfrmb.Text = _entity.selfrmb.HasValue ? _entity.selfrmb.Value.ToString("f2") : "0.00";
                txtSelfStorageDate.Text = _entity.selfstoragedate;
                txtSelfWeight.Text = _entity.selfstorageweight.HasValue ? _entity.selfstorageweight.Value.ToString("f2") : "0.00";

                rdbYes.Checked = _entity.selffinishproduct.EndsWith("1") ? true : false;
                rdbNo.Checked = !rdbYes.Checked;
            }
        }
        public void GetFishEx(FishEntity.ProductExEntity entity)
        {
            entity.selfdate = txtSelfDate.Text.Trim();
            decimal dollars = 0;
            decimal.TryParse(txtSelfDollars.Text, out dollars);
            entity.selfdollars = dollars;

            entity.selffinishproduct = rdbYes.Checked ? "1" : "0";
            entity.selflinkman = txtSelfLinkman.Text.Trim();
            entity.selflinkmancode = txtSelfLinkman.Tag == null ? string.Empty : txtSelfLinkman.Tag.ToString();
            decimal rmb = 0;
            decimal.TryParse(txtSelfrmb.Text, out rmb);
            entity.selfrmb = rmb;
            entity.selfstoragedate = txtSelfStorageDate.Text.Trim();
            int quantity = 0;
            int.TryParse(txtSelfQuantity.Text, out quantity);
            entity.selfstoragequantity = quantity;
            decimal weight = 0;
            decimal.TryParse(txtSelfWeight.Text, out weight);
            entity.selfstorageweight = weight;
            entity.selftrader = txtSelfCompany.Text.Trim();
            entity.selftradercode = txtSelfCompany.Tag == null ? string.Empty : txtSelfCompany.Tag.ToString();

        }

        public void Clear()
        {
            txtSelfDate.Text = string.Empty;
            txtSelfCompany.Text = string.Empty;
            txtSelfCompany.Tag = string.Empty;
            txtSelfDollars.Text = string.Empty;
            txtSelfLinkman.Text = string.Empty;
            txtSelfLinkman.Tag = string.Empty;
            txtSelfQuantity.Text = string.Empty;
            txtSelfrmb.Text = string.Empty;
            txtSelfStorageDate.Text = string.Empty;
            txtSelfWeight.Text = string.Empty;
            rdbYes.Checked = true;
        }

        private void txtSelfCompany_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtSelfCompany.Text = form.SelectCompany.fullname;
            txtSelfCompany.Tag = form.SelectCompany.code;

            txtSelfLinkman.Text = string.Empty;
            txtSelfLinkman.Tag = string.Empty;
        }

        private void txtSelfLinkman_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSelfCompany.Text) == true)
            {
                MessageBox.Show("请先选择货主贸易商,再操作。");
                return;
            }
            if (txtSelfCompany.Tag == null) return;
            string companycode = string.Empty;
            companycode = txtSelfCompany.Tag.ToString();
            UIForms.FormSelectCustomer form = new UIForms.FormSelectCustomer(companycode);
            form.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = form.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                FishEntity.CustomerEntity customer = form.SelectedCustomer;
                if (customer != null)
                {
                    txtSelfLinkman.Text = customer.name;
                    txtSelfLinkman.Tag = customer.code;
                }
            }
        }
    }
}
