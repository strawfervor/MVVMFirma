using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    //ta klasa jest wzorowana na klasie faktura, tylko zamiast kluczy obcych ma czytelne dla klienta pola (klucze obce będą zastąpione czytelnymi dla zwykłego człowieka danymi).
    public class CzytelnikForAllView
    {
        public int IdCzytelnika { get; set; }
        public String Imie { get; set; }
        public String Nazwisko { get; set; }

        //zamiast IdAdresu (klucza obcego) decydujemy jakie pola z Adresu wyświetlić i zamieniamy je (weźniemy tutaj ulica, numer domu i miasto) (49:44)
        public String AdresUlica { get; set; }

        public String AdresNumerDomu { get; set; }

        public String AdresMiejscowosc { get; set; }

        //zamista IdRodzajuCzlonokostwa  - NazwaCzlonkowstwa

        public String RodzajeCzlonkostwaNazwaCzlonkowstwa {  get; set; }


        public int? IloscWypozyczonychKsiazek { get; set; }
    }

    
}
