using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CiviKey.ViewModel
{
    public class HomeViewModel
    {
        public HomeViewModel( RoadmapViewModel lastRoadmap, IList<NewsViewModel> news )
        {
            LastRoadmap = lastRoadmap;
            News = news;
        }

        public RoadmapViewModel LastRoadmap { get; private set; }
        public IList<CiviKey.ViewModel.NewsViewModel> News { get; private set; }
    }
}