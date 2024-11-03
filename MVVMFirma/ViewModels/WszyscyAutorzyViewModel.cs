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
