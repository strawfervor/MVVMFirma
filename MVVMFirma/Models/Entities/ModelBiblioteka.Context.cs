﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVVMFirma.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BibliotekaEntities : DbContext
    {
        public BibliotekaEntities()
            : base("name=BibliotekaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adres> Adres { get; set; }
        public virtual DbSet<Autorzy> Autorzy { get; set; }
        public virtual DbSet<Czytelnicy> Czytelnicy { get; set; }
        public virtual DbSet<Egzemplarze> Egzemplarze { get; set; }
        public virtual DbSet<Kary> Kary { get; set; }
        public virtual DbSet<Ksiazki> Ksiazki { get; set; }
        public virtual DbSet<Rezerwacje> Rezerwacje { get; set; }
        public virtual DbSet<RodzajCzlonkostwa> RodzajCzlonkostwa { get; set; }
        public virtual DbSet<RodzajLiteracki> RodzajLiteracki { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tagi> Tagi { get; set; }
        public virtual DbSet<UzytkownicySystemu> UzytkownicySystemu { get; set; }
        public virtual DbSet<Wydawnictwa> Wydawnictwa { get; set; }
        public virtual DbSet<Wypozyczenia> Wypozyczenia { get; set; }
        public virtual DbSet<Zgloszenia> Zgloszenia { get; set; }
        public virtual DbSet<KsiazkiTag> KsiazkiTag { get; set; }
    }
}
