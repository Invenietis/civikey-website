using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiviKey.Models;

namespace CiviKey.Controllers
{
    public class ProjectController : Controller
    {
        //
        // GET: /Project/

        public ActionResult Index()
        {
            ViewBag.Section = Sections.Project;
            ViewBag.Title = "CiviKey - Le projet";
            return View();
        }


    }
}
