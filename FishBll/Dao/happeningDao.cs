using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class happeningDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<FishEntity.SalesRequisitionBodyEntity> getList(string Numbering)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append( "SELECT NumberingOne,code,product_id,productname,Funit,Variety,Quantity,unitprice,Amonut,db,tvn,za,ffa,zf,sf,shy,sz,cdb,tvnOne,hf,cm,zjh,tdh,pp,Country,zaOne,ffaOne,zfOne,sfOne,shyOne,szOne,codeNumZdi,codeNumHq FROM t_happening " );
            strSql.Append("WHERE NumberingOne=@NumberingOne");
            MySqlParameter[] parameter = {
                new MySqlParameter("@NumberingOne",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = Numbering;

            DataSet ds = MySqlHelper.Query(strSql.ToString(), parameter);
            DataTable dt = ds.Tables[0];

            List<FishEntity.SalesRequisitionBodyEntity> modelList = new List<FishEntity.SalesRequisitionBodyEntity>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(getModel(dt.Rows[i]));
                }
                return modelList;
            }
            else
                return null;

        }

        public FishEntity.SalesRequisitionBodyEntity getModel(DataRow row)
        {
            FishEntity.SalesRequisitionBodyEntity _model = new FishEntity.SalesRequisitionBodyEntity();

            if (row != null)
            {
                if (row["NumberingOne"]!=null)
                {
                    _model.NumberingOne = row["NumberingOne"].ToString();
                }
                if (row["code"] != null)
                    _model.code = row["code"].ToString();
                if (row["product_id"] != null)
                    _model.product_id = row["product_id"].ToString();
                if (row["productname"] != null)
                    _model.productname = row["productname"].ToString();
                if (row["Funit"] != null)
                    _model.Funit = row["Funit"].ToString();
                if (row["Variety"] != null)
                    _model.Variety = row["Variety"].ToString();
                if (row["Quantity"] != null)
                    _model.Quantity = decimal.Parse(row["Quantity"].ToString());
                if (row["Amonut"]!=null&&row["Amonut"].ToString()!="")
                {
                    _model.Amonut=decimal.Parse(row["Amonut"].ToString());
                }
                if (row["unitprice"] != null)
                    _model.unitprice = decimal.Parse(row["unitprice"].ToString());
                if (row["db"] != null)
                    _model.db = row["db"].ToString();
                if (row["tvn"] != null)
                    _model.tvn = row["tvn"].ToString();
                if (row["za"] != null)
                    _model.za = row["za"].ToString();
                if (row["ffa"] != null)
                    _model.ffa = row["ffa"].ToString();
                if (row["zf"] != null)
                    _model.zf = row["zf"].ToString();
                if (row["sf"] != null)
                    _model.sf = row["sf"].ToString();
                if (row["shy"] != null)
                    _model.shy = row["shy"].ToString();
                if (row["sz"] != null)
                    _model.sz = row["sz"].ToString();
                if (row["cdb"] != null)
                    _model.cdb = row["cdb"].ToString();
                if (row["tvnOne"] != null)
                    _model.tvnOne = row["tvnOne"].ToString();
                if (row["hf"] != null)
                    _model.hf = row["hf"].ToString();
                if (row["cm"] != null)
                    _model.cm = row["cm"].ToString();
                if (row["tdh"] != null)
                {
                    _model.tdh = row["tdh"].ToString();
                }
                if (row["zjh"] != null)
                    _model.zjh = row["zjh"].ToString();
                if (row["pp"] != null)
                    _model.pp = row["pp"].ToString();
                if (row["Country"] != null)
                    _model.Country = row["Country"].ToString();
                if (row["zaOne"] != null)
                {
                    _model.ZaOne = row["zaOne"].ToString();
                }
                if (row["ffaOne"]!=null)
                {
                    _model.FfaOne = row["ffaOne"].ToString();
                }
                if (row["zfOne"]!=null)
                {
                    _model.ZfOne = row["zfOne"].ToString();
                }
                if (row["sfOne"]!=null)
                {
                    _model.SfOne = row["sfOne"].ToString();
                }
                if (row["shyOne"]!=null)
                {
                    _model.ShyOne = row["shyOne"].ToString();
                }
                if (row["szOne"]!=null)
                {
                    _model.SzOne = row["szOne"].ToString();
                }
                if ( row [ "codeNumZdi" ] != null )
                {
                    _model . CodeNumZdi = row [ "codeNumZdi" ] . ToString ( );
                }
                if ( row [ "codeNumHq" ] != null )
                {
                    _model . CodeNumHq = row [ "codeNumHq" ] . ToString ( );
                }
            }
            return _model;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="fishId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable getTable ( string fishId ,string code )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( " select a.code,a.country,a.brand,a.fishId,b.name,a.price,a.weight,a.protein,a.histamine,a.tvn,b.shipno,b.cornerno,b.billofgoods,b.domestic_protein,b.domestic_graypart,b.domestic_sandsalt,b.domestic_tvn,b.domestic_fat,b.domestic_amine from t_QuotationPriceList a left join t_product b on a.fishId=b.code " );
            strSql . AppendFormat ( "where a.code='{0}' and a.fishId='{1}'" ,code ,fishId );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

    }
}
