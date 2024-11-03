using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieKsiazkaTagViewModel : WszystkieViewModel<KsiazkiTag>
    {
        #region Constructor

        public WszystkieKsiazkaTagViewModel()
            : base("Książka-Tag (wszystkie)")
        {
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KsiazkiTag>
                (
                   bibliotekaEntities.KsiazkiTag.ToList()
                );
        }
        #endregion
    }
}
