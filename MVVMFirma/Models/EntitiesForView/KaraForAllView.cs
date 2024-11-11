using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class KaraForAllView
    {
        public int IdKary { get; set; }
        public String CzytelnikImie { get; set; }
        public String CzytelnikNazwisko { get; set; }
        public String Opis { get; set; }

        public decimal? Kwota { get; set; }

        public DateTime? DataNaliczenia { get; set; }

    }
}
