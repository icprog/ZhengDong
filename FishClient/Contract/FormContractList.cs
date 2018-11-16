using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient.Contract
{
    public partial class FormContractList : FormBase
    {
        private FishBll.Bll.ContractProductBll _bll = new FishBll.Bll.ContractProductBll();
        UILibrary.TwoDimenDataGridView helper = null;

        public FormContractList()
        {
            InitializeComponent();

            this.SetButtomImage(btnQuery);

            helper = new UILibrary.TwoDimenDataGridView(dataGridView1);
                     

        }


        public FishEntity.ContractPorductEntity SelectedProduct
        {
            get
            {
                if (dataGridView1.CurrentRow != null)
                {
                    return dataGridView1.CurrentRow.DataBoundItem as FishEntity.ContractPorductEntity;
                }
                return null;
            }
        }
        

        protected string GetWhere()
        {
            string where = " 1=1 ";
            if ( string.IsNullOrEmpty( txtcontractno.Text.Trim() ) == false )
            {
                where += " and contractno like '%" + txtcontractno.Text.Trim()+"%'";
            }
            if (string.IsNullOrEmpty(txtyifang.Text.Trim()) == false)
            {
                where += " and yifang like '%"+ txtyifang.Text.Trim() +"%'";
            }

            return where;
        }

        protected void Query()
        {
            string where = GetWhere();
            List<FishEntity.ContractPorductEntity> list = _bll.GetNotSendProducts( where );
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void txtcontractno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Query();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            Query();
        }
    }
}
