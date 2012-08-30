using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiviKey.Models;
using System.Net.Mail;

namespace CiviKey.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        public ActionResult Index()
        {
            ViewBag.Section = Sections.Contact;
            ViewBag.Email = ViewBag.FonctionalEmail = System.Configuration.ConfigurationManager.AppSettings["fonctionalcontactmail"];
            ViewBag.TechEmail = System.Configuration.ConfigurationManager.AppSettings["techcontactmail"];
            ViewBag.Title = "CiviKey - Contactez-nous";
            return View();
        }

        [HttpPost]
        public JsonResult Send( Contact contact, bool techQuestion )
        {
            string contactMail = System.Configuration.ConfigurationManager.AppSettings["fonctionalcontactmail"];

            if( techQuestion )
            {
                string techcontact = System.Configuration.ConfigurationManager.AppSettings["techcontactmail"];
                contactMail = String.IsNullOrWhiteSpace( techcontact ) ? contactMail : techcontact;
            }

            if( String.IsNullOrWhiteSpace( contactMail ) ) return Json( new { success = false } );

            MailMessage mail = new MailMessage();
            mail.To.Add( contactMail );

            if (String.IsNullOrWhiteSpace(contact.Message) 
                || String.IsNullOrWhiteSpace(contact.Subject)
                || String.IsNullOrWhiteSpace(contact.From)) return Json(new { success = false });
            mail.Subject = contact.Subject;
            mail.Body = "Message venant de l'adresse : " + contact.From + "<br/><br/>" + contact.Message.Replace("\r\n", "<br/>");
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Send( mail );

            return Json( new { success = true } );
        }

        public ActionResult GetMailForm( string type )
        {
            if( type == "tech" )
                ViewBag.Email = System.Configuration.ConfigurationManager.AppSettings["techcontactmail"];
            else
                ViewBag.Email = System.Configuration.ConfigurationManager.AppSettings["fonctionalcontactmail"];

            return PartialView( "_MailView" );
        }
    }
}
