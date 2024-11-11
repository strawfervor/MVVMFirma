using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class WypozyczeniaForAllView
    {
        public int IdWypozyczenia { get; set; }
        public String KsiazkiTytul { get; set; }

        public String CzytelnikImie { get; set; }

        public String CzytelnikNazwisko { get; set; }

        public DateTime? DataWypozyczenia { set; get; }

        public DateTime? DataZwrotu { set; get; }
    }
}
