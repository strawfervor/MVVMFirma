using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieKsiazkiViewModel : WszystkieViewModel<Ksiazki>
    {
        #region Constructor

        public WszystkieKsiazkiViewModel()
            : base("Użytkownicy Systemu")
        {
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Ksiazki>
                (
                   bibliotekaEntities.Ksiazki.ToList()
                );
        }
        #endregion
    }
}