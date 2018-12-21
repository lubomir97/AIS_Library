using AIS_Library.DAO.Interfaces;
using AIS_Library.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIS_Library.DAO.Repositories
{
    public class AbonementLogRepository : IRepository<AbonementLog>
    {
        private ApplicationDbContext db;

        public AbonementLogRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(AbonementLog item)
        {
            db.AbonementLogs.Add(item);
        }

        public void Delete(int id)
        {
            //var item = db.AbonementLogs.Find(id);
            //if (item != null)
            //    db.AbonementLogs.Remove(item);
        }

        public AbonementLog Get(int id)
        {
            AbonementLog ALog = db.AbonementLogs.Find(id);
            ALog.Issuance = db.Issuances.Find(ALog.IssuanceId);
            ALog.User = db.Userss.Find(ALog.UserId);
            ALog.BookProperty = db.BookProperties.Find(ALog.BookPropertyId);
            ALog.Library = db.Libraries.Find(ALog.LibraryId);
            return ALog;
        }

        public IEnumerable<AbonementLog> GetAll()
        {
            IEnumerable<AbonementLog> log = db.AbonementLogs;
            var list = log.ToList();
            var users = db.Userss.Find(1);
            for (int i = 0; i < list.Count; i++)
            {
                list[i].BookProperty = db.BookProperties.Find(list[i].BookPropertyId);
                list[i].Issuance = db.Issuances.Find(list[i].IssuanceId);
                list[i].User = db.Userss.Find(list[i].UserId);
                list[i].Library = db.Libraries.Find(list[i].LibraryId);

            }
            return list;
        }

        public void Update(AbonementLog item)
        {
            throw new NotImplementedException();
        }
    }
}