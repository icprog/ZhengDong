

using System;
using System . Collections . Generic;
using System . Windows . Forms;

namespace FishClient
{
    //t_user  人员信息表
    public partial class FormSetReview :FormMenuBase
    {
       
        FishEntity.SetreviewEntity _list=null;
        FishBll.Bll.SetReviewBll _bll=new FishBll.Bll.SetReviewBll();

        public FormSetReview ( )
        {
            InitializeComponent ( );

            dataGridView1 . AllowUserToAddRows = false;
            dataGridView1 . AllowUserToDeleteRows = false;
            dataGridView1 . ReadOnly = true;

            tmiAdd . Visible = true;
            tmiQuery . Visible = true;
            tmiModify . Visible = false;
            tmiDelete . Visible = false;
            tmiReview . Visible = false;
            tmiSave . Visible = false;
            tmiCancel . Visible = false;
            tmiExport . Visible = false;
            tmiNext . Visible = false;
            tmiPrevious . Visible = false;
            tmiClose . Visible = true;

        }

        public override int Add ( )
        {
            tmiAdd . Visible = false;
            tmiQuery . Visible = false;
            tmiModify . Visible = false;
            tmiDelete . Visible = false;
            tmiReview . Visible = false;
            tmiSave . Visible = true;
            tmiCancel . Visible = true;
            tmiExport . Visible = false;
            tmiNext . Visible = false;
            tmiPrevious . Visible = false;
            tmiClose . Visible = false;

            dataGridView1 . AllowUserToAddRows = true;
            dataGridView1 . AllowUserToDeleteRows = true;
            dataGridView1 . ReadOnly = false;

            return base . Add ( );
        }

        public override int Query ( )
        {
            dataGridView1 . AllowUserToAddRows = false;
            dataGridView1 . AllowUserToDeleteRows = false;
            dataGridView1 . ReadOnly = true;

            tmiAdd . Visible = true;
            tmiQuery . Visible = true;
            tmiModify . Visible = true;
            tmiDelete . Visible = true;
            tmiReview . Visible = false;
            tmiSave . Visible = false;
            tmiCancel . Visible = false;
            tmiExport . Visible = false;
            tmiNext . Visible = false;
            tmiPrevious . Visible = false;
            tmiClose . Visible = true;

            List<FishEntity . SetreviewEntity> modelList = _bll . getList ( );
            if ( modelList != null )
            {
                dataGridView1 . Rows . Clear ( );
                foreach ( FishEntity . SetreviewEntity list in modelList )
                {
                    int idx = dataGridView1 . Rows . Add ( );
                    DataGridViewRow row = dataGridView1 . Rows [ idx ];
                    row . Cells [ "userName" ] . Value = list . userName;
                    row . Cells [ "programId" ] . Value = list . programId;
                    row . Cells [ "userNum" ] . Value = list . Realname;
                    row . Cells [ "programName" ] . Value = list . ProgramName;
                    row . Cells [ "level" ] . Value = list . level;
                }
            }

            return base . Query ( );
        }

        public override int Modify ( )
        {
            tmiAdd . Visible = false;
            tmiQuery . Visible = false;
            tmiModify . Visible = false;
            tmiDelete . Visible = false;
            tmiReview . Visible = false;
            tmiSave . Visible = true;
            tmiCancel . Visible = true;
            tmiExport . Visible = false;
            tmiNext . Visible = false;
            tmiPrevious . Visible = false;
            tmiClose . Visible = false;

            dataGridView1 . AllowUserToAddRows = true;
            dataGridView1 . AllowUserToDeleteRows = true;
            dataGridView1 . ReadOnly = false;

            return base . Modify ( );
        }

        public override int Delete ( )
        {
            if ( MessageBox . Show ( "全部删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return 0;

            bool resulu = _bll . Delete ( );
            if ( resulu == true )
            {
                MessageBox . Show ( "成功删除" );

                dataGridView1 . Rows . Clear ( );

                dataGridView1 . AllowUserToAddRows = false;
                dataGridView1 . AllowUserToDeleteRows = false;
                dataGridView1 . ReadOnly = true;

                tmiAdd . Visible = true;
                tmiQuery . Visible = true;
                tmiModify . Visible = false;
                tmiDelete . Visible = false;
                tmiReview . Visible = false;
                tmiSave . Visible = false;
                tmiCancel . Visible = false;
                tmiExport . Visible = false;
                tmiNext . Visible = false;
                tmiPrevious . Visible = false;
                tmiClose . Visible = true;

            }
            else
                MessageBox . Show ( "删除失败" );

            return base . Delete ( );
        }

        public override void Save ( )
        {
            dataGridView1 . EndEdit ( );

            //if ( check ( ) == false )
            //    return;

            List<FishEntity . SetreviewEntity> modelList = new List<FishEntity . SetreviewEntity> ( );
            foreach ( DataGridViewRow row in dataGridView1 . Rows )
            {
                if ( row . IsNewRow )
                    continue;

                _list = new FishEntity . SetreviewEntity ( );
                _list . programId = row . Cells [ "programId" ] . Value == null ? string . Empty : row . Cells [ "programId" ] . Value . ToString ( );
                _list . ProgramName = row . Cells [ "ProgramName" ] . Value == null ? string . Empty : row . Cells [ "ProgramName" ] . Value . ToString ( );
                _list . userName = row . Cells [ "userName" ] . Value == null ? string . Empty : row . Cells [ "userName" ] . Value . ToString ( );
                _list . Realname = row . Cells [ "userNum" ] . Value == null ? string . Empty : row . Cells [ "userNum" ] . Value . ToString ( );
                _list . level = row . Cells [ "level" ] . Value == null ? false : bool.Parse ( row . Cells [ "level" ] . Value . ToString ( ) );

                modelList . Add ( _list );
            }

            if ( modelList == null )
                return;

            bool result = _bll . add ( modelList ,FishEntity . Variable . User . username );
            if ( result == true )
            {
                MessageBox . Show ( "保存成功" );

                dataGridView1 . AllowUserToAddRows = false;
                dataGridView1 . AllowUserToDeleteRows = false;
                dataGridView1 . ReadOnly = true;

                tmiAdd . Visible = true;
                tmiQuery . Visible = true;
                tmiModify . Visible = false;
                tmiDelete . Visible = false;
                tmiReview . Visible = false;
                tmiSave . Visible = false;
                tmiCancel . Visible = false;
                tmiExport . Visible = false;
                tmiNext . Visible = false;
                tmiPrevious . Visible = false;
                tmiClose . Visible = true;
            }
            else
                MessageBox . Show ( "保存失败,请重试" );

            base . Save ( );
        }

        bool check ( )
        {
            bool result = true;
            for ( int i = 0 ; i < dataGridView1 . Rows . Count - 1 ; i++ )
            {
                if ( dataGridView1 . Rows [ i ] . Cells [ "level" ] . Value == null || dataGridView1 . Rows [ i ] . Cells [ "level" ] . Value . ToString ( ) . Trim ( ) == "" )
                {
                    MessageBox . Show ( "送审级别不可为空" );
                    result = false;
                    break;
                }
                int xs = 0;
                if ( int . TryParse ( dataGridView1 . Rows [ i ] . Cells [ "level" ] . Value . ToString ( ) ,out xs ) == false )
                {
                    MessageBox . Show ( "送审级别必须为数字" );
                    result = false;
                    break;
                }
            }

            return result;
        }

        public override void Cancel ( )
        {
            dataGridView1 . AllowUserToAddRows = false;
            dataGridView1 . AllowUserToDeleteRows = false;
            dataGridView1 . ReadOnly = true;

            tmiAdd . Visible = true;
            tmiQuery . Visible = true;
            tmiModify . Visible = false;
            tmiDelete . Visible = false;
            tmiReview . Visible = false;
            tmiSave . Visible = false;
            tmiCancel . Visible = false;
            tmiExport . Visible = false;
            tmiNext . Visible = false;
            tmiPrevious . Visible = false;
            tmiClose . Visible = true;

            base . Cancel ( );
        }

        private void dataGridView1_CellClick ( object sender ,System . Windows . Forms . DataGridViewCellEventArgs e )
        {

            if ( e . ColumnIndex < 0 || e . RowIndex < 0 )
                return;
            if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ( "programId" ,System . StringComparison . OrdinalIgnoreCase ) )
            {
                FormProgram from = new FormProgram ( );
                from . StartPosition = System . Windows . Forms . FormStartPosition . CenterParent;
                if ( from . ShowDialog ( ) != System . Windows . Forms . DialogResult . OK )
                    return;
                FishEntity . ProgramEntity model = from . model;
                dataGridView1 . Rows [ e . RowIndex ] . Cells [ "programId" ] . Value = model . programId;
                dataGridView1 . Rows [ e . RowIndex ] . Cells [ "programName" ] . Value = model . programName;
            }

            if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ( "userName" ,System . StringComparison . OrdinalIgnoreCase ) )
            {
                FormUserList from = new FormUserList ( true );
                from . StartPosition = System . Windows . Forms . FormStartPosition . CenterParent;
                if ( from . ShowDialog ( ) != System . Windows . Forms . DialogResult . OK )
                    return;
                FishEntity . PersonEntity model = from . SelectedPersion;
                dataGridView1 . Rows [ e . RowIndex ] . Cells [ "userName" ] . Value = model . username;
                dataGridView1 . Rows [ e . RowIndex ] . Cells [ "userNum" ] . Value = model . realname;
            }

        }


    }
}
