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
    /// 日 期：2022-06-15 21:07
    /// 描 述：控制器类
    /// </summary>
    [Area("BinfoManage")]
    public class Lg3dController :  BaseController
    {
        private Lg3dBLL lg3dBLL = new Lg3dBLL();

        #region 视图功能
        [AuthorizeFilter("binfo:lg3d:view")]
        public ActionResult Lg3dIndex()
        {
            return View();
        }

        public ActionResult Lg3dForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("binfo:lg3d:search")]
        public async Task<ActionResult> GetListJson(Lg3dListParam param)
        {
            TData<List<Lg3dEntity>> obj = await lg3dBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("binfo:lg3d:search")]
        public async Task<ActionResult> GetPageListJson(Lg3dListParam param, Pagination pagination)
        {
            TData<List<Lg3dEntity>> obj = await lg3dBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<Lg3dEntity> obj = await lg3dBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("binfo:lg3d:add,binfo:lg3d:edit")]
        public async Task<ActionResult> SaveFormJson(Lg3dEntity entity)
        {
            TData<string> obj = await lg3dBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("binfo:lg3d:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await lg3dBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
