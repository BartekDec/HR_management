using HR_management.ControllersInterfaces;
using Repository.Interfaces;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR_management.ControllersComponents
{
    public class EmploymentTypeComponents : IEmploymentTypeComponents
    {
        private readonly IEmploymentType _IEmploymentType;
        private readonly IHrContext _context;

        public EmploymentTypeComponents(IEmploymentType EmploymentType, IHrContext context)
        {
            _IEmploymentType = EmploymentType;
            _context = context;
        }

        public IQueryable<EmploymentType> GetEmploymentType()
        {
            var EmploymentType = _IEmploymentType.GetEmploymentType();
            return EmploymentType;
        }

        public EmploymentType GetEmploymentTypeById(int id)
        {
            var EmploymentType = _IEmploymentType.GetEmploymentTypeById(id);
            return EmploymentType;
        }

        public void AddEmploymentType(EmploymentType EmploymentType)
        {
            _IEmploymentType.AddEmploymentType(EmploymentType);
        }

        public void SaveChnages()
        {
            _IEmploymentType.SaveChanges();
        }

        public void DeleteEmploymentType(int id)
        {
            _IEmploymentType.DeleteEmploymentType(id);
        }

        public void Actualize(EmploymentType EmploymentType)
        {
            _IEmploymentType.Actualize(EmploymentType);
        }
    }
}