using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;
using CiviKey.Repositories;

namespace CiviKey.ViewModel
{
    public class ContactViewModel
    {
        tContact _contact;
        IQueryable<tContact> _organizations;

        public ContactViewModel( tContact model, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo )
        {
            _contact = contactRepo.ContactFromContactId( model.Id );
            Organizations = new List<ContactViewModel>();
            IsOrganization = model.Id == _contact.Id;
            LogoPath = _contact.LogoPath;

            if( !IsOrganization )
            {
                _organizations = contactRelationRepo.OrganizationsFromContactId( model.Id );
                ICollection<int> organisationIds = _organizations.Select( o => o.Id ).ToList();
                foreach( var organization in _organizations )
                {
                    Organizations.Add( new ContactViewModel( organization, partnerRepo, contactRepo, contactRelationRepo ) );
                }
            }
            else if( String.IsNullOrEmpty( LogoPath ) )
            {
                LogoPath = "partner-logo.png";
            }
        }
        
        public IList<ContactViewModel> Organizations { get; private set; }
        public string Description { get { return _contact.Description; } }
        public string Name { get { return _contact.Name; } }
        public bool IsOrganization { get; private set; }
        public string LogoPath { get; set; }
    }
}