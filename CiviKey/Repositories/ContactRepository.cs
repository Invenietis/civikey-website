using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;
using System.Data.Objects;

namespace CiviKey.Repositories
{
    public class ContactRepository
    {
        CiviKeyEntities _c;
        public ContactRepository( CiviKeyEntities c )
        {
            _c = c;
        }

        public IQueryable<tContact> AllContactsFromEntityId( int entityId )
        {
            IList<int> contactsIdList = _c.tContactRelations.Where(x=>x.EntityId == entityId && x.ContactId != entityId).Select(x=>x.ContactId).ToList();
            return _c.tContacts.Where( x => contactsIdList.Contains( x.Id ) );
        }

        public IQueryable<tContact> All { get { return _c.tContacts; } }

        public tContact ContactFromContactId (int contactId )
        {
            return _c.tContacts.Where( x => x.Id == contactId ).FirstOrDefault();
        }

        public tContact ContactFromContactSafeName( string safeName )
        {
            ObjectResult<int?> obj = _c.GetContactIdFromSafeName( safeName );
            IList<int?> ids = obj.ToList();
            int? id = ids.FirstOrDefault();
            if( id.HasValue ) return _c.tContacts.Where( x => x.Id == id.Value ).FirstOrDefault();
            return null;
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