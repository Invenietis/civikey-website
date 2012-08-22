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
    public enum ProgressDisplayTypes
    {
        classic,
        categorized
    }


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

        private void ConfigureViewBag( int id, string type )
        {
            ProgressDisplayTypes progressType;
            if( !Enum.TryParse<ProgressDisplayTypes>( type, out progressType) ) progressType = ProgressDisplayTypes.classic;
            ViewBag.Roadmaps = _roadmapRepo.All.ToList().Reverse<tRoadMap>();
            ViewBag.Section = Sections.Progress;
            ViewBag.Title = "CiviKey - Avancement";
            ViewBag.RoadmapViewType = progressType.ToString();
            ViewBag.CurrentRoadmapId = id;
        }

        public ActionResult Index( string version, string name, string type )
        {
            tRoadMap r = _roadmapRepo.GetLastReleasedRoadmap();
            ConfigureViewBag( r.Id, type );

            RoadmapViewModel rvm = new RoadmapViewModel( r, _partnerRepo, _contactRepo, _contactRelationRepo );

            if( version != null && name != null )
            {
                tRoadMap roadVersion = _roadmapRepo.GetRoadmapFromVersion( version );
                if( roadVersion != null )
                {
                    tFeature tf = roadVersion.tFeatures.Where( x => x.Title.ToLower().Contains( name.ToLower() ) ).FirstOrDefault();
                    if( tf != null )
                    {
                        FeatureViewModel fvm = new FeatureViewModel( tf, _partnerRepo, _contactRepo, _contactRelationRepo );
                        fvm.RoadMapVersion = version;
                        rvm.SelectedFeature = fvm;
                    }
                }
            }

            return View( "Index", rvm );
        }

        public ActionResult GetSpecificView( string version, string type )
        {
            RoadmapViewModel rvm = new RoadmapViewModel( _roadmapRepo.GetRoadmapFromVersion( version ), _partnerRepo, _contactRepo, _contactRelationRepo );
            if( rvm == null ) return Index( null, null, null );

            ConfigureViewBag( rvm.Id, type );

            return View( "Index", rvm );
        }

        public ActionResult GetFeatureView( string version, string type )
        {
            RoadmapViewModel rvm = new RoadmapViewModel( _roadmapRepo.GetRoadmapFromVersion( version ), _partnerRepo, _contactRepo, _contactRelationRepo );
            if( rvm == null ) return Index( null, null, null );

            ConfigureViewBag( rvm.Id, type );

            if( type == "categorized" ) return PartialView( "_CategorizedRoadmapView", rvm );
            return PartialView( "_RoadmapView", rvm );
        }

        protected override void OnActionExecuting( ActionExecutingContext filterContext )
        {
            // fix bug with cache
            filterContext.HttpContext.Response.Cache.SetCacheability( HttpCacheability.NoCache );

            base.OnActionExecuting( filterContext );
        }
    }
}
