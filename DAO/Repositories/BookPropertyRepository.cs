using AIS_Library.DAO.Interfaces;
using AIS_Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace AIS_Library.DAO.Repositories
{
    public class BookPropertyRepository : IRepository<BookProperty>
    {
        private ApplicationDbContext db;

        public BookPropertyRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(BookProperty item)
        {
            BookProperty bp = db.BookProperties.Add(item);
        }

        public void Delete(int id)
        {
            var book = db.BookProperties.Find(id);
            if (book != null)
            {
                db.BookProperties.Remove(book);
            }
        }

        public BookProperty Get(int id)
        {
            BookProperty bp = db.BookProperties.Find(id);
            bp.CompositionType = db.CompositionTypes.Find(bp.CompositionTypeId);
            bp.UsingRules = db.UsingRuless.Find(bp.UsingRulesId);
            bp.LibraryFund = db.LibraryFunds.Find(bp.LibraryFundId);
            return bp;
        }

        public IEnumerable<BookProperty> GetAll()
        {
            IEnumerable<BookProperty> book = db.BookProperties;
            var list = book.ToList();

            for (int i = 0; i < list.Count; i++)
            {
                list[i].CompositionType = db.CompositionTypes.Find(list[i].CompositionTypeId);
                list[i].UsingRules = db.UsingRuless.Find(list[i].UsingRulesId);
                list[i].LibraryFund = db.LibraryFunds.Find(list[i].LibraryFundId);

            }
            return list;
        }

        public void Update(BookProperty item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}