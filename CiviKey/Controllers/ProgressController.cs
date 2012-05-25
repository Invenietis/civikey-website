using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiviKey.Models;
using CiviKey.ViewModel;

namespace CiviKey.Controllers
{
    public class ProgressController : Controller
    {
        //
        // GET: /Progress/

        private CiviKeyEntities _entities;
        public ProgressController( CiviKeyEntities c )
        {
            _entities = c;
        }

        public ActionResult Index( int? id )
        {
            ViewBag.Roadmaps = _entities.tRoadMaps.ToList();
            ViewBag.Section = Sections.Progress;
            IList<FeatureViewModel> _features = new List<FeatureViewModel>();
            IQueryable<tFeature> features;

            if( id != null ) features = _entities.tFeatures.Where( x => x.IdRoadMap == id.Value );
            else features = _entities.tFeatures;

            foreach( var item in features )
            {
                _features.Add( new FeatureViewModel( _entities, item ) );
            }
            return View( _features );
        }
    }
}
