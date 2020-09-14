using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YaoGiAdmin.Lib;
using YaoGiAdmin.Models.Tools;

namespace YaoGiAdmin.Business.IService
{
    public interface IGenerateTablesService
    {
        Task<Response> GetList();

        Task<Response> CreateTable(GenerateTables model);

        Task<Response> DeleteTable(Guid? _tableId);

    }
}
