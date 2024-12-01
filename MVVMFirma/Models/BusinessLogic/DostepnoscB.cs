using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMFirma.Models.BusinessLogic
{
    public class DostepnoscB : DatabaseClass
    {
        #region Konstruktor
        public DostepnoscB(BibliotekaEntities db)
        :base(db)
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
        public List<string> ListaDostepnych(int idKsiazki)
        {
            return (
                from pozycja in db.Egzemplarze
                where
                    pozycja.IdKsiazki == idKsiazki && // wybieramy IdKsiążki
                    pozycja.Stan == "Dostępny"       // sprawdzamy czy jest dostępna
                select
                    pozycja.NumerWewnetrznyEgzemplarzu
            ).ToList();
        }
        #endregion
    }
}
