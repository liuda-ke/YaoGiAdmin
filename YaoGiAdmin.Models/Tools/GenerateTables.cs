using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YaoGiAdmin.Models.Common;

namespace YaoGiAdmin.Models.Tools
{
    public class GenerateTables : BaseColumnModel
    {
        [Description("表名称")]
        [Column(TypeName = "NVARCHAR(200)")]
        public string TableName { get; set; }

        [Description("表说明")]
        [Column(TypeName = "NVARCHAR(200)")]
        public string TableCNName { get; set; }

        [Description("表说明")]
        [Column(TypeName = "NVARCHAR(500)")]
        public string Descrption { get; set; }

        [Description("是否生成")]
        [Column(TypeName ="INT")]
        public int IsGenerate { get; set; }

        public IList<GenerateColumns> GenerateColumns { get; set; }
    }
}
