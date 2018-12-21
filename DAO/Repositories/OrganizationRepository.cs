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
    public class OrganizationRepository : IRepository<Organization>
    {
        private ApplicationDbContext db;

        public OrganizationRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(Organization item)
        {
            Organization org = db.Organizations.Add(item);
        }

        public void Delete(int id)
        {
            var value = db.Organizations.Find(id);
            if (value != null)
            {
                db.Organizations.Remove(value);
            }
        }

        public Organization Get(int id)
        {
            Organization org = db.Organizations.Find(id);

            return org;
        }

        public IEnumerable<Organization> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Organization item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}