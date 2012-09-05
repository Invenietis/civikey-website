using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;

namespace CiviKey.Repositories
{
    public class TestimonyRepository
    {
        CiviKeyEntities _c;
        public TestimonyRepository( CiviKeyEntities c )
        {
            _c = c;
        }

        public ICollection<tTestimony> All { get { return _c.tTestimonies.ToList(); } }

        public tTestimony GetTestimonialFromId( int id )
        {
            return All.Where(x=> x.Id == id).SingleOrDefault();
        }
    }
}