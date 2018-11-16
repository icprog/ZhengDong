using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FishClient
{
    /// <summary>
    /// 鱼粉资料
    /// </summary>
    public partial class FormFish : FormMenuBase
    {
        private FishBll.Bll.ProductBll _bll = new FishBll.Bll.ProductBll();
        private FishBll.Bll.ProductExBll _bllex = new FishBll.Bll.ProductExBll();
        private FishEntity.ProductEntity _fish = null;
        private FishEntity.ProductExEntity _fishex = null;
        private string _where = string.Empty;
        string _orderBy = "  ";//" order by id asc limit 1";
        public event EventHandler ClickGBEvent = null;
        private UIForms.FormFishCondition _queryForm = null;


        public FishEntity . ProductEntity getEntity
        {
            get
            {
                return _fish;
            }
        }

        public FishEntity . ProductExEntity getExEntity
        {
            get
            {
                return _fishex;
            }
        }

        public string getCode
        {
            get
            {
                return _fish . code;
            }
        }

        public FormFish()
        {
            InitializeComponent();

            BackColor = Color.White;
            fishCompositionControl1.ClickGBEvent += fishCompositionControl1_ClickGBEvent;
            fishCompositionControl1.RefreshDataEvent += fishCompositionControl1_RefreshDataEvent;
            this.panelAll.Enabled = false;
        }

        void fishCompositionControl1_RefreshDataEvent(object sender, EventArgs e)
        {
            string where = "";
            if (_fish != null)
            {
                where += " id=" + _fish.id;
            }

            QueryByWhere(where, _orderBy);
        }

        public FormFish(int productid) : this()
        {
            _where = " id=" + productid;
            QueryByWhere(_where, _orderBy);
        }

        public FormFish ( string fishId ) : this ( )
        {
            _where = " code=" + fishId;
            QueryByWhere ( _where ,_orderBy );
        }

        void fishCompositionControl1_ClickGBEvent(object sender, EventArgs e)
        {
            if (ClickGBEvent != null)
            {
                ClickGBEvent(this, EventArgs.Empty);
            }
        }

        protected void AddMenuItem()
        {
            //tmiDelete.Visible = false;
            //tmiExport.Visible = false;
            //tmiSave.Visible = false;
            //tmiCancel.Visible = false;
        }

        public override void Next()
        {
            QueryOne(" > ", " order by id asc limit 1");
        }

        public override void Previous()
        {
            QueryOne(" < ", " order by id desc limit 1");
        }

        protected void QueryOne(string operate, string orderBy)
        {
            string whereEx = string.Empty;
            if (string.IsNullOrEmpty(_where))
            {
                whereEx = " 1=1 ";
            }
            else
            {
                whereEx = _where;
            }

            if (_fish != null)
            {
                whereEx += " and code " + operate + _fish.code;
            }

            List<FishEntity.ProductEntity> list = _bll.GetModelList(whereEx + orderBy);
            if (list == null || list.Count < 1)
            {
                MessageBox.Show("已经没有记录了!");
                return;
            }

            _fish = list[0];
            //
            _fishex = _bllex.GetModel(_fish.id);

            SetFish();

        }

        public override int Query()
        {
            if (_queryForm == null)
            {
                _queryForm = new UIForms.FormFishCondition();
                _queryForm.StartPosition = FormStartPosition.CenterParent;
                _queryForm.ShowInTaskbar = false;
            }
            if (_queryForm.ShowDialog() != System.Windows.Forms.DialogResult.OK) return 0;

            _where = _queryForm.GetWhere();

            return QueryByWhere(_where, _orderBy);
        }

        protected int QueryByWhere(string where, string orderBy)
        {
            List<FishEntity.ProductEntity> list = _bll.GetModelList(where + orderBy);
            if (list == null || list.Count < 1)
            {
                _fish = null;
                _fishex = null;
                return 0;
            }
            else
            {
                _fish = list[0];

                _fishex = _bllex.GetModel(_fish.id);

                SetFish();
                return 1;
            }
        }

        protected void SetFish()
        {
            panelAll.Enabled = true;

            fishInfoControl1.SetFish(_fish);
            fishCompositionControl1.SetFish(_fish);
            fishSummaryControl1.SetFish(_fish);
            
            fishQuoteControl1.SetFishEx(_fishex);
            fishComfirmControl1.SetFishEx(_fishex);
            fishSpotGoodsControl1.SetFishEx(_fishex);
            fishSelfControl1.SetFishEx(_fishex);
            fishSaleControl1.SetFishEx(_fishex);
        }

        protected bool Check()
        {
            bool isok = true;
            bool isPass = fishInfoControl1.Check();
            if (isPass == false) { isok = false; }
            isPass = fishCompositionControl1.Check();
            if (isPass == false) { isok = false; }
            isPass = fishQuoteControl1.Check();
            if (isPass == false) { isok = false; }
            isPass = fishComfirmControl1.Check();
            if (isPass == false) { isok = false; }
            return isok;
        }

        protected void AddImages(FishEntity.ProductEntity fish)
        {
            if (fish == null) return;

            FishBll.Bll.ImageBll bll = new FishBll.Bll.ImageBll();

            if (fish.id > 0)
            {
                bll.DeleteByRecordIdAndType(fish.id, (int)FishEntity.ImageTypeEnum.SGS);
                bll.DeleteByRecordIdAndType(fish.id, (int)FishEntity.ImageTypeEnum.Label);
                bll.DeleteByRecordIdAndType(fish.id, (int)FishEntity.ImageTypeEnum.GJ);
                bll.DeleteByRecordIdAndType(fish.id, (int)FishEntity.ImageTypeEnum.QUOTE);
            }

            List<FishEntity.ImageEntity> images = fishCompositionControl1.GetQuoteImages();
            if (images != null)
            {
                foreach (FishEntity.ImageEntity item in images)
                {
                    item.recordid = fish.id;
                    item.createman = fish.createman;
                    item.createtime = fish.createtime;
                    bll.Add(item);
                }
            }

            images = fishCompositionControl1.GetSGSImages();
            if (images != null)
            {
                foreach (FishEntity.ImageEntity item in images)
                {
                    item.recordid = fish.id;
                    item.createman = fish.createman;
                    item.createtime = fish.createtime;
                    bll.Add(item);
                }
            }

            images = fishCompositionControl1.GetLabelImages();
            if (images != null)
            {
                foreach (FishEntity.ImageEntity item in images)
                {
                    item.recordid = fish.id;
                    item.createman = fish.createman;
                    item.createtime = fish.createtime;
                    bll.Add(item);
                }
            }

            images = fishCompositionControl1.GetGJImages();
            if (images != null)
            {
                foreach (FishEntity.ImageEntity item in images)
                {
                    item.recordid = fish.id;
                    item.createman = fish.createman;
                    item.createtime = fish.createtime;
                    bll.Add(item);
                }
            }
        }


        protected void AddImages1(FishEntity.ProductEntity fish)
        {
            if (fish == null) return;

            FishBll.Bll.ImageS_Bll bll = new FishBll.Bll.ImageS_Bll();

            //if (fish.id > 0)
            //{
            //    bll.DeleteByRecordIdAndType(fish.id, (int)FishEntity.ImageTypeEnum.SGS);
            //    bll.DeleteByRecordIdAndType(fish.id, (int)FishEntity.ImageTypeEnum.Label);
            //    bll.DeleteByRecordIdAndType(fish.id, (int)FishEntity.ImageTypeEnum.GJ);
            //    bll.DeleteByRecordIdAndType(fish.id, (int)FishEntity.ImageTypeEnum.QUOTE);
            //}

            List<FishEntity.t_image_S> images = fishCompositionControl1.GetQuoteImages1();
            if (images != null)
            {
                foreach (FishEntity.t_image_S item in images)
                {
                    item.Fid1 = fish.id;

                    //item.createman = fish.createman;
                    item.Date_ = fish.createtime;
                    bll.Add(item);
                }
            }

            images = fishCompositionControl1.GetSGSImages1();
            if (images != null)
            {
                foreach (FishEntity.t_image_S item in images)
                {
                    item.Fid1 = fish.id;
                    //item.createman = fish.createman;
                    item.Date_ = fish.createtime;
                    bll.Add(item);
                }
            }

            images = fishCompositionControl1.GetLabelImages1();
            if (images != null)
            {
                foreach (FishEntity.t_image_S item in images)
                {
                    item.Fid1 = fish.id;
                    item.Date_ = fish.createtime;
                    bll.Add(item);
                }
            }

            images = fishCompositionControl1.GetGJImages1();
            if (images != null)
            {
                foreach (FishEntity.t_image_S item in images)
                {
                    item.Fid1 = fish.id;
                    //item.createman = fish.createman;
                    item.Date_ = fish.createtime;
                    bll.Add(item);
                }
            }
        }
        public void SaveEx(int id)
        {
            _fishex = new FishEntity.ProductExEntity();
            fishQuoteControl1.GetFishEx(_fishex);
            fishComfirmControl1.GetFishEx(_fishex);
            fishSpotGoodsControl1.GetFishEx(_fishex);
            fishSelfControl1.GetFishEx(_fishex);
            fishSaleControl1.GetFishEx(_fishex);

            _fishex.id = id;
            _bllex.Add(_fishex);

            fishQuoteControl1.SetFishEx(_fishex);
            fishComfirmControl1.SetFishEx(_fishex);
            fishSpotGoodsControl1.SetFishEx(_fishex);
            fishSelfControl1.SetFishEx(_fishex);
            fishSaleControl1.SetFishEx(_fishex);
        }

        public override void Save()
        {
            _fish = new FishEntity.ProductEntity();
            fishInfoControl1.GetFish(_fish);//上
            fishCompositionControl1.GetFish(_fish);//中
            fishSummaryControl1.GetFish(_fish);//下
            _fish.createman = FishEntity.Variable.User.username;
            _fish.modifyman = _fish.createman;

            if (Check() == false) return;

            _fish.code = FishBll.Bll.SequenceUtil.GetFishSequence();
            bool isok = _bll.Exists(_fish.code);
            while (isok)
            {
                _fish.code = FishBll.Bll.SequenceUtil.GetFishSequence();
                isok = _bll.Exists(_fish.code);
            }

            int id = _bll.Add(_fish);
            if (id > 0)
            {
                _fish.id = id;

                AddImages(_fish);
                AddImages1(_fish);

                SaveEx(id);

                fishInfoControl1.SetFish(_fish);

                fishCompositionControl1.SetFish(_fish);

                //tmiAdd.Visible = true;
                //tmiModify.Visible = true;
                //tmiQuery.Visible = true;
                //tmiPrevious.Visible = true;
                //tmiNext.Visible = true;
                //tmiDelete.Visible = true;
                //tmiSave.Visible = false;
                //tmiCancel.Visible = false;
                ControlButtomRoles();

                MessageBox.Show("添加成功。");

            }
            else
            {
                MessageBox.Show("添加失败。");
            }

            return;
        }

        public override int Modify()
        {
            if (_fish == null)
            {
                MessageBox.Show("请查询需要修改的鱼粉。");
                return 0;
            }


            if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan)
                && false == FishEntity.Variable.User.username.Equals(_fish.createman))
            {
                MessageBox.Show("对不起，您不能修改别人创建的鱼粉资料！");
                return 0;
            }


            if (Check() == false) return 0;

            fishInfoControl1.GetFish(_fish);
            fishCompositionControl1.GetFish(_fish);
            fishSummaryControl1.GetFish(_fish);
            if (_fishex==null)
            {
                _fishex = new FishEntity.ProductExEntity();
            }
            fishQuoteControl1.GetFishEx(_fishex);
            fishComfirmControl1.GetFishEx(_fishex);
            fishSpotGoodsControl1.GetFishEx(_fishex);
            fishSelfControl1.GetFishEx(_fishex);
            fishSaleControl1.GetFishEx(_fishex);

            _fish.modifyman = FishEntity.Variable.User.username;
            _fish.modifytime = DateTime.Now;

            bool isok = _bll.Update(_fish);
            if (isok)
            {
                AddImages(_fish);
                AddImages1(_fish);
                _bllex.Update(_fishex);

                MessageBox.Show("修改成功。");
            }
            else
            {
                MessageBox.Show("修改失败。");
            }

            return 1;
        }

        public override int Add()
        {
            tmiSave.Visible = true;
            tmiCancel.Visible = true;
            tmiAdd.Visible = false;
            tmiModify.Visible = false;
            tmiQuery.Visible = false;
            tmiPrevious.Visible = false;
            tmiNext.Visible = false;
            tmiDelete.Visible = false;

            _fish = null;

            fishInfoControl1.Clear();
            fishSummaryControl1.Clear();
            fishCompositionControl1.Clear();

            fishQuoteControl1.Clear();
            fishComfirmControl1.Clear();
            fishSpotGoodsControl1.Clear();
            fishSelfControl1.Clear();
            fishSaleControl1.Clear();

            //txtman.Text = FishEntity.Variable.User.username;
            //txtmodifytime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            panelAll.Enabled = true;

            return 1;
        }

        public override void Cancel()
        {
            //tmiAdd.Visible = true;
            //tmiModify.Visible = true;
            //tmiQuery.Visible = true;
            //tmiPrevious.Visible = true;
            //tmiNext.Visible = true;
            //tmiDelete.Visible = true;

            //tmiSave.Visible = false;
            //tmiCancel.Visible = false;

            ControlButtomRoles();

            panelAll.Enabled = false;
        }

        private void FormFish_Load(object sender, EventArgs e)
        {
            AddMenuItem();
        }

        public override int Delete()
        {
            if (_fish == null) return 0;

            if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan)
             && false == FishEntity.Variable.User.username.Equals(_fish.createman))
            {
                MessageBox.Show("对不起，您不能删除别人创建的鱼粉资料！");
                return 0;
            }

            string fishid = _fish.code;
            if (MessageBox.Show("您确定要删除的【" + fishid + "】鱼粉信息吗?", "询问", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return 0;

            bool isok1 = _bll.Delete(_fish.id);
            bool isok2 = _bllex.Delete(_fish.id);
            if (isok1 == false || isok2 == false)
            {
                MessageBox.Show("删除鱼粉信息失败。");
            }
            else
            {
                MessageBox.Show("删除鱼粉信息成功。");

                _fish = null;

                Next();
            }

            return base.Delete();
        }
        private void fishInfoControl1_Load(object sender, EventArgs e)
        {

        }

        //
        private void fishInfoControl1_DoubleClick ( object sender ,EventArgs e )
        {
            if ( !string . IsNullOrEmpty ( _fish . code ) )
            {
                this . DialogResult = DialogResult . OK;
            }
        }

        private void fishCompositionControl1_Load(object sender, EventArgs e)
        {

        }

        private void btn_image_Click(object sender, EventArgs e)
        {
            //string name = @"...\FishSolution\Setup\Temp\" + _fish.id;
            string name = Application.StartupPath + "\\Temp\\" + _fish.id ;
            if (Directory.Exists(name))
            {

                System.Diagnostics.Process.Start(name);
            }
            else
            {
                MessageBox.Show("文件夹不存在");
            }
        }

    }
}



