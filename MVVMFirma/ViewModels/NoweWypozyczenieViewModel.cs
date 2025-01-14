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
                        //to jest messenger, który oczekuje na czytelnika, z widoku ze wszystkim czytelnikami, jak go złapie to wywoła metodę getWybranyCzytelnik;
                        Messenger.Default.Register<CzytelnikForAllView>(this, getWybranyCzytelnik);
                        Messenger.Default.Register<KsiazkaForAllView>(this, getWybranaKsiazka);
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

        private BaseCommand _ShowKsiazki;//to jest komenda ktora bezdie wywoływała funkcje showCzytelnicy ktora bedzie wyświetlała wszystkich czytelnikow i bedzie uruchamiana przez przycisk z  ...
        public ICommand ShowKsiazki
        {
            get
            {
                if (_ShowKsiazki == null)
                    _ShowKsiazki = new BaseCommand(() => showKsiazki());
                return _ShowKsiazki;
            }
        }

        private void showCzytelnicy()
        {
            Messenger.Default.Send("CzytelnicyAll");
        }

        private void showKsiazki()
        {
            Messenger.Default.Send("KsiazkiAll");
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

        public string CzytelnikImie { get; set; }

        public string CzytelnikNazwisko { get; set; }

        public string KsiazkaTytul { get; set; }

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

        //to jest funkcja, która wywoła się po przesłaniu kontrahenta z okna wszyscy kontrahenci.
        private void getWybranyCzytelnik(CzytelnikForAllView czytelnik)
        {
                IdCzytelnika = czytelnik.IdCzytelnika;
                CzytelnikImie = czytelnik.Imie;
                CzytelnikNazwisko = czytelnik.Nazwisko;
        }

        private void getWybranaKsiazka(KsiazkaForAllView ksiazka)
        {
            IdKsiazki = ksiazka.IdKsiazki;
            KsiazkaTytul = ksiazka.Tytul;
        }

        public override void Save()
        {
            bibliotekaEntites.Wypozyczenia.Add(item);//dodaje wypozyczenie do lokalnej kolekcji
            bibliotekaEntites.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion
    }
}
