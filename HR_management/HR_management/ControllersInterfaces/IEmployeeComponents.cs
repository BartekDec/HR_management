using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace HR_management.ControllersInterfaces
{
    public interface IEmployeeComponents
    {
        IQueryable<Employee> GetEmployee();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee Employee);
        void SaveChnages();
        void DeleteEmployee(int id);
        void Actualize(Employee Employee);
    }
}
