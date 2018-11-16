using System . Data;
using System . Text;

namespace FishBll . Dao
{
    public class PriWarehouseDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableView ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ("SELECT 	d.createman 所属人,d.code 鱼粉ID,a.codeNum 采购编号,a.codeNumContract 采购合同号,d.billofgoods 提单号,f.confirmagent 开证代理,f.confirmlinkman 联系人,f.confirmdate 售息日期,f.confirmrmb 价格RMB,d.nature 国别,d.brand 品牌,d.specification 品质,f.confirmsgsweight SGS重量,f.saleremainweight 剩余数量,d.sgs_protein SGS蛋白,d.sgs_tvn SGSTVN,d.sgs_fat SGS脂肪,d.sgs_water SGS水分,d.sgs_amine SGS组胺,d.sgs_ffa SGSFFA,d.sgs_sandsalt SGS沙和盐,d.sgs_graypart SGS灰份,d.domestic_protein 实测蛋白,d.domestic_amine 实测组胺,d.domestic_tvn 实测tvn,d.domestic_sandsalt 实测盐,d.domestic_graypart 实测灰分,d.domestic_sour 实测酸价,d.domestic_fat 实测脂肪,d.domestic_lysine 实测赖氨酸,d.domestic_methionine 实测蛋安酸,d.domestic_aminototal 氨基酸总和,d.remark 备注,d.shipno 船名,f.spotdate 入库日期,d.warehouse 仓库地址,d.cornerno 桩角号,d.samplingtime 取样日期,f.spotproductdate 生产日期,	CASE WHEN d.state = TRUE THEN	'报盘'WHEN d.state1 = TRUE THEN	'确盘'WHEN d.state2 = TRUE THEN'现货'WHEN d.state3 = TRUE THEN	'自营'WHEN d.state4 = TRUE THEN	'自制'WHEN d.state5 THEN	'成品'END 状态, d.port 港口 FROM	t_purchaseapplication a INNER JOIN t_purchaseappfishinfo b on a.codeNum=b.code inner JOIN t_product d ON b.fishId = d. CODE inner JOIN t_productex f ON d.id = f.id left join t_warehousereceipt x ON b.fishId=x.fishId where (a.choise='报盘'and x.code!='')or(a.choise!='报盘')");
            strSql.Append(" select * from v_baopan union select * from v_xianhuo ");
            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }
        public DataTable mx()
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("SELECT  CODE,SUM(weight) FROM (");
            strSql.Append(" SELECT '现货' CO,d.CODE,a.weight ,a.danjia 单价 FROM t_purchaseapplication a inner join t_purchasecontract p on a.codeNum = p.codeNum INNER JOIN t_product d ON a.fishId = d.CODE INNER JOIN t_productex f ON d.id = f.id WHERE(a.choise != '报盘') and a.process = '采购流程1' ");
            strSql.Append("UNION ALL ");
            strSql.Append("SELECT'报盘',d.CODE,x.ContractAntioxidant,f.confirmrmb FROM  t_purchaseapplication a INNER JOIN t_purchaseappfishinfo b ON a.codeNum = b.CODE INNER JOIN t_product d ON b.fishId = d.CODE INNER JOIN t_productex f ON d.id = f.id INNER JOIN t_warehousereceipt x ON b.fishId = x.fishId WHERE(a.choise = '报盘'AND x.CODE != '') and a.process = '采购流程1' ");
            strSql.Append("UNION ALL  ");
            strSql.Append("SELECT'退货',c.CODE,a.tons,a.price FROM t_returnreceipt a INNER JOIN t_product c ON a.fishId = c.CODE INNER JOIN t_productex d ON c.id = d.id where a.duanxuan = '自营' ");
            strSql.Append("UNION ALL ");
            strSql.Append("SELECT'销售',c.CODE,-b.Quantity,b.unitprice FROM  t_salesorder a INNER JOIN t_happening b ON a.Numbering = b.NumberingOne INNER JOIN t_product c ON b.product_id = c.CODE INNER JOIN t_productex e ON c.id = e.id where a.rabZy = 1 ");
            strSql.Append("UNION ALL ");
            strSql.Append("SELECT'自制',d.CODE,-a.weight,a.danjia FROM   t_purchaseapplication a INNER JOIN t_product d ON a.fishId = d.CODE INNER JOIN t_productex f ON d.id = f.id WHERE(a.choise = '自营') and a.process = '采购流程2' ");
            //strSql.Append(")A GROUP BY CODE ");
            return MySqlHelper.Query(strSql.ToString()).Tables[0];
        }
        public DataTable zzmx()
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("SELECT  CODE,SUM(weight) FROM (");
            strSql.Append(" SELECT '自制入库' CO,a.CODE,c.liweight ,a.price 单价 FROM t_storageofrequisition c left join t_product a on c.fishid=a.code inner join t_productex b ON a.id = b.id   ");
            strSql.Append("UNION ALL ");
            strSql.Append("SELECT'退货',c.CODE,a.tons,a.price FROM t_returnreceipt a INNER JOIN t_salesorder b ON a.codeNum = b.Numbering INNER JOIN t_product c ON a.fishId = c.CODE INNER JOIN t_productex d ON c.id = d.id left join t_purchaseapplication e on b.CNumbering = e.codeNum where a.duanxuan = '自制' ");
            strSql.Append("UNION ALL ");
            strSql.Append("SELECT'配料',a.CODE,-c.tons,c.price FROM  t_batchsheets c inner join t_product a on c.fishid=a.code inner join t_productex b ON a.id = b.id where c.issum=0 ");
            //strSql.Append(")A GROUP BY CODE ");
            return MySqlHelper.Query(strSql.ToString()).Tables[0];
        }

        //SELECT 	d.code 鱼粉ID,a.codeNum 采购编号,a.codeNumContract 采购合同号,d.billofgoods 提单号,f.confirmagent 开证代理,f.confirmlinkman 联系人,f.confirmdate 售息日期,f.confirmrmb 价格RMB,d.nature 国别,d.brand 品牌,d.specification 品质,f.confirmsgsweight SGS重量,f.saleremainweight 剩余数量,d.sgs_protein SGS蛋白,d.sgs_tvn SGSTVN,d.sgs_fat SGS脂肪,d.sgs_water SGS水分,d.sgs_amine SGS组胺,d.sgs_ffa SGSFFA,d.sgs_sandsalt SGS沙和盐,d.sgs_graypart SGS灰份,d.domestic_protein 实测蛋白,d.domestic_amine 实测组胺,d.domestic_tvn 实测tvn,d.domestic_sandsalt 实测盐,d.domestic_graypart 实测灰分,d.domestic_sour 实测酸价,d.domestic_fat 实测脂肪,d.domestic_lysine 实测赖氨酸,d.domestic_methionine 实测蛋安酸,d.domestic_aminototal 氨基酸总和,d.remark 备注,d.shipno 船名,f.spotdate 入库日期,d.warehouse 仓库地址,d.cornerno 桩角号,d.samplingtime 取样日期,f.spotproductdate 生产日期,	CASE WHEN d.state = TRUE THEN	'报盘'WHEN d.state1 = TRUE THEN	'确盘'WHEN d.state2 = TRUE THEN'现货'WHEN d.state3 = TRUE THEN	'自营'WHEN d.state4 = TRUE THEN	'自制'WHEN d.state5 THEN	'成品'END 状态, d.type 港口 FROM	t_purchaseapplication a inner JOIN t_product d ON a.fishId = d. CODE inner JOIN t_productex f ON d.id = f.id
        /*
         select a.fishId 鱼粉ID,a.codeNum 采购编号,a.codeNumContract 采购合同号,b.billNum 提单号,e.confirmagent 开证代理,e.confirmlinkman 联系人,e.confirmdate 售息日期,e.confirmrmb 价格RMB,b.conutry 国别,b.brand 品牌,b.quaSpe 品质,e.confirmsgsweight SGS重量,d.sgs_protein SGS蛋白,d.sgs_tvn SGSTVN,d.sgs_fat SGS脂肪,d.sgs_water SGS水分,d.sgs_amine SGS组胺,d.sgs_ffa SGSFFA,d.sgs_sandsalt SGS沙和盐,d.sgs_graypart SGS灰分,d.domestic_protein 实测蛋白,d.domestic_amine 实测组胺,d.domestic_tvn 实测tvn,d.domestic_sandsalt 实测盐,d.domestic_graypart 实测灰分,d.domestic_sour 实测酸价,d.domestic_fat 实测脂肪,d.domestic_lysine 实测赖氨酸,d.domestic_methionine 实测蛋安酸,d.domestic_aminototal 氨基酸总和,d.remark 备注,b.shipName 船名,e.spotdate 入库日期,d.warehouse 仓库地址,d.cornerno 桩角号,d.samplingtime 取样日期,e.spotproductdate 生产日期,d.type 港口 from t_purchaseapplication a left join t_purchasecontract b on a.codeNum=b.codeNum and a.fishId=b.fishId left join t_enterwarehousereceipts c on a.codeNum=c.codeNum and a.fishId=c.fishId and b.codeNumContract=c.codeNumContract left join t_product d on a.fishId=d.code left join t_productex e on d.id=e.id
         */

    }
}
