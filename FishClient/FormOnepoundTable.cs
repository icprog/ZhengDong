using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormOnepoundTable : FormMenuBase
    {
        FishBll.Bll.ProcessStateBll _bll = new FishBll.Bll.ProcessStateBll();
        FishEntity.OnepoundEntity fish = null;
        string bill = string.Empty, billNum = string.Empty, path = string.Empty;
        string getname = string.Empty;
        bool getnum = false;
        public FormOnepoundTable()
        {
            InitializeComponent(); ReadColumnConfig(dataGridView1, "Set_116");
        }
        
        public FormOnepoundTable(string name,bool num)
        {
            InitializeComponent(); ReadColumnConfig(dataGridView1, "Set_116");
            tmiQuery.Visible = true;
            tmiSave.Visible = false;
            tmiReview.Visible = false;
            tmiprint.Visible = false;
            tmiPrevious.Visible = false;
            tmiNext.Visible = false;
            tmiModify.Visible = false;
            tmiExport.Visible = false;
            tmiDelete.Visible = false;
            tmiClose.Visible = false;
            tmiCancel.Visible = false;
            tmiAdd.Visible = true;
            if (name != "")
            {
                getnum = num;
                getname = name;

                DataTable dt =null;
                dt = _bll.getdataset(" Numbering ='" + getname + "'");
                //首行空白
                DataRow dr = dt.NewRow();
                dr["TiDanCode"] = "";
                dr["TiDanCode"] = "";
                dt.Rows.InsertAt(dr, 0);
                //
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "TiDanCode";
                comboBox1.ValueMember = "TiDanCode";
                comboBox1.SelectedIndex = 0;
                view_one();
            }
        }
        public override int Query()
        {
            dataGridView1.Rows.Clear();
            List<FishEntity.OnepoundEntity> modelList = null;
            if (comboBox1.Text!=""&& comboBox1.Text!=null)
            {
                 modelList = _bll.GetFormOnepoundList(getname + "' and TiDanCode='" + comboBox1.Text + "");
            }
            else
            {
                 modelList = _bll.GetFormOnepoundList(getname);
            }

            if (modelList != null)
            {
                decimal SumCompetition = 0,shudan=0;
                foreach (FishEntity.OnepoundEntity model in modelList)
                {
                    int idx = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[idx];
                    row.Cells["Numbering"].Value = model.Numbering;
                    row.Cells["id"].Value = model.Id;
                    row.Cells["codeOne"].Value = model.Code;
                    row.Cells["Serialnumber"].Value = model.Serialnumber;
                    row.Cells["Dateofmanufacture"].Value = model.Dateofmanufacture;
                    row.Cells["IntothefactoryDate"].Value = model.IntothefactoryDate;
                    row.Cells["Carnumber"].Value = model.Carnumber;
                    row.Cells["Grossweight"].Value = model.Grossweight;
                    row.Cells["Tareweight"].Value = model.Tareweight;
                    row.Cells["Competition"].Value = model.Competition;
                    SumCompetition += decimal.Parse(model.Competition.ToString());
                    row.Cells["Goods"].Value = model.Goods;
                    row.Cells["Owner"].Value = model.Owner;
                    row.Cells["OwnerId"].Value = model.OwnerId;
                    row.Cells["Buyers"].Value = model.Buyers;
                    row.Cells["BuyersId"].Value = model.BuyersId;
                    row.Cells["Sellers"].Value = model.Sellers;
                    row.Cells["SellersId"].Value = model.SellersId;
                    row.Cells["Country"].Value = model.Country;
                    row.Cells["PName"].Value = model.PName;
                    row.Cells["Qualit"].Value = model.Qualit;
                    row.Cells["Quantity"].Value = model.Quantity;
                    row.Cells["Pileangle"].Value = model.Pileangle;
                    row.Cells["BillOfLadingid"].Value = model.BillOfLadingid;
                    row.Cells["Address"].Value = model.Address;
                    row.Cells["Remarks"].Value = model.Remarks;
                    row.Cells["Shipno"].Value = model.Shipno;
                    row.Cells["codeContract"].Value = model.codeContract;
                    row.Cells["createman"].Value = model.Createman;
                    row.Cells["FishMealId"].Value = model.FishMealId;
                    row.Cells["TiDanCode"].Value = model.TiDanCode;
                    row.Cells["RedemptionWeight"].Value = model.RedemptionWeight;
                    if (model.RedemptionWeight.ToString() != "" && model.RedemptionWeight != null)
                    {
                        shudan += decimal.Parse(model.RedemptionWeight.ToString());
                    }
                }
                txtCompetition.Text = SumCompetition.ToString();
                textBox1.Text = shudan.ToString();
            }
            return base.Query();
        }
        public void view_one()
        {
            dataGridView1.Rows.Clear();
            List<FishEntity.OnepoundEntity> modelList = _bll.GetFormOnepoundList(getname);
            if (modelList != null)
            {
                decimal SumCompetition = 0, shudan = 0;
                foreach (FishEntity.OnepoundEntity model in modelList)
                {
                    int idx = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[idx];
                    row.Cells["Numbering"].Value = model.Numbering;
                    row.Cells["id"].Value = model.Id;
                    row.Cells["codeOne"].Value = model.Code;
                    row.Cells["Serialnumber"].Value = model.Serialnumber;
                    row.Cells["Dateofmanufacture"].Value = model.Dateofmanufacture;
                    row.Cells["IntothefactoryDate"].Value = model.IntothefactoryDate;
                    row.Cells["Carnumber"].Value = model.Carnumber;
                    row.Cells["Grossweight"].Value = model.Grossweight;
                    row.Cells["Tareweight"].Value = model.Tareweight;
                    row.Cells["Competition"].Value = model.Competition;
                    SumCompetition += decimal.Parse(model.Competition.ToString());
                    row.Cells["Goods"].Value = model.Goods;
                    row.Cells["Owner"].Value = model.Owner;
                    row.Cells["OwnerId"].Value = model.OwnerId;
                    row.Cells["TiDanCode"].Value = model.TiDanCode;
                    row.Cells["RedemptionWeight"].Value = model.RedemptionWeight;
                    row.Cells["Buyers"].Value = model.Buyers;
                    row.Cells["BuyersId"].Value = model.BuyersId;
                    row.Cells["Sellers"].Value = model.Sellers;
                    row.Cells["SellersId"].Value = model.SellersId;
                    row.Cells["Country"].Value = model.Country;
                    row.Cells["PName"].Value = model.PName;
                    row.Cells["Qualit"].Value = model.Qualit;
                    row.Cells["Quantity"].Value = model.Quantity;
                    row.Cells["Pileangle"].Value = model.Pileangle;
                    row.Cells["BillOfLadingid"].Value = model.BillOfLadingid;
                    row.Cells["Address"].Value = model.Address;
                    row.Cells["Remarks"].Value = model.Remarks;
                    row.Cells["Shipno"].Value = model.Shipno;
                    row.Cells["codeContract"].Value = model.codeContract;
                    row.Cells["createman"].Value = model.Createman;
                    row.Cells["FishMealId"].Value = model.FishMealId;
                    if (model.RedemptionWeight.ToString()!=""&&model.RedemptionWeight!=null)
                    {
                        shudan += decimal.Parse(model.RedemptionWeight.ToString());
                    }
                }
                txtCompetition.Text = SumCompetition.ToString();
                textBox1.Text = shudan.ToString();
            }
        }
        public override int Add()
        {
            FormOnepound form = new FormOnepound(getname,getnum);
            form.ShowDialog();
            view_one();
            return 0;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            billNum = dataGridView1.Rows[e.RowIndex].Cells["codeOne"].Value.ToString();
            Reflected("FishClient.FormOnepound");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            fish = new FishEntity.OnepoundEntity();
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["codeOne"].Value != null && dataGridView1.Columns[e.ColumnIndex].Name.Equals("codeOne", StringComparison.OrdinalIgnoreCase) == true)
            {
               fish.Competition= dataGridView1.Rows[e.RowIndex].Cells["Competition"].Value.ToString();
                fish.Code = dataGridView1.Rows[e.RowIndex].Cells["codeOne"].Value.ToString();
                fish.FishMealId = dataGridView1.Rows[e.RowIndex].Cells["FishMealId"].Value.ToString();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_116");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_116");
        }
        protected void ReadColumnConfig(DataGridView dgv, string section)
        {
            string path = Application.StartupPath + "\\listconfig.ini";
            if (System.IO.File.Exists(path) == true)
            {
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    string wstr = Utility.IniUtil.ReadIniValue(path, section, col.HeaderText);
                    int w = 0;
                    if (int.TryParse(wstr, out w))
                    {
                        col.Width = w;
                    }
                }
            }
        }
        void Reflected(string path)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Form doc = (Form)asm.CreateInstance(path);
            Megres.oddNum = billNum;
            doc.Owner = this;
            doc.Show();
        }
        public FishEntity.OnepoundEntity _fish
        {
            get
            {
                return fish;
            }
        }
    }
}
