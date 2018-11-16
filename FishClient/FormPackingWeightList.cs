using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormPackingWeightList : FormMenuBase
    {
        FishEntity.PackingWeightListEntity _List = null;
        FishBll.Bll.PackingWeightListBll _bll = new FishBll.Bll.PackingWeightListBll();
        string num1, num2 = string.Empty;
        public FormPackingWeightList(string WarehouseCode, string FishId)
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            if (WarehouseCode!=string.Empty&&WarehouseCode!=null&&FishId!=string.Empty&&FishId!=null)
            {
                num1 = WarehouseCode;num2 = FishId;
            }
            tmiAdd.Visible = true;
            tmiQuery.Visible = true;
            tmiModify.Visible = false;
            tmiDelete.Visible = false;
            tmiReview.Visible = false;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;
            tmiExport.Visible = false;
            tmiNext.Visible = false;
            tmiPrevious.Visible = false;
            tmiClose.Visible = true;
            Query();
        }
        public override int Add()
        {
            tmiAdd.Visible = false;
            tmiQuery.Visible = false;
            tmiModify.Visible = false;
            tmiDelete.Visible = false;
            tmiReview.Visible = false;
            tmiSave.Visible = true;
            tmiCancel.Visible = true;
            tmiExport.Visible = false;
            tmiNext.Visible = false;
            tmiPrevious.Visible = false;
            tmiClose.Visible = false;

            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.ReadOnly = false;

            return base.Add();
        }
        public override int Query()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;

            tmiAdd.Visible = true;
            tmiQuery.Visible = true;
            tmiModify.Visible = true;
            tmiDelete.Visible = true;
            tmiReview.Visible = false;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;
            tmiExport.Visible = false;
            tmiNext.Visible = false;
            tmiPrevious.Visible = false;
            tmiClose.Visible = true;

            List<FishEntity.PackingWeightListEntity> ModelList = _bll.getList(num1,num2);
            if (ModelList != null)
            {
                dataGridView1.Rows.Clear();
                foreach (FishEntity.PackingWeightListEntity list in ModelList)
                {
                    int idx = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[idx];
                    row.Cells["id"].Value = list.Id;
                    row.Cells["WarehouseCode"].Value = list.WarehouseCode;
                    row.Cells["FishId"].Value = list.FishId;
                    row.Cells["CONTANERNO"].Value = list.CNOTANERNO;
                    row.Cells["QUANTITYOFBAGS"].Value = list.QUANTITYOFBAGS;
                    row.Cells["GROSSWEIGHT"].Value = list.GROSSWEIGHT;
                    row.Cells["NETWEIGHT"].Value = list.NETWEIGHT;
                }
            }

            return base.Query();
        }
        public override void Save()
        {
            dataGridView1.EndEdit();
            List<FishEntity.PackingWeightListEntity> ModelList = new List<FishEntity.PackingWeightListEntity>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }
                _List = new FishEntity.PackingWeightListEntity();
                _List.WarehouseCode = num1; //row.Cells["WarehouseCode"].Value == null ? string.Empty : row.Cells["WarehouseCode"].Value.ToString();
                _List.FishId = num2; //row.Cells["FishId"].Value == null ? string.Empty : row.Cells["FishId"].Value.ToString();
                _List.CNOTANERNO = row.Cells["CONTANERNO"].Value == null ? string.Empty : row.Cells["CONTANERNO"].Value.ToString();
                _List.QUANTITYOFBAGS = row.Cells["QUANTITYOFBAGS"].Value == null ? string.Empty : row.Cells["QUANTITYOFBAGS"].Value.ToString();
                _List.GROSSWEIGHT=row.Cells["GROSSWEIGHT"].Value == null ? string.Empty : row.Cells["GROSSWEIGHT"].Value.ToString();
                _List.NETWEIGHT = row.Cells["NETWEIGHT"].Value == null ? string.Empty : row.Cells["NETWEIGHT"].Value.ToString();
                //_List.Createman=_List.Modifyman = FishEntity.Variable.User.username;
                //_List.Createtime = _List.Createtime =DateTime.Now;
                ModelList.Add(_List);
            }
            if (ModelList == null)
                return;
            bool result = _bll.add(ModelList);
            if (result == true)
            {
                MessageBox.Show("保存成功");

                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ReadOnly = true;

                tmiAdd.Visible = true;
                tmiQuery.Visible = true;
                tmiModify.Visible = false;
                tmiDelete.Visible = false;
                tmiReview.Visible = false;
                tmiSave.Visible = false;
                tmiCancel.Visible = false;
                tmiExport.Visible = false;
                tmiNext.Visible = false;
                tmiPrevious.Visible = false;
                tmiClose.Visible = true;
            }
            else
                MessageBox.Show("保存失败,请重试");

            base.Save();
        }
        public override int Modify()
        {
            tmiAdd.Visible = false;
            tmiQuery.Visible = false;
            tmiModify.Visible = false;
            tmiDelete.Visible = false;
            tmiReview.Visible = false;
            tmiSave.Visible = true;
            tmiCancel.Visible = true;
            tmiExport.Visible = false;
            tmiNext.Visible = false;
            tmiPrevious.Visible = false;
            tmiClose.Visible = false;

            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.ReadOnly = false;

            return base.Modify();
        }
        public override void Cancel()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;

            tmiAdd.Visible = true;
            tmiQuery.Visible = true;
            tmiModify.Visible = false;
            tmiDelete.Visible = false;
            tmiReview.Visible = false;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;
            tmiExport.Visible = false;
            tmiNext.Visible = false;
            tmiPrevious.Visible = false;
            tmiClose.Visible = true;

            base.Cancel();
        }
    }
}
