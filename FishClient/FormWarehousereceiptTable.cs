using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormWarehousereceiptTable : FormMenuBase
    {
        FishEntity.WarehouseReceiptEntity _model = new FishEntity.WarehouseReceiptEntity();
        List<FishEntity.WarehouseReceiptEntity> modelList = new List<FishEntity.WarehouseReceiptEntity>();
        FishBll.Bll.WarehouseReceiptBll _Bll = new FishBll.Bll.WarehouseReceiptBll();
        string strwhere = string.Empty;
        public FormWarehousereceiptTable()
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_146");
        }
        public override int Query()
        {
            dataGridView1.Rows.Clear();
            List<FishEntity.WarehouseReceiptEntity> modelList = _Bll.GetModelList(strwhere);
            if (modelList != null)
            {
                foreach (FishEntity.WarehouseReceiptEntity model in modelList)
                {
                    int idx = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[idx];
                    row.Cells["codeNumContract"].Value = model.codeNumContract;
                    row.Cells["codeNum"].Value = model.codeNum;
                    row.Cells["fishId"].Value = model.fishId;
                    row.Cells["CODE"].Value = model.code;
                    row.Cells["commodityTons"].Value = model.commodityTons;
                    row.Cells["commodityPack"].Value = model.commodityPack;
                    row.Cells["commodity"].Value = model.commodity;
                    row.Cells["shipname"].Value = model.shipName;
                    row.Cells["billName"].Value = model.billName;
                    row.Cells["StartingCountry"].Value = model.StartingCountry;

                    row.Cells["StartingCity"].Value = model.StartingCity;
                    row.Cells["DestinationCountry"].Value = model.DestinationCountry;
                    row.Cells["DestinationCity"].Value = model.DestinationCity;
                    row.Cells["forwardingUnit"].Value = model.ForwardingUnit;
                    row.Cells["shipMent"].Value = model.shipMent;
                    row.Cells["shipMentUser"].Value = model.shipMentUser;
                    row.Cells["Label_Protein"].Value = model.Label_Protein;
                    row.Cells["Label_Water"].Value = model.Label_Water;
                    row.Cells["Label_Fat"].Value = model.Label_Fat;
                    row.Cells["Label_FFA"].Value = model.Label_FFA;

                    row.Cells["Label_SandSalt"].Value = model.Label_SandSalt;
                    row.Cells["Label_Antioxidant"].Value = model.Label_Antioxidant;
                    row.Cells["supCom"].Value = model.SupCom;
                    row.Cells["receive"].Value = model.Receive;
                    row.Cells["receiveAdd"].Value = model.ReceiveAdd;
                    row.Cells["contractNums"].Value = model.ContractNums;
                    row.Cells["priceMJ"].Value = model.PriceMJ;
                    row.Cells["FOB"].Value = model.FOB;
                    row.Cells["CFR"].Value = model.CFR;
                }
            }
            return base.Query();
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_146");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_146");
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
    }
}
