﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class wasilyEntities1 : DbContext
    {
        public wasilyEntities1()
            : base("name=wasilyEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Deal> Deal { get; set; }
        public virtual DbSet<DealOffer> DealOffer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Favorite> Favorite { get; set; }
        public virtual DbSet<Suggestion> Suggestion { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<user> user { get; set; }
    }
}