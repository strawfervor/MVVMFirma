using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieWypozyczeniaViewModel : WszystkieViewModel<Wypozyczenia>
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
            List = new ObservableCollection<Wypozyczenia>
                (
                   bibliotekaEntities.Wypozyczenia.ToList()
                );
        }
        #endregion
    }
}