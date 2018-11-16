using System;
using System . Collections . Generic;
using System . Windows . Forms;

namespace FishClient
{
    public partial class FormSetPresaleRequisiton :FormMenuBase
    {
        public FormSetPresaleRequisiton ( string text )
        {
            InitializeComponent ( );

            this . Text = text;
        }
        
        public override int Query ( )
        {
            UIForms . FormFishCondition _queryForm = new UIForms . FormFishCondition ( );
            _queryForm . StartPosition = FormStartPosition . CenterParent;
            _queryForm . ShowInTaskbar = false;
            if ( _queryForm . ShowDialog ( ) != System . Windows . Forms . DialogResult . OK )
                return 0;
            string _where = _queryForm . GetWhere ( );

            FishBll . Bll . PresaleRequisitionBll _bll = new FishBll . Bll . PresaleRequisitionBll ( );
            List<FishEntity . ProductEntity> _list = _bll . getList ( _where );
            dataGridView1 . Rows . Clear ( );
            foreach ( FishEntity . ProductEntity ml in _list )
            {
                int idx = dataGridView1 . Rows . Add ( );
                DataGridViewRow row = dataGridView1 . Rows [ idx ];
                row . Cells [ "code" ] . Value = ml . code;
                row . Cells [ "name" ] . Value = ml . name;
                row . Cells [ "specification" ] . Value = ml . specification;
                row . Cells [ "brand" ] . Value = ml . brand;
                row . Cells [ "nature" ] . Value = ml . nature;
                row.Cells["sgs_protein"].Value = ml.sgs_protein;
                row.Cells["sgs_tvn"].Value = ml.sgs_tvn;
                row.Cells["sgs_graypart"].Value = ml.sgs_graypart;
                row.Cells["sgs_sandsalt"].Value = ml.sgs_sandsalt;
                row.Cells["sgs_amine"].Value = ml.sgs_amine;
                row.Cells["sgs_ffa"].Value = ml.sgs_ffa;
                row.Cells["sgs_fat"].Value = ml.sgs_fat;
                row.Cells["sgs_water"].Value = ml.sgs_water;
                row.Cells["sgs_sand"].Value = ml.sgs_sand;
                row.Cells["shipno"].Value = ml.shipno;
                row.Cells["billofgoods"].Value = ml.billofgoods;
                row.Cells["cornerno"].Value = ml.cornerno;
                row.Cells["warehouse"].Value = ml.warehouse;
            }
            

            return base . Query ( );
        }

        private void dataGridView1_CellMouseDoubleClick ( object sender ,DataGridViewCellMouseEventArgs e )
        {
            if ( e . RowIndex < 0 )
                return;

            if ( dataGridView1 . CurrentRow == null )
            {
                return;
            }
            //this . _model = dataGridView1 . CurrentRow . DataBoundItem as FishEntity . ProductEntity;
            _model = new FishEntity . ProductEntity ( );
            if ( dataGridView1 . Rows [ e . RowIndex ] . Cells [ "code" ] . Value != null )
                _model . code = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "code" ] . Value . ToString ( );
            else
                _model . code = string . Empty;
            if ( dataGridView1 . Rows [ e . RowIndex ] . Cells [ "name" ] . Value != null )
                _model . name = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "name" ] . Value . ToString ( );
            else
                _model . name = string . Empty;
            if ( dataGridView1 . Rows [ e . RowIndex ] . Cells [ "specification" ] . Value != null )
                _model . specification = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "specification" ] . Value . ToString ( );
            else
                _model . specification = string . Empty;
            if ( dataGridView1 . Rows [ e . RowIndex ] . Cells [ "brand" ] . Value != null )
                _model . brand = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "brand" ] . Value . ToString ( );
            else
                _model . brand = string . Empty;
            if ( dataGridView1 . Rows [ e . RowIndex ] . Cells [ "nature" ] . Value != null )
                _model . nature = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "nature" ] . Value . ToString ( );
            else
                _model . nature = string . Empty;
            if (dataGridView1.Rows[e.RowIndex].Cells["brand"].Value != null)
            {
                _model.brand = dataGridView1.Rows[e.RowIndex].Cells["brand"].Value.ToString();
            }
            else {
                _model.brand = string.Empty;
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["sgs_protein"].Value != null)
            {
                _model.sgs_protein = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_protein"].Value.ToString());
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["sgs_tvn"].Value != null)
            {
                _model.sgs_tvn = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_tvn"].Value.ToString());
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["sgs_sandsalt"].Value != null)
            {
                _model.sgs_sandsalt = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_sandsalt"].Value.ToString());
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["sgs_amine"].Value != null)
            {
                _model.sgs_amine = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_amine"].Value.ToString());
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["sgs_ffa"].Value != null)
            {
                _model.sgs_ffa = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_ffa"].Value.ToString());
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["sgs_fat"].Value != null)
            {
                _model.sgs_fat = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_fat"].Value.ToString());
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["sgs_water"].Value != null)
            {
                _model.sgs_water = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_water"].Value.ToString());
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["sgs_sand"].Value != null)
            {
                _model.sgs_sand = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_sand"].Value.ToString());
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["shipno"].Value != null)
            {
                _model.shipno = dataGridView1.Rows[e.RowIndex].Cells["shipno"].Value.ToString();
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["billofgoods"].Value != null)
            {
                _model.billofgoods = dataGridView1.Rows[e.RowIndex].Cells["billofgoods"].Value.ToString();
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["cornerno"].Value != null)
            {
                _model.cornerno = dataGridView1.Rows[e.RowIndex].Cells["cornerno"].Value.ToString();
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["warehouse"].Value != null)
            {
                _model.warehouse = dataGridView1.Rows[e.RowIndex].Cells["warehouse"].Value.ToString();
            }
            this . DialogResult = System . Windows . Forms . DialogResult . OK;
        }

        FishEntity . ProductEntity _model=null;

        public FishEntity . ProductEntity getPerson
        {
            get
            {
                return _model;
            }
        }
         
        private void FormSetPresaleRequisiton_Load ( object sender ,EventArgs e )
        {
            menuStrip1 . Visible = true;

            tmiAdd . Visible = false;
            tmiCancel . Visible = false;
            tmiClose . Visible = false;
            tmiDelete . Visible = false;
            tmiExport . Visible = false;
            tmiModify . Visible = false;
            tmiNext . Visible = false;
            tmiPrevious . Visible = false;
            tmiSave . Visible = false;
            tmiQuery . Visible = true;
        }
    }
}
