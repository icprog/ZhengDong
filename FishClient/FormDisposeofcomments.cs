using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormDisposeofcomments:FormMenuBase
    {
        private FishBll.Bll.DisposeofcommentsBll _DisBll = new FishBll.Bll.DisposeofcommentsBll();
        FishClient.UIForms.FormDisposeofcommentsCodition _Dis = null;
        private FishEntity.DisposeofcommentsEntity _fish = null;
        private string _where = string.Empty;
        string _orderBy = " order by id asc limit 1";
        private string _rolewhere = string.Empty;
        public FormDisposeofcomments()
        {
            InitializeComponent();
            this.panel1.Enabled = false;
        }
        public override int Modify()
        {
            _fish.Filenumber = txtFilenumber.Text;
            _fish.Todealwith = txtTodealwith.Text;
            _fish.Treatmentmeasures = txtTreatmentmeasures.Text;
            _fish.DepartmentManagerOpinion = txtDepartmentManagerOpinion.Text;
            _fish.Managerdate = dtpManagerdate.Value;
            _fish.CompanyOpinion = txtCompanyOpinion.Text;
            _fish.Companydate= dtpCompanydate.Value;
            _fish.ResultOfDiscussion = txtResultOfDiscussion.Text;
            _fish.Discussdate= dtpDiscussdate.Value;
            _fish.PersonAgreesToSign= txtPersonAgreesToSign.Text;
            _fish.Remarks = txtRemarks.Text;
            _fish.Modifytime = DateTime.Now;
            _fish.Modifyman = FishEntity.Variable.User.username; ;
            FishBll.Bll.DisposeofcommentsBll bll = new FishBll.Bll.DisposeofcommentsBll();
            bool isok = bll.Update(_fish);
            if (isok)
            {
                MessageBox.Show("修改成功。");
            }
            else
            {
                MessageBox.Show("修改失败。");
            }
            return 1;
        }
        public override int Query()
        {
            if (_Dis == null)
            {
                _Dis = new UIForms.FormDisposeofcommentsCodition();
                _Dis.StartPosition = FormStartPosition.CenterParent;
                _Dis.ShowInTaskbar = false;
            }
            if (_Dis.ShowDialog() != System.Windows.Forms.DialogResult.OK) return 0;
            _where = _Dis.GetWhereCondition;
            List<FishEntity.DisposeofcommentsEntity> list = _DisBll.GetModelList(_where + _rolewhere + _orderBy);
            if (list == null || list.Count < 1)
            {
                _fish = null;
                MessageBox.Show("暂无数据！");
                return 0;
            }
            else
            {
                _fish = list[0];
                SetDisposeofcomments();
                panel1.Enabled = true;
                return 1;
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
            txtFilenumber.Text = string.Empty;
            txtTodealwith.Text = string.Empty;
            txtTreatmentmeasures.Text = string.Empty;
            txtDepartmentManagerOpinion.Text = string.Empty;
            dtpManagerdate.Value = DateTime.Now;
            txtCompanyOpinion.Text = string.Empty;
            dtpCompanydate.Value = DateTime.Now;
            txtResultOfDiscussion.Text = string.Empty;
            dtpDiscussdate.Value = DateTime.Now;
            txtPersonAgreesToSign.Text = string.Empty;
            txtRemarks.Text = string.Empty;

            return 1;
        }
        public override void Save()
        {
            FishEntity.DisposeofcommentsEntity _Dis = new FishEntity.DisposeofcommentsEntity();
            _Dis.Code= FishBll.Bll.SequenceUtil.GetDisposeofcomments();
            _Dis.Filenumber = txtFilenumber.Text;
            _Dis.Todealwith = txtTodealwith.Text;
            _Dis.Treatmentmeasures = txtTreatmentmeasures.Text;
            _Dis.DepartmentManagerOpinion = txtDepartmentManagerOpinion.Text;
            _Dis.Managerdate = dtpManagerdate.Value;
            _Dis.CompanyOpinion = txtCompanyOpinion.Text;
            _Dis.Companydate = dtpCompanydate.Value;
            _Dis.ResultOfDiscussion = txtResultOfDiscussion.Text;
            _Dis.Discussdate = dtpDiscussdate.Value;
            _Dis.PersonAgreesToSign = txtPersonAgreesToSign.Text;
            _Dis.Remarks = txtRemarks.Text;
            _Dis.Createtime = DateTime.Now;
            _Dis.Createman = FishEntity.Variable.User.username;
            _Dis.Modifytime = DateTime.Now;
            _Dis.Modifyman = FishEntity.Variable.User.username;
            FishBll.Bll.DisposeofcommentsBll bll = new FishBll.Bll.DisposeofcommentsBll();
            bool isok = bll.Exists(_Dis.Code);
            while (isok)
            {
                _Dis.Code = FishBll.Bll.SequenceUtil.GetDisposeofcomments();
                isok = bll.Exists(_Dis.Code);
            }
            int id = bll.Add(_Dis);
            if (id > 0)
            {
                _Dis.Id = id;
                tmiQuery.Visible = false;
                tmiDelete.Visible = false;
                tmiModify.Visible = false;
                tmiAdd.Visible = false;
                tmiSave.Visible = true;
                tmiCancel.Visible = true;
                MessageBox.Show("添加成功。");
                txtcode.Text = _Dis.Code;
            }
            else
            {
                txtcode.Text = _Dis.Code;
                MessageBox.Show("添加失败。");
            }
        }
        protected void SetDisposeofcomments()
        {
            txtcode.Text = _fish.Code;
            txtFilenumber.Text = _fish.Filenumber;
            txtTodealwith.Text = _fish.Todealwith;
            txtTreatmentmeasures.Text = _fish.Treatmentmeasures;
            txtDepartmentManagerOpinion.Text = _fish.DepartmentManagerOpinion;
            dtpManagerdate.Value = _fish.Managerdate.Value;
            txtCompanyOpinion.Text = _fish.CompanyOpinion;
            dtpCompanydate.Value = _fish.Companydate.Value;
            txtResultOfDiscussion.Text = _fish.ResultOfDiscussion;
            dtpDiscussdate.Value = _fish.Discussdate.Value;
            txtPersonAgreesToSign.Text = _fish.PersonAgreesToSign;
            txtRemarks.Text = _fish.Remarks;
        }

        private void FormDisposeofcomments_Load(object sender, EventArgs e)
        {
            _rolewhere = " and code='" + Megres.oddNum + "'";
            List<FishEntity.DisposeofcommentsEntity> list = _DisBll.GetModelList(_where + _rolewhere + _orderBy);
            Megres.oddNum = string.Empty;
            if (list == null || list.Count < 1)
            {
                _fish = null;
                MessageBox.Show("暂无数据！");
            }
            else
            {
                _fish = list[0];
                SetDisposeofcomments();
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
    }
}
