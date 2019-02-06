using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_management.ControllersInterfaces
{
    public interface IRoleComponents
    {
        IQueryable<Role> GetRole();
        Role GetRoleById(int id);
        void AddRole(Role Role);
        void SaveChnages();
        void DeleteRole(int id);
        void Actualize(Role Role);
    }
}
