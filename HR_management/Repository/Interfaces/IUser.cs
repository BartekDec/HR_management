using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;
namespace Repository.Interfaces
{
    public interface IUser
    {
        IQueryable<User> GetUser();
        User GetUserById(int id); // find User
        void DeleteUser(int id);
        void AddUser(User user);
        void Actualize(User user);
        void SaveChanges();
    }
}
