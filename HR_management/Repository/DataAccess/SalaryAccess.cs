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
    public class SalaryAccess : ISalary
    {
        private readonly IHrContext _db;
        public SalaryAccess(IHrContext db)
        {
            _db = db;
        }

        public void Actualize(Salary salary)
        {
            _db.Entry(salary).State = System.Data.Entity.EntityState.Modified;
        }

      

        public void AddSalary(Salary salary)
        {
            _db.Salary.Add(salary);
        }

        public void DeleteSalary(int id)
        {
            Salary salary = _db.Salary.Find(id);
            _db.Salary.Remove(salary);
        }

        public IQueryable<Salary> GetSalary()
        {
            _db.Database.Log = message => Trace.WriteLine(message);
            return _db.Salary.Include(b => b.EmploymentType);
        }

        public Salary GetSalaryById(int id)
        {
            Salary salary = _db.Salary.Find(id);
            return salary;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}