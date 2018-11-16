using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace FishBll.Dao
{
    public class ProductExDaoEx :ProductExDao
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productid"></param>
        /// <param name="weight"></param>
        /// <param name="quantity"></param>
        /// <param name="selfPrice"></param>
        /// <param name="salePrice"></param>
        public bool UpdateHomeMadeInfo(int productid, decimal storageWeight, int storageQuantity, decimal selfPrice, decimal salePrice , string  storageTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_productex set selfstorageweight= selfstorageweight+@weight, selfstoragequantity = selfstoragequantity+ @quantity , selfrmb=@selfprice , salermb=@saleprice, selfstoragedate=@storagetime where id=@id ");
            MySqlParameter[] parameters ={
                    new MySqlParameter("@weight",MySqlDbType.Decimal , 8),
                    new MySqlParameter("@quantity",MySqlDbType.Int32 , 6),
                    new MySqlParameter("@selfprice",MySqlDbType.Decimal,8) ,
                    new MySqlParameter("@saleprice",MySqlDbType.Decimal,8),
                    new MySqlParameter("@storagetime",MySqlDbType.VarChar,45),
                    new MySqlParameter("@id",MySqlDbType.Int32,6)
                                        };
            parameters[0].Value = storageWeight;
            parameters[1].Value = storageQuantity;
            parameters[2].Value = selfPrice;
            parameters[3].Value = salePrice;
            parameters[4].Value = storageTime;
            parameters[5].Value = productid;

            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0 ? true : false;
        }
       
        public bool UpdateHomeMadeInfo(int productid, decimal storageWeight, int storageQuantity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_productex set selfstorageweight= selfstorageweight+@weight, selfstoragequantity = selfstoragequantity+ @quantity where id=@id ");
            MySqlParameter[] parameters ={
                    new MySqlParameter("@weight",MySqlDbType.Decimal , 8),
                    new MySqlParameter("@quantity",MySqlDbType.Int32 , 6),
                    new MySqlParameter("@id",MySqlDbType.Int32,6)
                                        };
            parameters[0].Value = storageWeight;
            parameters[1].Value = storageQuantity;
            parameters[2].Value = productid;

            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0 ? true : false;
        }


        public bool UpdateFoodOutInfo(FishEntity.FoodOutDetailEntityVO model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update t_productex set");
            strSql.Append(" salermb=@salermb,");
            strSql.Append(" selfrmb=@selfrmb");
            strSql.Append(" where id=@id");

            MySqlParameter[] parameters = {
                    new MySqlParameter("@salermb", MySqlDbType.Decimal,6),
					new MySqlParameter("@selfrmb", MySqlDbType.Decimal,8),
					new MySqlParameter("@id", MySqlDbType.Int32,6)
                                           };

            parameters[0].Value = model.salermb;
            parameters[1].Value = model.selfrmb;
            parameters[2].Value = model.productid;

            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0 ? true : false;
        }

        public bool UpdateSaleInfo(int productid, decimal weight, int quantity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_productex set saleremainweight= saleremainweight+@weight, saleremainquantity = saleremainquantity+ @quantity where id=@id ");
            MySqlParameter[] parameters ={
                    new MySqlParameter("@weight",MySqlDbType.Decimal , 8),
                    new MySqlParameter("@quantity",MySqlDbType.Int32 , 6),
                    new MySqlParameter("@id",MySqlDbType.Int32,6)
                                        };
            parameters[0].Value = weight;
            parameters[1].Value = quantity;
            parameters[2].Value = productid;

            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0 ? true : false;
        }
    }
}
