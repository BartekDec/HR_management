using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_management.ControllersInterfaces
{
    public interface IPermissionComponents
    {
        IQueryable<Permission> GetPermission();
        Permission GetPermissionById(int id);
        void AddPermission(Permission Permission);
        void SaveChnages();
        void DeletePermission(int id);
        void Actualize(Permission Permission);
    }
}
