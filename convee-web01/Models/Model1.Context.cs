﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace convee_web01.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Riverside_HoldingsEntities : DbContext
    {
        public Riverside_HoldingsEntities()
            : base("name=Riverside_HoldingsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ADMINISTRATOR> ADMINISTRATORS { get; set; }
        public virtual DbSet<CLIENT> CLIENTS { get; set; }
        public virtual DbSet<INVOICE> INVOICES { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTS { get; set; }
    }
}