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

            contactList = _entities.GetOrganizationList();

            foreach (tContact contact in contactList)
            {
                contactViewModel.Add(new ContactViewModel(contact, _partnerRepo, _contactRepo, _contactRelationRepo));
            }

            return View(contactViewModel);
        }


    }
}
