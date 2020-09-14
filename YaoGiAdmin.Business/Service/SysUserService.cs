using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YaoGiAdmin.Business.IService;
using YaoGiAdmin.Lib;
using YaoGiAdmin.Models;
using YaoGiAdmin.Models.Sys;

namespace YaoGiAdmin.Business.Service
{
    public class SysUserService : ISysUserService
    {
        BuildingDbContext context;

        public SysUserService(BuildingDbContext dbContext)
        {
            context = dbContext;
        }
        public async Task<Response> RegisterUser(SysUser model)
        {
            Response res = new Response();
            try
            {
                var data = await context.SysUser.Where(m => m.UserMobile == model.UserMobile).FirstOrDefaultAsync();
                if (data != null)
                {
                    res.Code = 3;
                    res.Message = "该手机号码已经被注册";
                    return res;
                }
                model.CreateTime = DateTime.Now;
                model.UserPassword = ValueConvert.MD5(model.UserPassword);

                await context.SysUser.AddAsync(model);

                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                res.Code = 2;
                res.Message = e.Message;
            }
            return res;
        }

        public async Task<Response> UserLogin(string account, string password)
        {
            Response res = new Response();
            try
            {
                var data = await context.SysUser.Where(m => m.UserAccount == account && m.UserPassword == ValueConvert.MD5(password)).FirstOrDefaultAsync();
                if (data == null)
                {
                    res.Code = 3;
                    res.Message = "登陆失败";
                    return res;
                }
            }
            catch (Exception e)
            {
                res.Code = 2;
                res.Message = e.Message;
            }
            return res;
        }

        public bool IsValid(string account, string password)
        {
            return true;
        }
    }
}
