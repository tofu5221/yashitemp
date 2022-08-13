using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.BinfoManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2022-03-11 08:28
    /// 描 述：实体类
    /// </summary>
    [Table("BWarehouse")]
    public class WarehouseEntity : BaseExtensionEntity
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
        /// 仓库地址
        /// </summary>
        /// <returns></returns>
        public string WarehouseAddress { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        /// <returns></returns>
        public int WarehouseStatus { get; set; }
        /// <summary>
        /// 多个仓库Id
        /// </summary>
        [NotMapped]
        public string Ids { get; set; }
    }
}
