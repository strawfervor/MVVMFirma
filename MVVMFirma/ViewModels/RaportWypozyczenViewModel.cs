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
    public class RaportWypozyczenViewModel : WorkspaceViewModel
    {
        #region DB
        BibliotekaEntities db;

        #endregion
        #region Konstruktor
        public RaportWypozyczenViewModel()
        {
            base.DisplayName = "Raport Wypożyczeń";
            db = new BibliotekaEntities();
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
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

        private int _IdKsiazki;
        public int IdKsiazki
        {
            get
            {
                return _IdKsiazki;
            }
            set
            {
                if (value != _IdKsiazki)
                {
                    _IdKsiazki = value;
                    OnPropertyChanged(() => IdKsiazki);
                }
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
        #endregion

        //region żeby działał button, musi tu być podpięta komenda:
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
        #endregion

    }
}
