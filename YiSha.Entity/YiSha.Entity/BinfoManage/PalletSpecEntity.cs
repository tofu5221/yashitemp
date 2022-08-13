using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.BinfoManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2022-03-29 20:19
    /// 描 述：实体类
    /// </summary>
    [Table("BPalletSpec")]
    public class PalletSpecEntity : BaseExtensionEntity
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
        /// 长度
        /// </summary>
        /// <returns></returns>
        public string PalletSpecLenght { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        /// <returns></returns>
        public string PalletSpecWidth { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        /// <returns></returns>
        public string PalletSpecHeight { get; set; }
        /// <summary>
        /// 容量
        /// </summary>
        /// <returns></returns>
        public string PalletSpecVolume { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string PalletSpecRemark { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        /// <returns></returns>
        public int? PalletSpecStatus { get; set; }
        /// <summary>
        /// 多个托盘类型Id
        /// </summary>
        [NotMapped]
        public string Ids { get; set; }
    }
}
