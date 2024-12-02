using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NowyAutorViewModel : JedenViewModel<Autorzy>
    {
        #region Konstruktor
        public NowyAutorViewModel()
                    : base("Dodaj autora")
        {
            item = new Autorzy();
        }
        #endregion

        #region Pola
        //dla każdego pola na interfejsie tworzymy dodajemy properties

        public String Imie
        {
            get
            {
                return item.Imie;
            }
            set
            {
                item.Imie = value;
                OnPropertyChanged(() => Imie);
            }
        }

        public DateTime? DataUrodzenia
        {
            get
            {
                return item.DataUrodzenia;
            }
            set
            {
                item.DataUrodzenia = value;
                OnPropertyChanged(() => DataUrodzenia);
            }
        }

        public String Nazwisko
        {
            get
            {
                return item.Nazwisko;
            }
            set
            {
                item.Nazwisko = value;
                OnPropertyChanged(() => Nazwisko);
            }
        }

        public String KrajPochodzenia
        {
            get
            {
                return item.KrajPochodzenia;
            }
            set
            {
                item.KrajPochodzenia = value;
                OnPropertyChanged(() => KrajPochodzenia);
            }
        }
        #endregion


        #region Właściwości dla ComboBoxów

        #endregion

        #region Helpers
        public override void Save()
        {
            bibliotekaEntites.Autorzy.Add(item);//dodaje wypozyczenie do lokalnej kolekcji
            bibliotekaEntites.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion
    }
}