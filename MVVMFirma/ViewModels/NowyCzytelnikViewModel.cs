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
    public class NowyCzytelnikViewModel : JedenViewModel<Czytelnicy>
    {
        #region Konstruktor
        public NowyCzytelnikViewModel()
                    : base("Dodaj czytelnika")
        {
            item = new Czytelnicy();
        }
        #endregion

        #region Pola
        //dla każdego pola na interfejsie tworzymy dodajemy properties

        public int? IdAdresu
        {
            get
            {
                return item.IdAdresu;
            }
            set
            {
                item.IdAdresu = value;
                OnPropertyChanged(() => IdAdresu);
            }
        }

        public int? IdRodzajuCzlonkowstwa
        {
            get
            {
                return item.IdRodzajuCzlonkowstwa;
            }
            set
            {
                item.IdRodzajuCzlonkowstwa = value;
                OnPropertyChanged(() => IdRodzajuCzlonkowstwa);
            }
        }

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

        public int? IloscWypozyczonychKsiazek
        {
            get
            {
                return item.IloscWypozyczonychKsiazek;
            }
            set
            {
                item.IloscWypozyczonychKsiazek = value;
                OnPropertyChanged(() => IloscWypozyczonychKsiazek);
            }
        }
        #endregion


        #region Właściwości dla ComboBoxów

        public IQueryable<KeyAndValue> AdresyItems
        {
            get
            {
                return new AdresyB(bibliotekaEntites).GetAdresyKeyAndValueItems();
            }
        }

        public IQueryable<KeyAndValue> RodzajCzlonkostwaItems
        {
            get
            {
                return new RodzajCzlonkostwaB(bibliotekaEntites).GetRodzajCzlonkostwaKeyAndValueItems();
            }
        }

        #endregion

        #region Helpers
        public override void Save()
        {
            bibliotekaEntites.Czytelnicy.Add(item);//dodaje wypozyczenie do lokalnej kolekcji
            bibliotekaEntites.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion
    }
}
