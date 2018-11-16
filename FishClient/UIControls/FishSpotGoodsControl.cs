using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FishClient.UIControls
{
    public partial class FishSpotGoodsControl : UILibrary.TCBaseControl
    {
        protected FishEntity.ProductExEntity _entity = null;

        public FishSpotGoodsControl()
        {
            InitializeComponent();

            dtpdate.CustomFormat = " ";
            dtpdate.Format = DateTimePickerFormat.Custom;

            dtpstoragedate.CustomFormat = " ";
            dtpstoragedate.Format = DateTimePickerFormat.Custom;
        }
        public void SetFishEx(FishEntity.ProductExEntity entity)
        {
            _entity = entity;
            if (_entity == null)
            {
                txtcompany.Text = string.Empty;
                txtcompany.Tag = string.Empty;
                //txtdate.Text = string.Empty;
                txtdollars.Text = string.Empty;
                txtlife.Text = string.Empty;
                txtlinkman.Text = string.Empty;
                txtlinkman.Tag = string.Empty;
                txtproductdate.Text = string.Empty;
                txtproductyear.Text = string.Empty;
                txtquantity.Text = string.Empty;
                txtrmb.Text = string.Empty;
                //txtstoragedate.Text = string.Empty;
                txtweight.Text = string.Empty;

                dtpdate.CustomFormat = " ";
                dtpdate.Format = DateTimePickerFormat.Custom;
                dtpstoragedate.CustomFormat = " ";
                dtpstoragedate.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                txtcompany.Text = _entity.spotagent;
                txtcompany.Tag = _entity.spotagentcode;
                //txtdate.Text = _entity.spotdate;
                if( false == string.IsNullOrEmpty ( _entity.spotdate .Trim ()))
                {
                    dtpdate.CustomFormat ="yyyy.MM.dd";
                    dtpdate.Format=  DateTimePickerFormat.Custom;
                    try
                    {
                        dtpdate.Text = _entity.spotdate;
                    }
                    catch { }
                }else
                {
                    dtpdate.CustomFormat=" ";
                    dtpdate.Format = DateTimePickerFormat.Custom;
                }

                txtdollars.Text = _entity.spotdollars.HasValue ? _entity.spotdollars.Value.ToString("f2"):"0.00";
                txtlife.Text = _entity.spotlife;
                txtlinkman.Text = _entity.spotlinkman;
                txtlinkman.Tag = _entity.spotlinkmancode;
                txtproductdate.Text = _entity.spotproductdate;
                txtproductyear.Text = _entity.spotproductyear;
                txtquantity.Text = _entity.spotquantity.HasValue ? _entity.spotquantity.Value.ToString():"0";
                txtrmb.Text = _entity.spotrmb.HasValue? _entity.spotrmb.Value.ToString("f2"):"0.00";
                //txtstoragedate.Text = _entity.spotstoragedate;
                if( false == string.IsNullOrEmpty ( _entity.spotstoragedate .Trim ())){
                    dtpstoragedate.CustomFormat ="yyyy.MM.dd";
                    dtpstoragedate.Format=  DateTimePickerFormat.Custom;
                    try
                    {
                        dtpstoragedate.Text = _entity.spotstoragedate;
                    }
                    catch { }
                }else
                {
                    dtpstoragedate.CustomFormat=" ";
                    dtpstoragedate.Format = DateTimePickerFormat.Custom;
                }

                txtweight.Text = _entity.spotweight.HasValue ? _entity.spotweight.Value.ToString("f2"):"0.00";
            }

        }
        public void GetFishEx(FishEntity.ProductExEntity entity)
        {
            entity.spotagent = txtcompany.Text.Trim();
            entity.spotagentcode = txtcompany.Tag == null ? string.Empty : txtcompany.Tag.ToString();
            //entity.spotdate = txtdate.Text.Trim();
            entity.spotdate = dtpdate.Text.Trim();
            decimal dollars = 0;
            decimal.TryParse (txtdollars.Text,out dollars );
            entity.spotdollars = dollars;
            entity.spotlife = txtlife.Text.Trim();
            entity.spotlinkman = txtlinkman.Text.Trim();
            entity.spotlinkmancode = txtlinkman.Tag == null ? string.Empty : txtlinkman.Tag.ToString();
            entity.spotproductdate = txtproductdate.Text.Trim();
            entity.spotproductyear = txtproductyear.Text.Trim();
            int quantity=0;
            int.TryParse (txtquantity.Text , out quantity );
            entity.spotquantity = quantity;
            decimal rmb =0;
            decimal.TryParse(txtrmb.Text ,out rmb );
            entity.spotrmb = rmb;
            //entity.spotstoragedate = txtstoragedate.Text.Trim();
            entity.spotstoragedate = dtpstoragedate.Text.Trim();
            decimal weight=0;
            decimal.TryParse (txtweight.Text , out weight );
            entity.spotweight = weight;
                
        }
        public void Clear()
        {
            txtcompany.Text = string.Empty;
            txtcompany.Tag = string.Empty;
            //txtdate.Text = string.Empty;
            dtpdate.CustomFormat = " ";
            dtpdate.Format = DateTimePickerFormat.Custom;
            txtdollars.Text = string.Empty;
            txtlife.Text = string.Empty;
            txtlinkman.Text = string.Empty;
            txtlinkman.Tag = string.Empty;
            txtproductdate.Text = string.Empty;
            txtproductyear.Text = string.Empty;
            txtquantity.Text = string.Empty;
            txtrmb.Text = string.Empty;
            //txtstoragedate.Text = string.Empty;
            dtpstoragedate.CustomFormat = " ";
            dtpstoragedate.Format = DateTimePickerFormat.Custom;
            txtweight.Text = string.Empty;
        }

        private void dtpdate_ValueChanged(object sender, EventArgs e)
        {
            dtpdate.CustomFormat = "yyyy.MM.dd";
            dtpdate.Format = DateTimePickerFormat.Custom;
        }

        private void dtpstoragedate_ValueChanged(object sender, EventArgs e)
        {
            dtpstoragedate.CustomFormat = "yyyy.MM.dd";
            dtpstoragedate.Format = DateTimePickerFormat.Custom;
        }

        private void txtcompany_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtcompany.Text = form.SelectCompany.fullname;
            txtcompany.Tag = form.SelectCompany.code;

            txtlinkman.Text = string.Empty;
            txtlinkman.Tag = string.Empty;
        }

        private void txtlinkman_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcompany.Text) == true)
            {
                MessageBox.Show("请先选择报关货代商,再操作。");
                return;
            }
            if (txtcompany.Tag == null) return;
            string companycode = string.Empty;
            companycode = txtcompany.Tag.ToString();
            UIForms.FormSelectCustomer form = new UIForms.FormSelectCustomer(companycode);
            form.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = form.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                FishEntity.CustomerEntity customer = form.SelectedCustomer;
                if (customer != null)
                {
                    txtlinkman.Text = customer.name;
                    txtlinkman.Tag = customer.code;
                }
            }
        }
    }
}
