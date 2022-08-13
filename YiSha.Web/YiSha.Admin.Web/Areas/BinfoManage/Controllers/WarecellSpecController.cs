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
    /// 日 期：2022-03-30 20:36
    /// 描 述：控制器类
    /// </summary>
    [Area("BinfoManage")]
    public class WarecellSpecController :  BaseController
    {
        private WarecellSpecBLL warecellSpecBLL = new WarecellSpecBLL();

        #region 视图功能
        [AuthorizeFilter("binfo:warecellspec:view")]
        public ActionResult WarecellSpecIndex()
        {
            return View();
        }

        public ActionResult WarecellSpecForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("binfo:warecellspec:search")]
        public async Task<ActionResult> GetListJson(WarecellSpecListParam param)
        {
            TData<List<WarecellSpecEntity>> obj = await warecellSpecBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("binfo:warecellspec:search")]
        public async Task<ActionResult> GetPageListJson(WarecellSpecListParam param, Pagination pagination)
        {
            TData<List<WarecellSpecEntity>> obj = await warecellSpecBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<WarecellSpecEntity> obj = await warecellSpecBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("binfo:warecellspec:add,binfo:warecellspec:edit")]
        public async Task<ActionResult> SaveFormJson(WarecellSpecEntity entity)
        {
            TData<string> obj = await warecellSpecBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("binfo:warecellspec:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await warecellSpecBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
