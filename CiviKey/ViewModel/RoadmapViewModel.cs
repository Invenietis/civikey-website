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
        Dictionary<CategoryViewModel, ICollection<FeatureViewModel>> _categorizedFeatures;
        IList<ParticipationViewModel> _sponsors;
        tRoadMap _model;

        public RoadmapViewModel( tRoadMap model, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo )
        {
            _model = model;
            _categorizedFeatures = new Dictionary<CategoryViewModel, ICollection<FeatureViewModel>>();
            PopulateCollections( partnerRepo, contactRepo, contactRelationRepo, model.tFeatures, model.tParticipations );
        }

        private void PopulateCollections( PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo, ICollection<tFeature> features, ICollection<tParticipation> participations )
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

                foreach( CategoryViewModel cat in vm.Categories )
                {
                    if( !_categorizedFeatures.ContainsKey( cat ) ) _categorizedFeatures.Add( cat, new List<FeatureViewModel>() );
                    _categorizedFeatures[cat].Add( vm );
                }
            }

            _sponsors = participations.Where( x => x.PartType == ParticipationType.Sponsoring.ToString() )
            .Select( p => new ParticipationViewModel( p, partnerRepo, contactRepo, contactRelationRepo ) )
            .ToList();
        }

        public string Name { get { return _model.Name; } }
        public bool HasRelease { get { return _model.HasRelease; } }
        public int Id { get { return _model.Id; } }
        public ICollection<FeatureViewModel> Features { get { return _features; } }
        public ICollection<FeatureViewModel> NewFeatures { get { return _newFeatures; } }
        public ICollection<FeatureViewModel> UpdatedFeatures { get { return _updatedFeatures; } }
        public ICollection<FeatureViewModel> AvailableFeatures { get { return _availableFeatures; } }
        public ICollection<FeatureViewModel> UnavailableFeatures { get { return _unavailableFeatures; } }
        public Dictionary<CategoryViewModel, ICollection<FeatureViewModel>> CategorizedFeatures { get { return _categorizedFeatures; } }
        public IList<ParticipationViewModel> Sponsors { get { return _sponsors; } }
    }
}