using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;
using CiviKey.Repositories;

namespace CiviKey.ViewModel
{
    public class ContactViewModel
    {
        tContactRelation _model;
        tContact _contact;
        tContact _organization;

        public ContactViewModel( tContactRelation model, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo )
        {
            _model = model;
            _contact = contactRepo.ContactFromContactId( model.ContactId );
            _organization = partnerRepo.GetAllPartners.Where( x => x.Id == _model.EntityId ).Single();
            if( !IsOrganization ) Organization = new ContactViewModel( contactRelationRepo.All.Where( x => x.ContactId == _organization.Id ).Single(), partnerRepo, contactRepo, contactRelationRepo );
        }

        public ContactViewModel(tContact contact)
        {
            _contact = contact;
        }

        public ContactViewModel Organization { get; private set; }
        public string Name { get { return _contact.Name; } }
        public string Description { get { return _contact.Description; } }
        public bool IsOrganization { get { return _model.ContactId == _model.EntityId; } }
    }
}