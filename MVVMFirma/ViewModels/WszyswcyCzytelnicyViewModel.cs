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