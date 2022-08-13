using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.BinfoManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2022-06-15 21:07
    /// 描 述：实体类
    /// </summary>
    [Table("BLg3d")]
    public class Lg3dEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Lg3dCode { get; set; }
    }
}
