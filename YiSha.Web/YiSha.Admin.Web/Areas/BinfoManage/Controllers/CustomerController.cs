using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using YiSha.Util;
using YiSha.Util.Model;
using YiSha.Entity;
using YiSha.Model;
using YiSha.Admin.Web.Controllers;
using YiSha.Entity.BinfoManage;
using YiSha.Business.BinfoManage;
using YiSha.Model.Param.BinfoManage;

namespace YiSha.Admin.Web.Areas.BinfoManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2022-03-31 19:54
    /// 描 述：控制器类
    /// </summary>
    [Area("BinfoManage")]
    public class CustomerController :  BaseController
    {
        private CustomerBLL customerBLL = new CustomerBLL();

        #region 视图功能
        [AuthorizeFilter("binfo:customer:view")]
        public ActionResult CustomerIndex()
        {
            return View();
        }

        public ActionResult CustomerForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("binfo:customer:search")]
        public async Task<ActionResult> GetListJson(CustomerListParam param)
        {
            TData<List<CustomerEntity>> obj = await customerBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("binfo:customer:search")]
        public async Task<ActionResult> GetPageListJson(CustomerListParam param, Pagination pagination)
        {
            TData<List<CustomerEntity>> obj = await customerBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<CustomerEntity> obj = await customerBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("binfo:customer:add,binfo:customer:edit")]
        public async Task<ActionResult> SaveFormJson(CustomerEntity entity)
        {
            TData<string> obj = await customerBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("binfo:customer:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await customerBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
