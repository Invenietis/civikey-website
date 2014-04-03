using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CivikeyWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetStarted()
        {
            return View();
        }

        public ActionResult Features()
        {
            return View();
        }

        public ActionResult Keyboards()
        {
            return View();
        }

        public void Keyboard(string name)
        {
            Response.Clear();
            Response.AddHeader(
                "content-disposition", string.Format( "attachment; filename={0}", name ) );

            Response.ContentType = "application/octet-stream";

            Response.WriteFile( Server.MapPath( "~/Content/files/keyboards/" + name ) );
            Response.End();
        }

    }
}
