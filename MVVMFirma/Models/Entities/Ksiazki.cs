//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Ksiazki
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ksiazki()
        {
            this.Egzemplarze = new HashSet<Egzemplarze>();
            this.Rezerwacje = new HashSet<Rezerwacje>();
            this.Wypozyczenia = new HashSet<Wypozyczenia>();
            this.Tagi = new HashSet<Tagi>();
        }
    
        public int Id { get; set; }
        public string Tytul { get; set; }
        public Nullable<int> IdAutora { get; set; }
        public string ISBN { get; set; }
        public Nullable<int> RokWydania { get; set; }
        public Nullable<int> IdWydawnictwa { get; set; }
        public string Gatunek { get; set; }
        public Nullable<int> IloscEgzemplarzy { get; set; }
        public Nullable<int> RodzajLiteracki { get; set; }
    
        public virtual Autorzy Autorzy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Egzemplarze> Egzemplarze { get; set; }
        public virtual Wydawnictwa Wydawnictwa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezerwacje> Rezerwacje { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wypozyczenia> Wypozyczenia { get; set; }
        public virtual RodzajLiteracki RodzajLiteracki1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tagi> Tagi { get; set; }
    }
}
