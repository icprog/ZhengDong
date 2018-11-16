
using System . Collections . Generic;
using System . Windows . Forms;

namespace FishClient
{
    public partial class FormProgram :FormMenuBase
    {
        FishEntity.ProgramEntity list=new FishEntity.ProgramEntity();
        FishBll.Bll.ProgramBll _bll=new FishBll.Bll.ProgramBll();

        public FormProgram ( )
        {
            InitializeComponent ( );

            
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

            List<FishEntity . ProgramEntity> modelList = _bll . getList ( );
            if ( modelList != null )
            {
                dataGridView1 . Rows . Clear ( );
                foreach ( FishEntity . ProgramEntity list in modelList )
                {
                    int idx = dataGridView1 . Rows . Add ( );
                    DataGridViewRow row = dataGridView1 . Rows [ idx ];
                    row . Cells [ "programId" ] . Value = list . programId;
                    row . Cells [ "programName" ] . Value = list . programName;
                    row . Cells [ "programTable" ] . Value = list . programTable;
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

            List<FishEntity . ProgramEntity> modelList = new List<FishEntity . ProgramEntity> ( );
            foreach ( DataGridViewRow row in dataGridView1 . Rows )
            {
                if ( row . IsNewRow )
                    continue;

                list = new FishEntity . ProgramEntity ( );
                list . programId = row . Cells [ "programId" ] . Value == null ? string . Empty : row . Cells [ "programId" ] . Value . ToString ( );
                list . programName = row . Cells [ "programName" ] . Value == null ? string . Empty : row . Cells [ "programName" ] . Value . ToString ( );
                list . programTable = row . Cells [ "programTable" ] . Value == null ? string . Empty : row . Cells [ "programTable" ] . Value . ToString ( );

                modelList . Add ( list );
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

        private void dataGridView1_CellDoubleClick ( object sender ,DataGridViewCellEventArgs e )
        {
            if ( e . ColumnIndex < 0 || e . RowIndex < 0 )
                return;
            
            list . programId = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "programId" ] . Value == null ? string . Empty : dataGridView1 . Rows [ e . RowIndex ] . Cells [ "programId" ] . Value . ToString ( );
            list . programName = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "programName" ] . Value == null ? string . Empty : dataGridView1 . Rows [ e . RowIndex ] . Cells [ "programName" ] . Value . ToString ( );

            this . DialogResult = DialogResult . OK;
        }

        public FishEntity . ProgramEntity model
        {
            get
            {
                return list;
            }
        }

        private void FormProgram_Load ( object sender ,System . EventArgs e )
        {
            menuStrip1 . Visible = true;

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

            Query ( );
        }
    }
}
