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
        ContactRelationRepository _contactRelationRepo;
        private CiviKeyEntities _entities;
        public ProgressController( CiviKeyEntities c, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo )
        {
            _partnerRepo = partnerRepo;
            _contactRepo = contactRepo;
            _contactRelationRepo = contactRelationRepo;
            _entities = c;
        }

        public ActionResult Index( int? id )
        {
            ViewBag.CurrentRoadmapId = id != null ? id : 0;
            ViewBag.Roadmaps = _entities.tRoadMaps.ToList();
            ViewBag.Section = Sections.Progress;

            IList<FeatureViewModel> _features = new List<FeatureViewModel>();
            IQueryable<tFeature> features;
            features = _entities.tFeatures;
            foreach( var item in features )
            {
                _features.Add( new FeatureViewModel( item, _partnerRepo, _contactRepo, _contactRelationRepo ) );
            }
            return View( _features );
        }

        public ActionResult GetFeatureView( int? id )
        {
            ViewBag.CurrentRoadmapId = id;
            ViewBag.Roadmaps = _entities.tRoadMaps.ToList();
            ViewBag.Section = Sections.Progress;
            IList<FeatureViewModel> _features = new List<FeatureViewModel>();
            IQueryable<tFeature> features;

            if( id != null && id != 0 ) features = _entities.tFeatures.Where( x => x.IdRoadMap == id.Value );
            else features = _entities.tFeatures;

            foreach( var item in features )
            {
                _features.Add( new FeatureViewModel( item, _partnerRepo, _contactRepo, _contactRelationRepo ) );
            }
            return PartialView( "_FeatureList", _features );
        }
    }
}
