using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

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
