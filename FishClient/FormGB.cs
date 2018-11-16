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
    /// 国标检测
    /// </summary>
    public partial class FormGB : FormMenuBase
    {
        private FishBll.Bll.CheckBll _bll = new FishBll.Bll.CheckBll();
        private string _where = string.Empty;
        private FishEntity.CheckEntity _entity = null;
        private List<FishEntity.DictEntity> _columns = null;

        public FormGB()
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_GB");
            tmiExport.Visible = false;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;
            dataGridView1.BackgroundColor = this.BackColor;
            InitDataGridViewColumns();
        }

        protected void InitDataGridViewColumns()
        {
            dataGridView1.Columns.Clear();
            if (FishEntity.Variable.ProductDataTypeList == null) return;
            FishEntity.SystemDataType checkType = FishEntity.Variable.ProductDataTypeList.Find((i) => { return i.Code == FishEntity.Constant.CheckItem; });
            if (checkType == null) return;

            FishBll.Bll.DictBll bll = new FishBll.Bll.DictBll();
            _columns = bll.GetModelList(string.Format(" isdelete=0 and issystem=0 and pcode='{0}' order by pcode asc,orderid asc", checkType.Code));
            if (_columns == null || _columns.Count < 1) return;

            try
            {
                DataGridViewColumn col = null;

                foreach (FishEntity.DictEntity item in _columns)
                {
                    col = new DataGridViewTextBoxColumn();
                    col.HeaderText = item.name;
                    col.Name = item.code;
                    col.Width = 80;
                    dataGridView1.Columns.Add(col);

                    col = new DataGridViewTextBoxColumn();
                    col.HeaderText = item.name + "_id";
                    col.Name = item.code + "_id";
                    col.Visible = false;
                    dataGridView1.Columns.Add(col);
                }

                col = new DataGridViewTextBoxColumn();
                col.Name = "id";
                col.HeaderText = "id";
                dataGridView1.Columns.Add(col);
                col.Visible = false;

                col = new DataGridViewTextBoxColumn();
                col.Name = "line";
                col.HeaderText = "line";
                col.Visible = false;
                dataGridView1.Columns.Add(col);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            UIForms.FormSelectFish form = new UIForms.FormSelectFish(-1);
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectedProduct == null) return;

            txtFishCode.Text = form.SelectedProduct.code;
            txtFishCode.Tag = form.SelectedProduct.id;
            txtFishName.Text = form.SelectedProduct.name;

        }

        private void txtCheckUnit_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtCheckUnitCode.Text = form.SelectCompany.code;
            txtCheckUnit.Text = form.SelectCompany.fullname;
            txtCheckUnitCode.Tag = form.SelectCompany.id;
        }

        public override int Query()
        {
            QueryOne(">", " order by id asc limit 1");
            return 1;
        }
        
        public override void Previous()
        {
            QueryOne(" < ", " order by id desc limit 1");
        }

        public override void Next()
        {
            QueryOne(" > ", " order by id asc limit 1");
        }

        protected void QueryOne(string operate, string orderBy)
        {
            errorProvider1.Clear();
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

            List<FishEntity.CheckEntity> list = _bll.GetModelList(whereEx + orderBy);
            if (list == null || list.Count < 1)
            {
                MessageBox.Show("已经没有记录了!");
                return;
            }

            _entity = list[0];

            SetEntity();
            SetDetail();
        }

        protected void SetEntity()
        {
            if (_entity == null) return;

            txtCode.Text = _entity.code;
            txtCheckUnit.Text = _entity.checkunit;
            txtCheckUnitCode.Text = _entity.checkunitcode;
            txtCheckUnitCode.Tag = _entity.checkunitid;

            txtFishCode.Text = _entity.productcode;
            txtFishCode.Tag = _entity.productid;
            txtFishName.Text = _entity.productname;
            txtCheckFee.Text = _entity.checkfee.ToString();
            txtCode.Text = _entity.code;
            dtpCheckDate.Value = _entity.checkdate;
        }

        protected void SetDetail()
        {
            int mid = _entity.id;
            FishBll.Bll.CheckDetailBll detailbll = new FishBll.Bll.CheckDetailBll();
            List<FishEntity.CheckDetailEntity> details = detailbll.GetModelList("mid=" + mid);
            SetDetail(details);
        }

        protected void SetDetail(List<FishEntity.CheckDetailEntity> details)
        {
            dataGridView1.Rows.Clear();
            if (details == null || details.Count < 1) return;

            SortedDictionary<int, List<FishEntity.CheckDetailEntity>> lines = Group(details);

            foreach (KeyValuePair<int, List<FishEntity.CheckDetailEntity>> item in lines)
            {
                int idx = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[idx];
                row.Cells["line"].Value = item.Key;

                foreach (FishEntity.CheckDetailEntity child in item.Value)
                {
                    FishEntity.DictEntity dict = _columns.Find((i) => { return i.code.Equals(child.checkkey); });
                    if (dict == null) continue;

                    if (dataGridView1.Columns.Contains(child.checkkey + "_id"))
                    {
                        row.Cells[child.checkkey + "_id"].Value = child.id;
                    }
                    if (dataGridView1.Columns.Contains(child.checkkey))
                    {
                        row.Cells[child.checkkey].Value = child.checkvalue;
                    }
                }
            }
        }

        protected SortedDictionary<int, List<FishEntity.CheckDetailEntity>> Group(List<FishEntity.CheckDetailEntity> details)
        {
            SortedDictionary<int, List<FishEntity.CheckDetailEntity>> lines = new SortedDictionary<int, List<FishEntity.CheckDetailEntity>>();
            foreach (FishEntity.CheckDetailEntity item in details)
            {
                if (lines.ContainsKey(item.line) == false)
                {
                    List<FishEntity.CheckDetailEntity> array = new List<FishEntity.CheckDetailEntity>();
                    array.Add(item);
                    lines.Add(item.line, array);
                }
                else
                {
                    List<FishEntity.CheckDetailEntity> array = lines[item.line];
                    array.Add(item);
                }
            }
            return lines;
        }

        protected bool Check()
        {
            errorProvider1.Clear();
            bool isok = true;
            if (string.IsNullOrEmpty(txtCheckUnit.Text))
            {
                errorProvider1.SetError(txtCheckUnit, "请选择检测单位。");
                isok = false;
            }

            if (string.IsNullOrEmpty(txtFishName.Text))
            {
                errorProvider1.SetError(txtFishName, "请选择鱼粉ID。");
                isok = false;
            }

            decimal fee = 0;
            if (false == string.IsNullOrEmpty(txtCheckFee.Text))
            {
                if (false == decimal.TryParse(txtCheckFee.Text, out fee))
                {
                    isok = false;
                    errorProvider1.SetError(txtCheckFee, "请输入正确的数字。");
                }
            }

            if (dataGridView1.Rows.Count < 1)
            {
                isok = false;
                errorProvider1.SetError(dataGridView1, "请输入明细。");
            }

            bool hasDetails = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                hasDetails = true; 
            }
            if (hasDetails == false)
            {
                errorProvider1.SetError(dataGridView1, "请输入明细。");
                MessageBox.Show("请输入检测指标明细。");
                isok = false;
            }


            return isok;
        }

        public override void Save()
        {
            if (Check() == false) return ;
            _entity = new FishEntity.CheckEntity();

            GetEntity();

            _entity.createman = FishEntity.Variable.User.username;
            _entity.createtime = DateTime.Now;
            _entity.modifyman = _entity.createman;
            _entity.modifytime = _entity.createtime;

            _entity.code = FishBll.Bll.SequenceUtil.GetCheckSequence();
            while (_bll.Exists(_entity.code))
            {
                _entity.code = FishBll.Bll.SequenceUtil.GetCheckSequence();
            }
            int id = _bll.Add(_entity);
            if (id > 0)
            {
                AddDetails(id, true);

                _entity.id = id;
                txtCode.Text = _entity.code;

                tmiCancel.Visible = false;
                tmiSave.Visible = false;
                tmiAdd.Visible = true;
                tmiModify.Visible = true;
                tmiQuery.Visible = true;
                tmiPrevious.Visible = true;
                tmiNext.Visible = true;
                tmiDelete.Visible = true;

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
            tmiSave.Visible = false;
            tmiCancel.Visible = false;
            tmiDelete.Visible = true;
            tmiQuery.Visible = true;
            tmiPrevious.Visible = true;
            tmiNext.Visible = true;
            tmiModify.Visible = true;
            tmiAdd.Visible = true;
            errorProvider1.Clear();
        }

        protected void AddDetails(int mid, bool isAdd)
        {
            List<FishEntity.CheckDetailEntity> listNews = GetDetails(mid);
            List<FishEntity.CheckDetailEntity> listsource = null;
            FishBll.Bll.CheckDetailBll detailBll = new FishBll.Bll.CheckDetailBll();

            if (isAdd == false)
            {
                listsource = detailBll.GetModelList("mid=" + mid);
                if (listsource != null)
                {
                    foreach (FishEntity.CheckDetailEntity item in listsource)
                    {
                        bool isExist = listNews.Exists((i) => { return i.id == item.id; });
                        if (isExist == false)
                        {
                            bool isDelte = detailBll.Delete(item.id);
                        }
                    }
                }
            }

            foreach (FishEntity.CheckDetailEntity item in listNews)
            {
                if (item.id == 0)
                {
                    int detailId = detailBll.Add(item);
                    if (detailId > 0)
                    {
                        item.id = detailId;
                    }
                }
                else
                {
                    detailBll.Update(item);
                }
            }
        }

        protected void GetEntity()
        {
            if (_entity == null) return;

            _entity.checkdate = dtpCheckDate.Value;
            decimal fee = 0;
            decimal.TryParse(txtCheckFee.Text, out fee);
            _entity.checkfee = fee;
            int id = 0;
            int.TryParse(txtCheckUnitCode.Tag.ToString(), out id);
            _entity.checkunitid = id;
            _entity.checkunitcode = txtCheckUnitCode.Text;
            _entity.checkunit = txtCheckUnit.Text.Trim();
            int.TryParse(txtFishCode.Tag.ToString(), out id);
            _entity.productid = id;
            _entity.productcode = txtFishCode.Text;
            _entity.productname = txtFishName.Text;
        }

        protected List<FishEntity.CheckDetailEntity> GetDetails(int mid)
        {
            if (_columns == null) return null;

            dataGridView1.EndEdit();

            List<FishEntity.CheckDetailEntity> listNews = new List<FishEntity.CheckDetailEntity>();
            int lineidx = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                //int did = 0;
                //if (row.Cells["id"].Value != null)
                //{
                //    int.TryParse(row.Cells["id"].Value.ToString(), out did);
                //}               

                lineidx = row.Index;

                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    string colname = dataGridView1.Columns[i].Name;
                    FishEntity.DictEntity check = _columns.Find(k => { return k.code.Equals(colname); });
                    if (check == null) continue;

                    string value = row.Cells[check.code].Value == null ? string.Empty : row.Cells[check.code].Value.ToString();

                    int did = 0;
                    if (row.Cells[check.code + "_id"].Value != null)
                    {
                        int.TryParse(row.Cells[check.code + "_id"].Value.ToString(), out did);
                    }

                    FishEntity.CheckDetailEntity item = new FishEntity.CheckDetailEntity();
                    item.mid = mid;
                    item.id = did;
                    item.checkkey = check.code;
                    item.checkvalue = value;
                    item.line = lineidx;
                    item.orderid = dataGridView1.Columns[i].Index;
                    listNews.Add(item);
                }
            }

            return listNews;
        }

        public override int Delete()
        {
            if (_entity == null) return 0;

            string msg = string.Format("你确定要删除检测单号为【{0}】的记录吗?", _entity.code);
            if (MessageBox.Show(msg, "询问", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return 0;

            _bll.Delete(_entity.id);
            FishBll.Bll.CheckDetailBll detailbll = new FishBll.Bll.CheckDetailBll();

            detailbll.DeleteByMid(_entity.id);

            ClearText();

            Query();

            return 1;
        }

        protected void ClearText()
        {
            errorProvider1.Clear();
            txtCode.Text = string.Empty;
            txtCheckUnit.Text = string.Empty;
            txtCheckUnitCode.Text = string.Empty;
            txtCheckUnitCode.Tag = string.Empty;
            txtFishCode.Text = string.Empty;
            txtFishCode.Tag = string.Empty;
            txtFishName.Text = string.Empty;
            txtCheckFee.Text = string.Empty;
            dtpCheckDate.Value = DateTime.Now;
            dataGridView1.Rows.Clear();
            _entity = null;
        }

        public override int Modify()
        {
            if (_entity == null)
            {
                return 0;
            }
            if (Check() == false) return 0;

            GetEntity();
                 
            _entity.modifyman = FishEntity.Variable.User.username;
            _entity.modifytime = DateTime.Now;

            bool isok = _bll.Update(_entity);
            if (isok)
            {
                AddDetails(_entity.id, false);

                MessageBox.Show("修改成功。");
            }
            else
            {
                MessageBox.Show("修改失败。");
            }


            return 1;
        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_GB");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_GB");
        }
        protected void ReadColumnConfig(DataGridView dgv, string section)
        {
            string path = Application.StartupPath + "\\listconfig.ini";
            if (System.IO.File.Exists(path) == true)
            {
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    string wstr = Utility.IniUtil.ReadIniValue(path, section, col.HeaderText);
                    int w = 0;
                    if (int.TryParse(wstr, out w))
                    {
                        col.Width = w;
                    }
                }
            }
        }

    }
}
