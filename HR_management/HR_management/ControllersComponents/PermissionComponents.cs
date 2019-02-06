using HR_management.ControllersInterfaces;
using Repository.Interfaces;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR_management.ControllersComponents
{
    public class PermissionComponents : IPermissionComponents
    {

        private readonly IPermission _IPermission;
        private readonly IHrContext _context;
        public PermissionComponents(IPermission Permission, IHrContext context)
        {
            _IPermission = Permission;
            _context = context;
        }
        public IQueryable<Permission> GetPermission()
        {
            var Permission = _IPermission.GetPermission();
            return Permission;
        }

        public Permission GetPermissionById(int id)
        {
            var Permission = _IPermission.GetPermissionById(id);
            return Permission;
        }

        public void AddPermission(Permission Permission)
        {
            _IPermission.AddPermission(Permission);

        }

        public void SaveChnages()
        {
            _IPermission.SaveChanges();
        }

        public void DeletePermission(int id)
        {
            _IPermission.DeletePermission(id);

        }
        public void Actualize(Permission Permission)
        {
            _IPermission.Actualize(Permission);
        }
    }
}