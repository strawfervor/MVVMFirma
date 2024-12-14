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
        }
        #endregion

        #region Pola
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
                    _WykonajCommand = new BaseCommand(() => wykonajDostepnoscClick());
                }
                return _WykonajCommand;
            }
        }

        private void wykonajDostepnoscClick()
        {
            DostepneEgzemplarze = new DostepnoscB(db).ListaDostepnych(IdKsiazki);
        }
        #endregion

    }
}
