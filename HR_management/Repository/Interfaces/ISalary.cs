using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.Models;

namespace Repository.Interfaces
{
    public interface ISalary
    {
        IQueryable<Salary> GetSalary();
        Salary GetSalaryById(int id); // find Salary
        void DeleteSalary(int id);
        void AddSalary(Salary salary);
        void Actualize(Salary salary);
        void SaveChanges();
    }
}