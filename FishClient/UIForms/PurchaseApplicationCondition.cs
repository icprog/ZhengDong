using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Text;
using System . Windows . Forms;

namespace FishClient . UIForms
{
    public partial class PurchaseApplicationCondition :FormBase
    {
        FishBll.Bll.PurchaseApplicationBll _bll=null;
        FishBll .Bll.PurcurementContractBll _bllCon=null;
        string strWhere="1=1";
        
        public PurchaseApplicationCondition ( string text )
        {
            InitializeComponent ( );

            this . Text = text;
            _bll = new FishBll . Bll . PurchaseApplicationBll ( );
            _bllCon = new FishBll . Bll . PurcurementContractBll ( );
        }

        public string getStrWhere
        {
            get
            {
                return strWhere;
            }
        }

        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }

        private void btnSure_Click ( object sender ,EventArgs e )
        {
            if ( !string . IsNullOrEmpty ( cmbCodNum . Text ) )
            {
                if ( this . Text . Contains ( "申请单" ) )
                    strWhere = " codeNum='" + cmbCodNum . Text + "'";
                else
                    strWhere = " codeNumContract='" + cmbCodNum . Text + "'";
            }
            else
                strWhere = " 1=1";

            this . DialogResult = DialogResult . OK;
        }

        private void PurchaseApplicationCondition_Load ( object sender ,EventArgs e )
        {
            if ( this . Text . Contains ( "申请单" ) )
            {

                cmbCodNum . DataSource = _bll . getCodeNumData ( );
                cmbCodNum . DisplayMember = "codeNum";
            }
            else
            {
                cmbCodNum . DataSource = _bllCon . getCodeNumData ( );
                cmbCodNum . DisplayMember = "codeNumContract";
            }
        }

    }
}
