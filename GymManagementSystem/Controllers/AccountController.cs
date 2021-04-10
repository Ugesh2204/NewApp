using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using GymManagementSystem.Models;
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
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        //private object input;
        private readonly IEmailSender _emailSender;

        public AccountController(UserManager<ApplicationUser> _userManager, IEmailSender emailSender, SignInManager<ApplicationUser> _signInManager)
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
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            //string message = "";
            if (ModelState.IsValid)
            {

                ApplicationUser user = new ApplicationUser()
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
                    ViewBag.Msg = "<div class='alert alert-success' role='alert'>Confirmation link has been send to the above entered email.Please check your email, " +
                           "conifrm it by clicking the link provided and get access to your account</div>";


                }

                else
                {
                    
                    ViewBag.Msg = "<div class='alert alert-danger' role='alert'>Registration Fail</div>";

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
                ViewBag.Msg = "Email confirmation Succeeded! You can now login to your Account.";
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
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            //take parameter Email,Password,remember me and Lockout with Max 5 attempts
            var Result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);
            if (Result.Succeeded)
                return RedirectToAction("Index", "Home");
            return View();
        }






        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            //we have user manager object
            //with the usermanger object we are trying to that user by email address
            //and we are getting the email from model
            var user = await userManager.FindByEmailAsync(model.UserEmail);
            //After finding the user we are trying to generate token
            var resetToken = await userManager.GeneratePasswordResetTokenAsync(user);

            //Now i need to make a link for reset 

            string resetLink = Url.Action("ResetPassword", "Account", new { userid = user.Id, token = resetToken }, protocol: HttpContext.Request.Scheme);
            await _emailSender.SendEmailAsync(user.Email, "Reset Password link", resetLink);

            ViewBag.Msg = "<div class='alert alert-success' role='alert'>Reset Password Link Has Been Emailed</div>";


            return View();
        }


        [HttpGet]
        public IActionResult ResetPassword(string userId, string token)
        {
            //Here i create the object of ResetPasswordViewModel
            var obj = new ResetPasswordViewModel()
            {
                UserId = userId,
                Token = token
            };

            return View(obj);
        }


        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            //find the user first
            var user = await userManager.FindByIdAsync(model.UserId);
            //Reset password will take 3 parameters
            var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);

            if (result.Succeeded)
            {
                //if succeed you can redirect to login page
                ViewBag.Msg = "<div class='alert alert-success' role='alert'>Password Reset Succeded! You can now logIn</div>";
            }
            else
            {
                ViewBag.Msg = "<div class='alert alert-danger' role='alert'>Password Reset Failed!</div>";
            }

            return View();
        }








        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


    }
}