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
    public class NowyRodzajLiterackiViewModel : JedenViewModel<RodzajLiteracki>
    {
        #region Konstruktor
        public NowyRodzajLiterackiViewModel()
                    : base("Dodaj rodzaj literacki")
        {
            item = new RodzajLiteracki();
        }
        #endregion

        #region Pola
        //dla każdego pola na interfejsie tworzymy dodajemy properties

        public String NazwaRodzaju
        {
            get
            {
                return item.NazwaRodzaju;
            }
            set
            {
                item.NazwaRodzaju = value;
                OnPropertyChanged(() => NazwaRodzaju);
            }
        }

        #endregion


        #region Właściwości dla ComboBoxów


        #endregion

        #region Helpers
        public override void Save()
        {
            bibliotekaEntites.RodzajLiteracki.Add(item);//dodaje wypozyczenie do lokalnej kolekcji
            bibliotekaEntites.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion
    }
}