using System;
using System.Collections.Generic;
using System.Text;
using YaoGiAdmin.Lib;
using YaoGiAdmin.Models.Jwt;

namespace YaoGiAdmin.Business.IJwtService
{
    public interface IAuthenticateService
    {
        Response IsAuthenticated(LoginRequestDTO request, out string token);

        Response JwtDecrypt(string token);
    }
}
