using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//funkcja dostarcza dane komboboxowi
namespace MVVMFirma.Models.BusinessLogic
{
    internal class KsiazkaB:DatabaseClass
    {
        #region Konstruktor
            public KsiazkaB(BibliotekaEntities db) 
            :base(db) { }
        #endregion

        #region Funkcje biznesowe
            //dodamy fukcje, ktora bedzie zwracała ID ksiażki oraz jej nazwy i ISBN w KeyAndValue (poniżej trzeba było kliknąć w <KeyAndValue> drugim myszkiem i wybrać quick action i pierwsza opcje, zeby naprawic błąd)
            public IQueryable<KeyAndValue> GetKsiazkiKeyAndValueItems()
        {
            return
                (
                    from ksiazka in db.Ksiazki
                    select new KeyAndValue
                    {
                        Key = ksiazka.Id,
                        Value = ksiazka.Tytul + ", autor: " + ksiazka.Autorzy.Nazwisko,
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
