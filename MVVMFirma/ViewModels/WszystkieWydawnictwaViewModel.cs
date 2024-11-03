using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieWydawnictwaViewModel : WszystkieViewModel<Wydawnictwa>
    {
        #region Constructor

        public WszystkieWydawnictwaViewModel()
            : base("Wydawnictwa")
        {
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Wydawnictwa>
                (
                   bibliotekaEntities.Wydawnictwa.ToList()
                );
        }
        #endregion
    }
}
