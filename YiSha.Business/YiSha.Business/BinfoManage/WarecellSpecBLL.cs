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
    /// 日 期：2022-03-30 20:36
    /// 描 述：业务类
    /// </summary>
    public class WarecellSpecBLL
    {
        private WarecellSpecService warecellSpecService = new WarecellSpecService();

        #region 获取数据
        public async Task<TData<List<WarecellSpecEntity>>> GetList(WarecellSpecListParam param)
        {
            TData<List<WarecellSpecEntity>> obj = new TData<List<WarecellSpecEntity>>();
            obj.Data = await warecellSpecService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<WarecellSpecEntity>>> GetPageList(WarecellSpecListParam param, Pagination pagination)
        {
            TData<List<WarecellSpecEntity>> obj = new TData<List<WarecellSpecEntity>>();
            obj.Data = await warecellSpecService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<WarecellSpecEntity>> GetEntity(long id)
        {
            TData<WarecellSpecEntity> obj = new TData<WarecellSpecEntity>();
            obj.Data = await warecellSpecService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(WarecellSpecEntity entity)
        {
            TData<string> obj = new TData<string>();
            await warecellSpecService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await warecellSpecService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
