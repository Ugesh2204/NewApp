using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagementSystem.Models;
using GymManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    [Authorize]
    public class AccountManagerController : Controller
    {
        UserManager<ApplicationUser> userManager;
        RoleManager<IdentityRole> roleManager;

        public AccountManagerController(UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
        }

  


        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AssignRole()
        {
            //Get All users through userManager
            var users = userManager.Users.ToList();
            //Get All users through roleManager
            var roles = roleManager.Roles.ToList();

            // Getting all the Role from IDENTITYRole that have all the field
            // Storing all the roles in the ListRoles
            List<string> ListRoles = new List<string>();
            foreach (var item in roles)
            {
                ListRoles.Add(item.Name);
            }

            //Fill the list
            List<AssignRoleViewModel> list = new List<AssignRoleViewModel>();

            foreach (var item in users)
            {
                AssignRoleViewModel model = new AssignRoleViewModel();
                model.UserId = item.Id;
                model.UserName = item.UserName;
                model.Email = item.Email;
                //Check if user already have some role or not and get RoleName
                //1. If a user  got already a role then this count will be not equal to zero (userManager.GetRolesAsync(item).Result.Count != 0)
                //2. Get assign role with userManager.GetRolesAsync(item).Result[0] and IF not we say null
                //It will check in db if the current user have some role or not, if it has a role it will get the role name
                model.RoleName = userManager.GetRolesAsync(item).Result.Count != 0 ? userManager.GetRolesAsync(item).Result[0] : "";
                model.Roles = ListRoles;
                list.Add(model);
            }
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(string UserId,string RoleName)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.FindByIdAsync(UserId).Result;

                var roles = roleManager.Roles.ToList();
                List<string> listRoles = new List<string>();
                foreach (var item in roles)
                {
                    listRoles.Add(item.Name);
                }

                var ResultRemove = await userManager.RemoveFromRolesAsync(user, listRoles);

                //Assign the role to the user with AddRoleAsync
                var Result = await userManager.AddToRoleAsync(user, RoleName);
                return RedirectToAction("AssignRole");

            }

            return View();

        }

    }
}