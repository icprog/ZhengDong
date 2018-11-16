using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Text;
using System . Windows . Forms;

namespace FishClient
{
    public partial class FormBatchSheetQuery :FormBase
    {
        FishBll.Bll.BatchSheetBll _bll=null;
        public FormBatchSheetQuery ( string  text )
        {
            InitializeComponent ( );

            this . Text = text;
            _bll = new FishBll . Bll . BatchSheetBll ( );
        }

        string strWhere="1=1";

        public string getWhere
        {
            get
            {
                return strWhere;
            }
        }

        private void btnSure_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( comboBox1 . Text ) )
                strWhere = "1=1";
            else
                strWhere = strWhere + string . Format ( " AND code='{0}'" ,comboBox1 . Text );
            this . DialogResult = DialogResult . OK;
        }

        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }

        private void FormBatchSheetQuery_Load ( object sender ,EventArgs e )
        {
            comboBox1 . DataSource = _bll . getCodeD ( );
            comboBox1 . DisplayMember = "code";
        }
    }
}
