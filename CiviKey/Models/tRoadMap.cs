//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace CiviKey.Models
{
    public partial class tRoadMap
    {
        public tRoadMap()
        {
            this.tFeatures = new HashSet<tFeature>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<tFeature> tFeatures { get; set; }
    }
    
}
