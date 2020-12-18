using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagementSystem.Entities.Models;
using GymManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        readonly IEmployeeService db;

        public EmployeeController(IEmployeeService _db)
        {
            db = _db;
        }

 

        public IActionResult Index()
        {
            var employees = db.GetAll();
            return View(employees);
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            db.Create(employee);
            return View();
        }

        [HttpGet]
        public IActionResult EditEmployee(int id)
        {
            var getEmpId = db.GetById(id);
            return View(getEmpId);
        }


        [HttpPost]
        public IActionResult EditEmployee(Employee employee)
        {

            db.Update(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteEmployee(int id)
        {
            var getemployee = db.GetById(id);

            return View(getemployee);
        }


        [HttpPost]
        public IActionResult DeleteEmployee(Employee employee)
        {
            //employee = db.GetById(employee.EmployeeId);

            var deleteEmployee = db.Delete(employee.EmployeeId);

            return RedirectToAction("Index");
        }


    }
}