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
    public class WszystkieAdresyViewModel : WszystkieViewModel<Adres>
    {
        #region Constructor

        public WszystkieAdresyViewModel()
            : base("Adresy")
        {
        }

        #endregion

        #region Properties

        private Adres _WybranyAdres;
        //do tego propertisa zostanie przypisany czytelnik kliknięty z listy czytelników.
        public Adres WybranyAdres
        {
            get
            {
                return _WybranyAdres;
            }
            set
            {
                _WybranyAdres = value;
                Messenger.Default.Send(_WybranyAdres);
                //messengerem wysyłamy wybranego kontrahenta do okna z fakturą, a następnie zamykamy okno z listą czytelników (poniżej)
            }
        }

        #endregion

        #region SortAndFind

        //tu decydujemy po czym sortować

        public override List<string> GetComboboxSortList()
        {
            //po Ulicy i mieście
            return new List<string> {"Ulica", "Kod pocztowy", "Miejscowosc" }; 
        }

        //jak sortować
        public override void Sort()
        {
            if (SortField == "Ulica")
                List = new ObservableCollection<Adres>
                    (
                       bibliotekaEntities.Adres.OrderBy(x => x.Ulica).ToList()
                    );
            else if (SortField == "Kod pocztowy")
                List = new ObservableCollection<Adres>
                    (
                       bibliotekaEntities.Adres.OrderBy(x => x.KodPocztowy).ToList()
                    );
            else if (SortField == "Miejscowosc")
                List = new ObservableCollection<Adres>
                    (
                       bibliotekaEntities.Adres.OrderBy(x => x.Miejscowosc).ToList()
                    );
        }

        //tu decydujemy po czym szuykac
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Ulica", "Numer domu", "Miejscowosc" };
        }

        //jak wyszukiwać
        public override void Find()
        {
            if (FindField == "Ulica")
                List = new ObservableCollection<Adres>
                    (
                       bibliotekaEntities.Adres.Where(x => x.Ulica.Contains(FindTextBox)).ToList()
                    );
            else if (FindField == "Numer domu")
                List = new ObservableCollection<Adres>
                    (
                       bibliotekaEntities.Adres.Where(x => x.NumerDomu.Contains(FindTextBox)).ToList()
                    );
            else if (FindField == "Miejscowosc")
                List = new ObservableCollection<Adres>
                    (
                       bibliotekaEntities.Adres.Where(x => x.Miejscowosc.Contains(FindTextBox)).ToList()
                    );
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Adres>
                (
                   bibliotekaEntities.Adres.ToList()
                );
        }
        #endregion

        #region Guzik do zamykania

        private BaseCommand _CancelandCloseCommand;
        public ICommand CancelandCloseCommand
        {
            get
            {
                if (_CancelandCloseCommand == null)
                    _CancelandCloseCommand = new BaseCommand(() => CancelandClose());
                return _CancelandCloseCommand;
            }
        }

        public void CancelandClose()
        {
            base.OnRequestClose();//zmaknięcie zakładki
        }
        #endregion
    }
}
