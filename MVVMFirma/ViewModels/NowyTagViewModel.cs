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
    public class NowyTagViewModel : JedenViewModel<Tagi>
    {
        #region Konstruktor
        public NowyTagViewModel()
                    : base("Dodaj tag")
        {
            item = new Tagi();
        }
        #endregion

        #region Pola
        //dla każdego pola na interfejsie tworzymy dodajemy properties

        public String TrescTagu
        {
            get
            {
                return item.TrescTagu;
            }
            set
            {
                item.TrescTagu = value;
                OnPropertyChanged(() => TrescTagu);
            }
        }
        #endregion


        #region Właściwości dla ComboBoxów


        #endregion

        #region Helpers
        public override void Save()
        {
            bibliotekaEntites.Tagi.Add(item);//dodaje wypozyczenie do lokalnej kolekcji
            bibliotekaEntites.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion
    }
}