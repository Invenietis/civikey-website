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

            Random rng = new Random();
            int n = contactViewModel.Count;
            while( n > 1 )
            {
                n--;
                int k = rng.Next( n + 1 );
                ContactViewModel value = contactViewModel[k];
                contactViewModel[k] = contactViewModel[n];
                contactViewModel[n] = value;
            }  

            return View(contactViewModel);
        }

    }
}
