using HR_management.ControllersInterfaces;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.Models;

namespace HR_management.ControllersComponents
{
    public class EmployeeComponents : IEmployeeComponents
    {
        private readonly IEmployee _Iemployee;
        private readonly IHrContext _context;
        public EmployeeComponents(IEmployee employee, IHrContext context)
        {
            _Iemployee = employee;
            _context = context;
        }

        public IQueryable<Employee> GetEmployee()
        {
            var employee = _Iemployee.GetEmployee();
            return employee;
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _Iemployee.GetEmployeeById(id);
            return employee;
        }

        public void AddEmployee(Employee Employee)
        {
            _Iemployee.AddEmployee(Employee);
        }

        public void SaveChnages()
        {
            _Iemployee.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            _Iemployee.DeleteEmployee(id);
        }

        public void Actualize(Employee Employee)
        {
            _Iemployee.Actualize(Employee);
        }
    }
}