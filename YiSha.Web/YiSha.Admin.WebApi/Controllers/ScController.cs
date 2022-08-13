using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using YiSha.Util.Model;
//using YiSha.Entity.BinfoManage;
using YiSha.Business.BinfoManage;
//using YiSha.Model.Param.BinfoManage;
using YiSha.Model.Result;

namespace YiSha.Admin.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [AuthorizeFilter]
    public class ScController : ControllerBase
    {
        private ScBLL scBLL = new ScBLL();

        #region 获取数据
        [HttpGet]
        public async Task<TData<List<ScInfo>>> GetList([FromQuery] string no)
        {
            TData<List<ScInfo>> obj = await scBLL.GetList(no);
            return obj;
        }

        //[HttpGet]
        //public async Task<TData<List<WarecellEntity>>> GetPageList([FromQuery] WarecellListParam param, [FromQuery] Pagination pagination)
        //{
        //    TData<List<WarecellEntity>> obj = await warecellBLL.GetPageList(param, pagination);
        //    return obj;
        //}

        //[HttpGet]
        //public async Task<TData<WarecellEntity>> GetForm([FromQuery] long id)
        //{
        //    TData<WarecellEntity> obj = await warecellBLL.GetEntity(id);
        //    return obj;
        //}
        #endregion
    }
}
