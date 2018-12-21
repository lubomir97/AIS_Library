using AIS_Library.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AIS_Library.Models.Users;
using AIS_Library.DAO.Interfaces;
using Microsoft.Ajax.Utilities;
using AIS_Library.ViewModels;

namespace AIS_Library.BL.Services
{
    public class ManageLibrarian : IManageLibrarian
    {
        private IUnitofWork db;

        public ManageLibrarian(IUnitofWork database)
        {
            db = database;
        }

        public IEnumerable<Librarian> FindRoom(int room)
        {
            var value = db.Librarians.GetAll();
            var models = value.Where(l => l.ReadingRoomId == room).ToList();
            
            return models;
        }

        public IEnumerable<LibrarianProductivityViewModel> GetProductivity(DateTime start, DateTime end)
        {
            List<LibrarianProductivityViewModel> result = new List<LibrarianProductivityViewModel>();
            var value = db.VisitLogs.GetAll();
            var models = value.Where(l => l.ReturnDate >= start && l.ReturnDate <= end).ToList();
            for (int i = 0; i < models.Count; i++)
            {
                var libr = db.Librarians.Get(models[i].LibrarianId);
                string name = libr.User.Surname;
                int count = models.Count(m => m.LibrarianId == libr.Id);
                result.Add(Map(name, count));
            }

            return result;
        }

    

        private LibrarianProductivityViewModel Map(string name, int count)
        {
            var model = new LibrarianProductivityViewModel
            {
                Name = name,
                Number = count
            };
            return model; 
        }
    }
}