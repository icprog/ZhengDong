using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll
{
    public static class ReviewInfo
    {
        /// <summary>
        /// 自动审核
        /// </summary>
        /// <param name="programId">程序名称</param>
        /// <param name="SingleNumber">单号</param>
        /// <param name="content">送审意见</param>
        /// <param name="code">流程编号</param>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        public static Hashtable getSQLString ( string programId ,string SingleNumber, string content ,Hashtable SQLString)
        {
            SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ("select count(1) from t_review where programId='{0}' and SingleNumber='{1}' and date=(select max(date) from  t_review where programId='{0}' and SingleNumber='{1}') and state='审核' ", programId , SingleNumber);
            if ( MySqlHelper . Exists ( strSql . ToString ( ) ) == false )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "select examinUser from t_deliveredmanagement where tablePro='{0}'" ,programId );
                DataTable dt = MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    string reName = dt . Rows [ 0 ] [ "examinUser" ] . ToString ( );
                    if ( !string . IsNullOrEmpty ( reName ) )
                    {
                        if ( reName . Contains ( "|" ) )
                        {
                            string [ ] codes = reName . Split ( '|' );
                            for ( int i = 0 ; i < codes . Length ; i++ )
                            {
                                reName = codes [ i ] . Split ( ' ' ) [ 0 ];
                                SQLString . Add (  reviewEx ( programId , SingleNumber, content ,reName) ,null );
                            }
                        }
                        else
                        {
                            reName = reName . Split ( ' ' ) [ 0 ];
                            SQLString . Add (  reviewEx ( programId , SingleNumber, content ,reName) ,null );
                        }
                    }
                }
            }

            return SQLString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="programId"></param>
        /// <param name="SingleNumber"></param>
        /// <param name="content"></param>
        /// <param name="reviewName"></param>
        /// <returns></returns>
        public static string reviewEx ( string programId,string SingleNumber, string content,string reviewName)
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ("insert into t_review (userName,programId,SingleNumber,date,content,state,userNameReview) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", FishEntity . Variable . User . username ,programId , SingleNumber, DateTime . Now ,content ,"审核" ,reviewName);
            //strSql . AppendFormat ("insert into t_review (userName,programId,SingleNumber,date,content,state,userNameReview,Numbering) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7})", FishEntity . Variable . User . username ,programId , SingleNumber, DateTime . Now ,content ,"审核" ,reviewName, Numbering);

            return strSql . ToString ( );
        }

    }
}
