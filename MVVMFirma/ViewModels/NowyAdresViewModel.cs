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
    public class NowyAdresViewModel : JedenViewModel<Adres>
    {
        #region Konstruktor
        public NowyAdresViewModel()
                    : base("Dodaj karę")
        {
            item = new Adres();
        }
        #endregion

        #region Pola
        //dla każdego pola na interfejsie tworzymy dodajemy properties

        public String Ulica
        {
            get
            {
                return item.Ulica;
            }
            set
            {
                item.Ulica = value;
                OnPropertyChanged(() => Ulica);
            }
        }

        public String NumerDomu
        {
            get
            {
                return item.NumerDomu;
            }
            set
            {
                item.NumerDomu = value;
                OnPropertyChanged(() => NumerDomu);
            }
        }

        public String NumerMieszkania
        {
            get
            {
                return item.NumerMieszkania;
            }
            set
            {
                item.NumerMieszkania = value;
                OnPropertyChanged(() => NumerMieszkania);
            }
        }

        public String KodPocztowy
        {
            get
            {
                return item.KodPocztowy;
            }
            set
            {
                item.KodPocztowy = value;
                OnPropertyChanged(() => KodPocztowy);
            }
        }

        public String Miejscowosc
        {
            get
            {
                return item.Miejscowosc;
            }
            set
            {
                item.Miejscowosc = value;
                OnPropertyChanged(() => Miejscowosc);
            }
        }

        public String Poczta
        {
            get
            {
                return item.Poczta;
            }
            set
            {
                item.Poczta = value;
                OnPropertyChanged(() => Poczta);
            }
        }


        #endregion


        #region Właściwości dla ComboBoxów



        #endregion

        #region Helpers
        public override void Save()
        {
            bibliotekaEntites.Adres.Add(item);//dodaje wypozyczenie do lokalnej kolekcji
            bibliotekaEntites.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion
    }
}