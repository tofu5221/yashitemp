using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.BinfoManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2022-03-30 20:36
    /// 描 述：实体类
    /// </summary>
    [Table("BWarecellSpec")]
    public class WarecellSpecEntity : BaseExtensionEntity
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
        /// 长度
        /// </summary>
        /// <returns></returns>
        public string WarecellSpecLenght { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        /// <returns></returns>
        public string WarecellSpecWidth { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        /// <returns></returns>
        public string WarecellSpecHeight { get; set; }
        /// <summary>
        /// 容量
        /// </summary>
        /// <returns></returns>
        public string WarecellSpecVolume { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string WarecellSpecRemark { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        /// <returns></returns>
        public int? WarecellSpecStatus { get; set; }
        /// <summary>
        /// 多个Id
        /// </summary>
        [NotMapped]
        public string Ids { get; set; }
    }
}
