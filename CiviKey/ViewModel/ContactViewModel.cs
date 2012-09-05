﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;
using CiviKey.Repositories;

namespace CiviKey.ViewModel
{
    public class ContactViewModel : IEquatable<ContactViewModel>
    {
        tContact _contact;
        IQueryable<tContact> _organizations;

        public ContactViewModel( tContact model, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo )
            : this( model, partnerRepo, contactRepo, contactRelationRepo, false )
        {
        }

        public ContactViewModel( tContact model, PartnerRepository partnerRepo, ContactRepository contactRepo, ContactRelationRepository contactRelationRepo, bool hasSpecificPartnerView )
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
                    Organizations.Add( new ContactViewModel( organization, partnerRepo, contactRepo, contactRelationRepo, false ) );
                }
            }
            else if( String.IsNullOrEmpty( LogoPath ) )
            {
                LogoPath = "partner-logo.png";
            }
            _hasSpecificPartnerPage = hasSpecificPartnerView;
        }

        public int Id { get { return _contact.Id; } }
        public IList<ContactViewModel> Organizations { get; private set; }
        public string Description { get { return _contact.Description; } }

        public string SafeName { get { return _contact.SafeName; } }

        bool _hasSpecificPartnerPage;
        public bool HasSpecificPartnerPage { get { return IsOrganization && _hasSpecificPartnerPage; } }
        public string Name { get { return _contact.Name; } }
        public bool IsOrganization { get; private set; }
        public string LogoPath { get; set; }

        public bool Equals( ContactViewModel other )
        {
            return other.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}