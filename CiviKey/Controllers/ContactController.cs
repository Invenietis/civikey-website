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
            ViewBag.Email = System.Configuration.ConfigurationManager.AppSettings["contactmail"];
            ViewBag.Title = "CiviKey - Contactez-nous";
            return View();
        }

        [HttpPost]
        public JsonResult Send(Contact contact)
        {

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(contact.From);
            mail.To.Add(System.Configuration.ConfigurationManager.AppSettings["contactmail"]);

            mail.Subject = contact.Subject;
            mail.Body = contact.Message;

            SmtpClient smtp = new SmtpClient();
            smtp.Send(mail);

            return Json(new { success = true });
        }
    }
}
