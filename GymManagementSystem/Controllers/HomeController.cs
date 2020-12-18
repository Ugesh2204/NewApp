using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagementSystem.Services;
using GymManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        readonly IWorkoutService db;

        public HomeController(IWorkoutService _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {

            HomeViewModel model = new HomeViewModel();

            model.HomePageWorkouts = db.GetAll();

            return View(model);
        }
    }
}