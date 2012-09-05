using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;
using CiviKey.Repositories;
using System.Diagnostics;

namespace CiviKey.ViewModel
{
    public class FeatureViewModel
    {
        tFeature _model;
        PartnerRepository _partnerRepo;
        ContactRepository _contactRepo;
        ContactRelationRepository _contactRelationRepo;
        public FeatureViewModel( tFeature model, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo )
        {
            DeveloppingCompanies = new List<CompanyParticipationViewModel>();
            _contactRelationRepo = contactRelationRepo;
            _partnerRepo = partnerRepo;
            _contactRepo = contactRepo;
            _model = model;
            
            GenerateViewModels( model );
        }

        public Version Version { get { return new Version( _model.Version ); } }
        public DateTime CreationDate { get { return _model.CreationDate; } }
        public string Description { get { return _model.Description; } }
        public FeatureType Type { get { return _featureType; } }
        public int Progress { get { return _model.Progress; } }
        public string Title { get { return _model.Title; } }
        public string LogoPath { get; private set; }
        public int Id { get { return _model.Id; } }
        public string RoadMapVersion { get; set; }
        FeatureType _featureType;

        public IDictionary<ContactViewModel, IList<ParticipationViewModel>> Participations { get; private set; }
        public IList<CompanyParticipationViewModel> DeveloppingCompanies { get; private set; }
        
        public IList<ParticipationViewModel> Sponsors { get { return _sponsors; } }
        public IList<CategoryViewModel> Categories { get { return _categories; } }
        public IList<SectionViewModel> Sections { get { return _sections; } }
        public IList<VideoViewModel> Videos { get { return _videos; } }

        IList<ParticipationViewModel> _sponsors;
        IList<CategoryViewModel> _categories;
        IList<SectionViewModel> _sections;
        IList<VideoViewModel> _videos;

        private void GenerateViewModels( tFeature model )
        {
            if( !Enum.TryParse( model.Type.ToString(), out _featureType ) ) _featureType = 0;
            LogoPath = model.LogoPath;

            _categories = model.tCategories.Select( c => new CategoryViewModel( c ) ).ToList();

            _sponsors = model.tParticipations.Where( x => x.PartType == ParticipationType.Sponsoring.ToString() )
                .Select( p => new ParticipationViewModel( p, _partnerRepo, _contactRepo, _contactRelationRepo ) )
                .ToList();

            _sections = model.tSections.Select( s => new SectionViewModel( s ) ).ToList();
            _videos = model.tVideos.Select( v => new VideoViewModel( v ) ).ToList();

            Participations = new Dictionary<ContactViewModel, IList<ParticipationViewModel>>();
            foreach( var participation in model.tParticipations.Where( x => x.PartType == ParticipationType.Development.ToString() ) )
            {
                ParticipationViewModel vm = new ParticipationViewModel( participation, _partnerRepo, _contactRepo, _contactRelationRepo );
                var existings = FindOrCreateCompany( new ContactViewModel(participation.tContactRelation.tOrganization, _partnerRepo, _contactRepo, _contactRelationRepo) );
                existings.Add( vm );
            }

            foreach( var item in Participations )
            {
                int percent = 0;
                for( int i = 0; i < item.Value.Count; i++ )
                {
                    percent += item.Value[i].Percentage;
                }
                DeveloppingCompanies.Add( new CompanyParticipationViewModel(item.Key.Name, percent) );
            }
        }

        IList<ParticipationViewModel> FindOrCreateCompany( ContactViewModel company )
        {
            Debug.Assert( company.IsOrganization );
            IList<ParticipationViewModel> contacts = null;
            if( !Participations.TryGetValue( company, out contacts ) )
            {
                contacts = new List<ParticipationViewModel>();
                Participations.Add( company, contacts );
            }
            return contacts;
        }

    }
}