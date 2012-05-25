using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CiviKey.Models;

namespace CiviKey.Repositories
{
    public class FeatureRepository
    {
        CiviKeyEntities _c;
        public FeatureRepository(CiviKeyEntities c)
        {
            _c = c;
        }

        public IQueryable<tFeature> All { get { return _c.tFeatures; } }
    }
}