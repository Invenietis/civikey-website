using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiviKey.Models;

namespace CiviKey.Controllers
{
    public class ProgressController : Controller
    {
        //
        // GET: /Progress/

        public ActionResult Index()
        {
            ViewBag.Section = Sections.Progress;
            return View();
        }

    }
}
