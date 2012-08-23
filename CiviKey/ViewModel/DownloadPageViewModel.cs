using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CiviKey.ViewModel
{
    public class DownloadPageViewModel
    {
        public IList<ReleaseNoteViewModel> ReleaseNotes { get; set; }
        public RoadmapViewModel LastRoadmap { get; set; }

        public DownloadPageViewModel( IList<ReleaseNoteViewModel> releaseNotes, RoadmapViewModel lastRoadmap )
        {
            ReleaseNotes = releaseNotes;
            LastRoadmap = lastRoadmap;
        }
    }
}