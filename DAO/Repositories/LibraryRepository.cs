using System;
using AIS_Library.DAO.Interfaces;
using AIS_Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AIS_Library.DAO.Repositories
{
    public class LibraryRepository : IRepository<Library>
    {
        private ApplicationDbContext db;

        public LibraryRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(Library item)
        {
            Library lbr = db.Libraries.Add(item);
        }

        public void Delete(int id)
        {
            var value = db.Libraries.Find(id);
            if (value != null)
            {
                db.Libraries.Remove(value);
            }
        }

        public Library Get(int id)
        {
            Library lbr = db.Libraries.Find(id);

            return lbr;
        }

        public IEnumerable<Library> GetAll()
        {
            return db.Libraries.ToList();
        }

        public void Update(Library item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}