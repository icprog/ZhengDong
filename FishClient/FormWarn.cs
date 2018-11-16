using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Text;
using System . Windows . Forms;

namespace FishClient
{
    public partial class FormWarn :FormMenuBase
    {
        FishBll.Bll.WarnBll _bll=null;
        FishEntity.WarnEntity _model=null;

        bool result=false;
        int index=0;

        Dictionary<string,string> proDic=new Dictionary<string, string>();

        public FormWarn ( )
        {
            InitializeComponent ( );
            ReadColumnConfig(dataGridView1, "Set_148");

            _bll = new FishBll . Bll . WarnBll ( );

            _model = new FishEntity . WarnEntity ( );

            proDic = ProgramManager . setDicItem ( );
            BindingSource bs = new BindingSource ( );
            bs . DataSource = proDic;
            comboBox1 . DataSource = bs;
            comboBox1 . DisplayMember = "Value";
            comboBox1 . ValueMember = "Key";
        }

        private void comboBox1_SelectedValueChanged ( object sender ,EventArgs e )
        {
            textBox1 . Text = comboBox1 . SelectedValue . ToString ( );

            if ( comboBox1 . Text == string . Empty )
                return;
            DataTable table = _bll . getTablePosition ( comboBox1 . Text );
            comboBox7 . DataSource = table;
            comboBox7 . DisplayMember = "rolename";

        }
        private void comboBox2_SelectedValueChanged ( object sender ,EventArgs e )
        {
            comboBox2 . Tag = comboBox2 . SelectedValue;
        }
        private void comboBox3_SelectedValueChanged ( object sender ,EventArgs e )
        {
            comboBox3 . Tag = comboBox3 . SelectedValue;
        }
        private void comboBox4_SelectedValueChanged ( object sender ,EventArgs e )
        {
            comboBox4 . Tag = comboBox4 . SelectedValue;
        }
        private void comboBox5_SelectedValueChanged ( object sender ,EventArgs e )
        {
            comboBox5 . Tag = comboBox5 . SelectedValue;
        }
        private void comboBox6_SelectedValueChanged ( object sender ,EventArgs e )
        {
            comboBox6 . Tag = comboBox6 . SelectedValue;
        }
        //职位
        private void comboBox7_SelectedValueChanged ( object sender ,EventArgs e )
        {
            DataTable tableUser = _bll . getTableUser ( comboBox7 . Text );
            DataRow dr = tableUser.NewRow();
            dr["realname"] = "";
            dr["id"] = "0";
            tableUser.Rows.InsertAt(dr, 0);

            comboBox8 . DataSource = tableUser . Copy ( );
            comboBox8 . DisplayMember = "realname";
            comboBox8 . ValueMember = "id";
            comboBox9 . DataSource = tableUser . Copy ( ); 
            comboBox9 . DisplayMember = "realname";
            comboBox9 . ValueMember = "id";
        }
        //送审人
        private void comboBox8_SelectedValueChanged ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( comboBox7 . Text )&&string.IsNullOrEmpty(comboBox8.Text) )
            {
                //MessageBox . Show ( "请选择职位" );
                return;
            }
            comboBox8 . Tag = comboBox8 . SelectedValue;
            string id = comboBox8 . SelectedValue . ToString ( );

            proDic = ProgramManager . setDicItem ( );
            Dictionary<string ,string> proNewDic = new Dictionary<string ,string> ( );
            proNewDic . Add ( "" ,"" );

            DataTable tablePro = _bll . getTablePro ( id );
            if ( tablePro != null && tablePro . Rows . Count > 0 )
            {
                foreach ( DataRow row in tablePro . Rows )
                {
                    foreach ( string key in proDic . Keys )
                    {
                        if ( proDic [ key ] . Equals ( row [ "funname" ] ) )
                        {
                            if ( !proNewDic . ContainsKey ( key ) )
                                proNewDic . Add ( key ,proDic [ key ] );
                        }
                    }
                }
            }

            if ( proNewDic . Count < 1 )
                return;

            BindingSource bs1 = new BindingSource ( );
            bs1 . DataSource = proNewDic;
            comboBox2 . DataSource = bs1;
            comboBox2 . DisplayMember = "Value";
            comboBox2 . ValueMember = "Key";

            BindingSource bs2 = new BindingSource ( );
            bs2 . DataSource = proNewDic;
            comboBox3 . DataSource = bs2;
            comboBox3 . DisplayMember = "Value";
            comboBox3 . ValueMember = "Key";

            BindingSource bs3 = new BindingSource ( );
            bs3 . DataSource = proNewDic;
            comboBox4 . DataSource = bs3;
            comboBox4 . DisplayMember = "Value";
            comboBox4 . ValueMember = "Key";

            BindingSource bs4 = new BindingSource ( );
            bs4 . DataSource = proNewDic;
            comboBox5 . DataSource = bs4;
            comboBox5 . DisplayMember = "Value";
            comboBox5 . ValueMember = "Key";

            BindingSource bs5 = new BindingSource ( );
            bs5 . DataSource = proNewDic;
            comboBox6 . DataSource = bs5;
            comboBox6 . DisplayMember = "Value";
            comboBox6 . ValueMember = "Key";
        }
        private void comboBox9_SelectedValueChanged ( object sender ,EventArgs e )
        {
            if ( comboBox9 . SelectedValue == null )
            {
                comboBox9 . Tag = null;
                return;
            }
            comboBox9 . Tag = comboBox9 . SelectedValue . ToString ( );
        }
        public override int Add ( )
        {
            if ( getValue ( ) == false )
                return 0;

            if ( _bll . Exists ( _model ) )
            {
                MessageBox . Show ( "单据:" + _model . orderName + "\n\r送审人:" + _model . reviewUserName + "\n\r审核人:" + _model . examineUserName + "\n\r已经存在,请核实" );
                return 0;
            }

            index = 0;
            _model . id = _bll . Save ( _model );
            if ( _model . id > 0 )
            {
                comboBox1 . Tag = _model . id;
                DataGridViewRow Row = new DataGridViewRow ( );
                index = dataGridView1 . Rows . Add ( Row );
                dataGridView1 . Rows [ index ] . Cells [ "id" ] . Value = _model . id;
                dataGridView1 . Rows [ index ] . Cells [ "orderName" ] . Value = _model . orderName;
                dataGridView1 . Rows [ index ] . Cells [ "orderNum" ] . Value = _model . orderNum;
                dataGridView1 . Rows [ index ] . Cells [ "position" ] . Value = _model . position;
                dataGridView1 . Rows [ index ] . Cells [ "reviewUserName" ] . Value = _model . reviewUserName;
                dataGridView1 . Rows [ index ] . Cells [ "reviewUserNum" ] . Value = _model . reviewUserNum;
                dataGridView1 . Rows [ index ] . Cells [ "examineUserName" ] . Value = _model . examineUserName;
                dataGridView1 . Rows [ index ] . Cells [ "examineUserNum" ] . Value = _model . examineUserNum;
                dataGridView1 . Rows [ index ] . Cells [ "order1Name" ] . Value = _model . order1Name;
                dataGridView1 . Rows [ index ] . Cells [ "order1Num" ] . Value = _model . order1Num;
                dataGridView1 . Rows [ index ] . Cells [ "order2Name" ] . Value = _model . order2Name;
                dataGridView1 . Rows [ index ] . Cells [ "order2Num" ] . Value = _model . order2Num;
                dataGridView1 . Rows [ index ] . Cells [ "order3Name" ] . Value = _model . order3Name;
                dataGridView1 . Rows [ index ] . Cells [ "order3Num" ] . Value = _model . order3Num;
                dataGridView1 . Rows [ index ] . Cells [ "order4Name" ] . Value = _model . order4Name;
                dataGridView1 . Rows [ index ] . Cells [ "order4Num" ] . Value = _model . order4Num;
                dataGridView1 . Rows [ index ] . Cells [ "order5Name" ] . Value = _model . order5Name;
                dataGridView1 . Rows [ index ] . Cells [ "order5Num" ] . Value = _model . order5Num;
            }
            else
                MessageBox . Show ( "新增失败,请重试" );

            return base . Add ( );
        }

        public override int Modify ( )
        {
            if ( getValue ( ) == false )
                return 0;

            if ( _bll . Exists_Edit ( _model ) )
            {
                MessageBox . Show ( "单据:" + _model . orderName + "\n\r送审人:" + _model . reviewUserName + "\n\r审核人:" + _model . examineUserName + "\n\r已经存在,请核实" );
                return 0;
            }


            result = _bll . Edit ( _model );
            if ( result )
            {
                DataGridViewRow Row = dataGridView1 . Rows [ index ];
                Row . Cells [ "id" ] . Value = _model . id;
                Row . Cells [ "orderName" ] . Value = _model . orderName;
                Row . Cells [ "orderNum" ] . Value = _model . orderNum;
                Row . Cells [ "position" ] . Value = _model . position;
                Row . Cells [ "reviewUserName" ] . Value = _model . reviewUserName;
                Row . Cells [ "reviewUserNum" ] . Value = _model . reviewUserNum;
                Row . Cells [ "examineUserName" ] . Value = _model . examineUserName;
                Row . Cells [ "examineUserNum" ] . Value = _model . examineUserNum;
                Row . Cells [ "order1Name" ] . Value = _model . order1Name;
                Row . Cells [ "order1Num" ] . Value = _model . order1Num;
                Row . Cells [ "order2Name" ] . Value = _model . order2Name;
                Row . Cells [ "order2Num" ] . Value = _model . order2Num;
                Row . Cells [ "order3Name" ] . Value = _model . order3Name;
                Row . Cells [ "order3Num" ] . Value = _model . order3Num;
                Row . Cells [ "order4Name" ] . Value = _model . order4Name;
                Row . Cells [ "order4Num" ] . Value = _model . order4Num;
                Row . Cells [ "order5Name" ] . Value = _model . order5Name;
                Row . Cells [ "order5Num" ] . Value = _model . order5Num;
            }
            else
                MessageBox . Show ( "编辑失败" );

            return base . Modify ( );
        }

        public override int Delete ( )
        {
            _model . id = comboBox1 . Tag == null ? 0 : Convert . ToInt32 ( comboBox1 . Tag );
            if ( _model . id < 1 )
            {
                MessageBox . Show ( "请选择需要删除的内容" );
                return 0;
            }

            result = _bll . Delete ( _model . id );
            if ( result )
            {
                dataGridView1 . Rows . RemoveAt ( index );
            }
            else
                MessageBox . Show ( "删除失败" );

            return base . Delete ( );
        }

        bool getValue ( )
        {
            errorProvider1 . Clear ( );
            if ( string . IsNullOrEmpty ( comboBox1 . Text ) )
            {
                errorProvider1 . SetError ( comboBox1 ,"请选择" );
                return false;
            }
            if ( string . IsNullOrEmpty ( comboBox7 . Text ) )
            {
                errorProvider1 . SetError ( comboBox7 ,"请选择" );
                return false;
            }
            //if ( string . IsNullOrEmpty ( comboBox8 . Text ) )
            //{
            //    errorProvider1 . SetError ( comboBox8 ,"请选择" );
            //    return false;
            //}
            //if ( string . IsNullOrEmpty ( comboBox9 . Text ) )
            //{
            //    errorProvider1 . SetError ( comboBox9 ,"请选择" );
            //    return false;
            //}
            _model . id = comboBox1 . Tag == null ? 0 : Convert . ToInt32 ( comboBox1 . Tag );
            _model . orderName = comboBox1 . Text;
            _model . orderNum = textBox1 . Text;
            _model . reviewUserName = comboBox8 . Text;
            _model . reviewUserNum = comboBox8 . Tag == null ? string . Empty : comboBox8 . Tag . ToString ( );
            _model . examineUserName = comboBox9 . Text;
            _model . examineUserNum = comboBox9 . Tag == null ? string . Empty : comboBox9 . Tag . ToString ( );
            _model . position = comboBox7 . Text;
            _model . order1Name = comboBox2 . Text;
            _model . order1Num = comboBox2 . Tag == null ? string . Empty : comboBox2 . Tag . ToString ( );
            _model . order2Name = comboBox3 . Text;
            _model . order2Num = comboBox3 . Tag == null ? string . Empty : comboBox3 . Tag . ToString ( );
            _model . order3Name = comboBox4 . Text;
            _model . order3Num = comboBox4 . Tag == null ? string . Empty : comboBox4 . Tag . ToString ( );
            _model . order4Name = comboBox5 . Text;
            _model . order4Num = comboBox5 . Tag == null ? string . Empty : comboBox5 . Tag . ToString ( );
            _model . order5Name = comboBox6 . Text;
            _model . order5Num = comboBox6 . Tag == null ? string . Empty : comboBox6 . Tag . ToString ( );

            return true;
        }

        public override int Query ( )
        {
            dataGridView1 . Rows . Clear ( );
            List<FishEntity . WarnEntity> modelList = _bll . getList ( );
            if ( modelList == null )
                return 0;

            setValue ( modelList );

            return base . Query ( );
        }

        void setValue ( List<FishEntity . WarnEntity> modelList )
        {
            index = 0;
            foreach ( FishEntity . WarnEntity entity in modelList )
            {
                index = dataGridView1 . Rows . Add ( );
                dataGridView1 . Rows [ index ] . Cells [ "id" ] . Value = entity . id;
                dataGridView1 . Rows [ index ] . Cells [ "orderName" ] . Value = entity . orderName;
                dataGridView1 . Rows [ index ] . Cells [ "orderNum" ] . Value = entity . orderNum;
                dataGridView1 . Rows [ index ] . Cells [ "position" ] . Value = entity . position;
                dataGridView1 . Rows [ index ] . Cells [ "reviewUserName" ] . Value = entity . reviewUserName;
                dataGridView1 . Rows [ index ] . Cells [ "reviewUserNum" ] . Value = entity . reviewUserNum;
                dataGridView1 . Rows [ index ] . Cells [ "examineUserName" ] . Value = entity . examineUserName;
                dataGridView1 . Rows [ index ] . Cells [ "examineUserNum" ] . Value = entity . examineUserNum;
                dataGridView1 . Rows [ index ] . Cells [ "order1Name" ] . Value = entity . order1Name;
                dataGridView1 . Rows [ index ] . Cells [ "order1Num" ] . Value = entity . order1Num;
                dataGridView1 . Rows [ index ] . Cells [ "order2Name" ] . Value = entity . order2Name;
                dataGridView1 . Rows [ index ] . Cells [ "order2Num" ] . Value = entity . order2Num;
                dataGridView1 . Rows [ index ] . Cells [ "order3Name" ] . Value = entity . order3Name;
                dataGridView1 . Rows [ index ] . Cells [ "order3Num" ] . Value = entity . order3Num;
                dataGridView1 . Rows [ index ] . Cells [ "order4Name" ] . Value = entity . order4Name;
                dataGridView1 . Rows [ index ] . Cells [ "order4Num" ] . Value = entity . order4Num;
                dataGridView1 . Rows [ index ] . Cells [ "order5Name" ] . Value = entity . order5Name;
                dataGridView1 . Rows [ index ] . Cells [ "order5Num" ] . Value = entity . order5Num;
            }
        }

        private void dataGridView1_CellClick ( object sender ,DataGridViewCellEventArgs e )
        {
            if ( e . ColumnIndex < 0 && e . RowIndex < 0 )
                return;
            DataGridViewRow row = dataGridView1 . Rows [ e . RowIndex ];
            if ( row == null )
                return;

            comboBox1 . Tag = row . Cells [ "id" ] . Value . ToString ( );
            comboBox1 . Text = row . Cells [ "orderName" ] . Value . ToString ( );
            textBox1 . Text = row . Cells [ "orderNum" ] . Value . ToString ( );
            comboBox8 . Text = row . Cells [ "reviewUserName" ] . Value . ToString ( );
            comboBox8 . Tag = row . Cells [ "reviewUserNum" ] . Value . ToString ( );
            comboBox9 . Text = row . Cells [ "examineUserName" ] . Value . ToString ( );
            comboBox9 . Tag = row . Cells [ "examineUserNum" ] . Value . ToString ( );
            comboBox7 . Text = row . Cells [ "position" ] . Value . ToString ( );
            comboBox2 . Text = row . Cells [ "order1Name" ] . Value . ToString ( );
            comboBox2 . Tag = row . Cells [ "order1Num" ] . Value . ToString ( );
            comboBox3 . Text = row . Cells [ "order2Name" ] . Value . ToString ( );
            comboBox3 . Tag = row . Cells [ "order2Num" ] . Value . ToString ( );
            comboBox4 . Text = row . Cells [ "order3Name" ] . Value . ToString ( );
            comboBox4 . Tag = row . Cells [ "order3Num" ] . Value . ToString ( );
            comboBox5 . Text = row . Cells [ "order4Name" ] . Value . ToString ( );
            comboBox5 . Tag = row . Cells [ "order4Num" ] . Value . ToString ( );
            comboBox6 . Text = row . Cells [ "order5Name" ] . Value . ToString ( );
            comboBox6 . Tag = row . Cells [ "order5Num" ] . Value . ToString ( );

        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_148");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_148");
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

        private void FormWarn_Load(object sender, EventArgs e)
        {
            comboBox8.SelectedIndex = -1; comboBox9.SelectedIndex = -1;
        }
    }
}
