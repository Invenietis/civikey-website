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

        public ActionResult Index(string version, string name)
        {
            ViewBag.Roadmaps = _roadmapRepo.All.ToList().Reverse<tRoadMap>();
            ViewBag.Section = Sections.Progress;
            ViewBag.Title = "CiviKey - Avancement";

            ViewBag.RoadmapViewType = "classic";

            tRoadMap r = _roadmapRepo.GetLastReleasedRoadmap();
            ViewBag.CurrentRoadmapId = r.Id;

            RoadmapViewModel rvm = new RoadmapViewModel(r, _partnerRepo, _contactRepo, _contactRelationRepo);

            if (version != null && name != null)
            {
                tRoadMap roadVersion = _roadmapRepo.GetRoadmapFromVersion(version);
                if (roadVersion != null)
                {
                    tFeature tf = roadVersion.tFeatures.Where(x => x.Title.ToLower().Contains(name.ToLower())).FirstOrDefault();
                    if (tf != null)
                    {
                        FeatureViewModel fvm = new FeatureViewModel(tf, _partnerRepo, _contactRepo, _contactRelationRepo);
                        fvm.RoadMapVersion = version;
                        rvm.SelectedFeature = fvm;
                    }
                }
            }

            return View("Index", rvm );
        }

        protected override void OnActionExecuting( ActionExecutingContext filterContext )
        {
            // fix bug with cache
            filterContext.HttpContext.Response.Cache.SetCacheability( HttpCacheability.NoCache );

            base.OnActionExecuting( filterContext );
        }

        public ActionResult GetSpecificView( string version, string type )
        {
            ViewBag.Roadmaps = _roadmapRepo.All.ToList().Reverse<tRoadMap>();
            ViewBag.Section = Sections.Progress;
            ViewBag.Title = "CiviKey - Avancement";

            ViewBag.RoadmapViewType = type;

            tRoadMap r = _roadmapRepo.GetRoadmapFromVersion( version );
            if( r == null ) return Index(null,null);

            ViewBag.CurrentRoadmapId = r.Id;
            RoadmapViewModel rvm = new RoadmapViewModel( r, _partnerRepo, _contactRepo, _contactRelationRepo );
            return View("Index", rvm );
        }

        public ActionResult GetFeatureView( int id, string type )
        {
            ViewBag.CurrentRoadmapId = id;
            ViewBag.Roadmaps = _roadmapRepo.All.ToList().Reverse<tRoadMap>();
            ViewBag.Section = Sections.Progress;
            ViewBag.RoadmapViewType = type;

            RoadmapViewModel rvm = new RoadmapViewModel( _roadmapRepo.GetRoadmapFromId( id ), _partnerRepo, _contactRepo, _contactRelationRepo );

            if( type == "categorized" ) return PartialView( "_CategorizedRoadmapView", rvm );
            return PartialView( "_RoadmapView", rvm );
        }
    }
}
