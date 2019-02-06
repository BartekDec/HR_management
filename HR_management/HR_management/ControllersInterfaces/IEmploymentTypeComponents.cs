using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_management.ControllersInterfaces
{
    public interface IEmploymentTypeComponents
    {
        IQueryable<EmploymentType> GetEmploymentType();
        EmploymentType GetEmploymentTypeById(int id);
        void AddEmploymentType(EmploymentType EmploymentType);
        void SaveChnages();
        void DeleteEmploymentType(int id);
        void Actualize(EmploymentType EmploymentType);
    }
}
