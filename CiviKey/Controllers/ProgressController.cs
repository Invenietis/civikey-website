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
            ViewBag.Roadmaps = _roadmapRepo.All.ToList().Reverse<tRoadMap>();
            ViewBag.Section = Sections.Progress;
            ViewBag.Title = "CiviKey - Avancement";
            ViewBag.RoadmapViewType = "classic";
            RoadmapViewModel rvm = new RoadmapViewModel( _roadmapRepo.GetLastReleasedRoadmap(), _partnerRepo, _contactRepo, _contactRelationRepo );
            if( ViewBag.RoadmapViewType == "categorized" )
            {
                ViewBag.LineCountMax = 4;
                return View( rvm );
            }

            ViewBag.LineCountMax = 3;
            return View( rvm );
        }

        public ActionResult GetFeatureView( int id, string type )
        {
            ViewBag.CurrentRoadmapId = id;
            ViewBag.Roadmaps = _roadmapRepo.All.ToList().Reverse<tRoadMap>();
            ViewBag.Section = Sections.Progress;
            ViewBag.RoadmapViewType = type;
            RoadmapViewModel rvm = new RoadmapViewModel( _roadmapRepo.GetRoadmapFromId( id ), _partnerRepo, _contactRepo, _contactRelationRepo );

            if( type == "categorized" )
            {
                ViewBag.LineCountMax = 4;
                return PartialView( "_CategorizedRoadmapView", rvm );
            }

            ViewBag.LineCountMax = 3;
            return PartialView( "_RoadmapView", rvm );
        }
    }
}
