using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;

namespace CiviKey.Repositories
{
    public class ParticipationRepository
    {
        CiviKeyEntities _c;
        public ParticipationRepository( CiviKeyEntities c )
        {
            _c = c;
        }

        public IQueryable<tParticipation> All { get { return _c.tParticipations; } }
        public IQueryable<tParticipation> AllByFeatureId(int featureId)
        {
            return _c.tParticipations.Where( x => x.tFeature.Id == featureId ); 
        }

        public IQueryable<tParticipation> AllByPluginId( int featureId )
        {
            return _c.tParticipations.Where( x => x.tFeature.Id == featureId );
        }
    }
}