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
    public partial class FishInfoControl : UILibrary.TCBaseControl
    {
        //FishEntity.CompanyEntity enti= null;
        public FishInfoControl()
        {
            InitializeComponent();
            BindData();
        }

        protected void BindData()
        {
            try
            {
                if (this.DesignMode) return;

                //InitDataUtil.BindComboBoxData(cmbBand, FishEntity.Constant.Brand, true);
                cmbCountry.SelectedValueChanged -= cmbCountry_SelectedValueChanged;
                InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CountryType, true);
                cmbCountry.SelectedValueChanged += cmbCountry_SelectedValueChanged;
                BindCountryBrandData();
                
                InitDataUtil.BindComboBoxData(cmbPort, FishEntity.Constant.port,true);
                InitDataUtil.BindComboBoxData(cmbFishType, FishEntity.Constant.FishClass, true);
                InitDataUtil.BindComboBoxData(cmborigin, FishEntity.Constant.Origin, true);
                InitDataUtil.BindComboBoxData(cmbquality, FishEntity.Constant.GoodsEvaluation, true);
                InitDataUtil.BindComboBoxData(cmbTechClass, FishEntity.Constant.TechClass, true);
                InitDataUtil.BindComboBoxData(cmbpack, FishEntity.Constant.packk, true);
                InitDataUtil.BindComboBoxData(cmbName, FishEntity.Constant.Goods, true);
                InitDataUtil.BindComboBoxData(cmbSpecification, FishEntity.Constant.Specification, true);
                InitDataUtil.BindComboBoxData(cmbmanufacturers, FishEntity.Constant.Manufacturers, true);
                InitDataUtil.BindComboBoxData(cmbgoodsinfo, FishEntity.Constant.GoodsInfo, true);

                CheQuotation.Tag = FishEntity.Variable.StateList;
                CheFirm.Tag = FishEntity.Variable.StateList;
                Checommodity.Tag = FishEntity.Variable.StateList;
                CheCautotrophy.Tag = FishEntity.Variable.StateList;
                CheRestraint.Tag = FishEntity.Variable.StateList;
                CheArticles.Tag = FishEntity.Variable.StateList;
                //CheQuotation.Name = "name";
                //CheQuotation.Text = "code";

                cmbvalidate.Text = "有效";
                cmbvalidate1.Text = "有效";
                cmbvalidate2.Text = "有效";
                cmbvalidate3.Text = "有效";
                cmbvalidate4.Text = "有效";
                cmbvalidate5.Text = "有效";

            }
            catch { }
        }

        public void GetFish(FishEntity.ProductEntity entity)//添加
        {
            entity.code = txtCode.Text;
            entity.createman = txtsalesman.Text;
            //enti.createman = txtsalesman.Text;
            entity.name = cmbName.SelectedValue==null?string.Empty : cmbName.SelectedValue.ToString();
            if (cmbBand.SelectedValue != null)
            {
                entity.brand = cmbBand.SelectedValue.ToString();
            }
            else
            {
                entity.brand = string.Empty;
            }

            if (CheQuotation.Checked!= false)
            {
                entity.state = "1";//CheQuotation.Text.ToString();
            }
            else
            {
                entity.state = string.Empty;
            }

            if (CheFirm.Checked != false)
            {
                entity.State1 = "2";// CheFirm .Text.ToString();
            }
            else
            {
                entity.State1 = string.Empty;
            }

            if (Checommodity.Checked != false)
            {
                entity.State2 = "3";//Checommodity.Text.ToString();
            }
            else
            {
                entity.State2 = string.Empty;
            }

            if (CheCautotrophy.Checked != false)
            {
                entity.State3 = "4";//CheCautotrophy.Text.ToString();
            }
            else
            {
                entity.State3 = string.Empty;
            }

            if (CheRestraint.Checked != false)
            {
                entity.State4 = "5";//CheRestraint.Text.ToString();
            }
            else
            {
                entity.State4 = string.Empty;
            }

            if (CheArticles.Checked != false)
            {
                entity.State5 = "6";//CheArticles.Text.ToString();
            }
            else
            {
                entity.State5 = string.Empty;
            }
            entity.nature = cmbCountry.SelectedValue.ToString();

            entity.origin = cmborigin.SelectedValue.ToString();

            entity.type = cmbFishType.SelectedValue==null ? string.Empty:cmbFishType.SelectedValue.ToString();
            entity.port = cmbPort.SelectedValue == null ? string.Empty : cmbPort.SelectedValue.ToString();
            entity.Pack = cmbpack.SelectedValue.ToString();
            entity.getinfotime = dtpgetinfotime.Value;
            entity.endinfotime = dtpendinfotime.Value;

            entity.techtype = cmbTechClass.SelectedValue.ToString();

            entity.specification = cmbSpecification.SelectedValue==null? string.Empty : cmbSpecification.SelectedValue.ToString();
            entity.productdate = txtproductdate.Text.Trim();
            entity.shelflife = (int)nudlife.Value;

            entity.quality = cmbquality.SelectedValue.ToString();
            entity.manufacturers = cmbmanufacturers.SelectedValue==null?string.Empty:cmbmanufacturers.SelectedValue.ToString();
            entity.factoryaddress = txtfactoryaddress.Text;
            entity.remark = txtremark.Text;

            entity.isdelete = cmbvalidate.Text.Equals("有效") ? 1 : 0;
            entity.Isdelete1 = cmbvalidate1.Text.Equals("有效") ? 1 : 0;
            entity.Isdelete2 = cmbvalidate2.Text.Equals("有效") ? 1 : 0;
            entity.Isdelete3 = cmbvalidate3.Text.Equals("有效") ? 1 : 0;
            entity.Isdelete4 = cmbvalidate4.Text.Equals("有效") ? 1 : 0;
            entity.Isdelete5 = cmbvalidate5.Text.Equals("有效") ? 1 : 0;
            entity.shipno = txtshipno.Text.Trim();
            entity.billofgoods = txtbillofgoods.Text.Trim();
            entity.warehouse = txtwarehouse.Text.Trim();
            entity.cornerno = txtcornerno.Text.Trim();
            decimal temp = 0;
            decimal.TryParse(txtrate.Text , out temp );
            entity.tariffrate = temp;

            entity.goodsinfo = cmbgoodsinfo.SelectedValue == null ? string.Empty : cmbgoodsinfo.SelectedValue.ToString();
        }

        public void SetFish(FishEntity.ProductEntity entity)
        {
            if (entity == null) return;
            txtsalesman.Text = entity.createman;
            txtCode.Text = entity.code;
            txtfactoryaddress.Text = entity.factoryaddress;
            cmbmanufacturers.SelectedValue = entity.manufacturers;
            cmbName.SelectedValue = entity.name;
            cmborigin.SelectedValue = entity.origin;
            cmbquality.SelectedValue = entity.quality;
            txtremark.Text = entity.remark;
            cmbSpecification.SelectedValue = entity.specification;
            cmbCountry.SelectedValue = entity.nature;
            cmbBand.SelectedValue = entity.brand;
            cmbFishType.SelectedValue = entity.type;
            cmbPort.SelectedValue = entity.port;
            cmbpack.SelectedValue = entity.Pack;
            if (entity == null) return;
            if (entity.state != "" && entity.state.ToString()=="1") { CheQuotation.Checked = true; } else { CheQuotation.Checked = false; };
            if (entity.State1 != "" && entity.State1.ToString() == "2") { CheFirm.Checked = true; } else { CheFirm.Checked = false; };
            if (entity.State2 != "" && entity.State2.ToString() == "3") { Checommodity.Checked = true; } else { Checommodity.Checked = false; };
            if (entity.State3 != "" && entity.State3.ToString() == "4") { CheCautotrophy.Checked = true; } else { CheCautotrophy.Checked = false; };
            if (entity.State4 != "" && entity.State4.ToString() == "5") { CheRestraint.Checked = true; } else { CheRestraint.Checked = false; };
            if (entity.State5 != "" && entity.State5.ToString() == "7") { CheArticles.Checked = true; } else { CheArticles.Checked = false; };
            cmbTechClass.SelectedValue = entity.techtype;
            if (entity.getinfotime != null)
            {
                dtpgetinfotime.Value = entity.getinfotime.Value;
            }
            if (entity.endinfotime != null)
            {
                dtpendinfotime.Value = entity.endinfotime.Value;
            }
            if (entity.productdate != null)
            {
               txtproductdate.Text  = entity.productdate;
            }
            if (entity.shelflife != null)
            {
                nudlife.Value = entity.shelflife;
            }

            txtshipno.Text = entity.shipno;
            txtbillofgoods.Text = entity.billofgoods;
            txtcornerno.Text = entity.cornerno;
            txtwarehouse.Text = entity.warehouse;
            txtrate.Text = entity.tariffrate.Value.ToString("f4");
            cmbvalidate.Text = entity.isdelete == 1? "有效":"无效";
            cmbvalidate1.Text = entity.Isdelete1 == 1 ? "有效" : "无效";
            cmbvalidate2.Text = entity.Isdelete2 == 1 ? "有效" : "无效";
            cmbvalidate3.Text = entity.Isdelete3 == 1 ? "有效" : "无效";
            cmbvalidate4.Text = entity.Isdelete4 == 1 ? "有效" : "无效";
            cmbvalidate5.Text = entity.Isdelete5 == 1 ? "有效" : "无效";
            cmbgoodsinfo.SelectedValue = entity.goodsinfo;
        }

        public void Clear()
        {
            errorProvider1.Clear();

            txtCode.Text = string.Empty;
            txtsalesman.Text = string.Empty;
            txtfactoryaddress.Text = string.Empty;
            cmbmanufacturers.SelectedValue = string.Empty;
            cmbName.SelectedValue = string.Empty;
            txtremark.Text = string.Empty;
            cmbSpecification.SelectedValue = string.Empty;
            cmbBand.DataSource = null;
            cmbBand.SelectedValue = string.Empty;
            cmbCountry.SelectedValue = string.Empty;
            cmbFishType.SelectedValue = string.Empty;
            cmbPort.SelectedValue = string.Empty;
            cmbpack.SelectedValue = string.Empty;
            cmborigin.SelectedValue = string.Empty;
            cmbquality.SelectedValue = string.Empty;
            //if (CheQuotation.Checked) { CheQuotation.Text = "1"; } else { CheQuotation.Text = null; }
            //if (CheFirm.Checked) { CheFirm.Text = "2"; } else { CheFirm.Text = null; }
            //if (Checommodity.Checked) { Checommodity.Text = "3"; } else { Checommodity.Text = null; }
            //if (CheCautotrophy.Checked) { CheCautotrophy.Text = "4"; } else { CheCautotrophy.Text = null; }
            //if (CheRestraint.Checked) { CheRestraint.Text = "5"; } else { CheRestraint.Text = null; }
            //if (CheArticles.Checked) { CheArticles.Text = "7"; } else { CheArticles.Text = null; }
            //CheQuotation.Checked = false;
            //CheFirm.Checked = false;
            //Checommodity.Checked = false;
            //CheCautotrophy.Checked = false;
            //CheRestraint.Checked = false;
            //CheArticles.Checked = false;
            cmbTechClass.SelectedValue = string.Empty;
            dtpendinfotime.Value = DateTime.Now;
            dtpgetinfotime.Value = DateTime.Now;
            txtproductdate.Text = string.Empty;
            nudlife.Value = 0;

            txtshipno.Text = string.Empty;
            txtbillofgoods.Text = string.Empty;
            txtwarehouse.Text = string.Empty;
            txtrate.Text = string.Empty;
            txtcornerno.Text = string.Empty;
            
            cmbvalidate.Text = "有效";
            cmbvalidate1.Text = "有效";
            cmbvalidate2.Text = "有效";
            cmbvalidate3.Text = "有效";
            cmbvalidate4.Text = "有效";
            cmbvalidate5.Text = "有效";
            cmbgoodsinfo.SelectedValue = string.Empty;

        }

        public bool Check()
        {
            errorProvider1.Clear();
            bool isok = true;
            //bool iss = true;
            if ( cmbName.SelectedValue == null || string.IsNullOrEmpty(cmbName.SelectedValue.ToString()))
            {
                errorProvider1.SetError(cmbName, "请选择品名");
                isok = false;
            }
            if (cmbPort.SelectedValue == null || string.IsNullOrEmpty(cmbPort.SelectedValue.ToString()))
            {
                errorProvider1.SetError(cmbPort, "请选择港口");
                isok = false;
            }            
            if (cmbCountry.SelectedValue == null || string.IsNullOrEmpty(cmbCountry.SelectedValue.ToString()))
            {
                errorProvider1.SetError(cmbCountry, "请选择国别");
                isok = false;
            }
            //if (cmbBand.SelectedValue == null||string.IsNullOrEmpty(cmbBand.SelectedValue.ToString()))
            //{
            //    errorProvider1.SetError(cmbBand, "请选择品牌");
            //    isok = false;
            //}
            if (cmbSpecification.SelectedValue==null||string.IsNullOrEmpty(cmbSpecification.SelectedValue.ToString()))
            {
                errorProvider1.SetError(cmbSpecification, "请选择品质");
                isok = false;
            }
            //if (CheQuotation.Checked == false || string.IsNullOrEmpty(CheQuotation.Checked.ToString().Trim()))
            //{
            //    errorProvider1.SetError(CheQuotation, "请选择报盘");
            //    isok = false;
            //}

            return isok;
        }
        void cmbCountry_SelectedValueChanged(object sender, EventArgs e)
        {
            BindCountryBrandData();
        }


        private void BindCountryBrandData()
        {
            //cmbBand.DataSource = null;
            if (cmbCountry.SelectedValue == null) return;
            string pcode = cmbCountry.SelectedValue.ToString();
            FishEntity.DictEntity pModel = InitDataUtil.DictList.Find((i) => { return i.code == pcode && i.pcode.Equals(FishEntity.Constant.CountryType); });
            int pid = 0;
            if (pModel != null)
            {
                pid = pModel.id;
            }


            List<FishEntity.DictEntity> list = InitDataUtil.DictList.FindAll((i) => { return i.pid == pid && i.pcode.Equals(FishEntity.Constant.Brand); });
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

            cmbBand.DisplayMember = "name";
            cmbBand.ValueMember = "code";
            cmbBand.DataSource = list;
        }

        private void FishInfoControl_Load(object sender, EventArgs e)
        {

        }

        private void CheQuotation_Click(object sender, EventArgs e)
        {
         //   string CheQuota = null;
            //MessageBox.Show(CheQuota);
           // if (CheFirm.Checked)
          //  {
               // MessageBox.Show(CheFirm.Text.ToString());
          //  }
          //  else
         //   {
               // MessageBox.Show(null);
          //  }
        }

        private void CheQuotation_CheckedChanged(object sender, EventArgs e)
        {

        }
        //private void cmbCountry_TextChanged(object sender, EventArgs e)
        //{
        //    switch (cmbCountry.SelectedValue.ToString())
        //    {
        //        case "": select* from t_dict where pid = (select id from t_dict where code = '秘鲁') break;
        //        default:
        //            break;
        //    }
        //}
    }
}
