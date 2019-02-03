using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.Models;
using System.Diagnostics;
using System.Data.Entity;

namespace Repository.DataAccess
{
    public class EmployeeAccess : IEmployee
    {

        private readonly IHrContext _db;
        public EmployeeAccess(IHrContext db)
        {
            _db = db;
        }

        public void Actualize(Employee Employee)
        {
            _db.Entry(Employee).State = System.Data.Entity.EntityState.Modified;
        }



        public void AddEmployee(Employee Employee)
        {
            _db.Employee.Add(Employee);
        }

        public void DeleteEmployee(int id)
        {
            Employee Employee = _db.Employee.Find(id);
            _db.Employee.Remove(Employee);
        }

        public IQueryable<Employee> GetEmployee()
        {
            _db.Database.Log = message => Trace.WriteLine(message);
            return _db.Employee.Include(b => b.Salary);
        }

        public Employee GetEmployeeById(int id)
        {
            Employee Employee = _db.Employee.Find(id);
            return Employee;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

    }
}