using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagementSystem.ViewModels
{
    public class WorkoutViewModel
    {    
        public string WorkoutName { get; set; }

        public string Description { get; set; }

        public IFormFile Photo { get; set; }

        public int MaxParticpant { get; set; }

        public double Price { get; set; }
    }
}
