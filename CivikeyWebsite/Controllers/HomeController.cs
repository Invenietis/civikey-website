using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using CK.Core;
using CivikeyWebsite.Models;
using CK.Mailer;

namespace CivikeyWebsite.Controllers
{
    public class HomeController : Controller
    {
        protected string DestinationEmail
        {
            get { return AppSettings.Default.GetRequired<string>( "DestinationEmail" ); }
        }

        public ActionResult Index()
        {
            return View();
        }

        [Route( "comment-utiliser-Civikey" )]
        public ActionResult GetStarted()
        {
            return View();
        }

        [Route( "les-fonctionnalites-de-Civikey" )]
        public ActionResult Features()
        {
            return View();
        }

        [Route( "bibliotheque-de-claviers-Civikey" )]
        public ActionResult Keyboards()
        {
            return View();
        }

        [HttpGet]
        [Route( "support-utilisateur" )]
        public ActionResult Support()
        {
            return View();
        }

        [HttpPost]
        [Route( "support-utilisateur" )]
        public ActionResult Support( SupportEmailViewModel model )
        {
            IActivityMonitor m = new ActivityMonitor();
            if( ModelState.IsValid )
            {
                using( m.OpenInfo().Send( "Sending Support mail to {0}", DestinationEmail ) )
                {
                    try
                    {
                        IMailerService mailer = new CK.Mailer.DefaultMailerService( m );
                        mailer.SendMail( model, new RazorMailTemplateKey( "SupportEmail" ), new Recipient( DestinationEmail ) );
                    }
                    catch( Exception ex )
                    {
                        m.Error().Send( ex, "Email : {0}, Subject : {1}, Body : {2}", model.Email, model.Subject, model.Body );
                        return PartialView( "_EmailNotSent", model );
                    }
                }

                return PartialView( "_EmailSent" );
            }
            return PartialView( "_Form", model );
        }

        public void Documentation( string version )
        {
            string path =  Server.MapPath( "~/Content/files/documentation/" + version + ".pdf" );
            ReturnFileStream( "Civikey-documentation-v" + version + ".pdf", path );
        }

        public void Application( string version )
        {
            string path =  Server.MapPath( "~/Content/files/application/" + version + ".exe" );
            ReturnFileStream( "Civikey-v" + version + ".exe", path );
        }

        public void Keyboard( string name )
        {
            string path =  Server.MapPath( "~/Content/files/keyboards/" + name );
            ReturnFileStream( name, path );
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

        public ActionResult AddKeyboard( KeyboardModel keyboard )
        {
            IActivityMonitor m = new ActivityMonitor();

            KeyboardPostError err = KeyboardPostError.None;

            string uploadedFolderPath = AppSettings.Default.GetRequired<string>( "UploadFolderPath" );

            using( m.OpenInfo().Send( "Try AddKeyboard" ) )
            {
                if( ModelState.IsValid )
                {
                    if( Request.Files.Count > 0 )
                    {
                        string filePath = Path.Combine( uploadedFolderPath, String.Format( "{0}-{1}", keyboard.Name, Guid.NewGuid() ) );
                        Request.Files[0].SaveAs( filePath );

                        using( m.OpenInfo().Send( "Sending Keyboard submitted mail to {0}", DestinationEmail ) )
                        {
                            var model = new KeyboardSubmittedMailModel()
                            {
                                Name = keyboard.Name,
                                Description = keyboard.Description,
                                Email = keyboard.Email,
                                Author = keyboard.Author
                            };
                            try
                            {
                                IMailerService mailer = new CK.Mailer.DefaultMailerService( activityLogger: m );
                                mailer.SendMail( model, new RazorMailTemplateKey( "KeyboardSubmitted" ), new Recipient( DestinationEmail ) );
                            }
                            catch( Exception ex )
                            {
                                m.Error().Send( ex, "Email : {0}, Subject : {1}, Name : {2}, Description : {3}, Author : {4}",
                                    model.Email, model.Subject, model.Name, model.Description, model.Author );
                            }
                        }

                    }
                    else
                    {
                        err = KeyboardPostError.MissingPicture;
                        m.Error().Send( "Missing file." );
                    }
                }
                else
                {
                    err = KeyboardPostError.InvalidForm;
                    m.Error().Send( "InvalidForm" );
                }
                return Json( new { valid = false, error = err, keyboard = keyboard } );
            }
        }
    }

}
