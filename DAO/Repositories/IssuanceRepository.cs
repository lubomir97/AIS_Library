using System;
using AIS_Library.DAO.Interfaces;
using AIS_Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AIS_Library.DAO.Repositories
{
    public class IssuanceRepository : IRepository<Issuance>
    {
        private ApplicationDbContext db;

        public IssuanceRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(Issuance item)
        {
            Issuance iss = db.Issuances.Add(item);
        }

        public void Delete(int id)
        {
            var value = db.Issuances.Find(id);
            if (value != null)
            {
                db.Issuances.Remove(value);
            }
        }

        public Issuance Get(int id)
        {
            Issuance iss = db.Issuances.Find(id);

            return iss;
        }

        public IEnumerable<Issuance> GetAll()
        {
            return db.Issuances.ToList();
        }

        public void Update(Issuance item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}