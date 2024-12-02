using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NowyKonkursViewModel : JedenViewModel<Konkursy>
    {

        #region Konstruktor
        public NowyKonkursViewModel()
            : base("Dodaj konkurs")
        {
            item = new Konkursy();
            //ustawiamy domyslne wartosci pola daty
            DataRozpoczecia = DateTime.Now;
        }
        #endregion

        #region Properties
        //dla każdego pola na interface toworzymy properties
        public string NazwaKonkursu
        {
            get
            {
                return item.NazwaKonkursu;
            }
            set
            {
                item.NazwaKonkursu = value;
                OnPropertyChanged(() => NazwaKonkursu);
            }
        }

        public string Opis
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

        public string Status
        {
            get
            {
                return item.Status;
            }
            set
            {
                item.Status = value;
                OnPropertyChanged(() => Status);
            }
        }

        public int? IdZwyciezcy
        {
            get
            {
                return item.IdZwyciezcy;
            }
            set
            {
                item.IdZwyciezcy = value;
                OnPropertyChanged(() => IdZwyciezcy);
            }
        }

        public DateTime? DataZakonczenia
        {
            get
            {
                return item.DataZakonczenia;
            }
            set
            {
                item.DataZakonczenia = value;
                OnPropertyChanged(() => DataZakonczenia);
            }
        }

        public DateTime DataRozpoczecia
        {
            get
            {
                return item.DataRozpoczecia;
            }
            set
            {
                item.DataRozpoczecia = value;
                OnPropertyChanged(() => DataRozpoczecia);
            }
        }

        #endregion
        #region Helpers
        public override void Save()
        {
            bibliotekaEntites.Konkursy.Add(item);//dodaje usera do lokalnej kolekcji
            bibliotekaEntites.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion
    }
}
