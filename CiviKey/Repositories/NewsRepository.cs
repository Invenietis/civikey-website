using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;

namespace CiviKey.Repositories
{
    public class NewsRepository
    {
        CiviKeyEntities _c;
        public NewsRepository( CiviKeyEntities c )
        {
            _c = c;
        }

        public IList<tNew> All { get { return _c.tNews.OrderByDescending(x=>x.CreationDate).ToList(); } }

        public tNew GetNewsFromId( int id )
        {
            return All.Where(x=> x.Id == id).SingleOrDefault();
        }
    }
}