using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace CiviKey.Models
{
    public partial class CiviKeyEntities
    {
        public IEnumerable<tSection> GetSections(int featureId)
        {
            return this.tFeatures.Single(x => x.Id == featureId).tSections;
        }


    }
}