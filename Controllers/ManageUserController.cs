using AIS_Library.BL.Interfaces;
using AIS_Library.BL.Services;
using AIS_Library.DAO.Interfaces;
using AIS_Library.DAO.Repositories;
using AIS_Library.Models;
using AIS_Library.Models.Users;
using AIS_Library.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace AIS_Library.Controllers
{
    public class ManageUserController : Controller
    {
        private IManageUsers service;

        public ManageUserController()
        {
            service = new ManageUsers(new EFUnitOfWork());
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowLibrarian()
        {
            return View();
        }
        [HttpGet]
        public ActionResult FindLibrarian()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FindLibrarian(FindUserForLibrarian librarian)
        {
            return View("ShowLibrarian",service.FindUserForLibrarian(librarian.StartDate,librarian.EndDate,librarian.Name));
        }

        [HttpGet]
        public ActionResult GetBook()
        {
            return View(new List<User>());
        }
        [HttpPost]
        public ActionResult GetBook(string book)
        {
            return View(service.GetBookUsers(book));
        }

        [HttpGet]
        public ActionResult NoVisit()
        {
            return View(new List<User>());
        }

        [HttpPost]
        public ActionResult NoVisit( DateTime start, DateTime end)
        {
            return View(service.NotVisit(start, end));
        }

        public ActionResult Overdue()
        {
            return View(service.Overdue());
        }
    }
}