using GymManagementSystem.DAL;
using GymManagementSystem.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymManagementSystem.Services
{
    public interface IWorkoutService
    {
        List<Workout> GetAll();
        Workout GetById(int id);
        bool Create(Workout workout);
        bool Update(Workout workout);
        bool Delete(int id);

    }


    public class WorkoutService : IWorkoutService
    {
        private readonly ApplicationDbContext db;

        public WorkoutService(ApplicationDbContext _db)
        {
            db = _db;
        }
        public bool Create(Workout workout)
        {
            db.Add(workout);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var workout = db.Workouts.Find(id);
            db.Remove<Workout>(workout);
            db.SaveChanges();
            return true;
        }

        public List<Workout> GetAll()
        {
            return db.Workouts.ToList();
        }

        public Workout GetById(int id)
        {
            var workout = db.Workouts.Find(id);
            return workout;
        }

        public bool Update(Workout workout)
        {
            db.Update<Workout>(workout);
            db.SaveChanges();
            return true;
        }
    }
}
