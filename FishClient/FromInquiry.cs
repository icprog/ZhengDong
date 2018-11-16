using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Text;
using System . Windows . Forms;

namespace FishClient
{
    public partial class FromInquiry :FormMenuBase
    {
        static string codenum = "";
        public FromInquiry ( )
        {
            InitializeComponent ( );
            
            //tmiExport . Visible = false;
            //tmiPrevious . Visible = false;
            //tmiNext . Visible = false;
            //tmiClose . Visible = false;
            //tmiCancel . Visible = false;
            //tmiSave . Visible = false;
            FishBll . Bll . InquiryBll _bll = new FishBll . Bll . InquiryBll ( );
            comboBox1 . DataSource = _bll . GetFishId ( );
            comboBox1 . DisplayMember = "code";

            ReadColumnConfig ( dataGridView1 ,"Set_SystemDataSet" );
        }

        private void FromInquiry_Load ( object sender ,EventArgs e )
        {
            dataGridView1 . BackgroundColor = this . BackColor;
        }

        public override int Add ( )
        {
            if ( string . IsNullOrEmpty (codenum) )
            {
                MessageBox . Show ( "请选择鱼粉ID" );
                return 0;
            }
            //if ( Check ( ) == false )
            //{
            //    MessageBox . Show ( "不存在此鱼粉ID,请核实" );
            //    return 1;
            //}

            FromInquirySet inven = new FromInquirySet ( "新增数据" ,null , codenum);
            inven . RefreshEvent += form_RefreshEvent;
            inven . ShowDialog ( );

            return 0;
        }

        void form_RefreshEvent ( EventArgs obj )
        {
            Query ( );
        }

        public override int Query ( )
        {
            //if ( Check ( ) == false )
            //{
            //    MessageBox . Show ( "不存在此鱼粉ID,请核实" );
            //    return 1;
            //}
            FishBll . Bll . InquiryBll _bll = new FishBll . Bll . InquiryBll ( );
            List<FishEntity . InquiryEntity> _modelList = _bll . GetModelList ( "code=" + codenum + "" );

            dataGridView1 . AutoGenerateColumns = false;
            dataGridView1 . DataSource = _modelList;
            return 1;
        }
        public void FromInquiry1(string code)
        {
            //tmiExport.Visible = true;
            //tmiPrevious.Visible = true;
            //tmiNext.Visible = true;
            //tmiClose.Visible = true;
            //tmiCancel.Visible = true;
            //comboBox1.DisplayMember = code;
            codenum = code;
            FishBll.Bll.InquiryBll _bll = new FishBll.Bll.InquiryBll();
            List<FishEntity.InquiryEntity> _modelList = _bll.GetModelList("code=" + code + "");
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _modelList;
        }
        protected bool Check ( )
        {
            bool isOk = true;
            FishBll . Bll . InquiryBll _bll = new FishBll . Bll . InquiryBll ( );
            isOk = _bll . Exists ( comboBox1 . Text );
            return isOk;
        }

        private void dataGridView1_CellContentDoubleClick ( object sender ,DataGridViewCellEventArgs e )
        {
            if ( e . RowIndex < 0 )
                return;
            Modify ( );
        }

        private void dataGridView1_CellDoubleClick ( object sender ,DataGridViewCellEventArgs e )
        {
            if ( e . RowIndex < 0 )
                return;
            Modify ( );
        }

        public override int Modify ( )
        {
            if ( dataGridView1 . CurrentCell == null )
            {
                MessageBox . Show ( "请选择要编辑的行" );
                return 0;
            }
            FishEntity . InquiryEntity entity = dataGridView1 . CurrentRow . DataBoundItem as FishEntity . InquiryEntity;
            if ( entity == null )
            {
                MessageBox . Show ( "请选择需要编辑的行" );
                return 0;
            }

            FromInquirySet inven = new FromInquirySet ( "编辑数据" ,entity ,codenum );
            inven . RefreshEvent += form_RefreshEvent;
            inven . ShowDialog ( );

            return 0;
        }

        public override int Delete ( )
        {
            if ( dataGridView1 . SelectedRows == null )
            {
                MessageBox . Show ( "请选择要删除的行记录" );
                return 0;
            }
            string ids = string . Empty;
            foreach ( DataGridViewRow row in dataGridView1 . SelectedRows )
            {
                if ( string . IsNullOrEmpty ( ids ) == false )
                {
                    ids += ",";
                }
                ids += row . Cells [ "id" ] . Value . ToString ( );
            }
            if ( string . IsNullOrEmpty ( ids ) )
            {
                MessageBox . Show ( "请选择要删除的行记录" );
                return 0;
            }

            if ( MessageBox . Show ( "您确定要删除选中的记录吗?" ,"询问" ,MessageBoxButtons . OKCancel ) == System . Windows . Forms . DialogResult . Cancel )
                return 0;

            FishBll . Bll . InquiryBll _bll = new FishBll . Bll . InquiryBll ( );
            if ( _bll . Delete ( ids ) )
                Query ( );

            return 1;
        }

        private void contextMenuStrip1_Click ( object sender ,EventArgs e )
        {
            UIForms . FormSetColumnWidth form = new UIForms . FormSetColumnWidth ( dataGridView1 . Columns ,"Set_SystemDataSet" );
            form . ShowDialog ( );

            ReadColumnConfig ( dataGridView1 ,"Set_SystemDataSet" );
        }

        protected void ReadColumnConfig (DataGridView gdv,string section )
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


    }
}
