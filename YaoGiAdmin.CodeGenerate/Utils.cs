﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace YaoGiAdmin.CodeGenerate
{
   public class Utils
    {
        /// <summary>
        /// 类型转化
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public static string GetCsType(string dbType)
        {
            string csType = "";
            switch (dbType.ToLower())
            {
                case "varchar":
                case "varchar2":
                case "nvarchar":
                case "nvarchar2":
                case "char":
                case "nchar":
                case "text":
                case "longtext":
                case "string":
                    csType = "string";
                    break;

                case "date":
                case "datetime":
                case "smalldatetime":
                case "timestamp":
                    csType = "DateTime";
                    break;

                case "int":
                case "number":
                case "smallint":

                case "integer":
                    csType = "int";
                    break;

                case "bigint":
                    csType = "Int64";
                    break;

                case "float":
                case "numeric":
                case "decimal":
                case "money":
                case "smallmoney":
                case "real":
                case "double":
                    csType = "decimal";
                    break;
                case "tinyint":
                case "bit":
                    csType = "bool";
                    break;

                case "binary":
                case "varbinary":
                case "image":
                case "raw":
                case "long":
                case "long raw":
                case "blob":
                case "bfile":
                    csType = "byte[]";
                    break;

                case "uniqueidentifier":
                    csType = "Guid";
                    break;

                case "xml":
                case "json":
                    csType = "string";
                    break;
                default:
                    csType = "object";
                    break;
            }

            return csType;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string Save(string path, string content)
        {
            string dir = path.Substring(0, path.LastIndexOf("\\") + 1);
            if (!System.IO.Directory.Exists(dir)) System.IO.Directory.CreateDirectory(dir);
            File.WriteAllText(path, content);
            return path;
        }

        private static System.Text.RegularExpressions.Regex regSpace = new System.Text.RegularExpressions.Regex(@"\s");

        /// <summary>
        /// 去掉空格
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ReplaceSpace(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            char firstChar = value[0];
            if (firstChar >= 48 && firstChar <= 57)
            {
                value = "_" + value;
            }
            return regSpace.Replace(value.Trim(), " ");
        }

        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToUpperFirstword(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return value.Substring(0, 1).ToUpper() + value.Substring(1);

        }

        /**
        * 将下划线大写方式命名的字符串转换为驼峰式。如果转换前的下划线大写方式命名的字符串为空，则返回空字符串。</br>
        * 例如：HELLO_WORLD->HelloWorld
        * @param name 转换前的下划线大写方式命名的字符串
        * @return 转换后的驼峰式命名的字符串
*/
        /// <summary>
        /// 转换为驼峰命名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string ToCamelName(string name)
        {
            StringBuilder result = new StringBuilder();
            // 快速检查
            if (name == null || string.IsNullOrEmpty(name))
            {
                // 没必要转换
                return "";
            }
            else if (!name.Contains("_"))
            {
                // 不含下划线，仅将首字母大写
                return name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
            }
            // 用下划线将原始字符串分割
            string[] camels = name.Split('_');
            foreach (string camel in camels)
            {
                // 跳过原始字符串中开头、结尾的下换线或双重下划线
                if (string.IsNullOrEmpty(camel))
                {
                    continue;
                }
                // 处理真正的驼峰片段
                //if (result.Length == 0)
                //{
                // // 第一个驼峰片段，全部字母都小写
                // result.Append(camel.ToLower());
                //}
                //else
                //{
                // 其他的驼峰片段，首字母大写
                result.Append(camel.Substring(0, 1).ToUpper());
                result.Append(camel.Substring(1).ToLower());
                //}
            }
            return result.ToString();
        }
    }
}

