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

        public IQueryable<tContact> OrganizationsFromContactId( int contactId )
        {
            return _c.tContactRelations.Where( y => y.ContactId == contactId ).Select(x => x.tContact);
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
                contactRelationId = participation.ContactRelationId;
                return ContactRelationFromContactRelationId( contactRelationId );
            }
            return null;
        }

        internal IList<tContact> GetOrganizationList()
        {
            return All.Where( x => x.ContactId == x.EntityId ).Select( y => y.tContact ).ToList();
        }
    }
}