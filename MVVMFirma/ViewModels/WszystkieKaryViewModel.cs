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
    public class WszystkieKaryViewModel : WszystkieViewModel<KaraForAllView>
    {
        #region Constructor

        public WszystkieKaryViewModel()
            : base("Kary")
        {
        }

        #endregion

        #region SortAndFind

        //tu decydujemy po czym sortować

        public override List<string> GetComboboxSortList()
        {
            //po dacie naliczenia i kwocie
            return new List<string> { "Data naliczenia", "Kwota" };
        }

        //jak sortować
        public override void Sort()
        {
            if (SortField == "Data naliczenia")
                List = new ObservableCollection<KaraForAllView>(List.OrderBy(x => x.DataNaliczenia));
            if (SortField == "Kwota")
                List = new ObservableCollection<KaraForAllView>(List.OrderBy(x => x.Kwota));
        }

        //tu decydujemy po czym szuykac
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwisko czytelnika", "Imie czytelnika", "Opis" };
        }

        //jak wyszukiwać
        public override void Find()
        {
            if (FindField == "Nazwisko czytelnika")
                List = new ObservableCollection<KaraForAllView>(List.Where(x => x.CzytelnikNazwisko != null && x.CzytelnikNazwisko.Contains(FindTextBox)));
            if (FindField == "Imie czytelnika")
                List = new ObservableCollection<KaraForAllView>(List.Where(x => x.CzytelnikImie != null && x.CzytelnikImie.Contains(FindTextBox)));
            if (FindField == "Opis")
            {
                List = new ObservableCollection<KaraForAllView>(
                    List.Where(x => x.Opis != null && x.Opis.ToLower().Contains(FindTextBox.ToLower())));
            }
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KaraForAllView>
                (
                   //tworzymy tutaj zapytanie linq
                   from kara in bibliotekaEntities.Kary //dla każdegi czytelnika z bazy danych czytelników
                   select new KaraForAllView //tworzymy nowe CzytelnikForAllView i uzupełniamy jego dane
                   {
                       IdKary = kara.Id,
                       CzytelnikImie = kara.Czytelnicy.Imie,
                       CzytelnikNazwisko = kara.Czytelnicy.Nazwisko,
                       Opis = kara.Opis,
                       DataNaliczenia = kara.DataNaliczenia,
                       Kwota = kara.Kwota,
                   }
                );
        }
        #endregion
    }
}
