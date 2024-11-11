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
    public class WszystkieRezerwacjeViewModel : WszystkieViewModel<RezerwacjaForAllView>
    {
        #region Constructor

        public WszystkieRezerwacjeViewModel()
            : base("Rezerwacje")
        {
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<RezerwacjaForAllView>
                (
                   //tworzymy tutaj zapytanie linq
                   from rezerwacja in bibliotekaEntities.Rezerwacje //dla każdegi czytelnika z bazy danych czytelników
                   select new RezerwacjaForAllView //tworzymy nowe CzytelnikForAllView i uzupełniamy jego dane
                   {
                       IdRezerwacji = rezerwacja.Id,
                       CzytelnikImie = rezerwacja.Czytelnicy.Imie,
                       CzytelnikNazwisko = rezerwacja.Czytelnicy.Nazwisko,
                       KsiazkaTytul = rezerwacja.Ksiazki.Tytul,
                       DataRezerwacji = rezerwacja.DataRezerwacji,
                       DataOdbioru = rezerwacja.DataOdbioruKsiazki,
                   }
                );
        }
        #endregion
    }
}
