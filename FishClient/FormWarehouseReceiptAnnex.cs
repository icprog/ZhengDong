using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormWarehouseReceiptAnnex : FormMenuBase
    {
        int selectIdx = 0;
        string getname = string.Empty;
        FishEntity.PicInfoAll _pic = null;
        FishBll.Bll.WarehouseReceiptBll _bll = null;
        public FormWarehouseReceiptAnnex()
        {
            InitializeComponent();
        }
        public override int Query()
        {
            List<FishEntity.PicInfoAll> dicPic = new List<FishEntity.PicInfoAll>();
            _bll = new FishBll.Bll.WarehouseReceiptBll();
            dicPic=_bll.GetModel(int.Parse(txtid.Text), this.Name);
            if (dicPic == null || dicPic.Count < 1)
            {

            }
            else
            {
                setValue(dicPic);
            }
            return base.Query();
        }
        public FormWarehouseReceiptAnnex(string code,int id,string name)
        {
            InitializeComponent();
            if (code==""||id.ToString()==""||name=="")
            {   
                return;
            }
            txtcode.Text = code;txtid.Text = id.ToString();getname = name;
            List<FishEntity.PicInfoAll> dicPic = new List<FishEntity.PicInfoAll>();
            _bll = new FishBll.Bll.WarehouseReceiptBll();
            dicPic=_bll.GetModel(id, this.Name);
            if (dicPic == null || dicPic.Count < 1)
            {

            }
            else
            {
                setValue(dicPic);
            }
        }
        public override void Save()
        {
            List<FishEntity.PicInfoAll> dicPic = getValueView();
            int idx = 0;
            idx = _bll.Add(txtid.Text, dicPic, this.Name);
            if (idx > 0)
            {
                MessageBox.Show("成功保存");
                txtcode.Tag = idx;
                tmiSave.Visible = false;
            }
            else
                MessageBox.Show("保存失败");

            base.Save();
        }
        List<FishEntity.PicInfoAll> getValueView()
        {
            List<FishEntity.PicInfoAll> dicpic = new List<FishEntity.PicInfoAll>();
            dataGridView1.EndEdit();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                FishEntity.PicInfoAll entity = new FishEntity.PicInfoAll();
                entity.tableId = txtcode.Tag == null ? 0 : Convert.ToInt32(txtcode.Tag);
                entity.tableName = this.Name;
                entity.picInfo = dataGridView1.Rows[i].Cells["picInfo"].Value == null ? new byte[0] : (byte[])dataGridView1.Rows[i].Cells["picInfo"].Value;
                entity.categroy = dataGridView1.Rows[i].Cells["categroy"].Value == null ? string.Empty : dataGridView1.Rows[i].Cells["categroy"].Value.ToString();
                entity.remark = dataGridView1.Rows[i].Cells["remark"].Value == null ? string.Empty : dataGridView1.Rows[i].Cells["remark"].Value.ToString();
                dicpic.Add(entity);
            }

            return dicpic;
        }
        void setValue(List<FishEntity.PicInfoAll> dicPic)
        {
            dataGridView1.Rows.Clear();
            foreach (FishEntity.PicInfoAll entity in dicPic)
            {
                int idx = dataGridView1.Rows.Add();
                dataGridView1.Rows[idx].Cells["tableId"].Value = entity.tableId;
                dataGridView1.Rows[idx].Cells["tableName"].Value = entity.tableName;
                dataGridView1.Rows[idx].Cells["picInfo"].Value = entity.picInfo;
                dataGridView1.Rows[idx].Cells["categroy"].Value = entity.categroy;
                dataGridView1.Rows[idx].Cells["remark"].Value = entity.remark;
            }
        }
        public override int Modify()
        {
            List<FishEntity.PicInfoAll> dicPic = getValueView();
            int id = _bll.Update(txtid.Text, dicPic, this.Name);
            if (id > 0)
                MessageBox.Show("成功保存");
            else
                MessageBox.Show("保存失败");
            return base.Modify();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtLeiBie.Text))
            {
                errorProvider1.SetError(txtLeiBie, "请选择类别");
                return;
            }

            _pic = new FishEntity.PicInfoAll();
            _pic.tableId = txtcode.Tag == null ? 0 : Convert.ToInt32(txtcode.Tag);
            _pic.picInfo = PictureOpreation.ReadPicture(pic);
            _pic.tableName = this.Name;
            _pic.categroy = txtLeiBie.Text;
            //_pic.remark = txtBeiZhu.Text;
            int idx = dataGridView1.Rows.Add();
            dataGridView1.Rows[idx].Cells["tableId"].Value = _pic.tableId;
            dataGridView1.Rows[idx].Cells["tableName"].Value = _pic.tableName;
            dataGridView1.Rows[idx].Cells["picInfo"].Value = _pic.picInfo;
            dataGridView1.Rows[idx].Cells["categroy"].Value = _pic.categroy;
            //dataGridView1.Rows[idx].Cells["remark"].Value = _pic.remark;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtLeiBie.Text))
            {
                errorProvider1.SetError(txtLeiBie, "请选择类别");
                return;
            }
            _pic = new FishEntity.PicInfoAll();
            _pic.tableId = txtcode.Tag == null ? 0 : Convert.ToInt32(txtcode.Tag);
            _pic.picInfo = PictureOpreation.ReadPictureToByte(pic);
            _pic.tableName = this.Name;
            _pic.categroy = txtLeiBie.Text;
            //_pic.remark = txtBeiZhu.Text;

            dataGridView1.Rows[selectIdx].Cells["picInfo"].Value = _pic.picInfo;
            dataGridView1.Rows[selectIdx].Cells["categroy"].Value = _pic.categroy;
            //dataGridView1.Rows[selectIdx].Cells["remark"].Value = _pic.remark;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(selectIdx);
            pic.Image = null;
            //txtBeiZhu.Text = txtLeiBie.Text = string.Empty;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            selectIdx = e.RowIndex;
            txtLeiBie.Text = dataGridView1.Rows[e.RowIndex].Cells["categroy"].Value.ToString();
            pic.Image = PictureOpreation.ReadPicture(dataGridView1.Rows[e.RowIndex].Cells["picInfo"].Value == null ? null : (byte[])dataGridView1.Rows[e.RowIndex].Cells["picInfo"].Value);
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            selectIdx = e.RowIndex;
            txtLeiBie.Text = dataGridView1.Rows[e.RowIndex].Cells["categroy"].Value.ToString();
            pic.Image = PictureOpreation.ReadPicture(dataGridView1.Rows[e.RowIndex].Cells["picInfo"].Value == null ? null : (byte[])dataGridView1.Rows[e.RowIndex].Cells["picInfo"].Value);
        }

        private void pic_Click(object sender, EventArgs e)
        {
            UIForms.FormZoomImage form = new UIForms.FormZoomImage(pic.Image);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowInTaskbar = false;
            form.ShowDialog();
        }
    }
}
