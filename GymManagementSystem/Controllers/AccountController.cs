using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using GymManagementSystem.Utility;
using GymManagementSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace GymManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;
        //private object input;
        private readonly IEmailSender _emailSender;

        public AccountController(UserManager<IdentityUser> _userManager, IEmailSender emailSender , SignInManager<IdentityUser> _signInManager)
        {
            userManager = _userManager;
            _emailSender = emailSender;
            signInManager = _signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register( RegisterViewModel model)
         {
            //string message = "";
            if (ModelState.IsValid)
            {

                IdentityUser user = new IdentityUser()
                {
                  UserName = model.UserName,
                  Email = model.Email,
                  PhoneNumber = model.MobileNumber

                };
                var result = await userManager.CreateAsync(user, model.Password);
               


                if (result.Succeeded)
                {
                    //Generating confirmation token
                    string confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    //This will generate a link and mail this link to the user
                    string confirmationLink = Url.Action("ConfirmEmail", "Account", new { userid = user.Id, token = confirmationToken }, Request.Scheme);

                    await _emailSender.SendEmailAsync(user.Email, "Confirmation email link", confirmationLink);
                    //await _emailSender.SendEmailAsync(user.Email, "Confirm Your Email", $"Please Confirm your Email Address by clicking this link:  <a href='{confirmationLink}'>link<a/>");
                    //System.IO.File.WriteAllText(@"C:\Users\Ugesh\Desktop\dotcore2020\TestEmaillConfirmLink\ConfirmEmail.txt", confirmationLink);
                    //return RedirectToAction("Login", "Account");
                    ViewBag.Msg ="<div class='alert alert-success' role='alert'>Confirmation link has been send to the above entered email.Please check your email, " +
                           "conifrm it by clicking the link provided and get access to your account</div>";
                        
                       
                }

                else
                {
                    ViewBag.Msg = "Registration Fail";
                   
                }
            }
            return View();

        }


        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await userManager.FindByIdAsync(userId);
            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                ViewBag.Msg = "Email confirmation Succeeded!";
            }
            else
            {
                ViewBag.Msg = "Email confirmation Failed!";
            }

            return View();
        }




        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult>Login(LoginViewModel model)
         {
            //take parameter Email,Password,remember me and Lockout with Max 5 attempts
            var Result = await signInManager.PasswordSignInAsync(model.UserName,model.Password, model.RememberMe,true);
            if (Result.Succeeded)
                return RedirectToAction("Index", "Home");
            return View();
        }




    }
}