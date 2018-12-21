using AIS_Library.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using AIS_Library.Models.Users;
using AIS_Library.DAO.Interfaces;

namespace AIS_Library.BL.Services
{
    public class ManageUsers : IManageUsers
    {
        private IUnitofWork db;

        public ManageUsers(IUnitofWork database)
        {
            db = database;
        }

        public IEnumerable<User> FindUserForLibrarian(DateTime start, DateTime end, string librarian)
        {
            List<User> user = new List<User>();
            var value = db.VisitLogs.GetAll();
            var models = value.Where(l => l.Librarian.User.Surname.Equals(librarian)).Where(l => l.ReturnDate >= start && l.ReturnDate <= end).ToList();

            for (int i = 0; i < models.Count; i++)
            {
                var user1 = db.Userss.Get(models[i].UserId);
                user.Add(user1);
            }
            return user;
        }

        public IEnumerable<User> GetBookUsers(string book)
        {
            List<User> user = new List<User>();
            var value = db.AbonementLogs.GetAll();
            var models = value.Where(l=> l.BookProperty.BookName.Equals(book)).Where(l => l.Issuance.Term_date > DateTime.Today).ToList();

            for (int i = 0; i < models.Count; i++)
            {
                var user1 = db.Userss.Get(models[i].UserId);
                user.Add(user1);
            }
            return user;
        }

        public IEnumerable<User> GetTimeUser(DateTime start, DateTime end, string name)
        {
            throw new NotImplementedException();

        }

        public IEnumerable<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> NotVisit(DateTime start, DateTime end)
        {
            List<User> user = new List<User>();
            var value = db.VisitLogs.GetAll();
            var models = value.Where(l => (l.Issuance.Issue_date < start && l.Issuance.Issue_date < end) || l.ReturnDate > end).ToList();

            for (int i = 0; i < models.Count; i++)
            {
                var user1 = db.Userss.Get(models[i].UserId);
                user.Add(user1);
            }
            return user;
        }

        public IEnumerable<User> Overdue()
        {
            List<User> user = new List<User>();
            var value = db.VisitLogs.GetAll();
            var models = value.Where(l => l.ReturnDate > l.Issuance.Term_date).ToList();

            for (int i = 0; i < models.Count; i++)
            {
                var user1 = db.Userss.Get(models[i].UserId);
                user.Add(user1);
            }
            return user;
        }
    }
}