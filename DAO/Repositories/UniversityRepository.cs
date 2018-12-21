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
    public class UniversityRepository : IRepository<University>
    {
        private ApplicationDbContext db;

        public UniversityRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(University item)
        {
            University univer = db.Universities.Add(item);
        }

        public void Delete(int id)
        {
            var value = db.Universities.Find(id);
            if (value != null)
            {
                db.Universities.Remove(value);
            }
        }

        public University Get(int id)
        {
            University univer = db.Universities.Find(id);

            return univer;
        }

        public IEnumerable<University> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(University item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}