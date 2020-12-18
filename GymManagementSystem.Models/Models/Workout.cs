using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymManagementSystem.Entities.Models
{
    public class Workout
    {
        [Key]
        public int WorkoutId { get; set; }

        public string WorkoutName { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public int MaxParticpant { get; set; }

        public double Price { get; set; }
    }
}
