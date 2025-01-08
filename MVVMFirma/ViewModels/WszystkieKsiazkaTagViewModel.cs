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
    public class WszystkieKsiazkaTagViewModel : WszystkieViewModel<KsiazkaTagForAllView>
    {
        #region Constructor

        public WszystkieKsiazkaTagViewModel()
            : base("Książka-Tag")
        {
        }

        #endregion

        #region SortAndFind

        //tu decydujemy po czym sortować

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Tytuł książki", "Nazwa tagu" };
        }

        //jak sortować
        public override void Sort()
        {
            if (SortField == "Tytuł książki")
                List = new ObservableCollection<KsiazkaTagForAllView>(List.OrderBy(x => x.KsiazkaTytul));
            if (SortField == "Nazwa tagu")
                List = new ObservableCollection<KsiazkaTagForAllView>(List.OrderBy(x => x.TagiTag));
        }

        //tu decydujemy po czym szuykac
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Tytuł książki", "Nazwa tagu" };
        }

        //jak wyszukiwać
        public override void Find()
        {
            if (FindField == "Tytuł książki")
            {
                List = new ObservableCollection<KsiazkaTagForAllView>(
                    List.Where(x => x.KsiazkaTytul != null && x.KsiazkaTytul.ToLower().Contains(FindTextBox.ToLower())));
            }
            if (FindField == "Nazwa tagu")
            {
                List = new ObservableCollection<KsiazkaTagForAllView>(
                    List.Where(x => x.TagiTag != null && x.TagiTag.ToLower().Contains(FindTextBox.ToLower())));
            }
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KsiazkaTagForAllView>
                (
                   //tworzymy tutaj zapytanie linq
                   from ksiazkaTag in bibliotekaEntities.KsiazkiTag //dla każdegi czytelnika z bazy danych czytelników
                   select new KsiazkaTagForAllView //tworzymy nowe CzytelnikForAllView i uzupełniamy jego dane
                   {
                       IdKsiazkaTag = ksiazkaTag.Id,
                       KsiazkaTytul = ksiazkaTag.Ksiazki.Tytul,
                       TagiTag = ksiazkaTag.Tagi.TrescTagu,
                   }
                );
        }
        #endregion
    }
}
