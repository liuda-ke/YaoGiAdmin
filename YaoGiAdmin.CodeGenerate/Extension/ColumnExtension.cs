using System;
using System.Collections.Generic;
using System.Text;

namespace YaoGiAdmin.CodeGenerate.Extension
{
    /// <summary>
    /// 字段扩展类
    /// </summary>
    public class ColumnExtension
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// 字段类型
        /// </summary>
        public string ColumnType { get; set; }
        /// <summary>
        /// 是否是主键
        /// </summary>
        public bool IsPrimaryKey { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

    }
}
