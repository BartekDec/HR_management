using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.Interfaces
{
    public interface IPermission
    {
        IQueryable<Permission> GetPermission();
        Permission GetPermissionById(int id); // find permission
        void DeletePermission(int id);
        void AddPermission(Permission permission);
        void Actualize(Permission permission);
        void SaveChanges();
    }
}
