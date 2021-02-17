using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagementSystem.ViewModels
{
    public class ResetPasswordViewModel
    {
        //At the time of reseting the password we need 4 fields

        //This we are getting it from email
        public string UserId { get; set; }
        //This we are getting from the generated token link
        public string Token { get; set; }
        //This we are getting sent on form
        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
