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
    /// 日 期：2022-03-30 20:36
    /// 描 述：服务类
    /// </summary>
    public class WarecellSpecService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<WarecellSpecEntity>> GetList(WarecellSpecListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<WarecellSpecEntity>> GetPageList(WarecellSpecListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<WarecellSpecEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<WarecellSpecEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(WarecellSpecEntity entity)
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
            await this.BaseRepository().Delete<WarecellSpecEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<WarecellSpecEntity, bool>> ListFilter(WarecellSpecListParam param)
        {
            var expression = LinqExtensions.True<WarecellSpecEntity>();
            if (param != null)
            {
                if (!string.IsNullOrEmpty(param.WarecellSpecCode))
                {
                    expression = expression.And(t => t.WarecellSpecCode.Contains(param.WarecellSpecCode));
                }
                if (!string.IsNullOrEmpty(param.WarecellSpecName))
                {
                    expression = expression.And(t => t.WarecellSpecName.Contains(param.WarecellSpecName));
                }
                if (!string.IsNullOrEmpty(param.WarecellSpecRemark))
                {
                    expression = expression.And(t => t.WarecellSpecRemark.Contains(param.WarecellSpecRemark));
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
