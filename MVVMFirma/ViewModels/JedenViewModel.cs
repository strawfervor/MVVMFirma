using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public abstract class JedenViewModel<T>: WorkspaceViewModel
    {
        #region DB
        protected BibliotekaEntities bibliotekaEntites;
        #endregion

        #region Item
        protected T item;
        #endregion

        #region Command
        //to jest komenta, ktora zostanie podpieta pod przycisk zapisz i zamknij i ona wywoła funkcje SaveAndClose
        private BaseCommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                    _SaveCommand = new BaseCommand(() => SaveAndClose());
                return _SaveCommand;
            }
        }

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
        #endregion


        #region Konstruktor
        public JedenViewModel(String displayName)
        {
            base.DisplayName = displayName;
            bibliotekaEntites = new BibliotekaEntities();
        }
        #endregion

        #region Helpers
        public abstract void Save();
            public void SaveAndClose()
            {
                Save();
                base.OnRequestClose();//zmaknięcie zakładki
            }

        public void CancelandClose()
        {
            base.OnRequestClose();//zmaknięcie zakładki
        }
        #endregion
    }
}
