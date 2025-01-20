using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMFirma.Models.BusinessLogic
{
    public class DopasujB : DatabaseClass
    {
        #region Konstruktor
        public DopasujB(BibliotekaEntities db)
        : base(db)
        {

        }
        #endregion

        #region Funkcje Biznesowe
        public List<string> WyszukajKsiazki(int? rok, int? idAutora, int? idTagu)
        {
            // Tworzymy zapytanie na podstawie dostępnych filtrów
            var wyniki = (
                from ksiazka in db.KsiazkiTag
                where
                    // Filtrujemy po roku wydania, jeśli jest podany
                    (!rok.HasValue || ksiazka.Ksiazki.RokWydania >= rok) &&
                    // Filtrujemy po autorze, jeśli jest podany
                    (!idAutora.HasValue || ksiazka.Ksiazki.IdAutora == idAutora) &&
                    // Filtrujemy po tagu, jeśli jest podany
                    (!idTagu.HasValue || ksiazka.IdTagu == idTagu)
                select new
                {
                    TytulK = ksiazka.Ksiazki.Tytul,
                    Autor = ksiazka.Ksiazki.Autorzy.Nazwisko,
                    DataWydania = ksiazka.Ksiazki.RokWydania,
                }
            ).Distinct().ToList(); // Pobranie danych do pamięci

            // Zwracamy listę sformatowanych stringów
            return wyniki.Select(w =>
                $"Tytuł: {w.TytulK}, Autor: {w.Autor}, Rok wydania: {w.DataWydania}"
            ).ToList();
        }

        //Dodawanie innych spraw:

        public void DodajTag(string trescTagu)
        {
            if (string.IsNullOrWhiteSpace(trescTagu))
                throw new ArgumentException("Treść tagu nie może być pusta.");

            if (db.Tagi.Any(t => t.TrescTagu == trescTagu))
                throw new InvalidOperationException("Taki tag już istnieje.");

            var nowyTag = new Tagi
            {
                TrescTagu = trescTagu
            };

            db.Tagi.Add(nowyTag);
            db.SaveChanges();
        }

        // Przypisywanie tagu do książki
        public void PrzypiszTagDoKsiazki(int idKsiazki, int idTagu)
        {
            if (!db.Ksiazki.Any(k => k.Id == idKsiazki))
                throw new ArgumentException("Podana książka nie istnieje.");

            if (!db.Tagi.Any(t => t.Id == idTagu))
                throw new ArgumentException("Podany tag nie istnieje.");

            if (db.KsiazkiTag.Any(kt => kt.IdKsiazki == idKsiazki && kt.IdTagu == idTagu))
                throw new InvalidOperationException("Tag jest już przypisany do tej książki.");

            var nowyKsiazkiTag = new KsiazkiTag
            {
                IdKsiazki = idKsiazki,
                IdTagu = idTagu
            };

            db.KsiazkiTag.Add(nowyKsiazkiTag);
            db.SaveChanges();
        }
        #endregion
    }
}
