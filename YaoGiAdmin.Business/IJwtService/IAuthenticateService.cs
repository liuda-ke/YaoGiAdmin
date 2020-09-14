using System;
using System.Collections.Generic;
using System.Text;
using YaoGiAdmin.Models.Jwt;

namespace YaoGiAdmin.Business.IJwtService
{
    public interface IAuthenticateService
    {
        bool IsAuthenticated(LoginRequestDTO request, out string token);
    }
}
