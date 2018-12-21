using AIS_Library.BL.Interfaces;
using AIS_Library.BL.Services;
using AIS_Library.DAO.Repositories;
using AIS_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIS_Library.Controllers
{
    public class ManageBooksController : Controller
    {
        private IManageBooks service;

        public ManageBooksController()
        {
            service = new ManageBooks(new EFUnitOfWork());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PopularBooks()
        {
            return View(service.GetPopularBooks());
        }

        [HttpGet]
        public ActionResult GetPosution()
        {
            return View(new List<LibraryFund>());
        }
        [HttpPost]
        public ActionResult GetPosution(string name)
        {
            return View(service.GetPosition(name));
        }

        public ActionResult GetPositionForAutor()
        {
            return View(new List<LibraryFund>());
        }

        [HttpPost]
        public ActionResult GetPositionForAutor(string autor)
        {
            return View(service.GetPositionForAutor(autor));
        }
    }
}