using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class KonkursyForAllView
    {
        public int IdKonkursu { get; set; }
        public String NazwaKonkursu { get; set; }
        public String OpisKonkursu { get; set; }
        public String Status { get; set; }
        public String ImieZwyciezcy { get; set; }
        public String NazwiskoZwyciezcy { get; set; }
        public DateTime DataRozpoczecia  { get; set; }
        public DateTime? DataZakonczenia { get; set; }
    }
}
