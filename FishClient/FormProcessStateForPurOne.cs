using System;
using System . Collections . Generic;
using System . Data;
using System . Drawing;
using System . Reflection;
using System . Windows . Forms;

namespace FishClient
{
    public partial class FormProcessStateForPurOne :FormMenuBase
    {
        FishBll.Bll.ProcessStateForPurOneBll _bll=null;
        ProcessControl Authority =null;
        DataTable tableView,fishIdTable,tableErrorFK,tableWeiFK,tableErrorHWFK,tableWeiWTFK,tableKouWTFK,TableErrorForSK,TableWeiForSK;
        string strWhere=string.Empty;
        
        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            this.dtpStart.CustomFormat = null;
        }
        
        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            this.dtpEnd.CustomFormat = null;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            billNum = string.Empty;
            path = string.Empty;
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("createman", StringComparison.OrdinalIgnoreCase))
            {
                if (Authority.ProcessControText("销售申请单") == true)
                {
                    path = "FishClient.FormSalesRequisition";
                    billNum = dataGridView1.Rows[e.RowIndex].Cells["Numbering"].Value.ToString();
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("createman2", StringComparison.OrdinalIgnoreCase))
            {
                if (Authority.ProcessControText("现货销售合同") == true)
                {
                    path = "FishClient.FormSalesRContract";
                    billNum = dataGridView1.Rows[e.RowIndex].Cells["Numbering"].Value.ToString();
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("product_id", StringComparison.OrdinalIgnoreCase))//product_id
            {
                if (Authority.ProcessControText("鱼粉资料") == true)
                {
                    FormNewFish fish = new FormNewFish(dataGridView1.Rows[e.RowIndex].Cells["product_id"].Value.ToString());
                    fish.Show();
                }
            }
            if (!string.IsNullOrEmpty(path))
                Reflected(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormSalesRequisition form = new FormSalesRequisition("", "one");
            form.ShowDialog();
        }

        public FormProcessStateForPurOne ( )
        {
            InitializeComponent ( ); ReadColumnConfig(dataGridView1, "Set_127");

            _bll = new FishBll . Bll . ProcessStateForPurOneBll ( );
            Authority = new ProcessControl ( );
            tableView = new DataTable ( );
            tableErrorFK = new DataTable ( );
            fishIdTable = new DataTable ( );
            tableWeiFK = new DataTable ( );
            tableErrorHWFK = new DataTable ( );
            tableWeiWTFK = new DataTable ( );
            tableKouWTFK = new DataTable ( );
            TableErrorForSK = new DataTable ( );
            TableWeiForSK = new DataTable ( );

            DealDataGridViewHeader ( );
            User ( );
            fishIdTable = _bll . getFishTable ( );
            DataRow row = fishIdTable . NewRow ( );
            fishIdTable . Rows . InsertAt ( row ,0 );
            comfishId . DataSource = fishIdTable;
            comfishId . DisplayMember = "product_id";

            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.CustomFormat = "  ";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.CustomFormat = "  ";
        }

        public override int Query ( )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( comfishId . Text . Trim ( ) ) )
                strWhere = strWhere + " and b.product_id='" + comfishId . Text + "'";
            if ( !string . IsNullOrEmpty ( txtCodeNum . Text . Trim ( ) ) )
                strWhere = strWhere + " and a.Numbering like '%" + txtCodeNum . Text + "%'";
            if ( !string . IsNullOrEmpty ( txtCodeNumContract . Text . Trim ( ) ) )
                strWhere = strWhere + " and a.code like '%" + txtCodeNumContract . Text + "%'";
            if ( !string . IsNullOrEmpty ( cmbCodeNumUser . Text . Trim ( ) ) )
                strWhere = strWhere + " and a.createman='" + cmbCodeNumUser . Text + "'";

            if (!string.IsNullOrEmpty(txtsupplier.Text.Trim()))
                strWhere = strWhere + " and a.demand like'%" + txtsupplier.Text + "%'";
            if (!string.IsNullOrEmpty(dtpStart.Text.Trim()))
                strWhere = strWhere + " AND a.Signdate>='" + dtpStart.Text + "'";
            if (!string.IsNullOrEmpty(dtpEnd.Text.Trim()))
                strWhere = strWhere + " AND a.Signdate<='" + dtpEnd.Text + "'";
             strWhere = strWhere + " AND codeNumHq != '' or rabzy='1' ";
            tableView = _bll . getTableView ( strWhere );
            dataGridView1 . Rows . Clear ( );
            if ( tableView == null && tableView . Rows . Count < 1 )
                return 0;
            //tableErrorFK = _bll . getTableErrorForFK ( );
            //tableWeiFK = _bll . getTableWeiForFK ( );
            //tableErrorHWFK = _bll . getTabelErrorForHWFK ( );
            //tableWeiWTFK = _bll . getTableWeiForWTFK ( );
            //tableKouWTFK = _bll . getTableKouForWTFK ( );
            //TableErrorForSK = _bll . getTableErrorForSK ( );
            //TableWeiForSK = _bll . getTableWeiForSK ( );
            setValue ( );

            return base . Query ( );
        }

        void setValue ( )
        {
            string numbering = string . Empty, errorValue1 = string . Empty, weiValue1 = string . Empty, errorValue2 = string . Empty;
            bool result1 = false, result2 = false, result3 = false, result4 = false, result5 = false, result6 = false, result7 = false;
            //if ( tableErrorFK != null && tableErrorFK . Rows . Count > 0 )
            //{
            //    result1 = true;
            //}
            //if ( tableWeiFK != null && tableWeiFK . Rows . Count > 0 )
            //{
            //    result2 = true;
            //}
            //if ( tableErrorHWFK != null && tableErrorHWFK . Rows . Count > 0 )
            //{
            //    result3 = true;
            //}
            //if ( tableWeiWTFK != null && tableWeiWTFK . Rows . Count > 0 )
            //{
            //    result4 = true;
            //}
            //if ( tableKouWTFK != null && tableKouWTFK . Rows . Count > 0 )
            //{
            //    result5 = true;
            //}
            //if ( TableErrorForSK != null && TableErrorForSK . Rows . Count > 0 )
            //{
            //    result6 = true;
            //}
            //if ( TableWeiForSK != null && TableWeiForSK . Rows . Count > 0 )
            //{
            //    result7 = true;
            //}
            int idx = 0;
            string values = string . Empty;
            decimal w1 = 0M, w2 = 0M, w3 = 0M, w4 = 0M, w5 = 0M, w6 = 0M, w7 = 0M, w8 = 0M,shuzi=0M;
            for ( int i = 0 ; i < tableView . Rows . Count ; i++ )
            {
                idx = dataGridView1 . Rows . Add ( );
                //销售申请总重量
                w1 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "Quantity" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableView . Rows [ i ] [ "Quantity" ] . ToString ( ) );
                //付款申请单重量
                w2 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "weight" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableView . Rows [ i ] [ "weight" ] . ToString ( ) );
                //货物反馈单总磅单确认重量
                w3 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "ConfirmTheWeight" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableView . Rows [ i ] [ "ConfirmTheWeight" ] . ToString ( ) );
                //总扣款
                w4 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "Chargeback" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableView . Rows [ i ] [ "Chargeback" ] . ToString ( ) );
                //货物反馈单总磅单确认重量*销售申请单单价
                w5 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "unitCon" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableView . Rows [ i ] [ "unitCon" ] . ToString ( ) );
                //收款记录单总收款金额
                w6 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "rmb" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableView . Rows [ i ] [ "rmb" ] . ToString ( ) );
                //提货单总重量
                w7 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "ton" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableView . Rows [ i ] [ "ton" ] . ToString ( ) );
                //磅单
                w8 = string . IsNullOrEmpty ( tableView . Rows [ i ] [ "ton1" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableView . Rows [ i ] [ "ton1" ] . ToString ( ) );
                //百分比
                shuzi = string.IsNullOrEmpty(tableView.Rows[i]["overflow"].ToString()) == true ? 0 : Convert.ToDecimal(tableView.Rows[i]["overflow"].ToString());
                dataGridView1 . Rows [ i ] . Cells [ "product_id" ] . Value = tableView . Rows [ i ] [ "product_id" ] . ToString ( );
                //numbering = tableView . Rows [ i ] [ "Numbering" ] . ToString ( );
                dataGridView1 . Rows [ i ] . Cells [ "Numbering" ] . Value = tableView . Rows [ i ] [ "Numbering" ] . ToString ( );
                dataGridView1 . Rows [ i ] . Cells [ "ContractCode" ] . Value = tableView . Rows [ i ] [ "ContractCode" ] . ToString ( );
                dataGridView1 . Rows [ i ] . Cells [ "demand" ] . Value = tableView . Rows [ i ] [ "demand" ] . ToString ( );
                dataGridView1 . Rows [ i ] . Cells [ "Signdate" ] . Value = Convert.ToDateTime(tableView.Rows[i]["Signdate"]).ToString("yyyy-MM-dd");

                values = tableView . Rows [ i ] [ "createman" ] . ToString ( );
                if ( string . IsNullOrEmpty ( values ) )
                    dataGridView1 . Rows [ i ] . Cells [ "createman" ] . Style . BackColor = Color . FromName ( "Lightblue" );
                else
                    dataGridView1 . Rows [ i ] . Cells [ "createman" ] . Style . BackColor = Color . FromName ( "LightPink" );
                dataGridView1 . Rows [ i ] . Cells [ "createman" ] . Value = values;

                values = tableView . Rows [ i ] [ "code1" ] . ToString ( );
                if ( string . IsNullOrEmpty ( values ) )
                    dataGridView1 . Rows [ i ] . Cells [ "code1" ] . Style . BackColor = Color . FromName ( "Lightblue" );
                else
                {
                    dataGridView1 . Rows [ i ] . Cells [ "code1" ] . Value = values;
                    dataGridView1 . Rows [ i ] . Cells [ "code1" ] . Style . BackColor = Color . FromName ( "LightPink" );
                }

                values = tableView . Rows [ i ] [ "createman2" ] . ToString ( );
                if ( string . IsNullOrEmpty ( values ) )
                    dataGridView1 . Rows [ i ] . Cells [ "createman2" ] . Style . BackColor = Color . FromName ( "Lightblue" );
                else
                    dataGridView1 . Rows [ i ] . Cells [ "createman2" ] . Style . BackColor = Color . FromName ( "LightPink" );
                dataGridView1 . Rows [ i ] . Cells [ "createman2" ] . Value = values;

                values = tableView . Rows [ i ] [ "code2" ] . ToString ( );
                if ( string . IsNullOrEmpty ( values ) )
                    dataGridView1 . Rows [ i ] . Cells [ "code2" ] . Style . BackColor = Color . FromName ( "Lightblue" );
                else
                {
                    dataGridView1 . Rows [ i ] . Cells [ "code2" ] . Value = values;
                    dataGridView1 . Rows [ i ] . Cells [ "code2" ] . Style . BackColor = Color . FromName ( "LightPink" );
                }

                //付款申请单 
                values = tableView . Rows [ i ] [ "Numbering1" ] . ToString ( );
                if ( string . IsNullOrEmpty ( values ) )
                    dataGridView1 . Rows [ i ] . Cells [ "Numbering1" ] . Style . BackColor = Color . FromName ( "Lightblue" );
                else
                {
                    if ( w2 == 0 )
                        dataGridView1 . Rows [ i ] . Cells [ "Numbering1" ] . Style . BackColor = Color . FromName ( "LightGreen" );
                    else if ( w1 == w2 )
                        dataGridView1 . Rows [ i ] . Cells [ "Numbering1" ] . Style . BackColor = Color . FromName ( "LightPink" );
                    else if ( w1 != w2 )
                        dataGridView1 . Rows [ i ] . Cells [ "Numbering1" ] . Style . BackColor = Color . FromName ( "Yellow" );
                }
                //付款申请单审核
                values = tableView . Rows [ i ] [ "coun" ] . ToString ( );
                if (!string.IsNullOrEmpty(values))
                {
                    if (values == "0")
                    {
                        dataGridView1.Rows[i].Cells["coun"].Value = 0 + "%";
                        dataGridView1.Rows[i].Cells["coun"].Style.BackColor = Color.FromName("Lightblue");
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells["coun"].Value = values + "%";
                        dataGridView1.Rows[i].Cells["coun"].Style.BackColor = Color.FromName("LightPink");
                    }
                }
                else
                {
                    dataGridView1.Rows[i].Cells["coun"].Value = 0 + "%";
                    dataGridView1.Rows[i].Cells["coun"].Style.BackColor = Color.FromName("Lightblue");
                }
                //提货单
                values = tableView . Rows [ i ] [ "Numbering2" ] . ToString ( );
                if (w7!=0)
                dataGridView1.Rows[i].Cells["Numbering2"].Value = w7;
                if ( values == string . Empty )
                    dataGridView1 . Rows [ i ] . Cells [ "Numbering2" ] . Style . BackColor = Color . FromName ( "Lightblue" );
                else
                {
                    if ( w1 == w7 )
                        dataGridView1 . Rows [ i ] . Cells [ "Numbering2" ] . Style . BackColor = Color . FromName ( "LightPink" );
                    else
                        dataGridView1 . Rows [ i ] . Cells [ "Numbering2" ] . Style . BackColor = Color . FromName ( "Yellow" );
                }
                //磅单
                values = tableView . Rows [ i ] [ "Numbering3" ] . ToString ( );//tableView . Rows [ i ] [ "product_id" ] . ToString ( );
                if (w8 != 0)
                    dataGridView1.Rows[i].Cells["Numbering3"].Value = w8;
                if ( values == string . Empty )
                    dataGridView1 . Rows [ i ] . Cells [ "Numbering3" ] . Style . BackColor = Color . FromName ( "Lightblue" );
                else
                {
                    decimal num1 = 0;
                    num1 = shuzi*0.01M;
                    num1++;
                    if (w8 <= (w1 * shuzi) && w8 >= (w1 / shuzi))
                        dataGridView1 . Rows [ i ] . Cells [ "Numbering3" ] . Style . BackColor = Color . FromName ( "LightPink" );
                    else
                        dataGridView1 . Rows [ i ] . Cells [ "Numbering3" ] . Style . BackColor = Color . FromName ( "Yellow" );
                }
                //货物反馈单
                values = tableView . Rows [ i ] [ "Numbering4" ] . ToString ( );
                if (w3 != 0)
                    dataGridView1.Rows[i].Cells["Numbering4"].Value = w3;
                if ( values == string . Empty )
                    dataGridView1 . Rows [ i ] . Cells [ "Numbering4" ] . Style . BackColor = Color . FromName ( "Lightblue" );
                else
                {
                    if(w8== w3 )
                        dataGridView1 . Rows [ i ] . Cells [ "Numbering4" ] . Style . BackColor = Color . FromName ( "LightPink" );
                    else
                        dataGridView1 . Rows [ i ] . Cells [ "Numbering4" ] . Style . BackColor = Color . FromName ( "Yellow" );
                }
                //货物反馈单审核
                values = tableView . Rows [ i ] [ "coun1" ] . ToString ( );
                if (!string.IsNullOrEmpty(values))
                {
                    if (values == "0")
                    {
                        dataGridView1.Rows[i].Cells["coun1"].Value = 0 + "%";
                        dataGridView1.Rows[i].Cells["coun1"].Style.BackColor = Color.FromName("Lightblue");
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells["coun1"].Value = values + "%";
                        dataGridView1.Rows[i].Cells["coun1"].Style.BackColor = Color.FromName("LightPink");
                    }
                }
                else
                {
                    dataGridView1.Rows[i].Cells["coun1"].Value = 0 + "%";
                    dataGridView1.Rows[i].Cells["coun1"].Style.BackColor = Color.FromName("Lightblue");
                }

                //问题反馈单
                values = tableView . Rows [ i ] [ "Numbering5" ] . ToString ( );
                if ( string . IsNullOrEmpty ( values ) )
                    dataGridView1 . Rows [ i ] . Cells [ "Numbering5" ] . Style . BackColor = Color . FromName ( "Lightblue" );
                else
                {
                    if(w4==0)
                        dataGridView1 . Rows [ i ] . Cells [ "Numbering5" ] . Style . BackColor = Color . FromName ( "LightPink" );
                    else
                        dataGridView1 . Rows [ i ] . Cells [ "Numbering5" ] . Style . BackColor = Color . FromName ( "Yellow" );
                }
                //问题反馈单审核
                values = tableView . Rows [ i ] [ "coun2" ] . ToString ( );
                if (!string.IsNullOrEmpty(values))
                {
                    if (values == "0")
                    {
                        dataGridView1.Rows[i].Cells["coun2"].Value = 0 + "%";
                        dataGridView1.Rows[i].Cells["coun2"].Style.BackColor = Color.FromName("Lightblue");
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells["coun2"].Value = values + "%";
                        dataGridView1.Rows[i].Cells["coun2"].Style.BackColor = Color.FromName("LightPink");
                    }
                }
                else
                {
                    dataGridView1.Rows[i].Cells["coun2"].Value = 0 + "%";
                    dataGridView1.Rows[i].Cells["coun2"].Style.BackColor = Color.FromName("Lightblue");
                }
                //退货单
                values = tableView . Rows [ i ] [ "code3" ] . ToString ( );
                if(values==string.Empty)
                    dataGridView1 . Rows [ i ] . Cells [ "code3" ] . Style . BackColor = Color . FromName ( "Lightblue" );
                else
                    dataGridView1 . Rows [ i ] . Cells [ "code3" ] . Style . BackColor = Color . FromName ( "Yellow" );
                //收款记录单
                values = tableView . Rows [ i ] [ "Numbering6" ] . ToString ( );
                if ( values == string . Empty )
                    dataGridView1 . Rows [ i ] . Cells [ "Numbering6" ] . Style . BackColor = Color . FromName ( "Lightblue" );
                else
                {
                    if ( w5 - w4 == w6 )
                        dataGridView1 . Rows [ i ] . Cells [ "Numbering6" ] . Style . BackColor = Color . FromName ( "LightPink" );
                    else
                        dataGridView1 . Rows [ i ] . Cells [ "Numbering6" ] . Style . BackColor = Color . FromName ( "Yellow" );
                }
                //收款记录单审核
                values = tableView . Rows [ i ] [ "coun4" ] . ToString ( );
                if (!string.IsNullOrEmpty(values))
                {
                    if (values == "0")
                    {
                        dataGridView1.Rows[i].Cells["coun4"].Value = 0 + "%";
                        dataGridView1.Rows[i].Cells["coun4"].Style.BackColor = Color.FromName("Lightblue");
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells["coun4"].Value = values + "%";
                        dataGridView1.Rows[i].Cells["coun4"].Style.BackColor = Color.FromName("LightPink");
                    }
                }
                else
                {
                    dataGridView1.Rows[i].Cells["coun4"].Value = 0 + "%";
                    dataGridView1.Rows[i].Cells["coun4"].Style.BackColor = Color.FromName("Lightblue");
                }
            }
        }

        private void DealDataGridViewHeader ( )
        {
            UILibrary . TwoDimenDataGridView helper = new UILibrary . TwoDimenDataGridView ( dataGridView1 );
            UILibrary . TwoDimenDataGridView . TopHeader header1 = new UILibrary . TwoDimenDataGridView . TopHeader ( 5 ,2 ,"销售申请单" );
            UILibrary . TwoDimenDataGridView . TopHeader header2 = new UILibrary . TwoDimenDataGridView . TopHeader ( 7 ,2 ,"销售合同" );
            UILibrary . TwoDimenDataGridView . TopHeader header3 = new UILibrary . TwoDimenDataGridView . TopHeader ( 9 ,2 ,"付款申请单" );
            UILibrary . TwoDimenDataGridView . TopHeader header4 = new UILibrary . TwoDimenDataGridView . TopHeader ( 13 ,2 ,"货物反馈单" );
            UILibrary . TwoDimenDataGridView . TopHeader header5 = new UILibrary . TwoDimenDataGridView . TopHeader ( 15 ,2 ,"问题反馈单" );
            UILibrary . TwoDimenDataGridView . TopHeader header6 = new UILibrary . TwoDimenDataGridView . TopHeader ( 18 ,2 ,"收款记录单" );
            helper . Headers . AddRange ( new UILibrary . TwoDimenDataGridView . TopHeader [ ] { header1 ,header2 ,header3 ,header4,header5,header6 } );
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

            tmep . id = 0;
            tmep . username = " ";
            list1 . Insert ( 0 ,tmep );

            cmbCodeNumUser . DataSource = list1;
            cmbCodeNumUser . DisplayMember = "username";
            cmbCodeNumUser . ValueMember = "username";
        }

        string billNum = string.Empty, path = string.Empty;

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_127");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_127");
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

        FormBillofladingTable BillofladingTable = null;
        FormPaymentTabie PaymentTabie = null;
        FormOnepoundTable OnepoundTable = null;
        FormCargoFeedbackSheetTable CargoFeedbackSheetTable = null;
        FormTheproblemsheetTable Theproblemsheet = null;
        FormReturnAssociation ReturnTable = null;
        FormReceiptRecordtable ReceiptRecordtable = null;
        private void dataGridView1_CellClick ( object sender ,System . Windows . Forms . DataGridViewCellEventArgs e )
        {
            if ( e . RowIndex < 0 || e . ColumnIndex < 0 )
                return;
            billNum = string.Empty;
            path = string.Empty;

            if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ( "Numbering" ,StringComparison . OrdinalIgnoreCase ) )
            {
                if ( Authority . ProcessControText ( "销售申请单" ) == true )
                {
                    //关联表
                    FormSalesRequisition from = new FormSalesRequisition ( dataGridView1 . Rows [ e . RowIndex ] . Cells [ "Numbering" ] . Value . ToString ( ) );
                    from. ShowDialog ( );
                }
            }
            if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ( "ContractCode" ,StringComparison . OrdinalIgnoreCase ) )
            {
                if ( Authority . ProcessControText ( "现货销售合同" ) == true )
                {
                    //关联表
                    FormSalesRContract from1 = new FormSalesRContract ( dataGridView1 . Rows [ e . RowIndex ] . Cells [ "Numbering" ] . Value . ToString ( ) );
                    from1. ShowDialog ( );
                }
            }
            if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ( "Numbering1" ,StringComparison . OrdinalIgnoreCase ) )
            {
                if ( Authority . ProcessControText ( "付款申请单" ) == true )
                {
                    //关联表
                    if (PaymentTabie == null || PaymentTabie.IsDisposed)
                    {
                        PaymentTabie = new FormPaymentTabie(dataGridView1.Rows[e.RowIndex].Cells["Numbering"].Value.ToString(), "X");
                        PaymentTabie.Show();//未打开，直接打开。
                    }
                    else
                    {
                        PaymentTabie.Activate();//已打开，获得焦点，置顶。
                    }
                }
            }
            else if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ( "Numbering2" ,StringComparison . OrdinalIgnoreCase ) )
            {
                if ( Authority . ProcessControText ( "提货单" ) == true )
                {
                    //提货单表
                    if (BillofladingTable == null || BillofladingTable.IsDisposed)
                    {
                        BillofladingTable = new FormBillofladingTable(dataGridView1.Rows[e.RowIndex].Cells["Numbering"].Value.ToString());
                        BillofladingTable.Show();//未打开，直接打开。
                    }
                    else
                    {
                        BillofladingTable.Activate();//已打开，获得焦点，置顶。
                    }
                }
            }
            else if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ( "Numbering3" ,StringComparison . OrdinalIgnoreCase ) )
            {
                if ( Authority . ProcessControText ( "磅单" ) == true )
                {
                    //磅单表
                    if (OnepoundTable == null || OnepoundTable.IsDisposed)
                    {
                        OnepoundTable = new FormOnepoundTable(dataGridView1.Rows[e.RowIndex].Cells["Numbering"].Value.ToString(), false);
                        OnepoundTable.Show();//未打开，直接打开。
                    }
                    else
                    {
                        OnepoundTable.Activate();//已打开，获得焦点，置顶。
                    }
                }
            }
            else if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ( "Numbering4" ,StringComparison . OrdinalIgnoreCase ) )
            {
                if ( Authority . ProcessControText ( "货物反馈单" ) == true )
                {
                    //TODO:此处改成货物反馈关联表
                    if (CargoFeedbackSheetTable == null || CargoFeedbackSheetTable.IsDisposed)
                    {
                        CargoFeedbackSheetTable = new FormCargoFeedbackSheetTable(dataGridView1.Rows[e.RowIndex].Cells["Numbering"].Value.ToString());
                        CargoFeedbackSheetTable.Show();//未打开，直接打开。
                    }
                    else
                    {
                        CargoFeedbackSheetTable.Activate();//已打开，获得焦点，置顶。
                    }
                }
            }
            else if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ( "Numbering5" ,StringComparison . OrdinalIgnoreCase ) )
            {
                if ( Authority . ProcessControText ( "公司问题反馈单" ) == true )
                {
                    //TODO:此处改成问题反馈关联表
                    if (Theproblemsheet == null || Theproblemsheet.IsDisposed)
                    {
                        Theproblemsheet = new FormTheproblemsheetTable(dataGridView1.Rows[e.RowIndex].Cells["Numbering"].Value.ToString());
                        Theproblemsheet.Show();//未打开，直接打开。
                    }
                    else
                    {
                        Theproblemsheet.Activate();//已打开，获得焦点，置顶。
                    }
                }
            }
            else if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ( "code3" ,StringComparison . OrdinalIgnoreCase ) )
            {
                if ( Authority . ProcessControText ( "退货单" ) == true )
                {
                    //退货表
                    if (ReturnTable == null || ReturnTable.IsDisposed)
                    {
                        ReturnTable = new FormReturnAssociation(dataGridView1.Rows[e.RowIndex].Cells["Numbering"].Value.ToString());
                        ReturnTable.Show();//未打开，直接打开。
                    }
                    else
                    {
                        ReturnTable.Activate();//已打开，获得焦点，置顶。
                    }
                }
            }
            else if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ( "Numbering6" ,StringComparison . OrdinalIgnoreCase ) )
            {
                if ( Authority . ProcessControText ( "收款记录单" ) == true )
                {
                    //关联表
                    if (ReceiptRecordtable == null || ReceiptRecordtable.IsDisposed)
                    {
                        ReceiptRecordtable = new FormReceiptRecordtable(dataGridView1.Rows[e.RowIndex].Cells["Numbering"].Value.ToString());
                        ReceiptRecordtable.Show();//未打开，直接打开。
                    }
                    else
                    {
                        ReceiptRecordtable.Activate();//已打开，获得焦点，置顶。
                    }
                }
            }
            if ( !string . IsNullOrEmpty ( path ) )
                Reflected ( path );
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
