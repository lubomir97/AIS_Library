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
    public class FacultyRepository : IRepository<Faculty>
    {
        private ApplicationDbContext db;

        public FacultyRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(Faculty item)
        {
            Faculty fk = db.Faculties.Add(item);
        }

        public void Delete(int id)
        {
            var value = db.Faculties.Find(id);
            if (value != null)
            {
                db.Faculties.Remove(value);
            }
        }

        public Faculty Get(int id)
        {
            Faculty fk = db.Faculties.Find(id);
            fk.University = db.Universities.Find(fk.UnivertityId);

            return fk;
        }

        public IEnumerable<Faculty> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Faculty item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}