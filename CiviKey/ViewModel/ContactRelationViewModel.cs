using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;
using CiviKey.Repositories;

namespace CiviKey.ViewModel
{
    public class ContactRelationViewModel
    {
        tContactRelation _model;
        ContactViewModel _contact;
        ContactViewModel _organization;
        public ContactRelationViewModel( tContactRelation model, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo )
        {
            _model = model;
            _contact = new ContactViewModel( _model.tContact, partnerRepo, contactRepo, contactRelationRepo );
            _organization = new ContactViewModel( _model.tOrganization, partnerRepo, contactRepo, contactRelationRepo );
        }
        public ContactViewModel Contact { get { return _contact; } }
        public ContactViewModel Organization { get { return _organization; } }
        public DateTime StartDate { get { return _model.StartDate; } }
        public DateTime? EndDate { get { return _model.EndDate; } }
    }
}