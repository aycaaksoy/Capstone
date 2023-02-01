using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using BusinessLayer.Abstract;
using DTO.AppUserDTOs;
using System.Web;
using Capstone.Models;

namespace Capstone.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
       


        public RegisterController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration, IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterDTO p)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new()
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    Email = p.Email,
                    UserName = p.Username,

                };
                var result = await _userManager.CreateAsync(user, p.Password);
                if (result.Succeeded)
                {
                    var confirmEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var validEmailToken = HttpUtility.UrlEncode(confirmEmailToken);

                    var confirmationLink = Url.Action("ConfirmEmail", "Register", new {  userId= user.Id, validEmailToken }, Request.Scheme);
                    await _emailService.SendEmailAsync(user.Email, "Confirm your email", $"Welcome to Capstone Project Web App" +  $"Please confirm your email by entering this token --> " + confirmationLink);
                           


                            ViewBag.RegisterSuccessMessage = "Registration Successful";
                            ViewBag.RegisterConfirmationInfo = "We sent you a confirmation email. Before you can login, please confirm your " +
                                "email";
                    return View("EmailConfirmationInfo");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }

            return View();
        }
         
        // /Register/confirmemail?userid&token
        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(String userId, string validEmailToken)
        {
            var user = await _userManager.FindByIdAsync(userId);
          
            var receivedTokenDecoded = HttpUtility.UrlDecode(validEmailToken);
            if (string.IsNullOrWhiteSpace(validEmailToken))
                return NotFound();

            var result = await _userManager.ConfirmEmailAsync(user, receivedTokenDecoded);

            if (result.Succeeded)
            {

                ViewBag.RegisterSuccessMessage = "Email Confirmation Successful!";
                ViewBag.RegisterConfirmationInfo = "You can login to your account ";
                return View(); 
            }

            ViewBag.RegisterSuccessMessage = "Confirmation is NOT succesful :(";
            ViewBag.RegisterConfirmationInfo = "You can NOT login to your account ";
            return View();
        }
    }
}
