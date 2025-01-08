using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieRodzajeLiterackieViewModel : WszystkieViewModel<RodzajLiteracki>
    {
        #region Constructor

        public WszystkieRodzajeLiterackieViewModel()
            : base("Rodzaje Literackie")
        {
        }

        #endregion

        #region SortAndFind

        //tu decydujemy po czym sortować

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa rodzaju" };
        }

        //jak sortować
        public override void Sort()
        {
            if (SortField == "Nazwa rodzaju")
                List = new ObservableCollection<RodzajLiteracki>(List.OrderBy(x => x.NazwaRodzaju));
        }

        //tu decydujemy po czym szuykac
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa rodzaju" };
        }

        //jak wyszukiwać
        public override void Find()
        {
            if (FindField == "Nazwa rodzaju")
            {
                List = new ObservableCollection<RodzajLiteracki>(
                    List.Where(x => x.NazwaRodzaju != null && x.NazwaRodzaju.ToLower().Contains(FindTextBox.ToLower())));
            }
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<RodzajLiteracki>
                (
                   bibliotekaEntities.RodzajLiteracki.ToList()
                );
        }
        #endregion
    }
}
