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
    public class NowyRodzajCzlonkostwaViewModel : JedenViewModel<RodzajCzlonkostwa>
    {
        #region Konstruktor
        public NowyRodzajCzlonkostwaViewModel()
                    : base("Dodaj rodzaj członkostwa")
        {
            item = new RodzajCzlonkostwa();
        }
        #endregion

        #region Pola
        //dla każdego pola na interfejsie tworzymy dodajemy properties

        public String NazwaCzlonkowstwa
        {
            get
            {
                return item.NazwaCzlonkowstwa;
            }
            set
            {
                item.NazwaCzlonkowstwa = value;
                OnPropertyChanged(() => NazwaCzlonkowstwa);
            }
        }

        public int? MaxKsiazekWypozyczonych
        {
            get
            {
                return item.MaxKsiazekWypozyczonych;
            }
            set
            {
                item.MaxKsiazekWypozyczonych = value;
                OnPropertyChanged(() => MaxKsiazekWypozyczonych);
            }
        }

        public int? MaxCzasWypozyczenia
        {
            get
            {
                return item.MaxCzasWypozyczenia;
            }
            set
            {
                item.MaxCzasWypozyczenia = value;
                OnPropertyChanged(() => MaxCzasWypozyczenia);
            }
        }

        #endregion


        #region Właściwości dla ComboBoxów



        #endregion

        #region Helpers
        public override void Save()
        {
            bibliotekaEntites.RodzajCzlonkostwa.Add(item);//dodaje wypozyczenie do lokalnej kolekcji
            bibliotekaEntites.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion
    }
}
