using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;

namespace CiviKey.Repositories
{
    public class PartnerRepository
    {
        CiviKeyEntities _c;
        public PartnerRepository( CiviKeyEntities c )
        {
            _c = c;
            PartnerIdList = _c.tContactRelations.Where( z => z.ContactId == z.EntityId ).Select( y => y.Id ).ToList();
        }

        private IList<int> PartnerIdList { get; set; }
        public IQueryable<tContact> GetAllPartners 
        { 
            get
            {
                if( PartnerIdList == null ) return null; 
                return _c.tContacts.Where( x => PartnerIdList.Contains( x.Id ) ); 
            }
        }
    }
}