using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class Variable
    {
        protected static List<SystemDataType> _systemDataTypeList = null;
        public static List<SystemDataType> SystemDataTypeList
        {
            get
            {
                if (_systemDataTypeList == null)
                {
                    _systemDataTypeList = new List<SystemDataType>();
                    SystemDataType item = new SystemDataType(Constant.GeneralLevel, "综合等级");
                    _systemDataTypeList.Add(item);
                    item = new SystemDataType(Constant.CreditLevel, "信用等级");
                    _systemDataTypeList.Add(item);
                    item = new SystemDataType(Constant.RequiredLevel, "需求量等级");
                    _systemDataTypeList.Add(item);
                    item = new SystemDataType(Constant.ManageSpecificateDegree, "管理规范度");
                    _systemDataTypeList.Add(item);
                    item = new SystemDataType(Constant.ActiveLevel, "活跃度");
                    _systemDataTypeList.Add(item);
                    item = new SystemDataType(Constant.Loyalty, "忠诚度");
                    _systemDataTypeList.Add(item);
                    item = new SystemDataType(Constant.Products, "主要产品");
                    _systemDataTypeList.Add(item);
                    item = new SystemDataType(Constant.CompanyNature, "公司性质");
                    _systemDataTypeList.Add(item);
                    item = new SystemDataType(Constant.ManageProjects, "经营项目");
                    _systemDataTypeList.Add(item);

                    item = new SystemDataType(Constant.Type, "类别");
                    _systemDataTypeList.Add(item);

                    item = new SystemDataType(Constant.CustomerProperty, "客户性质");
                    _systemDataTypeList.Add(item);

                    item = new SystemDataType(Constant.Paymethod, "付款方式");
                    _systemDataTypeList.Add(item);
                    item = new SystemDataType(Constant.RequiredProduct, "需求商品");
                    _systemDataTypeList.Add(item);

                    item = new SystemDataType(Constant.Cooperation , "合作认识");
                    _systemDataTypeList.Add(item);

                    item = new SystemDataType(Constant.Province, "省份");
                    _systemDataTypeList.Add(item);

                    item = new SystemDataType(Constant.GoodsInfo , "货物情况");
                    _systemDataTypeList.Add(item);

                    item = new SystemDataType(Constant.Area, "地区");
                    _systemDataTypeList.Add(item);

                }
                return _systemDataTypeList;
            }
        }

        protected static List<SystemDataType> _productDataTypeList = null;
        public static List<SystemDataType> ProductDataTypeList
        {
            get
            {
                if (_productDataTypeList == null)
                {
                    _productDataTypeList = new List<SystemDataType>();
                    SystemDataType item = new SystemDataType(Constant.CountryType, "国别");
                    _productDataTypeList.Add(item);
                    item = new SystemDataType(Constant.Quality, "品质");
                    _productDataTypeList.Add(item);
                    item = new SystemDataType(Constant.TechClass, "工艺分类");
                    _productDataTypeList.Add(item);
                    item = new SystemDataType(Constant.FishClass, "鱼种分类");
                    _productDataTypeList.Add(item);

                    item = new SystemDataType(Constant.Brand, "品牌");
                    _productDataTypeList.Add(item);
                    item = new SystemDataType(Constant.packk, "包装规格");
                    _productDataTypeList.Add(item);
                    item = new SystemDataType(Constant.Origin, "产地");
                    _productDataTypeList.Add(item);

                    item = new SystemDataType(Constant.FishmealClass, "鱼粉分类");
                    _productDataTypeList.Add(item);

                    item = new SystemDataType(Constant.GoodsEvaluation, "品质评判");
                    _productDataTypeList.Add(item);

                    item = new SystemDataType(Constant.CheckItem, "检测项目");
                    _productDataTypeList.Add(item);

                    item = new SystemDataType(Constant.Goods, "品名");
                    _productDataTypeList.Add(item);

                    item = new SystemDataType(Constant.Specification, "品质规格");
                    _productDataTypeList.Add(item);

                    item = new SystemDataType(Constant.Manufacturers, "生产厂家");
                    _productDataTypeList.Add(item);


                    item = new SystemDataType(Constant.Warehouse, "仓库");
                    _productDataTypeList.Add(item);

                    item = new SystemDataType(Constant.port, "港口");
                    _productDataTypeList.Add(item);
                                  
                }
                return _productDataTypeList;
            }
        }

        protected static List<SystemDataType> _stateList = null;
        public static List<SystemDataType> StateList
        {
            get
            {
                if (_stateList == null)
                {
                    _stateList = new List<SystemDataType>();
                    SystemDataType item = new SystemDataType( Constant.STATE_QUOTE.ToString() ,"报盘");         
                    _stateList.Add(item);

                    item = new SystemDataType( Constant.STATE_CONFIRM.ToString() , "确盘");
                    _stateList.Add(item);

                    item = new SystemDataType( Constant.STATE_GOODS.ToString() , "现货");
                    _stateList.Add(item);

                    item = new SystemDataType(Constant.STATE_SELFBUY.ToString() , "自营");
                    _stateList.Add(item);

                    item = new SystemDataType(Constant.STATE_SELFMAKE.ToString () , "自制");
                    _stateList.Add(item);

                    item = new SystemDataType( Constant.STATE_SALEOUT.ToString () , "售完");
                    _stateList.Add(item);

                    item = new SystemDataType(Constant.STATE_FINISHED.ToString(), "成品");
                    _stateList.Add(item);

                }
                return _stateList;
            }
        }

        /// <summary>
        /// 数据字典
        /// </summary>
        public static List<DictEntity> DictList = null;

        public static PersonEntity User = null;

        public static List<FishEntity.PersonRole> Roles = null;
    }
}
