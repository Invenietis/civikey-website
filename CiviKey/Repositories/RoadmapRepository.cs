using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;

namespace CiviKey.Repositories
{
    public class RoadmapRepository
    {
        CiviKeyEntities _c;
        public RoadmapRepository( CiviKeyEntities c )
        {
            _c = c;
        }

        public IQueryable<tRoadMap> All { get { return _c.tRoadMaps; } }

        public tRoadMap GetRoadmapFromId( int roadmapId )
        {
            return All.Where( x => x.Id == roadmapId ).FirstOrDefault();
        }

        public tRoadMap GetLastRoadmap()
        {
            tRoadMap lastRoadmap = null;
            foreach( var roadmap in All )
            {
                if( lastRoadmap == null || new Version( lastRoadmap.Name ) < new Version( roadmap.Name ) )
                {
                    lastRoadmap = roadmap;
                }
            }
            return lastRoadmap;
        }
    }
}