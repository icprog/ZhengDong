using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormBarnAssociation : FormMenuBase
    {
        FishEntity.WarehouseReceiptEntity _model = null;
        FishBll.Bll.WarehouseReceiptBll _bll = null;
        string name = string.Empty;
        public FormBarnAssociation()
        {

            ReadColumnConfig(dataGridView1, "Set_100");
            _model = new FishEntity.WarehouseReceiptEntity();
            _bll = new FishBll.Bll.WarehouseReceiptBll();
            InitializeComponent();
        }
        //codeNum        
        public FormBarnAssociation(string codeNum)
        {
            InitializeComponent();

            ReadColumnConfig(dataGridView1, "Set_100");
            tmiQuery.Visible = false;
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
            _model = new FishEntity.WarehouseReceiptEntity();
            _bll = new FishBll.Bll.WarehouseReceiptBll();
            name = codeNum;
            Query();
    }
        public override int Add()
        {
            FormNewWarehouseReceipt form = new FormNewWarehouseReceipt(name);
            
            form.ShowDialog();
            Query();
            return base.Add();
        }
        public override int Query()
        {
            if (name != "" && name != null)
            {
                DataTable table = _bll.getTable(" codeNum= '" + name + "' ");
                if (table != null && table.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        int idx = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[idx];
                        row.Cells["id"].Value = table.Rows[i]["id"].ToString();
                        row.Cells["code"].Value = table.Rows[i]["code"].ToString();//单号
                        row.Cells["codeNumContract"].Value = table.Rows[i]["codeNumContract"].ToString();//采购合同编号
                        row.Cells["codeNum"].Value = table.Rows[i]["codeNum"].ToString();//采购编号
                        row.Cells["fishId"].Value = table.Rows[i]["fishId"].ToString();//鱼粉Id
                        row.Cells["quaIden"].Value = table.Rows[i]["quaIden"].ToString();//质量鉴定
                        row.Cells["commodityTons"].Value = table.Rows[i]["commodityTons"].ToString();//商品
                        row.Cells["commodityPack"].Value = table.Rows[i]["commodityPack"].ToString();//吨
                        row.Cells["commodity"].Value = table.Rows[i]["commodity"].ToString();//包
                        row.Cells["speci"].Value = table.Rows[i]["speci"].ToString();//规格

                        row.Cells["countryOfOrigin"].Value = table.Rows[i]["countryOfOrigin"].ToString();//原产品
                        row.Cells["billName"].Value = table.Rows[i]["billName"].ToString();//提单号
                        row.Cells["sign"].Value = table.Rows[i]["sign"].ToString();//标记
                        row.Cells["shipMent"].Value = table.Rows[i]["shipMent"].ToString();//装运
                        row.Cells["shipMentUser"].Value = table.Rows[i]["shipMentUser"].ToString();//装运人
                        row.Cells["checkAddDate"].Value = table.Rows[i]["checkAddDate"].ToString();//检验时间地点
                        row.Cells["sampling"].Value = table.Rows[i]["sampling"].ToString();//取样
                        row.Cells["db"].Value = table.Rows[i]["db"].ToString();//分蛋白
                        row.Cells["water"].Value = table.Rows[i]["water"].ToString();//水分
                        row.Cells["zf"].Value = table.Rows[i]["zf"].ToString();//脂肪

                        row.Cells["freshness"].Value = table.Rows[i]["freshness"].ToString();//新鲜度
                        row.Cells["sy"].Value = table.Rows[i]["sy"].ToString();//沙盐
                        row.Cells["oxi"].Value = table.Rows[i]["oxi"].ToString();//抗氧化剂
                        row.Cells["weight"].Value = table.Rows[i]["weight"].ToString();//重量
                        row.Cells["package"].Value = table.Rows[i]["package"].ToString();//集装箱/重量
                        row.Cells["avgWeight"].Value = table.Rows[i]["avgWeight"].ToString();//平均每包重量
                        row.Cells["shipper"].Value = table.Rows[i]["shipper"].ToString();//托运人
                        row.Cells["shipperNum"].Value = table.Rows[i]["shipperNum"].ToString();//托运号
                        row.Cells["billNames"].Value = table.Rows[i]["billNames"].ToString();//提单号
                        row.Cells["contractNum"].Value = table.Rows[i]["contractNum"].ToString();//服务合同号

                        row.Cells["goodsNum"].Value = table.Rows[i]["goodsNum"].ToString();//货品号
                        row.Cells["consi"].Value = table.Rows[i]["consi"].ToString();//收货人
                        row.Cells["preShip"].Value = table.Rows[i]["preShip"].ToString();//预装船
                        row.Cells["oceanShip"].Value = table.Rows[i]["oceanShip"].ToString();//远洋船舶
                        row.Cells["navNum"].Value = table.Rows[i]["navNum"].ToString();//航海号
                        row.Cells["agent"].Value = table.Rows[i]["agent"].ToString();//代理商
                        row.Cells["receipt"].Value = table.Rows[i]["receipt"].ToString();//收据地
                        row.Cells["shipHar"].Value = table.Rows[i]["shipHar"].ToString();//装船港
                        row.Cells["unShopHar"].Value = table.Rows[i]["unShopHar"].ToString();//卸船港
                        row.Cells["desTi"].Value = table.Rows[i]["desTi"].ToString();//目的地
                        
                        row.Cells["lastDesTi"].Value = table.Rows[i]["lastDesTi"].ToString();//最终目的地
                        row.Cells["num"].Value = table.Rows[i]["num"].ToString();//数量
                        row.Cells["containNum"].Value = table.Rows[i]["containNum"].ToString();//集装箱号
                        row.Cells["paper"].Value = table.Rows[i]["paper"].ToString();//封条
                        row.Cells["conWeight"].Value = table.Rows[i]["conWeight"].ToString();//重量
                        row.Cells["pakeWeight"].Value = table.Rows[i]["pakeWeight"].ToString();//包装重量和产品描述
                        row.Cells["seal"].Value = table.Rows[i]["seal"].ToString();//印章
                        row.Cells["freight"].Value = table.Rows[i]["freight"].ToString();//运费
                        row.Cells["freightAdd"].Value = table.Rows[i]["freightAdd"].ToString();//运费预付地点
                        row.Cells["shipName"].Value = table.Rows[i]["shipName"].ToString();//船名

                        row.Cells["price"].Value = table.Rows[i]["price"].ToString();//单价
                        row.Cells["forUnit"].Value = table.Rows[i]["forUnit"].ToString();//发货单位
                        row.Cells["supCom"].Value = table.Rows[i]["supCom"].ToString();//供应方公司
                        row.Cells["receive"].Value = table.Rows[i]["receive"].ToString();//接收方
                        row.Cells["receiveAdd"].Value = table.Rows[i]["receiveAdd"].ToString();//接收方地址
                        row.Cells["quaIndex"].Value = table.Rows[i]["quaIndex"].ToString();//质量指标
                        row.Cells["contractNums"].Value = table.Rows[i]["contractNums"].ToString();//合同号
                        row.Cells["priceMJ"].Value = table.Rows[i]["priceMJ"].ToString();//美金单价
                        row.Cells["FOB"].Value = table.Rows[i]["FOB"].ToString();//FOB金额
                        row.Cells["CFR"].Value = table.Rows[i]["CFR"].ToString();//CFR金额
                    }
                }
                else
                {
                    //MessageBox.Show("没有记录了");
                    return 0;
                }
            }
            else
            {

                MessageBox.Show("采购编号没有带入！");
            }
            //SELECT id,`code`,codeNumContract,codeNum,fishId,quaIden,commodityTons,commodityPack,commodity,speci,countryOfOrigin,billName,sign,shipMent,shipMentUser,checkAddDate,sampling,db,water,zf,freshness,sy,oxi,weight,package,avgWeight,shipper,shipperNum,billNames,contractNum,goodsNum,consi,preShip,oceanShip,navNum,agent,receipt,shipHar,unShopHar,desTi,lastDesTi,num,containNum,paper,conWeight,pakeWeight,seal,freight,freightAdd,shipName,price,forUnit,supCom,receive,receiveAdd,quaIndex,contractNums,priceMJ,FOB,CFR FROM	t_warehousereceipt
            return base.Query();
        }
        string bill = string.Empty, billNum = string.Empty, path = string.Empty;

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_100");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_100");
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            billNum = dataGridView1.Rows[e.RowIndex].Cells["codeNum"].Value.ToString();
            Reflected("FishClient.FormNewWarehouseReceipt");
        }

        void Reflected(string path)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Form doc = (Form)asm.CreateInstance(path);
            Megres.oddNum = billNum;
            doc.Owner = this;
            doc.Show();
        }
    }
}
