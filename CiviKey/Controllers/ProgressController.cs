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

        private CiviKeyEntities _entities;
        public ProgressController( CiviKeyEntities c )
        {
            _entities = c;
        }

        public ActionResult Index()
        {
            ViewBag.Section = Sections.Progress;
            return View(_entities.tFeatures.ToList());
        }

    }
}
