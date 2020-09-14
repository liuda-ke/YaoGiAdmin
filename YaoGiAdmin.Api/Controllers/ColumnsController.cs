using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YaoGiAdmin.Business.IService;
using YaoGiAdmin.Lib;
using YaoGiAdmin.Models.Tools;

namespace YaoGiAdmin.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ColumnsController : ControllerBase
    {
        IGenerateColumnsService _generateColumn;
        public ColumnsController(IGenerateColumnsService generateColumn)
        {
            _generateColumn = generateColumn;
        }
        [HttpGet]
        public async Task<Response> GetColumn(Guid? TableId)
        {
            return await _generateColumn.GetColumns(TableId);
        }
        [HttpPost]
        public async Task<Response> SetColumns(GenerateColumns models)
        {
            return await _generateColumn.SetColumns(models);
        }
    }
}
