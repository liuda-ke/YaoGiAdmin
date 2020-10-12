using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YaoGiAdmin.Models.Sys;

namespace YaoGiAdmin.Models.Common
{

    /// <summary>
    /// 通用字段实体
    /// </summary>
    public class BaseColumnModel
    {
        SysUser user = new SysUser();
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(TypeName = "DATETIME")]
        [Description("创建时间")]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        [Column(TypeName = "DATETIME")]
        [Description("修改时间")]
        public DateTime ModifyTime { get; set; } = DateTime.Now;


        public SysUser SysUser { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string CreateUser{get; set;}

        [Column(TypeName = "INT")]
        [DefaultValue(0)]
        public int IsDel { get; set; } = 0;




    }
}
