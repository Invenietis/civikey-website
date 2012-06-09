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
        FeatureViewModel _feature;
        public ParticipationViewModel( FeatureViewModel feature, tParticipation model, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo )
        {
            _model = model;
            _feature = feature;
            ContactRelation = new ContactRelationViewModel( _model.tContactRelation, partnerRepo, contactRepo, contactRelationRepo );
        }

        public ContactRelationViewModel ContactRelation { get; private set; }

        public int Percentage { get { return _model.Percentage; } }
        public DateTime ParticipationDate { get { return _model.ParticipationDate; } }

        public string Name
        {
            get { return ContactRelation.Contact.Name; }
        }
    }
}