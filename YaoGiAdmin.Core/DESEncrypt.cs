using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace YaoGiAdmin.Core
{
    /// <summary>
    /// 加密/解密
    /// </summary>
    public static class DESEncrypt
    {
        //8位字符的密钥字符串
        private static string key = "qiaogsxm";

        //8位字符的初始化向量字符串
        private static string iv = "qiaofangsxm";

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="data">加密数据</param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static string DESEncryptMI(this string data)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="data">解密数据</param>
        /// <returns></returns>
        public static string DESDecryptMI(this string data)
        {
            if (String.IsNullOrEmpty(data))
            {
                return null;
            }

            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);

            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(data);
            }
            catch
            {
                return null;
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }


        /// <summary>
        /// md532大写加密，不加盐
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string MD5Encrypt32(this string password)
        {
            string pwd = string.Empty;

            //实例化一个md5对像
            MD5 md5 = MD5.Create();

            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                if (s[i] <= 15)
                {
                    pwd = pwd + "0" + s[i].ToString("X");
                }
                else
                {
                    pwd = pwd + s[i].ToString("X");
                }

            }

            return pwd;
        }

        /// <summary> 
        /// MD5盐值加密 
        /// </summary> 
        /// <param name="rawPass">源字符串</param> 
        /// <param name="salt">盐值</param> 
        /// <returns>加密后字符串</returns> 
        public static string MD5Encoding(this string rawPass, object salt)
        {
            if (salt == null) return rawPass;
            return MD5Encrypt32(rawPass + "{" + salt.ToString() + "}");
        }
    }
}
