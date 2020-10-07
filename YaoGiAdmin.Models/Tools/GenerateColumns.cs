using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YaoGiAdmin.Models.Common;

namespace YaoGiAdmin.Models.Tools
{
    public partial class GenerateColumns : BaseColumnModel
    {
        [Column(TypeName = "NVARCHAR(200)")]
        public string ColumnName { get; set; }

        [Column(TypeName = "NVARCHAR(200)")]
        public string OldColumnName { get; set; }

        [Column(TypeName = "NVARCHAR(200)")]
        public string ColumnCnName { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string ColumnType { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string OldColumnType { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string Description { get; set; }
        
        public  GenerateTables GenerateTables { get; set; }

    }
}
