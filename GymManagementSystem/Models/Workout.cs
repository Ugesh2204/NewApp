using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagementSystem.Models
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
