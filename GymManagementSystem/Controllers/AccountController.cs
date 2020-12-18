using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagementSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        UserManager<IdentityUser> userManager;

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

           
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }

            }

        
            return View();
        }




        public IActionResult Login()
        {
            return View();
        }



    }
}