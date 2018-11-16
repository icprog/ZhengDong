using System . Collections . Generic;
using System . Windows . Forms;

namespace FishClient
{
    public partial class FormCustomStandardTable :FormMenuBase
    {
        //t_CustomStandardTable
        
        FishEntity.CustomStandardTableEntity _model=null;
        FishBll.Bll.CustomStandardTableBll _bll=null;
        bool result=false;
        
        public FormCustomStandardTable ( )
        {
            InitializeComponent ( ); ReadColumnConfig(dataGridView1, "Set_107");
            MenuCode = "M458"; ControlButtomRoles();
            InitDataUtil.BindComboBoxData(txtlevel, FishEntity.Constant.Specification, true);
            _model = new FishEntity . CustomStandardTableEntity ( );
            _bll = new FishBll . Bll . CustomStandardTableBll ( );
        }

        private void FormCustomStandardTable_Load ( object sender ,System . EventArgs e )
        {
            if ( Megres . oddNum != "" )
            {
                Query ( );
            }

            Megres . oddNum = string . Empty;
        }

        #region Main
        public override int Query ( )
        {
            List<FishEntity . CustomStandardTableEntity> modelLis = _bll . getModel ( );
            if ( modelLis != null && modelLis . Count > 0 )
            {
                setValue ( modelLis );
            }
            else
                MessageBox . Show ( "没有数据了" );

            return base . Query ( );
        }
        public override int Add ( )
        {
            clearControl ( );
            txtcode . Text = _bll . getCode ( );
            txtfishId . Text = _bll . getFishId ( );

            return base . Add ( );
        }
        public override int Delete ( )
        {
            _model . code = txtcode . Text;

            if ( !string . IsNullOrEmpty ( txtfishId . Text ) )
            {
                if ( _bll . Exists_idFishId ( _model . fishId ) )
                {
                    MessageBox . Show ( "此单据鱼粉ID已经被其他单据引用,不允许删除" );
                    return 0;
                }
            }

            //TODO:判断是否被销售申请单引用


            result = _bll . Delete ( _model . code );
            if ( result )
            {
                MessageBox . Show ( "成功删除" );
                Previous ( );
            }
            else
                MessageBox . Show ( "删除失败" );

            return base . Delete ( );
        }
        public override int Modify ( )
        {
            if ( getValue ( ) == false )
                return 0;
            result = _bll . Edit ( _model );
            if ( result )
            {
                MessageBox . Show ( "保存成功" );
                Query ( );
            }
            else
                MessageBox . Show ( "保存失败" );

            return base . Modify ( );
        }
        public override void Save ( )
        {
            if ( getValue ( ) == false )
                return;
            if ( _bll . Exists ( _model . code ) )
                result = _bll . Edit ( _model );
            else
                result = _bll . Save ( _model ,this . Name );
            if ( result )
            {
                MessageBox . Show ( "保存成功" );
                Query ( );
            }
            else
                MessageBox . Show ( "保存失败" );

            base . Save ( );
        }
        public override void Review ( )
        {
            Review ( this . Name ,txtcode . Text ,txtcode . Text );

            base . Review ( );
        }
        public override void Previous ( )
        {
            QueryOne ( "<" ,"'order by id asc limit 1'" );

            base . Previous ( );
        }
        public override void Next ( )
        {
            QueryOne ( ">" ,"'order by id asc limit 1'" );

            base . Next ( );
        }
        #endregion
        
        #region Event
        private void dataGridView1_CellDoubleClick ( object sender ,DataGridViewCellEventArgs e )
        {
            if ( e . ColumnIndex < 0 && e . RowIndex < 0 )
                this . DialogResult = DialogResult . Cancel;
            _model = new FishEntity.CustomStandardTableEntity();
            _model.code = dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
            _model.level = dataGridView1.Rows[e.RowIndex].Cells["level"].Value.ToString();
            _model.ash = dataGridView1.Rows[e.RowIndex].Cells["ash"].Value.ToString();
            _model.protein = dataGridView1.Rows[e.RowIndex].Cells["protein"].Value.ToString();
            _model.xd = dataGridView1.Rows[e.RowIndex].Cells["xd"].Value.ToString(); ;
            _model.TVN = dataGridView1.Rows[e.RowIndex].Cells["TVN"].Value.ToString();
            _model.fat = dataGridView1.Rows[e.RowIndex].Cells["fat"].Value.ToString();
            _model.ffa = dataGridView1.Rows[e.RowIndex].Cells["ffa"].Value.ToString();
            _model.water = dataGridView1.Rows[e.RowIndex].Cells["water"].Value.ToString();
            _model.histamine = dataGridView1.Rows[e.RowIndex].Cells["histamine"].Value.ToString();
            _model.shy = dataGridView1.Rows[e.RowIndex].Cells["shy"].Value.ToString();
            _model.fishId = dataGridView1.Rows[e.RowIndex].Cells["fishId"].Value.ToString();
            this . DialogResult = DialogResult . OK;
            
        }
        private void dataGridView1_CellClick ( object sender ,DataGridViewCellEventArgs e )
        {
            if ( e . ColumnIndex < 0 || e . RowIndex < 0 )
                return;

            txtcode . Text = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "code" ] . Value . ToString ( );
            txtlevel . Text = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "level" ] . Value . ToString ( );
            txtash . Text = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "ash" ] . Value . ToString ( );
            txtprotein . Text = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "protein" ] . Value . ToString ( );
            txtxd . Text = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "xd" ] . Value . ToString ( );
            txtfat . Text = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "fat" ] . Value . ToString ( );
            txtffa . Text = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "ffa" ] . Value . ToString ( );
            txtwater . Text = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "water" ] . Value . ToString ( );
            txthistamine . Text = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "histamine" ] . Value . ToString ( );
            txtshy . Text = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "shy" ] . Value . ToString ( );
            txtfishId . Text = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "fishId" ] . Value . ToString ( );
            txtxsCode . Text = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "xsCode" ] . Value . ToString ( );
        }
        private void txtfishId_DoubleClick ( object sender ,System . EventArgs e )
        {
            if ( string . IsNullOrEmpty ( txtfishId . Text ) )
                this . DialogResult = DialogResult . Cancel;
            this . DialogResult = DialogResult . OK;
        }
        #endregion

        #region Method 
        void clearControl ( )
        {
            foreach ( Control tc in splitContainer2.Panel1 . Controls )
            {
                if ( tc . GetType ( ) == typeof ( TextBox ) )
                {
                    TextBox tb = tc as TextBox;
                    tb . Text = string . Empty;
                }
                if ( tc . GetType ( ) == typeof ( ComboBox ) )
                {
                    ComboBox tb = tc as ComboBox;
                    tb . Text = string . Empty;
                }
            }
        }
        bool getValue ( )
        {
            _model = new FishEntity . CustomStandardTableEntity ( );
            errorProvider1 . Clear ( );
            if ( string . IsNullOrEmpty ( txtcode . Text ) )
            {
                errorProvider1 . SetError ( txtcode ,"不可为空" );
                return false;
            }
            if ( string . IsNullOrEmpty ( txtfishId . Text ) )
            {
                errorProvider1 . SetError ( txtfishId ,"不可为空" );
                return false;
            }

            _model . ash = txtash . Text;
            _model . code = txtcode . Text;
            _model . fat = txtfat . Text;
            _model . ffa = txtffa . Text;
            _model . histamine = txthistamine . Text;
            _model . level = txtlevel . Text;
            _model . protein = txtprotein . Text;
            _model . shy = txtshy . Text;
            _model . water = txtwater . Text;
            _model . xd = txtxd . Text;
            _model . fishId = txtfishId . Text;
            _model . xsCode = txtxsCode . Text;
            _model.TVN = txtTVN.Text;
            return true;
        }
        void setValue ( )
        {
            txtash . Text = _model . ash;
            txtcode . Text = _model . code;
            txtfat . Text = _model . fat;
            txtffa . Text = _model . ffa;
            txthistamine . Text = _model . histamine;
            txtlevel . Text = _model . level;
            txtprotein . Text = _model . protein;
            txtshy . Text = _model . shy;
            txtwater . Text = _model . water;
            txtxd . Text = _model . xd;
            txtfishId . Text = _model . fishId;
            txtcode . Text = _model . xsCode;
            txtTVN.Text = _model.TVN;
        }
        void setValue ( List<FishEntity . CustomStandardTableEntity> modelList)
        {
            dataGridView1 . Rows . Clear ( );
            foreach ( FishEntity . CustomStandardTableEntity entity in modelList )
            {
                int idx = dataGridView1 . Rows . Add ( );
                dataGridView1 . Rows [ idx ] . Cells [ "code" ] . Value = entity . code;
                dataGridView1 . Rows [ idx ] . Cells [ "level" ] . Value = entity . level;
                dataGridView1 . Rows [ idx ] . Cells [ "ash" ] . Value = entity .ash;
                dataGridView1 . Rows [ idx ] . Cells [ "protein" ] . Value = entity . protein;
                dataGridView1 . Rows [ idx ] . Cells [ "xd" ] . Value = entity . xd;
                dataGridView1 . Rows [ idx ] . Cells [ "fat" ] . Value = entity . fat;
                dataGridView1 . Rows [ idx ] . Cells [ "ffa" ] . Value = entity . ffa;
                dataGridView1 . Rows [ idx ] . Cells [ "water" ] . Value = entity . water;
                dataGridView1 . Rows [ idx ] . Cells [ "histamine" ] . Value = entity . histamine;
                dataGridView1 . Rows [ idx ] . Cells [ "shy" ] . Value = entity . shy;
                dataGridView1 . Rows [ idx ] . Cells [ "fishId" ] . Value = entity . fishId;
                dataGridView1 . Rows [ idx ] . Cells [ "xsCode" ] . Value = entity . xsCode;
                dataGridView1.Rows[idx].Cells["TVN"].Value = entity.TVN;
            }
        }
        void QueryOne ( string operate ,string orderBy )
        {
            string whereEx = "1=1" + " AND code " + operate + orderBy;

            _model = _bll . getModel ( whereEx );
            if ( _model == null )
            {
                MessageBox . Show ( "已经没有记录了" );
                return;
            }
            setValue ( );
        }
        public string getFishId
        {
            get
            {
                return txtfishId . Text;
            }
        }
        public FishEntity . CustomStandardTableEntity getModel
        {
            get
            {
                return _model;
            }
        }

        #endregion

        private void 设置列宽toolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_107");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_107");
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
