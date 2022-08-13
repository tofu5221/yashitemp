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
    /// 日 期：2022-03-11 11:08
    /// 描 述：区域管理业务类
    /// </summary>
    public class ZoneBLL
    {
        private ZoneService zoneService = new ZoneService();
        private WarehouseService warehouseService = new WarehouseService();

        #region 获取数据
        public async Task<TData<List<ZoneEntity>>> GetList(ZoneListParam param)
        {
            TData<List<ZoneEntity>> obj = new TData<List<ZoneEntity>>();
            obj.Data = await zoneService.GetList(param);

            List<WarehouseEntity> warehouseList = await warehouseService.GetList(new WarehouseListParam { Ids = obj.Data.Select(p => p.WarehouseId.Value).ParseToStrings<long>() });
            foreach (ZoneEntity zone in obj.Data)
            {
                zone.WarehouseName = warehouseList.Where(p => p.Id == zone.WarehouseId).Select(p => p.WarehouseName).FirstOrDefault();
            }

            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<ZoneEntity>>> GetPageList(ZoneListParam param, Pagination pagination)
        {
            TData<List<ZoneEntity>> obj = new TData<List<ZoneEntity>>();
            obj.Data = await zoneService.GetPageList(param, pagination);

            List<WarehouseEntity> warehouseList = await warehouseService.GetList(new WarehouseListParam { Ids = obj.Data.Select(p => p.WarehouseId.Value).ParseToStrings<long>() });
            foreach (ZoneEntity zone in obj.Data)
            {
                zone.WarehouseName = warehouseList.Where(p => p.Id == zone.WarehouseId).Select(p => p.WarehouseName).FirstOrDefault();
            }

            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<ZoneEntity>> GetEntity(long id)
        {
            TData<ZoneEntity> obj = new TData<ZoneEntity>();
            obj.Data = await zoneService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(ZoneEntity entity)
        {
            TData<string> obj = new TData<string>();
            await zoneService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await zoneService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
