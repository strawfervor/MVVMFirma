using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    internal class AdresyB : DatabaseClass
    {
        #region Konstruktor
        public AdresyB(BibliotekaEntities db)
        : base(db) { }
        #endregion

        #region Funkcje biznesowe
        //dodamy fukcje, ktora bedzie zwracała ID ksiażki oraz jej nazwy i ISBN w KeyAndValue (poniżej trzeba było kliknąć w <KeyAndValue> drugim myszkiem i wybrać quick action i pierwsza opcje, zeby naprawic błąd)
        public IQueryable<KeyAndValue> GetAdresyKeyAndValueItems()
        {
            return
                (
                    from adres in db.Adres
                    select new KeyAndValue
                    {
                        Key = adres.Id,
                        Value = adres.Ulica + " " + adres.NumerDomu + ", " + adres.Miejscowosc,
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
