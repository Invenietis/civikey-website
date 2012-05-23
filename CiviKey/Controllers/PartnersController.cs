using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiviKey.Models;

namespace CiviKey.Controllers
{
    public class PartnersController : Controller
    {
        //
        // GET: /Partners/

        public ActionResult Index()
        {
            ViewBag.Section = Sections.Partners;
            return View();
        }

    }
}
