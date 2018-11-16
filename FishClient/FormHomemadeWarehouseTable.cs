using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormHomemadeWarehouseTable : FormMenuBase
    {
        FishBll.Bll.HomemadeStorageBll _bll = new FishBll.Bll.HomemadeStorageBll();
        List<FishEntity.HomemadeStorageEntity> _list = new List<FishEntity.HomemadeStorageEntity>();
        public FormHomemadeWarehouseTable()
        {
            InitializeComponent();
        }
        public override int Query()
        {
            string strwhere = " 1=1 ";
            if (!string.IsNullOrEmpty(txtCode.Text))
            {
                strwhere += "and code like '%"+ txtCode.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtFishCode.Text))
            {
                strwhere += " and productid like '%"+txtFishCode.Text+"%'";
            }
            if (!string.IsNullOrEmpty(txtSeq.Text))
            {
                strwhere += "and seq like '%"+txtSeq.Text+"%'";
            }
            _list = _bll.GetModelList(strwhere);
            if (_list != null)
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = _list;
            }
            else
            {
                MessageBox.Show("查无数据！");
            }
            return base.Query();
        }
    }
}
