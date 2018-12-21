using AIS_Library.BL.Interfaces;
using AIS_Library.BL.Services;
using AIS_Library.DAO.Repositories;
using AIS_Library.Models.Users;
using AIS_Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIS_Library.Controllers
{
    public class ManageLibrarianController : Controller
    {
        private IManageLibrarian service;

        public ManageLibrarianController()
        {
            service = new ManageLibrarian(new EFUnitOfWork());
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FindRoom()
        {
            return View(new List<Librarian>());
        }

        [HttpPost]
        public ActionResult FindRoom(int room)
        {
            return View(service.FindRoom(room));
        }

        public ActionResult Productivity()
        {
            return View(new List<LibrarianProductivityViewModel>());
        }

        [HttpPost]
        public ActionResult Productivity(DateTime start, DateTime end)
        {
            return View(service.GetProductivity(start,end));
        }
    }
}