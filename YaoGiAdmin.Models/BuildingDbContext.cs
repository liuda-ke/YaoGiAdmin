using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YaoGiAdmin.Models.Sys;
using YaoGiAdmin.Models.Tools;

namespace YaoGiAdmin.Models
{
    public class BuildingDbContext:DbContext
    {
        public BuildingDbContext(DbContextOptions<BuildingDbContext> options) : base(options)
        {

        }
        /// <summary>
        /// 用户表
        /// </summary>
        public DbSet<SysUser> SysUser { get; set; }
        /// <summary>
        /// 表管理
        /// </summary>
        public DbSet<GenerateTables> GenerateTables { get; set; }
        /// <summary>
        /// 表字段管理
        /// </summary>
        public DbSet<GenerateColumns> GenerateColumns { get; set; }

    }
}
