using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.IO;
using System.Windows.Forms;
using FishEntity;
using System.Drawing.Design;
using FishClient.UIControls;

namespace FishClient.UIControls
{
    public partial class FishQuoteControl : UILibrary.TCBaseControl
    {
        protected FishEntity.ProductExEntity _entity = null;

        public FishQuoteControl()
        {
            InitializeComponent();

            LoadImage();

            dtpquotedate.CustomFormat = " ";
            dtpquotedate.Format = DateTimePickerFormat.Custom;

            dtpquotesaildatefast.CustomFormat = " ";
            dtpquotesaildatefast.Format = DateTimePickerFormat.Custom;

            dtpquotesaildatelate.CustomFormat = " ";
            dtpquotesaildatelate.Format = DateTimePickerFormat.Custom;
        }

        private void LoadImage()
        {
            btnquotequery.DrawType = UILibrary.DrawStyle.Img;


            string imagePath = Application.StartupPath + "\\Images\\blue_button_normal.png";
            if (File.Exists(imagePath))
            {
                btnquotequery.NormlBack = Image.FromFile(imagePath);
            }
            string downPath = Application.StartupPath + "\\Images\\blue_button_down.png";
            if (File.Exists(downPath))
            {
                btnquotequery.DownBack = Image.FromFile(downPath);
            }
            string hoverPath = Application.StartupPath + "\\Images\\blue_button_hover.png";
            if (File.Exists(hoverPath))
            {
                btnquotequery.MouseBack = Image.FromFile(hoverPath);
            }
        }

        public void SetFishEx(FishEntity.ProductExEntity entity)
        {
            _entity = entity;
            if (_entity == null)
            {
                txtquoteproductyear.Text = string.Empty;
                txtquotedate.Text = string.Empty;
                txtquotedollars.Text = string.Empty;
                txtquotelife.Text = string.Empty;
                txtquotelinkman.Text = string.Empty;
                txtquotelinkman.Tag = string.Empty;
                txtquoteproductdate.Text = string.Empty;
                txtquotequantity.Text = string.Empty;
                txtquotermb.Text = string.Empty;
                //txtquotesaildatefast.Text = string.Empty;
                //txtquotesaildatelate.Text = string.Empty;
                txtquotesuppliercode.Text = string.Empty;
                txtquotesuppliercode.Tag = string.Empty;
                txtquoteweight.Text = string.Empty;

                dtpquotedate.Text = string.Empty;
                dtpquotedate.CustomFormat = " ";
                dtpquotedate.Format = DateTimePickerFormat.Custom;

                dtpquotesaildatefast.Text = string.Empty;
                dtpquotesaildatefast.CustomFormat = " ";
                dtpquotesaildatefast.Format = DateTimePickerFormat.Custom;

                dtpquotesaildatelate.Text = string.Empty;
                dtpquotesaildatelate.CustomFormat = " ";
                dtpquotesaildatelate.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                txtquoteproductyear.Text = _entity.quoteproductyear;
                txtquotedate.Text = _entity.quotedate;
                txtquotedollars.Text = _entity.quotedollars.HasValue ? _entity.quotedollars.Value.ToString("f2") : "";
                txtquotelife.Text = _entity.quotelife;
                txtquotelinkman.Text = _entity.quotelinkman;
                txtquotelinkman.Tag = _entity.quotelinkmancode;
                txtquoteproductdate.Text = _entity.quoteproductdate;
                txtquotequantity.Text = _entity.quotequantity.HasValue ? _entity.quotequantity.Value.ToString() : "";
                txtquotermb.Text = _entity.quotermb.HasValue ? _entity.quotermb.Value.ToString("f2") : "";
                //txtquotesaildatefast.Text = _entity.quotesaildatefast;
                //txtquotesaildatelate.Text = _entity.quotesaildatelate;
                txtquotesuppliercode.Text = _entity.quotesupplier;
                txtquotesuppliercode.Tag = _entity.quotesuppliercode;
                txtquoteweight.Text = _entity.quoteweight.HasValue ? _entity.quoteweight.Value.ToString("f2") : "";

                if (string.IsNullOrEmpty(_entity.quotedate.Trim()) == false)
                {
                    try
                    {
                        dtpquotedate.CustomFormat = "yyyy.MM.dd";
                        dtpquotedate.Format = DateTimePickerFormat.Custom;
                        dtpquotedate.Text = _entity.quotedate;
                    }
                    catch (Exception ex) { }

                }
                else
                {
                    dtpquotedate.CustomFormat = " ";
                    dtpquotedate.Format = DateTimePickerFormat.Custom;
                }

                if (string.IsNullOrEmpty(_entity.quotesaildatefast.Trim()) == false)
                {
                    dtpquotesaildatefast.Format = DateTimePickerFormat.Custom;
                    dtpquotesaildatefast.CustomFormat = "yyyy.MM.dd";
                    try
                    {
                        dtpquotesaildatefast.Text = _entity.quotesaildatefast;
                    }
                    catch { }
                }
                else
                {
                    dtpquotesaildatefast.Text = string.Empty;
                    dtpquotesaildatefast.CustomFormat = " ";
                    dtpquotesaildatefast.Format = DateTimePickerFormat.Custom;
                }

                if (string.IsNullOrEmpty(_entity.quotesaildatelate.Trim()) == false)
                {
                    dtpquotesaildatelate.Format = DateTimePickerFormat.Custom;
                    dtpquotesaildatelate.CustomFormat = "yyyy.MM.dd";
                    try
                    {
                        dtpquotesaildatelate.Text = _entity.quotesaildatelate;
                    }
                    catch { }
                }
                else
                {
                    dtpquotesaildatelate.Text = string.Empty;
                    dtpquotesaildatelate.CustomFormat = " ";
                    dtpquotesaildatelate.Format = DateTimePickerFormat.Custom;
                }

            }
        }

        public void GetFishEx(FishEntity.ProductExEntity entity)
        {
            //entity.quotedate = txtquotedate.Text.Trim();
            if (dtpquotedate.Text !=""&& dtpquotedate.Text!=null)
            {
                entity.quotedate = dtpquotedate.Text.ToString();
            }

            decimal dollars= 0;
            decimal.TryParse( txtquotedollars.Text ,out dollars );
            entity.quotedollars = dollars;
            entity.quotelife = txtquotelife.Text.Trim();
            entity.quotelinkman = txtquotelinkman.Text.Trim();
            entity.quotelinkmancode = txtquotelinkman.Tag == null ? string.Empty : txtquotelinkman.Tag.ToString();
            entity.quoteproductdate = txtquoteproductdate.Text.Trim();
            entity.quoteproductyear = txtquoteproductyear.Text.Trim();
            int quantity=0;
            int.TryParse ( txtquotequantity.Text,out quantity );
            entity.quotequantity = quantity;
            decimal rmb=0;
            decimal.TryParse ( txtquotermb.Text , out rmb);
            entity.quotermb = rmb;
            //entity.quotesaildatefast = txtquotesaildatefast.Text.Trim();
            entity.quotesaildatefast = dtpquotesaildatefast.Text.Trim();
            //entity.quotesaildatelate = txtquotesaildatelate.Text.Trim();
            entity.quotesaildatelate = dtpquotesaildatelate.Text.Trim();
            entity.quotesupplier = txtquotesuppliercode.Text.Trim();
            entity.quotesuppliercode = txtquotesuppliercode.Tag == null ? string.Empty : txtquotesuppliercode.Tag.ToString();
            decimal  weight = 0;
            decimal.TryParse(txtquoteweight.Text, out weight);
            entity.quoteweight = weight;
        }
        public void Clear()
        {
            errorProvider1.Clear();

            txtquoteproductyear.Text = string.Empty;
            txtquotedate.Text = string.Empty;
            txtquotedollars.Text = string.Empty;
            txtquotelife.Text = string.Empty;
            txtquotelinkman.Text = string.Empty;
            txtquotelinkman.Tag = string.Empty;
            txtquoteproductdate.Text = string.Empty;
            txtquotequantity.Text = string.Empty;
            txtquotermb.Text = string.Empty;
            //txtquotesaildatefast.Text = string.Empty;
            //txtquotesaildatelate.Text = string.Empty;
            txtquotesuppliercode.Text = string.Empty;
            txtquotesuppliercode.Tag = string.Empty;
            txtquoteweight.Text = string.Empty;

            dtpquotedate.Format = DateTimePickerFormat.Custom;
            dtpquotedate.CustomFormat = " ";
            //dtpquotedate.Text = string.Empty;

            dtpquotesaildatefast.Format = DateTimePickerFormat.Custom;
            dtpquotesaildatefast.CustomFormat = " ";

            dtpquotesaildatelate.Format = DateTimePickerFormat.Custom;
            dtpquotesaildatelate.CustomFormat = " ";                
        }

        private void txtquotesuppliercode_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtquotesuppliercode.Text = form.SelectCompany.fullname;
            txtquotesuppliercode.Tag = form.SelectCompany.code;

            txtquotelinkman.Text = string.Empty;
            txtquotelinkman.Tag = string.Empty;
        }

        private void txtquotelinkman_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtquotesuppliercode.Text) == true)
            {
                MessageBox.Show("请先选择供应商,再操作。");
                return;
            }
            if (txtquotesuppliercode.Tag == null) return;
            string  companycode = string.Empty ;
            companycode = txtquotesuppliercode.Tag.ToString();
            UIForms.FormSelectCustomer form = new UIForms.FormSelectCustomer(companycode );
            form.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = form.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                FishEntity.CustomerEntity customer = form.SelectedCustomer;
                if (customer != null)
                {
                    txtquotelinkman.Text = customer.name;
                    txtquotelinkman.Tag = customer.code;
                }
            }
        }

        private void btnquotequery_Click(object sender, EventArgs e)
        {
            if (_entity == null) return;
            FormQuoteDetail form = new FormQuoteDetail(_entity.id);
            form.ShowMenu(false);
            form.Text = "报盘价格查询";
            form.ShowInTaskbar = false;
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void dtpquotedate_ValueChanged(object sender, EventArgs e)
        {
                dtpquotedate.CustomFormat = "yyyy.MM.dd";
                dtpquotedate.Format = DateTimePickerFormat.Custom;            
        }

        private void dtpquotesaildatefast_ValueChanged(object sender, EventArgs e)
        {
            dtpquotesaildatefast.CustomFormat = "yyyy.MM.dd";
            dtpquotesaildatefast.Format = DateTimePickerFormat.Custom;      
        }

        private void dtpquotesaildatelate_ValueChanged(object sender, EventArgs e)
        {
            dtpquotesaildatelate.CustomFormat = "yyyy.MM.dd";
            dtpquotesaildatelate.Format = DateTimePickerFormat.Custom;     
        }
        public bool Check()
        {
            errorProvider1.Clear();
            bool isok = true;
            //if (txtquoteweight.Text == null || txtquoteweight.Text.ToString()=="")
            //{
            //    errorProvider1.SetError(txtquoteweight, "请填写报盘重量");
            //    isok = false;
            //}
            //if (txtquotequantity.Text==null || txtquotequantity.Text.ToString()=="")
            //{
            //    errorProvider1.SetError(txtquotequantity, "请填写剩余重量");
            //    isok = false;
            //}
            //if (txtquotedollars.Text==null|| txtquotedollars.Text.ToString()=="")
            //{
            //    errorProvider1.SetError(txtquotedollars, "请填写美元价格");
            //    isok = false;
            //}
            //if (txtquotermb.Text==null|| txtquotermb.Text.ToString()=="")
            //{
            //    errorProvider1.SetError(txtquotermb, "请填写人民币价格");
            //    isok = false;
            //}
            //if (txtquotesuppliercode.Text==null|| txtquotesuppliercode.Text.ToString()=="")
            //{
            //    errorProvider1.SetError(txtquotesuppliercode, "请填写报盘供应商");
            //    isok = false;
            //}
            //if (txtquotelinkman.Text==null|| txtquotelinkman.Text.ToString()=="")
            //{
            //    errorProvider1.SetError(txtquotelinkman, "请填写报盘联系人");
            //    isok = false;
            //}
            //if (txtquotelife.Text==null|| txtquotelife.Text.ToString()=="")
            //{
            //    errorProvider1.SetError(txtquotelife,"请填写报盘保质期");
            //    isok = false;
            //}
            //if (dtpquotesaildatefast.Value==null|| dtpquotesaildatefast.Text.ToString()=="")
            //{
            //    errorProvider1.SetError(dtpquotesaildatefast,"请填写最快报盘船期");
            //    isok = false;
            //}
            //if (dtpquotesaildatelate.Text==null|| dtpquotesaildatelate.Text.ToString()=="")
            //{
            //    errorProvider1.SetError(dtpquotesaildatelate, "请填写最晚报盘船期");
            //    isok = false;
            //}
            return isok;
        }
    }
}
