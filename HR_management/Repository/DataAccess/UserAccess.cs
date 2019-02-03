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
    public class UserAccess : Interfaces.IUser
    {
        private readonly IHrContext _db;
        public UserAccess(IHrContext db)
        {
            _db = db;
        }

        public void Actualize(User User)
        {
            _db.Entry(User).State = System.Data.Entity.EntityState.Modified;
        }



        public void AddUser(User User)
        {
            _db.User.Add(User);
        }

        public void DeleteUser(int id)
        {
            User User = _db.User.Find(id);
            _db.User.Remove(User);
        }

        public IQueryable<User> GetUser()
        {
            _db.Database.Log = message => Trace.WriteLine(message);
            return _db.User.Include(b => b.Role);
        }

        public User GetUserById(int id)
        {
            User User = _db.User.Find(id);
            return User;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

    }
}