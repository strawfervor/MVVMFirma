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
        public List<string> RaportWypozyczen(int? idKsiazki, DateTime DataOd, DateTime DataDo)
        {
            var wyniki = (
                from pozycja in db.Wypozyczenia
                where
                    pozycja.IdKsiazki == idKsiazki &&
                    (pozycja.DataWypozyczenia <= DataDo && pozycja.DataZwrotu >= DataOd)
                select new
                {
                    Imie = pozycja.Czytelnicy.Imie,
                    Nazwisko = pozycja.Czytelnicy.Nazwisko,
                    DataWypozyczenia = pozycja.DataWypozyczenia,
                    DataZwrotu = pozycja.DataZwrotu
                }
            ).ToList(); // Pobranie danych do pamięci

            return wyniki.Select(w =>
                $"{w.Imie} {w.Nazwisko}, Wypożyczono: {w.DataWypozyczenia:d}, Zwrot: {(w.DataZwrotu.HasValue ? w.DataZwrotu.Value.ToString("d") : "Nie zwrócono")}"
            ).ToList();
        }
        #endregion
    }
}