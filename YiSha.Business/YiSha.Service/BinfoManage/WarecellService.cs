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
    /// 日 期：2022-03-30 21:05
    /// 描 述：服务类
    /// </summary>
    public class WarecellService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<WarecellEntity>> GetList(WarecellListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.OrderBy(p => p.WarecellCode).ToList();
        }

        public async Task<List<WarecellEntity>> GetPageList(WarecellListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<WarecellEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<WarecellEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(WarecellEntity entity)
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
            await this.BaseRepository().Delete<WarecellEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<WarecellEntity, bool>> ListFilter(WarecellListParam param)
        {
            var expression = LinqExtensions.True<WarecellEntity>();
            if (param != null)
            {
                if (!string.IsNullOrEmpty(param.WarecellCode))
                {
                    expression = expression.And(t => t.WarecellCode.Contains(param.WarecellCode));
                }
                if (param.PalletIds != null)
                {
                    expression = expression.And(t => param.PalletIds.Contains(t.PalletId.Value));
                }
                if (param.WarecellRow != null)
                {
                    expression = expression.And(t => t.WarecellRow == param.WarecellRow);
                }
                if (param.WarecellColumn != null)
                {
                    expression = expression.And(t => t.WarecellColumn == param.WarecellColumn);
                }
                if (param.WarecellLayer != null)
                {
                    expression = expression.And(t => t.WarecellLayer == param.WarecellLayer);
                }
                if (param.WarecellDepth != null)
                {
                    expression = expression.And(t => t.WarecellDepth == param.WarecellDepth);
                }
                if (param.WarecellWay != null)
                {
                    expression = expression.And(t => t.WarecellWay == param.WarecellWay);
                }

                if (!string.IsNullOrEmpty(param.WarecellRemark))
                {
                    expression = expression.And(t => t.WarecellRemark.Contains(param.WarecellRemark));
                }
                if (param.WarecellSpecId > -1)
                {
                    expression = expression.And(t => t.WarecellSpecId == param.WarecellSpecId);
                }
                if (param.ZoneId > -1)
                {
                    expression = expression.And(t => t.ZoneId == param.ZoneId);
                }
                if (param.WarecellStatusKey > -1)
                {
                    expression = expression.And(t => t.WarecellStatusKey == param.WarecellStatusKey);
                }
                if (param.WarecellStatus > -1)
                {
                    expression = expression.And(t => t.WarecellStatus == param.WarecellStatus);
                }
            }
            return expression;
        }
        #endregion
    }
}
