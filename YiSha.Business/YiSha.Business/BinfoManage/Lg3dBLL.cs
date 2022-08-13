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
    /// 日 期：2022-06-15 21:07
    /// 描 述：业务类
    /// </summary>
    public class Lg3dBLL
    {
        private Lg3dService lg3dService = new Lg3dService();

        #region 获取数据
        public async Task<TData<List<Lg3dEntity>>> GetList(Lg3dListParam param)
        {
            TData<List<Lg3dEntity>> obj = new TData<List<Lg3dEntity>>();
            obj.Data = await lg3dService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<Lg3dEntity>>> GetPageList(Lg3dListParam param, Pagination pagination)
        {
            TData<List<Lg3dEntity>> obj = new TData<List<Lg3dEntity>>();
            obj.Data = await lg3dService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<Lg3dEntity>> GetEntity(long id)
        {
            TData<Lg3dEntity> obj = new TData<Lg3dEntity>();
            obj.Data = await lg3dService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(Lg3dEntity entity)
        {
            TData<string> obj = new TData<string>();
            await lg3dService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await lg3dService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
