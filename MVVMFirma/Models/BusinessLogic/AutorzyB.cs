using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class AutorzyB : DatabaseClass
    {
        #region Konstruktor
        public AutorzyB(BibliotekaEntities db)
        : base(db) { }
        #endregion

        #region Funkcje biznesowe
        //dodamy fukcje, ktora bedzie zwracała ID ksiażki oraz jej nazwy i ISBN w KeyAndValue (poniżej trzeba było kliknąć w <KeyAndValue> drugim myszkiem i wybrać quick action i pierwsza opcje, zeby naprawic błąd)
        public IQueryable<KeyAndValue> GetAutorzyKeyAndValueItems()
        {
            return
                (
                    from autor in db.Autorzy
                    select new KeyAndValue
                    {
                        Key = autor.Id,
                        Value = autor.Imie + " " + autor.Nazwisko,
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}