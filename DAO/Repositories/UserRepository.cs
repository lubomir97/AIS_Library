using System;
using AIS_Library.DAO.Interfaces;
using AIS_Library.Models.Users;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AIS_Library.Models;
using System.Data.Entity;

namespace AIS_Library.DAO.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private ApplicationDbContext db;

        public UserRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(User item)
        {
            User usr = db.Userss.Add(item);
        }

        public void Delete(int id)
        {
            var value = db.Userss.Find(id);
            if (value != null)
            {
                db.Userss.Remove(value);
            }
        }

        public User Get(int id)
        {
            User usr = db.Userss.Find(id);
            return usr;
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}