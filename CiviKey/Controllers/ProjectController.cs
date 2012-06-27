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
    public class ProjectController : Controller
    {
        private ContactRelationRepository _entities;

        PartnerRepository _partnerRepo;
        ContactRepository _contactRepo;
        ContactRelationRepository _contactRelationRepo;

        public ProjectController(ContactRelationRepository c, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo)
        {
            _entities = c;
            _partnerRepo = partnerRepo;
            _contactRepo = contactRepo;
            _contactRelationRepo = contactRelationRepo;
        }

        public ActionResult Index()
        {
            ViewBag.Section = Sections.Project;
            ViewBag.Title = "CiviKey - Le projet";
            IList<tContact> contactList;
            IList<ContactViewModel> contactViewModel = new List<ContactViewModel>();

            contactList = _entities.GetContactList();

            foreach (tContact contact in contactList)
            {
                contactViewModel.Add(new ContactViewModel(contact, _partnerRepo, _contactRepo, _contactRelationRepo));
            }

            Random rng = new Random();
            int n = contactViewModel.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                ContactViewModel value = contactViewModel[k];
                contactViewModel[k] = contactViewModel[n];
                contactViewModel[n] = value;
            }
            return View(contactViewModel);
        }


    }
}
