using System;
using AIS_Library.DAO.Interfaces;
using AIS_Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AIS_Library.DAO.Repositories
{
    public class VisitLogRepository : IRepository<VisitLog>
    {
        private ApplicationDbContext db;

        public VisitLogRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(VisitLog item)
        {
            VisitLog vlog = db.VisitLogs.Add(item);
        }

        public void Delete(int id)
        {
            var value = db.VisitLogs.Find(id);
            if (value != null)
            {
                db.VisitLogs.Remove(value);
            }
        }

        public VisitLog Get(int id)
        {
            VisitLog vlog = db.VisitLogs.Find(id);
            vlog.BookProperty = db.BookProperties.Find(vlog.BookPropertyId);
            //vlog.User = db.Userss.Find(vlog.UserId);
            vlog.Issuance = db.Issuances.Find(vlog.IssuanceId);
            vlog.Librarian = db.Librarians.Find(vlog.LibrarianId);
            vlog.Librarian.User = db.Userss.Find(vlog.Librarian.UserId);

            return vlog;
        }

        public IEnumerable<VisitLog> GetAll()
        {
            IEnumerable<VisitLog> log = db.VisitLogs;
            var list = log.ToList();
            var users = db.Userss.Find(1);
            for(int i =0; i<list.Count; i++)
            {
                list[i].BookProperty = db.BookProperties.Find(list[i].BookPropertyId);
                list[i].Issuance = db.Issuances.Find(list[i].IssuanceId);
                list[i].Librarian = db.Librarians.Find(list[i].LibrarianId);
                list[i].Librarian.User = db.Userss.Find(list[i].Librarian.UserId);
                
            }
            return list;
        }

        public void Update(VisitLog item)
        {
            throw new NotImplementedException();
        }
    }
}