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
    /// 进仓单
    /// </summary>
    public partial class FormStorageBills : FormMenuBase
    {
        public FishBll.Bll.StorageBillsBll _bll = new FishBll.Bll.StorageBillsBll();
        protected FishEntity.StorageBillsEntity _entity = null;
        string _where = string.Empty;

        public FormStorageBills()
        {
            InitializeComponent();

            //tmiExport.Visible = false;
            //tmiSave.Visible = false;
            //tmiCancel.Visible = false;
        }

        public override void Previous()
        {
            QueryOne("<", " order by id desc limit 1");
        }

        public override void Next()
        {
            QueryOne(">", " order by id asc limit 1");
        }

        public override int Query()
        {
            //TODO
            _entity = null;

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

            List<FishEntity.StorageBillsEntity> list = _bll.GetModelList(whereEx + orderBy);
            if (list == null || list.Count < 1)
            {
                MessageBox.Show("已经没有记录了!");
                return;
            }

            _entity = list[0];

            SetStorageBill();
        }

        protected void SetStorageBill()
        {
            if (_entity == null) return;

            txtCode.Text = _entity.code;
            txtOperateCode.Text = _entity.operatecode;
            txtCompanyCode.Text = _entity.delegateunitcode;
            txtCompanyCode.Tag = _entity.delegateunitid;
            txtCompanyName.Text = _entity.delegateunit;
            txtStorageBill.Text = _entity.deliverybills;
            txtFishCode.Text = _entity.productcode;
            txtFishCode.Tag = _entity.productid;
            txtFishName.Text = _entity.productname;
            dtpunboxdate.Value = _entity.unboxdate.Value;
            txtPlace.Text = _entity.place;
            txtTon.Text = _entity.tons.ToString();
            txtNumber.Text = _entity.number.ToString();
            txtActualNum.Text = _entity.actualnumber.ToString();
            txtRemark.Text = _entity.remark;
            txtlocation.Text = _entity.location;
            txtShipno.Text = _entity.shipno;
        }

        protected bool Check()
        {
            errorProvider1.Clear ();
            bool isok = true;
            int tempInt1 = 0;
            int tempInt2=0;
            decimal temp2 = 0;

            if (int.TryParse(txtNumber.Text, out tempInt1) == false)
            {
                errorProvider1.SetError(txtNumber, "请输入正确数字。");
                isok = false;
            }
            else
            {
                if (tempInt1 < 1)
                {
                    isok = false;
                    errorProvider1.SetError(txtNumber, "请输入大于零的件数。");
                }
            }

            if (int.TryParse(txtActualNum.Text, out tempInt2 ) == false)
            {
                errorProvider1.SetError(txtActualNum , "请输入正确数字。");
                isok = false;
            }
            else
            {
                if (tempInt2 < 1)
                {
                    isok = false;
                    errorProvider1.SetError(txtActualNum, "请输入大于零的件数。");
                }
            }

            if (tempInt1 < tempInt2)
            {
                errorProvider1.SetError(txtActualNum, "实际件数必须小于等于件数。");
                isok = false;
            }

            if (decimal.TryParse(txtTon.Text, out temp2) == false)
            {
                errorProvider1.SetError(txtTon, "请输入正确的数字。");
                isok = false;
            }
            else
            {
                if (temp2 <= 0)
                {
                    isok = false;
                    errorProvider1.SetError(txtTon, "请输入大于零的吨数。");
                }
            }

            if (true == string.IsNullOrEmpty(txtCompanyCode.Text))
            {
                errorProvider1.SetError(txtCompanyName,"请选择委托单位。");
                isok = false;
            }
            if (true == string.IsNullOrEmpty(txtFishCode.Text))
            {
                errorProvider1.SetError(txtFishName, "请选择鱼粉。");
                isok = false;
            }

            int productid =0;
            if (txtFishCode.Tag != null && int.TryParse ( txtFishCode.Tag.ToString() , out productid))
            {
                productid = int.Parse(txtFishCode.Tag.ToString());
                //FishBll.Bll.ProductBll productBll = new FishBll.Bll.ProductBll();
                //FishEntity.ProductEntity model = productBll.GetModel(productid);
                //if (model != null && (model.price == null || model.price.Value <= 0))
                //{
                //    isok = false;
                //    MessageBox.Show("鱼粉的购买单价必须大于零，请修改鱼粉资料中的购买单价。");
                //}
                FishBll.Bll.ProductExBll productexBll = new FishBll.Bll.ProductExBll();
                FishEntity.ProductExEntity model = productexBll.GetModel(productid);
                if( model !=null &&( model.confirmrmb.HasValue == false || model.confirmrmb.Value <= 0 ))
                {
                    isok = false;
                    MessageBox.Show("鱼粉的确盘人民币购买价格必须大于零，请修改鱼粉资料中的确盘人民币购买价格。");
                }
            }

            return isok;
        }

        public override void Save()
        {
            if (Check() == false) return;

            _entity = new FishEntity.StorageBillsEntity();
            GetStorageBills();

            _entity.code = FishBll.Bll.SequenceUtil.GetStorageBillSequence();
            while (_bll.Exists(_entity.code))
            {
                _entity.code = FishBll.Bll.SequenceUtil.GetStorageBillSequence();
            }
            _entity.createman = FishEntity.Variable.User.username;
            _entity.createtime = DateTime.Now;
            _entity.modifyman = _entity.createman;
            _entity.modifytime = _entity.createtime;

            int id = _bll.Add(_entity);
            if (id > 0)
            {
                _entity.id = id;
                txtCode.Text = _entity.code;
                //更新 鱼粉的状态为“自营”，重量，数量
                FishBll.Bll.ProductBll productBll = new FishBll.Bll.ProductBll();
                bool isok = productBll.UpdateState(_entity.productid.Value , FishEntity.Constant.STATE_SELFBUY , _entity.actualnumber.Value , _entity.tons.Value );

                //tmiSave.Visible = false;
                //tmiCancel.Visible = false;
                //tmiDelete.Visible = true;
                //tmiAdd.Visible = true;
                //tmiModify.Visible = true;
                //tmiQuery.Visible = true;
                //tmiPrevious.Visible = true;
                //tmiNext.Visible = true;
                ControlButtomRoles();

                MessageBox.Show("新增成功。");   
            }
            else
            {
                MessageBox.Show("新增失败。");
            }
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

            ClearText();

            return 1;
        }

        public override void Cancel()
        {
            //tmiDelete.Visible = true;
            //tmiAdd.Visible = true;
            //tmiModify.Visible = true;
            //tmiQuery.Visible = true;
            //tmiPrevious.Visible = true;
            //tmiNext.Visible = true;
            //tmiCancel.Visible = false;
            //tmiSave.Visible = false;           
            ControlButtomRoles();
        }

        public override int Modify()
        {
            if (_entity == null)
            {
                MessageBox.Show("请查询需要修改的进仓单。");
                return 0;
            }
            if (Check() == false) return 0;

            int s_productid = _entity.productid.Value;
            int s_actualnumber = _entity.actualnumber.Value;
            decimal s_tons = _entity.tons.Value;

            GetStorageBills();

            _entity.modifyman = FishEntity.Variable.User.username;
            _entity.modifytime = DateTime.Now;

            int d_productid = _entity.productid.Value;
            int d_actualnumber = _entity.actualnumber.Value;
            decimal d_tons = _entity.tons.Value;

            int actualnumber = 0;// d_actualnumber - s_actualnumber;
            decimal tons = 0;// d_tons - s_tons;


            bool isok = _bll.Update(_entity );
            if (isok)
            {
                if (s_productid == d_productid)
                {//当鱼粉ID没有改变时， 更新 鱼粉的状态为 “自营”，重量，数量
                    actualnumber = d_actualnumber - s_actualnumber;
                    tons = d_tons - s_tons;
                    
                    FishBll.Bll.ProductBll productBll = new FishBll.Bll.ProductBll();
                    isok = productBll.UpdateState(_entity.productid.Value, FishEntity.Constant.STATE_SELFBUY, actualnumber, tons);                    

                }
                else
                {//当鱼粉id改变时，先调整原鱼粉资料的重量和包数，再调整新鱼粉资料的重量和包数
                    actualnumber = -s_actualnumber;
                    tons = -s_tons;
                    FishBll.Bll.ProductBll productBll = new FishBll.Bll.ProductBll();
                    isok = productBll.UpdateState(s_productid, FishEntity.Constant.STATE_CONFIRM, actualnumber, tons);
                    actualnumber = d_actualnumber;
                    tons = d_tons;
                    isok = productBll.UpdateState(d_productid, FishEntity.Constant.STATE_SELFBUY, actualnumber, tons);                       
                }
                //更新 鱼粉的状态为 “自营”，重量，数量
                //FishBll.Bll.ProductBll productBll = new FishBll.Bll.ProductBll();
                //isok = productBll.UpdateState(_entity.productid.Value, FishEntity.Constant.STATE_SELFBUY , actualnumber, tons);                    

                MessageBox.Show("修改成功。");
            }
            else
            {
                MessageBox.Show("修改失败。");
            }

            return 1;
        }

        public override int Delete()
        {
            if (_entity == null) return 0;

            string msg = string.Format("你确定要删除进仓单号为【{0}】的记录吗?", _entity.code);
            if (MessageBox.Show(msg, "询问", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return 0;

            FishBll.Bll.ProductBll productBll = new FishBll.Bll.ProductBll();
            bool isok = productBll.UpdateState(_entity.productid.Value, FishEntity.Constant.STATE_CONFIRM, -_entity.actualnumber.Value, -_entity.tons.Value );
            if (isok)
            {
                _bll.Delete(_entity.id);

                ClearText();
                Query();
            }   
            else
            {
                MessageBox.Show("删除失败。");
            }

            return 1;
        }

        protected void ClearText()
        {
            errorProvider1.Clear();
            txtCode.Text = string.Empty;
            txtCompanyCode.Text = string.Empty;
            txtCompanyCode.Tag = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtFishCode.Text = string.Empty;
            txtFishCode.Tag = string.Empty;
            txtFishName.Text = string.Empty;
            txtlocation.Text = string.Empty;
            txtNumber.Text = string.Empty;
            txtOperateCode.Text = string.Empty;
            txtPlace.Text = string.Empty;
            txtRemark.Text = string.Empty;
            txtStorageBill.Text = string.Empty;
            txtTon.Text = string.Empty;
            dtpunboxdate.Value = DateTime.Now;
            txtShipno.Text = string.Empty;

            _entity = null;
        }

        protected FishEntity.StorageBillsEntity GetStorageBills()
        {
            int temp =0;
            int.TryParse ( txtActualNum.Text , out temp );
            _entity.actualnumber = temp;
            _entity.delegateunit = txtCompanyName.Text.Trim();
            _entity.delegateunitcode = txtCompanyCode.Text.Trim();
            int.TryParse ( txtCompanyCode.Tag.ToString () , out temp );
            _entity.delegateunitid = temp;
            _entity.deliverybills = txtStorageBill.Text.Trim();
            _entity.isdelete = 0;
            _entity.location = txtlocation.Text.Trim();
            int.TryParse (txtNumber.Text ,out temp );
            _entity.number = temp;
            _entity.operatecode = txtOperateCode.Text.Trim();
            _entity.place = txtPlace.Text.Trim();
            _entity.productcode = txtFishCode.Text.Trim();
            int.TryParse (txtFishCode.Tag.ToString (),out temp );
            _entity.productid = temp;
            _entity.productname = txtFishName.Text.Trim();
            _entity.remark = txtRemark.Text.Trim();
            decimal temp2 = 0;
            decimal.TryParse(txtTon.Text , out temp2);
            _entity.tons = temp2;
            _entity.unboxdate = dtpunboxdate.Value;
            _entity.shipno = txtShipno.Text.Trim();

            return _entity;
        }
                                      
        private void txtCompanyCode_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;

            txtCompanyName.Text = form.SelectCompany.fullname;
            txtCompanyCode.Text = form.SelectCompany.code;
            txtCompanyCode.Tag = form.SelectCompany.id;         
        }

        private void txtFishCode_Click(object sender, EventArgs e)
        {
            if (_entity != null)
            {
                MessageBox.Show("修改进仓单时，不能改变鱼粉Id。");
                return;
            }

            //选择 状态为 “确盘”的鱼粉资料
            UIForms.FormSelectFish form = new UIForms.FormSelectFish( FishEntity.Constant.STATE_CONFIRM );
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectedProduct == null) return;

            txtFishCode.Text = form.SelectedProduct.code;
            txtFishCode.Tag = form.SelectedProduct.id;
            txtFishName.Text = form.SelectedProduct.name;
        }
    }
}
