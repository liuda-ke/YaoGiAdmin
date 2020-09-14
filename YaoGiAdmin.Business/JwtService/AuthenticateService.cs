using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YaoGiAdmin.Business.IJwtService;
using YaoGiAdmin.Business.IService;
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
        public bool IsAuthenticated(LoginRequestDTO request, out string token)
        {


            token = string.Empty;
            if (!_sysUser.IsValid(request.Username, request.Password))
                return false;
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.Username)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(_tokenManagement.Issuer, _tokenManagement.Audience, claims,
                expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration),
                signingCredentials: credentials);
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return true;

        }
    }
}
