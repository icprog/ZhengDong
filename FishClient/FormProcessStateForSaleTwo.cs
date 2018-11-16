using System;
using System . Collections . Generic;
using System . Data;
using System . Drawing;
using System . Reflection;
using System . Windows . Forms;

namespace FishClient
{

    public partial class FormProcessStateForSaleTwo :FormMenuBase
    {
        FishBll.Bll.ProcessStateForSaleTwoBll _bll=null;
        DataTable tableView=null,table=null,tableErrorFK=null;
        ProcessControl Authority =null;
        string strWhere="1=1";
        
        public FormProcessStateForSaleTwo ( )
        {
            InitializeComponent ( ); ReadColumnConfig(dataGridView1, "Set_130");

            _bll = new FishBll . Bll . ProcessStateForSaleTwoBll ( );
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
        
        public override int Query ( )
        {
            strWhere = "1=1 and a.process='采购流程2' ";
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

        private void DealDataGridViewHeader ( )
        {
            UILibrary . TwoDimenDataGridView helper = new UILibrary . TwoDimenDataGridView ( dataGridView1 );
            UILibrary . TwoDimenDataGridView . TopHeader header1 = new UILibrary . TwoDimenDataGridView . TopHeader ( 7 ,2 ,"采购申请单" );
            UILibrary . TwoDimenDataGridView . TopHeader header2 = new UILibrary . TwoDimenDataGridView . TopHeader ( 9 ,2 ,"采购合同" );
            UILibrary . TwoDimenDataGridView . TopHeader header3 = new UILibrary . TwoDimenDataGridView . TopHeader ( 11 ,2 ,"付款申请单" );
            helper . Headers . AddRange ( new UILibrary . TwoDimenDataGridView . TopHeader [ ] { header1 ,header2 ,header3 } );
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

            //tmep.id = 0;
            tmep . username = " ";
            list1 . Insert ( 0 ,tmep );

            cmbCodeNumUser . DataSource = list1;
            cmbCodeNumUser . DisplayMember = "username";
            cmbCodeNumUser . ValueMember = "username";
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
            decimal w1 = 0M, w2 = 0M, w3 = 0M, w4 = 0M, w5 = 0M, w6 = 0M, w7 = 0M, w8 = 0M;
            for (int i = 0; i < tableView.Rows.Count; i++)
            {
                idx = dataGridView1.Rows.Add();

                w1 = string.IsNullOrEmpty(tableView.Rows[i]["weight"].ToString()) == true ? 0 : Convert.ToDecimal(tableView.Rows[i]["weight"].ToString());

                w2 = string.IsNullOrEmpty(tableView.Rows[i]["saWeight"].ToString()) == true ? 0 : Convert.ToDecimal(tableView.Rows[i]["saWeight"].ToString());

                w3 = string.IsNullOrEmpty(tableView.Rows[i]["applymoney"].ToString()) == true ? 0 : Convert.ToDecimal(tableView.Rows[i]["applymoney"].ToString());

                w4 = string.IsNullOrEmpty(tableView.Rows[i]["price"].ToString()) == true ? 0 : Convert.ToDecimal(tableView.Rows[i]["price"].ToString());

                w5 = string.IsNullOrEmpty(tableView.Rows[i]["weight"].ToString()) == true ? 0 : Convert.ToDecimal(tableView.Rows[i]["weight"].ToString());

                dataGridView1.Rows[idx].Cells["fishId"].Value = tableView.Rows[i]["fishId"].ToString();
                dataGridView1.Rows[idx].Cells["codeNum"].Value = tableView.Rows[i]["codeNum"].ToString();
                codeNumContract = tableView.Rows[i]["codeNumContract"].ToString();
                dataGridView1.Rows[idx].Cells["codeNumContract"].Value = codeNumContract;
                dataGridView1.Rows[idx].Cells["supplier"].Value = tableView.Rows[i]["supplier"].ToString();
                dataGridView1.Rows[idx].Cells["signDate"].Value = Convert.ToDateTime(tableView.Rows[i]["signDate"]).ToString("yyyy-MM-dd");
                //
                dataGridView1.Rows[idx].Cells["weight11"].Value = tableView.Rows[i]["weight11"].ToString();
                dataGridView1.Rows[idx].Cells["proName"].Value = tableView.Rows[i]["proName"].ToString();
                if (string.IsNullOrEmpty(tableView.Rows[i]["codeNum"].ToString()))
                    dataGridView1.Rows[i].Cells["createUser"].Style.BackColor = Color.FromName("LightBlue");
                else { 
                    dataGridView1.Rows[i].Cells["createUser"].Style.BackColor = Color.FromName("LightPink");
                dataGridView1.Rows[idx].Cells["createUser"].Value = tableView.Rows[i]["caigou1"].ToString();
            }
                if ( string . IsNullOrEmpty ( tableView . Rows [ i ] [ "code" ] . ToString ( ) ) )
                    dataGridView1 . Rows [ i ] . Cells [ "code" ] . Style . BackColor = Color . FromName ( "LightBlue" );
                else
                { 
                    dataGridView1 . Rows [ i ] . Cells [ "code" ] . Style . BackColor = Color . FromName ( "LightPink" );
                dataGridView1 . Rows [ idx ] . Cells [ "code" ] . Value = tableView . Rows [ i ] ["caigou2"] . ToString ( );
                }
                if ( string . IsNullOrEmpty ( tableView . Rows [ i ] [ "codeNumContract" ] . ToString ( ) ) )
                    dataGridView1 . Rows [ i ] . Cells [ "createUser1" ] . Style . BackColor = Color . FromName ( "LightBlue" );
                else { 
                    dataGridView1 . Rows [ i ] . Cells [ "createUser1" ] . Style . BackColor = Color . FromName ( "LightPink" );
                dataGridView1 . Rows [ idx ] . Cells [ "createUser1" ] . Value = tableView . Rows [ i ] ["caigou3"] . ToString ( );
                }
                if ( string . IsNullOrEmpty ( tableView . Rows [ i ] [ "code1" ] . ToString ( ) ) )
                    dataGridView1 . Rows [ i ] . Cells [ "code1" ] . Style . BackColor = Color . FromName ( "LightBlue" );
                else { 
                    dataGridView1 . Rows [ i ] . Cells [ "code1" ] . Style . BackColor = Color . FromName ( "LightPink" );
                dataGridView1 . Rows [ idx ] . Cells [ "code1" ] . Value = tableView . Rows [ i ] ["caigou3"] . ToString ( );
                }
                if ( !string . IsNullOrEmpty ( tableView . Rows [ i ] [ "coun" ] . ToString ( ) ) && Convert . ToDecimal ( tableView . Rows [ i ] [ "coun" ] . ToString ( ) ) < 100 )
                    dataGridView1 . Rows [ i ] . Cells [ "coun" ] . Style . BackColor = Color . FromName ( "LightBlue" );
                else
                    dataGridView1 . Rows [ i ] . Cells [ "coun" ] . Style . BackColor = Color . FromName ( "LightPink" );
                if ( string . IsNullOrEmpty ( tableView . Rows [ i ] [ "coun" ] . ToString ( ) ) )
                {
                    dataGridView1 . Rows [ idx ] . Cells [ "coun" ] . Value = tableView . Rows [ i ] [ "coun" ] . ToString ( ) + "0%";
                    dataGridView1 . Rows [ i ] . Cells [ "coun" ] . Style . BackColor = Color . FromName ( "LightBlue" );
                }
                else
                    dataGridView1 . Rows [ idx ] . Cells [ "coun" ] . Value = tableView . Rows [ i ] [ "coun" ] . ToString ( ) + "%";
                //if ( !string . IsNullOrEmpty ( tableView . Rows [ i ] [ "weight" ] . ToString ( ) ) && Convert . ToDecimal ( tableView . Rows [ i ] [ "weight" ] . ToString ( ) ) < 100 )
                //    dataGridView1 . Rows [ i ] . Cells [ "weight" ] . Style . BackColor = Color . FromName ( "LightBlue" );
                //else
                //    dataGridView1 . Rows [ i ] . Cells [ "weight" ] . Style . BackColor = Color . FromName ( "LightPink" );
                //if ( string . IsNullOrEmpty ( tableView . Rows [ i ] [ "weight" ] . ToString ( ) ) )
                //{
                //    dataGridView1 . Rows [ idx ] . Cells [ "weight" ] . Value = tableView . Rows [ i ] [ "weight" ] . ToString ( ) + "0%";
                //    dataGridView1 . Rows [ i ] . Cells [ "weight" ] . Style . BackColor = Color . FromName ( "LightBlue" );
                //}
                //else
                //    dataGridView1 . Rows [ idx ] . Cells [ "weight" ] . Value = tableView . Rows [ i ] [ "weight" ] . ToString ( ) + "%";

                if (  tableView . Rows [ i ] [ "codenum1" ] . ToString ( )=="")
                        dataGridView1.Rows[i].Cells["coun1"].Style.BackColor = Color.FromName("LightBlue");
                else { 
                    if (w2==w1)
                {
                    dataGridView1.Rows[i].Cells["coun1"].Style.BackColor = Color.FromName("LightPink");
                }
               else if (w2> w1)
                {
                    dataGridView1.Rows[i].Cells["coun1"].Style.BackColor = Color.FromName("Lightgreen");
                }
                else if (w2 < w1)

                    dataGridView1.Rows[i].Cells["coun1"].Style.BackColor = Color.FromName("yellow");
                }
                //if ( string . IsNullOrEmpty ( tableView . Rows [ i ] [ "code2" ] . ToString ( ) ) )
                //    dataGridView1 . Rows [ i ] . Cells [ "code2" ] . Style . BackColor = Color . FromName ( "LightBlue" );
                //else
                //    dataGridView1 . Rows [ i ] . Cells [ "code2" ] . Style . BackColor = Color . FromName ( "LightPink" );
                ////dataGridView1 . Rows [ i ] . Cells [ "code2" ] . Value = tableView . Rows [ i ] [ "code2" ] . ToString ( );

                //if ( string . IsNullOrEmpty ( tableView . Rows [ i ] [ "code3" ] . ToString ( ) ) )
                //    dataGridView1 . Rows [ i ] . Cells [ "code3" ] . Style . BackColor = Color . FromName ( "LightBlue" );
                //else
                //    dataGridView1 . Rows [ i ] . Cells [ "code3" ] . Style . BackColor = Color . FromName ( "LightPink" );
                ////dataGridView1 . Rows [ i ] . Cells [ "code3" ] . Value = tableView . Rows [ i ] [ "code3" ] . ToString ( );

                //if ( string . IsNullOrEmpty ( tableView . Rows [ i ] [ "code4" ] . ToString ( ) ) )
                //    dataGridView1 . Rows [ i ] . Cells [ "code4" ] . Style . BackColor = Color . FromName ( "LightBlue" );
                //else
                //    dataGridView1 . Rows [ i ] . Cells [ "code4" ] . Style . BackColor = Color . FromName ( "LightPink" );
                ////dataGridView1 . Rows [ i ] . Cells [ "code4" ] . Value = tableView . Rows [ i ] [ "code4" ] . ToString ( );

                //if ( !string . IsNullOrEmpty ( codeNumContract ) && result == true )
                //{
                //    if ( tableErrorFK . Select ( "purchasecode='" + codeNumContract + "'" ) . Length > 0 )
                //    {
                //        errorValue = tableErrorFK . Select ( "purchasecode='" + codeNumContract + "'" ) [ 0 ] [ "calcu" ] . ToString ( );
                //        if ( string . IsNullOrEmpty ( errorValue ) )
                //            dataGridView1 . Rows [ i ] . Cells [ "error" ] . Style . BackColor = Color . FromName ( "LightPink" );
                //        else if ( Convert . ToDecimal ( errorValue ) != 0 )
                //            dataGridView1 . Rows [ i ] . Cells [ "error" ] . Style . BackColor = Color . FromName ( "LightYellow" );
                //        else
                //            dataGridView1 . Rows [ i ] . Cells [ "error" ] . Style . BackColor = Color . FromName ( "LightPink" );
                //    }
                //    else
                //        dataGridView1 . Rows [ i ] . Cells [ "error" ] . Style . BackColor = Color . FromName ( "LightPink" );
                //}
                //else
                //    dataGridView1 . Rows [ i ] . Cells [ "error" ] . Style . BackColor = Color . FromName ( "LightPink" );

                if (tableView.Rows[i]["codenum2"].ToString() == "")
                    dataGridView1.Rows[i].Cells["error"].Style.BackColor = Color.FromName("LightBlue");
                else {
                    dataGridView1.Rows[i].Cells["error"].Value = w5.ToString();
                 if (w3 == w4)
                {
                    dataGridView1.Rows[i].Cells["error"].Style.BackColor = Color.FromName("LightPink");
                }
                else if (w3 > w4)
                {
                    dataGridView1.Rows[i].Cells["error"].Style.BackColor = Color.FromName("Lightgreen");
                }
                else if (w3 < w4) { 
                    dataGridView1.Rows[i].Cells["error"].Style.BackColor = Color.FromName("yellow");
                    }
                }
            }
        }

        string path = string.Empty;

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            this.dtpStart.CustomFormat = null;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            this.dtpEnd.CustomFormat = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPurchaseApplication from = new FormPurchaseApplication("采购流程2"); from.ShowDialog();
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
                    Megres.oddNum = dataGridView1.Rows[e.RowIndex].Cells["codeNum"].Value.ToString();
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("createUser1", StringComparison.OrdinalIgnoreCase))
            {
                if (Authority.ProcessControText("采购合同") == true)
                {
                    path = "FishClient.FormPurcurementContract";
                    Megres.oddNum = dataGridView1.Rows[e.RowIndex].Cells["codeNum"].Value.ToString();
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
        FormPaymentTabie PaymentTabie = null; FormBarnAssociation BarnTable = null;

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_130");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_130");
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
        private void dataGridView1_CellClick ( object sender ,System . Windows . Forms . DataGridViewCellEventArgs e )
        {
            if ( e . RowIndex < 0 || e . ColumnIndex < 0 )
                return;
            path = string.Empty;
            Megres.oddNum = string.Empty;
            if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ("error", StringComparison . OrdinalIgnoreCase ) )
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
            else if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ( "weight" ,StringComparison . OrdinalIgnoreCase ) )
            {
                if ( Authority . ProcessControText ( "进仓单" ) == true )
                {
                    //自营仓库
                    
                    if (BarnTable == null || BarnTable.IsDisposed)

                    {

                        BarnTable = new FormBarnAssociation(dataGridView1.Rows[e.RowIndex].Cells["codeNum"].Value.ToString());

                        BarnTable.Show();//未打开，直接打开。

                    }

                    else

                    {

                        BarnTable.Activate();//已打开，获得焦点，置顶。

                    }
                }
            }
            else if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ("coun1", StringComparison . OrdinalIgnoreCase ) )
            {
                if ( Authority . ProcessControText ( "入库申请单" ) == true)
                {
                    FormWarehousingAssociation WarehousingTable = new FormWarehousingAssociation(dataGridView1.Rows[e.RowIndex].Cells["codeNum"].Value.ToString());
                    WarehousingTable.ShowDialog();
                    //path = "FishClient.FormStorageOfRequisition";
                    //Megres . oddNum  = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "codeNumContract" ] . Value . ToString ( );
                    //Megres . fishId = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "fishId" ] . Value . ToString ( );
                }
            }
            else if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ( "code2" ,StringComparison . OrdinalIgnoreCase ) )
            {
                if ( Authority . ProcessControText ( "配料单" ) == true )
                {
                    FormIngredientAssociation IngredientTable = new FormIngredientAssociation(dataGridView1.Rows[e.RowIndex].Cells["codeNum"].Value.ToString());
                    IngredientTable.ShowDialog();
                }
            }
            else if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ( "code3" ,StringComparison . OrdinalIgnoreCase ))//FormProcessStateForMacOne
            {
                if ( Authority . ProcessControText ( "自定义标准表" ) == true )
                {
                    path = "FishClient.FormCustomStandardTable";
                    Megres . oddNum = "1=1";
                }
            }
            else if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ( "code4" ,StringComparison . OrdinalIgnoreCase ) )
            {
                if ( Authority . ProcessControText ( "成品出库单" ) == true )
                {
                    FormFinishedProductAssociation FinishedTable = new FormFinishedProductAssociation(dataGridView1.Rows[e.RowIndex].Cells["fishId"].Value.ToString());
                    FinishedTable.ShowDialog();
                }
            }
            if (!string.IsNullOrEmpty(path))
                Reflected(path);
        }

        void Reflected ( string path )
        {
            Assembly asm = Assembly . GetExecutingAssembly ( );
            Form doc = ( Form ) asm . CreateInstance ( path );
            doc .Show( );
        }

    }
}
