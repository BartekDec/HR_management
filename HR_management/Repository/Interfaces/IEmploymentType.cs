using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.Models;

namespace Repository.Interfaces
{
    public interface IEmploymentType
    {
        IQueryable<EmploymentType> GetEmploymentType();
        EmploymentType GetEmploymentTypeById(int id); // find permission
        void DeleteEmploymentType(int id);
        void AddEmploymentType(EmploymentType employmentType);
        void Actualize(EmploymentType employmentType);
        void SaveChanges();
    }
}