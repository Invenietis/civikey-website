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
            ViewBag.Section = Sections.Progress;
            IList<FeatureViewModel> _features = new List<FeatureViewModel>();
            IQueryable<tFeature> features;

            //TODO : uncomment when the database has a roadmap table
            //if( id != null ) features = _entities.tFeatures.Where( x => x.RoadMapId == id.Value );
            //else features = _entities.tFeatures;

            features = _entities.tFeatures; //To remove when the database has a roadmap table
            foreach( var item in features )
            {
                _features.Add( new FeatureViewModel( _entities, item ) );
            }
            return View( _features );
        }
    }
}
