using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieAdresyViewModel : WszystkieViewModel<Adres>
    {
        #region Constructor

        public WszystkieAdresyViewModel()
            : base("Adresy")
        {
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Adres>
                (
                   bibliotekaEntities.Adres.ToList()
                );
        }
        #endregion
    }
}
