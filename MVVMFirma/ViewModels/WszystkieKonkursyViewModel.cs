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
