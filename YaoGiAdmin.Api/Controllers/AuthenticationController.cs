using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YaoGiAdmin.Business.IJwtService;
using YaoGiAdmin.Lib;
using YaoGiAdmin.Models.Jwt;

namespace YaoGiAdmin.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticateService _authenticateService;
        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }
        [AllowAnonymous]
        public ActionResult RequestToken([FromBody] LoginRequestDTO request)
        {
            Response res = new Response();
            if (!ModelState.IsValid)
            {
                res.Code = 2;
                res.Message = "验证失败";
                return BadRequest(res);
            }

            string token;
            res = _authenticateService.IsAuthenticated(request, out token);
            if (res.Code==1)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }

        }

        [AllowAnonymous]
        [HttpGet]
        public Response JwtDecrypt(string jwtToken)
        {
            return _authenticateService.JwtDecrypt(jwtToken);
        }
    }
}
