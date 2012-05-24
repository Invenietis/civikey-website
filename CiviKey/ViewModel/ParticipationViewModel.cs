using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;

namespace CiviKey.ViewModel
{
    public class ParticipationViewModel
    {
        tParticipation _model;
        public ParticipationViewModel(CiviKeyEntities c, tParticipation model )
        {
            _model = model;
            Contact = new ContactViewModel( c, _model.tContactRelation );
        }

        public ContactViewModel Contact { get; private set; }

        public int Percentage { get { return _model.Percentage; } }
        public string Name { get { return Contact.Name; } }
    }
}