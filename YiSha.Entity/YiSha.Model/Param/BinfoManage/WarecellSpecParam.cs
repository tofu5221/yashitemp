using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.BinfoManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2022-03-30 20:36
    /// 描 述：实体查询类
    /// </summary>
    public class WarecellSpecListParam
    {
        /// <summary>
        /// 货位类型编码
        /// </summary>
        /// <returns></returns>
        public string WarecellSpecCode { get; set; }
        /// <summary>
        /// 货位类型名称
        /// </summary>
        /// <returns></returns>
        public string WarecellSpecName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string WarecellSpecRemark { get; set; }
        /// <summary>
        /// 多个Id
        /// </summary>
        public string Ids { get; set; }
    }
}
