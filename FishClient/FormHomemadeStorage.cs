using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    /// <summary>
    /// 自制仓入库
    /// </summary>
    public partial class FormHomemadeStorage : FormMenuBase
    {
        protected FishBll.Bll.HomemadeStorageBll _bll = new FishBll.Bll.HomemadeStorageBll();
        protected FishBll.Bll.ProductBll _bl = new FishBll.Bll.ProductBll();
        protected FishEntity.HomemadeStorageEntity _entity = null;
        protected FishEntity.ProductEntity _en = null;
        protected string _where = string.Empty;

        public FormHomemadeStorage()
        {
            InitializeComponent();

            this.Text = "自制仓入库";
            this.panel1.Enabled = false;
            //tmiExport.Visible = false;
            //tmiSave.Visible = false;
            //tmiCancel.Visible = false;
        }

        public override void Next()
        {
            QueryOne(">", " order by id asc limit 1");
        }

        public override void Previous()
        {
            QueryOne("<", " order by id desc limit 1");
        }

        public override int Query()
        {
            //TODO

            QueryOne(">", " order by id asc limit 1");
            return 1;
        }

        protected void QueryOne(string operate, string orderBy)
        {
            string whereEx = string.Empty;
            if (string.IsNullOrEmpty(_where))
            {
                whereEx = " 1=1 ";
            }
            else
            {
                whereEx = _where;
            }

            if (_entity != null)
            {
                whereEx += " and code " + operate + _entity.code;
            }

            List<FishEntity.HomemadeStorageEntity> list = _bll.GetModelList(whereEx + orderBy);
            if (list == null || list.Count < 1)
            {
                MessageBox.Show("已经没有记录了!");
                return;
            }
            panel1.Enabled = true;
            _entity = list[0];

            SetEntity();
        }
              
        protected bool Check()
        {
             errorProvider1.Clear();

             bool isok = true;
             if (true == string.IsNullOrEmpty(txtFishCode.Text))
             {
                 isok = false;
                 errorProvider1.SetError(txtfishname, "请选择鱼粉ID");
             }

             decimal temp1=0;
             int quantity = 0;
             bool isdec1 = false;
             bool isdec2 = false;

             if (true == string.IsNullOrEmpty(txtweight.Text))
             {
                 errorProvider1.SetError(txtweight, "请输入自制仓入库重量。");
                 isok = false;
             }
             else
             {
                 if (decimal.TryParse(txtweight.Text, out temp1) == false)
                 {
                     isok = false;
                     errorProvider1.SetError(txtweight,"请输入正确的自制仓入库重量。");
                 }
                 else if (temp1 <= 0)
                 {
                     isok = false;
                     errorProvider1.SetError(txtweight ,"请输入大于零的重量。");
                 }
             }

             if (true == string.IsNullOrEmpty(txtquantity.Text))
             {
                 errorProvider1.SetError(txtquantity , "请输入自制仓入库数量。");
                 isok = false;
             }
             else
             {
                 if (int.TryParse(txtquantity.Text, out quantity ) == false)
                 {
                     isok = false;
                     errorProvider1.SetError(txtquantity, "请输入正确的自制仓入库数量。");
                 }
             }

             if (true == string.IsNullOrEmpty(txtselfprice .Text))
             {
                 errorProvider1.SetError(txtselfprice, "请输入自制仓采购单价。");
                 isok = false;
             }
             else
             {
                 if (decimal.TryParse(txtselfprice.Text, out temp1) == false)
                 {
                     isok = false;
                     errorProvider1.SetError(txtselfprice, "请输入正确的自制仓采购单价。");
                 }
                 else if (temp1 <= 0)
                 {
                     isok = false;
                     errorProvider1.SetError(txtselfprice, "请输入大于零的单价。");
                 }
             }

             if (true == string.IsNullOrEmpty(txtsaleprice.Text))
             {
                 errorProvider1.SetError(txtsaleprice, "请输入销售采购单价。");
                 isok = false;
             }
             else
             {
                 if (decimal.TryParse(txtsaleprice.Text, out temp1) == false)
                 {
                     isok = false;
                     errorProvider1.SetError(txtsaleprice, "请输入正确的销售采购单价。");
                 }
                 else if (temp1 <= 0)
                 {
                     isok = false;
                     errorProvider1.SetError(txtsaleprice, "请输入大于零的单价。");
                 }
             }




             if (false == string.IsNullOrEmpty(txtgrossweight.Text))
             {
                 if ((isdec1 = decimal.TryParse(txtgrossweight.Text, out temp1)) == false)
                 {
                     isok = false;
                     errorProvider1.SetError(txtgrossweight, "请输入正确的毛重。");
                 }
             }
             else
             {
                 isok = false;
                 errorProvider1.SetError(txtgrossweight, "请输入毛重。");
             }

             decimal temp2 = 0;
             if (false == string.IsNullOrEmpty(txttureweight.Text))
             {
                 if ((isdec2 = decimal.TryParse(txttureweight.Text, out temp2)) == false)
                 {
                     isok = false;
                     errorProvider1.SetError(txttureweight, "请输入正确的皮重。");
                 }
             }
             else
             {
                 isok = false;
                 errorProvider1.SetError(txttureweight, "请输入皮重。");
             }

             //if (isdec1 && isdec2)
             //{
             //    decimal temp3 = temp1 - temp2;
             //    if (temp3 <= 0)
             //    {
             //        isok = false;
             //        errorProvider1.SetError(txtgrossweight, "毛重减去皮重小于零。");
             //    }
             //}

             if (false == string.IsNullOrEmpty(txtpackagenum.Text))
             {
                 int temp4;
                 if (int.TryParse(txtpackagenum.Text, out temp4) == false)
                 {
                     isok = false;
                     errorProvider1.SetError(txtpackagenum, "请输入正确的包数。");
                 }
             }
             else
             {
                 isok = false;
                 errorProvider1.SetError(txtpackagenum, "请输入包数。");
             }

             //if (string.IsNullOrEmpty(txtunitprice.Text))
             //{
             //    isok = false;
             //    errorProvider1.SetError(txtunitprice, "请输入单价。");
             //}
             //else
             //{
             //    if (false == decimal.TryParse(txtunitprice.Text, out temp1))
             //    {
             //        isok = false;
             //        errorProvider1.SetError(txtunitprice, "请输入正确的单价。");
             //    }else if( temp1 <= 0 )
             //    {
             //        isok = false;
             //        errorProvider1.SetError(txtunitprice, "请输入大于0的单价。");
             //    }
             //}

             return isok;
        }

        protected void SetEntity()
        {
            if (_entity == null) return;

            txtCode.Text = _entity.code;
            txtFishCode.Text = _entity.productcode;
            txtFishCode.Tag = _entity.productid;
            txtfishname.Text = _entity.productname;
            txtgrossweight.Text = _entity.grossweight.ToString();
            txtnetweight.Text = _entity.netweight.ToString();
            txtpackagenum.Text = _entity.packages.ToString();
            txtSeq.Text = _entity.seq;
            txttureweight.Text = _entity.tareweight.ToString();
            txtunitprice.Text = _entity.unitprice.ToString();
            dtpIntime.Value = _entity.intime.Value;
            dtpOuttime.Value = _entity.outtime.Value;

            dtpStorageDate.Value = _entity.storagetime.Value;
            txtweight.Text = _entity.storageweight.ToString();
            txtquantity.Text = _entity.storagequantity.ToString();
            txtselfprice.Text = _entity.selfprice.ToString();
            txtsaleprice.Text = _entity.saleprice.ToString();
            txtpurposeman.Text = _entity.purchaseman;
            txtpurposeman.Tag = _entity.purchasemanid;
            txtdeliveryman.Text = _entity.storageman;
            txtdeliveryman.Tag = _entity.storagemanid;


            FishBll.Bll.ProductBll productBll = new FishBll.Bll.ProductBll();
            FishEntity.ProductEntity fish = productBll.GetModel(_entity.productid.Value);
            if (fish == null) return;

            txtsgs_amine.Text = fish.sgs_amine.ToString();
            txtsgs_fat.Text = fish.sgs_fat.ToString();
            txtsgs_ffa.Text = fish.sgs_ffa.ToString();
            txtsgs_graypart.Text = fish.sgs_graypart.ToString();
            txtsgs_protein.Text = fish.sgs_protein.ToString();
            txtsgs_sand.Text = fish.sgs_sand.ToString();
            txtsgs_sandsalt.Text = fish.sgs_sandsalt.ToString();
            txtsgs_tvn.Text = fish.sgs_tvn.ToString();
            txtsgs_water.Text = fish.sgs_water.ToString();

            txtlabel_lysine.Text = fish.label_lysine.ToString();
            txtlabel_methionine.Text = fish.label_methionine.ToString();

            txtdomestic_graypart.Text = fish.domestic_graypart.ToString();
            txtdomestic_lysine.Text = fish.domestic_lysine.ToString();
            txtdomestic_methionine.Text = fish.domestic_methionine.ToString();
            txtdomestic_protein.Text = fish.domestic_protein.ToString();
            txtdomestic_sandsalt.Text = fish.domestic_sandsalt.ToString();
            txtdomestic_sour.Text = fish.domestic_sour.ToString();
            txtdomestic_tvn.Text = fish.domestic_tvn.ToString();

            dtpStorageDate.Value = _entity.storagetime.Value;
            txtweight.Text = _entity.storageweight.ToString();
            txtquantity.Text = _entity.storagequantity.ToString();
            txtselfprice.Text = _entity.selfprice.ToString();
            txtsaleprice.Text = _entity.saleprice.ToString();
            txtpurposeman.Text = _entity.purchaseman;
            txtpurposeman.Tag = _entity.purchasemanid;
            txtdeliveryman.Text = _entity.storageman;
            txtdeliveryman.Tag = _entity.storagemanid;

            txtFishCode.Enabled = false;
            txtfishname.Enabled = false; 

        }

        protected void GetEntity()
        {
            if (_entity == null) return;
            if (_en == null) return;
            int temp1;
            decimal temp2;

            _entity.seq = txtSeq.Text.Trim();
            _entity.intime = dtpIntime.Value;
            _entity.outtime = dtpOuttime.Value;
            int.TryParse(txtFishCode.Tag.ToString(), out temp1);
            _entity.productid = temp1;
            _entity.productcode = txtFishCode.Text;
            _entity.productname = txtfishname.Text;
            _en.code = txtFishCode.Text;
            decimal.TryParse(txtgrossweight.Text ,out temp2);
            _entity.grossweight = temp2;
            decimal.TryParse(txttureweight.Text, out temp2);
            _entity.tareweight = temp2;

            decimal.TryParse(txtnetweight.Text, out temp2);
            _entity.netweight = temp2;

            int.TryParse(txtpackagenum.Text, out temp1);
            _entity.packages = temp1;

            decimal.TryParse(txtunitprice.Text, out temp2);
            _entity.unitprice = temp2;
                 
            //---------------SGS指标------------------------------------
            int.TryParse(txtsgs_amine.Text, out temp1);
            _entity.sgs_amine = temp1;

            decimal.TryParse(txtsgs_ffa.Text, out temp2);
            _entity.sgs_ffa = temp2;

            decimal.TryParse(txtsgs_fat.Text, out temp2);
            _entity.sgs_fat = temp2;

            decimal.TryParse(txtsgs_graypart.Text, out temp2);
            _entity.sgs_graypart = temp2;

            decimal.TryParse(txtsgs_protein.Text, out temp2);
            _entity.sgs_protein = temp2;

            decimal.TryParse(txtsgs_sand.Text, out temp2);
            _entity.sgs_sand = temp2;

            decimal.TryParse(txtsgs_sandsalt.Text, out temp2);
            _entity.sgs_sandsalt = temp2;

            int.TryParse(txtsgs_tvn.Text, out temp1);
            _entity.sgs_tvn = temp1;

            decimal.TryParse(txtsgs_water.Text, out temp2);
            _entity.sgs_water = temp2;

            //--------------------------------------------------------

            decimal.TryParse(txtlabel_lysine.Text, out temp2);
            _entity.label_lysine = temp2;

            decimal.TryParse(txtlabel_methionine.Text, out temp2);
            _entity.label_methionine = temp2;

            //-----------------------------------------------------------
            decimal.TryParse(txtdomestic_graypart.Text, out temp2);
            _entity.domestic_graypart = temp2;

            decimal.TryParse(txtdomestic_lysine.Text, out temp2);
            _entity.domestic_lysine = temp2;

            decimal.TryParse(txtdomestic_methionine.Text, out temp2);
            _entity.domestic_methionine = temp2;

            decimal.TryParse(txtdomestic_protein.Text, out temp2);
            _entity.domestic_protein = temp2;

            decimal.TryParse(txtdomestic_sandsalt.Text, out temp2);
            _entity.domestic_sandsalt = temp2;

            decimal.TryParse(txtdomestic_sour.Text, out temp2);
            _entity.domestic_sour = temp2;

            int.TryParse(txtdomestic_tvn.Text, out temp1);
            _entity.domestic_tvn = temp1;

            _entity.storagetime = dtpStorageDate.Value;
            decimal weight = 0;
            decimal.TryParse ( txtweight .Text , out weight );
            _entity.storageweight = weight;
            int quantity = 0;
            int.TryParse(txtquantity.Text, out quantity);
            _entity.storagequantity = quantity;

            int mainid = 0;
            int.TryParse(txtpurposeman.Tag == null ? "0" : txtpurposeman.Tag.ToString(), out mainid);
            _entity.purchasemanid = mainid;
            _entity.purchaseman = txtpurposeman.Text.Trim ();

            int.TryParse(txtdeliveryman.Tag == null ? "0" : txtdeliveryman.Tag.ToString(), out mainid);
            _entity.storagemanid = mainid;
            _entity.storageman = txtdeliveryman.Text.Trim();

            decimal price = 0;
            decimal.TryParse(txtselfprice.Text, out price);
            _entity.selfprice = price;

            decimal.TryParse(txtsaleprice.Text, out price);
            _entity.saleprice = price;


            _entity.storagetime = dtpStorageDate.Value;
            
            decimal.TryParse(txtweight.Text , out weight );
            _entity.storageweight = weight;

            int.TryParse(txtquantity.Text, out quantity);
            _entity.storagequantity = quantity;

            decimal.TryParse(txtselfprice.Text, out price);
            _entity.selfprice = price;

            decimal.TryParse(txtsaleprice.Text, out price);
            _entity.saleprice = price;

            int id = 0;
            int.TryParse(txtpurposeman.Tag == null ? "0" : txtpurposeman.Tag.ToString(),out id);
            _entity.purchasemanid = id;
            _entity.purchaseman = txtpurposeman.Text.Trim ();

            int.TryParse(txtdeliveryman.Tag == null ? "0" : txtdeliveryman.Tag.ToString(), out id);
            _entity.storagemanid = id;
            _entity.storageman = txtdeliveryman.Text.Trim();

        }
        
        public override void Save()
       {
            if (Check() == false) return ;

            _entity = new FishEntity.HomemadeStorageEntity();
            _en = new FishEntity.ProductEntity();
            GetEntity();

            _entity.createman = FishEntity.Variable.User.username;
            _entity.createtime = DateTime.Now;
            _entity.modifyman = _entity.createman;
            _entity.modifytime = _entity.createtime;

            _entity.code = FishBll.Bll.SequenceUtil.GetHomemadeStorageSequence();
            while (_bll.Exists(_entity.code))
            {
                _entity.code = FishBll.Bll.SequenceUtil.GetHomemadeStorageSequence();
            }

            int id = _bll.Add(_entity);
            _bll.Add1(_en);
            if (id > 0)
            {
                _entity.id = id;
                txtCode.Text = _entity.code;
                //更新 鱼粉资料 的自制仓 成本，数量 , 重量
                //FishBll.Bll.ProductBll productBll = new FishBll.Bll.ProductBll();
                //decimal cost = _entity.unitprice.Value * _entity.netweight.Value;
                //decimal weight = _entity.netweight.Value;
                //bool isok = productBll.UpdateHomemade(_entity.productid.Value , weight , cost, _entity.packages.Value);

                //更新 鱼粉资料的 自制仓 入库重量，数量，采购单价，销售单价，入库时间等信息
                FishBll.Bll.ProductExBll productExBll = new FishBll.Bll.ProductExBll();
                bool isok = productExBll.UpdateHomeMadeInfo(_entity.productid.Value, _entity.storageweight, _entity.storagequantity, _entity.selfprice, _entity.saleprice, _entity.storagetime.Value.ToString("yyyy/MM/dd"));

                //tmiCancel.Visible = false;
                //tmiSave.Visible = false;
                //tmiAdd.Visible = true;
                //tmiModify.Visible = true;
                //tmiDelete.Visible = true;
                //tmiQuery.Visible = true;
                //tmiPrevious.Visible = true;
                //tmiNext.Visible = true;
                //txtfishname.Enabled = false;
                //txtFishCode.Enabled = false;
                ControlButtomRoles();

                MessageBox.Show("新增成功。");
            }
            else
            {
                MessageBox.Show("新增失败。");
            }
            return ;
        }

        public override int Add()
        {
            tmiSave.Visible = true;
            tmiCancel.Visible = true;
            tmiAdd.Visible = false;
            tmiModify.Visible = false;
            tmiQuery.Visible = false;
            tmiPrevious.Visible = false;
            tmiNext.Visible = false;
            tmiDelete.Visible = false;
            panel1.Enabled = true;
            ClearContent();

            txtfishname.Enabled = true;
            txtFishCode.Enabled = true;

            return 1;
        }

        public override void Cancel()
        {
            //tmiDelete.Visible = true;
            //tmiAdd.Visible =true;
            //tmiModify.Visible = true;
            //tmiQuery.Visible = true;
            //tmiPrevious.Visible = true;
            //tmiNext.Visible = true;
            //tmiSave.Visible = false;
            //tmiCancel.Visible = false;
            ControlButtomRoles();

            ClearContent();
        }

        public override int Modify()
        {
            if (_entity == null) return 0;
            if (Check() == false) return 0;

            int s_productId = _entity.productid.Value;
            decimal s_weight = _entity.netweight.Value;
            decimal s_cost = _entity.unitprice.Value * _entity.netweight.Value;
            int s_packages = _entity.packages.Value;

            decimal s_storageweight = _entity.storageweight;
            int s_storagequantity = _entity.storagequantity;


            GetEntity();

            int d_productId = _entity.productid.Value;
            decimal d_weight = _entity.netweight.Value;
            decimal d_cost = _entity.unitprice.Value * _entity.netweight.Value;
            int d_packages = _entity.packages.Value;

            decimal d_storageweight = _entity.storageweight;
            int d_storagequantity = _entity.storagequantity;

            decimal weight = d_weight - s_weight;
            decimal cost = d_cost - s_cost;
            int packages = d_packages - s_packages;

            decimal storageweight = d_storageweight - s_storageweight;
            int storagequantity = d_storagequantity - s_storagequantity;

            _entity.modifyman = FishEntity.Variable.User.username;
            _entity.modifytime = DateTime.Now;

            bool isok = _bll.Update(_entity);
            if (isok)
            {
                if (s_productId == d_productId)
                {//当鱼粉ID没有改变时， 更新 鱼粉的状态为 “自营”，重量，数量,成本
                    weight = d_weight - s_weight;
                    packages = d_packages - s_packages;
                    cost = d_cost - s_cost;
                    //FishBll.Bll.ProductBll productBll = new FishBll.Bll.ProductBll();
                    //isok = productBll.UpdateHomemade(_entity.productid.Value, weight, cost, packages);

                    //单鱼粉id没有改变时，更新鱼粉自制仓入库重量数量，采购单价，销售单价，入库时间
                    FishBll.Bll.ProductExBll productExBll = new FishBll.Bll.ProductExBll();
                    isok = productExBll.UpdateHomeMadeInfo(_entity.productid.Value, storageweight, storagequantity, _entity.selfprice, _entity.saleprice, _entity.storagetime.Value.ToString("yyyy/MM/dd"));

                }
                else
                {//当鱼粉id改变时，先调整原鱼粉资料的自制仓 成本，数量 , 重量，再调整新鱼粉资料的自制仓 成本，数量 , 重量
                   //TODO 暂时屏蔽 这种情况。

                    //weight = -s_weight;
                    //packages = -s_packages;
                    //cost = -s_cost;
                    
                    //FishBll.Bll.ProductBll productBll = new FishBll.Bll.ProductBll();    
                    //productBll.UpdateHomemade(s_productId, weight, cost, packages);

                    //weight = d_weight;
                    //packages = d_packages;
                    //cost = d_cost;

                    //isok = productBll.UpdateHomemade( d_productId , weight, cost, packages);

                }

                MessageBox.Show("修改成功。");
            }
            else
            {
                MessageBox.Show("修改失败。");
            }
            return 1;
        }

        protected void ClearContent()
        {
            _entity = null;

            errorProvider1.Clear();
            txtCode.Text = string.Empty;
            txtFishCode.Text = string.Empty;
            txtFishCode.Tag = string.Empty;
            txtfishname.Text = string.Empty;
            txtgrossweight.Text = "0.00";
            txttureweight.Text = "0.00";
            txtnetweight.Text = "0.00";
            dtpIntime.Value = DateTime.Now;
            dtpOuttime.Value = DateTime.Now;
            txtSeq.Text = string.Empty;
            txtpackagenum.Text = "0";
            txtunitprice.Text = "0.00";

            txtsgs_amine.Text = "0";
            txtsgs_fat.Text = "0.00";
            txtsgs_ffa.Text = "0.00";
            txtsgs_graypart.Text = "0.00";
            txtsgs_protein.Text = "0.00";
            txtsgs_sand.Text = "0.00";
            txtsgs_sandsalt.Text = "0.00";
            txtsgs_tvn.Text = "0";
            txtsgs_water.Text = "0.00";

            txtlabel_lysine.Text = "0.00";
            txtlabel_methionine.Text = "0.00";

            txtdomestic_graypart.Text = "0.00";
            txtdomestic_lysine.Text = "0.00";
            txtdomestic_methionine.Text = "0.00";
            txtdomestic_protein.Text = "0.00";
            txtdomestic_sandsalt.Text = "0.00";
            txtdomestic_sour.Text = "0.00";
            txtdomestic_tvn.Text = "0";

            dtpStorageDate.Value = DateTime.Now;
            txtweight.Text = "0.00";
            txtquantity.Text = "0";
            txtsaleprice.Text = "0.00";
            txtselfprice.Text= "0.00";
            txtpurposeman.Text = string.Empty;
            txtpurposeman.Tag = "0";
            txtdeliveryman.Text = string.Empty;
            txtdeliveryman.Tag = "0";
        }

        public override int Delete()
        {
            if (_entity == null) return 0;

            string msg = string.Format ( "你确定要删除自制仓入库单号为【{0}】的记录吗？", _entity.code );
            if (MessageBox.Show( msg , "询问", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return 0;

            bool isok = _bll.Delete(_entity.id);
            if (isok)
            {
                //更新 鱼粉 的自制仓 成本，数量 , 重量
                //FishBll.Bll.ProductBll productBll = new FishBll.Bll.ProductBll();
                //decimal cost = - _entity.packages.Value * _entity.unitprice.Value;
                //decimal weight = - _entity.netweight.Value;
                //int number = -_entity.packages.Value;
                //isok = productBll.UpdateHomemade(_entity.productid.Value, weight , cost, number);


                //更新鱼粉资料 的自制仓入库重量数量，采购单价=0，销售单价=0，入库时间=""
                FishBll.Bll.ProductExBll productexBll = new FishBll.Bll.ProductExBll();
                decimal storageweight =- _entity.storageweight;
                int storagequantity = -_entity.storagequantity;
                decimal selfprice = 0.00m;
                decimal saleprice = 0.00m;
                string storagetime = string.Empty;
                productexBll.UpdateHomeMadeInfo(_entity.productid.Value, storageweight, storagequantity, selfprice, saleprice, storagetime);

                //

                //
                _entity = null;
                ClearContent();
                Query();
            }
            else
            {
            }
            return 1;
        }

        private void txtFishCode_Click(object sender, EventArgs e)
        {
            UIForms.FormSelectFish form = new UIForms.FormSelectFish( -1 );
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowInTaskbar = false;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectedProduct == null) return;

            txtFishCode.Text = form.SelectedProduct.code;
            txtFishCode.Tag = form.SelectedProduct.id;
            txtfishname.Text = form.SelectedProduct.name;      

            txtsgs_amine.Text = form.SelectedProduct.sgs_amine.ToString();
            txtsgs_fat.Text = form.SelectedProduct.sgs_fat.ToString();
            txtsgs_ffa.Text = form.SelectedProduct.sgs_ffa.ToString();
            txtsgs_graypart.Text = form.SelectedProduct.sgs_graypart.ToString();
            txtsgs_protein.Text = form.SelectedProduct.sgs_protein.ToString();
            txtsgs_sand.Text = form.SelectedProduct.sgs_sand.ToString();
            txtsgs_sandsalt.Text = form.SelectedProduct.sgs_sandsalt.ToString();
            txtsgs_tvn.Text = form.SelectedProduct.sgs_tvn.ToString();
            txtsgs_water.Text = form.SelectedProduct.sgs_water.ToString();

            txtlabel_lysine.Text = form.SelectedProduct.label_lysine.ToString();
            txtlabel_methionine.Text = form.SelectedProduct.label_methionine.ToString();

            txtdomestic_graypart.Text = form.SelectedProduct.domestic_graypart.ToString();
            txtdomestic_lysine.Text = form.SelectedProduct.domestic_lysine.ToString();
            txtdomestic_methionine.Text = form.SelectedProduct.domestic_methionine.ToString();
            txtdomestic_protein.Text = form.SelectedProduct.domestic_protein.ToString();
            txtdomestic_sandsalt.Text = form.SelectedProduct.domestic_sandsalt.ToString();
            txtdomestic_sour.Text = form.SelectedProduct.domestic_sour.ToString();
            txtdomestic_tvn.Text = form.SelectedProduct.domestic_tvn.ToString(); 

        }

        private void txtgrossweight_TextChanged(object sender, EventArgs e)
        {
            Calc();
        }

        protected void Calc()
        {
            decimal temp1 = 0;
            decimal.TryParse(txtgrossweight.Text, out temp1);
            decimal temp2 = 0;
            decimal.TryParse(txttureweight.Text, out temp2);
            decimal temp3 = 0;
            temp3 = temp1 - temp2;
            txtnetweight.Text = temp3.ToString("f2");
        }

        private void txttureweight_TextChanged(object sender, EventArgs e)
        {
            Calc();
        }

        private void txtunitprice_TextChanged(object sender, EventArgs e)
        {
            //decimal temp1 = 0;
            //decimal.TryParse(txtnetweight.Text, out temp1);
            //decimal temp2 = 0;
            //decimal.TryParse(txtunitprice.Text, out temp2);
            //decimal temp3 = temp1 * temp2;          
        }

        private void txtpurposeman_Click(object sender, EventArgs e)
        {
            SelectMan(txtpurposeman);
        }

        protected void SelectMan( TextBox txt )
        {
            FormUserList form = new FormUserList(true);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowInTaskbar = false;
            DialogResult result = form.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                FishEntity.PersonEntity person = form.SelectedPersion;
                if (person != null)
                {
                    txt.Text = person.realname;
                    txt.Tag = person.id;
                }
            }
        }

        private void txtdeliveryman_Click(object sender, EventArgs e)
        {
            SelectMan(txtdeliveryman);
        }
    }
}
