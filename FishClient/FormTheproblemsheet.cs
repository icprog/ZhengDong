using System;
using System . Collections . Generic;
using System . Windows . Forms;

namespace FishClient
{
    public partial class FormTheproblemsheet :FormMenuBase
    {
        /// <summary> 
        /// 流程状态表刷新
        /// </summary>
        FishBll.Bll.ProcessStateBll _Refreshbll = null;
        private FishBll.Bll.TheproblemsheetBll _TheBll = new FishBll.Bll.TheproblemsheetBll();
        FishClient.UIForms.FormTheproblemsheetCodition _FormThe = null;
        private FishEntity.TheproblemsheetEntity _fish = null;
        private string _where = string.Empty;
        string _orderBy = " order by id asc limit 1";//limit 1
        private string _rolewhere = string.Empty;
        string getname = string.Empty;
        public FormTheproblemsheet()
        {
            InitializeComponent();
            this.panel1.Enabled = false;
        }
        public FormTheproblemsheet(string name)
        {
            InitializeComponent();
            getname = name;
            this.panel1.Enabled = false;
        }
        public override int Query()
        {
            if (_FormThe == null)
            {
                _FormThe = new UIForms.FormTheproblemsheetCodition();
                _FormThe.StartPosition = FormStartPosition.CenterParent;
                _FormThe.ShowInTaskbar = false;
            }
            if (_FormThe.ShowDialog() != System.Windows.Forms.DialogResult.OK) return 0;
            _where = _FormThe.GetWhereCondition;
            List<FishEntity.TheproblemsheetEntityVo> list = _TheBll.GetModelListVo(_where + _rolewhere + _orderBy);
            if (list == null || list.Count < 1)
            {
                _fish = null;
                return 1;
            }
            else
            {
                _fish = list[0];
                SetTheproblemsheet();
                panel1.Enabled = true;
                return 1;
            }
        }
        public override int Add()
        {
            tmiQuery.Visible = false;
            tmiDelete.Visible = false;
            tmiModify.Visible = false;
            tmiAdd.Visible = false;
            tmiSave.Visible = true;
            tmiCancel.Visible = true;
            panel1.Enabled = true;
            txtcode.Text = string.Empty;
            dtpoccurDate.Value = DateTime.Now;
            txtEventName.Text = string.Empty;
            txtSolvTtheProblem.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtContractNo.Text =string.Empty;
            txtFishMealId.Text = string.Empty;
            if (getname!="")
            {
                FishBll.Bll.SalerequisitionBll _bll1 = new FishBll.Bll.SalerequisitionBll();
                FishEntity.SalesRequisitionEntity _fish1 = new FishEntity.SalesRequisitionEntity();
                _fish1 = _bll1.Getname(getname);
                if (_fish1!= null)
                {
                    txtCodeOdd.Text = _fish1.code;
                    txtNumbering.Text = _fish1.Numbering;
                    txtFishMealId.Text = _fish1.Product_id;
                }
            }

            return 1;
        }
        public override void Review()
        {
            Review(this.Name, txtNumbering.Text, txtcode.Text, txtcode.Text);
            //if (txtNumbering.Text != "")
            //{
            //    _Refreshbll = new FishBll.Bll.ProcessStateBll();
            //    _Refreshbll.GetFormTheproblemsheet(txtNumbering.Text);
            //}
            base.Review();
        }
        public override void Save()
        {
            decimal temp = 0;
            FishEntity.TheproblemsheetEntity _The = new FishEntity.TheproblemsheetEntity();
            _The.Code = FishBll.Bll.SequenceUtil.GetTheproblemsheet(); 
            _The.ContractNo = txtContractNo.Text;
            decimal.TryParse(txtChargeback.Text, out temp);
            _The.Chargeback= temp;
            _The.OccurDate = dtpoccurDate.Value;
            _The.EventName = txtEventName.Text;
            _The.SolvTtheProblem = txtSolvTtheProblem.Text;
            _The.Remarks = txtRemarks.Text;
            _The.FishMealId = txtFishMealId.Text;
            _The.Createtime = DateTime.Now;
            _The.Createman = FishEntity.Variable.User.username;
            _The.Modifytime = DateTime.Now;
            _The.Modifyman = _The.Createman;
            _The . codeContract = txtCodeOdd . Text;
            _The.Numbering = txtNumbering.Text;
            FishBll.Bll.TheproblemsheetBll bll = new FishBll.Bll.TheproblemsheetBll();
            bool isok = bll.Exists(_The.Code);
            while (isok)
            {
                _The.Code = FishBll.Bll.SequenceUtil.GetTheproblemsheet();
                isok = bll.Exists(_The.Code);
            }
            int id = 0;
            if ( temp == 0 )
                id = bll . Add ( _The ,this . Name );
            else
                id = bll . Add ( _The );
            if (id > 0)
            {
                _The.Id = id;
                //if (txtNumbering.Text!="")
                //{
                //    _Refreshbll = new FishBll.Bll.ProcessStateBll();
                //    _Refreshbll.GetFormTheproblemsheet(txtNumbering.Text);
                //}
                tmiQuery.Visible = false;
                tmiDelete.Visible = false;
                tmiModify.Visible = false;
                tmiSave.Visible = false;
                tmiAdd.Visible = false;
                tmiCancel.Visible = true;
                MessageBox.Show("添加成功。");
                txtcode.Text = _The.Code;
            }
            else
            {
                txtcode.Text = _The.Code;
                MessageBox.Show("添加失败。");
            }
        }
        public override void Cancel()
        {
            tmiAdd.Visible = true;
            tmiModify.Visible = true;
            tmiQuery.Visible = true;
            tmiDelete.Visible = true;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;

            //panel1.Enabled = true;
        }
        public override int Modify()
        {
            FishBll.Bll.TheproblemsheetBll bll = new FishBll.Bll.TheproblemsheetBll();
            _fish.ContractNo = txtContractNo.Text;//新增后修改bug
            decimal temp = 0;
            decimal.TryParse(txtChargeback.Text, out temp);
            _fish.Chargeback = temp;
            _fish.OccurDate = dtpoccurDate.Value;
            _fish.EventName = txtEventName.Text;
            _fish.SolvTtheProblem = txtSolvTtheProblem.Text;
            _fish.Remarks = txtRemarks.Text;
            _fish.FishMealId = txtFishMealId.Text;
            _fish.Modifytime = DateTime.Now;
            _fish.Modifyman = FishEntity.Variable.User.username;
            _fish . codeContract = txtCodeOdd . Text;
            if (bll.ExistsUpdate(_fish.Code, FishEntity.Variable.User.username)==false)
            {
                MessageBox.Show("不是所属人无法操作！");
                return 0;
            }
            _Refreshbll = new FishBll.Bll.ProcessStateBll();
            if (_Refreshbll.ExistsNumbering(txtNumbering.Text, "wtfkExBool") ==true)
            {
                MessageBox.Show("已审核无法操作！");
                return 0;
            }
            bool isok = bll.Update(_fish,this.Name);
            if (isok)
            {
                //if (txtNumbering.Text != "")
                //{
                //    _Refreshbll = new FishBll.Bll.ProcessStateBll();
                //    _Refreshbll.GetFormTheproblemsheet(txtNumbering.Text);
                //}
                MessageBox.Show("修改成功。");
            }
            else
            {
                MessageBox.Show("修改失败。");
            }
            return 1;
        }
        protected void SetTheproblemsheet()
        {
            txtContractNo.Text = _fish.ContractNo;
            txtcode.Text = _fish.Code;
            dtpoccurDate.Value = _fish.OccurDate.Value;
            txtEventName.Text = _fish.EventName;
            txtSolvTtheProblem.Text = _fish.SolvTtheProblem;
            txtRemarks.Text = _fish.Remarks;
            txtFishMealId.Text = _fish.FishMealId;
            txtCodeOdd . Text = _fish . codeContract;
            txtChargeback.Text = _fish.Chargeback.ToString();
            txtNumbering.Text = _fish.Numbering;
            txtcreateman.Text = _fish.Createman;
            txtmodifyman.Text = _fish.Modifyman;
                }

        //获取销售合同单号
        private void txtCodeOdd_Click ( object sender ,EventArgs e )
        {
            FormSalesTables from = new FormSalesTables( );
            from . StartPosition = System . Windows . Forms . FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) != System . Windows . Forms . DialogResult . OK )
                return;

            txtCodeOdd . Text = string . Empty;
            txtCodeOdd . Text = from . fish.code;
            txtFishMealId.Text = from.fish.Product_id;
            txtNumbering.Text = from.fish.Numbering;
        }

        private void FormTheproblemsheet_Load(object sender, EventArgs e)
        {
            MenuCode = "M309"; ControlButtomRoles();
            if (Megres.oddNum != null && Megres.oddNum != "")
            {
                _rolewhere = " and code='" + Megres.oddNum + "'";
                List<FishEntity.TheproblemsheetEntityVo> list = _TheBll.GetModelListVo(_rolewhere);
                getname = Megres.oddNum;
                Megres.oddNum = string.Empty;
                if (list == null || list.Count < 1)
                {
                    _fish = null;                    
                }
                else
                {
                    _fish = list[0];
                    SetTheproblemsheet();
                    this.panel1.Enabled = true;
                    menuStrip1.Visible = true;
                    tmiQuery.Visible = true;
                    tmiPrevious.Visible = false;
                    tmiExport.Visible = false;
                    tmiReview.Visible = true;
                    tmiAdd.Visible = false;
                    tmiModify.Visible = true;
                    tmiDelete.Visible = false;
                    tmiClose.Visible = true;
                    tmiCancel.Visible = false;
                    tmiSave.Visible = false;
                    tmiNext.Visible = false;
                    tmiprint.Visible = false;                    
                }
            }
        }
    }
}
