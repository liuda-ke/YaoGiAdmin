using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YaoGiAdmin.Core;
using YaoGiAdmin.Models.Jwt;
using YaoGiAdmin.Models.Sys;

namespace YaoGiAdmin.Business.IService
{
    public interface ISysUserService
    {
        Task<Response> RegisterUser(SysUser model);

        Task<Response> UserLogin(string account, string password);

        SysUser ResponseToken(LoginRequestDTO model);
    }
}
