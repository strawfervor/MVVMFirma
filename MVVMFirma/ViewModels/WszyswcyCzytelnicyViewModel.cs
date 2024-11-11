using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszyswcyCzytelnicyViewModel : WszystkieViewModel<CzytelnikForAllView>
    {
        #region Constructor

        public WszyswcyCzytelnicyViewModel()
            : base("Czytelnicy")
        {
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<CzytelnikForAllView>
                (
                   //tworzymy tutaj zapytanie linq
                   from czytelnik in bibliotekaEntities.Czytelnicy //dla każdegi czytelnika z bazy danych czytelników
                   select new CzytelnikForAllView //tworzymy nowe CzytelnikForAllView i uzupełniamy jego dane
                   {
                       IdCzytelnika = czytelnik.Id,
                       Imie = czytelnik.Imie,
                       Nazwisko = czytelnik.Nazwisko,
                       AdresUlica = czytelnik.Adres.Ulica, //odwołanie do Adresu
                       AdresNumerDomu = czytelnik.Adres.NumerDomu,
                       AdresMiejscowosc = czytelnik.Adres.Miejscowosc,
                       RodzajeCzlonkostwaNazwaCzlonkowstwa = czytelnik.RodzajCzlonkostwa.NazwaCzlonkowstwa,
                       IloscWypozyczonychKsiazek = czytelnik.IloscWypozyczonychKsiazek,
                   }
                );
        }
        #endregion
    }
}