using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Interfaces
{
    public interface IEmployee
    {
        IQueryable<Employee> GetEmployee();
        Employee GetEmployeeById(int id); // find employee
        void DeleteEmployee(int id);
        void AddEmployee(Employee employee);
        void Actualize(Employee employee);
        void SaveChanges();

    }
}