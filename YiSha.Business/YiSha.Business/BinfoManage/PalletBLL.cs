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
    /// 日 期：2022-03-29 21:08
    /// 描 述：业务类
    /// </summary>
    public class PalletBLL
    {
        private PalletService palletService = new PalletService();
        private PalletSpecService palletSpecService = new PalletSpecService();

        #region 获取数据
        public async Task<TData<List<PalletEntity>>> GetList(PalletListParam param)
        {
            TData<List<PalletEntity>> obj = new TData<List<PalletEntity>>();
            obj.Data = await palletService.GetList(param);

            List<PalletSpecEntity> palletSpecList = await palletSpecService.GetList(new PalletSpecListParam { Ids = obj.Data.Select(p => p.PalletSpecId.Value).ParseToStrings<long>() });
            foreach (PalletEntity pallet in obj.Data)
            {
                pallet.PalletSpecName = palletSpecList.Where(p => p.Id == pallet.PalletSpecId).Select(p => p.PalletSpecName).FirstOrDefault();
            }

            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<PalletEntity>>> GetPageList(PalletListParam param, Pagination pagination)
        {
            TData<List<PalletEntity>> obj = new TData<List<PalletEntity>>();
            obj.Data = await palletService.GetPageList(param, pagination);

            List<PalletSpecEntity> palletSpecList = await palletSpecService.GetList(new PalletSpecListParam { Ids = obj.Data.Select(p => p.PalletSpecId.Value).ParseToStrings<long>() });
            foreach (PalletEntity pallet in obj.Data)
            {
                pallet.PalletSpecName = palletSpecList.Where(p => p.Id == pallet.PalletSpecId).Select(p => p.PalletSpecName).FirstOrDefault();
            }

            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<PalletEntity>> GetEntity(long id)
        {
            TData<PalletEntity> obj = new TData<PalletEntity>();
            obj.Data = await palletService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(PalletEntity entity)
        {
            TData<string> obj = new TData<string>();
            await palletService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await palletService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
