using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.Interfaces
{
    public interface IRole
    {
        IQueryable<Role> GetRole();
        Role GetRoleById(int id); // find Role
        void DeleteRole(int id);
        void AddRole(Role role);
        void Actualize(Role role);
        void SaveChanges();
    }
}
