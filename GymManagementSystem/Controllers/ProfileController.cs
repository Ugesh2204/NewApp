using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GymManagementSystem.Data;
using GymManagementSystem.Models;
using GymManagementSystem.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Controllers
{
    public class ProfileController : Controller
    {
        ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        IHostingEnvironment _hostingEnvironment;

        public ProfileController(ApplicationDbContext db, UserManager<IdentityUser> userManager, IHostingEnvironment hostingEnvironment)
        {
         _db = db;
          _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }



        public IActionResult Index()
        {
            var logInuserId = _userManager.GetUserId(HttpContext.User);
            var finduser = _db.UserProfileDetails.Where(x => x.ApplicationUserId == logInuserId).FirstOrDefault();

            if(finduser == null )
            {
                return RedirectToAction("create", "Profile");
            }

            

          return View(finduser);

            
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


        [HttpPost]
        public IActionResult Create(ProfileViewModel model)
        {
           
                //we want to check on the photo model property is not null
                string uniqueFileName = null;

                if (model.Photo != null)
                {
                    //To get the path of the www folder we are going to use the IHOSTING ENVIROMENT
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img");

                    //to prevent upload image twice we use guid
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;

                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));

                }


                UserProfileDetail user = new UserProfileDetail();
                user.ApplicationUserId = model.Id;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Feet = model.Feet;
                user.Inch = model.Inch;
                user.Weight = model.Weight;
                user.Gender = model.Gender;
                user.ImagePhoto = uniqueFileName;
                user.HealthDescription = model.HealthDescription;


                _db.Add(user);
                _db.SaveChanges();

                return RedirectToAction("Index", "Profile");

           
           

            

        }
        



    }
}