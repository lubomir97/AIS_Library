using System;
using AIS_Library.DAO.Interfaces;
using AIS_Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AIS_Library.DAO.Repositories
{
    public class UsingRulesRepository : IRepository<UsingRules>
    {
        private ApplicationDbContext db;

        public UsingRulesRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(UsingRules item)
        {
            UsingRules ur = db.UsingRuless.Add(item);
        }

        public void Delete(int id)
        {
            var value = db.UsingRuless.Find(id);
            if (value != null)
            {
                db.UsingRuless.Remove(value);
            }
        }

        public UsingRules Get(int id)
        {
            UsingRules ur = db.UsingRuless.Find(id);

            return ur;
        }

        public IEnumerable<UsingRules> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(UsingRules item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}