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
    public class ProgressController : Controller
    {
        //
        // GET: /Progress/
        PartnerRepository _partnerRepo;
        ContactRepository _contactRepo;
        RoadmapRepository _roadmapRepo;
        FeatureRepository _featureRepo;
        ContactRelationRepository _contactRelationRepo;
        public ProgressController( RoadmapRepository roadmapRepo, FeatureRepository featureRepo, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo )
        {
            _roadmapRepo = roadmapRepo;
            _featureRepo = featureRepo;
            _partnerRepo = partnerRepo;
            _contactRepo = contactRepo;
            _contactRelationRepo = contactRelationRepo;
        }

        public ActionResult Index()
        {
            ViewBag.CurrentRoadmapId = 0;
            ViewBag.Roadmaps = _roadmapRepo.All.ToList().Reverse<tRoadMap>();
            ViewBag.Section = Sections.Progress;

            CategorizedRoadmapViewModel vm = new CategorizedRoadmapViewModel( _roadmapRepo.GetLastRoadmap().tFeatures, _partnerRepo, _contactRepo, _contactRelationRepo );
            return View( vm );
        }

        public ActionResult GetFeatureView( int? id )
        {
            ViewBag.CurrentRoadmapId = id;
            ViewBag.Roadmaps = _roadmapRepo.All.ToList().Reverse<tRoadMap>();
            ViewBag.Section = Sections.Progress;
            
            if( id.HasValue && id != 0 )
            {
                RoadmapViewModel rvm = new RoadmapViewModel( _roadmapRepo.GetRoadmapFromId(id.Value), _partnerRepo, _contactRepo, _contactRelationRepo );
                return PartialView( "_RoadmapView", rvm );
            }

            CategorizedRoadmapViewModel cvm = new CategorizedRoadmapViewModel( _roadmapRepo.GetLastRoadmap().tFeatures, _partnerRepo, _contactRepo, _contactRelationRepo );
            return PartialView( "_CategorizedRoadmapView", cvm );
            
        }
    }
}
