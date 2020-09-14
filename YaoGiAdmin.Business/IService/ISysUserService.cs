using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YaoGiAdmin.Lib;
using YaoGiAdmin.Models.Sys;

namespace YaoGiAdmin.Business.IService
{
    public interface ISysUserService
    {
        Task<Response> RegisterUser(SysUser model);

        Task<Response> UserLogin(string account, string password);
        bool IsValid(string account, string password);
    }
}
