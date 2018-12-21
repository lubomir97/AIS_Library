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
    public class ScientistRepository : IRepository<Scientist>
    {
        private ApplicationDbContext db;

        public ScientistRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(Scientist item)
        {
            Scientist sct = db.Scientists.Add(item);

        }

        public void Delete(int id)
        {
            var value = db.Scientists.Find(id);
            if (value != null)
            {
                db.Scientists.Remove(value);
            }
        }

        public Scientist Get(int id)
        {
            Scientist sct = db.Scientists.Find(id);
            sct.Organization = db.Organizations.Find(sct.OrganizationId);
            sct.User = db.Userss.Find(sct.UserId);

            return sct;
        }

        public IEnumerable<Scientist> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Scientist item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}