using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.BinfoManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2022-03-29 21:08
    /// 描 述：实体类
    /// </summary>
    [Table("BPallet")]
    public class PalletEntity : BaseExtensionEntity
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
        [JsonConverter(typeof(StringJsonConverter))]
        public long? PalletSpecId { get; set; }
        /// <summary>
        /// 托盘状态Key
        /// </summary>
        /// <returns></returns>
        public int? PalletStatusKey { get; set; }
        /// <summary>
        /// 使用次数
        /// </summary>
        /// <returns></returns>
        public int? PalletUseCount { get; set; }
        /// <summary>
        /// 打印次数
        /// </summary>
        /// <returns></returns>
        public int? PalletPrintCount { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string PalletRemark { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        /// <returns></returns>
        public int? PalletStatus { get; set; }

        /// <summary>
        /// 托盘类型名称
        /// </summary>
        [NotMapped]
        public string PalletSpecName { get; set; }
        /// <summary>
        /// 多个Id
        /// </summary>
        [NotMapped]
        public string Ids { get; set; }
    }
}
