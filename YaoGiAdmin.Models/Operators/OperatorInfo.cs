using System;
using System.Collections.Generic;
using System.Text;

namespace YaoGiAdmin.Models.Operators
{
    public class OperatorInfo
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }

        public int IsDel { get; set; }

        public string UserName { get; set; }

        public string UserAccount { get; set; }

        public string UserEmail { get; set; }

        public string UserMobile { get; set; }

        public string UserQQ { get; set; }

        public string UserWeChat { get; set; }

        public string UserBirthday { get; set; }

        public int UserGender { get; set; }

        public string UserPhoto { get; set; }

        public string WebToken { get; set; }
    }
}
