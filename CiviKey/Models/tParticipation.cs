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
    public partial class tParticipation
    {
        public int Id { get; set; }
        public int ContactRelationId { get; set; }
        public string PartType { get; set; }
        public int Percentage { get; set; }
        public System.DateTime ParticipationDate { get; set; }
    
        public virtual tContactRelation tContactRelation { get; set; }
        public virtual tFeature tFeature { get; set; }
        public virtual tRoadMap tRoadMap { get; set; }
    }
    
}
