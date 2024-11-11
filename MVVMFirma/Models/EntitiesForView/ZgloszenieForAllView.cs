using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class ZgloszenieForAllView
    {
        public int IdZgloszenia { get; set; }

        //z Czytelnicy

        public String CzytelnikImie { get; set; }

        public String CzytelnikNazwisko { get; set; }

        public String Opis { get; set; }

        public DateTime? DataZgloszenia { get; set; }
    }
}
