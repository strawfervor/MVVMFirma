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

        #region SortAndFind

        //tu decydujemy po czym sortować

        public override List<string> GetComboboxSortList()
        {
            //return new List<string> { "Ulica", "Numer domu", "Numer mieszkania", "Kod pocztowy", "Miasto" };
            return null;
        }

        //jak sortować
        public override void Sort()
        {
        }

        //tu decydujemy po czym szuykac
        public override List<string> GetComboboxFindList()
        {
            //return new List<string> { "Ulica", "Numer domu", "Numer mieszkania", "Kod pocztowy", "Miasto" };
            return null;
        }

        //jak wyszukiwać
        public override void Find()
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