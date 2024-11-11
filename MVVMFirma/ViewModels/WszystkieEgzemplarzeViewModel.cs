using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieEgzemplarzeViewModel : WszystkieViewModel<EgzemplarzForAllView>
    {
        #region Constructor

        public WszystkieEgzemplarzeViewModel()
            : base("Egzemplarze")
        {
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<EgzemplarzForAllView>
                (
                   //tworzymy tutaj zapytanie linq
                   from egzemplarz in bibliotekaEntities.Egzemplarze //dla każdegi czytelnika z bazy danych czytelników
                   select new EgzemplarzForAllView //tworzymy nowe CzytelnikForAllView i uzupełniamy jego dane
                   {
                       IdEgzemplarza = egzemplarz.Id,
                       KsiazkiTytul = egzemplarz.Ksiazki.Tytul,
                       NumerWewnetrzny = egzemplarz.NumerWewnetrznyEgzemplarzu,
                       Stan = egzemplarz.Stan,
                   }
                );
        }
        #endregion
    }
}
