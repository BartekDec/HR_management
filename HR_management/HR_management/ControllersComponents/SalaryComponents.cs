using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repository.Models;
using Repository.Interfaces;
using HR_management.ControllersInterfaces;

namespace HR_management.ControllersComponents
{
    public class SalaryComponents : Controller, ISalaryComponents
    {
        private readonly ISalary _Isalary;
        private readonly IHrContext _context;

        public SalaryComponents(ISalary salary, IHrContext context)
        {
            _Isalary = salary;
            _context = context;
        }
        public IQueryable<Salary> GetSalary()
        {
            var salary = _Isalary.GetSalary();
            return salary;
        }

        public Salary GetSalaryById(int id)
        {
            var salary = _Isalary.GetSalaryById(id);
            return salary;
        }

        public void AddSalary(Salary salary)
        {
            _Isalary.AddSalary(salary);

        }

        public void SaveChnages()
        {
            _Isalary.SaveChanges();
        }

        public void DeleteSalary(int id)
        {
            _Isalary.DeleteSalary(id);

        }
        public void Actualize(Salary salary)
        {
            _Isalary.Actualize(salary);
        }
    }
}