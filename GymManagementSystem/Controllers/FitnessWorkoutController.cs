using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GymManagementSystem.Entities.Models;
using GymManagementSystem.Services;
using GymManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class FitnessWorkoutController : Controller
    {
        readonly IWorkoutService db;
        IHostingEnvironment hostingEnvironment;

        public FitnessWorkoutController(IWorkoutService _db, IHostingEnvironment hostingEnvironment)
        {
            db = _db;
            this.hostingEnvironment = hostingEnvironment;
        }

   
        public IActionResult Index()
        {
            var workouts = db.GetAll();

            return View(workouts);

            
        }


      

        #region MyRegion
        //public Workout GetWorkId(int id)
        //{
        //    var workout = db.GetById(id);
        //    return workout;

        //}

        //public IEnumerable<Workout> GetWorkouts()
        //{
        //    var workouts = db.GetAll();

        //    return workouts;

        //}




        //public IActionResult WorkoutTable()
        //{
        //    var workouts = db.GetAll();

        //    return View(workouts);

        //}

        #endregion


        [HttpGet]
        public IActionResult CreateWorkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateWorkout(WorkoutViewModel model)
        {
            //we want to check on the photo model property is not null
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                //To get the path of the www folder we are going to use the IHOSTING ENVIROMENT

                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath,"img");

                //to prevent upload image twice we use guid
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));

            }

            Workout newworkout = new Workout();
            newworkout.WorkoutName = model.WorkoutName;
            newworkout.Description = model.Description;
            newworkout.ImageURL = uniqueFileName;
            newworkout.MaxParticpant = model.MaxParticpant;
            newworkout.Price = model.Price;
            

            db.Create(newworkout);
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult EditWorkout (int id)
        {
            var workout = db.GetById(id);
            return View(workout);
        }

        [HttpPost]
        public IActionResult EditWorkout(Workout workout)
        {
            db.Update(workout);
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public IActionResult DeleteWorkout(int id)
        //{
        //    var Getworkout = db.GetById(id);

        //    return View(Getworkout);
        //}


     
        public IActionResult DeleteWorkout(int id)
        {
            var deleteWorkout = db.Delete(id);
            return RedirectToAction("Index");
        }






















        ///------------Json----------------------



     

        //url: /FitnessWorkout/GetAllApiJson
        [HttpGet]
        public IActionResult GetAllApiJson()
        {
            return Json(new { data = db.GetAll() });
        }


        [HttpDelete]
        public IActionResult DeleteDataApiJson( int id)
        {
            var singleWorkout = db.GetById(id);
            if(singleWorkout == null)
            {
                return Json(new { success = false, message = "Data Not Found!!" });
            }

            db.Delete(singleWorkout.WorkoutId);

            return Json(new { success = true, message = "Successfully Deleted" });

        }
        // --------------------------------------


    }
}