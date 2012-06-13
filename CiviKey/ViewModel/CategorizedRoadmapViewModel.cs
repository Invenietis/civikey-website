using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;
using CiviKey.Repositories;

namespace CiviKey.ViewModel
{
    public class CategorizedRoadmapViewModel
    {
        Dictionary<string, ICollection<FeatureViewModel>> _categorizedFeatures;
        string _name;
        ICollection<FeatureViewModel> _features;

        public CategorizedRoadmapViewModel( tRoadMap model, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo )
            : this( model.tFeatures, partnerRepo, contactRepo, contactRelationRepo, model.Name )
        {
        }

        /// <summary>
        /// This constructor sets "All" as roadmap name.
        /// </summary>
        /// <param name="features"></param>
        /// <param name="partnerRepo"></param>
        /// <param name="contactRepo"></param>
        /// <param name="contactRelationRepo"></param>
        public CategorizedRoadmapViewModel( ICollection<tFeature> features, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo )
            : this( features, partnerRepo, contactRepo, contactRelationRepo, "All" )
        {
        }

        public CategorizedRoadmapViewModel( ICollection<tFeature> features, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo, string name )
        {
            _categorizedFeatures = new Dictionary<string, ICollection<FeatureViewModel>>();
            _name = name;
            PopulateCollections( partnerRepo, contactRepo, contactRelationRepo, features );
        }

        private void PopulateCollections( PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo, ICollection<tFeature> features )
        {
            _features = new List<FeatureViewModel>();
            foreach( tFeature feature in features )
            {
                FeatureViewModel vm = new FeatureViewModel( feature, partnerRepo, contactRepo, contactRelationRepo );
                _features.Add( vm );

                foreach( CategoryViewModel cat in vm.Categories )
                {
                    if( !_categorizedFeatures.ContainsKey( cat.Name ) ) _categorizedFeatures.Add( cat.Name, new List<FeatureViewModel>() );
                    _categorizedFeatures[cat.Name].Add( vm );
                }
            }
        }

        public string Name { get { return _name; } }
        public ICollection<FeatureViewModel> Features { get { return _features; } }
        public Dictionary<string, ICollection<FeatureViewModel>> CategorizedFeatures { get { return _categorizedFeatures; } }
    }
}