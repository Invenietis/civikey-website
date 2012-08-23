using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiviKey.Repositories;
using CiviKey.ViewModel;

namespace CiviKey.Controllers
{
    public class DownloadPageController : Controller
    {
        ReleaseNoteRepository _releaseNoteRepo;
        PartnerRepository _partnerRepo;
        ContactRepository _contactRepo;
        ContactRelationRepository _contactRelationRepo;
        RoadmapRepository _roadmapRepo;

        public DownloadPageController( ReleaseNoteRepository releaseNoteRepo, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo, RoadmapRepository roadmapRepo )
        {
            _releaseNoteRepo = releaseNoteRepo;
            _partnerRepo = partnerRepo;
            _contactRepo = contactRepo;
            _contactRelationRepo = contactRelationRepo;
            _roadmapRepo = roadmapRepo;
        }

        public ActionResult Index()
        {
            IList<ReleaseNoteViewModel> list = new List<ReleaseNoteViewModel>();

            foreach( var item in _releaseNoteRepo.All.ToList() )
            {
                ReleaseNoteViewModel rnvm = new ReleaseNoteViewModel( item, _partnerRepo, _contactRepo, _contactRelationRepo );
                if(rnvm.LinkedRoadmap.HasRelease)
                    list.Add( rnvm );
            }
            list = list.OrderByDescending( x => x.Version ).ToList();
            DownloadPageViewModel dpvm = new DownloadPageViewModel( list, new RoadmapViewModel( _roadmapRepo.GetLastReleasedRoadmap(), _partnerRepo, _contactRepo, _contactRelationRepo ) );
            return View( dpvm );
        }

    }
}
