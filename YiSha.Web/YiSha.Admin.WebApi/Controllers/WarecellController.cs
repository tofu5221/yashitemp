using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using YiSha.Util.Model;
using YiSha.Entity.BinfoManage;
using YiSha.Business.BinfoManage;
using YiSha.Model.Param.BinfoManage;

namespace YiSha.Admin.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [AuthorizeFilter]
    public class WarecellController : ControllerBase
    {
        private WarecellBLL warecellBLL = new WarecellBLL();

        #region 获取数据
        [HttpGet]
        public async Task<TData<List<WarecellEntity>>> GetList([FromQuery] WarecellListParam param)
        {
            TData<List<WarecellEntity>> obj = await warecellBLL.GetList(param);
            return obj;
        }

        [HttpGet]
        public async Task<TData<List<WarecellEntity>>> GetPageList([FromQuery] WarecellListParam param, [FromQuery] Pagination pagination)
        {
            TData<List<WarecellEntity>> obj = await warecellBLL.GetPageList(param, pagination);
            return obj;
        }

        [HttpGet]
        public async Task<TData<WarecellEntity>> GetForm([FromQuery] long id)
        {
            TData<WarecellEntity> obj = await warecellBLL.GetEntity(id);
            return obj;
        }
        #endregion
    }
}
