using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YaoGiAdmin.Core;
using YaoGiAdmin.Models.Tools;

namespace YaoGiAdmin.Business.IService
{
    public interface IGenerateColumnsService
    {
        Task<Response> GetColumns(Guid? TableId);

        Task<Response> SetColumns(GenerateColumns models);
    }
}
