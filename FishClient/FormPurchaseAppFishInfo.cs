using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Text;
using System . Windows . Forms;

namespace FishClient
{
    //table:t_PurchaseAppFishInfo

    public partial class FormPurchaseAppFishInfo :FormMenuBase
    {
        FishEntity.PurchaseAppFishInfoEntity model=null;
        FishBll.Bll.PurchaseAppFishInfoBll _bll=null;
        string strWhere="1=1"; bool result=false;
        string getname = string.Empty;

        public FormPurchaseAppFishInfo ( string purNum )
        {
            InitializeComponent ( ); ReadColumnConfig(dataGridView1, "Set_132");

            _bll = new FishBll . Bll . PurchaseAppFishInfoBll ( );
            model = new FishEntity . PurchaseAppFishInfoEntity ( );
            getname = purNum;
            if ( !string . IsNullOrEmpty ( purNum ) )
                strWhere += " AND code='" + purNum + "'";
            else
                strWhere = "1=1";

            Query ( );
        }

        #region Mian
        public override int Add()
        {
            model = new FishEntity.PurchaseAppFishInfoEntity();
            model.code = getname;
            FormPurchaseAppFish form = new FormPurchaseAppFish(model);
            form.ShowInTaskbar = false;
            form.RefreshEvent += form_RefreshEvent;
            form.Show();
            return base.Add();
        }
        void form_RefreshEvent(EventArgs obj)
        {
            Query();
        }
        public override int Query ( )
        {
            List<FishEntity . PurchaseAppFishInfoEntity> modelList = _bll . getModel ( strWhere );
            if ( modelList == null )
                return 0;
            setValue ( modelList );
          
            return base . Query ( );
        }
        public override int Delete ( )
        {
            //if ( string . IsNullOrEmpty ( model.code ) )
            //{
            //    MessageBox . Show ( "请选择采购合同编号" );
            //    return 0;
            //}
            //if ( string . IsNullOrEmpty ( model.fishId ) )
            //{
            //    MessageBox . Show ( "请选择鱼粉id" );
            //    return 0;
            //}
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("请选择要编辑的行");
                return 0;
            }
            if (dataGridView1.CurrentRow.Cells["fishId"].Value == null&& dataGridView1.CurrentRow.Cells["fishId"].Value.ToString()==""&& dataGridView1.CurrentRow.Cells["code"].Value == null && dataGridView1.CurrentRow.Cells["code"].Value.ToString() == "") return 0;
            FishEntity.PurchaseAppFishInfoEntity entity = new FishEntity.PurchaseAppFishInfoEntity();
            entity.fishId = dataGridView1.CurrentRow.Cells["fishId"].Value.ToString();
            entity.code = dataGridView1.CurrentRow.Cells["code"].Value.ToString();
            if (entity == null)
            {
                MessageBox.Show("请选择需要编辑的行");
                return 0;
            }
            result = _bll . Delete (entity);
            if ( result == false )
                MessageBox . Show ( "删除失败" );
            else
            {
                Query ( );
            }

            return base . Delete ( );
        }
        #endregion

        #region Method
        void setValue ( List<FishEntity . PurchaseAppFishInfoEntity> modelList )
        {
            dataGridView1 . Rows . Clear ( );
            int idx = 0;
            decimal weight = 0M;
            foreach ( FishEntity . PurchaseAppFishInfoEntity model in modelList )
            {
                idx = dataGridView1 . Rows . Add ( );
                dataGridView1 . Rows [ idx ] . Cells [ "code" ] . Value = model . code;
                dataGridView1 . Rows [ idx ] . Cells [ "fishId" ] . Value = model . fishId;
                dataGridView1 . Rows [ idx ] . Cells [ "specifications" ] . Value = model . specifications;
                dataGridView1 . Rows [ idx ] . Cells [ "country" ] . Value = model . country;
                dataGridView1 . Rows [ idx ] . Cells [ "brand" ] . Value = model . brand;
                dataGridView1 . Rows [ idx ] . Cells [ "shipName" ] . Value = model . shipName;
                dataGridView1 . Rows [ idx ] . Cells [ "billName" ] . Value = model . billName;
                dataGridView1 . Rows [ idx ] . Cells [ "Money" ] . Value = model . money.ToString();
                dataGridView1 . Rows [ idx ] . Cells [ "num" ] . Value = model . num;
                dataGridView1 . Rows [ idx ] . Cells [ "conProtein" ] . Value = model . conProtein;
                dataGridView1 . Rows [ idx ] . Cells [ "conTVN" ] . Value = model . conTVN;
                dataGridView1 . Rows [ idx ] . Cells [ "conZA" ] . Value = model . conZA;
                dataGridView1 . Rows [ idx ] . Cells [ "conFFA" ] . Value = model . conFFA;
                dataGridView1 . Rows [ idx ] . Cells [ "conZF" ] . Value = model . conZF;
                dataGridView1 . Rows [ idx ] . Cells [ "conSF" ] . Value = model . conSF;
                dataGridView1 . Rows [ idx ] . Cells [ "conSHY" ] . Value = model . conSHY;
                dataGridView1 . Rows [ idx ] . Cells [ "conS" ] . Value = model . conS;
                dataGridView1.Rows[idx].Cells["conSJ"].Value = model.conSJ;
                dataGridView1 . Rows [ idx ] . Cells [ "conHF" ] . Value = model . conHF;
                dataGridView1 . Rows [ idx ] . Cells [ "conLAS" ] . Value = model . conLAS;
                dataGridView1 . Rows [ idx ] . Cells [ "conDAS" ] . Value = model . conDAS;
                dataGridView1 . Rows [ idx ] . Cells [ "choise" ] . Value = model . choise;
                dataGridView1.Rows[idx].Cells["price"].Value = model.price.ToString();
                dataGridView1 . Rows [ idx ] . Cells [ "fastshipdate" ] . Value = model . fastshipdate;
                dataGridView1 . Rows [ idx ] . Cells [ "lastshipdate" ] . Value = model . lastshipdate;
                dataGridView1.Rows[idx].Cells["priceMY"].Value = model.priceMY.ToString();
                dataGridView1.Rows[idx].Cells["EexchangeRate"].Value = model.EexchangeRate.ToString();
                weight += Convert . ToDecimal ( model . num );
            }
            textBox1 . Text = weight . ToString ( );
        }
        #endregion

        #region Event
        private void dataGridView1_CellClick ( object sender ,DataGridViewCellEventArgs e )
        {
            if ( e . ColumnIndex < 0 || e . RowIndex < 0 )
                return;
            if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ( "fishId" ,StringComparison . OrdinalIgnoreCase ) )
            {
                model . code = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "code" ] . Value . ToString ( );
                model . fishId = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "fishId" ] . Value . ToString ( );
                model . specifications = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "specifications" ] . Value . ToString ( );
                model . country = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "country" ] . Value . ToString ( );
                model . shipName = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "shipName" ] . Value . ToString ( );
                model . billName = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "billName" ] . Value . ToString ( );
                model . brand = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "brand" ] . Value . ToString ( );
                model . choise = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "choise" ] . Value . ToString ( );
                string str = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "Money" ] . Value . ToString ( );
                model . money = string . IsNullOrEmpty ( str ) == true ? 0 : Convert . ToDecimal ( str );
                str = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "num" ] . Value . ToString ( );
                model . num = string . IsNullOrEmpty ( str ) == true ? 0 : Convert . ToDecimal ( str );
                str = (dataGridView1 . Rows [ e . RowIndex ] . Cells [ "price" ] . Value . ToString ( )==null?string.Empty: dataGridView1.Rows[e.RowIndex].Cells["price"].Value.ToString());
                model . price = string . IsNullOrEmpty ( str ) == true ? 0 : Convert . ToDecimal ( str );
                model . conProtein = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conProtein" ] . Value . ToString ( );
                model . conTVN = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conTVN" ] . Value . ToString ( );
                model . conZA = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conZA" ] . Value . ToString ( );
                model . conFFA = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conFFA" ] . Value . ToString ( );
                model . conZF = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conZF" ] . Value . ToString ( );
                model . conSF = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conSF" ] . Value . ToString ( );
                model . conSHY = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conSHY" ] . Value . ToString ( );
                model . conS = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conS" ] . Value . ToString ( );
                model . conSJ = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conSJ" ] . Value . ToString ( );
                model . conHF = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conHF" ] . Value . ToString ( );
                model . conLAS = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conLAS" ] . Value . ToString ( );
                model . conDAS = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conDAS" ] . Value . ToString ( );
                str = dataGridView1.Rows[e.RowIndex].Cells["priceMY"].Value.ToString();
                model.priceMY = string.IsNullOrEmpty(str) == true ? 0 : Convert.ToDecimal(str);
                str = dataGridView1.Rows[e.RowIndex].Cells["EexchangeRate"].Value.ToString();
                model.EexchangeRate = string.IsNullOrEmpty(str) == true ? 0 : Convert.ToDecimal(str);
                str = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "fastShipDate" ] . Value . ToString ( );
                if ( string . IsNullOrEmpty ( str ) )
                    model . fastshipdate = null;
                else
                    model . fastshipdate = Convert . ToDateTime ( str );
                str = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "lastShipDate" ] . Value . ToString ( );
                if ( string . IsNullOrEmpty ( str ) )
                    model . lastshipdate = null;
                else
                    model . lastshipdate = Convert . ToDateTime ( str );
                FormPurchaseAppFish from = new FormPurchaseAppFish ( model );
                if ( from . ShowDialog ( ) == DialogResult . OK )
                {
                    model = from . getModel;
                    if ( model == null )
                        return;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "code" ] . Value = model . code;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "fishId" ] . Value = model . fishId;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "specifications" ] . Value = model . specifications;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "country" ] . Value = model . country;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "brand" ] . Value = model . brand;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "shipName" ] . Value = model . shipName;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "billName" ] . Value = model . billName;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "Money" ] . Value = model . money;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "num" ] . Value = model . num;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conProtein" ] . Value = model . conProtein;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conTVN" ] . Value = model . conTVN;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conZA" ] . Value = model . conZA;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conFFA" ] . Value = model . conFFA;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conZF" ] . Value = model . conZF;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conSF" ] . Value = model . conSF;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conSHY" ] . Value = model . conSHY;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conS" ] . Value = model . conS;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conSJ" ] . Value = model . conSJ;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conHF" ] . Value = model . conHF;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conLAS" ] . Value = model . conLAS;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "conDAS" ] . Value = model . conDAS;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "choise" ] . Value = model . choise;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "fastShipDate" ] . Value = model . fastshipdate;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "lastShipDate" ] . Value = model . lastshipdate;
                    dataGridView1.Rows[e.RowIndex].Cells["priceMY"].Value = model.priceMY;
                    dataGridView1.Rows[e.RowIndex].Cells["EexchangeRate"].Value = model.EexchangeRate;
                }
            }
            else if (!dataGridView1.Columns[e.ColumnIndex].Name.Equals("fishId", StringComparison.OrdinalIgnoreCase))
            {
                _model = new FishEntity.PurchaseAppFishInfoEntity();
                string str = (dataGridView1.Rows[e.RowIndex].Cells["Money"].Value.ToString() == null ? string.Empty : dataGridView1.Rows[e.RowIndex].Cells["Money"].Value.ToString());
                _model.money = string.IsNullOrEmpty(str) == true ? 0 : Convert.ToDecimal(str);
                _model.conProtein = dataGridView1.Rows[e.RowIndex].Cells["conProtein"].Value.ToString();
                _model.conTVN = dataGridView1.Rows[e.RowIndex].Cells["conTVN"].Value.ToString();
                _model.conZA = dataGridView1.Rows[e.RowIndex].Cells["conZA"].Value.ToString();
                _model.conFFA = dataGridView1.Rows[e.RowIndex].Cells["conFFA"].Value.ToString();
                _model.conZF = dataGridView1.Rows[e.RowIndex].Cells["conZF"].Value.ToString();
                _model.conSF = dataGridView1.Rows[e.RowIndex].Cells["conSF"].Value.ToString();
                _model.conSHY = dataGridView1.Rows[e.RowIndex].Cells["conSHY"].Value.ToString();
                _model.conS = dataGridView1.Rows[e.RowIndex].Cells["conS"].Value.ToString();
                _model.conSJ = dataGridView1.Rows[e.RowIndex].Cells["conSJ"].Value.ToString();
                _model.conHF = dataGridView1.Rows[e.RowIndex].Cells["conHF"].Value.ToString();
                _model.conLAS = dataGridView1.Rows[e.RowIndex].Cells["conLAS"].Value.ToString();
                _model.conDAS = dataGridView1.Rows[e.RowIndex].Cells["conDAS"].Value.ToString();
                str = dataGridView1.Rows[e.RowIndex].Cells["priceMY"].Value.ToString();
                _model.fishId = dataGridView1.Rows[e.RowIndex].Cells["fishId"].Value.ToString();
                _model.priceMY = string.IsNullOrEmpty(str) == true ? 0 : Convert.ToDecimal(str);
                this.DialogResult = DialogResult.OK;
            }
        }
        FishEntity.PurchaseAppFishInfoEntity _model = null;
        public FishEntity.PurchaseAppFishInfoEntity getModel
        {
            get
            {
                return _model;
            }
        }
        #endregion

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_132");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_132");
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
    }
}
