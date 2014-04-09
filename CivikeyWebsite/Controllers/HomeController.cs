using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using CivikeyWebsite.Models;
using CK.Mailer;

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
            string path =  Server.MapPath( "~/Content/files/keyboards/" + name );
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

            Response.WriteFile( Server.MapPath( "~/Content/files/keyboards/" + name ) );
            Response.End();
        }

        public ActionResult AddKeyboard( KeyboardModel keyboard )
        {
            KeyboardPostError err = KeyboardPostError.None;
            IMailerService mailer = new DefaultMailerService();
            mailer.SendMail( new KeyboardSubmittedMailModel() {
                Name = keyboard.Name,
                Description = keyboard.Description,
                Email = keyboard.Email,
                Author = keyboard.Author
            },
                new RazorMailTemplateKey( "KeyboardSubmitted" ), 
                new Recipient[] { new Recipient( "jeanloup.kahloun@invenietis.com" ) } );

            if(ModelState.IsValid)
            {
                if( Request.Files.Count > 0 )
                {
                    //Request.Files[0].SaveAs( "" );
                }
                else
                {
                    err = KeyboardPostError.MissingPicutre;
                }
            }
            else
            {
                err = KeyboardPostError.InvalidForm;
            }

            return Json( new { valid = false, error = err, keyboard = keyboard } );
        }
    }
}
