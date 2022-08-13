using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.BinfoManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2022-03-30 21:05
    /// 描 述：实体类
    /// </summary>
    [Table("BWarecell")]
    public class WarecellEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 货位编码
        /// </summary>
        /// <returns></returns>
        public string WarecellCode { get; set; }
        /// <summary>
        /// 托盘Id
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? PalletId { get; set; }
        /// <summary>
        /// 区域Id
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? ZoneId { get; set; }
        /// <summary>
        /// 货位类型Id
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? WarecellSpecId { get; set; }
        /// <summary>
        /// 货位状态Key
        /// </summary>
        /// <returns></returns>
        public int? WarecellStatusKey { get; set; }
        /// <summary>
        /// 货位行
        /// </summary>
        /// <returns></returns>
        public int? WarecellRow { get; set; }
        /// <summary>
        /// 货位列
        /// </summary>
        /// <returns></returns>
        public int? WarecellColumn { get; set; }
        /// <summary>
        /// 货位层
        /// </summary>
        /// <returns></returns>
        public int? WarecellLayer { get; set; }
        /// <summary>
        /// 货位深度
        /// </summary>
        /// <returns></returns>
        public int? WarecellDepth { get; set; }
        /// <summary>
        /// 货位巷道
        /// </summary>
        /// <returns></returns>
        public int? WarecellWay { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string WarecellRemark { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        /// <returns></returns>
        public int? WarecellStatus { get; set; }

        /// <summary>
        /// 托盘编码
        /// </summary>
        [NotMapped]
        public string PalletCode { get; set; }
        /// <summary>
        /// 分区名称
        /// </summary>
        [NotMapped]
        public string ZoneName { get; set; }
        /// <summary>
        /// 货位类型名称
        /// </summary>
        [NotMapped]
        public string WarecellSpecName { get; set; }
    }
}
