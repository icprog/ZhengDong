using System . Collections . Generic;
using System . Windows . Forms;

namespace FishClient
{

    public partial class FormPresaleRContract :FormMenuBase
    {
        
        public FormPresaleRContract ( )
        {
            InitializeComponent ( );

            menuStrip1 . Items . Remove ( tmiAdd );
            menuStrip1 . Items . Remove ( tmiCancel );
            menuStrip1 . Items . Remove ( tmiClose );
            menuStrip1 . Items . Remove ( tmiDelete );
            menuStrip1 . Items . Remove ( tmiExport );
            menuStrip1 . Items . Remove ( tmiModify );
            menuStrip1 . Items . Remove ( tmiNext );
            menuStrip1 . Items . Remove ( tmiPrevious );
            menuStrip1 . Items . Remove ( tmiSave );

            dtpSigndate . Enabled = false;
            dataGridView1 . Enabled = false;
        }

        FishBll.Bll.PresaleRequisitionBll _bll=null;
        bool result=false;
        bool gnjc=false;

        public override int Query ( )
        {
            FormPresaleRequisition from = new FormPresaleRequisition ( );
            //DialogResult result = from . ShowDialog ( );
            //from . ShowDialog ( );
            from . StartPosition = FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) != DialogResult . OK )
                return 1;

            dataGridView1 . Rows . Clear ( );
            txtcode . Text = string . Empty;
            txtcode . Text = from . getCode;

            GenerateContect ( );
            if ( result == true )
                GenerateBody ( );

            return 1;
        }

        void GenerateContect ( )
        {
            _bll = new FishBll . Bll . PresaleRequisitionBll ( );
            result = _bll . Exists ( txtcode . Text );
            if ( result == true )
            {
                FishEntity . PresaleRequisitionHeadEntity _list = _bll . GetHeadList ( txtcode . Text );
                if ( _list == null )
                    return;
                headSetValue ( _list );
            }
            else
                MessageBox . Show ( "合同编号:" + txtcode . Text + "不存在,请核实" );

        }

        void headSetValue ( FishEntity . PresaleRequisitionHeadEntity _list )
        {
            txtsupplier . Text = _list . supplier;
            txtdemand . Text = _list . demand;
            dtpSigndate . Value = _list . Signdate;
            txtSignplace . Text = _list . Signplace;
            if ( _list . rebateBool == false )
            {
            }
            else
            {
            }
            if ( _list . PortpriceBool == false )
            {
                labPortpriceBool . Visible = false;
                texPortprice . Visible = false;
            }
            else
            {
                labPortpriceBool . Visible = true;
                texPortprice . Visible = true;
                texPortprice . Text = _list .Portprice . ToString ( );
            }
            texDeliveryPlace . Text = _list . DeliveryPlace;
            textransport . Text = _list . ModeOfTransport;
            texFreight . Text = _list . Freight . ToString ( );
            texDeliveryDeadline . Text = _list . DeliveryDeadline . ToString ( );
            texBanDan . Text = _list . BanDan;
            texOpenbank . Text = _list . Openbank;
            texCollectUnit . Text = _list . CollectUnit;
            texAcountNum . Text = _list . AcountNum;
            gnjc = _list . testIndex;
        }

        void GenerateBody ( )
        {
            _bll = new FishBll . Bll . PresaleRequisitionBll ( );
            List<FishEntity . PresaleRequisitionBodyEntity> modelList = _bll . GetBodyList ( txtcode . Text );
            if ( modelList . Count < 1 )
                return;
            bodySetValue ( modelList );
        }

        void bodySetValue ( List<FishEntity . PresaleRequisitionBodyEntity> modelList )
        {
            int i = 0;

            foreach ( FishEntity . PresaleRequisitionBodyEntity model in modelList )
            {
                int idx = dataGridView1 . Rows . Add ( );
                DataGridViewRow row = dataGridView1 . Rows [ idx ];
                row . Cells [ "codeNum_tre" ] . Value = model . codeNum;
                row . Cells [ "yfId" ] . Value = model . yfId;
                row . Cells [ "yfName" ] . Value = model . yfName;
                row . Cells [ "yfUnit" ] . Value = model . yfUnit;
                row . Cells [ "yfVarieties" ] . Value = model . yfVarieties;
                row . Cells [ "yfNum" ] . Value = model . yfNum;
                row . Cells [ "yfPrice" ] . Value = model . yfPrice;
                row . Cells [ "weight" ] . Value = model . weight;

                i++;
                if ( i > 1 )
                {
                    UILibrary . PresaleRControlSGS sgs = new UILibrary . PresaleRControlSGS ( );
                    sgs . Location = new System . Drawing . Point ( 0 ,118 * (i - 1) );
                    panel2 . Controls . Add ( sgs );
                    
                    //sgs . Dock = System . Windows . Forms . DockStyle . Top;
                    sgs . Visible = true;
                    sgs . Name = sgs + i . ToString ( );
                    sgs . setValue ( model ,gnjc );
                }
                else
                {
                    sgs1 . setValue ( model ,gnjc );
                }
            }
        }

    }

}
