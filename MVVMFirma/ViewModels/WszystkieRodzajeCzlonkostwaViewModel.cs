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
    public class WszystkieRodzajeCzlonkostwaViewModel : WszystkieViewModel<RodzajCzlonkostwa>
    {
        #region Constructor

        public WszystkieRodzajeCzlonkostwaViewModel()
            : base("RodzajeCzlonkostwa")
        {
        }

        #endregion

        #region SortAndFind

        //tu decydujemy po czym sortować

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa rodzaju członkostwa", "Max. czas wypożyczenia", "Max. ilość wypożyczeń" };
        }

        //jak sortować
        public override void Sort()
        {
            if (SortField == "Nazwa rodzaju członkostwa")
                List = new ObservableCollection<RodzajCzlonkostwa>(List.OrderBy(x => x.NazwaCzlonkowstwa));
            if (SortField == "Max. czas wypożyczenia")
                List = new ObservableCollection<RodzajCzlonkostwa>(List.OrderBy(x => x.MaxCzasWypozyczenia));
            if (SortField == "Max. ilość wypożyczeń")
                List = new ObservableCollection<RodzajCzlonkostwa>(List.OrderBy(x => x.MaxKsiazekWypozyczonych));
        }

        //tu decydujemy po czym szuykac
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa rodzaju członkostwa" };
        }

        //jak wyszukiwać
        public override void Find()
        {
            if (FindField == "Nazwa rodzaju członkostwa")
            {
                List = new ObservableCollection<RodzajCzlonkostwa>(
                    List.Where(x => x.NazwaCzlonkowstwa != null && x.NazwaCzlonkowstwa.ToLower().Contains(FindTextBox.ToLower())));
            }
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<RodzajCzlonkostwa>
                (
                   bibliotekaEntities.RodzajCzlonkostwa.ToList()
                );
        }
        #endregion
    }
}
