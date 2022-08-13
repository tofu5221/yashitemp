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
    /// 日 期：2022-03-29 20:19
    /// 描 述：业务类
    /// </summary>
    public class PalletSpecBLL
    {
        private PalletSpecService palletSpecService = new PalletSpecService();

        #region 获取数据
        public async Task<TData<List<PalletSpecEntity>>> GetList(PalletSpecListParam param)
        {
            TData<List<PalletSpecEntity>> obj = new TData<List<PalletSpecEntity>>();
            obj.Data = await palletSpecService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<PalletSpecEntity>>> GetPageList(PalletSpecListParam param, Pagination pagination)
        {
            TData<List<PalletSpecEntity>> obj = new TData<List<PalletSpecEntity>>();
            obj.Data = await palletSpecService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<PalletSpecEntity>> GetEntity(long id)
        {
            TData<PalletSpecEntity> obj = new TData<PalletSpecEntity>();
            obj.Data = await palletSpecService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(PalletSpecEntity entity)
        {
            TData<string> obj = new TData<string>();
            await palletSpecService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await palletSpecService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
