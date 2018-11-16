using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormAddFunCode : FormBase
    {
        public FishBll.Bll.FunCodeBll _bll = new FishBll.Bll.FunCodeBll();
        public event EventHandler RefreshData = null;
        public FishEntity.FunCodeEntity _funcode = null;

        public FormAddFunCode(FishEntity.FunCodeEntity funcode)
        {
            InitializeComponent();

            SetButtomImage(btnOk);
            SetButtomImage(btnCancel);

            BindFuncode();

            _funcode = funcode;

            if (_funcode != null)
            {
                txtcode.Text = _funcode.funcode;
                txtFunName.Text = _funcode.funname;
                ckbenable.Checked = _funcode.enable == 1;
                txtRemark.Text = _funcode.remark;
                rdbmenu.Checked = _funcode.type == 0;
                rdbbutton.Checked = _funcode.type == 1;
                cmbMenus.SelectedValue = _funcode.pid;
                numericUpDown1.Value = _funcode.sortid;

                this.Text = "修改功能";
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcode.Text) == true)
            {
                MessageBox.Show("请输入功能代码");
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            if ( string.IsNullOrEmpty( txtFunName.Text) ==true )
            {
                MessageBox.Show("请输入功能名称");
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

            if ( _funcode == null)
            {
                FishEntity.FunCodeEntity entity = new FishEntity.FunCodeEntity();
                entity.funcode = txtcode.Text.Trim();
                entity.funname = txtFunName.Text.Trim();
                entity.remark = txtRemark.Text.Trim();
                entity.enable = ckbenable.Checked ? 1 : 0;
                entity.type = rdbmenu.Checked ? 0 : 1;
                entity.pid = int.Parse(cmbMenus.SelectedValue.ToString());
                entity.sortid = (int)numericUpDown1.Value;

                bool isexist = _bll.Exists(entity.funcode);
                if (isexist)
                {
                    MessageBox.Show("代码重复，请重新输入。");
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                    return;
                }

                _bll.Add(entity);
                MessageBox.Show("添加成功");
            }
            else
            {
                string newcode = txtcode.Text.Trim();
                if (newcode.Equals(_funcode.funcode) == false)
                {
                    bool isexist = _bll.Exists(newcode);
                    if (isexist)
                    {
                        MessageBox.Show("代码重复，请重新输入。");
                        this.DialogResult = System.Windows.Forms.DialogResult.None;
                        return;
                    }
                }

                _funcode.funcode = txtcode.Text.Trim();
                _funcode.funname = txtFunName.Text.Trim();
                _funcode.remark = txtRemark.Text.Trim();
                _funcode.enable = ckbenable.Checked ? 1 : 0;
                _funcode.type = rdbmenu.Checked ? 0 : 1;
                _funcode.pid = int.Parse(cmbMenus.SelectedValue.ToString());
                _funcode.sortid = (int)numericUpDown1.Value;

                _bll.Update(_funcode);
                MessageBox.Show("修改成功");
            }

            if (RefreshData != null)
            {
                RefreshData(this, EventArgs.Empty);
            }
        }


        private void BindFuncode()
        {
            List<FishEntity.FunCodeEntity> data = _bll.GetModelList("pid=0 order by sortid asc");

            if (data == null )
            {
                data = new List<FishEntity.FunCodeEntity>();
            }

            FishEntity.FunCodeEntity empty = new FishEntity.FunCodeEntity();
            empty.funid = 0;
            empty.funname = "请选择父节点";
            data.Insert(0, empty);

            cmbMenus.DataSource = data;
            cmbMenus.DisplayMember = "funCodeAndName";
            cmbMenus.ValueMember = "funid";
        }
    
    }
}
