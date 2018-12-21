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
    public class LibrarianRepository : IRepository<Librarian>
    {
        private ApplicationDbContext db;

        public LibrarianRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(Librarian item)
        {
            Librarian lb = db.Librarians.Add(item);
        }

        public void Delete(int id)
        {
            var value = db.Librarians.Find(id);
            if (value != null)
            {
                db.Librarians.Remove(value);
            }
        }

        public Librarian Get(int id)
        {
            Librarian lb = db.Librarians.Find(id);
            lb.User = db.Userss.Find(lb.UserId);

            return lb;
        }

        public IEnumerable<Librarian> GetAll()
        {
            return db.Librarians.Include(o => o.User).ToList();
        }

        public void Update(Librarian item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}