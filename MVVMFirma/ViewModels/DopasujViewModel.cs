using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class DopasujViewModel : WorkspaceViewModel
    {
        #region DB
        private BibliotekaEntities db;
        #endregion

        #region Konstruktor
        public DopasujViewModel()
        {
            base.DisplayName = "Dopasowanie książek";
            db = new BibliotekaEntities();
            Rok = 1;
        }
        #endregion

        #region Pola
        private List<string> _DopasowaneKsiazki;
        public List<string> DopasowaneKsiazki
        {
            get { return _DopasowaneKsiazki; }
            set
            {
                if (_DopasowaneKsiazki != value)
                {
                    _DopasowaneKsiazki = value;
                    OnPropertyChanged(() => DopasowaneKsiazki);
                }
            }
        }

        private int? _Rok;
        public int? Rok
        {
            get { return _Rok; }
            set
            {
                if (_Rok != value)
                {
                    _Rok = value;
                    OnPropertyChanged(() => Rok);
                }
            }
        }

        private int? _IdAutora;
        public int? IdAutora
        {
            get { return _IdAutora; }
            set
            {
                if (_IdAutora != value)
                {
                    _IdAutora = value;
                    OnPropertyChanged(() => IdAutora);
                }
            }
        }

        private int? _IdTagu;
        public int? IdTagu
        {
            get { return _IdTagu; }
            set
            {
                if (_IdTagu != value)
                {
                    _IdTagu = value;
                    OnPropertyChanged(() => IdTagu);
                }
            }
        }

        // ComboBoxy dla autorów i tagów
        public IQueryable<KeyAndValue> AutorzyItems
        {
            get
            {
                return new AutorzyB(db).GetAutorzyKeyAndValueItems();
            }
        }

        public IQueryable<KeyAndValue> TagiItems
        {
            get
            {
                return new TagiB(db).GetTagiKeyAndValueItems();
            }
        }
        #endregion

        #region Komendy
        private BaseCommand _WykonajCommand;
        public ICommand WykonajCommand
        {
            get
            {
                if (_WykonajCommand == null)
                {
                    _WykonajCommand = new BaseCommand(() => WykonajDopasowanieClick());
                }
                return _WykonajCommand;
            }
        }

        private void WykonajDopasowanieClick()
        {
            // Przekazujemy dane do klasy DopasujB, aby wyszukała książki
            DopasujB dopasujB = new DopasujB(db);
            DopasowaneKsiazki = dopasujB.WyszukajKsiazki(Rok, IdAutora, IdTagu);
        }
        #endregion
    }
}
