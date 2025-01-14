using GalaSoft.MvvmLight.Messaging;
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
    public class WszystkieTagiViewModel : WszystkieViewModel<Tagi>
    {
        #region Constructor

        public WszystkieTagiViewModel()
            : base("Tagi")
        {
        }

        #endregion

        #region Properties

        private Tagi _WybranyTag;
        //do tego propertisa zostanie przypisany czytelnik kliknięty z listy czytelników.
        public Tagi WybranyTag
        {
            get
            {
                return _WybranyTag;
            }
            set
            {
                _WybranyTag = value;
                Messenger.Default.Send(_WybranyTag);
                //messengerem wysyłamy wybranego kontrahenta do okna z fakturą, a następnie zamykamy okno z listą czytelników (poniżej)
            }
        }

        #endregion

        #region SortAndFind

        //tu decydujemy po czym sortować

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Treść tagu" };
        }

        //jak sortować
        public override void Sort()
        {
            if (SortField == "Treść tagu")
                List = new ObservableCollection<Tagi>(List.OrderBy(x => x.TrescTagu));
        }

        //tu decydujemy po czym szuykac
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Treść tagu" };
        }

        //jak wyszukiwać
        public override void Find()
        {
            if (FindField == "Treść tagu")
            {
                List = new ObservableCollection<Tagi>(
                    List.Where(x => x.TrescTagu != null && x.TrescTagu.ToLower().Contains(FindTextBox.ToLower())));
            }
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Tagi>
                (
                   bibliotekaEntities.Tagi.ToList()
                );
        }
        #endregion

        #region Guzik do zamykania

        private BaseCommand _CancelandCloseCommand;
        public ICommand CancelandCloseCommand
        {
            get
            {
                if (_CancelandCloseCommand == null)
                    _CancelandCloseCommand = new BaseCommand(() => CancelandClose());
                return _CancelandCloseCommand;
            }
        }

        public void CancelandClose()
        {
            base.OnRequestClose();//zmaknięcie zakładki
        }
        #endregion
    }
}
