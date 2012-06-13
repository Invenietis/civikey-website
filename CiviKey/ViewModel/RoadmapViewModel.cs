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
        ICollection<FeatureViewModel> _newFeatures;
        ICollection<FeatureViewModel> _updatedFeatures;
        ICollection<FeatureViewModel> _availableFeatures;
        ICollection<FeatureViewModel> _unavailableFeatures;
        string _name;

        public RoadmapViewModel( tRoadMap model, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo )
        :this(model.tFeatures, partnerRepo, contactRepo, contactRelationRepo, model.Name)
        {
        }

        public RoadmapViewModel( ICollection<tFeature> features, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo )
            : this( features, partnerRepo, contactRepo, contactRelationRepo, "All" )
        {
        }


        public RoadmapViewModel( ICollection<tFeature> features, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo, string name )
        {
            _name = name;
            PopulateCollections( partnerRepo, contactRepo, contactRelationRepo, features );
        }

        private void PopulateCollections( PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo, ICollection<tFeature> features )
        {
            _features = new List<FeatureViewModel>();
            _newFeatures = new List<FeatureViewModel>();
            _updatedFeatures = new List<FeatureViewModel>();
            _availableFeatures = new List<FeatureViewModel>();
            _unavailableFeatures = new List<FeatureViewModel>();

            foreach( tFeature feature in features )
            {
                FeatureViewModel vm = new FeatureViewModel( feature, partnerRepo, contactRepo, contactRelationRepo );
                _features.Add( vm );
                switch( vm.Type )
                {
                    case FeatureType.New:
                        _newFeatures.Add( vm );
                        break;
                    case FeatureType.Update:
                        _updatedFeatures.Add( vm );
                        break;
                    case FeatureType.Available:
                        _availableFeatures.Add( vm );
                        break;
                    default:
                        _unavailableFeatures.Add( vm );
                        break;
                }
            }
        }

        public string Name { get { return _name; } }
        public ICollection<FeatureViewModel> Features { get { return _features; } }
        public ICollection<FeatureViewModel> NewFeatures { get { return _newFeatures; } }
        public ICollection<FeatureViewModel> UpdatedFeatures { get { return _updatedFeatures; } }
        public ICollection<FeatureViewModel> AvailableFeatures { get { return _availableFeatures; } }
        public ICollection<FeatureViewModel> UnavailableFeatures { get { return _unavailableFeatures; } }
    }
}