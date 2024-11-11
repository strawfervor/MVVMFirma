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
    public class WszystkieZgloszeniaViewModel : WszystkieViewModel<ZgloszenieForAllView>
    {
        #region Constructor

        public WszystkieZgloszeniaViewModel()
            : base("Zgłoszenia")
        {
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ZgloszenieForAllView>
                (
                   //tworzymy tutaj zapytanie linq
                   from zgloszenie in bibliotekaEntities.Zgloszenia //dla każdegi czytelnika z bazy danych czytelników
                   select new ZgloszenieForAllView //tworzymy nowe CzytelnikForAllView i uzupełniamy jego dane
                   {
                       IdZgloszenia = zgloszenie.Id,
                       CzytelnikImie = zgloszenie.Czytelnicy.Imie,
                       CzytelnikNazwisko = zgloszenie.Czytelnicy.Nazwisko,
                       Opis = zgloszenie.Opis,
                       DataZgloszenia = zgloszenie.DataZgloszenia,
                   }
                );
        }
        #endregion
    }
}
