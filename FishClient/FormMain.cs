using System;
using System . Drawing;
using System . Windows . Forms;
using System . Management;
using System . Threading;
using System . Data;
using System . Collections . Generic;

namespace FishClient
{
    public partial class FormMain : FormBase
    {
        ThreadManager _threadManager = null;
        FormPushMessage _formPushMessage = null;
        FormRemind _formRemind=null;
        MdiClient _mdiClient = null;

        Dictionary<string,string> proDic=new Dictionary<string, string>();

        public FormMain()
        {
            InitializeComponent();
            this.Location = new Point(-1000, -1000);
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            Login();
        }
        //功能
        protected void GetUserRoles()
        {
            if (FishEntity.Variable.User == null) return;
            FishBll.Bll.PersonBll bll = new FishBll.Bll.PersonBll();
            FishEntity.Variable.Roles = bll.GetPersionRoles(FishEntity.Variable.User.id);
        }

        protected void Login()
        {
            this.Hide();
            FormLogin form = new FormLogin();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Location = new Point(0, 0);
                this.WindowState = FormWindowState.Maximized;
                this.Show();
                this.BringToFront();
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    MdiClient client = this.Controls[i] as MdiClient;
                    if (client == null) continue;
                    _mdiClient = client;
                    _mdiClient.BackColor = Color.White;
                    break;
                }
                //判断页面
                GetUserRoles();

                LoadTreeMenu();

                ShowMenuByRoles();

                tSSLUser.Text = FishEntity.Variable.User == null ? string.Empty : FishEntity.Variable.User.realname + "(" + FishEntity.Variable.User.roletype + ")";

                DrawMdiClientBackground();

                ShowPushMessageForm();

                StartBackThread();
                //MessageBox.Show(GetMacString().ToString());

                proDic = ProgramManager . setDicItem ( );

                System . Timers . Timer t = new System . Timers . Timer ( 1000 );
                t . Elapsed += new System . Timers . ElapsedEventHandler ( checkWarn );
                t . AutoReset = true;
                t . Enabled = true;


            }
            else
            {
                this.Close();
            }
        }

        /// <summary>
        /// 启动线程
        /// </summary>
        protected void StartBackThread()
        {
            _threadManager = new ThreadManager();
            _threadManager.UIAnnouncementCallBackEvent += _threadManager_UIAnnouncementCallBackEvent;
            _threadManager.StartThread();

            _threadManager . UIAnnouncementRemindEvent += _threadManaget_UIAnnouncementRemindCallBackEvent;
            _threadManager . StartRemidThread ( );
        }

        /// <summary>
        /// 发现有新的信息，这在右下方弹出窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _threadManager_UIAnnouncementCallBackEvent(object sender, AnnouncementEventArgs e)
        {
            if (e.Announcement == null) return;
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler<AnnouncementEventArgs>(_threadManager_UIAnnouncementCallBackEvent), new object[] { sender, e });
            }
            else
            {
                if (_formPushMessage == null)
                {
                    _formPushMessage = new FormPushMessage();
                    _formPushMessage.Location = new Point(-1000, 0);
                }
                else
                {
                    _formPushMessage.OpenFormEvent -= _formPushMessage_OpenFormEvent;
                    _formPushMessage.OpenFormEvent += _formPushMessage_OpenFormEvent;
                    _formPushMessage.SetPosition();
                }

                _formPushMessage.SetCustomer(e.Announcement);

                Utility.NativeMethods.ShowWindow(new System.Runtime.InteropServices.HandleRef(_formPushMessage, _formPushMessage.Handle), 4);
            }
        }

        void _threadManaget_UIAnnouncementRemindCallBackEvent ( object sender ,AnnouncementRemindEventArgs e )
        {
            if ( e . AnnouncementRemind == null )
                return;
            if ( this . InvokeRequired )
            {
                this . Invoke ( new EventHandler<AnnouncementRemindEventArgs> ( _threadManaget_UIAnnouncementRemindCallBackEvent ) ,new object [ ] { sender ,e } );
            }
            else
            {
                if ( _formRemind == null )
                {
                    _formRemind = new FormRemind ( );
                    _formRemind . Location = new Point ( -1000 ,0 );
                }
                else
                {
                    _formRemind . SetPosition ( );
                }

                _formRemind . setValue ( e . AnnouncementRemind );

                Utility . NativeMethods . ShowWindow ( new System . Runtime . InteropServices . HandleRef ( _formRemind ,_formRemind . Handle ) ,4 );
            }
        }

        void _formPushMessage_OpenFormEvent(object sender, AnnouncementEventArgs e)
        {
            if (e == null || e.Announcement == null) return;

            buttom_Click(btnTip, EventArgs.Empty);


            //buttom_Click(btnLinkman, EventArgs.Empty);

            //if (btnLinkman.Form != null && btnLinkman.Form is FormLinkman)
            //{
            //   (btnLinkman.Form as FormLinkman).SetCustomer(e.Announcement);
            //}                 
        }

        /// <summary>
        /// 停止线程
        /// </summary>
        public void StopBackThread()
        {
            if (_threadManager == null) return;
            _threadManager.StopThread();
            _threadManager . StopRemindThread ( );
        }

        /// <summary>
        /// 显示主界面时，把消息弹出框隐藏在最左边
        /// </summary>
        protected void ShowPushMessageForm()
        {
            try
            {
                if (_formPushMessage == null)
                {
                    _formPushMessage = new FormPushMessage();
                }
                _formPushMessage.Show();
                _formPushMessage.Location = new Point(-1000, 0);
                if ( _formRemind == null )
                {
                    _formRemind = new FormRemind ( );
                }
                _formRemind . Show ( );
                _formRemind . Location = new Point ( -1000 ,0 );
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteException(ex);
            }
        }
        protected void LoadTreeMenu ( )
        {
            btnRole1 . FormType = btnRole . FormType = typeof ( FormRoles );
            btnSystemData1 . FormType = btnSystemData . FormType = typeof ( FormSystemDataSet );
            btnProductData1 . FormType = btnProductData . FormType = typeof ( FormProductDataSet );
            btnUserData1 . FormType = btnUserData . FormType = typeof ( FormUserList );
            btnCompany1 . FormType = btnCompany . FormType = typeof ( FormCompany );
            btnLinkman1 . FormType = btnLinkman . FormType = typeof ( FormLinkman );
            btnFish1 . FormType = btnFish . FormType = typeof ( FormFish );
            btnQuote1 . FormType = btnQuote . FormType = typeof ( FormQuote );
            btnStorageBills1 . FormType = btnStorageBills . FormType = typeof ( FormStorageBills );
            btnCallRecords1 . FormType = btnCallRecords . FormType = typeof ( FormCallRecords );
            btnhomemadebill1 . FormType = btnhomemadebill . FormType = typeof ( FormHomemadeStorage );
            btnCheck1 . FormType = btnCheck . FormType = typeof ( FormCheck );
            btnStorageOut1 . FormType = btnStorageOut . FormType = typeof ( FormFoodOut );
            btngoods1 . FormType = btngoods . FormType = typeof ( FormLoadingBills );
            btnShippingRecords1 . FormType = btnShippingRecords . FormType = typeof ( FormShippingRecords );
            btnProManager . FormType = btnShippingRecords . FormType = typeof ( FormWarn );

            btnCallRecordReport1 . FormType = btnCallRecordReport . FormType = typeof ( FormCallRecordsTable );
            btnRequiredReport1 . FormType = btnRequiredReport . FormType = typeof ( FormRequredForecastReport );
            btnFlowingReport1 . FormType = btnFlowingReport . FormType = typeof ( FormSelftStorageFlowingReport );
            btnStorageReport1 . FormType = btnStorageReport . FormType = typeof ( FormStorageReport );
            btnCustomerAnsyleReport1 . FormType = btnCustomerAnsyleReport . FormType = typeof ( FormCustomerAnalysisTable );
            btnCompanyList1 . FormType = btnCompanyList . FormType = typeof ( FormCompanyList );

            btnInventoryAccount1 . FormType = btnInventoryAccount . FormType = typeof ( FormInventory );
            btnTip1 . FormType = btnTip . FormType = typeof ( FormRemindMessage );

            btnFurtureContract1 . FormType = btnFurtureContract . FormType = typeof ( Contract . FormFuturesContract );
            btnProductContract11 . FormType = btnProductContract1 . FormType = typeof ( Contract . FormProductContract1 );
            btnProductContract21 . FormType = btnProductContract2 . FormType = typeof ( Contract . FormProductContract2 );
            btnProcessState1 . FormType = btnProcessState . FormType = typeof ( FormProcessState );
            btnConfirm1 . FormType = btnConfirm . FormType = typeof ( FormConfirm );
            btnSpot1 . FormType = btnSpot . FormType = typeof ( FormSpot );
            btnSelfSale1 . FormType = btnSelfSale . FormType = typeof ( FormSelfSale );
            btnSelfMake1 . FormType = btnSelfMake . FormType = typeof ( FormSelfMake );
            btnSaleRecord1 . FormType = btnSaleRecord . FormType = typeof ( FormSaleRecordReport );
            btnFinish1 . FormType = btnFinish . FormType = typeof ( FormFinish );
            btnSalesRequisition1 . FormType = btnSalesRequisition . FormType = typeof ( FormSalesRequisition );//
            btnPresaleRequisition1 . FormType = btnPresaleRequisition . FormType = typeof ( FormPresaleRequisition );
            btnPaymentRequisition1 . FormType = btnPaymentRequisition . FormType = typeof ( FormPaymentRequisition );
            btnTheproblemsheet1 . FormType = btnTheproblemsheet . FormType = typeof ( FormTheproblemsheet );
            btnDisposeofcomments1 . FormType = btnDisposeofcomments . FormType = typeof ( FormDisposeofcomments );
            btnOnepound1 . FormType = btnOnepound . FormType = typeof ( FormOnepound );
            btnBilloflading1 . FormType = btnBilloflading . FormType = typeof ( FormBilloflading );
            btnPoundsingletable1 . FormType = btnPoundsingletable . FormType = typeof ( FormPoundsingletable );
            btnBilloftable1 . FormType = btnBilloftable . FormType = typeof ( FormBilloftable );
            btnPurchasingSales1 . FormType = btnPurchasingSales . FormType = typeof ( FormPurchasingSales );
            btnEnterWarehouseReceipts1 . FormType = btnEnterWarehouseReceipts . FormType = typeof ( FormEnterWarehouseReceipts );
            btnSampleSingle1 . FormType = btnSampleSingle . FormType = typeof ( FormSampleSingle );
            btnContractProcessingSheet1 . FormType = btnContractProcessingSheet . FormType = typeof ( FormContractProcessingSheet );
            btnEntry1 . FormType = btnEntry . FormType = typeof ( FormEntry );
            btnCargoFeedbackSheet1 . FormType = btnCargoFeedbackSheet . FormType = typeof ( FormCargoFeedbackSheet );
            btningredients1 . FormType = btningredients . FormType = typeof ( Formingredients );
            btnPurchaseWarehousing1 . FormType = btnPurchaseWarehousing . FormType = typeof ( FormPurchaseWarehousing );
            btnSalesOutOfTheLibrary1 . FormType = btnSalesOutOfTheLibrary . FormType = typeof ( FormSalesOutOfTheLibrary );
            btnInquiry1 . FormType = btnInquiry . FormType = typeof ( FromInquiry );
            btnReceiptRecord1 . FormType = btnReceiptRecord . FormType = typeof ( FormReceiptRecord );
            btnAccountsReceivable1 . FormType = btnAccountsReceivable . FormType = typeof ( FormAccountsReceivable );
            btnPresaleRContract1 . FormType = btnPresaleRContract . FormType = typeof ( FormPresaleRContract );
            btnSalesRContract1 . FormType = btnSalesRContract . FormType = typeof ( FormSalesRContract );
            btnSalesTables1 . FormType = btnSalesTables . FormType = typeof ( FormSalesTables );
            btnSetReview1 . FormType = btnSetReview . FormType = typeof ( FormSetReview );
            btnProgram1 . FormType = btnProgram . FormType = typeof ( FormProgram );
            btnRemind1 . FormType = btnRemind . FormType = typeof ( FormRemind );
            btnPresaleTable1 . FormType = btnPresaleTable . FormType = typeof ( FormPresaleTable );
            btnPaymentForm1 . FormType = btnPaymentForm . FormType = typeof ( FormPaymentForm );
            btnReceiptRecordForm1 . FormType = btnReceiptRecordForm . FormType = typeof ( FormReceiptRecordForm );
            btnJinCangTable1 . FormType = btnJinCangTable . FormType = typeof ( FormJinCangTable );
            btnHomemadeWarehouseTable1 . FormType = btnHomemadeWarehouseTable . FormType = typeof ( FormHomemadeWarehouseTable );
            btnPurchaseRequisition1 . FormType = btnPurchaseRequisition . FormType = typeof ( FormPurchaseRequisition );
            btnTotalDataSheet1 . FormType = btnTotalDataSheet . FormType = typeof ( FormTotalDataSheet );
            btnDeliveredManagement1 . FormType = btnDeliveredManagement . FormType = typeof ( FormDeliveredManagement );
            btnSalesAssessment1 . FormType = btnSalesAssessment . FormType = typeof ( FormSalesAssessment );
            btnFormQuotationPriceList1 . FormType = btnFormQuotationPriceList . FormType = typeof ( FormQuotationPriceList );
            btnFormCustomStandardTable . FormType = btnFormCustomStandardTable1 . FormType = typeof ( FormCustomStandardTable );
            btnFormOutboundOrder1 . FormType = typeof ( FormOutboundOrder );
            btnFormReturnReceipt1 . FormType = typeof ( FormReturnReceipt );

            btnFormPurchaseApplication . FormType = typeof ( FormPurchaseApplication );
            btnFormPurcurementContract . FormType = typeof ( FormPurcurementContract );
            btnPriWarehouse . FormType = typeof ( FormPriWarehouse );
            btnStorageOfRequisition . FormType = typeof ( FormStorageOfRequisition );
            btnSelfcontrolWare . FormType = typeof ( FormSelfcontrolWare );
            btnFormBatchSheet . FormType = typeof ( FormBatchSheet );
            btnFormFinishedProList . FormType = typeof ( FormFinishedProList );
            btnFinishedInventoryTable.FormType = typeof(FormFinishedInventoryTable);
            btnWarehousereceiptTable.FormType = typeof(FormWarehousereceiptTable);

            btnProcessStateForMacOne.FormType = typeof(FormProcessStateForMacOne);

            btnFormPurchaseApplication1 . FormType = typeof ( FormPurchaseApplication );
            btnFormPurcurementContract1 . FormType = typeof ( FormPurcurementContract );
            btnPriWarehouse1 . FormType = typeof ( FormPriWarehouse );
            btnStorageOfRequisition1 . FormType = typeof ( FormStorageOfRequisition );
            btnSelfcontrolWare1 . FormType = typeof ( FormSelfcontrolWare );
            btnFormBatchSheet1 . FormType = typeof ( FormBatchSheet );
            btnFormFinishedProList1 . FormType = typeof ( FormFinishedProList );
            btnFormWarehouseReceipt1 . FormType = typeof (FormNewWarehouseReceipt);
            btnFinishedInventoryTable1.FormType = typeof(FormFinishedInventoryTable);
            btnPurchaseDataSheet1.FormType = typeof(FormPurchaseDataSheet);
            btnFormPurchaseContractTable1.FormType = typeof(FormPurchaseContractTable);
            btnFormReturnsTable1.FormType = typeof(FormReturnsTable);
            btnFormQuotePricingTable1.FormType = typeof(FormQuotePricingTable);
            btnFormIngredientList1.FormType = typeof(FormIngredientList);
            btnNewFish1.FormType = typeof(FormNewFish);
            btnDiscWarehouse1.FormType = typeof(FormDiscWarehouse);

            btnFormProcessStateForSaleOne . FormType = typeof ( FormProcessStateForSaleOne );
            btnFormProcessStateForSaleTwo2.FormType = typeof(FormProcessStateForSaleTwo);
            btnFormProcessStateForPurOne1.FormType = typeof(FormProcessStateForPurOne);
            btnFormProcessStateForPurTwo1.FormType = typeof(FormProcessStateForPurTwo);
            btnNewPriWarehouse.FormType = typeof(FormNewPriWarehouse);

            btnNewSelfcontrolWare.FormType = typeof(FormNewSelfcontrolWare);
            btnFormNewFinish.FormType = typeof(FormNewFinish);

            btnRole . Image= btnFormNewFinish .Image= btnNewSelfcontrolWare .Image= btnProcessStateForMacOne .Image= btnNewPriWarehouse.Image = btnSystemData . Image = btnDiscWarehouse1 .Image= btnProductData . Image = btnTotalDataSheet . Image = btnUserData . Image = btnFish . Image = btnEnterWarehouseReceipts . Image = btnSampleSingle . Image = btnEntry . Image = btnCargoFeedbackSheet . Image = btnSalesOutOfTheLibrary . Image =
            btnCallRecords . Image = btnCheck . Image = btngoods . Image = btnhomemadebill . Image = btnQuote . Image = btnStorageBills . Image = btnStorageOut . Image = btningredients . Image = btnPurchaseWarehousing . Image = btnInquiry . Image = btnSalesRContract . Image = btnDeliveredManagement . Image =
            btnCallRecordReport . Image = btnRequiredReport . Image = btnFlowingReport . Image = btnStorageReport . Image = btnCustomerAnsyleReport . Image = btnPresaleRContract . Image = btnPurchaseRequisition . Image = ImageUtil . ButtonLeftImageNormal;

            btnSetReview . Image = btnProgram . Image = btnRemind . Image = btnShippingRecords . Image = btnProcessState . Image = btnPresaleTable . Image = btnReceiptRecordForm . Image = btnJinCangTable . Image = btnHomemadeWarehouseTable . Image = btnSalesAssessment . Image = ImageUtil . ButtonLeftImageNormal;
        
            btnFurtureContract . Image = btnProductContract1 . Image = btnProductContract2 . Image=btnWarehousereceiptTable.Image = btnOnepound . Image = btnBilloflading . Image = btnContractProcessingSheet . Image = btnReceiptRecord . Image = btnAccountsReceivable . Image = btnSalesTables . Image =
            btnConfirm . Image = btnSpot . Image = btnSelfSale . Image = btnSelfMake . Image = btnTheproblemsheet . Image = btnPoundsingletable . Image = btnCompanyList . Image = ImageUtil . ButtonLeftImageNormal;
            btnInventoryAccount . Image = btnTip . Image = btnDisposeofcomments . Image = btnBilloftable . Image = btnPurchasingSales . Image = btnPaymentForm . Image= btnFormPurchaseApplication1.Image= btnFormPurchaseApplication.Image = ImageUtil . ButtonLeftImageNormal;
            btnSaleRecord . Image = btnFinish . Image = btnSalesRequisition . Image = btnPresaleRequisition . Image = btnPaymentRequisition . Image = btnCompany . Image = btnLinkman . Image=btnFinishedInventoryTable.Image = ImageUtil . ButtonLeftImageNormal;
            btnFormPurchaseApplication . Image = btnFormPurcurementContract . Image = btnPriWarehouse . Image = btnStorageOfRequisition . Image = btnSelfcontrolWare . Image = btnFormBatchSheet . Image = btnFormFinishedProList . Image = btnFormProcessStateForSaleOne . Image = ImageUtil . ButtonLeftImageNormal;
            ///////////////////////////////////////////
            btnRole1 . Image = btnSystemData1 . Image = btnProductData1 . Image = btnTotalDataSheet1 . Image = btnUserData1 . Image = btnFish1 . Image = btnEnterWarehouseReceipts1 . Image = btnSampleSingle1 . Image = btnEntry1 . Image = btnCargoFeedbackSheet1 . Image = btnSalesOutOfTheLibrary1 . Image =
            btnCallRecords1 . Image = btnCheck1 . Image = btngoods1 . Image = btnhomemadebill1 . Image = btnQuote1 . Image = btnStorageBills1 . Image = btnStorageOut1 . Image = btningredients1 . Image = btnPurchaseWarehousing1 . Image = btnInquiry1 . Image = btnSalesRContract1 . Image = btnDeliveredManagement1 . Image =
            btnCallRecordReport1 . Image = btnRequiredReport1 . Image = btnFlowingReport1 . Image = btnStorageReport1 . Image = btnCustomerAnsyleReport1 . Image = btnPresaleRContract1 . Image = btnPurchaseRequisition1 . Image = ImageUtil . ButtonLeftImageNormal;

            btnSetReview1 . Image = btnProgram1 . Image = btnRemind1 . Image = btnShippingRecords1 . Image = btnProcessState1 . Image = btnPresaleTable1 . Image = btnReceiptRecordForm1 . Image = btnJinCangTable1 . Image = btnHomemadeWarehouseTable1 . Image = btnSalesAssessment1 . Image = ImageUtil . ButtonLeftImageNormal;

            btnFurtureContract1 . Image = btnProductContract11 . Image = btnProductContract21 . Image = btnOnepound1 . Image = btnBilloflading1 . Image = btnContractProcessingSheet1 . Image = btnReceiptRecord1 . Image = btnAccountsReceivable1 . Image = btnSalesTables1 . Image =
            btnConfirm1 . Image= btnNewFish1.Image = btnSpot1 . Image = btnSelfSale1 . Image = btnSelfMake1 . Image = btnTheproblemsheet1 . Image = btnPoundsingletable1 . Image = btnCompanyList1 . Image = ImageUtil . ButtonLeftImageNormal;
            btnInventoryAccount1 . Image = btnTip1 . Image = btnDisposeofcomments1 . Image = btnBilloftable1 . Image = btnPurchasingSales1 . Image = btnPaymentForm1 . Image = btnFormPurchaseContractTable1 .Image= btnFormIngredientList1 .Image= ImageUtil . ButtonLeftImageNormal;
            btnSaleRecord1 . Image = btnFinish1 . Image = btnSalesRequisition1 . Image = btnPresaleRequisition1 . Image = btnPaymentRequisition1 . Image = btnCompany1 . Image = btnLinkman1 . Image= btnFinishedInventoryTable1.Image= btnPurchaseDataSheet1.Image= btnFormReturnsTable1.Image = ImageUtil . ButtonLeftImageNormal;
            btnFormPurchaseApplication1 . Image = btnFormPurcurementContract1 . Image = btnPriWarehouse1 . Image = btnStorageOfRequisition1 . Image = btnFormBatchSheet1 . Image = btnSelfcontrolWare1 . Image= btnFormProcessStateForSaleTwo2.Image= btnFormProcessStateForPurOne1.Image= btnFormProcessStateForPurTwo1.Image = btnFormFinishedProList1 . Image = btnFormQuotePricingTable1 .Image= ImageUtil . ButtonLeftImageNormal;
            btnFormQuotationPriceList1 . Image = btnFormQuotationPriceList . Image = btnFormCustomStandardTable . Image = btnFormCustomStandardTable1 . Image = btnFormOutboundOrder1.Image= btnFormReturnReceipt1.Image= btnFormWarehouseReceipt1.Image = btnProManager . Image = ImageUtil . ButtonLeftImageNormal;
        }

        protected void ShowMenuByRoles()
        {
            if (FishEntity.Variable.Roles == null || FishEntity.Variable.Roles.Count < 1) return;

            ShowMenuByRoles(pushPanelItem1);
            ShowMenuByRoles(pushPanelItem2);
            ShowMenuByRoles(pushPanelItem3);
            ShowMenuByRoles(pushPanelItem4);

            ShowMenuByRoles ( groupBox1 );
            ShowMenuByRoles ( groupBox2 );
            ShowMenuByRoles ( groupBox3 );
            ShowMenuByRoles ( groupBox4 );
            ShowMenuByRoles ( groupBox5 );
            ShowMenuByRoles ( groupBox6 );
            ShowMenuByRoles ( groupBox7 );
            ShowMenuByRoles ( groupBox8 );
            ShowMenuByRoles ( groupBox9 );
        }

        protected void ShowMenuByRoles(UILibrary.PushPanel.PushPanelItem pnl)
        {
            foreach (Control ctl in pnl.Controls)
            {
                UIControls.ButtonEx btn = ctl as UIControls.ButtonEx;
                if (btn == null) continue;
                if (string.IsNullOrEmpty(btn.FunctionCode))
                {
                    btn.Visible = false;
                    continue;
                }
                string code = btn.FunctionCode;
                bool isexist = FishEntity.Variable.Roles.Exists((i) => { return i.funcode.Equals(code, StringComparison.OrdinalIgnoreCase); });
                btn.Visible = isexist;
            }
        }
        protected void ShowMenuByRoles ( System . Windows . Forms . GroupBox pnl )
        {
            foreach ( Control ctl in pnl . Controls )
            {
                UIControls . ButtonEx btn = ctl as UIControls . ButtonEx;
                if ( btn == null )
                    continue;
                if ( string . IsNullOrEmpty ( btn . FunctionCode ) )
                {
                    btn . Visible = false;
                    continue;
                }
                string code = btn . FunctionCode;
                bool isexist = FishEntity . Variable . Roles . Exists ( ( i ) => {
                    return i . funcode . Equals ( code ,StringComparison . OrdinalIgnoreCase );
                } );
                btn . Visible = isexist;
            }
        }
        //
        protected Form ActivtorForm(Type formType)
        {
            return Activator.CreateInstance(formType) as Form;
        }

        private void DrawMdiClientBackground()
        {
            if (this.IsMdiContainer == false) return;
            if (_mdiClient == null) return;
            if (_mdiClient.ClientSize.Width <= 0 || _mdiClient.ClientSize.Height <= 0) return;
            string path = Application.StartupPath + "\\Images\\bgbar.jpg";
            if (System.IO.File.Exists(path) == false) return;

            Image mdiBg_Image = Image.FromFile(path);
            System.Drawing.Bitmap myImg = new Bitmap(_mdiClient.ClientSize.Width, _mdiClient.ClientSize.Height);
            System.Drawing.Graphics myGraphics = System.Drawing.Graphics.FromImage(myImg);
            myGraphics.Clear(Color.White);

            int myX = 0;
            int myY = 0;
            myX = (myImg.Width - mdiBg_Image.Width) / 2;
            myY = (myImg.Height - mdiBg_Image.Height) / 2;

            myGraphics.DrawImage(mdiBg_Image, myX, myY, mdiBg_Image.Width, mdiBg_Image.Height);
            _mdiClient.BackgroundImage = myImg;
            myGraphics.Dispose();
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            DrawMdiClientBackground();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopBackThread();
        }

        private void buttom_Click(object sender, EventArgs e)
        {
            UIControls.ButtonEx currentBtn = sender as UIControls.ButtonEx;
            if (currentBtn == null) return;
            currentBtn.Image = ImageUtil.ButtomLeftImageSelected;

            foreach (UILibrary.PushPanel.PushPanelItem item in pushPanel1.Items)
            {
                foreach (Control ctl in item.Controls)
                {
                    UILibrary.SkinButtom btn = ctl as UILibrary.SkinButtom;
                    if (btn == null) continue;
                    if (btn.Equals(currentBtn)) continue;
                    btn.Image = ImageUtil.ButtonLeftImageNormal;
                }
            }

            if (currentBtn.Form == null) return;

            if (currentBtn.Form is FormFish)
            {
                FormFish form = currentBtn.Form as FormFish;
                form.ClickGBEvent += form_ClickGBEvent;
            }
            else if (currentBtn.Form is FormQuote)
            {
                FormQuote form = currentBtn.Form as FormQuote;
                form.ClickFishEvent += form_ClickFishEvent;
            }
            else if (currentBtn.Form is FormConfirm)
            {
                FormConfirm form = currentBtn.Form as FormConfirm;
                form.ClickFishEvent += form_ClickFishEvent;
            }
            else if (currentBtn.Form is FormSpot)
            {
                FormSpot form = currentBtn.Form as FormSpot;
                form.ClickFishEvent += form_ClickFishEvent;
            }
            else if (currentBtn.Form is FormSelfSale)
            {
                FormSelfSale form = currentBtn.Form as FormSelfSale;
                form.ClickFishEvent += form_ClickFishEvent;
            }
            else if (currentBtn.Form is FormSelfMake)
            {
                FormSelfMake form = currentBtn.Form as FormSelfMake;
                form.ClickFishEvent += form_ClickFishEvent;
            }
            else if (currentBtn.Form is FormRemindMessage)
            {
                FormRemindMessage form = currentBtn.Form as FormRemindMessage;
                form.ClickRemindEvent += form_ClickRemindEvent;
            }
            ///父窗口
            //currentBtn.Form.MdiParent = this;
            currentBtn.Form.Show();
            currentBtn.Form.BringToFront();

        }

        void form_ClickRemindEvent(object sender, EventArgs e)
        {
            buttom_Click(btnCallRecords, EventArgs.Empty);
        }

        void form_ClickFishEvent(object sender, EventArgs e)
        {
            buttom_Click(btnFish, EventArgs.Empty);
        }

        void form_ClickGBEvent(object sender, EventArgs e)
        {
            buttom_Click(btnCheck, EventArgs.Empty);
        }
        public string GetMacString()
        {
            try
            {
                string strMac = string.Empty;
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        strMac = mo["MacAddress"].ToString();
                    }
                }
                moc = null;
                mc = null;
                return strMac;
            }
            catch
            {
                return "unknown";
            }
        }

        public delegate void DrawChartUiHandler ( bool resu );
        public event DrawChartUiHandler chartHandler;

        delegate void AsynUpdateUI ( );//定义一个委托，使其可以更新UI控件的状态
        void checkWarn ( object source ,System . Timers . ElapsedEventArgs e )
        {
            if ( InvokeRequired )
            {
                this . Invoke ( new AsynUpdateUI ( delegate ( )
                {
                    FishBll . Bll . WarnBll _bll = new FishBll . Bll . WarnBll ( );
                    DataTable table = _bll . getWarnInfo ( FishEntity . Variable . User . id ,ProgramManager . setDicItem ( ) );
                    if ( table == null || table . Rows . Count < 1 )
                        return;
                    signGroupWarn ( table );
                } ) );
            }
        }

        protected void signGroupWarn ( DataTable table )
        {
            signBtnWarm ( groupBox1 ,table );
            signBtnWarm ( groupBox2 ,table );
            signBtnWarm ( groupBox3 ,table );
            signBtnWarm ( groupBox4 ,table );
            signBtnWarm ( groupBox5 ,table );
            signBtnWarm ( groupBox6 ,table );
            signBtnWarm ( groupBox7 ,table );
            signBtnWarm ( groupBox8 ,table );
            signBtnWarm ( groupBox9 ,table );
        }

        protected void signBtnWarm ( System . Windows . Forms . GroupBox pnl ,DataTable table )
        {
            foreach ( Control ctl in pnl . Controls )
            {
                UIControls . ButtonEx btn = ctl as UIControls . ButtonEx;
                if ( btn == null )
                    continue;
                if ( btn . Tag != null )
                {
                    if ( btn . BackColor == Color . Red )
                        btn . BackColor = Color . Empty;
                    string proNum = btn . Tag . ToString ( );
                    if ( table . Select ( "programId='" + proNum + "'" ) . Length > 0 )
                    {
                        int count = Convert . ToInt32 ( table . Select ( "programId='" + proNum + "'" ) [ 0 ] [ "coun" ] );
                        if ( proDic . ContainsKey ( proNum ) )
                        {
                            btn . Text = proDic [ proNum ];
                            btn . Text = btn . Text + " " + count . ToString ( );
                            btn . BackColor = Color . Red;
                        }
                    }
                }
            }
        }

    }
}
