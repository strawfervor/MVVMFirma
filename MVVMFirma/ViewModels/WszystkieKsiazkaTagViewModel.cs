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
            : base("Książka-Tag (wszystkie)")
        {
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
