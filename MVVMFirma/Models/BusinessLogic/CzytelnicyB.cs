using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class CzytelnicyB : DatabaseClass
    {
        #region Konstruktor
        public CzytelnicyB(BibliotekaEntities db)
        : base(db) { }
        #endregion

        #region Funkcje biznesowe
        //dodamy fukcje, ktora bedzie zwracała ID ksiażki oraz jej nazwy i ISBN w KeyAndValue (poniżej trzeba było kliknąć w <KeyAndValue> drugim myszkiem i wybrać quick action i pierwsza opcje, zeby naprawic błąd)
        public IQueryable<KeyAndValue> GetCzytelnicyKeyAndValueItems()
        {
            return
                (
                    from czytelnik in db.Czytelnicy
                    select new KeyAndValue
                    {
                        Key = czytelnik.Id,
                        Value = czytelnik.Imie + " " + czytelnik.Nazwisko,
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
