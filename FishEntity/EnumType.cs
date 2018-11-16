using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    /// <summary>
    /// 数据类型
    /// </summary>
    public enum DataTypeEnum
    {
        /// <summary>
        /// 系统数据
        /// </summary>
        SYSTEM=1,
        /// <summary>
        /// 业务数据
        /// </summary>
        BUSINESS=2
    }

    public enum ImageTypeEnum
    {
        /// <summary>
        /// 磅单图片
        /// </summary>
        Onepoundcode=5,
        CompanyThreeCard =0,
        SGS=1,
        Label=2,
        GJ=3,
        QUOTE=4,
        /// <summary>
        /// 合同
        /// </summary>
        HETONG = 5,
        /// <summary>
        /// 出库单
        /// </summary>
        CHUKUDAN = 6,
        /// <summary>
        /// 头像图片
        /// </summary>
        Header=16
    }
    /// <summary>
    /// 合同类型
    /// </summary>
    public enum ContractTypeEnum
    {
        FuturesContract=1,
        ProductContract1=2,
        ProductContract2=3
    }
    /// <summary>
    /// 合同状态
    /// </summary>
    public enum ContractStatusEnum
    {
        /// <summary>
        /// 正常状态
        /// </summary>
        NORMAL=0,
        /// <summary>
        /// 结束状态 
        /// </summary>
        FINISH=4,
    }

    class EnumType
    {
    }
}
