using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NoweWypozyczenieViewModel : JedenViewModel<Wypozyczenia>
    {
        #region Konstruktor
            public NoweWypozyczenieViewModel() 
                        :base("Dodaj wypożyczenie")
                    {
                        item = new Wypozyczenia();
                    }
        #endregion

        #region Commands

        private BaseCommand _ShowCzytelnicy;//to jest komenda ktora bezdie wywoływała funkcje showCzytelnicy ktora bedzie wyświetlała wszystkich czytelnikow i bedzie uruchamiana przez przycisk z  ...
        public ICommand ShowCzytelnicy
        {
            get
            {
                if (_ShowCzytelnicy == null)
                    _ShowCzytelnicy = new BaseCommand(() => showCzytelnicy());
                return _ShowCzytelnicy;
            }
        }

        private void showCzytelnicy()
        {
            Messenger.Default.Send("CzytelnicyAll");
        }

        #endregion

        #region Pola
        //dla każdego pola na interfejsie tworzymy dodajemy properties

        public int? IdKsiazki
        {
            get
            {
                return item.IdKsiazki;
            }
            set
            {
                item.IdKsiazki = value;
                OnPropertyChanged(() => IdKsiazki);
            }
        }

        public int? IdCzytelnika
        {
            get
            {
                return item.IdCzytelnika;
            }
            set
            {
                item.IdCzytelnika = value;
                OnPropertyChanged(() => IdCzytelnika);
            }
        }

        public DateTime? DataWypozyczenia
        {
            get
            {
                return item.DataWypozyczenia;
            }
            set
            {
                item.DataWypozyczenia = value;
                OnPropertyChanged(() => DataWypozyczenia);
            }
        }

        public DateTime? DataZwrotu
        {
            get
            {
                return item.DataZwrotu;
            }
            set
            {
                item.DataZwrotu = value;
                OnPropertyChanged(() => DataZwrotu);
            }
        }
        #endregion


        #region Właściwości dla ComboBoxów

        public IQueryable<KeyAndValue> KsiazkiItems
        {
            get
            {
                return new KsiazkaB(bibliotekaEntites).GetKsiazkiKeyAndValueItems();
            }
        }

        public IQueryable<KeyAndValue> CzytelnicyItems
        {
            get
            {
                return new CzytelnicyB(bibliotekaEntites).GetCzytelnicyKeyAndValueItems();
            }
        }

        #endregion

        #region Helpers
        public override void Save()
        {
            bibliotekaEntites.Wypozyczenia.Add(item);//dodaje wypozyczenie do lokalnej kolekcji
            bibliotekaEntites.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion
    }
}
