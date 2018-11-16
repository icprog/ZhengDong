using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FishClient.UIControls
{
    public partial class FishConfirmControl : UILibrary.TCBaseControl
    {
        protected FishEntity.ProductExEntity _entity = null;

        public FishConfirmControl()
        {
            InitializeComponent();

            dtpConfirmDate.CustomFormat = " ";
            dtpConfirmDate.Format = DateTimePickerFormat.Custom;

            dtpconfirmsaildate.CustomFormat = " ";
            dtpconfirmsaildate.Format = DateTimePickerFormat.Custom;

            dtpArriveDate.CustomFormat = " ";
            dtpArriveDate.Format = DateTimePickerFormat.Custom;
        }

        public void SetFishEx(FishEntity.ProductExEntity entity)
        {
            _entity = entity;
            if (_entity == null)
            {
                txtCompany.Text = string.Empty;
                txtCompany.Tag = string.Empty;
                //txtConfirmDate.Text = string.Empty;
                txtConfirmdollars.Text = string.Empty;
                txtconfirmlife.Text = string.Empty;
                txtConfirmrmb.Text = string.Empty;
                //txtconfirmsaildate.Text = string.Empty;
                txtLinkman.Text = string.Empty;
                txtLinkman.Tag = string.Empty;
                txtproductdate.Text = string.Empty;
                txtproductyear.Text = string.Empty;
                txtSgsQuantity.Text = string.Empty;
                txtSgsWeight.Text = string.Empty;

                dtpConfirmDate.CustomFormat = " ";
                dtpConfirmDate.Format = DateTimePickerFormat.Custom;

                dtpconfirmsaildate.CustomFormat = " ";
                dtpconfirmsaildate.Format = DateTimePickerFormat.Custom;

                txtArriveDate.Text = string.Empty;
                dtpArriveDate.CustomFormat = " ";
                dtpArriveDate.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                txtCompany.Text = _entity.confirmagent;
                txtCompany.Tag = _entity.confirmagentcode;
                //txtConfirmDate.Text = _entity.confirmdate;
                if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
                {
                    txtConfirmdollars.PasswordChar = '*';
                    txtConfirmrmb.PasswordChar = '*';
                }
                txtConfirmdollars.Text = _entity.confirmdollars.HasValue ? _entity.confirmdollars.Value.ToString("f2") : "0.00";
                txtConfirmrmb.Text = _entity.confirmrmb.HasValue ? _entity.confirmrmb.Value.ToString("f2") : "0.00";
                txtconfirmlife.Text = _entity.confirmlife;
                //txtconfirmsaildate.Text = _entity.confirmsaildate;
                txtLinkman.Text = _entity.confirmlinkman;
                txtLinkman.Tag = _entity.confirmlinkmancode;
                txtproductdate.Text = _entity.confirmproductdate;
                txtproductyear.Text = _entity.confirmproductyear;
                txtSgsQuantity.Text = _entity.confirmsgsquantity;
                txtSgsWeight.Text = _entity.confirmsgsweight.HasValue ? _entity.confirmsgsweight.Value.ToString("f2") : "0.00";

                if (string.IsNullOrEmpty(_entity.confirmdate.Trim()) == false)
                {
                    dtpConfirmDate.Format = DateTimePickerFormat.Custom;
                    dtpConfirmDate.CustomFormat = "yyyy.MM.dd";
                    dtpConfirmDate.Text = _entity.confirmdate;
                }
                else
                {
                    dtpConfirmDate.Format = DateTimePickerFormat.Custom;
                    dtpConfirmDate.CustomFormat = " ";
                }

                if (string.IsNullOrEmpty(_entity.confirmsaildate.Trim()) == false)
                {
                    dtpconfirmsaildate.Format = DateTimePickerFormat.Custom;
                    dtpconfirmsaildate.CustomFormat = "yyyy.MM.dd";
                    dtpconfirmsaildate.Text = _entity.confirmsaildate;
                }
                else
                {
                    dtpconfirmsaildate.CustomFormat = " ";
                    dtpconfirmsaildate.Format = DateTimePickerFormat.Custom;
                }

                txtArriveDate.Text = _entity.confirmarrivedate;

                if (string.IsNullOrEmpty(_entity.confirmarrivedate.Trim()) == false)
                {
                    dtpArriveDate.Format = DateTimePickerFormat.Custom;
                    dtpArriveDate.CustomFormat = "yyyy.MM.dd";
                    try
                    {
                        dtpArriveDate.Text = _entity.confirmarrivedate;
                    }
                    catch (Exception) { }
                }
                else
                {
                    dtpArriveDate.CustomFormat = " ";
                    dtpArriveDate.Format = DateTimePickerFormat.Custom;
                }
            }
        }

        public void GetFishEx(FishEntity.ProductExEntity entity)
        {
            entity.confirmagent = txtCompany.Text.Trim();
            entity.confirmagentcode = txtCompany.Tag == null ? string.Empty : txtCompany.Tag.ToString();
            //entity.confirmdate = txtConfirmDate.Text.Trim();
            entity.confirmdate = dtpConfirmDate.Text.Trim();

            decimal dollars = 0;
            decimal.TryParse ( txtConfirmdollars.Text , out dollars );
            entity.confirmdollars = dollars;
            entity.confirmlife = txtconfirmlife.Text.Trim();
            entity.confirmlinkman = txtLinkman.Text.Trim();
            entity.confirmlinkmancode = txtLinkman.Tag == null ? string.Empty : txtLinkman.Tag.ToString();
            entity.confirmproductdate = txtproductdate.Text.Trim();
            entity.confirmproductyear = txtproductyear.Text.Trim();
            decimal rmb =0;
            decimal.TryParse(txtConfirmrmb.Text , out rmb);
            entity.confirmrmb = rmb;
            //entity.confirmsaildate = txtconfirmsaildate.Text.Trim();
            entity.confirmsaildate = dtpconfirmsaildate.Text.Trim();
            int quantity=0;
            int.TryParse (txtSgsQuantity.Text , out quantity );
            entity.confirmsgsquantity = txtSgsQuantity.Text;
            decimal weight = 0;
            decimal.TryParse (txtSgsWeight.Text , out weight );
            entity.confirmsgsweight = weight;

            //entity.confirmarrivedate = txtArriveDate.Text.Trim();
            entity.confirmarrivedate = dtpArriveDate.Text.Trim();

        }
        public void Clear()
        {
            errorProvider1.Clear();
            txtCompany.Text = string.Empty;
            txtCompany.Tag = string.Empty;
            //txtConfirmDate.Text = string.Empty;
            txtConfirmdollars.Text = string.Empty;
            txtconfirmlife.Text = string.Empty;
            txtConfirmrmb.Text = string.Empty;
            //txtconfirmsaildate.Text = string.Empty;
            txtLinkman.Text = string.Empty;
            txtLinkman.Tag = string.Empty;
            txtproductdate.Text = string.Empty;
            txtproductyear.Text = string.Empty;
            txtSgsQuantity.Text = string.Empty;
            txtSgsWeight.Text = string.Empty;
            dtpConfirmDate.Format = DateTimePickerFormat.Custom;
            dtpConfirmDate.CustomFormat = " ";

            dtpconfirmsaildate.Format = DateTimePickerFormat.Custom;
            dtpconfirmsaildate.CustomFormat = " ";

            txtArriveDate.Text = string.Empty;
            dtpArriveDate.Format = DateTimePickerFormat.Custom;
            dtpArriveDate.CustomFormat = " ";

        }

        private void dtpConfirmDate_ValueChanged(object sender, EventArgs e)
        {
            dtpConfirmDate.CustomFormat = "yyyy.MM.dd";
            dtpConfirmDate.Format = DateTimePickerFormat.Custom;
        }

        private void dtpconfirmsaildate_ValueChanged(object sender, EventArgs e)
        {
            dtpconfirmsaildate.CustomFormat = "yyyy.MM.dd";
            dtpconfirmsaildate.Format = DateTimePickerFormat.Custom;
        }

        private void dtpArriveDate_ValueChanged(object sender, EventArgs e)
        {
            dtpArriveDate.CustomFormat = "yyyy.MM.dd";
            dtpArriveDate.Format = DateTimePickerFormat.Custom;
        }

        private void txtCompany_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtCompany.Text = form.SelectCompany.fullname;
            txtCompany.Tag = form.SelectCompany.code;

            txtLinkman.Text = string.Empty;
            txtLinkman.Tag = string.Empty;
        }

        public bool Check()
        {
            errorProvider1.Clear();
            bool isok = true;
            //FishInfoControl info = new FishInfoControl();//|| string.IsNullOrEmpty(info.CheQuotation.Checked.ToString().Trim())==true
            //if (info.CheQuotation.Checked != false)
            //{
            //    if (txtSgsWeight.Text==null || txtSgsWeight.Text.ToString()=="")
            //    {
            //        errorProvider1.SetError(txtSgsWeight, "请填写SGS重量");
            //        isok = false;
            //    }
            //}
            return isok;
        }

        private void txtLinkman_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCompany.Text) == true)
            {
                MessageBox.Show("请先选择开证代理商,再操作。");
                return;
            }
            if (txtCompany.Tag == null) return;
            string companycode = string.Empty;
            companycode = txtCompany.Tag.ToString();
            UIForms.FormSelectCustomer form = new UIForms.FormSelectCustomer(companycode);
            form.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = form.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                FishEntity.CustomerEntity customer = form.SelectedCustomer;
                if (customer != null)
                {
                    txtLinkman.Text = customer.name;
                    txtLinkman.Tag = customer.code;
                }
            }
        }       
    }
}
