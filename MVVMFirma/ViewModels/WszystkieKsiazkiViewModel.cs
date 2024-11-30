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
    public class WszystkieKsiazkiViewModel : WszystkieViewModel<KsiazkaForAllView>
    {
        #region Constructor

        public WszystkieKsiazkiViewModel()
            : base("Książki")
        {
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KsiazkaForAllView>
                (
                   //tworzymy tutaj zapytanie linq
                   from ksiazka in bibliotekaEntities.Ksiazki //dla każdegi czytelnika z bazy danych czytelników
                   select new KsiazkaForAllView //tworzymy nowe CzytelnikForAllView i uzupełniamy jego dane
                   {
                       IdKsiazki = ksiazka.Id,
                       Tytul = ksiazka.Tytul,
                       AutorImie = ksiazka.Autorzy.Imie,
                       AutorNazwisko = ksiazka.Autorzy.Nazwisko,
                       ISBN = ksiazka.ISBN,
                       RokWydania = ksiazka.RokWydania,
                       WydawnictwaNazwa = ksiazka.Wydawnictwa.Nazwa,
                       Gatunek = ksiazka.Gatunek,
                       IloscEgzemplarzy = ksiazka.IloscEgzemplarzy,
                       RodzajLiterckiNazwa = ksiazka.RodzajLiteracki1.NazwaRodzaju,
                   }
                );
        }
        #endregion
    }
}