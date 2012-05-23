using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiviKey.Models;

namespace CiviKey.Controllers
{
    public class HomeController : Controller
    {
        private CiviKeyEntities _entities;
        public HomeController(CiviKeyEntities c)
        {
            _entities = c;
        }

        public ActionResult Index()
        {
            ViewBag.Section = Sections.Default;
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }
    }
}
