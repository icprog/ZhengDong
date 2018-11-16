using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormSampleSingle : FormMenuBase
    {
        FishEntity.SampleSingleEntity _fish = null;
        private UIForms.FormSampleSingleCodition _Form = null;
        private FishBll.Bll.SampleSingleBll _bll = new FishBll.Bll.SampleSingleBll();
        private string _where = string.Empty;
        string _orderBy = " order by id asc limit 1";//limit 1
        private string _rolewhere = string.Empty;
        public FormSampleSingle()
        {
            InitializeComponent();
        }
        public override int Query()
        {
            panel1.Enabled = true;
            if (_Form == null)
            {
                _Form = new UIForms.FormSampleSingleCodition();
                _Form.StartPosition = FormStartPosition.CenterParent;
                _Form.ShowInTaskbar = false;
            }
            if (_Form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return 0;
            _where = _Form.GetWhereCondition;
            List<FishEntity.SampleSingleEntity> list = _bll.GetModelListVo(_where + _rolewhere + _orderBy);
            if (list == null || list.Count < 1)
            {
                _fish = null;
                return 1;
            }
            else
            {
                _fish = list[0];
                SetOnepound();
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
            txtferryName.Text = string.Empty;
            txtBillOfLadingNumber.Text = string.Empty;
            txtPileAngle.Text = string.Empty;
            dtptdate.Value = DateTime.Now;
            return 1;
        }
        public override void Save()
        {
            FishEntity.SampleSingleEntity _fish = new FishEntity.SampleSingleEntity();            
            _fish.Code =FishBll.Bll.SequenceUtil.GetSampleSingleSequence();
            _fish.FerryName = txtferryName.Text.Trim();
            _fish.BillOfLadingNumber = txtBillOfLadingNumber.Text.Trim();
            _fish.PileAngle = txtPileAngle.Text.Trim();
            _fish.Tdate = dtptdate.Value;
            _fish.Createtime = DateTime.Now;
            _fish.Createman = FishEntity.Variable.User.username;
            _fish.Modifytime = DateTime.Now;
            _fish.Modifyman = FishEntity.Variable.User.username;

            FishBll.Bll.SampleSingleBll bll = new FishBll.Bll.SampleSingleBll();
            bool isok = bll.Exists(_fish.Code);
            while (isok)
            {
                _fish.Code = FishBll.Bll.SequenceUtil.GetSampleSingleSequence();
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
                MessageBox.Show("请查询需要修改的取样单。");
                return 0;
            }
            _fish.Code = txtcode.Text; 
            _fish.FerryName = txtferryName.Text.Trim();
            _fish.BillOfLadingNumber = txtBillOfLadingNumber.Text.Trim();
            _fish.PileAngle = txtPileAngle.Text.Trim();
            _fish.Tdate = dtptdate.Value;
            _fish.Modifytime = DateTime.Now;
            _fish.Modifyman = FishEntity.Variable.User.username;
            FishBll.Bll.SampleSingleBll bll = new FishBll.Bll.SampleSingleBll();
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
        protected void SetOnepound() {
            txtcode.Text = _fish.Code;
            txtferryName.Text = _fish.FerryName;
            txtBillOfLadingNumber.Text = _fish.BillOfLadingNumber;
            txtPileAngle.Text = _fish.PileAngle;
            dtptdate.Value = _fish.Tdate.Value;
        }
    }
}
