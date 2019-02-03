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
    public class RoleAccess : Interfaces.IRole
    {
        private readonly IHrContext _db;
        public RoleAccess(IHrContext db)
        {
            _db = db;
        }

        public void Actualize(Role Role)
        {
            _db.Entry(Role).State = System.Data.Entity.EntityState.Modified;
        }



        public void AddRole(Role Role)
        {
            _db.Role.Add(Role);
        }

        public void DeleteRole(int id)
        {
            Role Role = _db.Role.Find(id);
            _db.Role.Remove(Role);
        }

        public IQueryable<Role> GetRole()
        {
            _db.Database.Log = message => Trace.WriteLine(message);
            return _db.Role.AsNoTracking();
        }

        public Role GetRoleById(int id)
        {
            Role Role = _db.Role.Find(id);
            return Role;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

    }
}