using System;
using System . Collections . Generic;
using System . Data;
using System . Drawing;
using System . Reflection;
using System . Windows . Forms;

namespace FishClient
{
    public partial class FormProcessStateForSaleOne :FormMenuBase
    {
        FishBll.Bll. ProcessStateForSaleOneBll _bll=null; ProcessControl Authority =null;
        DataTable tableView=null,table=null,tableErrorFK=null;
        string strWhere="1=1";
        public FormProcessStateForSaleOne ( )
        {
            InitializeComponent ( ); ReadColumnConfig(dataGridView1, "Set_129");

            _bll = new FishBll . Bll . ProcessStateForSaleOneBll ( );
            tableView = new DataTable ( );
            Authority = new ProcessControl ( );
            tableErrorFK = new DataTable ( );
            DealDataGridViewHeader ( );
            User ( );
            table = _bll . getTableFishId ( );
            DataRow row = table . NewRow ( );
            table . Rows . InsertAt ( row ,0 );
            comfishId . DataSource = table;
            comfishId . DisplayMember = "fishId";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.CustomFormat = "  ";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.CustomFormat = "  ";
        }

        private void DealDataGridViewHeader ( )
        {
            UILibrary . TwoDimenDataGridView helper = new UILibrary . TwoDimenDataGridView ( dataGridView1 );
            UILibrary . TwoDimenDataGridView . TopHeader header1 = new UILibrary . TwoDimenDataGridView . TopHeader ( 7 ,2 ,"采购申请单" );
            UILibrary . TwoDimenDataGridView . TopHeader header2 = new UILibrary . TwoDimenDataGridView . TopHeader ( 9 ,2 ,"采购合同" );
            UILibrary . TwoDimenDataGridView . TopHeader header3 = new UILibrary . TwoDimenDataGridView . TopHeader (11 ,2 ,"付款申请单" );
            helper . Headers . AddRange ( new UILibrary . TwoDimenDataGridView . TopHeader [ ] { header1 ,header2 ,header3 } );
        }

        public override int Query ( )
        {
            strWhere = "1=1 and a.process='采购流程1' ";
            if ( !string . IsNullOrEmpty ( comfishId . Text . Trim ( ) ) )
                strWhere = strWhere + " and b.fishId='" + comfishId . Text + "'";
            if ( !string . IsNullOrEmpty ( txtCodeNum . Text . Trim ( ) ) )
                strWhere = strWhere + " and a.codeNum like '%" + txtCodeNum . Text + "%'";
            if ( !string . IsNullOrEmpty ( txtCodeNumContract . Text . Trim ( ) ) )
                strWhere = strWhere + " and a.codeNumContract like '%" + txtCodeNumContract . Text + "%'"; 
            if ( !string . IsNullOrEmpty ( cmbCodeNumUser . Text . Trim ( ) ) )
                strWhere = strWhere + " and a.createUser='" + cmbCodeNumUser . Text + "'";
            if (!string.IsNullOrEmpty(txtsupplier.Text.Trim()))
                strWhere = strWhere + " and a.supplier like'%" + txtsupplier.Text + "%'";
            if (!string.IsNullOrEmpty(dtpStart.Text.Trim()))
                strWhere = strWhere + " AND a.signDate>='" + dtpStart.Text + "'";
            if (!string.IsNullOrEmpty(dtpEnd.Text.Trim()))
                strWhere = strWhere + " AND a.Signdate<='" + dtpEnd.Text + "'";

            tableView = _bll . getTableView ( strWhere );
            dataGridView1 . Rows . Clear ( );
            if ( tableView == null || tableView . Rows . Count < 1 )
                return 0;
            tableErrorFK = _bll . getTableErrorForFK ( );
            setValue ( );

            return base . Query ( );
        }

        void setValue ( )
        {
            string codeNumContract = string . Empty, errorValue = string . Empty;
            bool result = false;
            if ( tableErrorFK != null && tableErrorFK . Rows . Count > 0 )
            {
                result = true;
            }
            int idx = 0;
            for (int i = 0; i < tableView.Rows.Count; i++)
            {
                idx = dataGridView1.Rows.Add();
                dataGridView1.Rows[idx].Cells["fishId"].Value = tableView.Rows[i]["fishId"].ToString();
                dataGridView1.Rows[idx].Cells["codeNum"].Value = tableView.Rows[i]["codeNum"].ToString();
                codeNumContract = tableView.Rows[i]["codeNumContract"].ToString();
                dataGridView1.Rows[idx].Cells["codeNumContract"].Value = codeNumContract;
                dataGridView1.Rows[idx].Cells["supplier"].Value = tableView.Rows[i]["supplier"].ToString();
                dataGridView1.Rows[idx].Cells["signDate"].Value = Convert.ToDateTime(tableView.Rows[i]["signDate"]).ToString("yyyy-MM-dd");
                dataGridView1.Rows[idx].Cells["weight"].Value = tableView.Rows[i]["weight"].ToString();//
                dataGridView1.Rows[idx].Cells["proName"].Value = tableView.Rows[i]["proName"].ToString();
                if (string.IsNullOrEmpty(tableView.Rows[i]["codeNum"].ToString()))
                    dataGridView1.Rows[i].Cells["createUser"].Style.BackColor = Color.FromName("LightBlue");
                else
                {
                    dataGridView1.Rows[i].Cells["createUser"].Style.BackColor = Color.FromName("LightPink");
                    dataGridView1.Rows[idx].Cells["createUser"].Value = tableView.Rows[i]["realname"].ToString();
                }
                if (string.IsNullOrEmpty(tableView.Rows[i]["realname1"].ToString()))
                    dataGridView1.Rows[i].Cells["Numbering"].Style.BackColor = Color.FromName("LightBlue");
                else
                {
                    dataGridView1.Rows[i].Cells["Numbering"].Style.BackColor = Color.FromName("LightPink");
                    dataGridView1.Rows[idx].Cells["Numbering"].Value = tableView.Rows[i]["realname1"].ToString();
                }
                if (string.IsNullOrEmpty(tableView.Rows[i]["codeNumContract"].ToString()))
                    dataGridView1.Rows[i].Cells["createUser1"].Style.BackColor = Color.FromName("LightBlue");
                else { 
                    dataGridView1.Rows[i].Cells["createUser1"].Style.BackColor = Color.FromName("LightPink");
                dataGridView1.Rows[idx].Cells["createUser1"].Value = tableView.Rows[i]["createUser1"].ToString();
            }
                if (string.IsNullOrEmpty(tableView.Rows[i]["realname2"].ToString()))
                    dataGridView1.Rows[i].Cells["Numbering1"].Style.BackColor = Color.FromName("LightBlue");
                else { 
                    dataGridView1.Rows[i].Cells["Numbering1"].Style.BackColor = Color.FromName("LightPink");
                dataGridView1.Rows[idx].Cells["Numbering1"].Value = tableView.Rows[i]["realname2"].ToString();
            }
                //if (!string.IsNullOrEmpty(tableView.Rows[i]["codeNum1"].ToString()))
                //dataGridView1.Rows[i].Cells["codeNum1"].Style.BackColor = Color.FromName("LightPink");
                //else
                //    dataGridView1.Rows[i].Cells["codeNum1"].Style.BackColor = Color.FromName("LightBlue");

                //codeNum2//applyMoney
                dataGridView1.Rows[i].Cells["codeNum2"].Value = tableView.Rows[i]["weight1"].ToString();
                if (tableView.Rows[i]["dengyu"].ToString()=="1")
                {
                    dataGridView1.Rows[i].Cells["codeNum2"].Style.BackColor = Color.FromName("LightPink");
                }
                else if (tableView.Rows[i]["dayu"].ToString() == "1")
                {
                    dataGridView1.Rows[i].Cells["codeNum2"].Style.BackColor = Color.FromName("Lightgreen");
                }
                else if (tableView.Rows[i]["xiaoyu"].ToString() == "1")
                {
                    dataGridView1.Rows[i].Cells["codeNum2"].Style.BackColor = Color.FromName("yellow");
                }
                else if (string.IsNullOrEmpty(tableView.Rows[i]["codeNum2"].ToString())|| tableView.Rows[i]["codeNum2"]==null)
                {
                    dataGridView1.Rows[i].Cells["codeNum2"].Style.BackColor = Color.FromName("LightBlue");
                }

                    if (tableView.Rows[i]["shenhe"].ToString()!=""&& tableView.Rows[i]["shenhe"]!=null)
                {
                    dataGridView1.Rows[idx].Cells["shenhe"].Value =decimal.Parse(tableView.Rows[i]["shenhe"].ToString()) *100+ "%";

                    dataGridView1.Rows[idx].Cells["shenhe"].Value = string.Format("{0:0.##}", decimal.Parse(tableView.Rows[i]["shenhe"].ToString()) * 100)+"%";
                    dataGridView1.Rows[i].Cells["shenhe"].Style.BackColor = Color.FromName("LightPink");
                }
                else { 
                    dataGridView1.Rows[idx].Cells["shenhe"].Value = /*tableView.Rows[i]["coun"].ToString()*/0 + "%";
                    dataGridView1.Rows[i].Cells["shenhe"].Style.BackColor = Color.FromName("LightBlue");
                }
                if (tableView.Rows[i]["jindan1"].ToString() != "" && tableView.Rows[i]["jindan1"] != null)
                    dataGridView1.Rows[i].Cells["jindan1"].Style.BackColor = Color.FromName("LightPink");
                else
                    dataGridView1.Rows[i].Cells["jindan1"].Style.BackColor = Color.FromName("LightBlue");
                if (tableView.Rows[i]["choise"].ToString() == "报盘")
                {
                    if (tableView.Rows[i]["jincang1"].ToString()!="")
                    {
                        dataGridView1.Rows[idx].Cells["jindan1"].Value = string.Format("{0:0.##}", decimal.Parse(tableView.Rows[i]["jindan1"].ToString()) * 100) + "%";
                        dataGridView1.Rows[i].Cells["jindan1"].Style.BackColor = Color.FromName("LightPink");
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells["jindan1"].Style.BackColor = Color.FromName("LightBlue");
                    }
                }
                else {
                    dataGridView1.Rows[i].Cells["jindan1"].Style.BackColor = Color.FromName("LightPink");
                }
                //if ( string . IsNullOrEmpty ( tableView . Rows [ i ] [ "weight" ] . ToString ( ) ) )
                //{
                //    dataGridView1 . Rows [ idx ] . Cells [ "weight" ] . Value = tableView . Rows [ i ] [ "weight" ] . ToString ( ) + "0%";
                //    dataGridView1 . Rows [ i ] . Cells [ "weight" ] . Style . BackColor = Color . FromName ( "LightBlue" );
                //}
                //else
                //    dataGridView1 . Rows [ idx ] . Cells [ "weight" ] . Value = tableView . Rows [ i ] [ "weight" ] . ToString ( ) + "%";
                ////if ( string . IsNullOrEmpty ( tableView . Rows [ i ] [ "code2" ] . ToString ( ) ) )
                ////    dataGridView1 . Rows [ i ] . Cells [ "code2" ] . Style . BackColor = Color . FromName ( "LightBlue" );
                ////else
                ////    dataGridView1 . Rows [ i ] . Cells [ "code2" ] . Style . BackColor = Color . FromName ( "LightPink" );

                //if ( !string . IsNullOrEmpty ( codeNumContract ) && result == true )
                //{
                //    if ( tableErrorFK . Select ( "purchasecode='" + codeNumContract + "'" ) . Length > 0 )
                //    {
                //        errorValue = tableErrorFK . Select ( "purchasecode='" + codeNumContract + "'" ) [ 0 ] [ "calcu" ] . ToString ( );
                //        if ( string . IsNullOrEmpty ( errorValue ) )
                //            dataGridView1 . Rows [ i ] . Cells [ "error" ] . Style . BackColor = Color . FromName ( "LightPink" );
                //        else if ( Convert . ToDecimal ( errorValue ) != 0 )
                //            dataGridView1 . Rows [ i ] . Cells [ "error" ] . Style . BackColor = Color . FromName ( "Yellow" );
                //        else
                //            dataGridView1 . Rows [ i ] . Cells [ "error" ] . Style . BackColor = Color . FromName ( "LightPink" );
                //    }
                //    else
                //        dataGridView1 . Rows [ i ] . Cells [ "error" ] . Style . BackColor = Color . FromName ( "LightPink" );
                //}
                //else
                //    dataGridView1 . Rows [ i ] . Cells [ "error" ] . Style . BackColor = Color . FromName ( "LightPink" );
            }
        }
        public void User ( )
        {
            FishBll . Bll . PersonBll bll = new FishBll . Bll . PersonBll ( );

            List<FishEntity . PersonEntity> list1 = bll . id_name ( );
            if ( list1 == null )
            {
                list1 = new List<FishEntity . PersonEntity> ( );
            }
            FishEntity . PersonEntity tmep = new FishEntity . PersonEntity ( );

            tmep.id = 0;
            tmep . username = " ";
            list1 . Insert ( 0 ,tmep );

            cmbCodeNumUser . DataSource = list1;
            cmbCodeNumUser . DisplayMember = "username";
            cmbCodeNumUser . ValueMember = "username";
        }

        string billNum = string.Empty, path = string.Empty;

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            this.dtpEnd.CustomFormat = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPurchaseApplication from = new FormPurchaseApplication("采购流程1"); from.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            path = string.Empty;
            Megres.oddNum = string.Empty;
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("createUser", StringComparison.OrdinalIgnoreCase))
            {
                if (Authority.ProcessControText("采购申请单") == true)
                {
                    path = "FishClient.FormPurchaseApplication";
                    billNum = dataGridView1.Rows[e.RowIndex].Cells["codeNum"].Value.ToString();
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("createUser1", StringComparison.OrdinalIgnoreCase))
            {
                if (Authority.ProcessControText("采购合同") == true)
                {
                    path = "FishClient.FormPurcurementContract";
                    billNum = dataGridView1.Rows[e.RowIndex].Cells["codeNum"].Value.ToString();
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("fishId", StringComparison.OrdinalIgnoreCase))//fishId
            {
                if (Authority.ProcessControText("鱼粉资料") == true)
                {
                    FormNewFish fish = new FormNewFish(dataGridView1.Rows[e.RowIndex].Cells["fishId"].Value.ToString());
                    fish.Show();
                }
                
            }
            if (!string.IsNullOrEmpty(path))
                Reflected(path);
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            this.dtpStart.CustomFormat = null;
        }

        FormPaymentTabie PaymentTabie = null; FormBarnAssociation BarnTable = null;

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_129");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_129");
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
        FormPricingAssociation PricingTable = null;
        private void dataGridView1_CellClick ( object sender ,System . Windows . Forms . DataGridViewCellEventArgs e )
        {
            if ( e . RowIndex < 0 || e . ColumnIndex < 0 )
                return;
            
             if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ("codeNum2", StringComparison . OrdinalIgnoreCase ) )
            {
                if ( Authority . ProcessControText ( "付款申请单" ) == true )
                {
                    if (PaymentTabie == null || PaymentTabie.IsDisposed)

                    {

                        PaymentTabie = new FormPaymentTabie(dataGridView1.Rows[e.RowIndex].Cells["codeNum"].Value.ToString(), "C");

                        PaymentTabie.Show();//未打开，直接打开。

                    }

                    else

                    {

                        PaymentTabie.Activate();//已打开，获得焦点，置顶。

                    }
                }
            }
            else if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ("jindan1", StringComparison . OrdinalIgnoreCase ) )
            {
                if ( Authority . ProcessControText ( "进仓单" ) == true )
                {
                    //自营仓库                    
                    if (BarnTable == null || BarnTable.IsDisposed)
                    {
                        BarnTable = new  FormBarnAssociation(dataGridView1.Rows[e.RowIndex].Cells["codeNum"].Value.ToString());
                        BarnTable.Show();//未打开，直接打开。
                    }
                    else
                    {
                        BarnTable.Activate();//已打开，获得焦点，置顶。
                    }
                }
            }
            else if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ( "code2" ,StringComparison . OrdinalIgnoreCase ) )
            {
                if ( Authority . ProcessControText ( "行情定价单" ) == true )
                {
                    //行情定价表
                    if (PricingTable == null || PricingTable.IsDisposed)
                    {
                        PricingTable = new  FormPricingAssociation(dataGridView1.Rows[e.RowIndex].Cells["fishId"].Value.ToString());
                        PricingTable.Show();//未打开，直接打开。
                    }
                    else
                    {
                        PricingTable.Activate();//已打开，获得焦点，置顶。
                    }
                }
            }
        }

        void Reflected ( string path )
        {
            Assembly asm = Assembly . GetExecutingAssembly ( );
            Form doc = ( Form ) asm . CreateInstance ( path );
            Megres . oddNum = billNum;
            doc .ShowDialog( );
        }

    }
}
