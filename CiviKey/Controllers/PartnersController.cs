using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiviKey.Models;
using CiviKey.ViewModel;
using CiviKey.Repositories;
using System.IO;

namespace CiviKey.Controllers
{
    public class PartnersController : Controller
    {
        private ContactRelationRepository _entities;

        PartnerRepository _partnerRepo;
        ContactRepository _contactRepo;
        ContactRelationRepository _contactRelationRepo;

        public PartnersController( ContactRelationRepository c, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo )
        {
            _entities = c;
            _partnerRepo = partnerRepo;
            _contactRepo = contactRepo;
            _contactRelationRepo = contactRelationRepo;
        }

        public ActionResult Index()
        {
            IList<tContact> organisationList;
            IList<ContactViewModel> organizationViewModels = new List<ContactViewModel>();
            ViewBag.Section = Sections.Partners;

            organisationList = _entities.GetOrganizationList();

            foreach( tContact contact in organisationList )
            {
                organizationViewModels.Add( new ContactViewModel( contact, _partnerRepo, _contactRepo, _contactRelationRepo, Helpers.GetPartnerSpecificView(ControllerContext, contact.SafeName).View != null ) );
            }

            Random rng = new Random( DateTime.Now.Hour );
            int n = organizationViewModels.Count;
            while( n > 1 )
            {
                n--;
                int k = rng.Next( n + 1 );
                ContactViewModel value = organizationViewModels[k];
                organizationViewModels[k] = organizationViewModels[n];
                organizationViewModels[n] = value;
            }

            ViewBag.Title = "CiviKey - Partenaires";
            return View( organizationViewModels );
        }

        public ActionResult GetPartnerPage( string safeName )
        {
            ViewEngineResult result = Helpers.GetPartnerSpecificView( ControllerContext, safeName );
            if( result.View == null )
            {
                tContact contact = _contactRepo.ContactFromContactSafeName( safeName );
                if( contact != null )
                {
                    string websiteUrl = contact.WebsiteUrl;
                    if( !String.IsNullOrEmpty( websiteUrl ) )
                    {
                        return Redirect( websiteUrl );
                    }
                }
                return RedirectToAction( "Index" );
            }
            return View( result.View );
        }
    }
}
