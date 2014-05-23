using System;
using System.Collections.Generic;
using System.IO;
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

        public void Documentation( string version )
        {
            string path =  Server.MapPath( "~/Content/files/documentation/" + version + ".docx" );
            ReturnFileStream( "Civikey-documentation-v" + version + ".docx", path );
        }

        public void Application( string version )
        {
            string path =  Server.MapPath( "~/Content/files/application/" + version + ".exe" );
            ReturnFileStream( "Civikey-v" + version + ".exe", path );
        }

        public void Keyboard( string name )
        {
            string path =  Server.MapPath( "~/Content/files/keyboards/" + name );
            ReturnFileStream( name + "xml", path );
        }

        private void ReturnFileStream( string name, string path )
        {
            if( !System.IO.File.Exists( path ) )
            {
                Response.StatusCode = 404;
                Response.StatusDescription = "Not found";
                return;
            }

            Response.Clear();
            Response.AddHeader(
                "content-disposition", string.Format( "attachment; filename={0}", name ) );

            Response.ContentType = "application/octet-stream";

            Response.WriteFile( path );
            Response.End();
        }
    }
}
