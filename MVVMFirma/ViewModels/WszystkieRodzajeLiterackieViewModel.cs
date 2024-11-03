﻿using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieRodzajeLiterackieViewModel : WszystkieViewModel<RodzajLiteracki>
    {
        #region Constructor

        public WszystkieRodzajeLiterackieViewModel()
            : base("Rodzaje Literackie")
        {
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<RodzajLiteracki>
                (
                   bibliotekaEntities.RodzajLiteracki.ToList()
                );
        }
        #endregion
    }
}
