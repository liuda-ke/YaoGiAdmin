using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YaoGiAdmin.Business.IService;
using YaoGiAdmin.Lib;
using YaoGiAdmin.Models.Sys;

namespace YaoGiAdmin.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SysUserController : ControllerBase
    {
        ISysUserService _sysUserService;
        public SysUserController(ISysUserService sysUserService)
        {
            _sysUserService = sysUserService;
        }
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Response> RegisterUser(SysUser model)
        {
            return await _sysUserService.RegisterUser(model);
        }
        [HttpPost]
        public async Task<Response> UserLogin(string account, string password)
        {
            return await _sysUserService.UserLogin(account, password);
        }
    }
}
