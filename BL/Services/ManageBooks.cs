using AIS_Library.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AIS_Library.Models;
using AIS_Library.DAO.Interfaces;
using AIS_Library.ViewModels;

namespace AIS_Library.BL.Services
{
    public class ManageBooks : IManageBooks
    {
        private IUnitofWork db;

        public ManageBooks(IUnitofWork database)
        {
            db = database;
        }

        public IEnumerable<BookProperty> ArrivedBooks(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookProperty> GetBooks(DateTime start, DateTime end, string user)
        {
            List<BookProperty> book = new List<BookProperty>();
            var value = db.AbonementLogs.GetAll();
            var models = value.Where(mod => mod.User.Surname.Equals(user)
            ).Where(time => time.Issuance.Issue_date >= start && time.Issuance.Issue_date <= end
            ).ToList();

            for (int i = 0; i < models.Count; i++)
            {
                var books = db.BookProperties.Get(models[i].BookPropertyId);
                book.Add(books);
            }
            return book;
        }

        public IEnumerable<BookProperty> GetBooksAnotherLibrary(DateTime start, DateTime end, int user)
        {
            List<BookProperty> book = new List<BookProperty>();
            var value = db.AbonementLogs.GetAll();
            var models = value.Where(mod => mod.User.Surname.Equals(user)
            ).Where(time => time.Issuance.Term_date >= start && time.Issuance.Term_date <= end
            ).ToList();

            for (int i = 0; i < models.Count; i++)
            {
                var books = db.BookProperties.Get(models[i].BookPropertyId);
                book.Add(books);
            }
            return book;
        }

        public IEnumerable<PopularViewModel> GetPopularBooks()
        {
            List<PopularViewModel> popular = new List<PopularViewModel>();
            List<BookProperty> book = new List<BookProperty>();
            
            var value = db.VisitLogs.GetAll().ToList();

            for (int i = 0; i < value.Count; i++)
            {
                var books = db.BookProperties.Get(value[i].BookPropertyId);
                string name = books.BookName;
                book.Add(books);
                int count = value.Count(m => m.BookPropertyId == book[i].Id);
                if (count > 2)
                {
                    popular.Add(Map(name, count));
                }
            }

            var result = popular.Distinct().ToList();

            return result;
        }

        private PopularViewModel Map(string name, int count)
        {
            var model = new  PopularViewModel
            {
                Name = name,
                Count = count
            };
            return model;
        }

        public IEnumerable<LibraryFund> GetPosition(string book)
        {
            List<LibraryFund> fund = new List<LibraryFund>();
            var value = db.BookProperties.GetAll();
            var models = value.Where(mod => mod.BookName.Equals(book)).ToList();

            for(int i = 0; i<models.Count; i++)
            {
                var books = db.LibraryFunds.Get(models[i].LibraryFund.Id);
                fund.Add(books);
            }
            return fund;

        }

        public IEnumerable<LibraryFund> GetPositionForAutor(string autor)
        {
            List<LibraryFund> fund = new List<LibraryFund>();
            var value = db.BookProperties.GetAll();
            var models = value.Where(mod => mod.Autor.Equals(autor)).ToList();

            for (int i = 0; i < models.Count; i++)
            {
                var books = db.LibraryFunds.Get(models[i].LibraryFundId);
                fund.Add(books);
            }
            return fund;
        }

        public IEnumerable<BookProperty> WrittenOffBooks(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}