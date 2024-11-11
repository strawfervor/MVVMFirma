using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class RezerwacjaForAllView
    {
        public int IdRezerwacji { get; set; }
        public String CzytelnikImie { get; set; }
        public String CzytelnikNazwisko { get; set; }
        public String KsiazkaTytul {  get; set; }
        public DateTime? DataRezerwacji { get; set; }
        public DateTime? DataOdbioru { get; set; }
    }
}
