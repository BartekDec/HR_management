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
    public class EmploymentTypeAccess : IEmploymentType
    {

        private readonly IHrContext _db;
        public EmploymentTypeAccess(IHrContext db)
        {
            _db = db;
        }

        public void Actualize(EmploymentType EmploymentType)
        {
            _db.Entry(EmploymentType).State = System.Data.Entity.EntityState.Modified;
        }



        public void AddEmploymentType(EmploymentType EmploymentType)
        {
            _db.EmploymentType.Add(EmploymentType);
        }

        public void DeleteEmploymentType(int id)
        {
            EmploymentType EmploymentType = _db.EmploymentType.Find(id);
            _db.EmploymentType.Remove(EmploymentType);
        }

        public IQueryable<EmploymentType> GetEmploymentType()
        {
            _db.Database.Log = message => Trace.WriteLine(message);
            return _db.EmploymentType.AsNoTracking();
        }

        public EmploymentType GetEmploymentTypeById(int id)
        {
            EmploymentType EmploymentType = _db.EmploymentType.Find(id);
            return EmploymentType;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

    }
}