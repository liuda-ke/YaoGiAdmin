using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YaoGiAdmin.Models.Common;

namespace YaoGiAdmin.Models.Sys
{
    public class SysUser
    {
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(TypeName = "DATETIME")]
        [Description("创建时间")]
        public DateTime CreateTime { get; set; }

        [Column(TypeName = "INT")]
        [Description("是否删除")]
        public int IsDel { get; set; }

        [Description("用户名")]
        [Column(TypeName ="NVARCHAR(200)")]
        public string UserName { get; set; }

        [Description("用户账号")]
        [Column(TypeName = "NVARCHAR(200)")]
        public string UserAccount { get; set; }

        [Description("用户密码")]
        [Column(TypeName = "NVARCHAR(200)")]
        public string UserPassword { get; set; }

        [Description("用户邮箱")]
        [Column(TypeName = "NVARCHAR(50)")]
        public string UserEmail { get; set; }

        [Description("用户手机号")]
        [Column(TypeName = "NVARCHAR(20)")]
        public string UserMobile { get; set; }

        [Description("用户QQ号")]
        [Column(TypeName = "NVARCHAR(11)")]
        public string UserQQ { get; set; }

        [Description("用户微信")]
        [Column(TypeName = "NVARCHAR(50)")]
        public string UserWeChat { get; set; }

        [Description("用户生日")]
        [Column(TypeName = "NVARCHAR(50)")]
        public string UserBirthday { get; set; }

        [Description("用户性别")]
        [Column(TypeName = "INT")]
        public int UserGender { get; set; }

        [Description("用户头像")]
        [Column(TypeName = "NVARCHAR(200)")]
        public string UserPhoto { get; set; }

        [Description("web标识")]
        [Column(TypeName = "NVARCHAR(50)")]
        public string WebToken { get; set; }
    }
}
