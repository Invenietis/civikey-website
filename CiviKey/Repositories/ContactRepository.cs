using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;

namespace CiviKey.Repositories
{
    public class ContactRepository
    {
        CiviKeyEntities _c;
        public ContactRepository( CiviKeyEntities c )
        {
            _c = c;
        }

        public IQueryable<tContact> All { get { return _c.tContacts; } }

        public tContact ContactFromContactId (int contactId )
        {
            return _c.tContacts.Where( x => x.Id == contactId ).FirstOrDefault();
        }

        public tContact ContactFromContactRelationId( int contactRelationId )
        {
            tContactRelation contactRelation = _c.tContactRelations.Where( x => x.Id == contactRelationId ).FirstOrDefault();
            if( contactRelation != null )
            {
                return ContactFromContactId( contactRelation.ContactId );
            }
            return null;
        }

        public tContact ContactFromParticipationId( int participationId )
        {
            int contactRelationId;
            tParticipation participation = _c.tParticipations.Where( x => x.Id == participationId ).FirstOrDefault();
            if( participation != null )
            {
                contactRelationId = participation.ContactRelationId; //WARNING : that participation.ContactId is a ContactRelationId !
                return ContactFromContactRelationId( contactRelationId );
            }
            return null;
        }
    }
}