using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormDeliveredManagement : FormMenuBase
    {
        FishBll.Bll.DeliveredManagementBll _bll = null;
        FishEntity.DeliveredManagementEntity _model = null;

        public FormDeliveredManagement()
        {
            InitializeComponent();
            getCombox();
            getQuery();
        }
        public void getQuery() {
            _bll = new FishBll.Bll.DeliveredManagementBll();
            _model = new FishEntity.DeliveredManagementEntity();
            //_model = _bll.getList(strWhere);
            List<FishEntity . DeliveredManagementEntity> modelList = _bll . getModelList ( );
            if ( modelList != null && modelList . Count > 0 )
            {
                setValue ( modelList );
            }
            else
            {
                tmiAdd . Visible = true;
            }            
        }
        public override int Add()
        {
            tmiSave.Visible = true;
            return base.Add();            
        }
        public override int Modify()
        {
            List<FishEntity . DeliveredManagementEntity> modelList = getValue ( );
            //bool isOk= _bll.Update(_model);
            bool isOk = _bll . Update ( modelList );
            if (isOk == true)
            {
                MessageBox.Show("保存成功！");
                tmiAdd.Visible = tmiSave.Visible = false;
            }
            return base.Modify(); 
        }
        public override void Save ( )
        {
            List<FishEntity . DeliveredManagementEntity> modelList = getValue ( );
            //bool  isOk = _bll.Add(_model);
            bool isOk = _bll . Add ( modelList );
            if ( isOk == true )
            {
                MessageBox . Show ( "新建成功！" );
                tmiAdd . Visible = tmiSave . Visible = false;
            }
        }

        
        void setValue ( List<FishEntity . DeliveredManagementEntity> modelList )
        {
            foreach ( FishEntity . DeliveredManagementEntity model in modelList )
            {
                if ( model . TablePro . Equals ( "FormSalesRequisition" ) )
                {
                    cmbTJxssqd . Text = model . ReviewDepart;
                    txtTJxssqd . Text = model . ReviewUser;
                    cmbSGxssqd . Text = model . ExaminDepart;
                    txtSGxssqd . Text = model . ExaminUser;
                }
                else if ( model . TablePro . Equals ( "FormSalesRContract" ) )
                {
                    cmbTJxsht . Text = model . ReviewDepart;
                    txtTJxsht . Text = model . ReviewUser;
                    cmbSGxsht . Text = model . ExaminDepart;
                    txtSGxsht . Text = model . ExaminUser;
                }
                else if ( model . TablePro . Equals ( "FormPaymentRequisition" ) )
                {
                    cmbTJfksqd . Text = model . ReviewDepart;
                    txtTJfksqd . Text = model . ReviewUser;
                    cmbSGfksqd . Text = model . ExaminDepart;
                    txtSGfksqd . Text = model . ExaminUser;
                }
                else if ( model . TablePro . Equals ( "FormOnepound" ) )
                {
                    cmbTJbd . Text = model . ReviewDepart;
                    txtTJbd . Text = model . ReviewUser;
                    cmbSGbd . Text = model . ExaminDepart;
                    txtSGbd . Text = model . ExaminUser;
                }
                else if ( model . TablePro . Equals ( "FormCargoFeedbackSheet" ) )
                {
                    cmbTJhwfkd . Text = model . ReviewDepart;
                    txtTJhwfkd . Text = model . ReviewUser;
                    cmbSGhwfkd . Text = model . ExaminDepart;
                    txtSGhwfkd . Text = model . ExaminUser;
                }
                else if ( model . TablePro . Equals ( "FormTheproblemsheet" ) )
                {
                    cmbTJgswtfkd . Text = model . ReviewDepart;
                    txtTJgswtfkd . Text = model . ReviewUser;
                    cmbSGgswtfkd . Text = model . ExaminDepart;
                    txtSGgswtfkd . Text = model . ExaminUser;
                }
                else if ( model . TablePro . Equals ( "FormReceiptRecord" ) )
                {
                    cmbTJskjld . Text = model . ReviewDepart;
                    txtTJskjld . Text = model . ReviewUser;
                    cmbSGskjld . Text = model . ExaminDepart;
                    txtSGskjld . Text = model . ExaminUser;
                }
                else if ( model . TablePro . Equals ( "FormPurchaseApplication" ) )
                {
                    cmbCgR . Text = model . ReviewDepart;
                    txtCgR . Text = model . ReviewUser;
                    cmbCgE . Text = model . ExaminDepart;
                    txtCgE . Text = model . ExaminUser;
                }
                else if ( model . TablePro . Equals ( "FormPurcurementContract" ) )
                {
                    cmbCgCR . Text = model . ReviewDepart;
                    txtCgCR . Text = model . ReviewUser;
                    cmbCgCE . Text = model . ExaminDepart;
                    txtCgCE . Text = model . ExaminUser;
                }
                else if ( model . TablePro . Equals ( "FormWarehouseReceipt" ) )
                {
                    cmJcR . Text = model . ReviewDepart;
                    txtJcR . Text = model . ReviewUser;
                    cmJcE . Text = model . ExaminDepart;
                    txtJcE . Text = model . ExaminUser;
                }
                else if ( model . TablePro . Equals ( "FormStorageOfRequisition" ) )
                {
                    cmbRkR . Text = model . ReviewDepart;
                    txtRkR . Text = model . ReviewUser;
                    cmbRkE . Text = model . ExaminDepart;
                    txtRkE . Text = model . ExaminUser;
                }
                else if ( model . TablePro . Equals ( "FormBatchSheet" ) )
                {
                    cmbPlR . Text = model . ReviewDepart;
                    txtPlR . Text = model . ReviewUser;
                    cmbPlE . Text = model . ExaminDepart;
                    txtPlE . Text = model . ExaminUser;
                }
                else if ( model . TablePro . Equals ( "FormQuotationPriceList" ) )
                {
                    cmbHqR . Text = model . ReviewDepart;
                    txtHqR . Text = model . ReviewUser;
                    cmbHqE . Text = model . ExaminDepart;
                    txtHqE . Text = model . ExaminUser;
                }
                else if ( model . TablePro . Equals ( "FormFinishedProList" ) )
                {
                    cmbCkR . Text = model . ReviewDepart;
                    txtCkR . Text = model . ReviewUser;
                    cmbCpE . Text = model . ExaminDepart;
                    txtCpE . Text = model . ExaminUser;
                }
                else if ( model . TablePro . Equals ( "FormCustomStandardTable" ) )
                {
                    cmbBzR . Text = model . ReviewDepart;
                    txtBzR . Text = model . ReviewUser;
                    cmbBzE . Text = model . ExaminDepart;
                    txtBzE . Text = model . ExaminUser;
                }
                else if ( model . TablePro . Equals ( "FormBilloflading" ) )
                {
                    cmbThR . Text = model . ReviewDepart;
                    txtThR . Text = model . ReviewUser;
                    cmbThE . Text = model . ExaminDepart;
                    txtThE . Text = model . ExaminUser;
                }
                else if ( model . TablePro . Equals ( "FormOutboundOrder" ) )
                {
                    cmbckdR . Text = model . ReviewDepart;
                    txtckdR . Text = model . ReviewUser;
                    cmbckdE . Text = model . ExaminDepart;
                    txtckdE . Text = model . ExaminUser;
                }
                else if ( model . TablePro . Equals ( "FormReturnReceipt" ) )
                {
                    cmbThdR . Text = model . ReviewDepart;
                    txtThdR . Text = model . ReviewUser;
                    cmbThdE . Text = model . ExaminDepart;
                    txtThdE . Text = model . ExaminUser;
                }
            }
        }

        List<FishEntity . DeliveredManagementEntity> getValue ( )
        {
            List<FishEntity . DeliveredManagementEntity> modelList = new List<FishEntity . DeliveredManagementEntity> ( );
            _model = new FishEntity . DeliveredManagementEntity ( );
            _model . TablePro = "FormSalesRequisition";
            _model . ReviewDepart = cmbTJxssqd . Text;
            _model . ReviewUser = txtTJxssqd . Text;
            _model . ExaminDepart = cmbSGxssqd . Text;
            _model . ExaminUser = txtSGxssqd . Text;
            modelList . Add ( _model );
            _model = new FishEntity . DeliveredManagementEntity ( );
            _model . TablePro = "FormSalesRContract";
            _model . ReviewDepart = cmbTJxsht . Text;
            _model . ReviewUser = txtTJxsht . Text;
            _model . ExaminDepart = cmbSGxsht . Text;
            _model . ExaminUser = txtSGxsht . Text;
            modelList . Add ( _model );
            _model = new FishEntity . DeliveredManagementEntity ( );
            _model . TablePro = "FormPaymentRequisition";
            _model . ReviewDepart = cmbTJfksqd . Text;
            _model . ReviewUser = txtTJfksqd . Text;
            _model . ExaminDepart = cmbSGfksqd . Text;
            _model . ExaminUser = txtSGfksqd . Text;
            modelList . Add ( _model );
            _model = new FishEntity . DeliveredManagementEntity ( );
            _model . TablePro = "FormOnepound";
            _model . ReviewDepart = cmbTJbd . Text;
            _model . ReviewUser = txtTJbd . Text;
            _model . ExaminDepart = cmbSGbd . Text;
            _model . ExaminUser = txtSGbd . Text;
            modelList . Add ( _model );
            _model = new FishEntity . DeliveredManagementEntity ( );
            _model . TablePro = "FormCargoFeedbackSheet";
            _model . ReviewDepart = cmbTJhwfkd . Text;
            _model . ReviewUser = txtTJhwfkd . Text;
            _model . ExaminDepart = cmbSGhwfkd . Text;
            _model . ExaminUser = txtSGhwfkd . Text;
            modelList . Add ( _model );
            _model = new FishEntity . DeliveredManagementEntity ( );
            _model . TablePro = "FormTheproblemsheet";
            _model . ReviewDepart = cmbTJgswtfkd . Text;
            _model . ReviewUser = txtTJgswtfkd . Text;
            _model . ExaminDepart = cmbSGgswtfkd . Text;
            _model . ExaminUser = txtSGgswtfkd . Text;
            modelList . Add ( _model );
            _model = new FishEntity . DeliveredManagementEntity ( );
            _model . TablePro = "FormReceiptRecord";
            _model . ReviewDepart = cmbTJskjld . Text;
            _model . ReviewUser = txtTJskjld . Text;
            _model . ExaminDepart = cmbSGskjld . Text;
            _model . ExaminUser = txtSGskjld . Text;
            modelList . Add ( _model );
            _model = new FishEntity . DeliveredManagementEntity ( );
            _model . TablePro = "FormPurchaseApplication";
            _model . ReviewDepart = cmbCgR . Text;
            _model . ReviewUser = txtCgR . Text;
            _model . ExaminDepart = cmbCgE . Text;
            _model . ExaminUser = txtCgE . Text;
            modelList . Add ( _model );
            _model = new FishEntity . DeliveredManagementEntity ( );
            _model . TablePro = "FormPurcurementContract";
            _model . ReviewDepart = cmbCgCR . Text;
            _model . ReviewUser = txtCgCR . Text;
            _model . ExaminDepart = cmbCgCE . Text;
            _model . ExaminUser = txtCgCE . Text;
            modelList . Add ( _model );
            _model = new FishEntity . DeliveredManagementEntity ( );
            _model . TablePro = "FormWarehouseReceipt";
            _model . ReviewDepart = cmJcR . Text;
            _model . ReviewUser = txtJcR . Text;
            _model . ExaminDepart = txtJcE . Text;
            modelList . Add ( _model );
            _model = new FishEntity . DeliveredManagementEntity ( );
            _model . TablePro = "FormStorageOfRequisition";
            _model . ReviewDepart = cmbRkR . Text;
            _model . ReviewUser = txtRkR . Text;
            _model . ExaminDepart = cmbRkE . Text;
            _model . ExaminUser = txtRkE . Text;
            modelList . Add ( _model );
            _model = new FishEntity . DeliveredManagementEntity ( );
            _model . TablePro = "FormBatchSheet";
            _model . ReviewDepart = cmbPlR . Text;
            _model . ReviewUser = txtPlR . Text;
            _model . ExaminDepart = cmbPlE . Text;
            _model . ExaminUser = txtPlE . Text;
            modelList . Add ( _model );
            _model = new FishEntity . DeliveredManagementEntity ( );
            _model . TablePro = "FormQuotationPriceList";
            _model . ReviewDepart = cmbHqR . Text;
            _model . ReviewUser = txtHqR . Text;
            _model . ExaminDepart = cmbHqE . Text;
            _model . ExaminUser = txtHqE . Text;
            modelList . Add ( _model );
            _model = new FishEntity . DeliveredManagementEntity ( );
            _model . TablePro = "FormFinishedProList";
            _model . ReviewDepart = cmbCkR . Text;
            _model . ReviewUser = txtCkR . Text;
            _model . ExaminDepart = cmbCpE . Text;
            _model . ExaminUser = txtCpE . Text;
            modelList . Add ( _model );
            _model = new FishEntity . DeliveredManagementEntity ( );
            _model . TablePro = "FormCustomStandardTable";
            _model . ReviewDepart = cmbBzR . Text;
            _model . ReviewUser = txtBzR . Text;
            _model . ExaminDepart = cmbBzE . Text;
            _model . ExaminUser = txtBzE . Text;
            modelList . Add ( _model );
            _model = new FishEntity . DeliveredManagementEntity ( );
            _model . TablePro = "FormBilloflading";
            _model . ReviewDepart = cmbThR . Text;
            _model . ReviewUser = txtThR . Text;
            _model . ExaminDepart = cmbThE . Text;
            _model . ExaminUser = txtThE . Text;
            modelList . Add ( _model );
            _model = new FishEntity . DeliveredManagementEntity ( );
            _model . TablePro = "FormOutboundOrder";
            _model . ReviewDepart = cmbckdR . Text;
            _model . ReviewUser = txtckdR . Text;
            _model . ExaminDepart = cmbckdE . Text;
            _model . ExaminUser = txtckdE . Text;
            modelList . Add ( _model );
            _model = new FishEntity . DeliveredManagementEntity ( );
            _model . TablePro = "FormReturnReceipt";
            _model . ReviewDepart = cmbThdR . Text;
            _model . ReviewUser = txtThdR . Text;
            _model . ExaminDepart = cmbThdE . Text;
            _model . ExaminUser = txtThdE . Text;
            modelList . Add ( _model );

            return modelList;
        }

        public void setValue(FishEntity.DeliveredManagementEntity _model)
        {
            txtid.Text =_model.id.ToString();
            cmbTJxssqd.Text = _model.cmbTJxssqd;
            txtTJxssqd.Text = _model.txtTJxssqd;
            cmbSGxssqd.Text = _model.cmbSGxssqd;
            txtSGxssqd.Text = _model.txtSGxssqd;
            cmbTJxsht.Text = _model.cmbTJxsht;
            txtTJxsht.Text = _model.txtTJxsht;
            cmbSGxsht.Text = _model.cmbSGxsht;
            txtSGxsht.Text = _model.txtSGxsht;
            cmbTJfksqd.Text = _model.cmbTJfksqd;
            txtTJfksqd.Text = _model.txtTJfksqd;
            cmbSGfksqd.Text = _model.cmbSGfksqd;
            txtSGfksqd.Text = _model.txtSGfksqd;
            cmbTJbd.Text = _model.cmbTJbd;
            txtTJbd.Text = _model.txtTJbd;
            cmbSGbd.Text = _model.cmbSGbd;
            txtSGbd.Text = _model.txtSGbd;
            cmbTJhwfkd.Text = _model.cmbTJhwfkd;
            txtTJhwfkd.Text = _model.txtTJhwfkd;
            cmbSGhwfkd.Text = _model.cmbSGhwfkd;
            txtSGhwfkd.Text = _model.txtSGhwfkd;
            cmbTJgswtfkd.Text = _model.cmbTJgswtfkd;
            txtTJgswtfkd.Text = _model.txtTJgswtfkd;
            cmbSGgswtfkd.Text = _model.cmbSGgswtfkd;
            txtSGgswtfkd.Text = _model.txtSGgswtfkd;
            cmbTJskjld.Text = _model.cmbTJskjld;
            txtTJskjld.Text = _model.txtTJskjld;
            cmbSGskjld.Text = _model.cmbSGskjld;
            txtSGskjld.Text = _model.txtSGskjld;

            tmiAdd.Visible = false;
            tmiSave.Visible = false;
        }
        public void getvalue() {
            _model = new FishEntity.DeliveredManagementEntity();
            _model.id =int.Parse(txtid.Text.ToString());
            _model.cmbTJxssqd = cmbTJxssqd.Text.ToString();
            _model.txtTJxssqd = txtTJxssqd.Text.ToString();
            _model.cmbSGxssqd = cmbSGxssqd.Text.ToString();
            _model.txtSGxssqd = txtSGxssqd.Text.ToString();
            _model.cmbTJxsht = cmbTJxsht.Text.ToString();
            _model.txtTJxsht = txtTJxsht.Text.ToString();
            _model.cmbSGxsht = cmbSGxsht.Text.ToString();
            _model.txtSGxsht = txtSGxsht.Text.ToString();
            _model.cmbTJfksqd = cmbTJfksqd.Text.ToString();
            _model.txtTJfksqd = txtTJfksqd.Text.ToString();
            _model.cmbSGfksqd = cmbSGfksqd.Text.ToString();
            _model.txtSGfksqd = txtSGfksqd.Text.ToString();
            _model.cmbTJbd = cmbTJbd.Text.ToString();
            _model.txtTJbd = txtTJbd.Text.ToString();
            _model.cmbSGbd = cmbSGbd.Text.ToString();
            _model.txtSGbd = txtSGbd.Text.ToString();
            _model.cmbTJhwfkd = cmbTJhwfkd.Text.ToString();
            _model.txtTJhwfkd = txtTJhwfkd.Text.ToString();
            _model.cmbSGhwfkd = cmbSGhwfkd.Text.ToString();
            _model.txtSGhwfkd = txtSGhwfkd.Text.ToString();
            _model.cmbTJgswtfkd = cmbTJgswtfkd.Text.ToString();
            _model.txtTJgswtfkd = txtTJgswtfkd.Text.ToString();
            _model.cmbSGgswtfkd = cmbSGgswtfkd.Text.ToString();
            _model.txtSGgswtfkd = txtSGgswtfkd.Text.ToString();
            _model.cmbTJskjld = cmbTJskjld.Text.ToString();
            _model.txtTJskjld = txtTJskjld.Text.ToString();
            _model.cmbSGskjld = cmbSGskjld.Text.ToString();
            _model.txtSGskjld = txtSGskjld.Text.ToString();
            _model.createman = FishEntity.Variable.User.username;
            _model.modifyman = FishEntity.Variable.User.username;
        }
        public void getCombox() {
            FishBll.Bll.ReceiptRecordBll _bll = new FishBll.Bll.ReceiptRecordBll();
            DataTable dt = _bll . getDepart ( );
            cmbTJxssqd . DataSource = dt . Copy ( );
            cmbTJxssqd .DisplayMember = "rolename";
            cmbSGxssqd .DataSource = dt . Copy ( );
            cmbSGxssqd .DisplayMember = "rolename";
            cmbTJxsht .DataSource = dt . Copy ( );
            cmbTJxsht .DisplayMember = "rolename";
            cmbSGxsht .DataSource = dt . Copy ( );
            cmbSGxsht .DisplayMember = "rolename";
            cmbTJfksqd .DataSource = dt . Copy ( );
            cmbTJfksqd .DisplayMember = "rolename";
            cmbSGfksqd .DataSource = dt . Copy ( );
            cmbSGfksqd .DisplayMember = "rolename";
            cmbTJbd .DataSource = dt . Copy ( );
            cmbTJbd .DisplayMember = "rolename";
            cmbSGbd .DataSource = dt . Copy ( );
            cmbSGbd .DisplayMember = "rolename";
            cmbTJhwfkd .DataSource= dt . Copy ( );
            cmbTJhwfkd .DisplayMember = "rolename";
            cmbSGhwfkd .DataSource = dt . Copy ( );
            cmbSGhwfkd .DisplayMember = "rolename";
            cmbTJgswtfkd .DataSource = dt . Copy ( );
            cmbTJgswtfkd .DisplayMember = "rolename";
            cmbSGgswtfkd .DataSource = dt . Copy ( );
            cmbSGgswtfkd .DisplayMember = "rolename";
            cmbTJskjld .DataSource = dt . Copy ( );
            cmbTJskjld .DisplayMember = "rolename";
            cmbSGskjld .DataSource = dt . Copy ( );
            cmbSGskjld .DisplayMember = "rolename";
            cmbCgR . DataSource = dt . Copy ( );
            cmbCgR . DisplayMember = "rolename";
            cmbCgE . DataSource = dt . Copy ( );
            cmbCgE . DisplayMember = "rolename";
            cmbCgCR . DataSource = dt . Copy ( );
            cmbCgCR . DisplayMember = "rolename";
            cmbCgCE . DataSource = dt . Copy ( );
            cmbCgCE . DisplayMember = "rolename";
            cmJcR . DataSource = dt . Copy ( );
            cmJcR . DisplayMember = "rolename";
            cmJcE . DataSource = dt . Copy ( );
            cmJcE . DisplayMember = "rolename";
            cmbRkR . DataSource = dt . Copy ( );
            cmbRkR . DisplayMember = "rolename";
            cmbRkE . DataSource = dt . Copy ( );
            cmbRkE . DisplayMember = "rolename";
            cmbPlR . DataSource = dt . Copy ( );
            cmbPlR . DisplayMember = "rolename";
            cmbPlE . DataSource = dt . Copy ( );
            cmbPlE . DisplayMember = "rolename";
            cmbHqR . DataSource = dt . Copy ( );
            cmbHqR . DisplayMember = "rolename";
            cmbHqE . DataSource = dt . Copy ( );
            cmbHqE . DisplayMember = "rolename";
            cmbCkR . DataSource = dt . Copy ( );
            cmbCkR . DisplayMember = "rolename";
            cmbCpE . DataSource = dt . Copy ( );
            cmbCpE . DisplayMember = "rolename";
            cmbBzR . DataSource = dt . Copy ( );
            cmbBzR . DisplayMember = "rolename";
            cmbBzE . DataSource = dt . Copy ( );
            cmbBzE . DisplayMember = "rolename";
        }


        private void txtxsssd_Click(object sender, EventArgs e)
        {
            FormUserList from = new FormUserList(true);
            from.StartPosition = FormStartPosition.CenterParent;
            if (from.ShowDialog() != DialogResult.OK)
                return;
            txtTJxssqd.Text = from.getStr;
        }
        private void txtxxht_Click(object sender, EventArgs e)
        {
            FormUserList from = new FormUserList(true);
            from.StartPosition = FormStartPosition.CenterParent;
            if (from.ShowDialog() != DialogResult.OK)
                return;
            txtTJxsht.Text = from.getStr;
        }

        private void txtfksqd_Click(object sender, EventArgs e)
        {
            FormUserList from = new FormUserList(true);
            from.StartPosition = FormStartPosition.CenterParent;
            if (from.ShowDialog() != DialogResult.OK)
                return;
            txtTJfksqd.Text = from.getStr;
        }
        private void txtbd_Click(object sender, EventArgs e)
        {
            FormUserList from = new FormUserList(true);
            from.StartPosition = FormStartPosition.CenterParent;
            if (from.ShowDialog() != DialogResult.OK)
                return;
            txtTJbd.Text = from.getStr;
        }

        private void txthwfkd_Click(object sender, EventArgs e)
        {
            FormUserList from = new FormUserList(true);
            from.StartPosition = FormStartPosition.CenterParent;
            if (from.ShowDialog() != DialogResult.OK)
                return;
            txtTJhwfkd.Text = from.getStr;
        }

        private void txtgswtfkd_Click(object sender, EventArgs e)
        {
            FormUserList from = new FormUserList(true);
            from.StartPosition = FormStartPosition.CenterParent;
            if (from.ShowDialog() != DialogResult.OK)
                return;
            txtTJgswtfkd.Text = from.getStr;
        }

        private void txtskjld_Click(object sender, EventArgs e)
        {
            FormUserList from = new FormUserList(true);
            from.StartPosition = FormStartPosition.CenterParent;
            if (from.ShowDialog() != DialogResult.OK)
                return;
            txtTJskjld.Text = from.getStr;
        }

        private void txtSGxssqd_Click(object sender, EventArgs e)
        {
            FormUserList from = new FormUserList(true);
            from.StartPosition = FormStartPosition.CenterParent;
            if (from.ShowDialog() != DialogResult.OK)
                return;
            txtSGxssqd.Text = from.getStr;
        }

        private void txtSGxsht_Click(object sender, EventArgs e)
        {
            FormUserList from = new FormUserList(true);
            from.StartPosition = FormStartPosition.CenterParent;
            if (from.ShowDialog() != DialogResult.OK)
                return;
            txtSGxsht.Text = from.getStr;
        }

        private void txtSGfksqd_Click(object sender, EventArgs e)
        {
            FormUserList from = new FormUserList(true);
            from.StartPosition = FormStartPosition.CenterParent;
            if (from.ShowDialog() != DialogResult.OK)
                return;
            txtSGfksqd.Text = from.getStr;
        }

        private void txtSGbd_Click(object sender, EventArgs e)
        {
            FormUserList from = new FormUserList(true);
            from.StartPosition = FormStartPosition.CenterParent;
            if (from.ShowDialog() != DialogResult.OK)
                return;
            txtSGbd.Text = from.getStr;
        }

        private void txtSGhwfkd_Click(object sender, EventArgs e)
        {
            FormUserList from = new FormUserList(true);
            from.StartPosition = FormStartPosition.CenterParent;
            if (from.ShowDialog() != DialogResult.OK)
                return;
            txtSGhwfkd.Text = from.getStr;
        }

        private void txtSGgswtfkd_Click(object sender, EventArgs e)
        {
            FormUserList from = new FormUserList(true);
            from.StartPosition = FormStartPosition.CenterParent;
            if (from.ShowDialog() != DialogResult.OK)
                return;
            txtSGgswtfkd.Text = from.getStr;
        }

        private void txtSGskjld_Click(object sender, EventArgs e)
        {
            FormUserList from = new FormUserList(true);
            from.StartPosition = FormStartPosition.CenterParent;
            if (from.ShowDialog() != DialogResult.OK)
                return;
            txtSGskjld.Text = from.getStr;
        }

        private void FormDeliveredManagement_Load(object sender, EventArgs e)
        {
            getQuery();
        }

        private void txtBzE_Click ( object sender ,EventArgs e )
        {
            FormUserList from = new FormUserList ( true );
            from . StartPosition = FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) != DialogResult . OK )
                return;
            txtBzE . Text = from . getStr;
        }

        private void txtCgCR_Click ( object sender ,EventArgs e )
        {
            FormUserList from = new FormUserList ( true );
            from . StartPosition = FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) != DialogResult . OK )
                return;
            txtCgCR . Text = from . getStr;
        }

        private void txtJcR_Click ( object sender ,EventArgs e )
        {
            FormUserList from = new FormUserList ( true );
            from . StartPosition = FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) != DialogResult . OK )
                return;
            txtJcR . Text = from . getStr;
        }

        private void txtRkR_Click ( object sender ,EventArgs e )
        {
            FormUserList from = new FormUserList ( true );
            from . StartPosition = FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) != DialogResult . OK )
                return;
            txtRkR . Text = from . getStr;
        }

        private void txtPlR_Click ( object sender ,EventArgs e )
        {
            FormUserList from = new FormUserList ( true );
            from . StartPosition = FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) != DialogResult . OK )
                return;
            txtPlR . Text = from . getStr;
        }

        private void txtHqR_Click ( object sender ,EventArgs e )
        {
            FormUserList from = new FormUserList ( true );
            from . StartPosition = FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) != DialogResult . OK )
                return;
            txtHqR . Text = from . getStr;
        }

        private void txtCkR_Click ( object sender ,EventArgs e )
        {
            FormUserList from = new FormUserList ( true );
            from . StartPosition = FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) != DialogResult . OK )
                return;
            txtCkR . Text = from . getStr;
        }

        private void txtBzR_Click ( object sender ,EventArgs e )
        {
            FormUserList from = new FormUserList ( true );
            from . StartPosition = FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) != DialogResult . OK )
                return;
            txtBzR . Text = from . getStr;
        }

        private void txtCgE_Click ( object sender ,EventArgs e )
        {
            FormUserList from = new FormUserList ( true );
            from . StartPosition = FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) != DialogResult . OK )
                return;
            txtCgE . Text = from . getStr;
        }

        private void txtCgCE_Click ( object sender ,EventArgs e )
        {
            FormUserList from = new FormUserList ( true );
            from . StartPosition = FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) != DialogResult . OK )
                return;
            txtCgCE . Text = from . getStr;
        }

        private void txtJcE_Click ( object sender ,EventArgs e )
        {
            FormUserList from = new FormUserList ( true );
            from . StartPosition = FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) != DialogResult . OK )
                return;
            txtJcE . Text = from . getStr;
        }

        private void txtRkE_Click ( object sender ,EventArgs e )
        {
            FormUserList from = new FormUserList ( true );
            from . StartPosition = FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) != DialogResult . OK )
                return;
            txtRkE . Text = from . getStr;

        }

        private void txtPlE_Click ( object sender ,EventArgs e )
        {
            FormUserList from = new FormUserList ( true );
            from . StartPosition = FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) != DialogResult . OK )
                return;
            txtPlE . Text = from . getStr;

        }

        private void txtHqE_Click ( object sender ,EventArgs e )
        {
            FormUserList from = new FormUserList ( true );
            from . StartPosition = FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) != DialogResult . OK )
                return;
            txtHqE . Text = from . getStr;
        }

        private void txtCpE_Click ( object sender ,EventArgs e )
        {
            FormUserList from = new FormUserList ( true );
            from . StartPosition = FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) != DialogResult . OK )
                return;
            txtCpE . Text = from . getStr;
        }

        private void txtCgR_Click ( object sender ,EventArgs e )
        {
            FormUserList from = new FormUserList ( true );
            from . StartPosition = FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) != DialogResult . OK )
                return;
            txtCgR . Text = from . getStr;
        }
    }
}
