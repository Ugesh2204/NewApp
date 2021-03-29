using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagementSystem.Data;
using GymManagementSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Controllers
{
    public class ProfileController : Controller
    {
        ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
         _db = db;
          _userManager = userManager;
        }



        public IActionResult Index()
        {
            var logInuserId = _userManager.GetUserId(HttpContext.User);
            var finduser = _db.UserProfileDetails.Where(x => x.ApplicationUserId == logInuserId).FirstOrDefault();

            if(finduser == null )
            {
                return RedirectToAction("create", "Profile");
            }

            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            //Get login id and pass it to view
            var logInuserId = _userManager.GetUserId(HttpContext.User);

            //var userdetail = _db.UserProfileDetails.Include(a => a.ApplicationUser)
            //                  .FirstOrDefault(x => x.ApplicationUser.Id == logInuserId);

            var userdetail = _db.Users.Where(x => x.Id == logInuserId).FirstOrDefault();

            ProfileViewModel model = new ProfileViewModel();
            model.Id = logInuserId;
            model.Email = userdetail.Email;
            model.Phone = userdetail.PhoneNumber;


            return View(model);
        }



    }
}