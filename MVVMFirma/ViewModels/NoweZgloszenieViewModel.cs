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
    public class NoweZgloszenieViewModel : JedenViewModel<Zgloszenia>
    {
        #region Konstruktor
        public NoweZgloszenieViewModel()
                    : base("Dodaj karę")
        {
            item = new Zgloszenia();
            DataZgloszenia = DateTime.Now;
        }
        #endregion

        #region Pola
        //dla każdego pola na interfejsie tworzymy dodajemy properties

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

        public DateTime? DataZgloszenia
        {
            get
            {
                return item.DataZgloszenia;
            }
            set
            {
                item.DataZgloszenia = value;
                OnPropertyChanged(() => DataZgloszenia);
            }
        }

        public String Opis
        {
            get
            {
                return item.Opis;
            }
            set
            {
                item.Opis = value;
                OnPropertyChanged(() => Opis);
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

        #endregion

        #region Helpers
        public override void Save()
        {
            bibliotekaEntites.Zgloszenia.Add(item);//dodaje wypozyczenie do lokalnej kolekcji
            bibliotekaEntites.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion
    }
}