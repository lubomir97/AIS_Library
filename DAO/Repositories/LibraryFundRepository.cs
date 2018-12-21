using System;
using AIS_Library.DAO.Interfaces;
using AIS_Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AIS_Library.DAO.Repositories
{
    public class LibraryFundRepository : IRepository<LibraryFund>
    {
        private ApplicationDbContext db;

        public LibraryFundRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(LibraryFund item)
        {
            LibraryFund fund = db.LibraryFunds.Add(item);
        }

        public void Delete(int id)
        {
            var value = db.LibraryFunds.Find(id);
            if (value != null)
            {
                db.LibraryFunds.Remove(value);
            }
        }

        public LibraryFund Get(int id)
        {
            LibraryFund fund = db.LibraryFunds.Find(id);

            return fund;
        }

        public IEnumerable<LibraryFund> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(LibraryFund item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}