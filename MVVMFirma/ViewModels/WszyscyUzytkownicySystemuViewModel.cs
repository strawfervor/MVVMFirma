using MVVMFirma.Models.Entities;
using MVVMFirma.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszyscyUzytkownicySystemuViewModel : WszystkieViewModel<UzytkownicySystemu>
    {
        #region Constructor

        public WszyscyUzytkownicySystemuViewModel()
            : base("Użytkownicy Systemu")
        {
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<UzytkownicySystemu>
                (
                   bibliotekaEntities.UzytkownicySystemu.ToList()
                );
        }
        #endregion
    }
}
