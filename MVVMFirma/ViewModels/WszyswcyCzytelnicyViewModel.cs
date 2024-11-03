using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszyswcyCzytelnicyViewModel : WszystkieViewModel<Czytelnicy>
    {
        #region Constructor

        public WszyswcyCzytelnicyViewModel()
            : base("Czytelnicy")
        {
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Czytelnicy>
                (
                   bibliotekaEntities.Czytelnicy.ToList()
                );
        }
        #endregion
    }
}