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
    /// 日 期：2022-03-29 20:19
    /// 描 述：服务类
    /// </summary>
    public class PalletSpecService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<PalletSpecEntity>> GetList(PalletSpecListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<PalletSpecEntity>> GetPageList(PalletSpecListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<PalletSpecEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<PalletSpecEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(PalletSpecEntity entity)
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
            await this.BaseRepository().Delete<PalletSpecEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<PalletSpecEntity, bool>> ListFilter(PalletSpecListParam param)
        {
            var expression = LinqExtensions.True<PalletSpecEntity>();
            if (param != null)
            {
                if (!string.IsNullOrEmpty(param.PalletSpecCode))
                {
                    expression = expression.And(t => t.PalletSpecCode.Contains(param.PalletSpecCode));
                }
                if (!string.IsNullOrEmpty(param.PalletSpecName))
                {
                    expression = expression.And(t => t.PalletSpecName.Contains(param.PalletSpecName));
                }
                if (!string.IsNullOrEmpty(param.PalletSpecRemark))
                {
                    expression = expression.And(t => t.PalletSpecRemark.Contains(param.PalletSpecRemark));
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
