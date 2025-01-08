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
    public class WszystkieWypozyczeniaViewModel : WszystkieViewModel<WypozyczeniaForAllView>
    {
        #region Constructor

        public WszystkieWypozyczeniaViewModel()
            : base("Wypożyczenia")
        {
        }

        #endregion

        #region SortAndFind

        //tu decydujemy po czym sortować

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Tytuł", "Nazwisko czytelnika", "Data wypożyczenia", "Data zwrotu" };
        }

        //jak sortować
        public override void Sort()
        {
            if (SortField == "Tytuł")
                List = new ObservableCollection<WypozyczeniaForAllView>(List.OrderBy(x => x.KsiazkiTytul));
            if (SortField == "Nazwisko czytelnika")
                List = new ObservableCollection<WypozyczeniaForAllView>(List.OrderBy(x => x.CzytelnikNazwisko));
            if (SortField == "Data wypożyczenia")
                List = new ObservableCollection<WypozyczeniaForAllView>(List.OrderBy(x => x.DataWypozyczenia));
            if (SortField == "Data zwrotu")
                List = new ObservableCollection<WypozyczeniaForAllView>(List.OrderBy(x => x.DataZwrotu));
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
                List = new ObservableCollection<WypozyczeniaForAllView>(
                    List.Where(x => x.KsiazkiTytul != null && x.KsiazkiTytul.ToLower().Contains(FindTextBox.ToLower())));
            }
            if (FindField == "Nazwisko czytelnika")
            {
                List = new ObservableCollection<WypozyczeniaForAllView>(
                    List.Where(x => x.CzytelnikNazwisko != null && x.CzytelnikNazwisko.ToLower().Contains(FindTextBox.ToLower())));
            }
            if (FindField == "Imie czytelnika")
            {
                List = new ObservableCollection<WypozyczeniaForAllView>(
                    List.Where(x => x.CzytelnikImie != null && x.CzytelnikImie.ToLower().Contains(FindTextBox.ToLower())));
            }
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<WypozyczeniaForAllView>
                (
                   //tworzymy tutaj zapytanie linq
                   from wypozyczenia in bibliotekaEntities.Wypozyczenia //dla każdegi czytelnika z bazy danych czytelników
                   select new WypozyczeniaForAllView //tworzymy nowe CzytelnikForAllView i uzupełniamy jego dane
                   {
                       IdWypozyczenia = wypozyczenia.Id,
                       CzytelnikImie = wypozyczenia.Czytelnicy.Imie,
                       CzytelnikNazwisko = wypozyczenia.Czytelnicy.Nazwisko,
                       KsiazkiTytul = wypozyczenia.Ksiazki.Tytul,
                       DataWypozyczenia = wypozyczenia.DataWypozyczenia,
                       DataZwrotu = wypozyczenia.DataZwrotu,
                   }
                );
        }
        #endregion
    }
}