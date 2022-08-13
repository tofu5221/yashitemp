using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.BinfoManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2022-03-29 21:08
    /// 描 述：实体查询类
    /// </summary>
    public class PalletListParam
    {
        /// <summary>
        /// 托盘编码
        /// </summary>
        /// <returns></returns>
        public string PalletCode { get; set; }
        /// <summary>
        /// 托盘类型Id
        /// </summary>
        /// <returns></returns>
        public long? PalletSpecId { get; set; }
        /// <summary>
        /// 托盘状态Key
        /// </summary>
        /// <returns></returns>
        public int? PalletStatusKey { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string PalletRemark { get; set; }
        /// <summary>
        /// 多个托盘类型Id
        /// </summary>
        public string Ids { get; set; }
    }
}
