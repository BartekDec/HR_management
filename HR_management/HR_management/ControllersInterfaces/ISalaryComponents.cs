using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace HR_management.ControllersInterfaces
{
    public interface ISalaryComponents
    {
        IQueryable<Salary> GetSalary();
        Salary GetSalaryById(int id);
        void AddSalary(Salary salary);
        void SaveChnages();
        void DeleteSalary(int id);
        void Actualize(Salary salary);

    }
}
