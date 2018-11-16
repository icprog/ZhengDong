using System;
using System . Collections . Generic;
using System . Data;
using MySql . Data . MySqlClient;
using System . Text;

namespace FishBll . Dao
{
    public class InquiryDao
    {
        public InquiryDao ( )
        {
            
        }
        
        /// <summary>
        /// 获取鱼粉ID
        /// </summary>
        /// <returns></returns>
        public DataTable GetFishId ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT code FROM t_product" );

            DataSet RData = MySqlHelper . Query ( strSql . ToString ( ) );

            return RData . Tables [ 0 ];
        }

        /// <summary>
        /// 获取一个实体对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public FishEntity . InquiryEntity GetRowToModel ( DataRow row)
        {
            FishEntity . InquiryEntity _model = new FishEntity . InquiryEntity ( );

            if ( row != null )
            {
                if ( row [ "id" ] != null && row [ "id" ] . ToString ( ) != "" )
                    _model . ID = int . Parse ( row [ "id" ] . ToString ( ) );
                if ( row [ "code" ] != null && row [ "code" ] . ToString ( ) != "" )
                    _model . Code = row [ "code" ] . ToString ( );
                if ( row [ "weight" ] != null && row [ "weight" ] . ToString ( ) != "" )
                    _model . Weight = decimal . Parse ( row [ "weight" ] . ToString ( ) );
                if ( row [ "number" ] != null && row [ "number" ] . ToString ( ) != "" )
                    _model . Number = int . Parse ( row [ "number" ] . ToString ( ) );
                if ( row [ "remark" ] != null && row [ "remark" ] . ToString ( ) != "" )
                    _model . Remark = row [ "remark" ] . ToString ( );
                if ( row [ "exchangerate" ] != null && row [ "exchangerate" ] . ToString ( ) != "" )
                    _model . Exchangerate = decimal . Parse ( row [ "exchangerate" ] . ToString ( ) );
                if ( row [ "rmb" ] != null && row [ "rmb" ] . ToString ( ) != "" )
                    _model . Rmb = decimal . Parse ( row [ "rmb" ] . ToString ( ) );
                if ( row [ "dollarprice" ] != null && row [ "dollarprice" ] . ToString ( ) != "" )
                    _model . Dollarprice = decimal . Parse ( row [ "dollarprice" ] . ToString ( ) );
                if ( row [ "datetime" ] != null && row [ "datetime" ] . ToString ( ) != "" )
                    _model . Datetime = DateTime . Parse ( row [ "datetime" ] . ToString ( ) );
            }

            return _model;
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int Add ( FishEntity . InquiryEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO t_inquiry (" );
            strSql . Append ( "code,weight,number,remark,exchangerate,rmb,dollarprice,datetime)" );
            strSql . Append ( " VALUES (" );
            strSql . Append ( "@code,@weight,@number,@remark,@exchangerate,@rmb,@dollarprice,@datetime);" );
            strSql . Append ( "select last_insert_id();" );
            MySqlParameter [ ] parameter = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@weight",MySqlDbType.Decimal,11),
                new MySqlParameter("@number",MySqlDbType.Int32 ,11),
                new MySqlParameter("@remark",MySqlDbType.VarChar,500),
                new MySqlParameter("@exchangerate",MySqlDbType.Decimal,11),
                new MySqlParameter("@rmb",MySqlDbType.Decimal,11),
                new MySqlParameter("@dollarprice",MySqlDbType.Decimal,11),
                new MySqlParameter("@datetime",MySqlDbType.DateTime)
            };
            parameter [ 0 ] . Value = _model . Code;
            parameter [ 1 ] . Value = _model . Weight;
            parameter [ 2 ] . Value = _model . Number;
            parameter [ 3 ] . Value = _model . Remark;
            parameter [ 4 ] . Value = _model . Exchangerate;
            parameter [ 5 ] . Value = _model . Rmb;
            parameter [ 6 ] . Value = _model . Dollarprice;
            parameter [ 7 ] . Value = _model . Datetime;

            int id = MySqlHelper . ExecuteSqlReturnId ( strSql . ToString ( ) ,parameter );
            return id;
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Update ( FishEntity . InquiryEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE t_inquiry SET " );
            strSql . Append ( "code=@code," );
            strSql . Append ( "weight=@weight," );
            strSql . Append ( "number=@number," );
            strSql . Append ( "remark=@remark," );
            strSql . Append ( "exchangerate=@exchangerate," );
            strSql . Append ( "rmb=@rmb," );
            strSql . Append ( "dollarprice=@dollarprice," );
            strSql . Append ( "datetime=@datetime" );
            strSql . Append ( " WHERE id=@id" );
            MySqlParameter [ ] parameter = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@weight",MySqlDbType.Decimal,11),
                new MySqlParameter("@number",MySqlDbType.Int32,11),
                new MySqlParameter("@remark",MySqlDbType.VarChar,500),
                new MySqlParameter("@exchangerate",MySqlDbType.Decimal,11),
                new MySqlParameter("@rmb",MySqlDbType.Decimal,11),
                new MySqlParameter("@dollarprice",MySqlDbType.Decimal,11),
                new MySqlParameter("@datetime",MySqlDbType.DateTime),
                new MySqlParameter("@id",MySqlDbType.Int32,11)
            };
            parameter [ 0 ] . Value = _model . Code;
            parameter [ 1 ] . Value = _model . Weight;
            parameter [ 2 ] . Value = _model . Number;
            parameter [ 3 ] . Value = _model . Remark;
            parameter [ 4 ] . Value = _model . Exchangerate;
            parameter [ 5 ] . Value = _model . Rmb;
            parameter [ 6 ] . Value = _model . Dollarprice;
            parameter [ 7 ] . Value = _model . Datetime;
            parameter [ 8 ] . Value = _model . ID;

            int row = MySqlHelper . ExecuteSql ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool Delete ( string ids )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM t_inquiry" );
            strSql . Append ( " WHERE id IN (" + ids + ")" );

            int row = MySqlHelper . ExecuteSql ( strSql . ToString ( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT id,code,weight,number,remark,exchangerate,rmb,dollarprice,datetime FROM t_inquiry" );
            if ( strWhere . Trim ( ) != "" )
                strSql . Append ( " WHERE " + strWhere );

            return MySqlHelper . Query ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否存在此鱼粉ID
        /// </summary>
        /// <param name="fishId"></param>
        /// <returns></returns>
        public bool Exists ( string fishId )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT count(1) coun  FROM t_product" );
            strSql . Append ( " WHERE code=@code" );
            MySqlParameter [ ] parameter = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45)
            };
            parameter [ 0 ] . Value = fishId;

            return MySqlHelper . Exists ( strSql . ToString ( ) ,parameter );
        }
    }
}
