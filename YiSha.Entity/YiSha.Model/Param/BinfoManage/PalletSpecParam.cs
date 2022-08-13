using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.BinfoManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2022-03-29 20:19
    /// 描 述：实体查询类
    /// </summary>
    public class PalletSpecListParam
    {
        /// <summary>
        /// 托盘类型编码
        /// </summary>
        /// <returns></returns>
        public string PalletSpecCode { get; set; }
        /// <summary>
        /// 托盘类型名称
        /// </summary>
        /// <returns></returns>
        public string PalletSpecName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string PalletSpecRemark { get; set; }
        /// <summary>
        /// 多个托盘类型Id
        /// </summary>
        public string Ids { get; set; }
    }
}
