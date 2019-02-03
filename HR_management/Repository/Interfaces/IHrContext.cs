using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Repository.Interfaces
{
    public interface IHrContext
    {
        DbSet<Role> Role { get; set; }
        DbSet<Employee> Employee { get; set; }
        DbSet<Permission> Permission { get; set; }
        DbSet<Salary> Salary { get; set; }
        DbSet<EmploymentType> EmploymentType { get; set; }
        DbSet<User> User { get; set; }
        DbSet<Role_Permission> Role_Permission { get; set; }
        int SaveChanges();
        Database Database { get; }

        DbEntityEntry Entry(object entity);



    }
}
