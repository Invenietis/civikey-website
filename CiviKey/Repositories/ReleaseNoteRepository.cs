using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;

namespace CiviKey.Repositories
{
    public class ReleaseNoteRepository
    {
        CiviKeyEntities _c;
        RoadmapRepository _roadmapRepo;
        public ReleaseNoteRepository( CiviKeyEntities c, RoadmapRepository roadmapRepo )
        {
            _c = c;
            _roadmapRepo = roadmapRepo;
        }

        public IEnumerable<tReleaseNote> All { get { return _c.tReleaseNotes; } }
    }
}