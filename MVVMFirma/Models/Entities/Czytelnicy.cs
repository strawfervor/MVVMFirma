
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
    
public partial class Czytelnicy
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Czytelnicy()
    {

        this.Kary = new HashSet<Kary>();

        this.Rezerwacje = new HashSet<Rezerwacje>();

        this.Wypozyczenia = new HashSet<Wypozyczenia>();

        this.Zgloszenia = new HashSet<Zgloszenia>();

        this.Konkursy = new HashSet<Konkursy>();

    }


    public int Id { get; set; }

    public string Imie { get; set; }

    public string Nazwisko { get; set; }

    public Nullable<int> IdAdresu { get; set; }

    public Nullable<int> IdRodzajuCzlonkowstwa { get; set; }

    public Nullable<int> IloscWypozyczonychKsiazek { get; set; }



    public virtual Adres Adres { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Kary> Kary { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Rezerwacje> Rezerwacje { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Wypozyczenia> Wypozyczenia { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Zgloszenia> Zgloszenia { get; set; }

    public virtual RodzajCzlonkostwa RodzajCzlonkostwa { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Konkursy> Konkursy { get; set; }

}

}
