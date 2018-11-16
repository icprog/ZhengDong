using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient.Contract
{
    public partial class FormContractTakeDetail : FormMenuBase
    {
        private int _contractid = 0;
        private string _contractno = "";
        private FishBll.Bll.ContractDetailBll _contractdetailBll = null;
        private List<FishEntity.ContractPorductEntity> _products = null;
        private FishBll.Bll.ContractProductBll _contractproductBll = null;

        public FormContractTakeDetail( int contractid , string contractno)
        {
            InitializeComponent();

            _contractid = contractid;
            _contractno = contractno;

            this.menuStrip1.Visible = false;

            this.Text = "合同号："+ _contractno ;

            InitData();

            _contractdetailBll = new FishBll.Bll.ContractDetailBll();
            List<FishEntity.ContractDetailEntity> detail = _contractdetailBll.GetModelList("contractid=" + contractid);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = detail;

            _contractproductBll = new FishBll.Bll.ContractProductBll (); 
            //_products =_contractproductBll.GetProducts( _contractid , _

            if (detail != null && detail .Count >0 )
            {
                int detailid = detail[0].id;
                queryProduct(detailid);
            }
        }

        private void InitData()
        {
            List<FishEntity.DictEntity> list = InitDataUtil.DictList.FindAll((i) => { return i.pcode.Equals(FishEntity.Constant.Goods); });
            if (list == null)
            {
                list = new List<FishEntity.DictEntity>();
            }

            FishEntity.DictEntity empty = new FishEntity.DictEntity();
            empty.name = "";
            empty.code = "-1";
            list.Insert(0, empty);

            productname.DataSource = list;
            productname.DisplayMember = "name";
            productname.ValueMember = "code";

            list = InitDataUtil.DictList.FindAll((i) => { return i.pcode.Equals(FishEntity.Constant.Specification); });
            if (list == null)
            {
                list = new List<FishEntity.DictEntity>();
            }

            empty = new FishEntity.DictEntity();
            empty.name = "";
            empty.code = "-1";
            list.Insert(0, empty);

            specification.DataSource = list;
            specification.DisplayMember = "name";
            specification.ValueMember = "code";
        }

        protected void queryProduct( int detailid )
        {
            _products = _contractproductBll.GetProducts(_contractid, detailid);
            SetProducts(_products);
        }

        protected void SetProducts(List<FishEntity.ContractPorductEntity> list)
        {
            dataGridView2.Rows.Clear();
            if (list == null || list.Count < 1) return;

            foreach (FishEntity.ContractPorductEntity item in list)
            {
                int idx = dataGridView2.Rows.Add();
                DataGridViewRow row = dataGridView2.Rows[idx];
                row.Cells["cpid"].Value = item.cpid;
                row.Cells["productid"].Value = item.id;
                row.Cells["code"].Value = item.code;
                row.Cells["name"].Value = item.name;
                row.Cells["spe"].Value = item.specification;               
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            int detailid = int.Parse( dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
            queryProduct(detailid);
        }

        public int Add()
        {
            dataGridView2.EndEdit();

            int idx = dataGridView2.Rows.Add();
            dataGridView2.Rows[idx].Cells["cpid"].Value = 0;
            dataGridView2.Rows[idx].Cells["productid"].Value = 0;
            dataGridView2.Rows[idx].Cells["code"].Value = "";
            dataGridView2.Rows[idx].Cells["name"].Value = "";
            dataGridView2.Rows[idx].Cells["spe"].Value = "";

            return 1;
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add();
        }

        public int Delete()
        {
            if (dataGridView2.CurrentRow != null)
            {
                dataGridView2.EndEdit();

                if (dataGridView2.CurrentRow.IsNewRow)
                {
                    return 0;
                }

                dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
            }

            return 1;
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private bool Check()
        {
            if (dataGridView2.Rows.Count < 1) return true;
            bool isok = true;
            //List<FishEntity.QuoteEntity> listNews = new List<FishEntity.QuoteEntity>();
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;
                object val = row.Cells["code"].EditedFormattedValue;
                if (val == null)
                {
                    isok = false;
                    row.Cells["code"].ErrorText = "请选择鱼粉";
                }
            }
            return isok;
        }

        protected void Save()
        {
            if (Check()==false )
            {
                return;
            }

            dataGridView2.EndEdit();

            List<FishEntity.ContractPorductEntity> listNews = new List<FishEntity.ContractPorductEntity>();
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;
                FishEntity.ContractPorductEntity product = new FishEntity.ContractPorductEntity();
                int cpid = 0;
                int.TryParse(row.Cells["cpid"].Value == null ? "0" : row.Cells["cpid"].Value.ToString(), out cpid);
                product.cpid = cpid;
                int pid = 0;
                int.TryParse(row.Cells["productid"].Value == null ? "0" : row.Cells["productid"].Value.ToString(), out pid);
                product.id = pid;
                product.code = row.Cells["code"].Value == null ? "" : row.Cells["code"].Value.ToString();
                product.name = row.Cells["name"].Value == null ? "" : row.Cells["name"].Value.ToString();               
                        
                listNews.Add(product);
            }


            int detailid= int.Parse( dataGridView1.CurrentRow.Cells["id"].Value .ToString ());

            List<FishEntity.ContractPorductEntity> listsource = _contractproductBll.GetProducts( _contractid ,  detailid );
            if (listsource != null)
            {
                foreach (FishEntity.ContractPorductEntity item in listsource)
                {
                    bool isExist = listNews.Exists((i) => { return i.cpid == item.cpid; });
                    if (isExist == false)
                    {
                        int deleteRows = _contractproductBll.DeleteBy( _contractid , detailid , item.id);
                    }
                }
            }


            foreach (FishEntity.ContractPorductEntity item in listNews)
            {
                if (item.cpid ==0)
                {
                
                    int cpid = _contractproductBll.Add( _contractid , detailid , item.id );
                    if (cpid > 0)
                    {
                        item.cpid = cpid;
                    }
                }
                else
                {
                    int updateRows = _contractproductBll.Update( _contractid , detailid , item.id , item.cpid );
                    if (updateRows>0)
                    {
                    }
                }
            }

            SetProducts(listNews);         
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(  e.RowIndex <0 || e.ColumnIndex <0) return;

            string cname = dataGridView2.Columns[e.ColumnIndex].Name;
            if( cname.Equals("code"))
            {
                UIForms.FormSelectFish form = new UIForms.FormSelectFish(-1);
                if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

                dataGridView2.Rows[e.RowIndex].Cells["productid"].Value = form.SelectedProduct.id;
                dataGridView2.Rows[e.RowIndex].Cells["code"].Value = form.SelectedProduct.code;
                dataGridView2.Rows[e.RowIndex].Cells["name"].Value = form.SelectedProduct.name;
                dataGridView2.Rows[e.RowIndex].Cells["spe"].Value = form.SelectedProduct.specification;
            }
        }

    }
}
