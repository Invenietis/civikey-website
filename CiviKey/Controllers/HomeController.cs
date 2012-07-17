using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiviKey.Models;
using CiviKey.Repositories;
using CiviKey.ViewModel;

namespace CiviKey.Controllers
{
    public class HomeController : Controller
    {
        Random _rand;
        TestimonyRepository _testiRepo;
        NewsRepository _newsRepo;
        RoadmapRepository _roadmapRepo;
        PartnerRepository _partnerRepo;
        ContactRepository _contactRepo;
        ContactRelationRepository _contactRelationRepo;

        public HomeController( ContactRelationRepository contactRelationRepo, ContactRepository contactRepo, PartnerRepository partnerRepo, RoadmapRepository roadmapRepo, TestimonyRepository testiRepo, NewsRepository newsRepo )
        {
            _contactRelationRepo = contactRelationRepo;
            _contactRepo = contactRepo;
            _partnerRepo = partnerRepo;
            _roadmapRepo = roadmapRepo;
            _testiRepo = testiRepo;
            _newsRepo = newsRepo;
            _rand = new Random( DateTime.Now.Millisecond );
        }

        public ActionResult Index()
        {
            ViewBag.Section = Sections.Default;
            ViewBag.Title = "CiviKey - Accueil";
            IList<tNew> news = _newsRepo.All;
            IList<NewsViewModel> newsVms = new List<NewsViewModel>();
            for( int i = 0; i < news.Count; i++ )
            {
                newsVms.Add( new NewsViewModel( news.ElementAt( i ) ) );
            }

            RoadmapViewModel rvm = new RoadmapViewModel( _roadmapRepo.GetLastReleasedRoadmap(), _partnerRepo, _contactRepo, _contactRelationRepo );
            HomeViewModel h = new HomeViewModel( rvm, newsVms );

            return View( h );
        }

        public ActionResult GetTestimonyView( int? currentTestimonyId )
        {
            ICollection<tTestimony> testimonies = _testiRepo.All;

            tTestimony foundTestimony = null;
            if( testimonies.Count == 0 ) return null;
            do
            {
                int index = _rand.Next( 0, testimonies.Count );
                foundTestimony = testimonies.ElementAt( index );
            } while( foundTestimony == null || ( currentTestimonyId.HasValue && foundTestimony.Id == currentTestimonyId ) && testimonies.Count > 1 );

            ViewBag.currentTestimonyId = foundTestimony.Id;

            return PartialView( "_TestimonyView", new TestimonyViewModel( foundTestimony ) );
        }
    }
}
