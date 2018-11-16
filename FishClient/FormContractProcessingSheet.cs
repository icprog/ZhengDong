using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormContractProcessingSheet : FormMenuBase
    {
        FishEntity.ContractProcessingSheetEntity _fish = null;
        private UIForms.FormContractProcessingSheetConditicon _Form = null;
        private FishBll.Bll.FormContractProcessingSheetBll _bll = new FishBll.Bll.FormContractProcessingSheetBll();
        private string _where = string.Empty;
        string _orderBy = " order by id asc limit 1";//limit 1
        private string _rolewhere = string.Empty;
        public FormContractProcessingSheet()
        {
            InitializeComponent();
        }

        private void FormContractProcessingSheet_Load ( object sender ,EventArgs e )
        {
            _rolewhere = " and code='" + Megres . oddNum + "'";
            List<FishEntity . ContractProcessingSheetEntity> list = _bll . GetModelListVo (_where + _rolewhere + _orderBy);
            Megres.oddNum = string.Empty;
            if ( list == null || list . Count < 1 )
            {
                _fish = null;
            }
            else
            {
                _fish = list [ 0 ];
                Set ( );
                this.panel1.Enabled = true;
                menuStrip1.Visible = true;
                tmiQuery.Visible = true;
                tmiPrevious.Visible = false;
                tmiExport.Visible = false;
                tmiReview.Visible = true;
                tmiAdd.Visible = false;
                tmiModify.Visible = false;
                tmiDelete.Visible = false;
                tmiClose.Visible = true;
                tmiCancel.Visible = false;
                tmiSave.Visible = false;
                tmiNext.Visible = false;
                tmiprint.Visible = false;
            }
        }

        public override int Query()
        {
            panel1.Enabled = true;
            if (_Form == null)
            {
                _Form = new UIForms.FormContractProcessingSheetConditicon();
                _Form.StartPosition = FormStartPosition.CenterParent;
                _Form.ShowInTaskbar = false;
            }
            if (_Form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return 0;
            _where = _Form.GetWhereCondition;
            List<FishEntity.ContractProcessingSheetEntity> list = _bll.GetModelListVo(_where + _rolewhere + _orderBy);
            if (list == null || list.Count < 1)
            {
                _fish = null;
                return 1;
            }
            else
            {
                _fish = list[0];
                Set();
            }
            return 1;
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
            txtcontractcode.Text = string.Empty;
            dtptdate.Value = DateTime.Now;
            txtTheReason.Text = string.Empty;
            txtProcessing.Text = string.Empty;
            return 1;
        }
        public override void Save()
        {
            FishEntity.ContractProcessingSheetEntity _fish = new FishEntity.ContractProcessingSheetEntity();
            _fish.Code = FishBll.Bll.SequenceUtil.GetContractProcessingSheetquence();
            _fish.Contractcode = txtcontractcode.Text.Trim();
            _fish.Tdate = dtptdate.Value;
            _fish.TheReason = txtTheReason.Text.Trim();
            _fish.Processing = txtProcessing.Text.Trim();
            _fish.Createtime = DateTime.Now;
            _fish.Createman = FishEntity.Variable.User.username;
            _fish.Modifytime = DateTime.Now;
            _fish.Modifyman = FishEntity.Variable.User.username;
            FishBll.Bll.FormContractProcessingSheetBll bll = new FishBll.Bll.FormContractProcessingSheetBll();
            bool isok = bll.Exists(_fish.Code);
            while (isok)
            {
                _fish.Code = FishBll.Bll.SequenceUtil.GetContractProcessingSheetquence();
                isok = bll.Exists(_fish.Code);
            }
            int id = bll.Add(_fish);
            if (id > 0)
            {
                _fish.Id = id;
                tmiQuery.Visible = false;
                tmiDelete.Visible = false;
                tmiModify.Visible = false;
                tmiAdd.Visible = false;
                tmiSave.Visible = true;
                tmiCancel.Visible = true;
                MessageBox.Show("添加成功。");
                txtcode.Text = _fish.Code.ToString();
            }
            else
            {
                // txtCode.Text = _fish.Code;
                MessageBox.Show("添加失败。");
            }
        }
        public override int Modify()
        {
            if (_fish == null)
            {
                MessageBox.Show("请查询需要修改的数据。");
                return 0;
            }
            _fish.Code = txtcode.Text.Trim();
            _fish.Contractcode = txtcontractcode.Text.Trim();
            _fish.Tdate = dtptdate.Value;
            _fish.TheReason = txtTheReason.Text.Trim();
            _fish.Processing = txtProcessing.Text.Trim();
            _fish.Modifytime = DateTime.Now;
            _fish.Modifyman = FishEntity.Variable.User.username;
            FishBll.Bll.FormContractProcessingSheetBll bll = new FishBll.Bll.FormContractProcessingSheetBll();
            bool isOk = bll.Update(_fish);
            if (isOk)
            {
                MessageBox.Show("修改成功。");
            }
            else
            {
                //txtcode.Text = string.Empty;
                MessageBox.Show("修改失败。");
            }
            return 1;
        }
        public override void Cancel()
        {
            tmiAdd.Visible = true;
            tmiModify.Visible = true;
            tmiQuery.Visible = true;
            tmiDelete.Visible = true;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;

            panel1.Enabled = true;
        }
        protected void Set() {
            txtcode.Text = _fish.Code;
            txtcontractcode.Text = _fish.Contractcode;
            dtptdate.Value = _fish.Tdate.Value;
            txtTheReason.Text = _fish.TheReason;
            txtProcessing.Text = _fish.Processing;
        }

    }
}
