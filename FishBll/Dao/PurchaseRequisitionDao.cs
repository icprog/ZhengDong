using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;
using FishEntity;


namespace FishBll.Dao
{
    public class PurchaseRequisitionDao
    {
        public PurchaseRequisitionDao() { }
        public bool Exists(string code)//
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_PurchaseRequisition");
            strSql.Append(" where ContractNo=@ContractNo ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ContractNo", MySqlDbType.VarChar,45)};
            parameters[0].Value = code;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }
        public string ContractNo()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(ContractNo) ContractNo FROM t_PurchaseRequisition where length(ContractNo)=10");

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["ContractNo"].ToString()))
                    return string.Empty;
                else
                    return ds.Tables[0].Rows[0]["ContractNo"].ToString();
            }
            else
                return string.Empty;
        }
        public DateTime getDate()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NOW() t");

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["t"].ToString()))
                    return DateTime.Now;
                else
                    return Convert.ToDateTime(ds.Tables[0].Rows[0]["t"].ToString());
            }
            else
                return DateTime.Now;
        }
        public List<FishEntity.PurchaseRequisitionEntity> getMax()
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(" SELECT Numbering FROM t_purchaserequisition where substring_index(Numbering,'C',1)=DATE_FORMAT(NOW(),'%Y') ");
            DataSet ds = MySqlHelper.Query(strsql.ToString());
            List<FishEntity.PurchaseRequisitionEntity> ModelList = new List<PurchaseRequisitionEntity>();
            int rowsCount = ds.Tables[0].Rows.Count;
            FishEntity.PurchaseRequisitionEntity model;
            for (int i = 0; i < rowsCount; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                model = new PurchaseRequisitionEntity();
                if (row["Numbering"]!=null)
                {
                    model.Numbering = row["Numbering"].ToString();
                }
                ModelList.Add(model);
            }
            return ModelList;
        }
        public List<FishEntity.PurchaseRequisitionEntity> GetList(string strwhere)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from t_PurchaseRequisition ");
            if (strwhere.Trim() != "")
            {
                strsql.Append(" where " + strwhere);
            }
            DataSet ds = MySqlHelper.Query(strsql.ToString());
            List<FishEntity.PurchaseRequisitionEntity> ModelList = new List<PurchaseRequisitionEntity>();
            int rowsCount = ds.Tables[0].Rows.Count;
            FishEntity.PurchaseRequisitionEntity model;
            for (int i = 0; i < rowsCount; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                model = new PurchaseRequisitionEntity();
                if (row["id"].ToString() != "")
                {
                    model.Id = int.Parse(row["id"].ToString());
                }
                if (row["Numbering"] != null)
                {
                    model.Numbering = row["Numbering"].ToString();
                }
                if (row["accountnumber"] != null)
                {
                    model.Accountnumber = row["accountnumber"].ToString();
                }
                if (row["Openbank"] != null)
                {
                    model.Openbank = row["Openbank"].ToString();
                }
                if (row["ContractNo"] != null && row["ContractNo"].ToString() != "")
                {
                    model.ContractNo = row["ContractNo"].ToString();
                }
                if (row["supplier"] != null)
                {
                    model.Supplier = row["supplier"].ToString();
                }
                if (row["SupplierId"] != null)
                {
                    model.SupplierId = row["SupplierId"].ToString();
                }
                if (row["DemandSide"] != null)
                {
                    model.DemandSide = row["DemandSide"].ToString();
                }
                if (row["Purchasingcontacts"] != null)
                {
                    model.Purchasingcontacts = row["Purchasingcontacts"].ToString();
                }
                if (row["PurchasingcontactsId"] != null)
                {
                    model.PurchasingcontactsId = row["PurchasingcontactsId"].ToString();
                }
                if (row["DemandSideId"] != null)
                {
                    model.DemandSideId = row["DemandSideId"].ToString();
                }
                if (row["DateOfSigni"] != null)
                {
                    model.DateOfSigni = DateTime.Parse(row["DateOfSigni"].ToString());
                }
                if (row["deliverytime"] != null)
                {
                    model.Deliverytime = DateTime.Parse(row["deliverytime"].ToString());
                }
                if (row["PlaceOfSign"] != null && row["PlaceOfSign"].ToString() != "")
                {
                    model.PlaceOfSign = row["PlaceOfSign"].ToString();
                }
                if (row["ProductName"] != null && row["ProductName"].ToString() != "")
                {
                    model.ProductName = row["ProductName"].ToString();
                }
                if (row["Unit"] != null && row["Unit"].ToString() != "")
                {
                    model.Unit = row["Unit"].ToString();
                }
                if (row["FishmealId"] != null)
                {
                    model.FishmealId = row["FishmealId"].ToString();
                }
                if (row["Variety"] != null && row["Variety"].ToString() != "")
                {
                    model.Variety = row["Variety"].ToString();
                }
                if (row["Quantity"] != null)
                {
                    model.Quantity = row["Quantity"].ToString();
                }
                if (row["NameOfTheShip"] != null)
                {
                    model.NameOfTheShip = row["NameOfTheShip"].ToString();
                }
                if (row["BillOfLadingNumber"] != null)
                {
                    model.BillOfLadingNumber = row["BillOfLadingNumber"].ToString();
                }
                if (row["DemandSideShort"] != null)
                {
                    model.DemandSideShort = row["DemandSideShort"].ToString();
                }
                if (row["SupplierAbbreviation"] != null)
                {
                    model.SupplierAbbreviation = row["SupplierAbbreviation"].ToString();
                }
                if (row["Ash"] != null)
                {
                    model.Ash = row["Ash"].ToString();
                }
                if (row["HTprotein"] != null)
                {
                    model.HTprotein = row["HTprotein"].ToString();
                }
                if (row["HTTVB"] != null)
                {
                    model.HTTVB = row["HTTVB"].ToString();
                }
                if (row["HTHistamine"] != null)
                {
                    model.HTHistamine = row["HTHistamine"].ToString();
                }
                if (row["HTFFA"] != null)
                {
                    model.HTFFA = row["HTFFA"].ToString();
                }
                if (row["HTFat"] != null)
                {
                    model.HTFat = row["HTFat"].ToString();
                }
                if (row["HTMoisture"] != null)
                {
                    model.HTMoisture = row["HTMoisture"].ToString();
                }
                if (row["HTSandAndSalt"] != null)
                {
                    model.HTSandAndSalt = row["HTSandAndSalt"].ToString();
                }
                if (row["HTSand"] != null)
                {
                    model.HTSand = row["HTSand"].ToString();
                }
                if (row["HTUnit"] != null)
                {
                    model.HTUnit = row["HTUnit"].ToString();
                }
                if (row["HTAsh"] != null)
                {
                    model.HTAsh = row["HTAsh"].ToString();
                }
                if (row["Lysine"] != null)
                {
                    model.Lysine = row["Lysine"].ToString();
                }
                if (row["Methionine"] != null)
                {
                    model.Methionine = row["Methionine"].ToString();
                }
                if (row["Specification"] != null)
                {
                    model.Specification = row["Specification"].ToString();
                }
                if (row["MJAmount"] != null)
                {
                    model.MJAmount = row["MJAmount"].ToString();
                }
                if (row["Remarks"] != null)
                {
                    model.Remarks = row["Remarks"].ToString();
                }
                if (row["UnitPrice"] != null)
                {
                    model.UnitPrice = row["UnitPrice"].ToString();
                }
                if (row["AmountOfMoney"] != null)
                {
                    model.AmountOfMoney = row["AmountOfMoney"].ToString();
                }
                if (row["Protein"] != null)
                {
                    model.Protein = row["Protein"].ToString();
                }
                if (row["TVN"] != null)
                {
                    model.TVN = row["TVN"].ToString();
                }
                if (row["Histamine"] != null)
                {
                    model.Histamine = row["Histamine"].ToString();
                }
                if (row["FFA"] != null)
                {
                    model.FFA = row["FFA"].ToString();
                }
                if (row["Fat"] != null)
                {
                    model.Fat = row["Fat"].ToString();
                }
                if (row["Moisture"] != null)
                {
                    model.Moisture = row["Moisture"].ToString();
                }
                if (row["SandAndSalt"] != null)
                {
                    model.SandAndSalt = row["SandAndSalt"].ToString();
                }
                if (row["Sand"] != null)
                {
                    model.Sand = row["Sand"].ToString();
                }
                if (row["Rebate"] != null)
                {
                    model.Rebate = row["Rebate"].ToString();
                }
                if (row["USDollarPrice"] != null)
                {
                    model.USDollarPrice = row["USDollarPrice"].ToString();
                }
                if (row["Country"] != null)
                {
                    model.Country = row["Country"].ToString();
                }
                if (row["validate"]!=null)
                {
                    model.validate = row["validate"].ToString();
                }
                if (row["Brand"] != null)
                {
                    model.Brand = row["Brand"].ToString();
                }
                if (row["TradingLocations"] != null)
                {
                    model.TradingLocations = row["TradingLocations"].ToString();
                }
                if (row["TimeOfShipment"] != null)
                {
                    model.TimeOfShipment = DateTime.Parse(row["TimeOfShipment"].ToString());
                }
                if (row["ExpectedDate"] != null)
                {
                    model.ExpectedDate = DateTime.Parse(row["ExpectedDate"].ToString());
                }
                if (row["createman"] != null)
                {
                    model.Createman = row["createman"].ToString();
                }
                ModelList.Add(model);
            }
            return ModelList;
        }
        public string code()
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("SELECT max(substring_index(Numbering,'C',-1))as Numbering FROM t_PurchaseRequisition where substring_index(Numbering,'C',1)=DATE_FORMAT(NOW(),'%Y')");
            strSql.Append("SELECT max(substring_index(Numbering,'C',-1))as Numbering FROM t_PurchaseRequisition where substring_index(Numbering,'C',1)=DATE_FORMAT(NOW(),'%Y')");

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Numbering"].ToString()))
                    return string.Empty;
                else
                    return ds.Tables[0].Rows[0]["Numbering"].ToString();
            }
            else
                return string.Empty;
        }
        public bool Update(FishEntity.PurchaseRequisitionEntity model) {
            StringBuilder strsql = new StringBuilder();            
            strsql.Append("update t_purchaserequisition set ");
            strsql.Append("supplier = @supplier,");
            strsql.Append("ContractNo=@ContractNo,");
            strsql.Append("SupplierId = @SupplierId,");
            strsql.Append("DemandSide = @DemandSide,");
            strsql.Append("DemandSideId = @DemandSideId,");
            strsql.Append("DateOfSigni = @DateOfSigni,");
            strsql.Append("PlaceOfSign = @PlaceOfSign,");
            strsql.Append("ProductName = @ProductName,");
            strsql.Append("Unit = @Unit,");
            strsql.Append("FishmealId=@FishmealId,");
            strsql.Append("Variety = @Variety,");
            strsql.Append("Quantity = @Quantity,");
            strsql.Append("NameOfTheShip = @NameOfTheShip,");
            strsql.Append("BillOfLadingNumber = @BillOfLadingNumber,");
            strsql.Append("DemandSideShort = @DemandSideShort,");
            strsql.Append("SupplierAbbreviation = @SupplierAbbreviation,");
            strsql.Append("Ash = @Ash,");
            strsql.Append("HTprotein = @HTprotein,");
            strsql.Append("HTTVB = @HTTVB,");
            strsql.Append("HTHistamine = @HTHistamine,");
            strsql.Append("HTFFA = @HTFFA,");
            strsql.Append("HTFat = @HTFat,");
            strsql.Append("HTMoisture = @HTMoisture,");
            strsql.Append("HTSandAndSalt = @HTSandAndSalt,");
            strsql.Append("HTSand = @HTSand,");
            strsql.Append("HTUnit = @HTUnit,");
            strsql.Append("HTAsh = @HTAsh,");
            strsql.Append("Lysine = @Lysine,");
            strsql.Append("Methionine = @Methionine,");
            strsql.Append("Specification=@Specification,");
            strsql.Append("MJAmount=@MJAmount,");
            strsql.Append("UnitPrice = @UnitPrice,");
            strsql.Append("AmountOfMoney = @AmountOfMoney,");
            strsql.Append("Protein = @Protein,");
            strsql.Append("TVN = @TVN,");
            strsql.Append("Histamine = @Histamine,");
            strsql.Append("FFA = @FFA,");
            strsql.Append("Fat = @Fat,");
            strsql.Append("Moisture = @Moisture,");
            strsql.Append("SandAndSalt = @SandAndSalt,");
            strsql.Append("Sand = @Sand,");
            strsql.Append("Rebate = @Rebate,");
            strsql.Append("USDollarPrice = @USDollarPrice,");
            strsql.Append("Country = @Country,");
            strsql.Append("validate=@validate,");
            strsql.Append("Brand=@Brand,");
            strsql.Append("TradingLocations = @TradingLocations,");
            strsql.Append("TimeOfShipment = @TimeOfShipment,");
            strsql.Append("ExpectedDate = @ExpectedDate, ");
            strsql.Append("modifyman=@modifyman,");
            strsql.Append("modifytime=@modifytime, ");
            strsql.Append("Numbering=@Numbering, ");
            strsql.Append("Openbank=@Openbank, ");
            strsql.Append("accountnumber=@accountnumber, ");
            strsql.Append("Purchasingcontacts=@Purchasingcontacts,");
            strsql.Append("PurchasingcontactsId=@PurchasingcontactsId,");
            strsql.Append("deliverytime=@deliverytime,");
            strsql.Append("Remarks=@Remarks ");
            strsql.Append("where id = @id");
            MySqlParameter[] parameter = {
                new MySqlParameter("@supplier",MySqlDbType.VarChar,45),
                new MySqlParameter("@DemandSide",MySqlDbType.VarChar,45),
                new MySqlParameter("@DateOfSigni",MySqlDbType.DateTime),
                new MySqlParameter("@PlaceOfSign",MySqlDbType.VarChar,45),
                new MySqlParameter("@ProductName",MySqlDbType.VarChar,45),
                new MySqlParameter("@Unit",MySqlDbType.VarChar,45),
                new MySqlParameter("@Variety",MySqlDbType.VarChar,45),
                new MySqlParameter("@Quantity",MySqlDbType.VarChar,45),
                new MySqlParameter("@UnitPrice",MySqlDbType.VarChar,45),
                new MySqlParameter("@AmountOfMoney",MySqlDbType.VarChar,45),
                new MySqlParameter("@Protein",MySqlDbType.VarChar,45),
                new MySqlParameter("@TVN",MySqlDbType.VarChar,45),
                new MySqlParameter("@Histamine",MySqlDbType.VarChar,45),
                new MySqlParameter("@FFA",MySqlDbType.VarChar,45),
                new MySqlParameter("@Fat",MySqlDbType.VarChar,45),
                new MySqlParameter("@Moisture",MySqlDbType.VarChar,45),
                new MySqlParameter("@SandAndSalt",MySqlDbType.VarChar,45),
                new MySqlParameter("@Sand",MySqlDbType.VarChar,45),
                new MySqlParameter("@Rebate",MySqlDbType.VarChar,45),
                new MySqlParameter("@USDollarPrice",MySqlDbType.VarChar,45),
                new MySqlParameter("@Country",MySqlDbType.VarChar,45),
                new MySqlParameter("@TradingLocations",MySqlDbType.VarChar,45),
                new MySqlParameter("@TimeOfShipment",MySqlDbType.DateTime),
                new MySqlParameter("@ExpectedDate",MySqlDbType.DateTime),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@Numbering",MySqlDbType.VarChar,45),
                new MySqlParameter("@Openbank",MySqlDbType.VarChar,100),
                new MySqlParameter("@accountnumber",MySqlDbType.VarChar,100),
                new MySqlParameter("@id",MySqlDbType.Int32,11),
                new MySqlParameter("@deliverytime",MySqlDbType.DateTime),
                new MySqlParameter("@SupplierId",MySqlDbType.VarChar,45),
                new MySqlParameter("@Purchasingcontacts",MySqlDbType.VarChar,45),
                new MySqlParameter("@DemandSideId",MySqlDbType.VarChar,45),
                new MySqlParameter("@PurchasingcontactsId",MySqlDbType.VarChar,45),
                new MySqlParameter("@FishmealId",MySqlDbType.VarChar,45),
                new MySqlParameter("@Brand",MySqlDbType.VarChar,45),
                new MySqlParameter("@Remarks",MySqlDbType.VarChar,500),
                new MySqlParameter("@ContractNo",MySqlDbType.VarChar,45),
                new MySqlParameter("@NameOfTheShip",MySqlDbType.VarChar,45),
                new MySqlParameter("@BillOfLadingNumber",MySqlDbType.VarChar,45),
                new MySqlParameter("@DemandSideShort",MySqlDbType.VarChar,45),
                new MySqlParameter("@SupplierAbbreviation",MySqlDbType.VarChar,45),
                new MySqlParameter("@Ash",MySqlDbType.VarChar,45),
                new MySqlParameter("@HTprotein",MySqlDbType.VarChar,45),
                new MySqlParameter("@HTTVB",MySqlDbType.VarChar,45),
                new MySqlParameter("@HTHistamine",MySqlDbType.VarChar,45),
                new MySqlParameter("@HTFFA",MySqlDbType.VarChar,45),
                new MySqlParameter("@HTFat",MySqlDbType.VarChar,45),
                new MySqlParameter("@HTMoisture",MySqlDbType.VarChar,45),
                new MySqlParameter("@HTSandAndSalt",MySqlDbType.VarChar,45),
                new MySqlParameter("@HTSand",MySqlDbType.VarChar,45),
                new MySqlParameter("@HTUnit",MySqlDbType.VarChar,45),
                new MySqlParameter("@HTAsh",MySqlDbType.VarChar,45),
                new MySqlParameter("@Lysine",MySqlDbType.VarChar,45),
                new MySqlParameter("@Methionine",MySqlDbType.VarChar,45),
                new MySqlParameter("@Specification",MySqlDbType.VarChar,45),
                new MySqlParameter("@MJAmount",MySqlDbType.VarChar,45),
                new MySqlParameter("@validate",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = model.Supplier;
            parameter[1].Value = model.DemandSide;
            parameter[2].Value = model.DateOfSigni;
            parameter[3].Value = model.PlaceOfSign;
            parameter[4].Value = model.ProductName;
            parameter[5].Value = model.Unit;
            parameter[6].Value = model.Variety;
            parameter[7].Value = model.Quantity;
            parameter[8].Value = model.UnitPrice;
            parameter[9].Value = model.AmountOfMoney;
            parameter[10].Value = model.Protein;
            parameter[11].Value = model.TVN;
            parameter[12].Value = model.Histamine;
            parameter[13].Value = model.FFA;
            parameter[14].Value = model.Fat;
            parameter[15].Value = model.Moisture;
            parameter[16].Value = model.SandAndSalt;
            parameter[17].Value = model.Sand;
            parameter[18].Value = model.Rebate;
            parameter[19].Value = model.USDollarPrice;
            parameter[20].Value = model.Country;
            parameter[21].Value = model.TradingLocations;
            parameter[22].Value = model.TimeOfShipment;
            parameter[23].Value = model.ExpectedDate;
            parameter[24].Value = model.Modifyman;
            parameter[25].Value = model.Modifytime;
            parameter[26].Value = model.Numbering;
            parameter[27].Value = model.Openbank;
            parameter[28].Value = model.Accountnumber;
            parameter[29].Value = model.Id;
            parameter[30].Value = model.Deliverytime;
            parameter[31].Value = model.SupplierId;
            parameter[32].Value = model.Purchasingcontacts;
            parameter[33].Value = model.DemandSideId;
            parameter[34].Value = model.PurchasingcontactsId;
            parameter[35].Value = model.FishmealId;
            parameter[36].Value = model.Brand;
            parameter[37].Value = model.Remarks;
            parameter[38].Value = model.ContractNo;
            parameter[39].Value = model.NameOfTheShip;
            parameter[40].Value = model.BillOfLadingNumber;
            parameter[41].Value = model.DemandSideShort;
            parameter[42].Value = model.SupplierAbbreviation;
            parameter[43].Value = model.Ash;
            parameter[44].Value = model.HTprotein;
            parameter[45].Value = model.HTTVB;
            parameter[46].Value = model.HTHistamine;
            parameter[47].Value = model.HTFFA;
            parameter[48].Value = model.HTFat;
            parameter[49].Value = model.HTMoisture;
            parameter[50].Value = model.HTSandAndSalt;
            parameter[51].Value = model.HTSand;
            parameter[52].Value = model.HTUnit;
            parameter[53].Value = model.HTAsh;
            parameter[54].Value = model.Lysine;
            parameter[55].Value = model.Methionine;
            parameter[56].Value = model.Specification;
            parameter[57].Value = model.MJAmount;
            parameter[58].Value = model.validate;
            int row = MySqlHelper.ExecuteSql(strsql.ToString(), parameter);
            if (row > 0)
                return true;
            else
                return false;
        }
        public int Add(FishEntity.PurchaseRequisitionEntity model)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into t_purchaserequisition(ContractNo,supplier,SupplierId,DemandSide,DemandSideId,DateOfSigni,PlaceOfSign,ProductName,Unit,FishmealId,Variety,Quantity,NameOfTheShip,BillOfLadingNumber,DemandSideShort,SupplierAbbreviation,Ash,HTprotein,HTTVB,HTHistamine,HTFFA,HTFat,HTMoisture,HTSandAndSalt,HTSand,HTUnit,HTAsh,Lysine,Methionine,UnitPrice,AmountOfMoney,Protein,TVN,Histamine,FFA,Fat,Moisture,SandAndSalt,Sand,Rebate,USDollarPrice,Country,Brand,TradingLocations,TimeOfShipment,ExpectedDate,modifyman,modifytime,createman,createtime,Numbering,Openbank,accountnumber,Purchasingcontacts,deliverytime,PurchasingcontactsId,Remarks,Specification,MJAmount,validate)");
            strsql.Append("values(@ContractNo,@supplier,@SupplierId,@DemandSide,@DemandSideId,@DateOfSigni,@PlaceOfSign,@ProductName,@Unit,@FishmealId,@Variety,@Quantity,@NameOfTheShip,@BillOfLadingNumber,@DemandSideShort,@SupplierAbbreviation,@Ash,@HTprotein,@HTTVB,@HTHistamine,@HTFFA,@HTFat,@HTMoisture,@HTSandAndSalt,@HTSand,@HTUnit,@HTAsh,@Lysine,@Methionine,@UnitPrice,@AmountOfMoney,@Protein,@TVN,@Histamine,@FFA,@Fat,@Moisture,@SandAndSalt,@Sand,@Rebate,@USDollarPrice,@Country,@Brand,@TradingLocations,@TimeOfShipment,@ExpectedDate,@modifyman,@modifytime,@createman,@createtime,@Numbering,@Openbank,@accountnumber,@Purchasingcontacts,@deliverytime,@PurchasingcontactsId,@Remarks,@Specification,@MJAmount,@validate)");
            MySqlParameter[] parameter = {
                new MySqlParameter("@ContractNo",MySqlDbType.VarChar,45),
                new MySqlParameter("@supplier",MySqlDbType.VarChar,45),
                new MySqlParameter("@DemandSide",MySqlDbType.VarChar,45),
                new MySqlParameter("@DateOfSigni",MySqlDbType.DateTime),
                new MySqlParameter("@PlaceOfSign",MySqlDbType.VarChar,45),
                new MySqlParameter("@ProductName",MySqlDbType.VarChar,45),
                new MySqlParameter("@Unit",MySqlDbType.VarChar,45),
                new MySqlParameter("@Variety",MySqlDbType.VarChar,45),
                new MySqlParameter("@Quantity",MySqlDbType.VarChar,45),
                new MySqlParameter("@UnitPrice",MySqlDbType.VarChar,45),
                new MySqlParameter("@AmountOfMoney",MySqlDbType.VarChar,45),
                new MySqlParameter("@Protein",MySqlDbType.VarChar,45),
                new MySqlParameter("@TVN",MySqlDbType.VarChar,45),
                new MySqlParameter("@Histamine",MySqlDbType.VarChar,45),
                new MySqlParameter("@FFA",MySqlDbType.VarChar,45),
                new MySqlParameter("@Fat",MySqlDbType.VarChar,45),
                new MySqlParameter("@Moisture",MySqlDbType.VarChar,45),
                new MySqlParameter("@SandAndSalt",MySqlDbType.VarChar,45),
                new MySqlParameter("@Sand",MySqlDbType.VarChar,45),
                new MySqlParameter("@Rebate",MySqlDbType.VarChar,45),
                new MySqlParameter("@USDollarPrice",MySqlDbType.VarChar,45),
                new MySqlParameter("@Country",MySqlDbType.VarChar,45),
                new MySqlParameter("@TradingLocations",MySqlDbType.VarChar,45),
                new MySqlParameter("@TimeOfShipment",MySqlDbType.DateTime),
                new MySqlParameter("@ExpectedDate",MySqlDbType.DateTime),
                new MySqlParameter("@createman",MySqlDbType.VarChar,45),
                new MySqlParameter("@createtime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@Numbering",MySqlDbType.VarChar,45),
                new MySqlParameter("@Openbank",MySqlDbType.VarChar,100),
                new MySqlParameter("@accountnumber",MySqlDbType.VarChar,100),
                new MySqlParameter("@Purchasingcontacts",MySqlDbType.VarChar,45),
                new MySqlParameter("@deliverytime",MySqlDbType.DateTime),
                new MySqlParameter("@SupplierId",MySqlDbType.VarChar,45),
                new MySqlParameter("@DemandSideId",MySqlDbType.VarChar,45),
                new MySqlParameter("@PurchasingcontactsId",MySqlDbType.VarChar,45),
                new MySqlParameter("@FishmealId",MySqlDbType.VarChar,45),
                new MySqlParameter("@Brand",MySqlDbType.VarChar,45),
                new MySqlParameter("@Remarks",MySqlDbType.VarChar,500),
                new MySqlParameter("@NameOfTheShip",MySqlDbType.VarChar,45),
                new MySqlParameter("@BillOfLadingNumber",MySqlDbType.VarChar,45),
                new MySqlParameter("@DemandSideShort",MySqlDbType.VarChar,45),
                new MySqlParameter("@SupplierAbbreviation",MySqlDbType.VarChar,45),
                new MySqlParameter("@Ash",MySqlDbType.VarChar,45),
                new MySqlParameter("@HTprotein",MySqlDbType.VarChar,45),
                new MySqlParameter("@HTTVB",MySqlDbType.VarChar,45),
                new MySqlParameter("@HTHistamine",MySqlDbType.VarChar,45),
                new MySqlParameter("@HTFFA",MySqlDbType.VarChar,45),
                new MySqlParameter("@HTFat",MySqlDbType.VarChar,45),
                new MySqlParameter("@HTMoisture",MySqlDbType.VarChar,45),
                new MySqlParameter("@HTSandAndSalt",MySqlDbType.VarChar,45),
                new MySqlParameter("@HTSand",MySqlDbType.VarChar,45),
                new MySqlParameter("@HTUnit",MySqlDbType.VarChar,45),
                new MySqlParameter("@HTAsh",MySqlDbType.VarChar,45),
                new MySqlParameter("@Lysine",MySqlDbType.VarChar,45),
                new MySqlParameter("@Methionine",MySqlDbType.VarChar,45),
                new MySqlParameter("@Specification",MySqlDbType.VarChar,45),
                new MySqlParameter("@MJAmount",MySqlDbType.VarChar,45),
                new MySqlParameter("@validate",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = model.ContractNo;
            parameter[1].Value = model.Supplier;
            parameter[2].Value = model.DemandSide;
            parameter[3].Value = model.DateOfSigni;
            parameter[4].Value = model.PlaceOfSign;
            parameter[5].Value = model.ProductName;
            parameter[6].Value = model.Unit;
            parameter[7].Value = model.Variety;
            parameter[8].Value = model.Quantity;
            parameter[9].Value = model.UnitPrice;
            parameter[10].Value = model.AmountOfMoney;
            parameter[11].Value = model.Protein;
            parameter[12].Value = model.TVN;
            parameter[13].Value = model.Histamine;
            parameter[14].Value = model.FFA;
            parameter[15].Value = model.Fat;
            parameter[16].Value = model.Moisture;
            parameter[17].Value = model.SandAndSalt;
            parameter[18].Value = model.Sand;
            parameter[19].Value = model.Rebate;
            parameter[20].Value = model.USDollarPrice;
            parameter[21].Value = model.Country;
            parameter[22].Value = model.TradingLocations;
            parameter[23].Value = model.TimeOfShipment;
            parameter[24].Value = model.ExpectedDate;
            parameter[25].Value = model.Createman;
            parameter[26].Value = model.Createtime;
            parameter[27].Value = model.Modifyman;
            parameter[28].Value = model.Modifytime;
            parameter[29].Value = model.Numbering;
            parameter[30].Value = model.Openbank;
            parameter[31].Value = model.Accountnumber;
            parameter[32].Value = model.Purchasingcontacts;
            parameter[33].Value = model.Deliverytime;
            parameter[34].Value = model.SupplierId;
            parameter[35].Value = model.DemandSideId;
            parameter[36].Value = model.PurchasingcontactsId;
            parameter[37].Value = model.FishmealId;
            parameter[38].Value = model.Brand;
            parameter[39].Value = model.Remarks;
            parameter[40].Value = model.NameOfTheShip;
            parameter[41].Value = model.BillOfLadingNumber;
            parameter[42].Value = model.DemandSideShort;
            parameter[43].Value = model.SupplierAbbreviation;
            parameter[44].Value = model.Ash;
            parameter[45].Value = model.HTprotein;
            parameter[46].Value = model.HTTVB;
            parameter[47].Value = model.HTHistamine;
            parameter[48].Value = model.HTFFA;
            parameter[49].Value = model.HTFat;
            parameter[50].Value = model.HTMoisture;
            parameter[51].Value = model.HTSandAndSalt;
            parameter[52].Value = model.HTSand;
            parameter[53].Value = model.HTUnit;
            parameter[54].Value = model.HTAsh;
            parameter[55].Value = model.Lysine;
            parameter[56].Value = model.Methionine;
            parameter[57].Value = model.Specification;
            parameter[58].Value = model.MJAmount;
            parameter[59].Value = model.validate;
            int id = MySqlHelper.ExecuteSql(strsql.ToString(), parameter);
            return id;
        }

    }
}
