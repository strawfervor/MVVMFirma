using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MVVMFirma.ViewModels
{
    public class WszystkieKonkursyViewModel : WszystkieViewModel<KonkursyForAllView>
    {
        #region Constructor

        public WszystkieKonkursyViewModel()
            : base("Konkursy (wszystkie)")
        {
        }

        #endregion

        #region SortAndFind

        //tu decydujemy po czym sortować

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa konkursu", "Data rozpoczęcia", "Data zakończenia", "Status" };
        }

        //jak sortować
        public override void Sort()
        {
            if (SortField == "Nazwa konkursu")
                List = new ObservableCollection<KonkursyForAllView>(List.OrderBy(x => x.NazwaKonkursu));
            if (SortField == "Data rozpoczęcia")
                List = new ObservableCollection<KonkursyForAllView>(List.OrderBy(x => x.DataRozpoczecia));
            if (SortField == "Data zakończenia")
                List = new ObservableCollection<KonkursyForAllView>(List.OrderBy(x => x.DataZakonczenia));
            if (SortField == "Status")
                List = new ObservableCollection<KonkursyForAllView>(List.OrderBy(x => x.Status));
        }

        //tu decydujemy po czym szuykac
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Opis", "Status", "Nazwisko zwycięzcy", "Imie zwycięzcy", "Nazwa konkursu" };
        }

        //jak wyszukiwać
        public override void Find()
        {
            if (FindField == "Nazwisko zwycięzcy")
                List = new ObservableCollection<KonkursyForAllView>(List.Where(x => x.NazwiskoZwyciezcy != null && x.NazwiskoZwyciezcy.Contains(FindTextBox)));
            if (FindField == "Imie zwycięzcy")
                List = new ObservableCollection<KonkursyForAllView>(List.Where(x => x.ImieZwyciezcy != null && x.ImieZwyciezcy.Contains(FindTextBox)));
            if (FindField == "Nazwa konkursu")
                List = new ObservableCollection<KonkursyForAllView>(List.Where(x => x.NazwiskoZwyciezcy != null && x.NazwaKonkursu.Contains(FindTextBox)));
            if (FindField == "Status")
                List = new ObservableCollection<KonkursyForAllView>(List.Where(x => x.Status != null && x.Status.Contains(FindTextBox)));
            if (FindField == "Opis")
            {
                List = new ObservableCollection<KonkursyForAllView>(
                    List.Where(x => x.OpisKonkursu != null && x.OpisKonkursu.ToLower().Contains(FindTextBox.ToLower())));
            }
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KonkursyForAllView>
            (
            //tworzymy tutaj zapytanie linq
                   from konkurs in bibliotekaEntities.Konkursy //dla każdegi czytelnika z bazy danych czytelników
                   select new KonkursyForAllView //tworzymy nowe CzytelnikForAllView i uzupełniamy jego dane
                   {
                       IdKonkursu = konkurs.Id,
                       NazwaKonkursu = konkurs.NazwaKonkursu,
                       OpisKonkursu = konkurs.Opis,
                       Status = konkurs.Status,
                       ImieZwyciezcy = konkurs.Czytelnicy.Imie,
                       NazwiskoZwyciezcy = konkurs.Czytelnicy.Nazwisko,
                       DataRozpoczecia = konkurs.DataRozpoczecia,
                       DataZakonczenia = konkurs.DataZakonczenia,
                   }
                );
        }
        #endregion
    }
}
