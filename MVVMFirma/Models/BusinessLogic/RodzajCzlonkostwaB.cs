using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    internal class RodzajCzlonkostwaB : DatabaseClass
    {
        #region Konstruktor
        public RodzajCzlonkostwaB(BibliotekaEntities db)
        : base(db) { }
        #endregion

        #region Funkcje biznesowe
        //dodamy fukcje, ktora bedzie zwracała ID ksiażki oraz jej nazwy i ISBN w KeyAndValue (poniżej trzeba było kliknąć w <KeyAndValue> drugim myszkiem i wybrać quick action i pierwsza opcje, zeby naprawic błąd)
        public IQueryable<KeyAndValue> GetRodzajCzlonkostwaKeyAndValueItems()
        {
            return
                (
                    from rodzaj in db.RodzajCzlonkostwa
                    select new KeyAndValue
                    {
                        Key = rodzaj.Id,
                        Value = rodzaj.NazwaCzlonkowstwa,
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}