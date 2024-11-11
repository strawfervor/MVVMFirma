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
    public class WszystkieKaryViewModel : WszystkieViewModel<KaraForAllView>
    {
        #region Constructor

        public WszystkieKaryViewModel()
            : base("Kary")
        {
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KaraForAllView>
                (
                   //tworzymy tutaj zapytanie linq
                   from kara in bibliotekaEntities.Kary //dla każdegi czytelnika z bazy danych czytelników
                   select new KaraForAllView //tworzymy nowe CzytelnikForAllView i uzupełniamy jego dane
                   {
                       IdKary = kara.Id,
                       CzytelnikImie = kara.Czytelnicy.Imie,
                       CzytelnikNazwisko = kara.Czytelnicy.Nazwisko,
                       Opis = kara.Opis,
                       DataNaliczenia = kara.DataNaliczenia,
                       Kwota = kara.Kwota,
                   }
                );
        }
        #endregion
    }
}
