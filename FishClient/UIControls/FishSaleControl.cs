using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FishClient.UIControls
{
    public partial class FishSaleControl : UILibrary.TCBaseControl
    {
        protected FishEntity.ProductExEntity _entity = null;

        public FishSaleControl()
        {
            InitializeComponent();

            LoadImage();
        }

        private void LoadImage()
        {
            btnQuery.DrawType = UILibrary.DrawStyle.Img;


            string imagePath = Application.StartupPath + "\\Images\\blue_button_normal.png";
            if (File.Exists(imagePath))
            {
                btnQuery.NormlBack = Image.FromFile(imagePath);
            }
            string downPath = Application.StartupPath + "\\Images\\blue_button_down.png";
            if (File.Exists(downPath))
            {
                btnQuery.DownBack = Image.FromFile(downPath);
            }
            string hoverPath = Application.StartupPath + "\\Images\\blue_button_hover.png";
            if (File.Exists(hoverPath))
            {
                btnQuery.MouseBack = Image.FromFile(hoverPath);
            }
        }


        public void SetFishEx(FishEntity.ProductExEntity entity)
        {
            _entity = entity;
            if (_entity == null)
            {
                txtSaleCompany.Text = string.Empty;
                txtSaleCompany.Tag = string.Empty;
                txtSaleDate.Text = string.Empty;
                txtSaleDollars.Text = string.Empty;
                txtSaleLinkman.Text = string.Empty;
                txtSaleOutDate.Text = string.Empty;
                txtSaleQuantity.Text = string.Empty;
                txtSaleRmb.Text = string.Empty;
                txtSaleWeight.Text = string.Empty;

            }
            else
            {
                txtSaleCompany.Text = _entity.saletrader;
                txtSaleCompany.Tag = _entity.saletradercode;
                txtSaleDate.Text = _entity.selfdate;
                if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
                {
                    txtSaleDollars.PasswordChar = '*';
                    txtSaleRmb.PasswordChar = '*';
                }
                txtSaleDollars.Text = _entity.saledollars.HasValue ? _entity.saledollars.Value.ToString("f2") : "0.00";
                txtSaleLinkman.Text = _entity.salelinkman;
                txtSaleLinkman.Tag = _entity.salelinkmancode;
                txtSaleOutDate.Text = _entity.saleoutdate;
                txtSaleQuantity.Text = _entity.saleremainquantity.HasValue ? _entity.saleremainquantity.Value.ToString() : "0";
                txtSaleRmb.Text = _entity.salermb.HasValue ? _entity.salermb.Value.ToString("f2") : "0.00";
                txtSaleWeight.Text = _entity.saleremainweight.HasValue ? _entity.saleremainweight.Value.ToString("f2") : "0.00";
            }
        }

        public void GetFishEx(FishEntity.ProductExEntity entity)
        {
            entity.saledate = txtSaleDate.Text.Trim();
            decimal dollars = 0;
            decimal.TryParse(txtSaleDollars.Text, out dollars);
            entity.saledollars = dollars;
            entity.salelinkman = txtSaleLinkman.Text.Trim();
            entity.salelinkmancode = txtSaleLinkman.Tag == null ? string.Empty : txtSaleLinkman.Tag.ToString();
            entity.saleoutdate = txtSaleOutDate.Text.Trim();
            int quantity = 0;
            int.TryParse(txtSaleQuantity.Text, out quantity);
            entity.saleremainquantity = quantity;
            decimal weight = 0;
            decimal.TryParse(txtSaleWeight.Text, out weight);
            entity.saleremainweight = weight;
            decimal rmb = 0;
            decimal.TryParse(txtSaleRmb.Text, out rmb);
            entity.salermb = rmb;
            entity.saletrader = txtSaleCompany.Text.Trim();
            entity.saletradercode = txtSaleCompany.Tag == null ? string.Empty : txtSaleCompany.Tag.ToString();

        }
        public void Clear()
        {
            txtSaleCompany.Text = string.Empty;
            txtSaleCompany.Tag = string.Empty;
            txtSaleDate.Text = string.Empty;
            txtSaleDollars.Text = string.Empty;
            txtSaleLinkman.Text = string.Empty;
            txtSaleOutDate.Text = string.Empty;
            txtSaleQuantity.Text = string.Empty;
            txtSaleRmb.Text = string.Empty;
            txtSaleWeight.Text = string.Empty;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (_entity == null) return;
            FormSpotDetail form = new FormSpotDetail(_entity.id);
            form.ShowInTaskbar = false;
            form.ShowMenu(false);
            form.Text = "现货价格货主查询";
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void txtSaleCompany_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtSaleCompany.Text = form.SelectCompany.fullname;
            txtSaleCompany.Tag = form.SelectCompany.code;

            txtSaleLinkman.Text = string.Empty;
            txtSaleLinkman.Tag = string.Empty;
        }

        private void txtSaleLinkman_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSaleCompany.Text) == true)
            {
                MessageBox.Show("请先选择现货货主,再操作。");
                return;
            }
            if (txtSaleCompany.Tag == null) return;
            string companycode = string.Empty;
            companycode = txtSaleCompany.Tag.ToString();
            UIForms.FormSelectCustomer form = new UIForms.FormSelectCustomer(companycode);
            form.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = form.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                FishEntity.CustomerEntity customer = form.SelectedCustomer;
                if (customer != null)
                {
                    txtSaleLinkman.Text = customer.name;
                    txtSaleLinkman.Tag = customer.code;
                }
            }
        }
    }
}
