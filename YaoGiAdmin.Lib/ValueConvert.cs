using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace YaoGiAdmin.Lib
{
    public static class ValueConvert
    {
        public static string MD5(this string str)
        {
            string result;
            if (string.IsNullOrEmpty(str))
            {
                result = string.Empty;
            }
            else
            {
                MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                byte[] bytes = Encoding.Default.GetBytes(str);
                byte[] value = mD5CryptoServiceProvider.ComputeHash(bytes);
                str = BitConverter.ToString(value);
                result = str;
            }
            return result;
        }

        public static string Path(this string str, string path)
        {
            int num = str.LastIndexOf('\\');
            int startIndex = str.LastIndexOf('.');
            return str.Substring(0, num + 1) + path + str.Substring(startIndex);
        }

        public static List<string> ToList(this string ids)
        {
            List<string> list = new List<string>();
            if (!string.IsNullOrEmpty(ids))
            {
                SortedSet<string> sortedSet = new SortedSet<string>(ids.Split(new char[]
                {
                    ','
                }));
                foreach (string current in sortedSet)
                {
                    list.Add(current);
                }
            }
            return list;
        }

        public static List<string> GetIdSort(this string ids)
        {
            List<string> list = new List<string>();
            if (!string.IsNullOrEmpty(ids))
            {
                SortedSet<string> sortedSet = new SortedSet<string>(from w in ids.Split(new char[]
                {
                    '^'
                })
                                                                    where !string.IsNullOrWhiteSpace(w) && w.Contains('&')
                                                                    select w into s
                                                                    select s.Substring(0, s.IndexOf('&')));
                foreach (string current in sortedSet)
                {
                    list.Add(current);
                }
            }
            return list;
        }

        public static string GetId(this string ids)
        {
            string result;
            if (!string.IsNullOrEmpty(ids))
            {
                SortedSet<string> sortedSet = new SortedSet<string>(from w in ids.Split(new char[]
                {
                    '^'
                })
                                                                    where !string.IsNullOrWhiteSpace(w) && w.Contains('&')
                                                                    select w into s
                                                                    select s.Substring(0, s.IndexOf('&')));
                foreach (string current in sortedSet)
                {
                    if (!string.IsNullOrWhiteSpace(current))
                    {
                        result = current;
                        return result;
                    }
                }
            }
            result = null;
            return result;
        }

        public static Dictionary<string, string> StringToDictionary(string value)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string[] array = value.Split(new char[]
            {
                '^'
            });
            for (int i = 0; i < array.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(array[i]) && !array[i].Contains("undefined"))
                {
                    string[] array2 = array[i].Split(new char[]
                    {
                        '&'
                    });
                    if (!string.IsNullOrEmpty(array2[0]) && !string.IsNullOrEmpty(array2[1]))
                    {
                        dictionary.Add(array2[0], array2[1]);
                    }
                }
            }
            return dictionary;
        }

        public static int GetInt(this object Value)
        {
            return Value.GetInt(0);
        }

        public static int GetInt(this object Value, int defaultValue)
        {
            int result;
            if (Value == null)
            {
                result = defaultValue;
            }
            else if (Value is string && !Value.GetString().HasValue())
            {
                result = defaultValue;
            }
            else if (Value is DBNull)
            {
                result = defaultValue;
            }
            else if (!(Value is string) && Value is IConvertible)
            {
                result = (Value as IConvertible).ToInt32(CultureInfo.CurrentCulture);
            }
            else
            {
                int num = defaultValue;
                if (int.TryParse(Value.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out num))
                {
                    result = num;
                }
                else
                {
                    result = defaultValue;
                }
            }
            return result;
        }

        public static string GetString(this object Value)
        {
            return Value.GetString(string.Empty);
        }

        public static string GetString(this object Value, string defaultValue)
        {
            string result;
            if (Value == null)
            {
                result = defaultValue;
            }
            else
            {
                string text = defaultValue;
                try
                {
                    string text2 = Value as string;
                    if (text2 != null)
                    {
                        result = text2;
                        return result;
                    }
                    char[] array = Value as char[];
                    if (array != null)
                    {
                        result = new string(array);
                        return result;
                    }
                    text = Value.ToString();
                }
                catch
                {
                    result = defaultValue;
                    return result;
                }
                result = text;
            }
            return result;
        }

        public static DateTime GetDateTime(this object Value)
        {
            return Value.GetDateTime(DateTime.MinValue);
        }

        public static DateTime GetDateTime(this object Value, DateTime defaultValue)
        {
            DateTime result;
            if (Value == null)
            {
                result = defaultValue;
            }
            else if (Value is DBNull)
            {
                result = defaultValue;
            }
            else
            {
                string text = Value as string;
                if (text == null && Value is IConvertible)
                {
                    result = (Value as IConvertible).ToDateTime(CultureInfo.CurrentCulture);
                }
                else
                {
                    if (text != null)
                    {
                        text = text.Replace("年", "-").Replace("月", "-").Replace("日", "-").Replace("点", ":").Replace("时", ":").Replace("分", ":").Replace("秒", ":");
                    }
                    DateTime dateTime = defaultValue;
                    if (DateTime.TryParse(Value.GetString(), out dateTime))
                    {
                        result = dateTime;
                    }
                    else
                    {
                        result = defaultValue;
                    }
                }
            }
            return result;
        }

        public static bool GetBool(this object Value)
        {
            return Value.GetBool(false);
        }

        public static bool GetBool(this object Value, bool defaultValue)
        {
            bool result;
            if (Value == null)
            {
                result = defaultValue;
            }
            else if (Value is string && !Value.GetString().HasValue())
            {
                result = defaultValue;
            }
            else
            {
                if (!(Value is string) && Value is IConvertible)
                {
                    if (Value is DBNull)
                    {
                        result = defaultValue;
                        return result;
                    }
                    try
                    {
                        result = (Value as IConvertible).ToBoolean(CultureInfo.CurrentCulture);
                        return result;
                    }
                    catch
                    {
                    }
                }
                if (Value is string)
                {
                    if (Value.GetString() == "0")
                    {
                        result = false;
                        return result;
                    }
                    if (Value.GetString() == "1")
                    {
                        result = true;
                        return result;
                    }
                    if (Value.GetString().ToLower() == "yes")
                    {
                        result = true;
                        return result;
                    }
                    if (Value.GetString().ToLower() == "no")
                    {
                        result = false;
                        return result;
                    }
                }
                bool flag = defaultValue;
                if (bool.TryParse(Value.GetString(), out flag))
                {
                    result = flag;
                }
                else
                {
                    result = defaultValue;
                }
            }
            return result;
        }

        public static Guid GetGuid(string GuidValue)
        {
            Guid result;
            try
            {
                result = new Guid(GuidValue);
            }
            catch
            {
                result = Guid.Empty;
            }
            return result;
        }

        public static bool HasValue(this string Value)
        {
            return Value != null && !string.IsNullOrEmpty(Value.ToString());
        }
    }
}
