using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YaoGiAdmin.Business.IJwtService;
using YaoGiAdmin.Business.IService;
using YaoGiAdmin.Lib;
using YaoGiAdmin.Models;
using YaoGiAdmin.Models.Jwt;

namespace YaoGiAdmin.Business.JwtService
{
    public class AuthenticateService : IAuthenticateService
    {
        BuildingDbContext context;
        private readonly ISysUserService _sysUser;
        private readonly JwtToken _tokenManagement;
        public AuthenticateService(BuildingDbContext dbcontext, IOptions<JwtToken> tokenManagement, ISysUserService sysUser)
        {
            context = dbcontext;
            _tokenManagement = tokenManagement.Value;
            _sysUser = sysUser;

        }
        public Response IsAuthenticated(LoginRequestDTO request, out string token)
        {
            Response res = new Response();

            token = string.Empty;
            var sys = _sysUser.ResponseToken(request);
            if (sys == null)
            {
                res.Code = 2;
                res.Message = "该用户不存在";
                return res;
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,sys.UserAccount),
                new Claim(JwtRegisteredClaimNames.Jti, sys.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString(),ClaimValueTypes.Integer64),
                new Claim(JwtRegisteredClaimNames.Sid,sys.Id.ToString()),
               //用户名
                //new Claim(ClaimTypes.Name,request.Account),
                new Claim(ClaimTypes.Name,"你好"),
                //角色
                new Claim(ClaimTypes.Role,"a")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(_tokenManagement.Issuer, _tokenManagement.Audience, claims,
                expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration),
                signingCredentials: credentials);
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            sys.UserPassword = "";
            var result = new { user = sys.UserName, token = token };
            res.Code = 1;
            res.Data = result;
            return res;

        }
    }
}
