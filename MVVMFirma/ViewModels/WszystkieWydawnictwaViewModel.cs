using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieWydawnictwaViewModel : WszystkieViewModel<Wydawnictwa>
    {
        #region Constructor

        public WszystkieWydawnictwaViewModel()
            : base("Wydawnictwa")
        {
        }

        #endregion

        #region SortAndFind

        //tu decydujemy po czym sortować

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa", "Kraj" };
        }

        //jak sortować
        public override void Sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<Wydawnictwa>(List.OrderBy(x => x.Nazwa));
            if (SortField == "Kraj")
                List = new ObservableCollection<Wydawnictwa>(List.OrderBy(x => x.Kraj));
        }

        //tu decydujemy po czym szuykac
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa", "Kraj" };
        }

        //jak wyszukiwać
        public override void Find()
        {
            if (FindField == "Nazwa")
            {
                List = new ObservableCollection<Wydawnictwa>(
                    List.Where(x => x.Nazwa != null && x.Nazwa.ToLower().Contains(FindTextBox.ToLower())));
            }
            if (FindField == "Kraj")
            {
                List = new ObservableCollection<Wydawnictwa>(
                    List.Where(x => x.Kraj != null && x.Kraj.ToLower().Contains(FindTextBox.ToLower())));
            }
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Wydawnictwa>
                (
                   bibliotekaEntities.Wydawnictwa.ToList()
                );
        }
        #endregion
    }
}
