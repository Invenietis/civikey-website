﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CiviKey.Models
{
    public partial class CiviKeyEntities : DbContext
    {
        public CiviKeyEntities()
            : base("name=CiviKeyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tCategory> tCategories { get; set; }
        public DbSet<tContact> tContacts { get; set; }
        public DbSet<tContactRelation> tContactRelations { get; set; }
        public DbSet<tNew> tNews { get; set; }
        public DbSet<tParticipation> tParticipations { get; set; }
        public DbSet<tPlugin> tPlugins { get; set; }
        public DbSet<tSection> tSections { get; set; }
        public DbSet<tTestimony> tTestimonies { get; set; }
        public DbSet<tRoadMap> tRoadMaps { get; set; }
        public DbSet<tVideo> tVideos { get; set; }
        public DbSet<tFeature> tFeatures { get; set; }
    }
}
