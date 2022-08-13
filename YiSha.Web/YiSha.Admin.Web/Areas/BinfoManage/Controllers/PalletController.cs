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
    /// 日 期：2022-03-29 21:08
    /// 描 述：控制器类
    /// </summary>
    [Area("BinfoManage")]
    public class PalletController :  BaseController
    {
        private PalletBLL palletBLL = new PalletBLL();

        #region 视图功能
        [AuthorizeFilter("binfo:pallet:view")]
        public ActionResult PalletIndex()
        {
            return View();
        }

        public ActionResult PalletForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("binfo:pallet:search")]
        public async Task<ActionResult> GetListJson(PalletListParam param)
        {
            TData<List<PalletEntity>> obj = await palletBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("binfo:pallet:search")]
        public async Task<ActionResult> GetPageListJson(PalletListParam param, Pagination pagination)
        {
            TData<List<PalletEntity>> obj = await palletBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<PalletEntity> obj = await palletBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("binfo:pallet:add,binfo:pallet:edit")]
        public async Task<ActionResult> SaveFormJson(PalletEntity entity)
        {
            TData<string> obj = await palletBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("binfo:pallet:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await palletBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
