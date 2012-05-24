using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;

namespace CiviKey.ViewModel
{
    public class ContactViewModel
    {
        CiviKeyEntities _c;
        tContactRelation _model;
        tContact _contact;
        tContact _organization;

        public ContactViewModel( CiviKeyEntities c, tContactRelation model )
        {
            _c = c;
            _model = model;
            _contact = c.tContacts.Where( x => x.Id == _model.ContactId ).Single();
            _organization = c.tContacts.Where( x => x.Id == _model.EntityId ).Single();
            if( !IsOrganization ) Organization = new ContactViewModel( _c, _c.tContactRelations.Where(x => x.ContactId == _organization.Id).Single() );
        }

        public ContactViewModel Organization { get; private set; }
        public string Name { get { return _contact.Name; } }
        public bool IsOrganization { get { return _model.ContactId == _model.EntityId; } }
    }
}