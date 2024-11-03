using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowyUzytkownikSystemuViewModel : WorkspaceViewModel
    {
        #region DB
        private BibliotekaEntities bibliotekaEntites;
        #endregion
        #region Item
        private UzytkownicySystemu uzytkownicySystemu;
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
        #endregion
        #region Konstruktor
        public NowyUzytkownikSystemuViewModel()
        {
            base.DisplayName = "Użytkownik Systemu";
            bibliotekaEntites = new BibliotekaEntities();
            uzytkownicySystemu = new UzytkownicySystemu();
        }
        #endregion

        #region Properties
        //dla każdego pola na interface toworzymy properties
        public string Login
        {
            get
            {
                return uzytkownicySystemu.Login;
            }
            set
            {
                uzytkownicySystemu.Login = value;
                OnPropertyChanged(() => Login);
            }
        }

        public string Haslo
        {
            get
            {
                return uzytkownicySystemu.Haslo;
            }
            set
            {
                uzytkownicySystemu.Haslo = value;
                OnPropertyChanged(() => Haslo);
            }
        }

        public string Rola
        {
            get
            {
                return uzytkownicySystemu.Rola;
            }
            set
            {
                uzytkownicySystemu.Rola = value;
                OnPropertyChanged(() => Rola);
            }
        }
        #endregion
        #region Helpers
        public void Save()
        {
            bibliotekaEntites.UzytkownicySystemu.Add(uzytkownicySystemu);//dodaje usera do lokalnej kolekcji
            bibliotekaEntites.SaveChanges();//zapisuje zmiany do bazy danych
        }
        public void SaveAndClose()
        {
            Save();
            base.OnRequestClose();//zmaknięcie zakładki
        }
        #endregion
    }
}