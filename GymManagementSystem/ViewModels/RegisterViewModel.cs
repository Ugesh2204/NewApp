
using GymManagementSystem.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagementSystem.ViewModels
{
    //unique email validation
    //public class UniqueEmailAttribute : ValidationAttribute
    //{

    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        ApplicationDbContext db = new  ApplicationDbContext();


    //        //int count = db.user.where(x => x.Email == value.ToString()).Count();
    //        int count = db.ApplicationUsers.Where(x => x.Email == value.ToString()).Count();

    //        if (count == 0)
    //            return ValidationResult.Success;
    //        else
    //            return new ValidationResult("This Email already exist !");

    //    }

    //}

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        //[UniqueEmail]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [RegularExpression(@"^([0-9]{8})$", ErrorMessage = "Invalid Phone Number.")]
        public string MobileNumber { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
