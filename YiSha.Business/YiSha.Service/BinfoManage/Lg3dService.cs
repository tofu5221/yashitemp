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
    /// 日 期：2022-06-15 21:07
    /// 描 述：服务类
    /// </summary>
    public class Lg3dService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<Lg3dEntity>> GetList(Lg3dListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<Lg3dEntity>> GetPageList(Lg3dListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<Lg3dEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<Lg3dEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(Lg3dEntity entity)
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
            await this.BaseRepository().Delete<Lg3dEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<Lg3dEntity, bool>> ListFilter(Lg3dListParam param)
        {
            var expression = LinqExtensions.True<Lg3dEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
