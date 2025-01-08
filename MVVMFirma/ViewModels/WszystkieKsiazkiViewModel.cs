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
            return new List<string> { "Tytuł", "Nazwisko autora", "Rok wydania", "Wydawnictwo", "Rodzaj literacki" };
        }

        //jak sortować
        public override void Sort()
        {
            if (SortField == "Tytuł")
                List = new ObservableCollection<KsiazkaForAllView>(List.OrderBy(x => x.Tytul));
            if (SortField == "Nazwisko autora")
                List = new ObservableCollection<KsiazkaForAllView>(List.OrderBy(x => x.AutorNazwisko));
            if (SortField == "Rok wydania")
                List = new ObservableCollection<KsiazkaForAllView>(List.OrderBy(x => x.RokWydania));
            if (SortField == "Wydawnictwo")
                List = new ObservableCollection<KsiazkaForAllView>(List.OrderBy(x => x.WydawnictwaNazwa));
            if (SortField == "Rodzaj literacki")
                List = new ObservableCollection<KsiazkaForAllView>(List.OrderBy(x => x.RodzajLiterckiNazwa));
        }

        //tu decydujemy po czym szuykac
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Tytuł", "Nazwisko autora", "Imie autora",  "Wydawnictwo", "ISBN" };
        }

        //jak wyszukiwać
        public override void Find()
        {
            if (FindField == "Tytuł")
            {
                List = new ObservableCollection<KsiazkaForAllView>(
                    List.Where(x => x.Tytul != null && x.Tytul.ToLower().Contains(FindTextBox.ToLower())));
            }
            if (FindField == "Nazwisko autora")
            {
                List = new ObservableCollection<KsiazkaForAllView>(
                    List.Where(x => x.AutorNazwisko != null && x.AutorNazwisko.ToLower().Contains(FindTextBox.ToLower())));
            }
            if (FindField == "Imie autora")
            {
                List = new ObservableCollection<KsiazkaForAllView>(
                    List.Where(x => x.AutorImie != null && x.AutorImie.ToLower().Contains(FindTextBox.ToLower())));
            }
            if (FindField == "Wydawnictwo")
            {
                List = new ObservableCollection<KsiazkaForAllView>(
                    List.Where(x => x.WydawnictwaNazwa != null && x.WydawnictwaNazwa.ToLower().Contains(FindTextBox.ToLower())));
            }
            if (FindField == "ISBN")
            {
                List = new ObservableCollection<KsiazkaForAllView>(
                    List.Where(x => x.ISBN != null && x.ISBN.ToLower().Contains(FindTextBox.ToLower())));
            }

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