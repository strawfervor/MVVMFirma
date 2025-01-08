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
    public class WszystkieZgloszeniaViewModel : WszystkieViewModel<ZgloszenieForAllView>
    {
        #region Constructor

        public WszystkieZgloszeniaViewModel()
            : base("Zgłoszenia")
        {
        }

        #endregion

        #region SortAndFind

        //tu decydujemy po czym sortować

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwisko czytelnika", "Data zgłoszenia" };
        }

        //jak sortować
        public override void Sort()
        {
            if (SortField == "Nazwisko czytelnika")
                List = new ObservableCollection<ZgloszenieForAllView>(List.OrderBy(x => x.CzytelnikNazwisko));
            if (SortField == "Data zgłoszenia")
                List = new ObservableCollection<ZgloszenieForAllView>(List.OrderBy(x => x.DataZgloszenia));
        }

        //tu decydujemy po czym szuykac
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Imie czytelnika", "Nazwisko czytelnika", "Opis" };
        }

        //jak wyszukiwać
        public override void Find()
        {
            if (FindField == "Opis")
            {
                List = new ObservableCollection<ZgloszenieForAllView>(
                    List.Where(x => x.Opis != null && x.Opis.ToLower().Contains(FindTextBox.ToLower())));
            }
            if (FindField == "Nazwisko czytelnika")
            {
                List = new ObservableCollection<ZgloszenieForAllView>(
                    List.Where(x => x.CzytelnikNazwisko != null && x.CzytelnikNazwisko.ToLower().Contains(FindTextBox.ToLower())));
            }
            if (FindField == "Imie czytelnika")
            {
                List = new ObservableCollection<ZgloszenieForAllView>(
                    List.Where(x => x.CzytelnikImie != null && x.CzytelnikImie.ToLower().Contains(FindTextBox.ToLower())));
            }
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ZgloszenieForAllView>
                (
                   //tworzymy tutaj zapytanie linq
                   from zgloszenie in bibliotekaEntities.Zgloszenia //dla każdegi czytelnika z bazy danych czytelników
                   select new ZgloszenieForAllView //tworzymy nowe CzytelnikForAllView i uzupełniamy jego dane
                   {
                       IdZgloszenia = zgloszenie.Id,
                       CzytelnikImie = zgloszenie.Czytelnicy.Imie,
                       CzytelnikNazwisko = zgloszenie.Czytelnicy.Nazwisko,
                       Opis = zgloszenie.Opis,
                       DataZgloszenia = zgloszenie.DataZgloszenia,
                   }
                );
        }
        #endregion
    }
}
