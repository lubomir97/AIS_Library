using System;
using AIS_Library.DAO.Interfaces;
using AIS_Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AIS_Library.DAO.Repositories
{
    public class CompositionTypeRepository : IRepository<CompositionType>
    {
        private ApplicationDbContext db;

        public CompositionTypeRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(CompositionType item)
        {
            CompositionType ct = db.CompositionTypes.Add(item);
        }

        public void Delete(int id)
        {
            var ct = db.CompositionTypes.Find(id);
            if (ct != null)
            {
                db.CompositionTypes.Remove(ct);
            }
        }

        public CompositionType Get(int id)
        {
            CompositionType ct = db.CompositionTypes.Find(id);

            return ct;
        }

        public IEnumerable<CompositionType> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(CompositionType item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}