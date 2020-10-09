using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YaoGiAdmin.Business.IJwtService;
using YaoGiAdmin.Business.IService;
using YaoGiAdmin.Lib;
using YaoGiAdmin.Models;
using YaoGiAdmin.Models.Common;
using YaoGiAdmin.Models.Jwt;
using YaoGiAdmin.Models.Sys;

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
            BaseColumnModel model = new BaseColumnModel();
            model.SysUser = sys;
            if (sys == null)
            {
                res.Code = 2;
                res.Message = "该用户不存在";
                return res;
            }

            var claims = new[]
            {
                //可有可无
                //new Claim(JwtRegisteredClaimNames.Jti, sys.Id.ToString()),
                //new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString(),ClaimValueTypes.Integer64),
                //new Claim(JwtRegisteredClaimNames.Sub,sys.UserAccount),
                //new Claim(JwtRegisteredClaimNames.Sid,sys.Id.ToString()),
                //可有可无
                //new Claim(ClaimTypes.Name,sys.UserName),
                //new Claim(ClaimTypes.Email,sys.UserEmail),
                //new Claim(ClaimTypes.MobilePhone,sys.UserMobile),
                new Claim("Id",sys.Id.ToString()),
                new Claim("UserName",sys.UserName),
                new Claim("UserAccount",sys.UserAccount),
                new Claim("UserEmail",sys.UserEmail),
                new Claim("UserMobile",sys.UserMobile),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(
               issuer: _tokenManagement.Issuer,
               audience: _tokenManagement.Audience,
               claims: claims,
                expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration),
                signingCredentials: credentials);
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            var t = new JwtSecurityTokenHandler().ReadJwtToken(token);
            sys.UserPassword = "";
            var result = new { user = sys.UserName, token = token };
            res.Code = 1;
            res.Data = result;
            UserCacheHelper.SetUser(sys);

            return res;

        }
        /// <summary>
        /// 解析jwt生成token信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Response JwtDecrypt(string token)
        {
            Response response = new Response();
            var Decryptjwt = new JwtSecurityTokenHandler().ReadJwtToken(token).Payload;
            response.Code = 1;
            response.Data = Decryptjwt;
            response.Message = "成功";
            string jsonstr= JsonConvert.SerializeObject(Decryptjwt);
            SysUser sys = JsonConvert.DeserializeObject<SysUser>(jsonstr);
            return response;

        }
    }
}
