using BusinessLayer.Abstract;
using DTO;
using DTO.AppUserDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLayer.Concrete
{
    public class UserService:IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        
        public UserService(UserManager<AppUser> userManager, IConfiguration configuration, IEmailService emailService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _emailService = emailService;
        }               
        public async Task<AppUser> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return new AppUserResponse
                {
                    IsSuccess = false,
                    Message = "User not found"
                };

            var decodedToken = WebEncoders.Base64UrlDecode(token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ConfirmEmailAsync(user, normalToken);

            if (result.Succeeded)
                return new AppUserResponse
                {
                    Message = "Email confirmed successfully!",
                    IsSuccess = true,
                };

            return new AppUserResponse
            {
                IsSuccess = false,
                Message = "Error, email is not confirmed!",
                Errors = result.Errors.Select(x => x.Description)
            };
        }
        public async Task<string> CreateResetPasswordToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var validToken = HttpUtility.UrlEncode(token);

            return validToken;
        }
        public async Task<AppUser> SendConfirmationEmailAsync(AppUser appUser)
        {
            var confirmEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);

            var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
            var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);

            string url = $"{_configuration["AppUrl"]}/api/auth/confirmemail?userid={appUser.Id}&token={validEmailToken}";

            await _emailService.SendEmailAsync(appUser.Email, "Confirm your email", $"<h1>Welcome to Auth Demo</h1>" +
                $"<p>Please confirm your email by <a href='{url}'>Clicking here</a></p>");


            return new AppUserResponse
            {
                Message = "User created successfully!",
                IsSuccess = true,
            };
        }
        public async Task<AppUserResponse> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordDTO.Email);
            if (user == null)
                return new AppUserResponse
                {
                    IsSuccess = false,
                    Message = "No user associated with email",
                };

            if (resetPasswordDTO.NewPassword != resetPasswordDTO.ConfirmPassword)
                return new AppUserResponse
                {
                    IsSuccess = false,
                    Message = "Password doesn't match its confirmation",
                };

            var decodedToken = WebEncoders.Base64UrlDecode(resetPasswordDTO.Token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ResetPasswordAsync(user, normalToken, resetPasswordDTO.NewPassword);

            if (result.Succeeded)
                return new AppUserResponse
                {
                    Message = "Password has been reset successfully!",
                    IsSuccess = true,
                };

            return new AppUserResponse
            {
                Message = "Something went wrong",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description),
            };
        }

        public async Task<AppUserResponse> ForgetPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return new AppUserResponse
                {
                    IsSuccess = false,
                    Message = "No user associated with email",
                };

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"{_configuration["AppUrl"]}/ResetPassword?email={email}&token={validToken}";
            
            await _emailService.SendEmailAsync(email, "Reset Password", "<h1>Follow the instructions to reset your password</h1>" +
                $"<p>To reset your password <a href='{url}'>Click here</a></p>");

            return new AppUserResponse
            {
                IsSuccess = true,
                Message = "Reset password URL has been sent to the email successfully!"
            };
        }
    }
}
