using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Entity.BinfoManage;
using YiSha.Model.Param.BinfoManage;
using YiSha.Service.BinfoManage;

namespace YiSha.Business.BinfoManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2022-03-31 19:54
    /// 描 述：业务类
    /// </summary>
    public class CustomerBLL
    {
        private CustomerService customerService = new CustomerService();

        #region 获取数据
        public async Task<TData<List<CustomerEntity>>> GetList(CustomerListParam param)
        {
            TData<List<CustomerEntity>> obj = new TData<List<CustomerEntity>>();
            obj.Data = await customerService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<CustomerEntity>>> GetPageList(CustomerListParam param, Pagination pagination)
        {
            TData<List<CustomerEntity>> obj = new TData<List<CustomerEntity>>();
            obj.Data = await customerService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<CustomerEntity>> GetEntity(long id)
        {
            TData<CustomerEntity> obj = new TData<CustomerEntity>();
            obj.Data = await customerService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(CustomerEntity entity)
        {
            TData<string> obj = new TData<string>();
            await customerService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await customerService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
