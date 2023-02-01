using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.AppUserDTOs
{
    public class UserRegisterDTO
    {
        [Required(ErrorMessage = "You must enter your username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "You must enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter your surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Enter your E-mail address")]
        [EmailAddress(ErrorMessage = "You must enter a valid E-mail address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        
        public string Password { get; set; }

        [Required(ErrorMessage = "Retype your password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
