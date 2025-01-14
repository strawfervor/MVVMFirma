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
    public class NowyCzytelnikViewModel : JedenViewModel<Czytelnicy>
    {
        #region Konstruktor
        public NowyCzytelnikViewModel()
                    : base("Dodaj czytelnika")
        {
            item = new Czytelnicy();
            Messenger.Default.Register<Adres>(this, getWybranyAdres);
        }
        #endregion

        #region Pola
        //dla każdego pola na interfejsie tworzymy dodajemy properties

        public int? IdAdresu
        {
            get
            {
                return item.IdAdresu;
            }
            set
            {
                item.IdAdresu = value;
                OnPropertyChanged(() => IdAdresu);
            }
        }

        public int? IdRodzajuCzlonkowstwa
        {
            get
            {
                return item.IdRodzajuCzlonkowstwa;
            }
            set
            {
                item.IdRodzajuCzlonkowstwa = value;
                OnPropertyChanged(() => IdRodzajuCzlonkowstwa);
            }
        }

        public String Imie
        {
            get
            {
                return item.Imie;
            }
            set
            {
                item.Imie = value;
                OnPropertyChanged(() => Imie);
            }
        }

        public String Nazwisko
        {
            get
            {
                return item.Nazwisko;
            }
            set
            {
                item.Nazwisko = value;
                OnPropertyChanged(() => Nazwisko);
            }
        }

        public int? IloscWypozyczonychKsiazek
        {
            get
            {
                return item.IloscWypozyczonychKsiazek;
            }
            set
            {
                item.IloscWypozyczonychKsiazek = value;
                OnPropertyChanged(() => IloscWypozyczonychKsiazek);
            }
        }

        public string AdresUlica { get; set; }
        #endregion

        #region Commands

        private BaseCommand _ShowAdresy;//to jest komenda ktora bezdie wywoływała funkcje showCzytelnicy ktora bedzie wyświetlała wszystkich czytelnikow i bedzie uruchamiana przez przycisk z  ...
        public ICommand ShowAdresy
        {
            get
            {
                if (_ShowAdresy == null)
                    _ShowAdresy = new BaseCommand(() => showAdresy());
                return _ShowAdresy;
            }
        }

        private void showAdresy()
        {
            Messenger.Default.Send("AdresyAll");
        }


        #endregion


        #region Właściwości dla ComboBoxów

        public IQueryable<KeyAndValue> AdresyItems
        {
            get
            {
                return new AdresyB(bibliotekaEntites).GetAdresyKeyAndValueItems();
            }
        }

        public IQueryable<KeyAndValue> RodzajCzlonkostwaItems
        {
            get
            {
                return new RodzajCzlonkostwaB(bibliotekaEntites).GetRodzajCzlonkostwaKeyAndValueItems();
            }
        }

        #endregion

        #region Helpers
        public override void Save()
        {
            bibliotekaEntites.Czytelnicy.Add(item);//dodaje wypozyczenie do lokalnej kolekcji
            bibliotekaEntites.SaveChanges();//zapisuje zmiany do bazy danych
        }

        private void getWybranyAdres(Adres adres)
        {
            IdAdresu = adres.Id;
            AdresUlica = adres.Ulica + " ," + adres.Miejscowosc;
        }
        #endregion
    }
}
