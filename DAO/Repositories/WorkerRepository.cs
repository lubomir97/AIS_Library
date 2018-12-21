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
    public class WorkerRepository : IRepository<Worker>
    {
        private ApplicationDbContext db;

        public WorkerRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(Worker item)
        {
            Worker wrk = db.Workers.Add(item);
        }

        public void Delete(int id)
        {
            var value = db.Workers.Find(id);
            if (value != null)
            {
                db.Workers.Remove(value);
            }
        }

        public Worker Get(int id)
        {
            Worker wrk = db.Workers.Find(id);
            wrk.Organization = db.Organizations.Find(wrk.OrganizationId);
            wrk.User = db.Userss.Find(wrk.UserId);

            return wrk;
        }

        public IEnumerable<Worker> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Worker item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}