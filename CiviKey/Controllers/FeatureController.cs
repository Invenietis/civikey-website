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
    public class FeatureController : Controller
    {
        PartnerRepository _partnerRepo;
        ContactRepository _contactRepo;
        ContactRelationRepository _contactRelationRepo;
        private CiviKeyEntities _entities;
        public FeatureController( CiviKeyEntities c, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo)
        {
            _partnerRepo = partnerRepo;
            _contactRepo = contactRepo;
            _contactRelationRepo = contactRelationRepo;
            _entities = c;
        }
        //
        // GET: /Contact/

        public ActionResult Index( int id )
        {
            FeatureViewModel vm;
            ViewBag.Section = Sections.Progress;
            string version;

            version = _entities.tFeatures.Where(x => x.Id == id).FirstOrDefault().tRoadMap.Name;
            tFeature model = _entities.tFeatures.Where( x => x.Id == id ).FirstOrDefault();
            if( model != null )
            {
                vm = new FeatureViewModel( model, _partnerRepo, _contactRepo, _contactRelationRepo );
                vm.RoadMapVersion = version;
                return PartialView( vm );
            }
            return null; //TODO : get the proper pattern to reroute towards a 404 error
        }
    }
}
