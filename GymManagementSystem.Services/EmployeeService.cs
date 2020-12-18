using GymManagementSystem.DAL;
using GymManagementSystem.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagementSystem.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        bool Create(Employee employee);
        bool Update(Employee employee);
        bool Delete(int id);

    }


    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext db;

        public EmployeeService(ApplicationDbContext _db)
        {
            db = _db;
        }


        public bool Create(Employee employee)
        {
            db.Add(employee);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var employee = db.Employees.Find(id);
            db.Remove<Employee>(employee);
            db.SaveChanges();
            return true;

        }

        public IEnumerable<Employee> GetAll()
        {
            return db.Employees;
        }

        public Employee GetById(int id)
        {
            var employee = db.Employees.Find(id);
            return employee;

        }

        public bool Update(Employee employee)
        {
            db.Update<Employee>(employee);
            db.SaveChanges();
            return true;
        }
    }
}
