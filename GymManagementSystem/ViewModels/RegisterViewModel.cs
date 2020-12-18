using GymManagementSystem.DAL;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagementSystem.ViewModels
{
    
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        public string MobileNumber { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
