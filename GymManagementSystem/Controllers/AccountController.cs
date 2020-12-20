using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagementSystem.Utility;
using GymManagementSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        UserManager<IdentityUser> userManager;
        //private readonly EmailSender _emailSender;

        public AccountController(UserManager<IdentityUser> _userManager)
        {
            userManager = _userManager;
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
                //Generating confirmation token
                string confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
                //This will generate a link and mail this link to the user
                string confirmationLink = Url.Action("ConfirmEmail", "Account", new { userid = user.Id, token = confirmationToken }, Request.Scheme);
              
                //await _emailSender.SendEmailAsync(user.Email, "Confirm Your Email","Click here to Confirm your Email Address" + confirmationLink);
                System.IO.File.WriteAllText(@"C:\Users\Ugesh\Desktop\dotcore2020\TestEmaillConfirmLink\ConfirmEmail.txt", confirmationLink);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
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





        public IActionResult Login()
        {
            return View();
        }



    }
}