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
    /// 日 期：2022-03-11 08:28
    /// 描 述：控制器类
    /// </summary>
    [Area("BinfoManage")]
    public class WarehouseController :  BaseController
    {
        private WarehouseBLL warehouseBLL = new WarehouseBLL();

        #region 视图功能
        [AuthorizeFilter("binfo:warehouse:view")]
        public ActionResult WarehouseIndex()
        {
            return View();
        }

        public ActionResult WarehouseForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("binfo:warehouse:search")]
        public async Task<ActionResult> GetListJson(WarehouseListParam param)
        {
            TData<List<WarehouseEntity>> obj = await warehouseBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("binfo:warehouse:search")]
        public async Task<ActionResult> GetPageListJson(WarehouseListParam param, Pagination pagination)
        {
            TData<List<WarehouseEntity>> obj = await warehouseBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<WarehouseEntity> obj = await warehouseBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("binfo:warehouse:add,binfo:warehouse:edit")]
        public async Task<ActionResult> SaveFormJson(WarehouseEntity entity)
        {
            TData<string> obj = await warehouseBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("binfo:warehouse:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await warehouseBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
