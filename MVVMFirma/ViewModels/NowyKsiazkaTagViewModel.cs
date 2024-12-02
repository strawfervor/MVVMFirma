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
    public class NowyKsiazkaTagViewModel : JedenViewModel<KsiazkiTag>
    {
        #region Konstruktor
        public NowyKsiazkaTagViewModel()
                    : base("Dodaj tag do książki")
        {
            item = new KsiazkiTag();
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

        public int? IdTagu
        {
            get
            {
                return item.IdTagu;
            }
            set
            {
                item.IdTagu = value;
                OnPropertyChanged(() => IdTagu);
            }
        }
        #endregion


        #region Właściwości dla ComboBoxów

        public IQueryable<KeyAndValue> KsiazkiItems
        {
            get
            {
                return new KsiazkaB(bibliotekaEntites).GetKsiazkiKeyAndValueItems();
            }
        }

        public IQueryable<KeyAndValue> TagiItems
        {
            get
            {
                return new TagiB(bibliotekaEntites).GetTagiKeyAndValueItems();
            }
        }

        #endregion

        #region Helpers
        public override void Save()
        {
            bibliotekaEntites.KsiazkiTag.Add(item);//dodaje wypozyczenie do lokalnej kolekcji
            bibliotekaEntites.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion
    }
}