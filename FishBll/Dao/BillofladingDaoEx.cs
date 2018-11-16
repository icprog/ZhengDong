using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;


namespace FishBll.Dao
{
    public class BillofladingDaoEx : BillofladingDao
    {
        public FishEntity.SalesRequisitionEntity getTHD(string getname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.Numbering,c.product_id,a.code,demand,demandId,b.Variety,cm,zjh,tdh,c.Quantity FROM t_salesorder a LEFT JOIN t_purchaserequisition b ON a.Purchasecontractnumber = b.ContractNo LEFT JOIN t_happening c on a.Numbering=c.NumberingOne ");
            strSql.Append("where a.Numbering= '" + getname + "'");
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                FishEntity.SalesRequisitionEntity model = new FishEntity.SalesRequisitionEntity();
                DataRow row = ds.Tables[0].Rows[0];
                if (row["Numbering"]!=null)
                {
                    model.Numbering = row["Numbering"].ToString();
                }
                if (row["code"] != null)
                {
                    model.code = row["code"].ToString();
                }
                if (row["product_id"]!=null)
                {
                    model.Product_id = row["product_id"].ToString();
                }
                if (row["demand"] != null)
                {
                    model.demand = row["demand"].ToString();
                }
                if (row["demandId"] != null)
                {
                    model.demandId = row["demandId"].ToString();
                }
                if (row["Variety"] != null)
                {
                    model.Variety = row["Variety"].ToString();
                }
                if (row["cm"] != null)
                {
                    model.cm = row["cm"].ToString();
                }
                if (row["Quantity"] != null)
                {
                    model.Quantity = row["Quantity"].ToString();
                }
                if (row["zjh"] != null)
                {
                    model.zjh = row["zjh"].ToString();
                }
                if (row["tdh"] != null)
                {
                    model.tdh = row["tdh"].ToString();
                }
                return model;
            }
            else {
                return null;
            }
        }
        public List<FishEntity.BillofladingEntityVo> GetModelListVo(string strwhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from t_billoflading");
            if (strwhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strwhere);
            }
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            List<FishEntity.BillofladingEntityVo> modelList = new List<FishEntity.BillofladingEntityVo>();
            int rowsCount = ds.Tables[0].Rows.Count;
            FishEntity.BillofladingEntityVo model;
            for (int n = 0; n < rowsCount; n++)
            {
                DataRow row = ds.Tables[0].Rows[n];
                model = new FishEntity.BillofladingEntityVo();
                if (row["Numbering"]!=null)
                {
                    model.Numbering = row["Numbering"].ToString();
                }
                if (row["FishMealId"] != null) {
                    model.FishMealId = row["FishMealId"].ToString();
                }
                if (row["Country"]!=null)
                {
                    model.Country = row["Country"].ToString();
                }
                if (row["Brands"]!=null)
                {
                    model.Brands = row["Brands"].ToString();
                }
                if (row["id"].ToString() != "")
                {
                    model.Id = int.Parse(row["id"].ToString());
                }
                if (row["code"] != null && row["code"].ToString() != "")
                {
                    model.Code = row["code"].ToString();
                }
                if (row["Issuingtime"] != null && row["Issuingtime"].ToString() != "")
                {
                    model.Issuingtime = DateTime.Parse(row["Issuingtime"].ToString());
                }
                if (row["contactsunit"] != null && row["contactsunit"].ToString() != "")
                {
                    model.Contactsunit = row["contactsunit"].ToString();
                }
                if (row["ContactsunitId"] != null)
                {
                    model.ContactsunitId = row["ContactsunitId"].ToString();
                }
                if (row["warehouse"] != null && row["warehouse"].ToString() != "")
                {
                    model.Warehouse = row["warehouse"].ToString();
                }
                if (row["species"] != null)
                {
                    model.Species = row["species"].ToString();
                }
                if (row["specification"] != null)
                {
                    model.Specification = row["specification"].ToString();
                }
                if (row["SerialNumber"]!=null)
                {
                    model.SerialNumber = row["SerialNumber"].ToString();
                }
                if (row["ferryname"] != null && row["ferryname"].ToString() != "")
                {
                    model.Ferryname = row["ferryname"].ToString();
                }
                if (row["listname"] != null && row["listname"].ToString() != "")
                {
                    model.Listname = row["listname"].ToString();
                }
                if (row["cornerno"] != null)
                {
                    model.Cornerno = row["cornerno"].ToString();
                }
                if (row["Ton"] != null)
                {
                    model.Ton = row["Ton"].ToString();
                }
                if (row["RedemptionWeight"] != null && row["RedemptionWeight"].ToString() != "")
                {
                    model.RedemptionWeight =Convert.ToDecimal(row["RedemptionWeight"].ToString());
                }
                if (row["packagenumber"] != null)
                {
                    model.Packagenumber = row["packagenumber"].ToString();
                }
                if (row["Remarks"].ToString() != "")
                {
                    model.Remarks = row["Remarks"].ToString();
                }
                if (row["ShipNotice"] != null && row["ShipNotice"].ToString() != "")
                {
                    model.ShipNotice = row["ShipNotice"].ToString();
                }
                if (row["Storagecosts"] != null)
                {
                    model.Storagecosts = row["Storagecosts"].ToString();
                }
                if (row["codeContract"] != null && row["codeContract"].ToString() != "")
                {
                    model.codeContract = row["codeContract"].ToString();
                }
                if (row["Recipient"] != null)
                {
                    model.Recipient = row["Recipient"].ToString();
                }
                //if (row["createtime"]!=null&&row["createtime"].ToString()!="")
                //{
                //    model.Createtime = DateTime.Parse(row["createtime"].ToString());
                //}
                if (row["createman"] != null && row["createman"].ToString() != "")
                {
                    model.Createman = row["createman"].ToString();
                }
                if (row["modifytime"] != null && row["modifytime"].ToString() != "")
                {
                    model.Modifytime = DateTime.Parse(row["modifytime"].ToString());
                }
                if (row["modifyman"] != null && row["modifyman"].ToString() != "")
                {
                    model.Modifyman = row["modifyman"].ToString();
                }
                modelList.Add(model);
            }
            return modelList;
        }
    }
}
