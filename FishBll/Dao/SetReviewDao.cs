using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FishBll.Dao
{
    public class SetReviewDao
    {
        /// <summary>
        /// 得到数据列表
        /// </summary>
        /// <returns></returns>
        public List<FishEntity.SetreviewEntity> getList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.userName,a.programId,level,b.realname,c.programName from t_setreview a left join t_user b on a.userName=b.userName left join t_program c on a.programId=c.programId ");

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            DataTable dt = ds.Tables[0];
            List<FishEntity.SetreviewEntity> modelList = new List<FishEntity.SetreviewEntity>();
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
        public FishEntity.ReviewEntity UserName(string Numbering) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select b.userName from t_salesorder a inner join t_review b on a.Numbering=b.Numbering where programId='FormSalesRContract'and state='提交' ");
            strSql.Append("and a.Numbering='" + Numbering + "'");
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                FishEntity.ReviewEntity model = new FishEntity.ReviewEntity(); DataRow row = ds.Tables[0].Rows[0];
                if (row != null)
                {
                    if (row["userName"] != null)
                    {
                        model.userName = row["userName"].ToString();
                    }
                }
                return model;
            }
            else { return null; }
        }
        public FishEntity.SetreviewEntity getModel(DataRow row)
        {
            FishEntity.SetreviewEntity model = new FishEntity.SetreviewEntity();

            if (row != null)
            {
                if (row["userName"] != null)
                    model.userName = row["userName"].ToString();
                if (row["programId"] != null)
                    model.programId = row["programId"].ToString();
                if (row["level"] != null)
                    model.level = bool.Parse(row["level"].ToString());
                if (row["realname"] != null)
                    model.Realname = row["realname"].ToString();
                if (row["programName"] != null)
                    model.ProgramName = row["programName"].ToString();
            }

            return model;

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_setreview");

            int row = MySqlHelper.ExecuteSql(strSql.ToString());
            if (row > 0)
                return true;
            else
                return false;
        }

        DateTime dt()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT now() t");

            DataSet da = MySqlHelper.Query(strSql.ToString());

            return Convert.ToDateTime(da.Tables[0].Rows[0]["t"].ToString());
        }

        /// <summary>
        /// 保存记录
        /// </summary>
        /// <param name="modelList"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool add(List<FishEntity.SetreviewEntity> modelList, string userName)
        {
            Hashtable SQLString = new Hashtable();
            StringBuilder strSql = new StringBuilder();

            foreach (FishEntity.SetreviewEntity list in modelList)
            {
                list.createTime = list.modifyTime = dt();
                list.createMan = list.modifyMan = userName;

                if (Exists(list.userName, list.programId) == true)
                    edit(list, SQLString, strSql);
                else
                    insert(list, SQLString, strSql);
            }

            DataTable tab = table();
            if (tab != null && tab.Rows.Count > 0)
            {
                FishEntity.SetreviewEntity list = new FishEntity.SetreviewEntity();
                string person = string.Empty, proId = string.Empty;
                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    person = tab.Rows[i]["userName"].ToString();
                    proId = tab.Rows[i]["programId"].ToString();
                    list = modelList.Find((k) =>
                {
                    return k.userName.Equals(person) && k.programId.Equals(proId);
                });

                    if (list == null)
                    {
                        del(person, proId, SQLString, strSql);
                    }

                }
            }

            return MySqlHelper.ExecuteSqlTran(SQLString);
        }

        public bool Exists(string userName, string programId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) coun from t_setreview ");
            strSql.Append("where userName=@userName and programId=@programId");
            MySqlParameter[] parameter = {
                new MySqlParameter("@userName",MySqlDbType.VarChar,45),
                new MySqlParameter("@programId",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = userName;
            parameter[1].Value = programId;

            return MySqlHelper.Exists(strSql.ToString(), parameter);
        }

        void edit(FishEntity.SetreviewEntity list, Hashtable SQLString, StringBuilder strSql)
        {
            strSql = new StringBuilder();
            strSql.Append("update t_setreview set ");
            strSql.Append("level=@level,");
            strSql.Append("modifyTime=@modifyTime,");
            strSql.Append("modifyMan=@modifyMan ");
            strSql.Append("where userName=@userName and ");
            strSql.Append("programId=@programId");
            MySqlParameter[] parameter = {
                new MySqlParameter("@userName",MySqlDbType.VarChar,45),
                new MySqlParameter("@programId",MySqlDbType.VarChar,45),
                new MySqlParameter("@level",MySqlDbType.Bit,1),
                new MySqlParameter("@modifyTime",MySqlDbType.DateTime),
                new MySqlParameter("@modifyMan",MySqlDbType.VarChar,45)
            };

            parameter[0].Value = list.userName;
            parameter[1].Value = list.programId;
            parameter[2].Value = list.level;
            parameter[3].Value = list.modifyTime;
            parameter[4].Value = list.modifyMan;

            SQLString.Add(strSql, parameter);

        }

        void insert(FishEntity.SetreviewEntity list, Hashtable SQLString, StringBuilder strSql)
        {
            strSql = new StringBuilder();
            strSql.Append("insert into t_setreview (");
            strSql.Append("userName,programId,level,createTime,createMan,modifyTime,modifyMan)");
            strSql.Append("values (");
            strSql.Append("@userName,@programId,@level,@createTime,@createMan,@modifyTime,@modifyMan)");
            MySqlParameter[] parameter = {
                new MySqlParameter("@userName",MySqlDbType.VarChar,45),
                new MySqlParameter("@programId",MySqlDbType.VarChar,45),
                new MySqlParameter("@level",MySqlDbType.Bit,1),
                new MySqlParameter("@createTime",MySqlDbType.DateTime),
                new MySqlParameter("@createMan",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifyTime",MySqlDbType.DateTime),
                new MySqlParameter("@modifyMan",MySqlDbType.VarChar,45)
            };

            parameter[0].Value = list.userName;
            parameter[1].Value = list.programId;
            parameter[2].Value = list.level;
            parameter[3].Value = list.createTime;
            parameter[4].Value = list.createMan;
            parameter[5].Value = list.modifyTime;
            parameter[6].Value = list.modifyMan;

            SQLString.Add(strSql, parameter);
        }

        DataTable table()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select userName,programId from t_setreview ");

            return MySqlHelper.Query(strSql.ToString()).Tables[0];
        }

        void del(string person, string proId, Hashtable SQLString, StringBuilder strSql)
        {
            strSql = new StringBuilder();
            strSql.Append("delete from t_setreview ");
            strSql.Append("where userName=@userName and ");
            strSql.Append("programId=@programId");
            MySqlParameter[] parameter = {
                new MySqlParameter("@userName",MySqlDbType.VarChar,45),
                new MySqlParameter("@programId",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = person;
            parameter[1].Value = proId;

            SQLString.Add(strSql, parameter);
        }
        public bool existStr1(string Numbering, string programId, string userName, string SingleNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select COUNT(1) from t_review where programId='{0}' and Numbering='{1}' and userName='{2}' and SingleNumber={3}", programId, Numbering, userName, SingleNumber);
            return MySqlHelper.Exists(strSql.ToString());
        }
        public bool existStr(string Numbering, string programId, string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select COUNT(1) from t_review where programId='{0}' and Numbering='{1}' and userName='{2}'", programId, Numbering, userName);

            return MySqlHelper.Exists(strSql.ToString());
        }
        public bool existStr1(string Numbering, string programId, string SingleNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select COUNT(1) from t_review where programId='{0}' and Numbering='{1}' and SingleNumber='{2}'", programId, Numbering, SingleNumber);

            return MySqlHelper.Exists(strSql.ToString());
        }
        public bool existtr(string Numbering, string programId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select COUNT(1) from t_review where programId='{0}' and Numbering='{1}' ", programId, Numbering);

            return MySqlHelper.Exists(strSql.ToString());
        }

        /// <summary>
        /// 送审
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Review(List<FishEntity.ReviewEntity> modelList)
        {
            StringBuilder strSql = new StringBuilder();
            Hashtable SQLString = new Hashtable();

            int x = modelList.Count;

            foreach (FishEntity.ReviewEntity model in modelList)
            {
                string s = model.userNameReview;
                if (model.state.Equals("驳回"))
                {
                    strSql.Append("SELECT a.userName FROM t_review a inner join (");
                    strSql.Append("SELECT MAX(date) date FROM t_review where programId=@programId and Numbering=@Numbering) b ");
                    strSql.Append("on a.date=b.date");
                    MySqlParameter[] paramete = {
                    new MySqlParameter("@programId",MySqlDbType.VarChar,45),
                    new MySqlParameter("@Numbering",MySqlDbType.VarChar,45)
                };
                    paramete[0].Value = model.programId;
                    paramete[1].Value = model.Numbering;

                    DataSet ds = MySqlHelper.Query(strSql.ToString(), paramete);
                    DataTable dt = ds.Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                        model.userNameReview = dt.Rows[0]["userName"].ToString();
                    else
                        model.userNameReview = string.Empty;
                }
                if (getStr1(model.Numbering, model.programId, model.userName, model.SingleNumber) == true)
                {
                    strSql = new StringBuilder();
                    model.date = model.createTime = model.modifyTime = dt();
                    strSql.Append("update t_review set ");
                    strSql.Append("userName = @userName,");
                    strSql.Append("code = @code,");
                    strSql.Append("date = @date,");
                    strSql.Append("content = @content,");
                    strSql.Append("state = @state,");
                    strSql.Append("userNameReview = @userNameReview,");
                    strSql.Append("modifyTime = @modifyTime,");
                    strSql.Append("modifyMan = @modifyMan ");
                    strSql.Append("where ");
                    strSql.Append("Numbering = @Numbering and programId = @programId and SingleNumber = @SingleNumber");
                    MySqlParameter[] parameter = {
                        new MySqlParameter("@userName",MySqlDbType.VarChar,45),
                        new MySqlParameter("@code",MySqlDbType.VarChar,45),
                        new MySqlParameter("@date",MySqlDbType.DateTime),
                        new MySqlParameter("@content",MySqlDbType.VarChar,45),
                        new MySqlParameter("@state",MySqlDbType.VarChar,45),
                        new MySqlParameter("@userNameReview",MySqlDbType.VarChar,45),
                        new MySqlParameter("@modifyTime",MySqlDbType.DateTime),
                        new MySqlParameter("@modifyMan",MySqlDbType.VarChar,45),
                        new MySqlParameter("@Numbering",MySqlDbType.VarChar,45),
                        new MySqlParameter("@programId",MySqlDbType.VarChar,45),
                        new MySqlParameter("@SingleNumber",MySqlDbType.VarChar,45)
                };
                    parameter[0].Value = model.userName;
                    parameter[1].Value = model.code;
                    parameter[2].Value = model.date;
                    parameter[3].Value = model.content;
                    parameter[4].Value = model.state;
                    parameter[5].Value = model.userNameReview;
                    parameter[6].Value = model.modifyTime;
                    parameter[7].Value = model.modifyMan;
                    parameter[8].Value = model.Numbering;
                    parameter[9].Value = model.programId;
                    parameter[10].Value = model.SingleNumber; SQLString.Add(strSql, parameter);
                }
                else if (getStr1(model.Numbering, model.programId, model.SingleNumber) == true)
                {
                    strSql = new StringBuilder();
                    model.date = model.createTime = model.modifyTime = dt();
                    strSql.Append("update t_review set ");
                    strSql.Append("userName = @userName,");
                    strSql.Append("code = @code,");
                    strSql.Append("date = @date,");
                    strSql.Append("content = @content,");
                    strSql.Append("state = @state,");
                    strSql.Append("userNameReview = @userNameReview,");
                    strSql.Append("modifyTime = @modifyTime,");
                    strSql.Append("modifyMan = @modifyMan ");
                    strSql.Append("where ");
                    strSql.Append("Numbering = @Numbering and programId = @programId and SingleNumber = @SingleNumber ");
                    MySqlParameter[] parameter = {
                        new MySqlParameter("@userName",MySqlDbType.VarChar,45),
                        new MySqlParameter("@code",MySqlDbType.VarChar,45),
                        new MySqlParameter("@date",MySqlDbType.DateTime),
                        new MySqlParameter("@content",MySqlDbType.VarChar,45),
                        new MySqlParameter("@state",MySqlDbType.VarChar,45),
                        new MySqlParameter("@userNameReview",MySqlDbType.VarChar,45),
                        new MySqlParameter("@modifyTime",MySqlDbType.DateTime),
                        new MySqlParameter("@modifyMan",MySqlDbType.VarChar,45),
                        new MySqlParameter("@Numbering",MySqlDbType.VarChar,45),
                        new MySqlParameter("@programId",MySqlDbType.VarChar,45),
                        new MySqlParameter("@SingleNumber",MySqlDbType.VarChar,45)
                };
                    parameter[0].Value = model.userName;
                    parameter[1].Value = model.code;
                    parameter[2].Value = model.date;
                    parameter[3].Value = model.content;
                    parameter[4].Value = model.state;
                    parameter[5].Value = model.userNameReview;
                    parameter[6].Value = model.modifyTime;
                    parameter[7].Value = model.modifyMan;
                    parameter[8].Value = model.Numbering;
                    parameter[9].Value = model.programId;
                    parameter[10].Value = model.SingleNumber; SQLString.Add(strSql, parameter);
                }
                else if (getStr(model.Numbering, model.programId, model.userName) == true)
                {
                    strSql = new StringBuilder();
                    model.date = model.createTime = model.modifyTime = dt();
                    strSql.Append("update t_review set ");
                    strSql.Append("userName = @userName,");
                    strSql.Append("code = @code,");
                    strSql.Append("date = @date,");
                    strSql.Append("content = @content,");
                    strSql.Append("state = @state,");
                    strSql.Append("userNameReview = @userNameReview,");
                    strSql.Append("modifyTime = @modifyTime,");
                    strSql.Append("modifyMan = @modifyMan,");
                    strSql.Append("SingleNumber = @SingleNumber ");
                    strSql.Append("where ");
                    strSql.Append("Numbering = @Numbering and programId = @programId and SingleNumber='' ORDER BY id DESC LIMIT 1");
                    MySqlParameter[] parameter = {
                        new MySqlParameter("@userName",MySqlDbType.VarChar,45),
                        new MySqlParameter("@code",MySqlDbType.VarChar,45),
                        new MySqlParameter("@date",MySqlDbType.DateTime),
                        new MySqlParameter("@content",MySqlDbType.VarChar,45),
                        new MySqlParameter("@state",MySqlDbType.VarChar,45),
                        new MySqlParameter("@userNameReview",MySqlDbType.VarChar,45),
                        new MySqlParameter("@modifyTime",MySqlDbType.DateTime),
                        new MySqlParameter("@modifyMan",MySqlDbType.VarChar,45),
                        new MySqlParameter("@Numbering",MySqlDbType.VarChar,45),
                        new MySqlParameter("@programId",MySqlDbType.VarChar,45),
                        new MySqlParameter("@SingleNumber",MySqlDbType.VarChar,45)
                };
                    parameter[0].Value = model.userName;
                    parameter[1].Value = model.code;
                    parameter[2].Value = model.date;
                    parameter[3].Value = model.content;
                    parameter[4].Value = model.state;
                    parameter[5].Value = model.userNameReview;
                    parameter[6].Value = model.modifyTime;
                    parameter[7].Value = model.modifyMan;
                    parameter[8].Value = model.Numbering;
                    parameter[9].Value = model.programId;
                    parameter[10].Value = model.SingleNumber; SQLString.Add(strSql, parameter);
                }
                else if (getStr(model.Numbering, model.programId) == true)
                {
                    strSql = new StringBuilder();
                    model.date = model.createTime = model.modifyTime = dt();
                    strSql.Append("update t_review set ");
                    strSql.Append("userName = @userName,");
                    strSql.Append("code = @code,");
                    strSql.Append("date = @date,");
                    strSql.Append("content = @content,");
                    strSql.Append("state = @state,");
                    strSql.Append("userNameReview = @userNameReview,");
                    strSql.Append("modifyTime = @modifyTime,");
                    strSql.Append("modifyMan = @modifyMan,");
                    strSql.Append("SingleNumber = @SingleNumber");
                    strSql.Append("where ");
                    strSql.Append("Numbering = @Numbering and programId = @programId and SingleNumber='' ORDER BY id DESC LIMIT 1");
                    MySqlParameter[] parameter = {
                        new MySqlParameter("@userName",MySqlDbType.VarChar,45),
                        new MySqlParameter("@code",MySqlDbType.VarChar,45),
                        new MySqlParameter("@date",MySqlDbType.DateTime),
                        new MySqlParameter("@content",MySqlDbType.VarChar,45),
                        new MySqlParameter("@state",MySqlDbType.VarChar,45),
                        new MySqlParameter("@userNameReview",MySqlDbType.VarChar,45),
                        new MySqlParameter("@modifyTime",MySqlDbType.DateTime),
                        new MySqlParameter("@modifyMan",MySqlDbType.VarChar,45),
                        new MySqlParameter("@Numbering",MySqlDbType.VarChar,45),
                        new MySqlParameter("@programId",MySqlDbType.VarChar,45),
                        new MySqlParameter("@SingleNumber",MySqlDbType.VarChar,45)
                };
                    parameter[0].Value = model.userName;
                    parameter[1].Value = model.code;
                    parameter[2].Value = model.date;
                    parameter[3].Value = model.content;
                    parameter[4].Value = model.state;
                    parameter[5].Value = model.userNameReview;
                    parameter[6].Value = model.modifyTime;
                    parameter[7].Value = model.modifyMan;
                    parameter[8].Value = model.Numbering;
                    parameter[9].Value = model.programId;
                    parameter[10].Value = model.SingleNumber; SQLString.Add(strSql, parameter);
                }
                else {
                    strSql = new StringBuilder();
                    model.date = model.createTime = model.modifyTime = dt();
                    strSql.Append("insert into t_review (");
                    strSql.Append("userName,programId,code,Numbering,date,content,state,userNameReview,createTime,createMan,modifyTime,modifyMan,SingleNumber) ");
                    strSql.Append("values (");
                    strSql.Append("@userName,@programId,@code,@Numbering,@date,@content,@state,@userNameReview,@createTime,@createMan,@modifyTime,@modifyMan,@SingleNumber) ");
                    MySqlParameter[] parameter = {
                new MySqlParameter("@userName",MySqlDbType.VarChar,45),
                new MySqlParameter("@programId",MySqlDbType.VarChar,45),
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@date",MySqlDbType.DateTime),
                new MySqlParameter("@content",MySqlDbType.VarChar,45),
                new MySqlParameter("@state",MySqlDbType.VarChar,45),
                new MySqlParameter("@userNameReview",MySqlDbType.VarChar,45),
                new MySqlParameter("@createTime",MySqlDbType.DateTime),
                new MySqlParameter("@createMan",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifyTime",MySqlDbType.DateTime),
                new MySqlParameter("@modifyMan",MySqlDbType.VarChar,45),
                new MySqlParameter("@Numbering",MySqlDbType.VarChar,45),
                new MySqlParameter("@SingleNumber",MySqlDbType.VarChar,45)
            };
                    parameter[0].Value = model.userName;
                    parameter[1].Value = model.programId;
                    parameter[2].Value = model.code;
                    parameter[3].Value = model.date;
                    parameter[4].Value = model.content;
                    parameter[5].Value = model.state;
                    parameter[6].Value = model.userNameReview;
                    parameter[7].Value = model.createTime;
                    parameter[8].Value = model.createMan;
                    parameter[9].Value = model.modifyTime;
                    parameter[10].Value = model.modifyMan;
                    parameter[11].Value = model.Numbering;
                    parameter[12].Value = model.SingleNumber;
                    SQLString.Add(strSql, parameter);
                }
            }
            return MySqlHelper.ExecuteSqlTran(SQLString);
        }

        /// <summary> n
        /// 获取提醒消息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public List<FishEntity.ReviewEntity> modelList(string userName, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT distinct a.userName,c.realname,a.programId,d.programName,a.SingleNumber,a.Numbering,a.date,a.content,a.state FROM t_review a inner join (");
            strSql.AppendFormat("SELECT  date FROM t_review where userNameReview='{0}' and state!='审核' ) b ", userName);
            //strSql . AppendFormat ( "SELECT  date FROM t_review where  state!='审核' ) b " ,userName );
            strSql .AppendFormat("on a.date=b.date left join t_user c on a.userName=c.username left join t_program d on a.programId=d.programId {0}", strWhere);
            //strSql . AppendFormat ( "on a.date=b.date left join t_user c on a.userName=c.username left join t_program d on a.programId=d.programId " ,strWhere );

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            DataTable dt = ds.Tables[0];
            List<FishEntity.ReviewEntity> modelList = new List<FishEntity.ReviewEntity>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(getM(dt.Rows[i]));
                }
                return modelList;
            }
            else
                return null;
        }

        public FishEntity.ReviewEntity getM(DataRow row)
        {
            FishEntity.ReviewEntity model = new FishEntity.ReviewEntity();

            if (row != null)
            {
                if (row["userName"] != null)
                    model.userName = row["userName"].ToString();
                if (row["realname"] != null)
                    model.realName = row["realName"].ToString();
                if (row["programId"] != null)
                    model.programId = row["programId"].ToString();
                if (row["programName"] != null)
                    model.programName = row["programName"].ToString();
                if (row["SingleNumber"] != null)
                    model.SingleNumber = row["SingleNumber"].ToString();
                if (row["date"] != null && row["date"].ToString() != "")
                    model.date = DateTime.Parse(row["date"].ToString());
                if (row["content"] != null)
                    model.content = row["content"].ToString();
                if (row["state"] != null)
                    model.state = row["state"].ToString();
                if (row["Numbering"] != null)
                {
                    model.Numbering = row["Numbering"].ToString();
                }
            }

            return model;
        }

        /// <summary>
        /// 是否审核
        /// </summary>
        /// <param name="Numbering"></param>
        /// <param name="programId"></param>
        /// <returns></returns>
        public bool getStr1(string Numbering, string programId, string userName, string SingleNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select COUNT(1) from t_review where programId='{0}' and Numbering='{1}' and state='审核' and userName='{2}' and SingleNumber='{3}'", programId, Numbering, userName, SingleNumber);
            return MySqlHelper.Exists(strSql.ToString());
        }
        public bool getStr(string Numbering, string programId, string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select COUNT(1) from t_review where programId='{0}' and Numbering='{1}' and state='审核' and userName='{2}' and SingleNumber=''", programId, Numbering, userName);
            return MySqlHelper.Exists(strSql.ToString());
        }
        public bool getStr1(string Numbering, string programId, string SingleNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select COUNT(1) from t_review where programId='{0}' and Numbering='{1}' and state='审核' and SingleNumber='{2}'", programId, Numbering, SingleNumber);
            return MySqlHelper.Exists(strSql.ToString());
        }
        public bool getStr(string Numbering, string programId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select COUNT(1) from t_review where programId='{0}' and Numbering='{1}' and state='审核' and SingleNumber=''", programId, Numbering);

            return MySqlHelper.Exists(strSql.ToString());
        }
        /// <summary>
        /// 撤审
        /// </summary>
        /// <param name="Numbering"></param>
        /// <param name="programId"></param>
        /// <returns></returns>
        public bool examine(string Numbering, string programId, string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_review ");
            strSql.AppendFormat("where programId='{0}' and Numbering='{1}' and state='审核' and userName='{2}'", programId, Numbering, userName);

            int row = MySqlHelper.ExecuteSql(strSql.ToString());
            if (row > 0)
                return true;
            else
                return false;
        }
        public bool examine_1(string Numbering, string programId, string userName, string SingleNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_review ");
            strSql.AppendFormat("where programId='{0}' and Numbering='{1}' and state='审核' and userName='{2}' and SingleNumber='{3}'", programId, Numbering, userName, SingleNumber);

            int row = MySqlHelper.ExecuteSql(strSql.ToString());
            if (row > 0)
                return true;
            else
                return false;
        }
        public bool examine(string Numbering, string programId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_review ");
            strSql.AppendFormat("where programId='{0}' and Numbering='{1}' and state='审核'", programId, Numbering);

            int row = MySqlHelper.ExecuteSql(strSql.ToString());
            if (row > 0)
                return true;
            else
                return false;
        }
        public bool examine_1(string Numbering, string programId, string SingleNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_review ");
            strSql.AppendFormat("where programId='{0}' and Numbering='{1}' and state='审核' and SingleNumber='{2}'", programId, Numbering, SingleNumber);

            int row = MySqlHelper.ExecuteSql(strSql.ToString());
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否有审核权限
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="programId"></param>
        /// <returns></returns>
        public bool examinePow(string userName, string programId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select level from t_setreview   ");
            strSql.AppendFormat("where programId='{0}' and userName='{1}'", programId, userName);

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            DataTable dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(dt.Rows[0]["level"].ToString()))
                    return false;
                else
                {
                    return bool.Parse(dt.Rows[0]["level"].ToString());
                }
            }
            else
                return false;
        }

    }
}
