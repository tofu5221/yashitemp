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
    /// 日 期：2022-03-11 11:08
    /// 描 述：区域管理控制器类
    /// </summary>
    [Area("BinfoManage")]
    public class ZoneController :  BaseController
    {
        private ZoneBLL zoneBLL = new ZoneBLL();

        #region 视图功能
        [AuthorizeFilter("binfo:zone:view")]
        public ActionResult ZoneIndex()
        {
            return View();
        }

        public ActionResult ZoneForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("binfo:zone:search")]
        public async Task<ActionResult> GetListJson(ZoneListParam param)
        {
            TData<List<ZoneEntity>> obj = await zoneBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("binfo:zone:search")]
        public async Task<ActionResult> GetPageListJson(ZoneListParam param, Pagination pagination)
        {
            TData<List<ZoneEntity>> obj = await zoneBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<ZoneEntity> obj = await zoneBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("binfo:zone:add,binfo:zone:edit")]
        public async Task<ActionResult> SaveFormJson(ZoneEntity entity)
        {
            TData<string> obj = await zoneBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("binfo:zone:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await zoneBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
