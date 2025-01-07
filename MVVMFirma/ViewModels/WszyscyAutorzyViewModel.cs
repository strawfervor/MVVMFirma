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
