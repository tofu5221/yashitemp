using System;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Data;
using YiSha.Data.Repository;
using YiSha.Entity.BinfoManage;
using YiSha.Model.Param.BinfoManage;

namespace YiSha.Service.BinfoManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2022-03-11 11:08
    /// 描 述：区域管理服务类
    /// </summary>
    public class ZoneService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<ZoneEntity>> GetList(ZoneListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<ZoneEntity>> GetPageList(ZoneListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<ZoneEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<ZoneEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(ZoneEntity entity)
        {
            if (entity.Id.IsNullOrZero())
            {
                await entity.Create();
                await this.BaseRepository().Insert(entity);
            }
            else
            {
                await entity.Modify();
                await this.BaseRepository().Update(entity);
            }
        }

        public async Task DeleteForm(string ids)
        {
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            await this.BaseRepository().Delete<ZoneEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<ZoneEntity, bool>> ListFilter(ZoneListParam param)
        {
            var expression = LinqExtensions.True<ZoneEntity>();
            if (param != null)
            {
                if (!string.IsNullOrEmpty(param.ZoneCode))
                {
                    expression = expression.And(t => t.ZoneCode.Contains(param.ZoneCode));
                }
                if (!string.IsNullOrEmpty(param.ZoneName))
                {
                    expression = expression.And(t => t.ZoneName.Contains(param.ZoneName));
                }
                if (param.WarehouseId > -1)
                {
                    expression = expression.And(t => t.WarehouseId == param.WarehouseId);
                }
            }
            return expression;
        }
        #endregion
    }
}
