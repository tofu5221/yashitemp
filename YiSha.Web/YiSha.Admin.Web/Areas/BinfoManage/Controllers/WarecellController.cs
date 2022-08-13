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
    /// 日 期：2022-03-30 21:05
    /// 描 述：控制器类
    /// </summary>
    [Area("BinfoManage")]
    public class WarecellController :  BaseController
    {
        private WarecellBLL warecellBLL = new WarecellBLL();

        #region 视图功能
        [AuthorizeFilter("binfo:warecell:view")]
        public ActionResult WarecellIndex()
        {
            return View();
        }

        public ActionResult WarecellForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("binfo:warecell:search")]
        public async Task<ActionResult> GetListJson(WarecellListParam param)
        {
            TData<List<WarecellEntity>> obj = await warecellBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("binfo:warecell:search")]
        public async Task<ActionResult> GetPageListJson(WarecellListParam param, Pagination pagination)
        {
            TData<List<WarecellEntity>> obj = await warecellBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<WarecellEntity> obj = await warecellBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("binfo:warecell:add,binfo:warecell:edit")]
        public async Task<ActionResult> SaveFormJson(WarecellEntity entity)
        {
            TData<string> obj = await warecellBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("binfo:warecell:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await warecellBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
