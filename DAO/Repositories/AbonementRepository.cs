using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AIS_Library.Models;
using AIS_Library.DAO.Interfaces;
using System.Data.Entity;

namespace AIS_Library.DAO.Repositories
{
    public class AbonementRepository : IRepository<Abonement>
    {
        private ApplicationDbContext db;

        public AbonementRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(Abonement item)
        {
            db.Abonements.Add(item);
        }

        public void Delete(int id)
        {
            var Abonement = db.Abonements.Find(id);
            if(Abonement!= null)
            {
                db.Abonements.Remove(Abonement);
            }
        }

        public Abonement Get(int id)
        {
            Abonement abn = db.Abonements.Find(id);
            abn.User = db.Userss.Find(abn.UserId);
            abn.Library = db.Libraries.Find(abn.LibraryId);

            return abn;
        }

        public IEnumerable<Abonement> GetAll()
        {
            return db.Abonements.ToList();
        }

        public void Update(Abonement item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
