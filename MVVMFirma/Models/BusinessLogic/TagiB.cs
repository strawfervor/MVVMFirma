using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    internal class TagiB : DatabaseClass
    {
        #region Konstruktor
        public TagiB(BibliotekaEntities db)
        : base(db) { }
        #endregion

        #region Funkcje biznesowe
        //dodamy fukcje, ktora bedzie zwracała ID ksiażki oraz jej nazwy i ISBN w KeyAndValue (poniżej trzeba było kliknąć w <KeyAndValue> drugim myszkiem i wybrać quick action i pierwsza opcje, zeby naprawic błąd)
        public IQueryable<KeyAndValue> GetTagiKeyAndValueItems()
        {
            return
                (
                    from tag in db.Tagi
                    select new KeyAndValue
                    {
                        Key = tag.Id,
                        Value = tag.TrescTagu,
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
