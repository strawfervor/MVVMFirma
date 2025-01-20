using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            base.DisplayName = "Zarządzanie tagami";
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

        //nowe pola dla dodawania tagów i doklejania tagów do książki
        //
        //

        private string _TrescTagu;
        public string TrescTagu
        {
            get { return _TrescTagu; }
            set
            {
                if (_TrescTagu != value)
                {
                    _TrescTagu = value;
                    OnPropertyChanged(() => TrescTagu);
                }
            }
        }

        private int? _IdKsiazki;
        public int? IdKsiazki
        {
            get { return _IdKsiazki; }
            set
            {
                if (_IdKsiazki != value)
                {
                    _IdKsiazki = value;
                    OnPropertyChanged(() => IdKsiazki);
                }
            }
        }

        public IQueryable<KeyAndValue> KsiazkiItems
        {
            get
            {
                return new KsiazkaB(db).GetKsiazkiKeyAndValueItems();
            }
        }
        //private ObservableCollection<KeyAndValue> _KsiazkiItems;
        //public ObservableCollection<KeyAndValue> KsiazkiItems
        //{
        //    get { return _KsiazkiItems; }
        //    set
        //    {
        //        if (_KsiazkiItems != value)
        //        {
        //            _KsiazkiItems = value;
        //            OnPropertyChanged(() => KsiazkiItems);
        //        }
        //    }
        //}

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

        //Dodawanie tagów
        //dodawanie tagów do książki
        //

        private BaseCommand _DodajTagCommand;
        public ICommand DodajTagCommand
        {
            get
            {
                if (_DodajTagCommand == null)
                {
                    _DodajTagCommand = new BaseCommand(() => DodajTagClick());
                }
                return _DodajTagCommand;
            }
        }

        private void DodajTagClick()
        {
            try
            {
                DopasujB dopasujB = new DopasujB(db);
                dopasujB.DodajTag(TrescTagu);
                MessageBox.Show("Tag został dodany.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}");
            }
        }

        private BaseCommand _TagujCommand;
        public ICommand TagujCommand
        {
            get
            {
                if (_TagujCommand == null)
                {
                    _TagujCommand = new BaseCommand(() => TagujClick());
                }
                return _TagujCommand;
            }
        }

        private void TagujClick()
        {
            try
            {
                if (!IdKsiazki.HasValue || !IdTagu.HasValue)
                {
                    MessageBox.Show("Proszę wybrać książkę i tag.");
                    return;
                }

                DopasujB dopasujB = new DopasujB(db);
                dopasujB.PrzypiszTagDoKsiazki(IdKsiazki.Value, IdTagu.Value);
                MessageBox.Show("Tag został przypisany do książki.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}");
            }
        }

        #endregion
    }
}
