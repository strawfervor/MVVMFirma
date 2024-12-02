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
    public class NowaRezerwacjaViewModel : JedenViewModel<Rezerwacje>
    {
        #region Konstruktor
        public NowaRezerwacjaViewModel()
                    : base("Dodaj rezerwację")
        {
            item = new Rezerwacje();
            DataRezerwacji = DateTime.Now;
        }
        #endregion

        #region Pola
        //dla każdego pola na interfejsie tworzymy dodajemy properties


        public int? IdKsiazki
        {
            get
            {
                return item.IdKsiazki;
            }
            set
            {
                item.IdKsiazki = value;
                OnPropertyChanged(() => IdKsiazki);
            }
        }

        public int? IdCzytelnika
        {
            get
            {
                return item.IdCzytelnika;
            }
            set
            {
                item.IdCzytelnika = value;
                OnPropertyChanged(() => IdCzytelnika);
            }
        }

        public DateTime? DataRezerwacji
        {
            get
            {
                return item.DataRezerwacji;
            }
            set
            {
                item.DataRezerwacji = value;
                OnPropertyChanged(() => DataRezerwacji);
            }
        }

        public DateTime? DataOdbioruKsiazki
        {
            get
            {
                return item.DataOdbioruKsiazki;
            }
            set
            {
                item.DataOdbioruKsiazki = value;
                OnPropertyChanged(() => DataOdbioruKsiazki);
            }
        }


        #endregion


        #region Właściwości dla ComboBoxów

        public IQueryable<KeyAndValue> CzytelnicyItems
        {
            get
            {
                return new CzytelnicyB(bibliotekaEntites).GetCzytelnicyKeyAndValueItems();
            }
        }

        public IQueryable<KeyAndValue> KsiazkiItems
        {
            get
            {
                return new KsiazkaB(bibliotekaEntites).GetKsiazkiKeyAndValueItems();
            }
        }

        #endregion

        #region Helpers
        public override void Save()
        {
            bibliotekaEntites.Rezerwacje.Add(item);//dodaje wypozyczenie do lokalnej kolekcji
            bibliotekaEntites.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion
    }
}
