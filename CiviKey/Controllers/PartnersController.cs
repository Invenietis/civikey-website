using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiviKey.Models;
using CiviKey.ViewModel;
using CiviKey.Repositories;

namespace CiviKey.Controllers
{
    public class PartnersController : Controller
    {
        private ContactRelationRepository _entities;
        

        public PartnersController(ContactRelationRepository c)
        {
            _entities = c;
        }

        public ActionResult Index()
        {
            IList<tContact> contactList;
            IList<ContactViewModel> contactViewModel = new List<ContactViewModel>();
            ViewBag.Section = Sections.Partners;


            contactList = _entities.GetContactList();
            
            foreach (tContact i in contactList)
            {
                contactViewModel.Add(new ContactViewModel(i));
            }

            return View(contactViewModel);
        }

    }
}
