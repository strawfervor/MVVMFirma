
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
    
public partial class Konkursy
{

    public int Id { get; set; }

    public string NazwaKonkursu { get; set; }

    public string Opis { get; set; }

    public string Status { get; set; }

    public Nullable<int> IdZwyciezcy { get; set; }

    public Nullable<System.DateTime> DataZakonczenia { get; set; }

    public System.DateTime DataRozpoczecia { get; set; }



    public virtual Czytelnicy Czytelnicy { get; set; }

}

}
