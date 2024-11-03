using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieTagiViewModel : WszystkieViewModel<Tagi>
    {
        #region Constructor

        public WszystkieTagiViewModel()
            : base("Tagi")
        {
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Tagi>
                (
                   bibliotekaEntities.Tagi.ToList()
                );
        }
        #endregion
    }
}
