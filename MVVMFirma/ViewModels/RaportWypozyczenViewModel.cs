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
    public class RaportWypozyczenViewModel : JedenViewModel<Wypozyczenia>//WorkspaceViewModel
    {
        #region DB
        BibliotekaEntities db;

        #endregion
        #region Konstruktor
        public RaportWypozyczenViewModel()
            : base("Manager wypożyczeń")
        {
            db = new BibliotekaEntities();
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
            item = new Wypozyczenia();
        }
        #endregion

        #region Pola
        //dla każdego pola istotnego dla obliczeń tworzymy pole i właściwość

        private List<string> _RaportWypozyczen;
        public List<string> RaportWypozyczen
        {
            get { return _RaportWypozyczen; }
            set
            {
                if (_RaportWypozyczen != value)
                {
                    _RaportWypozyczen = value;
                    OnPropertyChanged(() => RaportWypozyczen);
                }
            }
        }

        private DateTime _DataOd;
        public DateTime DataOd
        {
            get { return _DataOd; }
            set
            {
                if (_DataOd != value)
                {
                    _DataOd = value;
                    OnPropertyChanged(() => DataOd);
                }
            }
        }

        private DateTime _DataDo;
        public DateTime DataDo
        {
            get { return _DataDo; }
            set
            {
                if (_DataDo != value)
                {
                    _DataDo = value;
                    OnPropertyChanged(() => DataDo);
                }
            }
        }

        //private int _IdKsiazki;
        //public int IdKsiazki
        //{
        //    get
        //    {
        //        return _IdKsiazki;
        //    }
        //    set
        //    {
        //        if (value != _IdKsiazki)
        //        {
        //            _IdKsiazki = value;
        //            OnPropertyChanged(() => IdKsiazki);
        //        }
        //    }
        //}

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

        //comboboxa robienie ; to jest proporties ktory uzupelni wszystkie pola w komboboksie
        public IQueryable<KeyAndValue> KsiazkiItems
        {
            get
            {
                return new KsiazkaB(db).GetKsiazkiKeyAndValueItems();
            }
        }


        //Rzeczy z DostępnośćViewModel:

        //dla każdego pola istotnego dla obliczeń tworzymy pole i właściwość

        private List<string> _DostepneEgzemplarze;
        public List<string> DostepneEgzemplarze
        {
            get { return _DostepneEgzemplarze; }
            set
            {
                if (_DostepneEgzemplarze != value)
                {
                    _DostepneEgzemplarze = value;
                    OnPropertyChanged(() => DostepneEgzemplarze);
                }
            }
        }


        //z nowych wypożyczeń::

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

        //end region polaaaa ^^^^^


        //region żeby działał button, musi tu być podpięta komenda:

        #region Właściwości dla ComboBoxów

        public IQueryable<KeyAndValue> CzytelnicyItems
        {
            get
            {
                return new CzytelnicyB(bibliotekaEntites).GetCzytelnicyKeyAndValueItems();
            }
        }



        #endregion



        //end region comboboxy ^^^^^



        #region Komendy
        //to jest komenda która zostanie podpięta pod przycisk Wykonaj i która wywoła wykonajDostepnoscClick()
        private BaseCommand _WykonajCommand;
        public ICommand WykonajCommand
        {
            get
            {
                if (_WykonajCommand == null)
                {
                    _WykonajCommand = new BaseCommand(() => wykonajRaportClick());
                }
                return _WykonajCommand;
            }
        }

        private void wykonajRaportClick()
        {
            RaportWypozyczen = new RaportWypozyczenB(db).RaportWypozyczen(IdKsiazki, DataOd, DataDo);
        }

        //dostępność przeniesiona tutaj z DostępnośćViewModel //zmieniono na WykonajCommandD

        private BaseCommand _WykonajCommandD;
        public ICommand WykonajCommandD
        {
            get
            {
                if (_WykonajCommandD == null)
                {
                    _WykonajCommandD = new BaseCommand(() => wykonajDostepnoscClick());
                }
                return _WykonajCommandD;
            }
        }

        
        private void wykonajDostepnoscClick()
        {
            RaportWypozyczen = new DostepnoscB(db).ListaDostepnych(IdKsiazki);//raport wypożyczeń bo lista jest bindowana pod tą zmienną
        }

        public override void Save()
        {
            bibliotekaEntites.Wypozyczenia.Add(item);//dodaje wypozyczenie do lokalnej kolekcji
            bibliotekaEntites.SaveChanges();//zapisuje zmiany do bazy danych
        }


        #endregion

    }
}
