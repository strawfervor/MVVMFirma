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
    public class NowyEgzemplarzViewModel : JedenViewModel<Egzemplarze>
    {
        #region Konstruktor
        public NowyEgzemplarzViewModel()
                    : base("Dodaj egzemplarz")
        {
            item = new Egzemplarze();
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

        public String NumerWewnetrznyEgzemplarzu
        {
            get
            {
                return item.NumerWewnetrznyEgzemplarzu;
            }
            set
            {
                item.NumerWewnetrznyEgzemplarzu = value;
                OnPropertyChanged(() => NumerWewnetrznyEgzemplarzu);
            }
        }

        public String Stan
        {
            get
            {
                return item.Stan;
            }
            set
            {
                item.Stan = value;
                OnPropertyChanged(() => Stan);
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

        #endregion

        #region Helpers
        public override void Save()
        {
            bibliotekaEntites.Egzemplarze.Add(item);//dodaje wypozyczenie do lokalnej kolekcji
            bibliotekaEntites.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion
    }
}
