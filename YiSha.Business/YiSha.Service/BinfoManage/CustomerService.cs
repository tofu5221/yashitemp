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
    /// 日 期：2022-03-31 19:54
    /// 描 述：服务类
    /// </summary>
    public class CustomerService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<CustomerEntity>> GetList(CustomerListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<CustomerEntity>> GetPageList(CustomerListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<CustomerEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<CustomerEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(CustomerEntity entity)
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
            await this.BaseRepository().Delete<CustomerEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<CustomerEntity, bool>> ListFilter(CustomerListParam param)
        {
            var expression = LinqExtensions.True<CustomerEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
