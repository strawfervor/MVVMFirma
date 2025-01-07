using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel//pod T będą podstawiane konkretne typy elementow listy
    {
        #region DB
        protected readonly BibliotekaEntities bibliotekaEntities;//to jest pole, które reprezentuje baze danych
        #endregion
        #region Command
        private BaseCommand _LoadCommand;//to jest komenda ktora bezdie wywoływała funkcje Load pobierajaca z bazy danych towary
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                    _LoadCommand = new BaseCommand(() => Load());
                return _LoadCommand;
            }
        }

        private BaseCommand _AddCommand;//to jest komenda ktora bezdie wywoływała funkcje Add wywołującą okno do dodawania i zostanie podpięta pod przycisk dodaj
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                    _AddCommand = new BaseCommand(() => add());
                return _AddCommand;
            }
        }

        #endregion
        #region List
        private ObservableCollection<T> _List;//tu beda przechowywane towary pobrane z bazy dancyh.
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                    Load();
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);//to jest "zlecenie odświezenia" listy na interface
            }
        }

        #endregion

        #region Constructor

        public WszystkieViewModel(String displayName)
        {
            bibliotekaEntities = new BibliotekaEntities();
            base.DisplayName = displayName;

        }

        #endregion

        #region Sort And Filtr
        //do sortowania:
        //wynik wyboru po czym sortować zostanie zapisany w SortField.
        public string SortField { get; set; }
        private BaseCommand _SortCommand;//to jest komenda ktora bezdie wywoływała funkcje po nacisnieciu przycisku sortuj w filtrowaniu (generic.xaml)
        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                    _SortCommand = new BaseCommand(() => Sort());
                return _SortCommand;
            }
        }
        public List<string> SortComboboxItems 
        { 
            get
            {
                return GetComboboxSortList();
            }
        }

        public abstract void Sort();

        public abstract List<string> GetComboboxSortList();

        //do fitrowania:


        public string FindField { get; set; }
        public string FindTextBox { get; set; }
        private BaseCommand _FindCommand;//to jest komenda ktora bezdie wywoływała funkcje po nacisnieciu przycisku szukaj w wyszukiwaniu (generic.xaml)
        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                    _FindCommand = new BaseCommand(() => Find());
                return _FindCommand;
            }
        }
        public List<string> FindComboboxItems
        {
            get
            {
                return GetComboboxFindList();
            }
        }

        public abstract void Find();

        public abstract List<string> GetComboboxFindList();

        #endregion

        #region Helpers
        public abstract void Load();

        private void add()
        {
            //messenger jest z biblioteki MVVMLight
            //dzięki messengerowi wysyłamy do innych obiektów komunikat DisplayNameAdd, gdzie display name jest nazwą widoku
            //tem komunikat odbierze MainWindowViewModel, które odpowiada za otwieranie zadkładek/okien
            Messenger.Default.Send(DisplayName + "Add");
        }
        #endregion

    }
}
