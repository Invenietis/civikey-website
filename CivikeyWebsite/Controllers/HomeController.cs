using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using CK.Core;
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

        [HttpGet]
        public ActionResult Support()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Support( SupportEmailViewModel model )
        {
            if( ModelState.IsValid )
            {
                try
                {
                    Recipient[] recipients = new Recipient[1];
                    recipients[0] = new Recipient( "contact@invenietis.com" );

                    IMailerService mailer = new CK.Mailer.DefaultMailerService();
                    mailer.SendMail( model, new RazorMailTemplateKey( "SupportEmail" ), recipients );
                }
                catch( Exception ex )
                {
                    CK.Core.SystemActivityMonitor.RootLogPath = ConfigurationManager.AppSettings.Get( "LogFolderPath" ); //"~/Private/Logs" 
                    ActivityMonitor.MonitoringError.Add( ex, String.Format( "Email : {0}, Subject : {1}, Body : {2}", model.Email, model.Subject, model.Body ) );

                    return PartialView( "_EmailNotSent", model );
                }

                return PartialView( "_EmailSent" );
            }
            return PartialView( "_Form", model );
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

    public class SupportEmailViewModel : IMailConfigurator<SupportEmailViewModel>
    {
        public SupportEmailViewModel()
        {

        }

        [Required( ErrorMessage = "Veuillez sélectionner une adresse email valide" )]
        [EmailAddress( ErrorMessage = "Veuillez sélectionner une adresse email valide" )]
        public string Email { get; set; }

        [Required( ErrorMessage = "Veuillez saisir un titre pour votre question" )]
        public string Subject { get; set; }

        [Required( ErrorMessage = "Veuillez poser une question" )]
        public string Body { get; set; }

        #region IMailConfigurator<SupportEmailViewModel> Members

        public void ConfigureMail( SupportEmailViewModel model, MailParams mailParams )
        {
        }

        public string GetSubject( SupportEmailViewModel model )
        {
            return "Support Civikey";
        }

        #endregion
    }
}
