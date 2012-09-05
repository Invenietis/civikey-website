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

        public IQueryable<tRoadMap> All { get { return _c.tRoadMaps.OrderBy( x => x.Name ); } }

        public tRoadMap GetRoadmapFromId( int roadmapId )
        {
            return All.Where( x => x.Id == roadmapId ).FirstOrDefault();
        }

        public tRoadMap GetRoadmapFromVersion( string version )
        {
            return All.Where( x => x.Name == version ).SingleOrDefault();
        }

        public tRoadMap GetLastReleasedRoadmap()
        {
            tRoadMap lastRoadmap = null;
            foreach( var roadmap in All )
            {
                if( lastRoadmap == null || ( roadmap.HasRelease && lastRoadmap.CompareTo( roadmap ) < 0 ) )
                {
                    lastRoadmap = roadmap;
                }
            }
            return lastRoadmap;
        }
    }
}