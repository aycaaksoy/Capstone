using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AppUserDTOs
{
    public class UserLoginDTO
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "You must enter your username")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; }
        
    }
}
