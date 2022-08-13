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
    /// 日 期：2022-03-11 08:28
    /// 描 述：服务类
    /// </summary>
    public class WarehouseService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<WarehouseEntity>> GetList(WarehouseListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<WarehouseEntity>> GetPageList(WarehouseListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<WarehouseEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<WarehouseEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(WarehouseEntity entity)
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
            await this.BaseRepository().Delete<WarehouseEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<WarehouseEntity, bool>> ListFilter(WarehouseListParam param)
        {
            var expression = LinqExtensions.True<WarehouseEntity>();
            if (param != null)
            {
                if (!string.IsNullOrEmpty(param.WarehouseCode))
                {
                    expression = expression.And(t => t.WarehouseCode.Contains(param.WarehouseCode));
                }
                if (!string.IsNullOrEmpty(param.WarehouseName))
                {
                    expression = expression.And(t => t.WarehouseName.Contains(param.WarehouseName));
                }
                if (!string.IsNullOrEmpty(param.Ids))
                {
                    long[] idArr = TextHelper.SplitToArray<long>(param.Ids, ',');
                    expression = expression.And(t => idArr.Contains(t.Id.Value));
                }
            }
            return expression;
        }
        #endregion
    }
}
