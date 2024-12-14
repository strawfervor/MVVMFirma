using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class RaportWypozyczenB : DatabaseClass
    {
        #region Konstruktor
        public RaportWypozyczenB(BibliotekaEntities db)
        : base(db)
        {

        }
        #endregion

        #region Funkcje Biznesowe
        //ta funkcja wyświetla wypożyczenia danej ksiązki
        //public String LiczbaDostepnych(int idKsiazki)
        //{
        //    return
        //        (
        //            from pozycja in db.Egzemplarze
        //            where
        //                pozycja.IdKsiazki == idKsiazki && //wybieramy IdKsiązki
        //                pozycja.Stan == "Dostępny" //sprawdzamy czy jest dostępna
        //            select
        //                pozycja.NumerWewnetrznyEgzemplarzu
        //        ).FirstOrDefault()?.ToString();
        //}
        public List<string> RaportWypozyczen(int idKsiazki, DateTime DataOd, DateTime DataDo)
        {
            return (
                from pozycja in db.Wypozyczenia
                where
                    pozycja.IdKsiazki == idKsiazki &&
                    (
                        (pozycja.DataWypozyczenia <= DataDo && pozycja.DataZwrotu >= DataOd)
                    )
                select 
                    pozycja.Czytelnicy.Nazwisko
            ).ToList();
        }
        #endregion
    }
}