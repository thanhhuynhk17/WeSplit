﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeSplit.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WeSplitEntities1 : DbContext
    {
        public WeSplitEntities1()
            : base("name=WeSplitEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<journey> journeys { get; set; }
        public virtual DbSet<journey_member> journey_member { get; set; }
        public virtual DbSet<member> members { get; set; }
        public virtual DbSet<place> places { get; set; }
        public virtual DbSet<province> provinces { get; set; }
        public virtual DbSet<route> routes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
