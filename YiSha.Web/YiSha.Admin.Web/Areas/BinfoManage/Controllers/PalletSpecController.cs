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
    /// 日 期：2022-03-29 20:19
    /// 描 述：控制器类
    /// </summary>
    [Area("BinfoManage")]
    public class PalletSpecController :  BaseController
    {
        private PalletSpecBLL palletSpecBLL = new PalletSpecBLL();

        #region 视图功能
        [AuthorizeFilter("binfo:palletspec:view")]
        public ActionResult PalletSpecIndex()
        {
            return View();
        }

        public ActionResult PalletSpecForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("binfo:palletspec:search")]
        public async Task<ActionResult> GetListJson(PalletSpecListParam param)
        {
            TData<List<PalletSpecEntity>> obj = await palletSpecBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("binfo:palletspec:search")]
        public async Task<ActionResult> GetPageListJson(PalletSpecListParam param, Pagination pagination)
        {
            TData<List<PalletSpecEntity>> obj = await palletSpecBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<PalletSpecEntity> obj = await palletSpecBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("binfo:palletspec:add,binfo:palletspec:edit")]
        public async Task<ActionResult> SaveFormJson(PalletSpecEntity entity)
        {
            TData<string> obj = await palletSpecBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("binfo:palletspec:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await palletSpecBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
