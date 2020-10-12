using System;
using System.Collections.Generic;
using System.Text;

namespace YaoGiAdmin.Models.Operators
{
    public class Operator
    {
        public static Operator Instance
        {
            get { return new Operator(); }
        }
        //private string LoginProvider = GlobalContext.Configuration.GetSection("SystemConfig:LoginProvider").Value;
        //private string TokenName = "UserToken"; //cookie name or session name
    }
}
