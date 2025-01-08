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
    public class WszystkieEgzemplarzeViewModel : WszystkieViewModel<EgzemplarzForAllView>
    {
        #region Constructor

        public WszystkieEgzemplarzeViewModel()
            : base("Egzemplarze")
        {
        }

        #endregion

        #region SortAndFind

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Stan", "Numer wewnętrzny", "Tytuł" };
        }

        //jak sortować
        public override void Sort()
        {
            if (SortField == "Stan")
                List = new ObservableCollection<EgzemplarzForAllView>(List.OrderBy(x => x.Stan));
            if (SortField == "Numer wewnętrzny")
                List = new ObservableCollection<EgzemplarzForAllView>(List.OrderBy(x => x.NumerWewnetrzny));
            if (SortField == "Tytuł")
                List = new ObservableCollection<EgzemplarzForAllView>(List.OrderBy(x => x.KsiazkiTytul));
        }

        //tu decydujemy po czym szuykac
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Stan", "Numer wewnętrzny" };
        }

        //jak wyszukiwać
        public override void Find()
        {
            if(FindField == "Stan")
                List = new ObservableCollection<EgzemplarzForAllView>(List.Where(x => x.Stan != null && x.Stan.Contains(FindTextBox)));
            if (FindField == "Numer wewnętrzny")
                List = new ObservableCollection<EgzemplarzForAllView>(List.Where(x => x.NumerWewnetrzny != null && x.NumerWewnetrzny.Contains(FindTextBox)));
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<EgzemplarzForAllView>
                (
                   //tworzymy tutaj zapytanie linq
                   from egzemplarz in bibliotekaEntities.Egzemplarze //dla każdegi czytelnika z bazy danych czytelników
                   select new EgzemplarzForAllView //tworzymy nowe CzytelnikForAllView i uzupełniamy jego dane
                   {
                       IdEgzemplarza = egzemplarz.Id,
                       KsiazkiTytul = egzemplarz.Ksiazki.Tytul,
                       NumerWewnetrzny = egzemplarz.NumerWewnetrznyEgzemplarzu,
                       Stan = egzemplarz.Stan,
                   }
                );
        }
        #endregion
    }
}
