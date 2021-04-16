using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YaoGiAdmin.Business.IJwtService;
using YaoGiAdmin.Business.IService;
using YaoGiAdmin.Core;
using YaoGiAdmin.Models.Jwt;
using YaoGiAdmin.Models.Sys;

namespace YaoGiAdmin.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class SysUserController : ControllerBase
    {
        ISysUserService _sysUserService;
        IAuthenticateService _authenticateService;
        public SysUserController(ISysUserService sysUserService, IAuthenticateService authenticateService)
        {
            _sysUserService = sysUserService;
            _authenticateService = authenticateService;
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
        [AllowAnonymous]
        [HttpPost]
        public async Task<Response> UserLogin([FromForm] string account, [FromForm] string password)
        {
            return await _sysUserService.UserLogin(account, password);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult ResponseToken([FromForm] LoginRequestDTO model)
        {
            Response res = new Response();
            if (!ModelState.IsValid)
            {
                res.Code = 2;
                res.Message = "验证失败";
                return BadRequest(res);
            }
            string token;
            res = _authenticateService.IsAuthenticated(model, out token);
            if (res.Code == 1)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }

        }

    }
}
