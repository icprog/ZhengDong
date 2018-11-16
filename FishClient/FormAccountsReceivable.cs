using System;
using System . Collections . Generic;
using System . Windows . Forms;
using FishEntity;
namespace FishClient
{
    //t_AccountsReceivableHead  表一
    //t_AccountsReceivableBody  表二
    public partial class FormAccountsReceivable :FormMenuBase
    {
        FishEntity.AccountsReceivableHead _head=null;
        FishEntity.AccountsreceivableBody _body=null;
        FishBll.Bll.AccountsReceivableBll _bll=new FishBll.Bll.AccountsReceivableBll();
        bool isOk=false;string strWhere=string.Empty;
        string state=string.Empty;

        public FormAccountsReceivable ( )
        {
            InitializeComponent ( );
            FishBll . Bll . SalerequisitionBll _bll = new FishBll . Bll . SalerequisitionBll ( );
            

            cmbYfId.DisplayMember = "code";
            cmbYfId . DataSource = _bll . getCode ( );
            cmbYfId.SelectedIndex = -1;

            tmiExport . Visible = true;
            tmiQuery . Visible = true;
            tmiAdd . Visible = true;
            tmiDelete . Visible = false;
            tmiModify . Visible = false;
            tmiNext . Visible = false;
            tmiPrevious . Visible = false;
            tmiSave . Visible = true;
            tmiCancel . Visible = true;
            tmiClose . Visible = true;

            ReadColumnConfig ( dataGridView1 ,"Set_SystemDataSet" );
            ReadColumnConfig ( dataGridView2 ,"Set_SystemDataSet" );
        }

        private void textBox2_Click ( object sender ,EventArgs e )
        {
            SelectMan ( txtSaleman );
        }

        protected void SelectMan ( TextBox txt )
        {
            FormUserList form = new FormUserList ( true );
            form . StartPosition = FormStartPosition . CenterParent;
            form . ShowInTaskbar = false;
            DialogResult result = form . ShowDialog ( );
            if ( result == System . Windows . Forms . DialogResult . OK )
            {
                FishEntity . PersonEntity person = form . SelectedPersion;
                if ( person != null )
                {
                    txt . Text = person . realname;
                    txt . Tag = person . id;
                }
            }
        }

        private void contextMenuStrip1_Click ( object sender ,EventArgs e )
        {
            UIForms . FormSetColumnWidth form = new UIForms . FormSetColumnWidth ( dataGridView1 . Columns ,"Set_SystemDataSet" );
            form . ShowDialog ( );

            ReadColumnConfig ( dataGridView1 ,"Set_SystemDataSet" );
        }

        protected void ReadColumnConfig ( DataGridView gdv ,string section )
        {
            string path = Application . StartupPath + "\\listconfig.ini";

            if ( System . IO . File . Exists ( path ) )
            {
                foreach ( DataGridViewColumn col in gdv . Columns )
                {
                    string wstr = Utility . IniUtil . ReadIniValue ( path ,section ,col . HeaderText );
                    int w = 0;
                    if ( int . TryParse ( wstr ,out w ) )
                    {
                        col . Width = w;
                    }
                }
            }
        }

        private void contextMenuStrip2_Click ( object sender ,EventArgs e )
        {
            UIForms . FormSetColumnWidth form = new UIForms . FormSetColumnWidth ( dataGridView2 . Columns ,"Set_SystemDataSet" );
            form . ShowDialog ( );

            ReadColumnConfig ( dataGridView2 ,"Set_SystemDataSet" );
        }

        private void FormAccountsReceivable_Load ( object sender ,EventArgs e )
        {

        }

        private void txtUnit_Click ( object sender ,EventArgs e )
        {
            FormCompanyList form = new FormCompanyList ( );
            form . StartPosition = FormStartPosition . CenterParent;
            if ( form . ShowDialog ( ) != System . Windows . Forms . DialogResult . OK )
                return;
            if ( form . SelectCompany == null )
                return;
            txtUnit . Text = form . SelectCompany . fullname;
            txtUnit . Tag = form . SelectCompany . code;
        }

        public override int Query ( )
        {

            state = "query";

            headOf ( );

            strWhere = " 1=1 ";
            

            if (!string.IsNullOrEmpty(cmbYfId.Text))
            {
                strWhere = " yfId like'%" + cmbYfId.Text + "%' ";
            }
            List<FishEntity . AccountsReceivableHead> _head = _bll . getList ( strWhere );
            if ( _head != null && _head.Count!=0)
            {
                setValueHead ( _head [ 0 ] );
                tmiSave . Visible = true;
                tmiCancel . Visible = false;
            }
            else
                MessageBox . Show ( "查无记录" );

            return base . Query ( );
        }

        void headOf ( )
        {
            _head = new FishEntity . AccountsReceivableHead ( );
            isOk = _bll . head_one ( cmbYfId . Text ,FishEntity . Variable . User . username );
        }

        void setValueHead ( FishEntity . AccountsReceivableHead _head )
        {
            dataGridView1 . Rows . Clear ( );
            int idx = dataGridView1 . Rows . Add ( );
            DataGridViewRow row = dataGridView1 . Rows [ idx ];
            row . Cells [ "yfId" ] . Value = _head . yfId;
            row . Cells [ "province" ] . Value = _head . province;
            row . Cells [ "region" ] . Value = _head . region;
            row . Cells [ "customer" ] . Value = _head . customer;
            row . Cells [ "salesman" ] . Value = _head . salesman;
            row . Cells [ "yearArrears" ] . Value = _head . yearArrears;
            row . Cells [ "monthReceivable" ] . Value = _head . monthReceivable;
            row . Cells [ "monthNetreceipts" ] . Value = _head . monthNetreceipts;
            row . Cells [ "yearReceivable" ] . Value = _head . YearReceivable;
            row . Cells [ "yearNetreceipts" ] . Value = _head . yearNetreceipts;
            row . Cells [ "qmqk" ] . Value = _head . YearReceivable - _head . yearNetreceipts;
            row . Cells [ "remark" ] . Value = _head . remark;
            row . Cells [ "count" ] . Value = _head . count;
        }

        private void dataGridView1_CellClick ( object sender ,DataGridViewCellEventArgs e )
        {
            if ( e . ColumnIndex < 0 || e . RowIndex < 0 )
                return;

            _body = new FishEntity . AccountsreceivableBody ( );
            _body . yfId = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "yfId" ] . Value . ToString ( );

            isOk = _bll . head_two ( _body . yfId ,FishEntity . Variable . User . username );

            List<FishEntity . AccountsreceivableBody> modelList = _bll . getLists ( _body . yfId );
            setValueBody ( modelList );
        }

        void setValueBody ( List<FishEntity . AccountsreceivableBody> modelList )
        {
            dataGridView2 . Rows . Clear ( );
            foreach ( FishEntity . AccountsreceivableBody _body in modelList )
            {
                int idx = dataGridView2 . Rows . Add ( );
                DataGridViewRow row = dataGridView2 . Rows [ idx ];
                row . Cells [ "yfId_one" ] . Value = _body . yfId;
                row . Cells [ "code" ] . Value = _body . code;
                row . Cells [ "date" ] . Value = _body . date;
                row . Cells [ "num" ] . Value = _body . num;
                row . Cells [ "price" ] . Value = _body . price;
                row . Cells [ "paymentDate" ] . Value = _body . paymentDate;
                row . Cells [ "quality" ] . Value = _body . quality;
                row . Cells [ "customer_one" ] . Value = _body . customer;
                row . Cells [ "salesman_one" ] . Value = _body . salesman;
                row . Cells [ "deliveryDay" ] . Value = _body . deliveryDay;
                row . Cells [ "deliveryMonth" ] . Value = _body . deliveryMonth;
                row . Cells [ "deliveryNum" ] . Value = _body . deliveryNum;
                row . Cells [ "settlementNum" ] . Value = _body . settlementNum;
                row . Cells [ "receivablesDay" ] . Value = _body . receivablesDay;
                row . Cells [ "receivablesMonth" ] . Value = _body . receivablesMonth;
                row . Cells [ "receivablesAmount" ] . Value = _body . receivablesAmount;
                row . Cells [ "receuvablesAcountNum" ] . Value = _body . receuvablesAcountNum;
                row . Cells [ "remark_one" ] . Value = _body . remark;
                row . Cells [ "htje" ] . Value = _body . num * _body . price;
                row . Cells [ "fhje" ] . Value = _body . deliveryNum * _body . price;
                row . Cells [ "jsje" ] . Value = _body . settlementNum * _body . price;
            }
        }

        private void btnQuery_Click ( object sender ,EventArgs e )
        {
            state = "queryAll";

            strWhere = "1=1";
            List<FishEntity . AccountsReceivableHead> _head = _bll . getList ( strWhere );
            if ( _head != null )
            {
                foreach ( FishEntity . AccountsReceivableHead _list in _head )
                {
                    setValueHead ( _list );
                }
                tmiSave . Visible = true;
                tmiCancel . Visible = false;
            }
            else
                MessageBox . Show ( "查无记录" );
        }

        public override void Save ( )
        {
            if ( dataGridView2 . Rows . Count > 0 )
            {
                dataGridView2 . EndEdit ( );

                List<FishEntity . AccountsreceivableBody> modelList = new List<FishEntity . AccountsreceivableBody> ( );

                for ( int i = 0 ; i < dataGridView2 . Rows . Count ; i++ )
                {
                    _body = new FishEntity . AccountsreceivableBody ( );
                    _body . yfId = dataGridView2 . Rows [ i ] . Cells [ "yfId_one" ] . Value . ToString ( );
                    _body . code = dataGridView2 . Rows [ i ] . Cells [ "code" ] . Value . ToString ( );
                    _body . settlementNum = string . IsNullOrEmpty ( dataGridView2 . Rows [ i ] . Cells [ "settlementNum" ] . Value . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dataGridView2 . Rows [ i ] . Cells [ "settlementNum" ] . Value . ToString ( ) );
                    modelList . Add ( _body );
                }

                if ( modelList . Count > 0 )
                {
                    isOk = _bll . Add ( modelList ,FishEntity . Variable . User . username );
                    if ( isOk == true )
                    {
                        MessageBox . Show ( "保存成功" );
                        if ( state . Equals ( "query" ) )
                            Query ( );
                        else
                            btnQuery_Click ( null ,null );
                    }
                    else
                        MessageBox . Show ( "保存失败" );
                }

            }

            base . Save ( );
        }


    }
}



//select fullname 公司名称,province 省,zone 地区,salesman 所属人 from t_salesorder a left join t_company b on a.demandId=b.code
//select SUM(b.RMB) rmb 年初欠款, from t_salesorder a left join  t_ReceiptRecord b on a.demandId=b.fuKuanDanWeiId where YEAR ( b . date)<=YEAR ( NOW())
//select SUM(c.Quantity*unitprice)-SUM(b.RMB) rmb 本月应收账款 from t_salesorder a LEFT JOIN t_happening c on a.code=c.code left join  t_ReceiptRecord b on a.demandId=b.fuKuanDanWeiId where YEAR(a.Signdate)=YEAR(NOW()) and MONTH(a.Signdate)=YEAR(NOW())
//SELECT SUM(RMB) rmb 本月实收金额 FROM t_ReceiptRecord where YEAR(date)=YEAR(NOW()) and MONTH(date)=MONTH(NOW()) 
//select SUM(c.Quantity*unitprice)-SUM(b.RMB) rmb 本年应收账款 from t_salesorder a LEFT JOIN t_happening c on a . code=c.code left join  t_ReceiptRecord b on a . demandId=b.fuKuanDanWeiId where YEAR ( a . Signdate)=YEAR ( NOW())
//SELECT SUM(RMB) rmb 本年实收金额 FROM t_ReceiptRecord where YEAR(date)=YEAR(NOW()) and MONTH(date)=MONTH(NOW()) 
//select COUNT(1) coun 计数 from t_salesorder where YEAR(Signdate)<=YEAR(NOW())

//磅单和销售合同根据   销售申请单.提单号=提货单.编号  and  提货单.磅单号=榜单.榜单序号
/*
 select a.code,Signdate,b.Quantity,b.unitprice,b.Quantity*b.unitprice amount,a.payment,b.Variety,a.demand,a.createman,
DAY(c.createtime) dayOf,MONTH(c.createtime) monthOf,b.unitprice*d.Competition amount1,
DAY(e.createTime) dayOfE,MONTH(e.createTime) monthOfE,SUM(RMB) rmbE,e.fuKuanZhangHao
from t_salesorder a LEFT JOIN t_happening b on a . code=b . code
                    LEFT JOIN t_billoflading c on b.tdh=c.code
                    LEFT JOIN t_poundsalone d on c.listname=d.code
                    LEFT JOIN t_ReceiptRecord e on a.code=e.codeOfYu
                    */
