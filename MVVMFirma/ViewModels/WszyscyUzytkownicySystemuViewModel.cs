using MVVMFirma.Models.Entities;
using MVVMFirma.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszyscyUzytkownicySystemuViewModel : WszystkieViewModel<UzytkownicySystemu>
    {
        #region Constructor

        public WszyscyUzytkownicySystemuViewModel()
            : base("Użytkownicy Systemu")
        {
        }

        #endregion

        #region SortAndFind

        //tu decydujemy po czym sortować

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Login", "Rola" };
        }

        //jak sortować
        public override void Sort()
        {
            if (SortField == "Login")
                List = new ObservableCollection<UzytkownicySystemu>
                    (
                       bibliotekaEntities.UzytkownicySystemu.OrderBy(x => x.Login).ToList()
                    );
            else if (SortField == "Rola")
                List = new ObservableCollection<UzytkownicySystemu>
                    (
                       bibliotekaEntities.UzytkownicySystemu.OrderBy(x => x.Rola).ToList()
                    );
        }

        //tu decydujemy po czym szuykac
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Login", "Rola" };
        }

        //jak wyszukiwać
        public override void Find()
        {
            if (FindField == "Login")
                List = new ObservableCollection<UzytkownicySystemu>
                    (
                       bibliotekaEntities.UzytkownicySystemu.Where(x => x.Login.Contains(FindTextBox)).ToList()
                    );
            else if (FindField == "Rola")
                List = new ObservableCollection<UzytkownicySystemu>
                    (
                       bibliotekaEntities.UzytkownicySystemu.Where(x => x.Rola.Contains(FindTextBox)).ToList()
                    );
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<UzytkownicySystemu>
                (
                   bibliotekaEntities.UzytkownicySystemu.ToList()
                );
        }
        #endregion
    }
}
