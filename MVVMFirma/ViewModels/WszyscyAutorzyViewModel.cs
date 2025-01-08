using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszyscyAutorzyViewModel : WszystkieViewModel<Autorzy>//dziedzyczy z WszystkieViewModeli<i działa na w tym wypadku Towar>
    {
        #region Constructor

        public WszyscyAutorzyViewModel()
            : base("Autorzy")//nazwa zakladki tutaj wedryuje
        {
        }

        #endregion

        #region SortAndFind

        //tu decydujemy po czym sortować

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Imie", "Nazwisko", "Nazwisko i imie", "Data urodzenia", "Kraj pochodzenia" };
        }

        //jak sortować
        public override void Sort()
        {
            if (SortField == "Imie")
                List = new ObservableCollection<Autorzy>
                    (
                       bibliotekaEntities.Autorzy.OrderBy(x => x.Imie).ToList()
                    );
            else if (SortField == "Nazwisko")
                List = new ObservableCollection<Autorzy>
                    (
                       bibliotekaEntities.Autorzy.OrderBy(x => x.Nazwisko).ToList()
                    );
            else if (SortField == "Data urodzenia")
                List = new ObservableCollection<Autorzy>
                    (
                       bibliotekaEntities.Autorzy.OrderBy(x => x.DataUrodzenia).ToList()
                    );
            else if (SortField == "Kraj pochodzenia")
                List = new ObservableCollection<Autorzy>
                    (
                       bibliotekaEntities.Autorzy.OrderBy(x => x.KrajPochodzenia).ToList()
                    );
            else if (SortField == "Nazwisko i imie")
                List = new ObservableCollection<Autorzy>
                    (
                       bibliotekaEntities.Autorzy.OrderBy(x => x.Nazwisko).OrderBy(x => x.Imie).ToList()
                    );
        }

        //tu decydujemy po czym szuykac
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Imie", "Nazwisko", "Kraj pochodzenia" };
        }

        //jak wyszukiwać
        public override void Find()
        {
            if (FindField == "Imie")
                List = new ObservableCollection<Autorzy>
                    (
                       bibliotekaEntities.Autorzy.Where(x => x.Imie.Contains(FindTextBox)).ToList()
                    );
            else if (FindField == "Nazwisko")
                List = new ObservableCollection<Autorzy>
                    (
                       bibliotekaEntities.Autorzy.Where(x => x.Nazwisko.Contains(FindTextBox)).ToList()
                    );
            else if (FindField == "Kraj pochodzenia")
                List = new ObservableCollection<Autorzy>
                    (
                       bibliotekaEntities.Autorzy.Where(x => x.KrajPochodzenia.Contains(FindTextBox)).ToList()
                    );
        }

        #endregion

        #region Helpers
        //metoda load pobiera wszystkie towary z bazy danych
        public override void Load()
        {
            List = new ObservableCollection<Autorzy>//<Towar, lub cokolwiek tutaj ma byc>
                (
                   bibliotekaEntities.Autorzy.ToList()// fakturyEntities.Towar lub cokolwiek ma byc.ToList()
                   //z bazy danych, która reprezentuje faktury entities pobieram Towar i wszystkie rekordy pobieram na liste
                );
        }

        #endregion
    }
}
