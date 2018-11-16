using System;
using System . Data;

namespace FishClient
{
    public partial class FormPriWarehouse :FormMenuBase
    {
        FishBll.Bll.PriWarehouseBll _bll=null;
        DataTable tableView;
        FishEntity.QuotationPriceListEntity _model=null;
        public FishEntity . QuotationPriceListEntity getModel
        {
            get
            {
                return _model;
            }
        }
        
        public FormPriWarehouse ( )
        {
            InitializeComponent ( );

            _bll = new FishBll . Bll . PriWarehouseBll ( );
        }

        public override int Query ( )
        {
            tableView = _bll . getTableView ( );
            huizong.Text = tableView.Rows.Count.ToString();
            dataGridView1 . DataSource = tableView;
            
            return base . Query ( );
        }
        
        private void dataGridView1_CellDoubleClick ( object sender ,System . Windows . Forms . DataGridViewCellEventArgs e )
        {
            if ( e . ColumnIndex < 0 || e . RowIndex < 0 )
                return;
            _model = new FishEntity . QuotationPriceListEntity ( );
            /*select e.fishId 鱼粉ID,a.codeNum 采购编号,a.codeNumContract 采购合同号,e.billName 提单号,f.confirmagent 开证代理,f.confirmlinkman 联系人,f.confirmdate 售息日期, f.confirmrmb 价格RMB,b.conutry 国别,e.brand 品牌,b.quaSpe 品质,f.confirmsgsweight SGS重量,c.height 剩余数量,d.sgs_protein SGS蛋白,d.sgs_tvn SGSTVN, d.sgs_fat SGS脂肪,d.sgs_water SGS水分,d.sgs_amine SGS组胺,d.sgs_ffa SGSFFA,d.sgs_sandsalt SGS沙和盐,d.sgs_graypart SGS灰分,d.domestic_protein 实测蛋白, d.domestic_amine 实测组胺,d.domestic_tvn 实测tvn,d.domestic_sandsalt 实测盐,d.domestic_graypart 实测灰分,d.domestic_sour 实测酸价,d.domestic_fat 实测脂肪, d.domestic_lysine 实测赖氨酸,d.domestic_methionine 实测蛋安酸,d.domestic_aminototal 氨基酸总和,d.remark 备注,e.shipName 船名,f.spotdate 入库日期, d.warehouse 仓库地址,d.cornerno 桩角号,d.samplingtime 取样日期,f.spotproductdate 生产日期,case when d.state=TRUE then '报盘' when d.state1=TRUE then '确盘' when d.state2=TRUE then '现货' when d.state3=TRUE then '自营' when d.state4=TRUE then '自制' when d.state5 then '成品' end 状态,d.type 港口  from t_purchaseapplication a left join t_purchaseFishInfo e on a.codeNum=e.code left join t_purchasecontract b on a.codeNum=b.codeNum  left join t_enterwarehousereceipts c on a.codeNum=c.codeNum and e.fishId=c.fishId and b.codeNumContract=c.codeNumContract left join t_product d on e.fishId=d.code left join t_productex f on d.id=f.id*/
            
            _model . code = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "采购编号" ] . Value . ToString ( );
            _model . CodeNumSales = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "采购合同号" ] . Value . ToString ( );
            _model . fishId = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "鱼粉ID" ] .Value . ToString ( );
            _model.qualitySpe = dataGridView1.Rows[e.RowIndex].Cells["品质"].Value.ToString();
            _model . acid = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "实测酸价" ] . Value . ToString ( );
            _model . las = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "实测赖氨酸" ] . Value . ToString ( );
            _model . das = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "实测蛋安酸" ] . Value . ToString ( );
            _model . salt = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "实测盐" ] . Value . ToString ( );
            _model . tvn = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "实测tvn" ] . Value . ToString ( );
            _model . protein = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "实测蛋白" ] . Value . ToString ( );
            _model . histamine = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "实测组胺" ] . Value . ToString ( );
            _model . ash = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "实测灰分" ] . Value . ToString ( );
            _model . contract = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "联系人" ] . Value . ToString ( );
            _model . weight = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "SGS重量" ] . Value == null ? 0 : Convert . ToDecimal ( dataGridView1 . Rows [ e . RowIndex ] . Cells [ "SGS重量" ] . Value );
            _model . price = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "价格RMB" ] . Value == null ? 0 : Convert . ToDecimal ( dataGridView1 . Rows [ e . RowIndex ] . Cells [ "价格RMB" ] . Value );
            _model.unit= dataGridView1.Rows[e.RowIndex].Cells["开证代理"].Value.ToString();

            ////////////////////////
            _model.Sgs_graypart= dataGridView1.Rows[e.RowIndex].Cells["SGS灰份"].Value.ToString();
            _model.Sgs_protein = dataGridView1.Rows[e.RowIndex].Cells["SGS蛋白"].Value.ToString();
            _model.Sgs_tvn = dataGridView1.Rows[e.RowIndex].Cells["SGSTVN"].Value.ToString();
            _model.Sgs_amine = dataGridView1.Rows[e.RowIndex].Cells["SGS组胺"].Value.ToString();
            _model.Sgs_ffa = dataGridView1.Rows[e.RowIndex].Cells["SGSFFA"].Value.ToString();
            _model.Sgs_fat = dataGridView1.Rows[e.RowIndex].Cells["SGS脂肪"].Value.ToString();
            _model.Sgs_water = dataGridView1.Rows[e.RowIndex].Cells["SGS水分"].Value.ToString();
            _model.Sgs_sandsalt = dataGridView1.Rows[e.RowIndex].Cells["SGS沙和盐"].Value.ToString();

            _model.Domestic_protein = dataGridView1.Rows[e.RowIndex].Cells["实测蛋白"].Value.ToString();
            _model.Domestic_tvn = dataGridView1.Rows[e.RowIndex].Cells["实测tvn"].Value.ToString();
            _model.Domestic_graypart = dataGridView1.Rows[e.RowIndex].Cells["实测灰分"].Value.ToString();
            _model.Domestic_amine = dataGridView1.Rows[e.RowIndex].Cells["实测组胺"].Value.ToString();
            _model.Domestic_fat = dataGridView1.Rows[e.RowIndex].Cells["实测脂肪"].Value.ToString();
            _model.Domestic_sandsalt = dataGridView1.Rows[e.RowIndex].Cells["实测盐"].Value.ToString();

            _model.ShipName = dataGridView1.Rows[e.RowIndex].Cells["船名"].Value.ToString();
            _model.Cornerno = dataGridView1.Rows[e.RowIndex].Cells["桩角号"].Value.ToString();
            _model.BillName = dataGridView1.Rows[e.RowIndex].Cells["提单号"].Value.ToString();
            _model.country = dataGridView1.Rows[e.RowIndex].Cells["国别"].Value.ToString();
            _model.brand = dataGridView1.Rows[e.RowIndex].Cells["品牌"].Value.ToString();
            this . DialogResult = System . Windows . Forms . DialogResult . OK;
        }

        private void FormPriWarehouse_Load ( object sender ,EventArgs e )
        {
            if ( Megres . oddNum != "" )
            {
                tableView = _bll . getTableView ( );
                dataGridView1 . DataSource = tableView;
            }

            //权限控制功能。
            Megres . oddNum = string . Empty;
        }


    }
}
