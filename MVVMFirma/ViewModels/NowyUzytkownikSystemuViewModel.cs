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
    public class NowyUzytkownikSystemuViewModel : JedenViewModel<UzytkownicySystemu>
    {

        #region Konstruktor
        public NowyUzytkownikSystemuViewModel()
            :base("Użytkownicy Systemu")
        {
            item = new UzytkownicySystemu();
        }
        #endregion

        #region Properties
        //dla każdego pola na interface toworzymy properties
        public string Login
        {
            get
            {
                return item.Login;
            }
            set
            {
                item.Login = value;
                OnPropertyChanged(() => Login);
            }
        }

        public string Haslo
        {
            get
            {
                return item.Haslo;
            }
            set
            {
                item.Haslo = value;
                OnPropertyChanged(() => Haslo);
            }
        }

        public string Rola
        {
            get
            {
                return item.Rola;
            }
            set
            {
                item.Rola = value;
                OnPropertyChanged(() => Rola);
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            bibliotekaEntites.UzytkownicySystemu.Add(item);//dodaje usera do lokalnej kolekcji
            bibliotekaEntites.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion
    }
}
