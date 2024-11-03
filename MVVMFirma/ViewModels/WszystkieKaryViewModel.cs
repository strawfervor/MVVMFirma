using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieKaryViewModel : WszystkieViewModel<Kary>
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
            List = new ObservableCollection<Kary>
                (
                   bibliotekaEntities.Kary.ToList()
                );
        }
        #endregion
    }
}
