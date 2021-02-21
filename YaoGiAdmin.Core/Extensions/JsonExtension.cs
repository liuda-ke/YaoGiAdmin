using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YaoGiAdmin.Core.Extensions
{
    public static class JsonExtension
    {
        /// <summary>
        /// 泛型转Json字符串
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="t">泛型</param>
        /// <returns></returns>
        public static string ToJson<T>(this T t)
        {
            if (t != null)
            {
                return JsonConvert.SerializeObject(t);
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// Json字符串转实体
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="jsonStr">json字符串</param>
        /// <returns></returns>
        public static T FromJson<T>(this string jsonStr)
        {
            if (!string.IsNullOrWhiteSpace(jsonStr))
            {
                return JsonConvert.DeserializeObject<T>(jsonStr);
            }
            else
            {
                return default;
            }
        }
    }
}
