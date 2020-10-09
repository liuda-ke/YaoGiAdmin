using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YaoGiAdmin.Models.Sys;

namespace YaoGiAdmin.Lib
{
    public  class UserCacheHelper
    {
        private static  SysUser sysUsers = new SysUser();
        private static  UserCacheHelper _Singleton = null;
        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        public static UserCacheHelper CreateInstance()
        {
            if (_Singleton == null)
            {
                _Singleton = new UserCacheHelper();
            }
            return _Singleton;
        }

        public static void SetUser(SysUser model)
        {
            sysUsers=model;
        }

        public static SysUser GetSys()
        {
            return sysUsers;
        }
    }
}
