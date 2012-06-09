using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;
using CiviKey.Repositories;

namespace CiviKey.ViewModel
{
    public class RoadmapViewModel
    {
        ICollection<FeatureViewModel> _features;
        string _name;

        public RoadmapViewModel( tRoadMap model, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo )
        {
            _name = model.Name;
            _features = new List<FeatureViewModel>();
            foreach( tFeature feature in model.tFeatures )
            {
                _features.Add( new FeatureViewModel( feature, partnerRepo, contactRepo, contactRelationRepo ) );
            }
        }

        public RoadmapViewModel( ICollection<tFeature> features, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo )
        {
            _name = "All";
            _features = new List<FeatureViewModel>();
            foreach( tFeature feature in features )
            {
                _features.Add( new FeatureViewModel( feature, partnerRepo, contactRepo, contactRelationRepo ) );
            }
        }


        public string Name { get { return _name; } }
        public ICollection<FeatureViewModel> Features { get { return _features; } }
    }
}