using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class KsiazkaForAllView
    {
        public int IdKsiazki { get; set; }
        public String Tytul { get; set; }
        public String AutorImie { get; set; }
        public String AutorNazwisko { get; set; }
        public String ISBN { get; set; }
        public int? RokWydania { get; set; }
        public String WydawnictwaNazwa {  get; set; }
        public String Gatunek { get; set; }
        public int? IloscEgzemplarzy { get; set; }
        public String RodzajLiterckiNazwa { get; set; }
    }
}
