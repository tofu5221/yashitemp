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
    /// 日 期：2022-03-29 21:08
    /// 描 述：服务类
    /// </summary>
    public class PalletService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<PalletEntity>> GetList(PalletListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<PalletEntity>> GetPageList(PalletListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<PalletEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<PalletEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(PalletEntity entity)
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
            await this.BaseRepository().Delete<PalletEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<PalletEntity, bool>> ListFilter(PalletListParam param)
        {
            var expression = LinqExtensions.True<PalletEntity>();
            if (param != null)
            {
                if (!string.IsNullOrEmpty(param.PalletCode))
                {
                    expression = expression.And(t => t.PalletCode.Contains(param.PalletCode));
                }
                if (!string.IsNullOrEmpty(param.PalletRemark))
                {
                    expression = expression.And(t => t.PalletRemark.Contains(param.PalletRemark));
                }
                if (param.PalletSpecId > -1)
                {
                    expression = expression.And(t => t.PalletSpecId == param.PalletSpecId);
                }
                if (param.PalletStatusKey > -1)
                {
                    expression = expression.And(t => t.PalletStatusKey == param.PalletStatusKey);
                }
            }
            return expression;
        }
        #endregion
    }
}
