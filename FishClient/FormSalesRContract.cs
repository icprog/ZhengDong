using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormSalesRContract :FormMenuBase
    {
        FishEntity.SalesRequisitionEntity setbool = new FishEntity.SalesRequisitionEntity();
        FishEntity.SalesRContractEntity _model = null;
        FishBll.Bll.SalesRContractBll bll = null;
        FishEntity.productsituationEntity _body = null;
        private UIForms.FormSalesRContractQuery QueryForm = null;
        
        private string _where = string.Empty;
        string _orderBy = " order by id asc limit 1";//limit 1
        string name = string.Empty;
        FormImage formimage = null;
        /// <summary>
        /// 流程状态表刷新
        /// </summary>
        FishBll.Bll.ProcessStateBll _Refreshbll = null;
        string _rolewhere = string.Empty;
        public FormSalesRContract ( )
        {
            InitializeComponent ( );
            menuStrip1.Visible = true;
            dtpSigndate . Enabled = false;
            dataGridView1 . Enabled = true;

            //texCountry . Visible = false;
        }
        public  FormSalesRContract(string Numbering)
        {
            InitializeComponent();
            MenuCode = "M423"; ControlButtomRoles();
            txtNumbering.Text = string.Empty;
            txtNumbering.Text = Numbering;
            dataGridView1.Rows.Clear();
            GenerateContectNumbering();
            if (result == true)
                GenerateBody();
        }
        public override void Review()
        {
            Review(this.Name, txtNumbering.Text, txtcode.Text);
            //if (txtNumbering.Text!="")
            //{
            //    _Refreshbll = new FishBll.Bll.ProcessStateBll();
            //    _Refreshbll.GetFormSalesRContract(txtNumbering.Text);
            //}
            base.Review();
        }
        FishBll.Bll.SalerequisitionBll _bll = new FishBll.Bll.SalerequisitionBll();
        bool result=false;
        bool gnjc=false;
        private void FormSalesRContract_Load(object sender, EventArgs e)
        {
            MenuCode = "M423"; ControlButtomRoles();
            if (Megres.oddNum!="")
            {
                name = Megres.oddNum;
                txtNumbering.Text = Megres.oddNum;
                GenerateContectNumbering();
                Megres.oddNum = string.Empty;
                if (result == true)
                    GenerateBody();
            }
        }
        public override int Add()
        {
            tmiSave.Visible = true;
            tmiCancel.Visible = true;
            tmiAdd.Visible = false;
            tmiModify.Visible = false;
            tmiQuery.Visible = false;
            tmiDelete.Visible = false;
            tmiClose.Visible = false;
            tmiNext.Visible = false;
            tmiPrevious.Visible = false;
            tmiExport.Visible = false;
            tmiReview.Visible = false;
            txtcode.Text = string.Empty;
            txtdemand.Text = string.Empty;
            txtNumbering.Text = string.Empty;
            txtSignplace.Text = string.Empty;
            txtsupplier.Text = string.Empty;
            dtpSigndate.Value = DateTime.Now;     
            
            _model = null;

            dataGridView1.Rows.Clear();

            dataGridView1.Rows.Insert(0, new DataGridViewRow());

            //新增带入

            bll = new FishBll.Bll.SalesRContractBll();
            DataTable queryTable = bll.getxxsqd(" a.Numbering='" + name+"' ");
            if (queryTable != null && queryTable.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < queryTable.Rows.Count; i++)
                {
                    int idx = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[idx];
                    txtNumbering.Text = queryTable.Rows[i]["Numbering"].ToString();
                    dtpSigndate.Value=DateTime.Parse(queryTable.Rows[i]["Signdate"].ToString());
                    txtdemand.Text= queryTable.Rows[i]["demand"].ToString();
                    txtSignplace.Text= queryTable.Rows[i]["Signplace"].ToString();
                    txtsupplier.Text= queryTable.Rows[i]["supplier"].ToString();
                    txtcode.Text = queryTable.Rows[i]["code"].ToString();
                    row.Cells["product_id"].Value = queryTable.Rows[i]["product_id"].ToString();
                    row.Cells["productname"].Value = queryTable.Rows[i]["productname"].ToString();
                    row.Cells["Funit"].Value = queryTable.Rows[i]["Funit"].ToString();
                    row.Cells["Variety"].Value = queryTable.Rows[i]["Variety"].ToString();
                    row.Cells["Quantity"].Value = queryTable.Rows[i]["Quantity"].ToString();
                    row.Cells["unitprice"].Value = queryTable.Rows[i]["unitprice"].ToString();
                    row.Cells["Amonut"].Value = queryTable.Rows[i]["Amonut"].ToString();
                }
            }
            return 0;
        }
        public void SetSalesRContract() {
            txtcode.Text = _model.ContractCode;
            txtNumbering.Text = _model.Numbering;
            txtdemand.Text = _model.Demand;
            txtsupplier.Text = _model.Supplier;
            txtSignplace.Text = _model.Signplace;
            setbool.id = _model.Id;
            if (_model.Signdate!=null)
            dtpSigndate.Value= DateTime.Parse(_model.Signdate.ToString());
        }
        public void GetSalesRContract() {
            _model.ContractCode = txtcode.Text.ToString();
            _model.Numbering = txtNumbering.Text.ToString();
            _model.Demand = txtdemand.Text.ToString();
            _model.Signdate = dtpSigndate.Value;
            _model.Supplier = txtsupplier.Text.ToString();
            _model.Signplace = txtSignplace.Text.ToString();
            _model.Createman =  FishEntity.Variable.User.username;
            _model.Modifyman = FishEntity.Variable.User.username;
            _model.Createtime =  DateTime.Now;
            _model.Modifytime = DateTime.Now;
        }
        public override void Save()
        {
            _model = new FishEntity.SalesRContractEntity();
            List<FishEntity.productsituationEntity> modelList = new List<FishEntity.productsituationEntity>();
            bll = new FishBll.Bll.SalesRContractBll();
            GetSalesRContract();
            DataView(modelList);
            //bool isok = bll.Exists(_model.ContractCode);
            //if (isok)
            //{
            //    MessageBox.Show("合同编号已存在！");
            //    return;
            //}
            bool isok = bll.ExistsNumbering(_model.Numbering);
            if (isok)
            {
                MessageBox.Show("编号已存在！");
                return;
            }
            _model.Id= bll.Add(_model, modelList);
            if (_model.Id>0)
            {
                setbool.id = _model.Id;
                AddImages(_model);
                MessageBox.Show("保存成功！");
            }
            
        }
        public override int Modify()
        {
            _model = new FishEntity.SalesRContractEntity();
            GetSalesRContract();
            List<FishEntity.productsituationEntity> modelList = new List<FishEntity.productsituationEntity>();
            DataView(modelList);
            bll = new FishBll.Bll.SalesRContractBll();
            bool isok = bll.Update(_model, modelList);
                if (isok==true)
                {
                    AddImages(_model);
                    MessageBox.Show("保存成功！"); return 1;
                }
                return 1;
        }
        public void DataView(List<FishEntity.productsituationEntity> modelList)
        {
            dataGridView1.EndEdit();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;
                _body = new FishEntity.productsituationEntity();
                _body.Code = _model.ContractCode;
                _body.Numbering = _model.Numbering;
                _body.Product_id = row.Cells["product_id"].Value == null ? string.Empty : row.Cells["product_id"].Value.ToString();
                _body.Productname = row.Cells["productname"].Value == null ? string.Empty : row.Cells["productname"].Value.ToString();
                _body.Funit = row.Cells["Funit"].Value == null ? string.Empty : row.Cells["Funit"].Value.ToString();
                _body.Variety = row.Cells["Variety"].Value == null ? string.Empty : row.Cells["Variety"].Value.ToString();
                _body.Quantity = row.Cells["Quantity"].Value == null ? 0 : Math.Round(decimal.Parse(row.Cells["Quantity"].Value.ToString()), 2);
                _body.Unitprice = row.Cells["unitprice"].Value == null ? 0 : Math.Round(decimal.Parse(row.Cells["unitprice"].Value.ToString()), 2);
                _body.Amonut = row.Cells["Amonut"].Value == null ? 0 : Math.Round(decimal.Parse(row.Cells["Amonut"].Value.ToString()), 2);
                modelList.Add(_body);
            }            
        }
        public override int Query ( )
        {
            if (QueryForm == null)
            {
                QueryForm = new UIForms.FormSalesRContractQuery();
                QueryForm.StartPosition = FormStartPosition.CenterParent;
                QueryForm.ShowInTaskbar = false;
            }
            if (QueryForm.ShowDialog() != System.Windows.Forms.DialogResult.OK) return 0;
            _where = QueryForm.GetWhereCondition;
            bll = new FishBll.Bll.SalesRContractBll();
            _model = new FishEntity.SalesRContractEntity();
            _model = bll.GetList(_where);
            if (_model != null)
            {
                SetSalesRContract();
                dataGridView1.Rows.Clear();
                GenerateBody();
            }
            else {

                MessageBox.Show("查无数据！");
            }

            //FormSalesTables form = new FormSalesTables();
            //form.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK)            
            //if (form.fish == null) return 1;
            //txtcode.Text = string.Empty;
            //txtcode.Text = form.fish.code;
            //dataGridView1.Rows.Clear();
            //GenerateContect();
            //if (result == true)
            //    GenerateBody();

            return base . Query ( );
        }
        //void GenerateContect ( )
        //{
        //    result = _bll . Exist (txtNumbering. Text );
        //    if ( result == true )
        //    {
        //        _rolewhere += " Numbering= '" + txtNumbering.Text+"' ";
        //        if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
        //        {
        //            _rolewhere += string.Format(" and createman='{0}' ", FishEntity.Variable.User.username);
        //        }
        //        FishEntity . SalesRequisitionEntity _list = _bll . GetList (_rolewhere);
        //        if ( _list == null )
        //            return;
        //        headSetValue ( _list );

        //    }
        //    else
        //        MessageBox . Show ( "编号:" + txtNumbering. Text + "不存在,请核实" );
        //}
        //void GenerateContectCode()
        //{
        //    result = _bll.ExistCode(txtNumbering.Text);
        //    if (result == true)
        //    {
        //        _rolewhere += " Numbering= '" + txtcode.Text + "' ";
        //        if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
        //        {
        //            _rolewhere += string.Format(" and createman='{0}' ", FishEntity.Variable.User.username);
        //        }
        //        FishEntity.SalesRequisitionEntity _list = _bll.GetList(_rolewhere);
        //        if (_list == null)
        //            return;
        //        headSetValue(_list);

        //    }
        //    else
        //        MessageBox.Show("销售编号:" + txtcode.Text + "不存在,请核实");
        //}
        void GenerateContectNumbering()
        {
            bll = new FishBll.Bll.SalesRContractBll();
            result = _bll.ExistCode(txtNumbering.Text);
            if (result == true)
            {
                _rolewhere += " Numbering= '" + txtNumbering.Text + "' ";
                if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
                {
                    _rolewhere += string.Format(" and createman='{0}' ", FishEntity.Variable.User.username);
                }
                _model = new FishEntity.SalesRContractEntity();
                _model = bll.GetList(_rolewhere);
                if (_model == null)
                    return;
                SetSalesRContract();

            }
            //else
                //MessageBox.Show("销售编号:" + txtcode.Text + "不存在,请核实");
        }
        void headSetValue ( FishEntity . SalesRequisitionEntity _list )
        {
            txtNumbering.Text = _list.Numbering;
            txtcode . Text = _list . code;
            txtsupplier . Text = _list . supplier;
            txtsupplier . Tag = _list . supplierId;
            txtdemand . Text = _list . demand;
            txtdemand . Tag = _list . demandId;
            txtSignplace . Text = _list . Signplace;
            setbool.id = _list.id;
            if ( _list . Signdate != null )
                dtpSigndate . Value = DateTime . Parse ( _list . Signdate . ToString ( ) );
            #region
            //if ( _list . rebateBool == true )
            //{
            //    //labrebateBool . Visible = true;
            //    //texrebate . Visible = true;
            //    //texrebate . Text = _list . rebate . ToString ( );
            //}
            //else
            //{
            //    //labrebateBool . Visible = false;
            //    //texrebate . Visible = false;
            //}
            //if (_list.Freightbool==true)
            //{
            //    labFreightBool.Visible = true;
            //    texFreight.Visible = true;
            //    texFreight.Text = _list.Freight.ToString();
            //}
            //else
            //{
            //    labFreightBool.Visible = false;
            //    texFreight.Visible = false;
            //}
            //if ( _list . PortpriceBool == true )
            //{
            //    labPortpriceBool . Visible = true;
            //    texPortprice . Visible = true;
            //    texPortprice . Text = _list . Portprice . ToString ( );
            //}
            //else
            //{
            //    labPortpriceBool . Visible = false;
            //    texPortprice . Visible = false;
            //}
            //if (_list.WithSkinbool == true)
            //{
            //    labWithSkinBool.Visible = true;
            //    texWithSkin.Visible = true;
            //    texWithSkin.Text = _list.WithSkin.ToString();
            //}
            //else {
            //    labWithSkinBool.Visible = false;
            //    texWithSkin.Visible = false;
            //}
            //if (_list.Stockpilebool == true)
            //{
            //    labelStockpilebool.Visible = true;
            //    texdt.Visible = true;
            //    labeldty.Visible = true;
            //    texdt.Text = _list.dt.ToString();
            //}
            //else {
            //    labelStockpilebool.Visible = false;
            //    texdt.Visible = false;
            //    labeldty.Visible = false;
            //    texdt.Text = _list.dt.ToString();
            //}
            //if (_list.Informationbool==true)
            //{

            //}
            //texDeliveryPlace . Text = _list . delivery;
            //textransport . Text = _list . transport;
            //texDeliveryDeadline . Text = _list . deadline . ToString ( );
            //texBanDan . Text = _list . Settlementmethod;
            //texOpenbank . Text = _list . Bank;
            //texCollectUnit . Text = _list . Receipt;
            //texAcountNum . Text = _list . accountnumber . ToString ( );
            #endregion
            gnjc = _list . deIndex;
            setbool = _list;
        }
        void GenerateBody ( )
        {
            bll=new FishBll.Bll.SalesRContractBll();
            List<FishEntity .productsituationEntity> modelList = bll .modellist(txtNumbering. Text );
            if ( modelList . Count < 1&& modelList == null)
                return;
            bodySetValue ( modelList );
        }
        DataTable tableOne, tableTwo, tableTre;
        public override int Print()
        {
            if (printOrExport() == false)
                return 0;

            Print(new DataTable[] { tableOne, tableTwo, tableTre }, "\\销售合同.frx");

            return base.Print();
        }
        public override int Export()
        {
            if (printOrExport() == false)
                return 0;

            Export(new DataTable[] { tableOne, tableTwo, tableTre }, "\\销售合同.frx");

            return base.Export();
        }

        bool printOrExport()
        {
            if (string.IsNullOrEmpty(txtcode.Text))
            {
                MessageBox.Show("合同编号不可为空");
                return false;
            }
            tableOne = _bll.printTableOne(txtcode.Text);
            tableOne.TableName = "TableOne";
            tableTwo = _bll.printTableTwo(txtcode.Text);
            tableTwo.TableName = "TableTwo";
            tableTre = _bll.printTableTre(txtcode.Text);
            tableTre.TableName = "TableTre";

            return true;
        }
        void bodySetValue ( List<FishEntity .productsituationEntity> modelList )
        {
            int i = 0;

            foreach ( FishEntity .productsituationEntity list in modelList )
            {
                int idx = dataGridView1 . Rows . Add ( );
                DataGridViewRow row = dataGridView1 . Rows [ idx ];
                row . Cells [ "product_id" ] . Value = list . Product_id;
                row . Cells [ "productname" ] . Value = list . Productname;
                row . Cells [ "Funit" ] . Value = list . Funit;
                row . Cells [ "Variety" ] . Value = list . Variety;
                row . Cells [ "Quantity" ] . Value = list . Quantity;
                row . Cells [ "unitprice" ] . Value = list . Unitprice;
                row . Cells ["Amonut"] . Value = list .Amonut;

                i++;
                #region
                //if ( i > 1 )
                //{
                //    UILibrary . PresaleRControlSGS sgs = new UILibrary . PresaleRControlSGS ( );
                //    sgs . Location = new System . Drawing . Point ( 0 ,118 * ( i - 1 ) );
                //    panel2 . Controls . Add ( sgs );

                //    //sgs . Dock = System . Windows . Forms . DockStyle . Top;
                //    sgs . Visible = true;
                //    sgs . Name = sgs + i . ToString ( );
                //    sgs . setSaleValue ( list ,gnjc,setbool );
                //}
                //else
                //{
                //    sgs1 . setSaleValue ( list ,gnjc ,setbool);
                //}
                #endregion
            }
        }

        private void btnHeTong_Click(object sender, EventArgs e)
        {
            if (formimage == null)
            {
                formimage = new FormImage(0, FishEntity.ImageTypeEnum.HETONG);
            }

            formimage.SetData(setbool == null ? 0 : setbool.id, FishEntity.ImageTypeEnum.HETONG);

            formimage.StartPosition = FormStartPosition.CenterParent;
            if (formimage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            bool isOk = true;
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("product_id", StringComparison.OrdinalIgnoreCase) == true)
            {
                FormSalesTables form = new FormSalesTables();
                if (form.ShowDialog() != DialogResult.OK)
                    return;
                FishEntity.SalesRequisitionEntity head = form.fish;
                if (head == null)
                    return;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    //if (!string.IsNullOrEmpty(dataGridView1.Rows[i].Cells["product_id"].Value.ToString()) && dataGridView1.Rows[i].Cells["product_id"].Value.ToString() == head.Product_id)
                    //{
                        if (i != e.RowIndex)
                        {
                            isOk = false;
                            break;
                        }
                    //}
                }
                if (isOk == false)
                    return;
                dataGridView1.Rows[e.RowIndex].Cells["product_id"].Value = head.Product_id;
                dataGridView1.Rows[e.RowIndex].Cells["productname"].Value = head.Productname;
                dataGridView1.Rows[e.RowIndex].Cells["Funit"].Value = head.Funit;
                dataGridView1.Rows[e.RowIndex].Cells["Variety"].Value = head.Variety;
                dataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value = head.Quantity;
                dataGridView1.Rows[e.RowIndex].Cells["unitprice"].Value = head.UnitPrice;
                dataGridView1.Rows[e.RowIndex].Cells["amonut"].Value = head.Amonut;
            }
         }

        protected void AddImages(FishEntity.SalesRContractEntity fish)
        {
            if (fish == null) return;

            FishBll.Bll.ImageBll bll = new FishBll.Bll.ImageBll();
            if (setbool.id > 0)
            {
                bll.DeleteByRecordIdAndType(setbool.id, (int)FishEntity.ImageTypeEnum.HETONG);
            }
            List<FishEntity.ImageEntity> images = GetSGSImages();
            images = GetSGSImages();
            if (images != null)
            {
                foreach (FishEntity.ImageEntity item in images)
                {
                    item.recordid = setbool.id;
                    item.createman = FishEntity.Variable.User.username;
                    item.createtime = DateTime.Now;
                    item.title = "合同";
                    item.remark = this.Name;
                    bll . Add ( item );
                }
            }
        }
        public List<FishEntity.ImageEntity> GetSGSImages()
        {
            if (formimage == null) return null;
            List<FishEntity.ImageEntity> images = new List<FishEntity.ImageEntity>();
            if (formimage.Image1 != null && formimage.Image1.image != null) images.Add(formimage.Image1);
            if (formimage.Image2 != null && formimage.Image2.image != null) images.Add(formimage.Image2);
            if (formimage.Image3 != null && formimage.Image3.image != null) images.Add(formimage.Image3);
            return images;
        }

    }
}
