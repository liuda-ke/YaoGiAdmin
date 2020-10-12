using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YaoGiAdmin.Business.IService;
using YaoGiAdmin.Core;
using YaoGiAdmin.Models.Sys;
using YaoGiAdmin.Models.Tools;

namespace YaoGiAdmin.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class TablesController : ControllerBase
    {
        IGenerateTablesService _tablesService;
        public TablesController(IGenerateTablesService tablesService)
        {
            _tablesService = tablesService;
        }

        [HttpGet]
        public async Task<Response> GetTableList()
        {
            return await _tablesService.GetList();
        }
        [HttpPost]
        public async Task<Response> CreateTable([FromForm]GenerateTables model)
        {
            return await _tablesService.CreateTable(model);
        }

        public async Task<Response> RemoveTable(Guid? _tableId)
        {
            return await _tablesService.DeleteTable(_tableId);
        }



    }
}
