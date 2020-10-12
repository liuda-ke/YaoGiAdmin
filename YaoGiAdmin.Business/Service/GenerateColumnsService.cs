using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using YaoGiAdmin.Business.IService;
using YaoGiAdmin.Core;
using YaoGiAdmin.Models;
using YaoGiAdmin.Models.Tools;

namespace YaoGiAdmin.Business.Service
{
    public  class GenerateColumnsService : IGenerateColumnsService
    {
        BuildingDbContext context;
        public GenerateColumnsService(BuildingDbContext dbcontext)
        {
            context = dbcontext;
        }

        public async Task<Response> GetColumns(Guid? TableId)
        {
            Response res = new Response();
            try
            {
                var data = await context.GenerateColumns.Where(m => m.IsDel == 0 && m.GenerateTables.Id == TableId).ToListAsync();
                //var data1 = await context.GenerateColumns.Include(n => n.GenerateTables).Where(n=> n.GenerateTables.Id == TableId&&n.IsDel==0).ToListAsync();
                if (data == null)
                {
                    res.Code = 0;
                    res.Message = "无数据";
                    return res;
                }
                res.Data = data;
            }
            catch (Exception e)
            {
                res.Code = 2;
                res.Message = e.Message;
            }
            return res;
        }

        public async Task<Response> SetColumns(GenerateColumns models)
        {
            Response res = new Response();
            try
            {
                var tabledata = await context.GenerateTables.FirstOrDefaultAsync(m => m.Id == models.GenerateTablesId);
                if (tabledata == null)
                {
                    res.Code = 3;
                    res.Message = "该表存在无法添加字段";
                    return res;
                }
                var data = context.GenerateColumns.FirstOrDefault(m => m.ColumnName == models.ColumnName);
                if (data != null)
                {
                    res.Code = 3;
                    res.Message = "该字段已存在";
                    return res;
                }
                models.GenerateTables = tabledata;
                await context.GenerateColumns.AddAsync(models);
                await context.SaveChangesAsync();
                res.Data = models.Id;
            }
            catch (Exception e)
            {
                res.Code = 2;
                res.Message = e.Message;
            }
            return res;
        }
    }
}
