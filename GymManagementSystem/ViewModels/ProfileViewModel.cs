using GymManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagementSystem.ViewModels
{
    public class ProfileViewModel
    {
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public Gender Gender { get; set; }


        public IFormFile Photo { get; set; }

        [Required]
        public int Weight { get; set; }
        [Required]
        public int Feet { get; set; }
        [Required]
        public double Inch { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string HealthDescription { get; set; }
    }
}
