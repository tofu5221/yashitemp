using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.BinfoManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2022-03-31 19:54
    /// 描 述：实体类
    /// </summary>
    [Table("BCustomer")]
    public class CustomerEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 客户编码
        /// </summary>
        /// <returns></returns>
        public string CustomerCode { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        /// <returns></returns>
        public string CustomerName { get; set; }
        /// <summary>
        /// 仓库Id
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? WarehouseId { get; set; }
        /// <summary>
        /// 是否客户
        /// </summary>
        /// <returns></returns>
        public int? IsCustomer { get; set; }
        /// <summary>
        /// 是否供应商
        /// </summary>
        /// <returns></returns>
        public int? IsSupplier { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        /// <returns></returns>
        public string CustomerAddress { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        /// <returns></returns>
        public string CustomerContacts { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        /// <returns></returns>
        public string CustomerPhoneNo { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        /// <returns></returns>
        public string CustomerEmail { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string CustomerRemark { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        /// <returns></returns>
        public int? CustomerStatus { get; set; }
    }
}
