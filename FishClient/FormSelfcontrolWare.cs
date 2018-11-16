using System;
using System . Data;
using System . Windows . Forms;

namespace FishClient
{
    public partial class FormSelfcontrolWare :FormMenuBase
    {
        FishBll.Bll.SelfcontrolWareBll _bll=null;
        DataTable tableView;

        FishEntity.BatchSheetsEntity _models=new FishEntity.BatchSheetsEntity();
        public FishEntity . BatchSheetsEntity getModel
        {
            get
            {
                return _models;
            }
        }

        public FormSelfcontrolWare ( )
        {
            InitializeComponent ( );
            
            _bll = new FishBll . Bll . SelfcontrolWareBll ( );
        }
        
        public override int Query ( )
        {
            tableView = _bll . getTableView ( );
            huizong.Text = tableView.Rows.Count.ToString();
            dataGridView1 . DataSource = tableView;

            return base . Query ( );
        }
        
        private void dataGridView1_CellClick ( object sender ,System . Windows . Forms . DataGridViewCellEventArgs e )
        {
            /*
           select fishId 鱼粉ID,billName 提单号,codeNum 采购编号,codeNumContract 采购合同号,a.price 采购价格,c.salermb 市场价格,a.applyDate 入库日期,c.selfstorageweight 重量,c.selfstoragequantity 数量,pileNum 桩角号,db 蛋白,tvn TVN,za 组胺,shy 沙和盐,hf 灰份,domestic_sour 酸价,zf 脂肪,domestic_lysine 赖氨酸,domestic_methionine 蛋氨酸,domestic_aminototal 氨基酸总和,a.remark 备注,country 国别,a.brand 品牌,shipName 船名,b.State4 状态 ,b.type 港口,a.code 入库申请单单号 from t_storageofrequisition a inner join t_product b on a.fishId=b.code inner join t_productex c on b.id=c.id
             */
            if ( e . ColumnIndex < 0 && e . RowIndex < 0 )
                return;
            _models = new FishEntity . BatchSheetsEntity ( );
            _models . fishId = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "鱼粉ID" ] . Value == null ? string . Empty : dataGridView1 . Rows [ e . RowIndex ] . Cells [ "鱼粉ID" ] . Value . ToString ( );
            _models . codeNum = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "采购编号" ] . Value == null ? string . Empty : dataGridView1 . Rows [ e . RowIndex ] . Cells [ "采购编号" ] . Value . ToString ( );
            _models . codeNumContract = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "采购合同号" ] . Value == null ? string . Empty : dataGridView1 . Rows [ e . RowIndex ] . Cells [ "采购合同号" ] . Value . ToString ( );
            _models . country = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "国别" ] . Value == null ? string . Empty : dataGridView1 . Rows [ e . RowIndex ] . Cells [ "国别" ] . Value . ToString ( );
            _models . brand = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "品牌" ] . Value == null ? string . Empty : dataGridView1 . Rows [ e . RowIndex ] . Cells [ "品牌" ] . Value . ToString ( );
            _models . protein = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "蛋白" ] . Value == null ? string . Empty : dataGridView1 . Rows [ e . RowIndex ] . Cells [ "蛋白" ] . Value . ToString ( );
            _models . tvn = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "TVN" ] . Value == null ? string . Empty : dataGridView1 . Rows [ e . RowIndex ] . Cells [ "TVN" ] . Value . ToString ( );
            _models .salt = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "沙和盐" ] . Value == null ? string . Empty : dataGridView1 . Rows [ e . RowIndex ] . Cells [ "沙和盐" ] . Value . ToString ( );
            _models .acid = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "酸价" ] . Value == null ? string . Empty : dataGridView1 . Rows [ e . RowIndex ] . Cells [ "酸价" ] . Value . ToString ( );
            _models .ash = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "灰份" ] . Value == null ? string . Empty : dataGridView1 . Rows [ e . RowIndex ] . Cells [ "灰份" ] . Value . ToString ( );
            _models .histamine = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "组胺" ] . Value == null ? string . Empty : dataGridView1 . Rows [ e . RowIndex ] . Cells [ "组胺" ] . Value . ToString ( );
            _models . las = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "赖氨酸" ] . Value == null ? string . Empty : dataGridView1 . Rows [ e . RowIndex ] . Cells [ "赖氨酸" ] . Value . ToString ( );
            _models .das = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "蛋氨酸" ] . Value == null ? string . Empty : dataGridView1 . Rows [ e . RowIndex ] . Cells [ "蛋氨酸" ] . Value . ToString ( );
            _models . tons = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "重量" ] . Value == null ? 0 : Convert . ToDecimal ( dataGridView1 . Rows [ e . RowIndex ] . Cells [ "重量" ] . Value );
            _models . rkCode = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "入库申请单单号" ] . Value . ToString ( );
            this . DialogResult = DialogResult . OK;
        }

    }
}
