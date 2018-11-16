using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormJinCangTable : FormMenuBase
    {
        List<FishEntity.EnterWarehouseReceipts> GetList = new List<FishEntity.EnterWarehouseReceipts>();
        private FishBll.Bll.EnterWarehouseReceiptsBll _bll = new FishBll.Bll.EnterWarehouseReceiptsBll();
        public FormJinCangTable()
        {
            InitializeComponent();
        }
        public override int Query()
        {
            string strwhere = " 1=1 ";
            if (!string.IsNullOrEmpty(txtcode.Text))
            {
                strwhere += " and code like '%"+txtcode.Text+"%'"; 
            }
            strwhere += string.Format(" and Unpackingdate>='{0}' and Unpackingdate<='{1}'",
                dtpbefore.Value.ToString("yyyy-MM-dd 00:00:00"),
                dtpRear.Value.ToString("yyyy-MM-dd 23:59:59"));
            GetList = _bll.GetModelListVo(strwhere);
            if (GetList != null)
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = GetList;
            }
            else {
                MessageBox.Show("查无数据!");
            }
            return base.Query();
        }

        private void txtRequester_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtRequester.Text = form.SelectCompany.fullname;
            txtRequester.Tag = form.SelectCompany;
        }
    }
}
