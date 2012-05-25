using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiviKey.Models;
using CiviKey.ViewModel;

namespace CiviKey.Controllers
{
    public class FeatureController : Controller
    {

        private CiviKeyEntities _entities;
        public FeatureController( CiviKeyEntities c )
        {
            _entities = c;
        }
        //
        // GET: /Contact/

        public ActionResult Index( int id )
        {
            FeatureViewModel vm;
            ViewBag.Section = Sections.Progress;
            tFeature model = _entities.tFeatures.Where( x => x.Id == id ).FirstOrDefault();
            if( model != null )
            {
                vm = new FeatureViewModel( _entities, model );
                return View( vm );
            }
            return null; //TODO : get the proper pattern to reroute towards a 404 error
        }
    }
}
