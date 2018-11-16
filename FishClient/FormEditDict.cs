using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormEditDict : Form
    {
        public event Action<EventArgs> RefreshEvent = null;
        FishEntity.DictEntity _entity = null;
        FishEntity.DataTypeEnum _dataType = FishEntity.DataTypeEnum.SYSTEM;

        public FormEditDict( string title ,FishEntity.DataTypeEnum dataType , FishEntity.DictEntity entity)
        {
            InitializeComponent();

            _dataType = dataType;
            cmbType.DisplayMember = "Name";
            cmbType.ValueMember = "Code";

            if (_dataType == FishEntity.DataTypeEnum.SYSTEM)
            {
                cmbType.DataSource = FishEntity.Variable.SystemDataTypeList;
            }
            else
            {
                cmbType.DataSource = FishEntity.Variable.ProductDataTypeList;
            }

            _entity = entity;//修改
            if (_entity != null)
            {
                txtCode .Text = _entity.code;
                txtName.Text = _entity.name;
                cmbType.SelectedValue = _entity.pcode;
                numericUpDown1.Value = _entity.orderid.GetValueOrDefault();
                txtRemark.Text = _entity.remark;
                cmbPid.SelectedValue = _entity.pid;
            }
            this.Text = title;
        }

        protected bool Check()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                txtName.Focus();
                    MessageBox.Show("请输入名称");
                    return false;
            }
            if (cmbType.SelectedValue.ToString().Equals(FishEntity.Constant.Area))
            {
                if (cmbPid.SelectedValue == null)
                {
                    cmbPid.Focus();
                    MessageBox.Show("请选择父代码");
                    return false;
                }
            }

            return true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Check() == false)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

            bool isAdd = false;
            if (_entity == null)
            {
                _entity = new FishEntity.DictEntity();
                _entity.isdelete = 0;
                _entity.issystem = _dataType == FishEntity.DataTypeEnum.SYSTEM ? 1 : 0;
                isAdd = true;
            }
            else
            {
                string code = txtCode.Text.Trim();
                if (_entity.code.Equals(code) == false)
                {
                    FishBll.Bll.DictBll bll = new FishBll.Bll.DictBll();
                    if (bll.Exists(code, cmbType.SelectedValue.ToString(), _entity.issystem))
                    {
                        MessageBox.Show("代码已经存在，请修改其他值。");
                        this.DialogResult = System.Windows.Forms.DialogResult.None;
                        return;
                    }
                }
            }
           
            _entity.code = txtCode.Text.Trim();
            _entity.name = txtName.Text.Trim();
            _entity.pcode = cmbType.SelectedValue.ToString();
            _entity.orderid = (int)numericUpDown1.Value;
            _entity.remark = txtRemark.Text.Trim();

            if (_entity.pcode.Equals(FishEntity.Constant.Area))
            {
                _entity.pid = int.Parse(cmbPid.SelectedValue.ToString());
            }
            else if (_entity.pcode.Equals(FishEntity.Constant.Brand))
            {
                _entity.pid = int.Parse(cmbPid.SelectedValue.ToString());
            }
            else
            {
                _entity.pid = 0;
            }

            if ( isAdd )
            {   
                FishBll.Bll.DictBll bll = new FishBll.Bll.DictBll();
                if (bll.Exists(_entity.code , _entity.pcode , _entity.issystem ))
                {
                    MessageBox.Show("代码已经存在，请修改其他值。");
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                    return;
                }

               bool isOk =  bll.Add(_entity);
               if (isOk) OnRefresh();
            }
            else
            {
                FishBll.Bll.DictBll bll = new FishBll.Bll.DictBll();
                bool isOk = bll.Update(_entity);
                if (isOk)
                {
                    OnRefresh();
                }
            }

            InitDataUtil.DictList = null;

        }

        protected void OnRefresh()
        {
            if (RefreshEvent != null)
            {
                RefreshEvent(EventArgs.Empty);
            }
        }

        private void cmbType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedValue == null) return;

            string type = cmbType.SelectedValue.ToString();
            if (type == FishEntity.Constant.Area)
            {
                panel1.Visible = true;
                SetProvince();
            }
            else if (type == FishEntity.Constant.Brand)
            {
                panel1.Visible = true;
                SetBrand();
            }
            else
            {
                panel1.Visible = false;
            }
        }
        ///两级联动
        ///
        protected void SetProvince()
        {
            List<FishEntity.DictEntity> list = InitDataUtil.DictList.FindAll((i) => { return i.pcode.Equals(FishEntity.Constant.Province); });
            cmbPid.ValueMember = "id";
            cmbPid.DisplayMember = "name";
            cmbPid.DataSource = list;
        }
        protected void SetBrand()
        {
            List<FishEntity.DictEntity> list = InitDataUtil.DictList.FindAll((i) => { return i.pcode.Equals(FishEntity.Constant.CountryType); });
            cmbPid.ValueMember = "id";
            cmbPid.DisplayMember = "name";
            cmbPid.DataSource = list;
        }     
    }
}
