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
    public class NowaKsiazkaViewModel : JedenViewModel<Ksiazki>
    {
        #region Konstruktor
        public NowaKsiazkaViewModel()
                    : base("Dodaj książkę")
        {
            item = new Ksiazki();
        }
        #endregion

        #region Pola
        //dla każdego pola na interfejsie tworzymy dodajemy properties

        public String Tytul
        {
            get
            {
                return item.Tytul;
            }
            set
            {
                item.Tytul = value;
                OnPropertyChanged(() => Tytul);
            }
        }

        public int? IdAutora
        {
            get
            {
                return item.IdAutora;
            }
            set
            {
                item.IdAutora = value;
                OnPropertyChanged(() => IdAutora);
            }
        }

        public String ISBN
        {
            get
            {
                return item.ISBN;
            }
            set
            {
                item.ISBN = value;
                OnPropertyChanged(() => ISBN);
            }
        }

        public int? RokWydania
        {
            get
            {
                return item.RokWydania;
            }
            set
            {
                item.RokWydania = value;
                OnPropertyChanged(() => RokWydania);
            }
        }

        public int? IdWydawnictwa
        {
            get
            {
                return item.IdWydawnictwa;
            }
            set
            {
                item.IdWydawnictwa = value;
                OnPropertyChanged(() => IdWydawnictwa);
            }
        }

        public String Gatunek
        {
            get
            {
                return item.Gatunek;
            }
            set
            {
                item.Gatunek = value;
                OnPropertyChanged(() => Gatunek);
            }
        }

        public int? IloscEgzemplarzy
        {
            get
            {
                return item.IloscEgzemplarzy;
            }
            set
            {
                item.IloscEgzemplarzy = value;
                OnPropertyChanged(() => IloscEgzemplarzy);
            }
        }

        public int? RodzajLiteracki
        {
            get
            {
                return item.RodzajLiteracki;
            }
            set
            {
                item.RodzajLiteracki = value;
                OnPropertyChanged(() => RodzajLiteracki);
            }
        }

        #endregion


        #region Właściwości dla ComboBoxów

        public IQueryable<KeyAndValue> AutorzyItems
        {
            get
            {
                return new AutorzyB(bibliotekaEntites).GetAutorzyKeyAndValueItems();
            }
        }

        public IQueryable<KeyAndValue> WydawnictwaItems
        {
            get
            {
                return new WydawnictwaB(bibliotekaEntites).GetWydawnictwaKeyAndValueItems();
            }
        }

        public IQueryable<KeyAndValue> RodzajItems
        {
            get
            {
                return new RodzajeLiterackieB(bibliotekaEntites).GetRodzajeLiterackieKeyAndValueItems();
            }
        }

        #endregion

        #region Helpers
        public override void Save()
        {
            bibliotekaEntites.Ksiazki.Add(item);//dodaje wypozyczenie do lokalnej kolekcji
            bibliotekaEntites.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion
    }
}