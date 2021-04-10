using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagementSystem.Models
{
    public class UserProfileDetail
    {
        [Key]
        public int? ProfileId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        //Gender
        public Gender Gender { get; set; }

        //Height in feet and inch
        public int Feet { get; set; }

        public double Inch { get; set; }

        public int Weight { get; set; }
     

        public string HealthDescription { get; set; }

        public string ImagePhoto  { get; set; }

        public string Address    { get; set; }

        [ForeignKey("ApplicationUserId")]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }


    }

    public enum Gender
    {
        Male,
        Female
    }



}




