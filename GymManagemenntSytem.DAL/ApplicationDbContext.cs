
using GymManagementSystem.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace GymManagementSystem.DAL
{
   public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        //{
        //    optionsbuilder.UseSqlServer(@"server=desktop-7bgfqjh;database=GymProFitnessDb;trusted_connection=true;");
        //}


        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Employee> Employees{ get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


    





    }
}
