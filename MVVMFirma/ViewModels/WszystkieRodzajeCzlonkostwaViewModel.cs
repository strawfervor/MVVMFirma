using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieRodzajeCzlonkostwaViewModel : WszystkieViewModel<RodzajCzlonkostwa>
    {
        #region Constructor

        public WszystkieRodzajeCzlonkostwaViewModel()
            : base("RodzajeCzlonkostwa")
        {
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<RodzajCzlonkostwa>
                (
                   bibliotekaEntities.RodzajCzlonkostwa.ToList()
                );
        }
        #endregion
    }
}
