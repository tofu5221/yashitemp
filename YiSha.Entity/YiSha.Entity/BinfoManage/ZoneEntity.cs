using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.BinfoManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2022-03-11 11:08
    /// 描 述：区域管理实体类
    /// </summary>
    [Table("BZone")]
    public class ZoneEntity : BaseExtensionEntity
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
        [JsonConverter(typeof(StringJsonConverter))]
        public long? WarehouseId { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        [NotMapped]
        public string WarehouseName { get; set; }
        /// <summary>
        /// 多个Id
        /// </summary>
        [NotMapped]
        public string Ids { get; set; }
    }
}
