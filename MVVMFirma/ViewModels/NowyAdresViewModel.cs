using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowyAdresViewModel : WorkspaceViewModel
    {
        #region DB
        private BibliotekaEntities bibliotekaEntites;
        #endregion
        #region Item
        private Adres adres;
        #endregion
        #region Command
        //to jest komenta, ktora zostanie podpieta pod przycisk zapisz i zamknij i ona wywoła funkcje SaveAndClose
        private BaseCommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                    _SaveCommand = new BaseCommand(() => SaveAndClose());
                return _SaveCommand;
            }
        }
        #endregion
        #region Konstruktor
        public NowyAdresViewModel()
        {
            base.DisplayName = "Adres";
            bibliotekaEntites = new BibliotekaEntities();
            adres = new Adres();
        }
        #endregion

        #region Properties
        //dla każdego pola na interface toworzymy properties
        public string Ulica
        {
            get
            {
                return adres.Ulica;
            }
            set
            {
                adres.Ulica = value;
                OnPropertyChanged(() => Ulica);
            }
        }

        public string NumerDomu
        {
            get
            {
                return adres.NumerDomu;
            }
            set
            {
                adres.NumerDomu = value;
                OnPropertyChanged(() => NumerDomu);
            }
        }

        public string NumerMieszkania
        {
            get
            {
                return adres.NumerMieszkania;
            }
            set
            {
                adres.NumerMieszkania = value;
                OnPropertyChanged(() => NumerMieszkania);
            }
        }

        public string KodPocztowy
        {
            get
            {
                return adres.KodPocztowy;
            }
            set
            {
                adres.KodPocztowy = value;
                OnPropertyChanged(() => KodPocztowy);
            }
        }

        public string Miejscowosc
        {
            get
            {
                return adres.Miejscowosc;
            }
            set
            {
                adres.Miejscowosc = value;
                OnPropertyChanged(() => Miejscowosc);
            }
        }

        public string Poczta
        {
            get
            {
                return adres.Poczta;
            }
            set
            {
                adres.Poczta = value;
                OnPropertyChanged(() => Poczta);
            }
        }

        #endregion
        #region Helpers
        public void Save()
        {
            bibliotekaEntites.Adres.Add(adres);//dodaje usera do lokalnej kolekcji
            bibliotekaEntites.SaveChanges();//zapisuje zmiany do bazy danych
        }
        public void SaveAndClose()
        {
            Save();
            base.OnRequestClose();//zmaknięcie zakładki
        }
        #endregion
    }
}