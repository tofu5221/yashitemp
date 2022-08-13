using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.BinfoManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2022-03-11 11:08
    /// 描 述：区域管理实体查询类
    /// </summary>
    public class ZoneListParam
    {
        /// <summary>
        /// 分区编码
        /// </summary>
        /// <returns></returns>
        public string ZoneCode { get; set; }
        /// <summary>
        /// 分区名称
        /// </summary>
        /// <returns></returns>
        public string ZoneName { get; set; }
        /// <summary>
        /// 仓库Id
        /// </summary>
        /// <returns></returns>
        public long? WarehouseId { get; set; }
        /// <summary>
        /// 多个Id
        /// </summary>
        public string Ids { get; set; }
    }
}
