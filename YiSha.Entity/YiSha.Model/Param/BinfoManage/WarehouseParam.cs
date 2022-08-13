using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.BinfoManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2022-03-11 08:28
    /// 描 述：实体查询类
    /// </summary>
    public class WarehouseListParam
    {
        /// <summary>
        /// 仓库编码
        /// </summary>
        /// <returns></returns>
        public string WarehouseCode { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        /// <returns></returns>
        public string WarehouseName { get; set; }
        /// <summary>
        /// 多个仓库Id
        /// </summary>
        public string Ids { get; set; }
    }
}
