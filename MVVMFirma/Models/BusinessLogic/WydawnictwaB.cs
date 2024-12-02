using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    internal class WydawnictwaB : DatabaseClass
    {
        #region Konstruktor
        public WydawnictwaB(BibliotekaEntities db)
        : base(db) { }
        #endregion

        #region Funkcje biznesowe
        //dodamy fukcje, ktora bedzie zwracała ID ksiażki oraz jej nazwy i ISBN w KeyAndValue (poniżej trzeba było kliknąć w <KeyAndValue> drugim myszkiem i wybrać quick action i pierwsza opcje, zeby naprawic błąd)
        public IQueryable<KeyAndValue> GetWydawnictwaKeyAndValueItems()
        {
            return
                (
                    from wydawnictwo in db.Wydawnictwa
                    select new KeyAndValue
                    {
                        Key = wydawnictwo.Id,
                        Value = wydawnictwo.Nazwa + ", " + wydawnictwo.Kraj,
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}