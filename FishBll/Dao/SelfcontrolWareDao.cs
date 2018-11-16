using System . Data;
using System . Text;

namespace FishBll . Dao
{
    public class SelfcontrolWareDao
    {
        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <returns></returns>
        public DataTable getTableView ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ("select fishId 鱼粉ID,billName 提单号,codeNum 采购编号,codeNumContract 采购合同号,a.price 采购价格,c.salermb 市场价格,a.applyDate 入库日期,c.selfstorageweight 重量,c.selfstoragequantity 数量,pileNum 桩角号,db 蛋白,tvn TVN,za 组胺,shy 沙和盐,hf 灰份,domestic_sour 酸价,zf 脂肪,domestic_lysine 赖氨酸,domestic_methionine 蛋氨酸,domestic_aminototal 氨基酸总和,a.remark 备注,country 国别,a.brand 品牌,shipName 船名,b.State4 状态 ,b.port 港口,a.code 入库申请单单号 from t_storageofrequisition a inner join t_product b on a.fishId=b.code inner join t_productex c on b.id=c.id");
            
            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }
    }
}
