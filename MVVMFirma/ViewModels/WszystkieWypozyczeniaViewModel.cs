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
    public class WszystkieWypozyczeniaViewModel : WszystkieViewModel<WypozyczeniaForAllView>
    {
        #region Constructor

        public WszystkieWypozyczeniaViewModel()
            : base("Wypożyczenia")
        {
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<WypozyczeniaForAllView>
                (
                   //tworzymy tutaj zapytanie linq
                   from wypozyczenia in bibliotekaEntities.Wypozyczenia //dla każdegi czytelnika z bazy danych czytelników
                   select new WypozyczeniaForAllView //tworzymy nowe CzytelnikForAllView i uzupełniamy jego dane
                   {
                       IdWypozyczenia = wypozyczenia.Id,
                       CzytelnikImie = wypozyczenia.Czytelnicy.Imie,
                       CzytelnikNazwisko = wypozyczenia.Czytelnicy.Nazwisko,
                       KsiazkiTytul = wypozyczenia.Ksiazki.Tytul,
                       DataWypozyczenia = wypozyczenia.DataWypozyczenia,
                       DataZwrotu = wypozyczenia.DataZwrotu,
                   }
                );
        }
        #endregion
    }
}