using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;

namespace CiviKey.Repositories
{
    public class ContactRelationRepository
    {
        CiviKeyEntities _c;
        public ContactRelationRepository( CiviKeyEntities c )
        {
            _c = c;
        }

        public IQueryable<tContactRelation> All { get { return _c.tContactRelations; } }

        public tContactRelation ContactRelationFromContactRelationId( int contactRelationId )
        {
            return _c.tContactRelations.Where( x => x.Id == contactRelationId ).FirstOrDefault();
        }

        public tContactRelation ContactRelationFromParticipationId( int participationId )
        {
            int contactRelationId;
            tParticipation participation = _c.tParticipations.Where( x => x.Id == participationId ).FirstOrDefault();
            if( participation != null )
            {
                contactRelationId = participation.ContactId; //WARNING : that participation.ContactId is a ContactRelationId !
                return ContactRelationFromContactRelationId( contactRelationId );
            }
            return null;
        }
    }
}