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

        #region SortAndFind

        //tu decydujemy po czym sortować

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Tytuł", "Nazwisko czytelnika", "Data rezerwacji", "Data odbioru książki" };
        }

        //jak sortować
        public override void Sort()
        {
            if (SortField == "Tytuł")
                List = new ObservableCollection<RezerwacjaForAllView>(List.OrderBy(x => x.KsiazkaTytul));
            if (SortField == "Nazwisko czytelnika")
                List = new ObservableCollection<RezerwacjaForAllView>(List.OrderBy(x => x.CzytelnikNazwisko));
            if (SortField == "Data rezerwacji")
                List = new ObservableCollection<RezerwacjaForAllView>(List.OrderBy(x => x.DataRezerwacji));
            if (SortField == "Data odbioru książki")
                List = new ObservableCollection<RezerwacjaForAllView>(List.OrderBy(x => x.DataOdbioru));
        }

        //tu decydujemy po czym szuykac
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Tytuł", "Nazwisko czytelnika", "Imie czytelnika" };
        }

        //jak wyszukiwać
        public override void Find()
        {
            if (FindField == "Tytuł")
            {
                List = new ObservableCollection<RezerwacjaForAllView>(
                    List.Where(x => x.KsiazkaTytul != null && x.KsiazkaTytul.ToLower().Contains(FindTextBox.ToLower())));
            }
            if (FindField == "Nazwisko czytelnika")
            {
                List = new ObservableCollection<RezerwacjaForAllView>(
                    List.Where(x => x.CzytelnikNazwisko != null && x.CzytelnikNazwisko.ToLower().Contains(FindTextBox.ToLower())));
            }
            if (FindField == "Imie czytelnika")
            {
                List = new ObservableCollection<RezerwacjaForAllView>(
                    List.Where(x => x.CzytelnikImie != null && x.CzytelnikImie.ToLower().Contains(FindTextBox.ToLower())));
            }
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
