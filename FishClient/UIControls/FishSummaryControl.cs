

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FishClient.UIControls
{
    public partial class FishSummaryControl : UILibrary.TCBaseControl
    {
        public FishSummaryControl()
        {
            InitializeComponent();
        }

        public void GetFish( FishEntity.ProductEntity entity )
        {
            decimal temp1 = 0;
            decimal.TryParse ( txtweight.Text , out temp1 );
            entity.weight = temp1;

            int temp2=0;
            int .TryParse ( txtquantity.Text , out temp2 );
            entity.quantity = temp2;

            decimal.TryParse(txtremainweight.Text, out temp1);
            entity.remainweight = temp1;

            int.TryParse(txtremainquantity.Text, out temp2);
            entity.remainquantity = temp2;

            decimal.TryParse(txthomemadeweight.Text, out temp1);
            entity.homemadeweight = temp1;

            decimal.TryParse(txthomemadecost.Text, out temp1);
            entity.homemadecost = temp1;

            int.TryParse(txthomemadepackages.Text, out temp2);
            entity.homemadepackages = temp2;

            decimal.TryParse(txthomemadeunitprice.Text, out temp1);
            entity.homemadeunitprice = temp1;

            decimal.TryParse(txtprice.Text, out temp1);
            entity.price = temp1;

            
            entity.arriveportdate = txtarriveportdate.Text;

            entity.sailingschedule = txtsailingschedule.Text;

            if (string.IsNullOrEmpty(txtownershort.Text) == false)
            {
                entity.ownerCode = txtownershort.Tag.ToString();
                entity.ownershortname = txtownershort.Text;
                entity.ownername = txtowner.Text;
            }
            else
            {
                entity.ownername = string.Empty;
                entity.ownerCode = string.Empty;
                entity.ownershortname = string.Empty;
            }

            //entity.billofgoods = txtbillofgoods.Text;

            entity.agentifcompany = txtagentifcompany.Text;
            entity.customsofcompany = txtcustomsofcompany.Text;
        }

        public void SetFish(FishEntity.ProductEntity entity)
        {
            txtweight.Text = entity.weight.ToString();
            txtremainweight.Text = entity.remainweight.ToString();
            txtquantity.Text = entity.quantity.ToString();
            txtremainquantity.Text = entity.remainquantity.ToString();

            txthomemadecost.Text = entity.homemadecost.ToString();
            txthomemadepackages.Text = entity.homemadepackages.ToString();
            //自制仓单价= 自制仓成本/自制仓重量
            decimal unitprice = entity.homemadeweight.Value == 0 ? 0: entity.homemadecost.Value / entity.homemadeweight.Value;
            txthomemadeunitprice.Text = unitprice.ToString("f2"); // entity.homemadeunitprice.ToString();
            txthomemadeweight.Text = entity.homemadeweight.ToString();

            txtarriveportdate.Text = entity.arriveportdate;
            //txtbillofgoods.Text = entity.billofgoods;
            txtcustomsofcompany.Text = entity.customsofcompany;
            txtagentifcompany.Text = entity.agentifcompany;
            txtowner.Text = entity.ownername;
            txtownershort.Text = entity.ownershortname;
            txtownershort.Tag = entity.ownerCode;

            txtprice.Text = entity.price.ToString();
            txtsailingschedule.Text = entity.sailingschedule;            
        }

        private void txtownershort_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtownershort.Tag = form.SelectCompany.code;
            txtownershort.Text = form.SelectCompany.shortname;
            txtowner.Text = form.SelectCompany.fullname;
        }

        public void Clear()
        {
           
            txtagentifcompany.Text = string.Empty;
            txtarriveportdate.Text = string.Empty;
            txtbillofgoods.Text = string.Empty;
            txtcustomsofcompany.Text = string.Empty;
            txthomemadecost.Text = string.Empty;
            txthomemadepackages.Text = string.Empty;
            txthomemadeunitprice.Text = string.Empty;
            txthomemadeweight.Text = string.Empty;
            txtowner.Text = string.Empty;
            txtownershort.Text = string.Empty;
            txtownershort.Tag = string.Empty;
            txtprice.Text = string.Empty;
            txtquantity.Text = string.Empty;
            txtremainquantity.Text = string.Empty;
            txtremainweight.Text = string.Empty;
            txtsailingschedule.Text = string.Empty;
            txtweight.Text = string.Empty;
        }
    }
}
