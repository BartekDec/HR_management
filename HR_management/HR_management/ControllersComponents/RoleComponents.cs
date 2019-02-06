using HR_management.ControllersInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.Models;
using Repository.Interfaces;

namespace HR_management.ControllersComponents
{
    public class RoleComponents : IRoleComponents
    {
        private readonly IRole _IRole;
        private readonly IHrContext _context;
        public RoleComponents(IRole role, IHrContext context)
        {
            _IRole = role;
            _context = context;
        }
        public IQueryable<Role> GetRole()
        {
            var Role = _IRole.GetRole();
            return Role;
        }

        public Role GetRoleById(int id)
        {
            var Role = _IRole.GetRoleById(id);
            return Role;
        }

        public void AddRole(Role Role)
        {
            _IRole.AddRole(Role);

        }

        public void SaveChnages()
        {
            _IRole.SaveChanges();
        }

        public void DeleteRole(int id)
        {
            _IRole.DeleteRole(id);

        }
        public void Actualize(Role Role)
        {
            _IRole.Actualize(Role);
        }
    }
}