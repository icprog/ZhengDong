using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FishBll.Dao
{
    public class ProcessStateDo
    {

        /// <summary>
        /// 获取销售申请单的合同编号
        /// </summary>
        /// <returns></returns>
        public DataTable getCode()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT '' code from t_salesorder UNION select DISTINCT code from t_salesorder order by code");

            return MySqlHelper.Query(strSql.ToString()).Tables[0];
        }
        public DataTable getNumbering()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT '' Numbering from t_salesorder UNION select DISTINCT Numbering from t_salesorder order by Numbering");

            return MySqlHelper.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="Numbering"></param>
        /// <returns></returns>
        public bool Exists(string Numbering)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_processState ");
            strSql.AppendFormat("where Numbering='{0}'", Numbering);
            return MySqlHelper.Exists(strSql.ToString());
        }

        /// <summary>
        /// 销售申请单
        /// </summary>
        /// <param name="Numbering"></param>
        /// <returns></returns>
        public bool GetFormSalesRequisition(string Numbering)
        {
            FishEntity.ProcessStateEntity _list = new FishEntity.ProcessStateEntity();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_review where programId='FormSalesRequisition' and state='审核' ");
            strSql.AppendFormat(" and Numbering='{0}'", Numbering);

            if (MySqlHelper.Exists(strSql.ToString()) == true)
                _list.xssqExBool = true;
            else
                _list.xssqExBool = false;

            strSql = new StringBuilder();
            if (Exists(Numbering) == true)
            {
                strSql.AppendFormat("UPDATE t_processState SET xssqBool={0},xssqExBool={1} WHERE Numbering='{2}'", true, _list.xssqExBool, Numbering);
            }
            else
            {
                strSql.AppendFormat("INSERT INTO  t_processState (Numbering,xssqBool,xssqExBool,protime) VALUES ('{0}',{1},{2},now())", Numbering, true, _list.xssqExBool);

            }

            int row = MySqlHelper.ExecuteSql(strSql.ToString());
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 销售合同
        /// </summary>
        /// <param name="Numbering"></param>
        /// <returns></returns>
        public bool GetFormSalesRContract(string Numbering)
        {
            FishEntity.ProcessStateEntity _list = new FishEntity.ProcessStateEntity();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_review where programId='FormSalesRequisition' and state='审核' ");
            strSql.AppendFormat(" and Numbering='{0}'", Numbering);
            if (MySqlHelper.Exists(strSql.ToString()) == true)
                _list.xshtBool = true;
            else
                _list.xshtBool = false;

            strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from t_review where programId='FormSalesRContract' and state='审核' and Numbering='{0}'", Numbering);

            if (MySqlHelper.Exists(strSql.ToString()) == true)
                _list.xshtExBool = true;
            else
                _list.xshtExBool = false;

            strSql = new StringBuilder();
            if (Exists(Numbering) == true)
            {
                strSql.AppendFormat("UPDATE t_processState SET xshtBool={0},xshtExBool={1} WHERE Numbering='{2}'", _list.xshtBool, _list.xshtExBool, Numbering);
            }
            else
            {
                strSql.AppendFormat("INSERT INTO  t_processState (Numbering,xshtBool,xshtExBool) VALUES ('{0}',{1},{2})", Numbering, _list.xshtBool, _list.xshtExBool);
            }

            int row = MySqlHelper.ExecuteSql(strSql.ToString());
            if (row > 0)
                return true;
            else
                return false;

        }

        /// <summary>
        /// 付款申请单
        /// </summary>
        /// <param name="Numbering"></param>
        /// <returns></returns>
        public bool GetFormPaymentRequisition(string Numbering)
        {
            FishEntity.ProcessStateEntity _list = new FishEntity.ProcessStateEntity();

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*) from t_paymentrequisition where Numbering='" + Numbering + "'and(select SUM(weight)from t_paymentrequisition where Numbering='" + Numbering + "')=(select Quantity from t_happening where NumberingOne='" + Numbering + "')");

            if (MySqlHelper.Exists(strSql.ToString()) == true)
            {
                _list.fksqBool = '1';
            }
            else {
                strSql = new StringBuilder();
                strSql.AppendFormat("select count(1) from t_paymentrequisition where weight='0.00' and Numbering='{0}'", Numbering);
                if (MySqlHelper.Exists(strSql.ToString()) == true)
                {
                    _list.fksqBool = '3';
                }
                else {
                    strSql = new StringBuilder();
                    strSql.AppendFormat("select count(1) from t_paymentrequisition where Numbering='{0}'", Numbering);
                    if (MySqlHelper.Exists(strSql.ToString()) == true)
                    {
                        _list.fksqBool = '2';
                    }
                    else {
                        _list.fksqBool = '0';
                    }
                }
            }
            strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from t_review where programId='FormPaymentRequisition' and state='审核' and Numbering='{0}'", Numbering);

            if (MySqlHelper.Exists(strSql.ToString()) == true)
                _list.fksqExBool = true;
            else
                _list.fksqExBool = false;

            strSql = new StringBuilder();
            if (Exists(Numbering) == true)
            {
                strSql.AppendFormat("UPDATE t_processState SET fksqBool={0},fksqExBool={1} WHERE Numbering='{2}'", _list.fksqBool, _list.fksqExBool, Numbering);
            }
            else
            {
                strSql.AppendFormat("INSERT INTO  t_processState (Numbering,fksqBool,fksqExBool) VALUES ('{0}',{1},{2})", Numbering, _list.fksqBool, _list.fksqExBool);
            }

            int row = MySqlHelper.ExecuteSql(strSql.ToString());
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 提货单
        /// </summary>
        /// <param name="Numbering"></param>
        /// <returns></returns>
        public bool GetFormBilloflading(string Numbering)
        {
            FishEntity.ProcessStateEntity _list = new FishEntity.ProcessStateEntity();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from t_billoflading where Numbering='" + Numbering + "'and(select sum(Ton) from t_billoflading where Numbering='" + Numbering + "')=(select Quantity from t_happening where NumberingOne='" + Numbering + "')and ton!=''");
            if (MySqlHelper.Exists(strSql.ToString()) == true)
            {
                _list.thdBool = '1';
            }
            else {
                strSql = new StringBuilder();
                strSql.Append("select count(*) from t_billoflading where Numbering='" + Numbering + "'");
                if (MySqlHelper.Exists(strSql.ToString()) == true)
                {
                    _list.thdBool = '2';
                }
                else {
                    _list.thdBool = '0';
                }
            }
            strSql = new StringBuilder();
            if (Exists(Numbering) == true)
            {
                strSql.AppendFormat("UPDATE t_processState SET thdBool={0} WHERE Numbering='{1}'", _list.thdBool, Numbering);
            }
            else
            {
                strSql.AppendFormat("INSERT INTO  t_processState (Numbering,thdBool) VALUES ('{0}',{1},'{2}')", Numbering, _list.thdBool);
            }

            int row = MySqlHelper.ExecuteSql(strSql.ToString());
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 磅单
        /// </summary>
        /// <param name="Numbering></param>
        /// <returns></returns>
        public bool GetFormOnepound(string Numbering)
        {
            FishEntity.ProcessStateEntity _list = new FishEntity.ProcessStateEntity();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from t_poundsalone where Numbering='" + Numbering + "'and(select sum(Competition) from t_poundsalone where Numbering='" + Numbering + "')=(select Sum(ton) from t_billoflading where Numbering='" + Numbering + "')");
            if (MySqlHelper.Exists(strSql.ToString()) == true)
            {
                _list.bdBool = '1';
            }
            else {
                strSql = new StringBuilder();
                strSql.Append("select count(*) from t_poundsalone where Numbering='" + Numbering + "'");
                if (MySqlHelper.Exists(strSql.ToString()) == true)
                {
                    _list.bdBool = '2';
                }
                else {
                    _list.bdBool = '0';
                }
            }
            strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from t_review where programId='FormOnepound' and state='审核' and Numbering='{0}'", Numbering);

            if (MySqlHelper.Exists(strSql.ToString()) == true)
                _list.bdExBool = true;
            else
                _list.bdExBool = false;

            strSql = new StringBuilder();
            if (Exists(Numbering) == true)
            {
                strSql.AppendFormat("UPDATE t_processState SET bdBool={0},bdExBool={1}  WHERE Numbering='{2}'", _list.bdBool, _list.bdExBool, Numbering);
            }
            else
            {
                strSql.AppendFormat("INSERT INTO  t_processState (Numbering,bdBool,bdExBool) VALUES ('{0}',{1},{2})", Numbering, _list.bdBool, _list.bdExBool);
            }

            int row = MySqlHelper.ExecuteSql(strSql.ToString());
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 货物反馈单
        /// </summary>
        /// <param name="Numbering"></param>
        /// <returns></returns> 
        public bool GetFormCargoFeedbackSheet(string Numbering)
        {
            FishEntity.ProcessStateEntity _list = new FishEntity.ProcessStateEntity();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from t_CargoFeedbackSheet where Numbering='" + Numbering + "'and(select sum(ConfirmTheWeight) from t_CargoFeedbackSheet where Numbering='" + Numbering + "')=(select sum(Competition) from t_poundsalone where Numbering='" + Numbering + "')");
            
            if (MySqlHelper.Exists(strSql.ToString()) == true)
            {
                _list.hwfkBool = '1';
                //if (TableExists(Numbering, "FormCargoFeedbackSheet") == true)
                //{
                //    SHUpdate("FormCargoFeedbackSheet",Numbering);
                //}
                //else
                //{
                //    SHAdd("FormCargoFeedbackSheet", Numbering);
                //}
            }
            else {
                strSql = new StringBuilder();
                strSql.Append("select count(*) from t_CargoFeedbackSheet where Numbering='" + Numbering + "'");
                if (MySqlHelper.Exists(strSql.ToString()) == true)
                {
                    _list.hwfkBool = '2';
                }
                else {
                    _list.hwfkBool = '0';
                }
            }

            strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from t_review where programId='FormCargoFeedbackSheet' and state='审核' and Numbering='{0}'", Numbering);
            if (MySqlHelper.Exists(strSql.ToString()) == true)
                _list.hwfkExBool = true;
            else
                _list.hwfkExBool = false;
            strSql = new StringBuilder();
            if (Exists(Numbering) == true)
            {
                strSql.AppendFormat("UPDATE t_processState SET hwfkBool={0},hwfkExBool={1} WHERE Numbering='{2}'", _list.hwfkBool, _list.hwfkExBool, Numbering);
            }
            else
            {
                strSql.AppendFormat("INSERT INTO  t_processState (Numbering,hwfkBool,hwfkExBool) VALUES ('{0}',{1},{2},'{3}')", Numbering, _list.hwfkBool, _list.hwfkExBool);
            }

            int row = MySqlHelper.ExecuteSql(strSql.ToString());
            if (row > 0)
                return true;
            else
                return false;
        }
        
        /// <summary>
        /// 问题反馈单
        /// <param name="Numbering"></param>
        /// <returns></returns>
        public bool GetFormTheproblemsheet(string Numbering)
        {
            FishEntity.ProcessStateEntity _list = new FishEntity.ProcessStateEntity();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from t_theproblemsheet where Numbering='" + Numbering + "' and Chargeback!=0 ");
            if (MySqlHelper.Exists(strSql.ToString()) == true)
            {
                _list.wtfkBool = '2';
            }
            else {
                strSql = new StringBuilder();
                strSql.Append("select count(*) from t_theproblemsheet where Numbering='" + Numbering + "' and Chargeback=0 ");
                if (MySqlHelper.Exists(strSql.ToString()) == true)
                {
                    _list.wtfkBool = '1';
                    if (TableExists(Numbering, "FormTheproblemsheet") == true)
                    {
                        SHUpdate("FormTheproblemsheet", Numbering);
                    }
                    else
                    {
                        SHAdd("FormTheproblemsheet", Numbering);
                    }
                }
                else
                {
                    _list.wtfkBool = '0';
                }
            }
            strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from t_review where programId='FormTheproblemsheet' and state='审核' and Numbering='{0}'", Numbering);

            if (MySqlHelper.Exists(strSql.ToString()) == true)
                _list.wtfkExBool = true;
            else
                _list.wtfkExBool = false;

            strSql = new StringBuilder();
            if (Exists(Numbering) == true)
            {
                strSql.AppendFormat("UPDATE t_processState SET wtfkBool={0},wtfkExBool={1} WHERE Numbering='{2}'", _list.wtfkBool, _list.wtfkExBool, Numbering);
            }
            else
            {
                strSql.AppendFormat("INSERT INTO  t_processState (Numbering,wtfkBool,wtfkExBool) VALUES ('{0}',{1},{2},'{3}')", Numbering, _list.wtfkBool, _list.wtfkExBool);
            }

            int row = MySqlHelper.ExecuteSql(strSql.ToString());
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 收款记录单  提成换算表
        /// </summary>
        /// <param name="Numbering"></param>
        /// <returns></returns>
        public bool GetFormReceiptRecord(string Numbering)
        {
            FishEntity.ProcessStateEntity _list = new FishEntity.ProcessStateEntity();

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*) from t_receiptrecord where Numbering='" + Numbering + "'and((select sum(truncate(ConfirmTheWeight,3)) from t_cargofeedbacksheet where Numbering='" + Numbering + "')*(select truncate(unitprice,4) from t_happening where NumberingOne='" + Numbering + "')-(select Sum(truncate(Chargeback,4))from t_theproblemsheet where Numbering='" + Numbering + "'))=(select SUM(truncate(RMB,4)) from t_receiptrecord where Numbering='" + Numbering+"')");
            if (MySqlHelper.Exists(strSql.ToString()) == true)
            {
                _list.skjlBool = '1'; //对应上为红色
            }
            else {
                strSql = new StringBuilder();
                strSql.AppendFormat("select count(1) from t_receiptrecord where Numbering='{0}'", Numbering);
                if (MySqlHelper.Exists(strSql.ToString()) == true)
                {
                    _list.skjlBool = '2';//已录入对应不上为黄色
                }
                else {
                    _list.skjlBool = '0';//无数据为蓝色
                }
            }

            strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from t_review where programId='FormReceiptRecord' and state='审核' and Numbering='{0}'", Numbering);

            if (MySqlHelper.Exists(strSql.ToString()) == true)
                _list.skjlExBool = true;
            else
                _list.skjlExBool = false;

            _list.tchsBool = _list.tchsExBool = false;

            strSql = new StringBuilder();
            if (Exists(Numbering) == true)
            {
                strSql.AppendFormat("UPDATE t_processState SET skjlBool={0},skjlExBool={1},tchsBool={3},tchsExBool={4} WHERE Numbering='{2}'", _list.skjlBool, _list.skjlExBool, Numbering, _list.tchsBool, _list.tchsExBool);
            }
            else
            {
                strSql.AppendFormat("INSERT INTO  t_processState (Numbering,skjlBool,skjlExBool,tchsBool,tchsExBool) VALUES ('{0}',{1},{2},{3},{4})", Numbering, _list.skjlBool, _list.skjlExBool, _list.tchsBool, _list.tchsExBool);
            }

            int row = MySqlHelper.ExecuteSql(strSql.ToString());
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public List<FishEntity.ProcessStateEntity> getList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.effect,a.id,b.code,a.xssqBool,a.xssqExBool,a.xshtBool,a.xshtExBool,a.fksqBool,a.fksqExBool,a.thdCode,a.thdBool,a.bdCode,a.bdBool,a.bdExBool,a.hwfkCode,a.hwfkBool,a.hwfkExBool,a.wtfkCode,a.wtfkBool,a.wtfkExBool,a.skjlBool,a.skjlExBool,a.tchsBool,a.tchsExBool,a.protime,a.Numbering from t_processstate a left join t_salesorder b on a.Numbering=b.Numbering  ");
            strSql.Append("where " + strWhere);
            strSql.Append(" and b.Numbering!='' order by id desc ");

            DataTable dt = MySqlHelper.Query(strSql.ToString()).Tables[0];
            List<FishEntity.ProcessStateEntity> modelList = new List<FishEntity.ProcessStateEntity>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(GetDataRow(dt.Rows[i]));
                }

                return modelList;
            }
            else
                return null;
        }
        /// <summary>
        /// 修改有效性
        /// </summary>
        /// <param name="Numbering"></param>
        /// <param name="effect"></param>
        /// <returns></returns>
        public bool update(string effect, string Numbering) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_processstate set ");
            strSql.Append(" effect=@effect ");
            strSql.Append(" where Numbering=@Numbering ");
            MySqlParameter[] parameter = {
                new MySqlParameter("@effect",MySqlDbType.VarChar,45),
                new MySqlParameter("@Numbering",MySqlDbType.VarChar,45),
            };
            parameter[0].Value = effect;
            parameter[1].Value = Numbering;
            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameter);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public FishEntity.ProcessStateEntity GetDataRow(DataRow row)
        {
            FishEntity.ProcessStateEntity model = new FishEntity.ProcessStateEntity();

            if (row != null)
            {
                if (row["id"]!=null&&row["id"].ToString()!="")
                {
                    model.id =int.Parse(row["id"].ToString());
                }
                if (row["Numbering"]!=null)
                {
                    model.Numbering = row["Numbering"].ToString();
                }
                if (row["code"] != null)
                {
                    model.code = row["code"].ToString();
                }
                if (row["xssqBool"] != null)
                {
                    model.xssqBool = bool.Parse(row["xssqBool"].ToString());
                }
                if (row["xssqExBool"] != null)
                {
                    model.xssqExBool = bool.Parse(row["xssqExBool"].ToString());
                }
                if (row["xshtBool"] != null && row["xshtBool"].ToString() != "")
                {
                    model.xshtBool = bool.Parse(row["xshtBool"].ToString());
                }
                if (row["xshtExBool"] != null && row["xshtExBool"].ToString() != "")
                {
                    model.xshtExBool = bool.Parse(row["xshtExBool"].ToString());
                }
                if (row["fksqBool"] != null && row["fksqBool"].ToString() != "")
                {
                    model.fksqBool = char.Parse(row["fksqBool"].ToString());
                }
                if (row["fksqExBool"] != null && row["fksqExBool"].ToString() != "")
                {
                    model.fksqExBool = bool.Parse(row["fksqExBool"].ToString());
                }
                if (row["thdCode"] != null)
                {
                    model.ThdCode = row["thdCode"].ToString();
                }
                if (row["thdBool"] != null && row["thdBool"].ToString() != "")
                {
                    model.thdBool = char.Parse(row["thdBool"].ToString());
                }
                if (row["bdCode"] != null)
                {
                    model.BdCode = row["bdCode"].ToString();
                }
                if (row["bdBool"] != null && row["bdBool"].ToString() != "")
                {
                    model.bdBool = char.Parse(row["bdBool"].ToString());
                }
                if (row["bdExBool"] != null && row["bdExBool"].ToString() != "")
                {
                    model.bdExBool = bool.Parse(row["bdExBool"].ToString());
                }
                if (row["hwfkCode"] != null)
                {
                    model.HwfkCode = row["hwfkCode"].ToString();
                }
                if (row["hwfkBool"] != null && row["hwfkBool"].ToString() != "")
                {
                    model.hwfkBool = char.Parse(row["hwfkBool"].ToString());
                }
                if (row["hwfkExBool"] != null && row["hwfkExBool"].ToString() != "")
                {
                    model.hwfkExBool = bool.Parse(row["hwfkExBool"].ToString());
                }
                if (row["wtfkCode"] != null)
                {
                    model.WtfkCode = row["wtfkCode"].ToString();
                }
                if (row["wtfkBool"] != null && row["wtfkBool"].ToString() != "")
                {
                    model.wtfkBool = char.Parse(row["wtfkBool"].ToString());
                }
                if (row["wtfkExBool"] != null && row["wtfkExBool"].ToString() != "")
                {
                    model.wtfkExBool = bool.Parse(row["wtfkExBool"].ToString());
                }
                if (row["skjlBool"] != null && row["skjlBool"].ToString() != "")
                {
                    model.skjlBool = char.Parse(row["skjlBool"].ToString());
                }
                if (row["skjlExBool"] != null && row["skjlExBool"].ToString() != "")
                {
                    model.skjlExBool = bool.Parse(row["skjlExBool"].ToString());
                }
                if (row["tchsBool"] != null && row["tchsBool"].ToString() != "")
                {
                    model.tchsBool = bool.Parse(row["tchsBool"].ToString());
                }
                if (row["tchsExBool"] != null && row["tchsExBool"].ToString() != "")
                {
                    model.tchsExBool = bool.Parse(row["tchsExBool"].ToString());
                }
                if (row["effect"] != null)
                {
                    model.Effect = row["effect"].ToString();
                }
            }

            return model;
        }
        /// <summary>
        /// 公司问题反馈单关联查询
        /// </summary>
        /// <param name="Numbering"></param>
        /// <returns></returns>
        public List<FishEntity.TheproblemsheetEntity> GetTheproblemsheetList(string Numbering)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DISTINCT a.id,a.createman,a.Numbering,a.code,a.codeContract,a.occurDate,a.EventName,a.SolvTtheProblem,a.Remarks,a.Chargeback,a.FishMealId from t_theproblemsheet a left join t_review b on a.Numbering=b.Numbering and b.programId = 'FormTheproblemsheet' and state = '审核' where a.Numbering='" + Numbering + "'");
            DataTable dt = MySqlHelper.Query(strSql.ToString()).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                List<FishEntity.TheproblemsheetEntity> modelList = new List<FishEntity.TheproblemsheetEntity>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FishEntity.TheproblemsheetEntity model = new FishEntity.TheproblemsheetEntity();
                    DataRow row = dt.Rows[i];
                    if (row!=null)
                    {
                        if (row["id"]!=null && row["id"].ToString() != "")
                        {
                            model.Id = int.Parse(row["id"].ToString());
                        }
                        if (row["Numbering"]!=null)
                        {
                            model.Numbering = row["Numbering"].ToString();
                        }
                        if (row["code"]!=null)
                        {
                            model.Code = row["code"].ToString();
                        }
                        if (row["codeContract"] != null)
                        {
                            model.codeContract = row["codeContract"].ToString();
                        }
                        if (row["createman"]!=null)
                        {
                            model.Createman = row["createman"].ToString();
                        }
                        if (row["occurDate"] != null)
                        {
                            model.OccurDate =DateTime.Parse(row["occurDate"].ToString());
                        }
                        if (row["EventName"] != null)
                        {
                            model.EventName = row["EventName"].ToString();
                        }
                        if (row["SolvTtheProblem"] != null)
                        {
                            model.SolvTtheProblem = row["SolvTtheProblem"].ToString();
                        }
                        if (row["Remarks"] != null)
                        {
                            model.Remarks = row["Remarks"].ToString();
                        }
                        if (row["Chargeback"] != null&&row["Chargeback"].ToString()!="")
                        {
                            model.Chargeback =decimal.Parse(row["Chargeback"].ToString());
                        }
                        if (row["FishMealId"]!=null)
                        {
                            model.FishMealId = row["FishMealId"].ToString();
                        }
                        modelList.Add(model);
                    }
                }
                return modelList;
            }
            else {
                return null;
            }
        }
        /// <summary>
        /// 货物反馈单关联查询
        /// </summary>
        /// <param name="Numbering"></param>
        /// <returns></returns>
        public List<FishEntity.CargoFeedbackSheetEntity> GetCargoFeedbackSheetList(string Numbering)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DISTINCT a.id,a.Numbering,a.createman,a.code,a.codeContract,a.sponsor,a.acceptor,a.processresult,a.evaluation,a.remarks,a.ConfirmTheWeight,FishMealId,PoundDifference,NetWeight,PoundBillNumber from t_cargofeedbacksheet a left join t_review b on a.Numbering=b.Numbering and b.programId = 'FormCargoFeedbackSheet' and state = '审核' where a.Numbering='" + Numbering + "'");
            DataTable dt = MySqlHelper.Query(strSql.ToString()).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                List<FishEntity.CargoFeedbackSheetEntity> modelList = new List<FishEntity.CargoFeedbackSheetEntity>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FishEntity.CargoFeedbackSheetEntity model = new FishEntity.CargoFeedbackSheetEntity();
                    DataRow row = dt.Rows[i];
                    if (row != null)
                    {
                        if (row["id"] != null&&row["id"].ToString()!="")
                        {
                            model.Id = int.Parse(row["id"].ToString());
                        }
                        if (row["code"] != null)
                        {
                            model.Code = row["code"].ToString();
                        }
                        if (row["Numbering"]!=null)
                        {
                            model.Numbering = row["Numbering"].ToString();
                        }
                        if (row["createman"]!=null)
                        {
                            model.Createman = row["createman"].ToString();
                        }
                        if (row["codeContract"] != null)
                        {
                            model.codeContract = row["codeContract"].ToString();
                        }
                        if (row["sponsor"] != null)
                        {
                            model.Sponsor = row["sponsor"].ToString();
                        }
                        if (row["acceptor"] != null)
                        {
                            model.Acceptor = row["acceptor"].ToString();
                        }
                        if (row["processresult"] != null)
                        {
                            model.Processresult = row["processresult"].ToString();
                        }
                        if (row["evaluation"] != null)
                        {
                            model.Evaluation = row["evaluation"].ToString();
                        }
                        if (row["ConfirmTheWeight"] != null)
                        {
                            model.ConfirmTheWeight = row["ConfirmTheWeight"].ToString();
                        }
                        if (row["remarks"] != null)
                        {
                            model.Remarks = row["remarks"].ToString();
                        }
                        if (row["FishMealId"]!=null)
                        {
                            model.FishMealId = row["FishMealId"].ToString();
                        }
                        if (row["PoundBillNumber"]!=null)
                        {
                            model.PoundBillNumber = row["PoundBillNumber"].ToString();
                        }
                        if (row["PoundDifference"]!=null)
                        {
                            model.PoundDifference = row["PoundDifference"].ToString();
                        }
                        if (row["NetWeight"]!=null)
                        {
                            model.NetWeight = row["NetWeight"].ToString();
                        }
                        modelList.Add(model);
                    }
                }
                return modelList;
            }
            else {
                return null;
            }
        }
        /// <summary>
        /// 关联提货单数据查询
        /// </summary>
        /// <param name="Numbering"></param>
        /// <returns></returns>
        public List<FishEntity.BillofladingEntity> GetBillofladingListOne(string Numbering)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DISTINCT a.id,a.Numbering,a.FishMealId,a.Country,a.Brands,a.RedemptionWeight,a. CODE codeOne,a.createman,a.SerialNumber,a.Issuingtime,a.codeContract,a.contactsunit,a.ContactsunitId,a.warehouse,a.species,a.specification,a.cornerno,a.ferryname,a.listname,a.Ton,a.packagenumber,a.Remarks,a.ShipNotice,a.Storagecosts,a.Recipient from t_billoflading a left join t_review b on a.Numbering=b.Numbering and b.programId = 'FormBilloflading' and state = '审核' where a.Numbering='" + Numbering + "' ORDER BY a.Issuingtime ASC");
            DataTable dt = MySqlHelper.Query(strSql.ToString()).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                List<FishEntity.BillofladingEntity> modelList = new List<FishEntity.BillofladingEntity>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FishEntity.BillofladingEntity model = new FishEntity.BillofladingEntity();
                    DataRow row = dt.Rows[i];
                    if (row != null)
                    {
                        if (row["id"] != null && row["id"].ToString() != "")
                        {
                            model.Id = int.Parse(row["id"].ToString());
                        }
                        if (row["FishMealId"]!=null)
                        {
                            model.FishMealId = row["FishMealId"].ToString();
                        }
                        if (row["Country"] != null)
                        {
                            model.Country = row["Country"].ToString();
                        }
                        if (row["Brands"] != null)
                        {
                            model.Brands = row["Brands"].ToString();
                        }
                        if (row["RedemptionWeight"]!=null&&row["RedemptionWeight"].ToString()!="")
                        {
                            model.RedemptionWeight = Convert.ToDecimal(row["RedemptionWeight"]);
                        }
                        if (row["codeOne"] != null )
                        {
                            model.Code = row["codeOne"].ToString();
                        }
                        if (row["Numbering"]!=null)
                        {
                            model.Numbering = row["Numbering"].ToString();
                        }
                        if (row["SerialNumber"] != null)
                        {
                            model.SerialNumber = row["SerialNumber"].ToString();
                        }
                        if (row["Issuingtime"] != null && row["Issuingtime"].ToString() != "")
                        {
                            model.Issuingtime = DateTime.Parse(row["Issuingtime"].ToString());
                        }
                        if (row["codeContract"] != null )
                        {
                            model.codeContract = row["codeContract"].ToString();
                        }
                        if (row["contactsunit"] != null )
                        {
                            model.Contactsunit = row["contactsunit"].ToString();
                        }
                        if (row["ContactsunitId"] != null )
                        {
                            model.ContactsunitId = row["ContactsunitId"].ToString();
                        }
                        if (row["warehouse"] != null )
                        {
                            model.Warehouse = row["warehouse"].ToString();
                        }
                        if (row["species"] != null )
                        {
                            model.Species = row["species"].ToString();
                        }
                        if (row["specification"] != null )
                        {
                            model.Specification = row["specification"].ToString();
                        }
                        if (row["cornerno"] != null )
                        {
                            model.Cornerno = row["cornerno"].ToString();
                        }
                        if (row["ferryname"] != null )
                        {
                            model.Ferryname = row["ferryname"].ToString();
                        }
                        if (row["ferryname"] != null )
                        {
                            model.Ferryname = row["ferryname"].ToString();
                        }
                        if (row["listname"] != null )
                        {
                            model.Listname = row["listname"].ToString();
                        }
                        if (row["Ton"] != null )
                        {
                            model.Ton = row["Ton"].ToString();
                        }
                        if (row["packagenumber"] != null )
                        {
                            model.Packagenumber = row["packagenumber"].ToString();
                        }
                        if (row["Remarks"] != null )
                        {
                            model.Remarks = row["Remarks"].ToString();
                        }
                        if (row["ShipNotice"] != null )
                        {
                            model.ShipNotice = row["ShipNotice"].ToString();
                        }
                        if (row["Storagecosts"] != null )
                        {
                            model.Storagecosts = row["Storagecosts"].ToString();
                        }
                        if (row["Recipient"] != null)
                        {
                            model.Recipient = row["Recipient"].ToString();
                        }
                        if (row["createman"]!=null)
                        {
                            model.Createman = row["createman"].ToString();
                        }
                        modelList.Add(model);
                    }
                }
                return modelList;
            }
            else
                return null;
        }
        public DataTable getdataset(string where) {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select DISTINCT TiDanCode from t_poundsalone where {0} ", where);
            return MySqlHelper.Query(strSql.ToString()).Tables[0];
        }

        public List<FishEntity.OnepoundEntity> GetFormOnepoundList(string Numbering)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DISTINCT a.id,a.FishMealId,a.RedemptionWeight,a.TiDanCode,a.createman,a.Numbering,a.code codeOne,a.Serialnumber,a.Dateofmanufacture,a.IntothefactoryDate,a.Carnumber,a.Grossweight,a.Tareweight,a.Competition,a.Goods,a.Owner,a.OwnerId,a.Buyers,a.BuyersId,a.Sellers,a.SellersId,a.Country,a.PName,a.Qualit,a.Quantity,a.Pileangle,a.BillOfLadingid,a.Address,a.Remarks,a.Shipno,a.codeContract  from t_poundsalone a left join t_review b on a.code = b.SingleNumber and b.programId='FormOnepound' AND state = '审核' where a.Numbering='" + Numbering + "' ORDER BY a.Dateofmanufacture ASC");
            DataTable dt = MySqlHelper.Query(strSql.ToString()).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                List<FishEntity.OnepoundEntity> modelList = new List<FishEntity.OnepoundEntity>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FishEntity.OnepoundEntity model = new FishEntity.OnepoundEntity();
                    DataRow row = dt.Rows[i];
                    if (row != null)
                    {
                        if (row["id"] != null && row["id"].ToString() != "")
                        {
                            model.Id = int.Parse(row["id"].ToString());
                        }
                        if (row["TiDanCode"].ToString()!="")
                        {
                            model.TiDanCode = row["TiDanCode"].ToString();
                        }
                        if (row["RedemptionWeight"] != null && row["RedemptionWeight"].ToString() != "")
                        {
                            model.RedemptionWeight = decimal.Parse( row["RedemptionWeight"].ToString());
                        }
                        if (row["FishMealId"]!=null)
                        {
                            model.FishMealId = row["FishMealId"].ToString();
                        }
                        if (row["codeOne"] != null)
                        {
                            model.Code = row["codeOne"].ToString();
                        }
                        if (row["Numbering"]!=null)
                        {
                            model.Numbering = row["Numbering"].ToString();
                        }
                        if (row["Serialnumber"] != null)
                        {
                            model.Serialnumber = row["Serialnumber"].ToString();
                        }
                        if (row["Dateofmanufacture"] != null && row["Dateofmanufacture"].ToString() != "")
                        {
                            model.Dateofmanufacture = DateTime.Parse(row["Dateofmanufacture"].ToString());
                        }
                        if (row["IntothefactoryDate"] != null && row["IntothefactoryDate"].ToString() != "")
                        {
                            model.IntothefactoryDate = DateTime.Parse(row["IntothefactoryDate"].ToString());
                        }
                        if (row["Country"]!=null)
                        {
                            model.Country = row["Country"].ToString();
                        }
                        if (row["Carnumber"] != null)
                        {
                            model.Carnumber = row["Carnumber"].ToString();
                        }
                        if (row["Grossweight"] != null)
                        {
                            model.Grossweight = row["Grossweight"].ToString();
                        }
                        if (row["Tareweight"] != null)
                        {
                            model.Tareweight = row["Tareweight"].ToString();
                        }
                        if (row["Competition"] != null)
                        {
                            model.Competition = row["Competition"].ToString();
                        }
                        if (row["Goods"] != null)
                        {
                            model.Goods = row["Goods"].ToString();
                        }
                        if (row["Owner"] != null)
                        {
                            model.Owner = row["Owner"].ToString();
                        }
                        if (row["OwnerId"] != null)
                        {
                            model.OwnerId = row["OwnerId"].ToString();
                        }
                        if (row["Buyers"] != null)
                        {
                            model.Buyers = row["Buyers"].ToString();
                        }
                        if (row["BuyersId"] != null)
                        {
                            model.BuyersId = row["BuyersId"].ToString();
                        }
                        if (row["Sellers"] != null)
                        {
                            model.Sellers = row["Sellers"].ToString();
                        }
                        if (row["SellersId"] != null)
                        {
                            model.SellersId = row["SellersId"].ToString();
                        }
                        if (row["PName"] != null)
                        {
                            model.PName = row["PName"].ToString();
                        }
                        if (row["Qualit"] != null)
                        {
                            model.Qualit = row["Qualit"].ToString();
                        }
                        if (row["Quantity"] != null)
                        {
                            model.Quantity = row["Quantity"].ToString();
                        }
                        if (row["Pileangle"] != null)
                        {
                            model.Pileangle = row["Pileangle"].ToString();
                        }
                        if (row["BillOfLadingid"] != null)
                        {
                            model.BillOfLadingid = row["BillOfLadingid"].ToString();
                        }
                        if (row["Address"] != null)
                        {
                            model.Address = row["Address"].ToString();
                        }
                        if (row["Remarks"] != null)
                        {
                            model.Remarks = row["Remarks"].ToString();
                        }
                        if (row["Shipno"] != null)
                        {
                            model.Shipno = row["Shipno"].ToString();
                        }
                        if (row["codeContract"] != null)
                        {
                            model.codeContract = row["codeContract"].ToString();
                        }
                        if (row["createman"]!=null)
                        {
                            model.Createman = row["createman"].ToString();
                        }
                        modelList.Add(model);
                    }
                }
                return modelList;
            }
            else
                return null;
        }
        /// <summary>
        /// 付款申请单数据查询
        /// </summary>
        /// <param name="Numbering"></param>
        /// <returns></returns>
        public List<FishEntity.PaymentRequisitionEntity> GetListOne(string Numbering)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DISTINCT a.applyMoney,a.id,a.FishMealId,bond,a.Numbering,a.CNumbering,a.PurchasingUnit,PricingType,applyCode,a.createMan,a.code,applyDate,purchasecode,acountNum,unit,contacts,backDeposit,price,weight,paymentMethod,paymentType,paymentDate,invoiceType,remark,case when state='审核' then '审核' else '' end paymentMethodOther from t_paymentrequisition a LEFT JOIN t_review b on a.code = b.SingleNumber and b.programId='FormPaymentRequisition' and state='审核'");
            strSql.AppendFormat(" where {0} ", Numbering);

            DataTable dt = MySqlHelper.Query(strSql.ToString()).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                List<FishEntity.PaymentRequisitionEntity> modelList = new List<FishEntity.PaymentRequisitionEntity>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(getModel(dt.Rows[i]));
                }
                return modelList;
            }
            else
                return null;
        }

        public FishEntity.PaymentRequisitionEntity getModel(DataRow row)
        {
            FishEntity.PaymentRequisitionEntity model = new FishEntity.PaymentRequisitionEntity();

            if (row != null)
            {
                if (row["id"] != null)
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if ( row [ "Numbering" ] != null )
                {
                    model . Numbering = row [ "Numbering" ] . ToString ( );
                }
                if (row["FishMealId"]!=null)
                {
                    model.FishMealId = row["FishMealId"].ToString();
                }
                //if (row["codeOne"] != null)
                //    model.code = row["codeOne"].ToString();
                //if ( row [ "applyDepartId" ] != null )
                //    model . applyDepartId = row [ "applyDepartId" ] . ToString ( );
                //if ( row [ "applyDepart" ] != null )
                //    model . applyDepart = row [ "applyDepart" ] . ToString ( );
                if (row["applyDate"] != null && row["applyDate"].ToString() != "")
                    model.applyDate = DateTime.Parse(row["applyDate"].ToString());
                if ( row [ "applyCode" ] != null )
                    model . applyCode = row [ "applyCode" ] . ToString ( );
                if (row["purchasecode"] != null)
                {
                    model.Purchasecode = row["purchasecode"].ToString();
                }
                if (row["applyMoney"]!=null&&row["applyMoney"].ToString()!="")
                {
                    model.applyMoney = decimal.Parse(row["applyMoney"].ToString());
                }
                if (row["PurchasingUnit"]!=null)
                {
                    model.PurchasingUnit = row["PurchasingUnit"].ToString();
                }
                if ( row [ "unit" ] != null )
                    model . unit = row [ "unit" ] . ToString ( );
                if ( row [ "contacts" ] != null )
                    model . contacts = row [ "contacts" ] . ToString ( );
                if (row["backDeposit"] != null)
                    model.backDeposit = row["backDeposit"].ToString();
                if (row["price"] != null && row["price"].ToString() != "")
                    model.price = decimal.Parse(row["price"].ToString());
                if (row["weight"] != null && row["weight"].ToString() != "")
                    model.weight = decimal.Parse(row["weight"].ToString());
                if (row["paymentType"] != null)
                    model.paymentType = row["paymentType"].ToString();
                if (row["PricingType"] !=null)
                {
                    model.PricingType = row["PricingType"].ToString();
                }
                if (row["paymentMethod"] != null)
                    model.paymentMethod = row["paymentMethod"].ToString();
                if (row["paymentMethodOther"] != null)
                    model.paymentMethodOther = row["paymentMethodOther"].ToString();
                if (row["invoiceType"] != null)
                    model.invoiceType = row["invoiceType"].ToString();
                if (row["paymentDate"] != null && row["paymentDate"].ToString() != "")
                    model.paymentDate = DateTime.Parse(row["paymentDate"].ToString());
                if (row["remark"] != null)
                    model.remark = row["remark"].ToString();
                if (row["acountNum"] != null)
                    model.AcountNum = row["acountNum"].ToString();
                if (row["createMan"]!=null)
                {
                    model.createMan = row["createMan"].ToString();
                }
                if ( row ["CNumbering"] != null )
                    model .CNumbering = row ["CNumbering"] . ToString ( );
                if ( row [ "code" ] != null )
                    model . code = row [ "code" ] . ToString ( );
            }

            return model;
        }

        /// <summary>
        /// 收款记录单数据查询
        /// </summary>
        /// <param name="Numbering"></param>
        /// <returns></returns>
        public List<FishEntity.ReceiptRecordEntity> GetListTwo(string Numbering)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DISTINCT a.id,a.DemaUndnit,a.FishMealId,a.DemandSideContact,a.Numbering,a.createMan,codeContract,a.code codeTwo,a.fuKuandate,codePrice,codeYunFei,codeHuiKou,fuKuanDanWei,fuKuanZhangHao,weight weightOne ,price priceOne,fuKuanType,fuKuanMethod,RMB,invoiceType invoiceTypeOne,remark remarkOne,case when state='审核' then '审核' else '' end ShouKuanZhuangTai from t_ReceiptRecord a left join t_review b on a.code = b.SingleNumber and b.programId='FormReceiptRecord' and b.state='审核' ");
            strSql.AppendFormat(" where a.Numbering='{0}'", Numbering);

            DataTable dt = MySqlHelper.Query(strSql.ToString()).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                List<FishEntity.ReceiptRecordEntity> modelList = new List<FishEntity.ReceiptRecordEntity>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(GetModel(dt.Rows[i]));
                }
                return modelList;
            }
            else
                return null;
        }

        public FishEntity.ReceiptRecordEntity GetModel(DataRow row)
        {
            FishEntity.ReceiptRecordEntity _model = new FishEntity.ReceiptRecordEntity();

            if (row != null)
            {
                if (row["id"]!=null)
                {
                    _model.id =int.Parse(row["id"].ToString());
                }
                if (row["Numbering"]!=null)
                {
                    _model.Numbering = row["Numbering"].ToString();
                }
                if (row["ShouKuanZhuangTai"] !=null)
                {
                    _model.ShouKuanZhuangTai = row["ShouKuanZhuangTai"].ToString();
                }
                if (row["DemaUndnit"]!=null)
                {
                    _model.DemaUndnit = row["DemaUndnit"].ToString();
                }
                if (row["DemandSideContact"] != null)
                {
                    _model.DemandSideContact = row["DemandSideContact"].ToString();
                }
                if (row["codeContract"] != null && row["codeContract"].ToString() != "")
                    _model.codeContract = row["codeContract"].ToString();
                if (row["codeTwo"] != null && row["codeTwo"].ToString() != "")
                    _model.code = row["codeTwo"].ToString();
                if (row["fuKuandate"] != null && row["fuKuandate"].ToString() != "")
                    _model.fuKuandate = DateTime.Parse(row["fuKuandate"].ToString());
                if (row["codePrice"] != null && row["codePrice"].ToString() != "")
                    _model.codePrice = decimal.Parse(row["codePrice"].ToString());
                if (row["codeYunFei"] != null && row["codeYunFei"].ToString() != "")
                    _model.codeYunFei = decimal.Parse(row["codeYunFei"].ToString());
                if (row["codeHuiKou"] != null && row["codeHuiKou"].ToString() != "")
                    _model.codeHuiKou = decimal.Parse(row["codeHuiKou"].ToString());
                if (row["fuKuanDanWei"] != null && row["fuKuanDanWei"].ToString() != "")
                    _model.fuKuanDanWei = row["fuKuanDanWei"].ToString();
                if (row["fuKuanZhangHao"] != null && row["fuKuanZhangHao"].ToString() != "")
                    _model.fuKuanZhangHao = row["fuKuanZhangHao"].ToString();
                if (row["weightOne"] != null && row["weightOne"].ToString() != "")
                    _model.weight = decimal.Parse(row["weightOne"].ToString());
                if (row["priceOne"] != null && row["priceOne"].ToString() != "")
                    _model.price = decimal.Parse(row["priceOne"].ToString());
                if (row["fuKuanType"] != null && row["fuKuanType"].ToString() != "")
                    _model.fuKuanType = row["fuKuanType"].ToString();
                if (row["fuKuanMethod"] != null && row["fuKuanMethod"].ToString() != "")
                    _model.fuKuanMethod = row["fuKuanMethod"].ToString();
                if (row["RMB"] != null && row["RMB"].ToString() != "")
                    _model.RMB = decimal.Parse(row["RMB"].ToString());
                if (row["invoiceTypeOne"] != null && row["invoiceTypeOne"].ToString() != "")
                    _model.invoiceType = row["invoiceTypeOne"].ToString();
                if (row["remarkOne"] != null && row["remarkOne"].ToString() != "")
                    _model.remark = row["remarkOne"].ToString();
                if (row["createMan"]!=null)
                {
                    _model.createMan = row["createMan"].ToString();
                }
                if (row["FishMealId"]!=null)
                {
                    _model.FishMealId = row["FishMealId"].ToString();
                }
            }

            return _model;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Numbering"></param>
        /// <param name="Form"></param>
        /// <returns></returns>
        public bool TableExists(string Numbering,string Form) {
            StringBuilder strsql = new StringBuilder();
            strsql.AppendFormat("select count(1) from t_review where programId='{0}' and state='审核' and Numbering='{1}'",Form,Numbering);
            return MySqlHelper.Exists(strsql.ToString());
        }
        DateTime dt()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT now() t");

            DataSet da = MySqlHelper.Query(strSql.ToString());

            return Convert.ToDateTime(da.Tables[0].Rows[0]["t"].ToString());
        }
        public bool SHAdd(string Form,string Numbering) {
            StringBuilder strSql = new StringBuilder();
            DateTime date, createTime, modifyTime;
            date = createTime = modifyTime = dt();
            strSql.Append("insert into t_review (");
            strSql.Append("userName,programId,Numbering,date,content,state,userNameReview,createTime,createMan,modifyTime,modifyMan) ");
            strSql.Append("values (");
            strSql.Append("@userName,@programId,@Numbering,@date,@content,@state,@userNameReview,@createTime,@createMan,@modifyTime,@modifyMan) ");
            MySqlParameter[] parameter = {
                new MySqlParameter("@userName",MySqlDbType.VarChar,45),
                new MySqlParameter("@programId",MySqlDbType.VarChar,45),
                new MySqlParameter("@date",MySqlDbType.DateTime),
                new MySqlParameter("@content",MySqlDbType.VarChar,45),
                new MySqlParameter("@state",MySqlDbType.VarChar,45),
                new MySqlParameter("@userNameReview",MySqlDbType.VarChar,45),
                new MySqlParameter("@createTime",MySqlDbType.DateTime),
                new MySqlParameter("@createMan",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifyTime",MySqlDbType.DateTime),
                new MySqlParameter("@modifyMan",MySqlDbType.VarChar,45),
                new MySqlParameter("@Numbering",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = "自动审核";
            parameter[1].Value = Form;
            parameter[2].Value = date;
            parameter[3].Value = "自动审核";
            parameter[4].Value = "审核";
            parameter[5].Value = "自动审核";
            parameter[6].Value = createTime;
            parameter[7].Value = "自动审核";
            parameter[8].Value = modifyTime;
            parameter[9].Value = "自动审核";
            parameter[10].Value = Numbering;
            int row = MySqlHelper.ExecuteSql(strSql.ToString(),parameter);
            if (row > 0)
                return true;
            else
                return false;
        }
        public bool SHUpdate(string Form, string Numbering) {
            StringBuilder strsql = new StringBuilder();
            DateTime date, modifyTime;
            date = modifyTime = dt();
            strsql.Append("UPDATE t_review SET ");
            strsql.Append(" userName = @userName,");
            strsql.Append("date = @date,");
            strsql.Append("content = @content,");
            strsql.Append("state = @state,");
            strsql.Append("userNameReview = @userNameReview,");
            strsql.Append("modifyTime = @modifyTime,");
            strsql.Append("modifyMan = @modifyMan ");
            strsql.Append("WHERE Numbering = @Numbering and programId=@programId ORDER BY id DESC LIMIT 1");
            MySqlParameter[] parameter = {
                new MySqlParameter("@userName",MySqlDbType.VarChar,45),
                new MySqlParameter("@programId",MySqlDbType.VarChar,45),
                new MySqlParameter("@date",MySqlDbType.DateTime),
                new MySqlParameter("@content",MySqlDbType.VarChar,45),
                new MySqlParameter("@state",MySqlDbType.VarChar,45),
                new MySqlParameter("@userNameReview",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifyTime",MySqlDbType.DateTime),
                new MySqlParameter("@modifyMan",MySqlDbType.VarChar,45),
                new MySqlParameter("@Numbering",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = "自动审核";
            parameter[1].Value = Form;
            parameter[2].Value = date;
            parameter[3].Value = "自动审核";
            parameter[4].Value = "审核";
            parameter[5].Value = "自动审核";
            parameter[6].Value = modifyTime;
            parameter[7].Value = "自动审核";
            parameter[8].Value = Numbering;
            int row = MySqlHelper.ExecuteSql(strsql.ToString(), parameter);
            if (row > 0)
                return true;
            else
                return false;
        }
        public bool ExistsNumbering(string Numbering,string status)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select count(*) from t_processstate where Numbering=@Numbering and "+ status + "=1 ");
            MySqlParameter[] parameter = {
                new MySqlParameter("@Numbering",MySqlDbType.VarChar,200)
            };
            parameter[0].Value = Numbering;
            return MySqlHelper.Exists(strsql.ToString(), parameter);
        }
    }
}
