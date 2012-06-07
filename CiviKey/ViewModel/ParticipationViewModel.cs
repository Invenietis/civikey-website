using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;
using CiviKey.Repositories;

namespace CiviKey.ViewModel
{
    public class ParticipationViewModel
    {
        tParticipation _model;
        public ParticipationViewModel( tParticipation model, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo )
        {
            _model = model;
            Contact = new ContactViewModel( _model.tContactRelation, partnerRepo, contactRepo, contactRelationRepo );
        }

        public ContactViewModel Contact { get; private set; }

        public int Percentage { get { return _model.Percentage; } }
        public string Name { get { return Contact.Name; } }

        public override string ToString()
        {
            return Contact.Name;
        }
    }
}