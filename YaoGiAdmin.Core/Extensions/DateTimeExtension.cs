using System;
using System.Collections.Generic;
using System.Text;

namespace YaoGiAdmin.Core.Extensions
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// 将日期字符串转为时间
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="timestr"></param>
        /// <returns></returns>
        public static DateTime FromDateTime<T>(this string timeStr)
        {
            if (!string.IsNullOrWhiteSpace(timeStr))
            {
                DateTime dt = new DateTime();
                bool flag = DateTime.TryParse(timeStr, out dt);
                if (flag)
                {
                    return dt;
                }
                else
                {
                    return default;
                }
            }
            else
            {
                return default;
            }
        }
        /// <summary>
        /// 将日期转为yyyy-MM-dd HH:mm:ss时间格式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="timestr"></param>
        /// <returns></returns>
        public static string FromDateTime<T>(this DateTime timeStr)
        {
            if (timeStr != DateTime.MinValue)
            {
                return timeStr.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                return default;
            }
        }



    }
}
