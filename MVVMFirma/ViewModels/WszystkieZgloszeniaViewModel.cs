﻿using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieZgloszeniaViewModel : WszystkieViewModel<Zgloszenia>
    {
        #region Constructor

        public WszystkieZgloszeniaViewModel()
            : base("Zgłoszenia")
        {
        }

        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Zgloszenia>
                (
                   bibliotekaEntities.Zgloszenia.ToList()
                );
        }
        #endregion
    }
}
