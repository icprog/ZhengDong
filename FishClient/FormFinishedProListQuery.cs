using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Text;
using System . Windows . Forms;

namespace FishClient
{
    public partial class FormFinishedProListQuery :FormBase
    {
        public FormFinishedProListQuery ( string text )
        {
            InitializeComponent ( );

            this . Text = text;
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
                strWhere = strWhere + string . Format ( " and code='{0}'" ,comboBox1 . Text );
            this . DialogResult = DialogResult . OK;
        }

        private void panel1_Paint ( object sender ,PaintEventArgs e )
        {
            
        }

        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }

        private void FormFinishedProListQuery_Load ( object sender ,EventArgs e )
        {
            FishBll . Bll . FinishedProListBll _bll = new FishBll . Bll . FinishedProListBll ( );
            comboBox1 . DataSource = _bll . getCodeT ( );
            comboBox1 . DisplayMember = "code";
        }
    }
}
