using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YaoGiAdmin.Models.Jwt
{
    public class LoginRequestDTO
    {
        [Required]
        public string Account { get; set; }


        [Required]
        public string Password { get; set; }
    }
}
