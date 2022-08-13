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
    /// 日 期：2022-03-30 21:05
    /// 描 述：业务类
    /// </summary>
    public class WarecellBLL
    {
        private WarecellService warecellService = new WarecellService();
        private WarecellSpecService warecellSpecService = new WarecellSpecService();
        private ZoneService zoneService = new ZoneService();
        private PalletService palletService = new PalletService();

        #region 获取数据
        public async Task<TData<List<WarecellEntity>>> GetList(WarecellListParam param)
        {
            if (!string.IsNullOrEmpty(param.PalletCode))
            {
                param.PalletIds = (await palletService.GetList(new PalletListParam { PalletCode = param.PalletCode })).Select(p => p.Id);
            }

            TData<List<WarecellEntity>> obj = new TData<List<WarecellEntity>>();
            obj.Data = await warecellService.GetList(param);

            List<WarecellSpecEntity> warecellSpecList = await warecellSpecService.GetList(new WarecellSpecListParam { Ids = obj.Data.Select(p => p.WarecellSpecId.Value).ParseToStrings<long>() });
            foreach (WarecellEntity warecell in obj.Data)
            {
                warecell.WarecellSpecName = warecellSpecList.Where(p => p.Id == warecell.WarecellSpecId).Select(p => p.WarecellSpecName).FirstOrDefault();
            }
            List<ZoneEntity> zoneList = await zoneService.GetList(new ZoneListParam { Ids = obj.Data.Select(p => p.ZoneId.Value).ParseToStrings<long>() });
            foreach (WarecellEntity warecell in obj.Data)
            {
                warecell.ZoneName = zoneList.Where(p => p.Id == warecell.ZoneId).Select(p => p.ZoneName).FirstOrDefault();
            }
            List<PalletEntity> palletList = await palletService.GetList(new PalletListParam { Ids = obj.Data.Select(p => p.PalletId.Value).ParseToStrings<long>() });
            foreach (WarecellEntity warecell in obj.Data)
            {
                warecell.PalletCode = palletList.Where(p => p.Id == warecell.PalletId).Select(p => p.PalletCode).FirstOrDefault();
            }

            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<WarecellEntity>>> GetPageList(WarecellListParam param, Pagination pagination)
        {
            if (!string.IsNullOrEmpty(param.PalletCode.Trim()))
            {
                param.PalletIds = (await palletService.GetList(new PalletListParam { PalletCode = param.PalletCode })).Select(p => p.Id);
            }

            TData<List<WarecellEntity>> obj = new TData<List<WarecellEntity>>();
            obj.Data = await warecellService.GetPageList(param, pagination);

            List<WarecellSpecEntity> warecellSpecList = await warecellSpecService.GetList(new WarecellSpecListParam { Ids = obj.Data.Select(p => p.WarecellSpecId.Value).ParseToStrings<long>() });
            foreach (WarecellEntity warecell in obj.Data)
            {
                warecell.WarecellSpecName = warecellSpecList.Where(p => p.Id == warecell.WarecellSpecId).Select(p => p.WarecellSpecName).FirstOrDefault();
            }
            List<ZoneEntity> zoneList = await zoneService.GetList(new ZoneListParam { Ids = obj.Data.Select(p => p.ZoneId.Value).ParseToStrings<long>() });
            foreach (WarecellEntity warecell in obj.Data)
            {
                warecell.ZoneName = zoneList.Where(p => p.Id == warecell.ZoneId).Select(p => p.ZoneName).FirstOrDefault();
            }
            List<PalletEntity> palletList = await palletService.GetList(new PalletListParam { Ids = obj.Data.Select(p => p.PalletId.Value).ParseToStrings<long>() });
            foreach (WarecellEntity warecell in obj.Data)
            {
                warecell.PalletCode = palletList.Where(p => p.Id == warecell.PalletId).Select(p => p.PalletCode).FirstOrDefault();
            }

            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<WarecellEntity>> GetEntity(long id)
        {
            TData<WarecellEntity> obj = new TData<WarecellEntity>();
            obj.Data = await warecellService.GetEntity(id);
            PalletEntity palletEntity = await palletService.GetEntity(obj.Data.PalletId.Value);
            if (palletEntity != null)
                obj.Data.PalletCode = palletEntity.PalletCode;
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(WarecellEntity entity)
        {
            TData<string> obj = new TData<string>();
            bool isCommit = false;
            if (string.IsNullOrEmpty(entity.PalletCode.Trim()))
            {
                entity.PalletId = 0;
                isCommit = true;
            }
            else
            {
                List<PalletEntity> palletList = await palletService.GetList(new PalletListParam { PalletCode = entity.PalletCode });
                if (palletList.Count == 1)
                {
                    entity.PalletId = palletList[0].Id;
                    isCommit = true;
                }
                else
                {
                    obj.Message = "该托盘不可用！";
                }
            }
            if(isCommit)
            {
                await warecellService.SaveForm(entity);
                obj.Data = entity.Id.ParseToString();
                obj.Tag = 1;
            }
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await warecellService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
