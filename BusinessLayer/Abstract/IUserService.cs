
using DTO;
using DTO.AppUserDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
       Task<AppUserResponse> ForgetPasswordAsync(string email);
       Task<AppUserResponse> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO);
        
    }
}
