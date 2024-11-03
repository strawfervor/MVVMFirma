using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieRezerwacjeViewModel : WszystkieViewModel<Rezerwacje>
    {
        #region Constructor

        public WszystkieRezerwacjeViewModel()
            : base("Rezerwacje")
        {
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Rezerwacje>
                (
                   bibliotekaEntities.Rezerwacje.ToList()
                );
        }
        #endregion
    }
}
