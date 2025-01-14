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
    public class NowyKsiazkaTagViewModel : JedenViewModel<KsiazkiTag>
    {
        #region Konstruktor
        public NowyKsiazkaTagViewModel()
                    : base("Dodaj tag do książki")
        {
            item = new KsiazkiTag();
            Messenger.Default.Register<KsiazkaForAllView>(this, getWybranaKsiazka);
            Messenger.Default.Register<Tagi>(this, getWybranyTag);
        }
        #endregion

        #region Commands

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

        private void showKsiazki()
        {
            Messenger.Default.Send("KsiazkiAll");
        }


        private BaseCommand _ShowTag;//to jest komenda ktora bezdie wywoływała funkcje showCzytelnicy ktora bedzie wyświetlała wszystkich czytelnikow i bedzie uruchamiana przez przycisk z  ...
        public ICommand ShowTag
        {
            get
            {
                if (_ShowTag == null)
                    _ShowTag = new BaseCommand(() => showTag());
                return _ShowTag;
            }
        }

        private void showTag()
        {
            Messenger.Default.Send("TagAll");
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

        public int? IdTagu
        {
            get
            {
                return item.IdTagu;
            }
            set
            {
                item.IdTagu = value;
                OnPropertyChanged(() => IdTagu);
            }
        }

        public string KsiazkaTytul { get; set; }
        public string NazwaTagu { get; set; }
        #endregion


        #region Właściwości dla ComboBoxów

        public IQueryable<KeyAndValue> KsiazkiItems
        {
            get
            {
                return new KsiazkaB(bibliotekaEntites).GetKsiazkiKeyAndValueItems();
            }
        }

        public IQueryable<KeyAndValue> TagiItems
        {
            get
            {
                return new TagiB(bibliotekaEntites).GetTagiKeyAndValueItems();
            }
        }

        #endregion

        #region Helpers
        public override void Save()
        {
            bibliotekaEntites.KsiazkiTag.Add(item);//dodaje wypozyczenie do lokalnej kolekcji
            bibliotekaEntites.SaveChanges();//zapisuje zmiany do bazy danych
        }

        private void getWybranaKsiazka(KsiazkaForAllView ksiazka)
        {
            IdKsiazki = ksiazka.IdKsiazki;
            KsiazkaTytul = ksiazka.Tytul;
        }

        private void getWybranyTag(Tagi tag)
        {
            IdTagu = tag.Id;
            NazwaTagu = tag.TrescTagu;
        }
        #endregion
    }
}