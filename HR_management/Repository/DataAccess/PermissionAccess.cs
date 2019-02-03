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
    public class PermissionAccess : IPermission
    {
        private readonly IHrContext _db;
        public PermissionAccess(IHrContext db)
        {
            _db = db;
        }

        public void Actualize(Permission Permission)
        {
            _db.Entry(Permission).State = System.Data.Entity.EntityState.Modified;
        }



        public void AddPermission(Permission Permission)
        {
            _db.Permission.Add(Permission);
        }

        public void DeletePermission(int id)
        {
            Permission Permission = _db.Permission.Find(id);
            _db.Permission.Remove(Permission);
        }

        public IQueryable<Permission> GetPermission()
        {
            _db.Database.Log = message => Trace.WriteLine(message);
            return _db.Permission.AsNoTracking();
        }

        public Permission GetPermissionById(int id)
        {
            Permission Permission = _db.Permission.Find(id);
            return Permission;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

    }
}