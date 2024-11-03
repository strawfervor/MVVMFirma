using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel//pod T będą podstawiane konkretne typy elementow listy
    {
        #region DB
        protected readonly BibliotekaEntities bibliotekaEntities;//to jest pole, które reprezentuje baze danych
        #endregion
        #region LoadCommand
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
                OnPropertyChanged(() => List);//to jest "zlecenie odświezenia" listy na int4erface
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

        #region Helpers
        public abstract void Load();
        #endregion
    }
}
