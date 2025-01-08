using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class WszyswcyCzytelnicyViewModel : WszystkieViewModel<CzytelnikForAllView>
    {
        #region Constructor

        public WszyswcyCzytelnicyViewModel()
            : base("Czytelnicy")
        {
        }

        #endregion

        #region SortAndFind

        //tu decydujemy po czym sortować

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Imie", "Nazwisko", "Ulica", "Miejscowość", "Rodzaj członkostwa" };
        }

        //jak sortować
        public override void Sort()
        {
            if (SortField == "Imie")
                List = new ObservableCollection<CzytelnikForAllView>(List.OrderBy(x => x.Imie));
            if (SortField == "Nazwisko")
                List = new ObservableCollection<CzytelnikForAllView>(List.OrderBy(x => x.Nazwisko));
            if (SortField == "Ulica")
                List = new ObservableCollection<CzytelnikForAllView>(List.OrderBy(x => x.AdresUlica));
            if (SortField == "Miejscowość")
                List = new ObservableCollection<CzytelnikForAllView>(List.OrderBy(x => x.AdresMiejscowosc));
            if (SortField == "Rodzaj członkostwa")
                List = new ObservableCollection<CzytelnikForAllView>(List.OrderBy(x => x.RodzajeCzlonkostwaNazwaCzlonkowstwa));
        }

        //tu decydujemy po czym szuykac
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Imie", "Nazwisko", "Ulica", "Miejscowość", "Rodzaj członkostwa" };
        }

        //jak wyszukiwać
        public override void Find()
        {
            if (FindField == "Imie")
            {
                List = new ObservableCollection<CzytelnikForAllView>(
                    List.Where(x => x.Imie != null && x.Imie.ToLower().Contains(FindTextBox.ToLower())));
            }
            if (FindField == "Nazwisko")
            {
                List = new ObservableCollection<CzytelnikForAllView>(
                    List.Where(x => x.Nazwisko != null && x.Nazwisko.ToLower().Contains(FindTextBox.ToLower())));
            }
            if (FindField == "Ulica")
            {
                List = new ObservableCollection<CzytelnikForAllView>(
                    List.Where(x => x.AdresUlica != null && x.AdresUlica.ToLower().Contains(FindTextBox.ToLower())));
            }
            if (FindField == "Miejscowość")
            {
                List = new ObservableCollection<CzytelnikForAllView>(
                    List.Where(x => x.AdresMiejscowosc != null && x.AdresMiejscowosc.ToLower().Contains(FindTextBox.ToLower())));
            }
            if (FindField == "Rodzaj członkostwa")
            {
                List = new ObservableCollection<CzytelnikForAllView>(
                    List.Where(x => x.RodzajeCzlonkostwaNazwaCzlonkowstwa != null && x.RodzajeCzlonkostwaNazwaCzlonkowstwa.ToLower().Contains(FindTextBox.ToLower())));
            }
        }

        #endregion

        #region Properties

        private CzytelnikForAllView _WybranyCzytelnik;
        //do tego propertisa zostanie przypisany czytelnik kliknięty z listy czytelników.
        public CzytelnikForAllView WybranyCzytelnik
        {
            get
            {
                return _WybranyCzytelnik;
            }
            set
            {
                _WybranyCzytelnik = value;
                Messenger.Default.Send(_WybranyCzytelnik);
                //messengerem wysyłamy wybranego kontrahenta do okna z fakturą, a następnie zamykamy okno z listą czytelników (poniżej)
                OnRequestClose();
            }
        }

        #endregion


        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<CzytelnikForAllView>
                (
                   //tworzymy tutaj zapytanie linq
                   from czytelnik in bibliotekaEntities.Czytelnicy //dla każdegi czytelnika z bazy danych czytelników
                   select new CzytelnikForAllView //tworzymy nowe CzytelnikForAllView i uzupełniamy jego dane
                   {
                       IdCzytelnika = czytelnik.Id,
                       Imie = czytelnik.Imie,
                       Nazwisko = czytelnik.Nazwisko,
                       AdresUlica = czytelnik.Adres.Ulica, //odwołanie do Adresu
                       AdresNumerDomu = czytelnik.Adres.NumerDomu,
                       AdresMiejscowosc = czytelnik.Adres.Miejscowosc,
                       RodzajeCzlonkostwaNazwaCzlonkowstwa = czytelnik.RodzajCzlonkostwa.NazwaCzlonkowstwa,
                       IloscWypozyczonychKsiazek = czytelnik.IloscWypozyczonychKsiazek,
                       MaksWypozyczen = czytelnik.RodzajCzlonkostwa.MaxKsiazekWypozyczonych,
                   }
                );
        }
        #endregion
    }
}