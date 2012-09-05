using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;
using CiviKey.Repositories;

namespace CiviKey.ViewModel
{
    //public class CategorizedRoadmapViewModel
    //{
    //    Dictionary<CategoryViewModel, ICollection<FeatureViewModel>> _categorizedFeatures;
    //    ICollection<FeatureViewModel> _features;
    //    tRoadMap _model;

    //    public CategorizedRoadmapViewModel( tRoadMap model, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo )
    //    {
    //        _categorizedFeatures = new Dictionary<CategoryViewModel, ICollection<FeatureViewModel>>();
    //        _model = model;
    //        PopulateCollections( partnerRepo, contactRepo, contactRelationRepo, model.tFeatures );
    //    }
 
    //    private void PopulateCollections( PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo, ICollection<tFeature> features )
    //    {
    //        _features = new List<FeatureViewModel>();
    //        foreach( tFeature feature in features )
    //        {
    //            FeatureViewModel vm = new FeatureViewModel( feature, partnerRepo, contactRepo, contactRelationRepo );
    //            _features.Add( vm );

    //            foreach( CategoryViewModel cat in vm.Categories )
    //            {
    //                if (!_categorizedFeatures.ContainsKey(cat)) _categorizedFeatures.Add(cat, new List<FeatureViewModel>());
    //                _categorizedFeatures[cat].Add( vm );
    //            }
    //        }
    //    }

    //    public bool HasRelease { get { return _model.HasRelease; } }
    //    public int Id { get { return _model.Id; } }
    //    public string Name { get { return _model.Name; } }
    //    public ICollection<FeatureViewModel> Features { get { return _features; } }
    //    public Dictionary<CategoryViewModel, ICollection<FeatureViewModel>> CategorizedFeatures { get { return _categorizedFeatures; } }
    //}
}