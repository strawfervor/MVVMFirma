using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MVVMFirma.ViewModels
{
    public class KartaBibliotecznaViewModel : JedenViewModel<Czytelnicy>
    {
        #region DB
        BibliotekaEntities db;

        #endregion
        #region Konstruktor
        public KartaBibliotecznaViewModel()
            :base("Karta biblioteczna")
        {
            db = new BibliotekaEntities();
            item = new Czytelnicy();
        }
        #endregion

        #region Pola

        private int? _IdCzytelnika;
        public int? IdCzytelnika
        {
            get { return _IdCzytelnika; }
            set
            {
                if (_IdCzytelnika != value)
                {
                    _IdCzytelnika = value;
                    OnPropertyChanged(() => IdCzytelnika);
                }

                if (value.HasValue)
                {
                    WybranoCzytelnika(value.Value);
                }
            }
        }

        private List<string> _KaryLista;
        public List<string> KaryLista
        {
            get { return _KaryLista; }
            set
            {
                if (_KaryLista != value)
                {
                    _KaryLista = value;
                    OnPropertyChanged(() => KaryLista);
                }
            }
        }

        private List<string> _ZgloszeniaLista;
        public List<string> ZgloszeniaLista
        {
            get { return _ZgloszeniaLista; }
            set
            {
                if (_ZgloszeniaLista != value)
                {
                    _ZgloszeniaLista = value;
                    OnPropertyChanged(() => ZgloszeniaLista);
                }
            }
        }

        private List<string> _WypozyczeniaLista;
        public List<string> WypozyczeniaLista
        {
            get { return _WypozyczeniaLista; }
            set
            {
                if (_WypozyczeniaLista != value)
                {
                    _WypozyczeniaLista = value;
                    OnPropertyChanged(() => WypozyczeniaLista);
                }
            }
        }

        private string _AdresCzytelnika;
        public string AdresCzytelnika
        {
            get { return _AdresCzytelnika; }
            set
            {
                if (_AdresCzytelnika != value)
                {
                    _AdresCzytelnika = value;
                    OnPropertyChanged(() => AdresCzytelnika);
                }
            }
        }

        private string _RodzajCzlonkowstwaCzytelnika;
        public string RodzajCzlonkowstwaCzytelnika
        {
            get { return _RodzajCzlonkowstwaCzytelnika; }
            set
            {
                if (_RodzajCzlonkowstwaCzytelnika != value)
                {
                    _RodzajCzlonkowstwaCzytelnika = value;
                    OnPropertyChanged(() => RodzajCzlonkowstwaCzytelnika);
                }
            }
        }

        private string _IloscWypozyczonychKsiazekCzytelnika;
        public string IloscWypozyczonychKsiazekCzytelnika
        {
            get { return _IloscWypozyczonychKsiazekCzytelnika; }
            set
            {
                if (_IloscWypozyczonychKsiazekCzytelnika != value)
                {
                    _IloscWypozyczonychKsiazekCzytelnika = value;
                    OnPropertyChanged(() => IloscWypozyczonychKsiazekCzytelnika);
                }
            }
        }



        #endregion



        #region Funkcje Biznesowe
        public List<string> PokazZgloszenia(int? IdCzytelnika)
        {
            // Tworzymy zapytanie na podstawie dostępnych filtrów
            var wyniki = (
                from Zgloszenia in db.Zgloszenia
                where
                    // Filtrujemy po roku wydania, jeśli jest podany
                    (!IdCzytelnika.HasValue || Zgloszenia.IdCzytelnika == IdCzytelnika)
                select new
                {
                    DataZgloszenia = Zgloszenia.DataZgloszenia,
                    Opis = Zgloszenia.Opis,
                }
            ).ToList(); // Pobranie danych do pamięci

            // Zwracamy listę sformatowanych stringów
            return wyniki.Select(w =>
                $"Data zgłoszenia: {w.DataZgloszenia}, Treść zgłoszenia: {w.Opis}"
            ).ToList();
        }

        public List<string> PokazKary(int? IdCzytelnika)
        {
            // Tworzymy zapytanie na podstawie dostępnych filtrów
            var wyniki = (
                from Kary in db.Kary
                where
                    // Filtrujemy po roku wydania, jeśli jest podany
                    (!IdCzytelnika.HasValue || Kary.IdCzytelnika == IdCzytelnika)
                select new
                {
                    DataNaliczenia = Kary.DataNaliczenia,
                    Opis = Kary.Opis,
                    Kwota = Kary.Kwota
                }
            ).ToList(); // Pobranie danych do pamięci

            // Zwracamy listę sformatowanych stringów
            return wyniki.Select(w =>
                $"Data naliczenia: {w.DataNaliczenia}, Kwota kary: {w.Kwota}, Opis kary: {w.Opis}"
            ).ToList();
        }

        public List<string> PokazWypozyczenia(int? IdCzytelnika)
        {
            // Tworzymy zapytanie na podstawie dostępnych filtrów
            var wyniki = (
                from Wypozyczenia in db.Wypozyczenia
                where
                    // Filtrujemy po roku wydania, jeśli jest podany
                    (!IdCzytelnika.HasValue || Wypozyczenia.IdCzytelnika == IdCzytelnika)
                select new
                {
                    Tytul = Wypozyczenia.Ksiazki.Tytul,
                    DataWypozyczenia = Wypozyczenia.DataWypozyczenia,
                    DataZwrotu = Wypozyczenia.DataZwrotu,
                }
            ).ToList(); // Pobranie danych do pamięci

            // Zwracamy listę sformatowanych stringów
            return wyniki.Select(w =>
                $"Tytuł książki: {w.Tytul}, Data wypożyczenia: {w.DataWypozyczenia}, Data zwrotu: {w.DataZwrotu}"
            ).ToList();
        }
        #endregion



        #region Właściwości dla ComboBoxów

        public IQueryable<KeyAndValue> CzytelnicyItems
        {
            get
            {
                return new CzytelnicyB(db).GetCzytelnicyKeyAndValueItems();
            }
        }



        #endregion



        #region Helpers

        public override void Save()
        {
            Console.WriteLine("save");
        }


        private void WybranoCzytelnika(int idCzytelnika)
        {
            // Pobierz dane dla wybranego czytelnika
            ZgloszeniaLista = PokazZgloszenia(idCzytelnika);
            KaryLista = PokazKary(idCzytelnika);
            WypozyczeniaLista = PokazWypozyczenia(idCzytelnika);
            AdresCzytelnika = "ul. " + db.Czytelnicy.Find(idCzytelnika).Adres.Ulica + " " + db.Czytelnicy.Find(idCzytelnika).Adres.NumerDomu  + ", " + db.Czytelnicy.Find(idCzytelnika).Adres.Miejscowosc;
            RodzajCzlonkowstwaCzytelnika = db.Czytelnicy.Find(idCzytelnika).RodzajCzlonkostwa.NazwaCzlonkowstwa;
            IloscWypozyczonychKsiazekCzytelnika = db.Wypozyczenia.Where(x => x.IdCzytelnika == idCzytelnika).Count() + " / " + db.Czytelnicy.Find(idCzytelnika).RodzajCzlonkostwa.MaxKsiazekWypozyczonych;
        }

        #endregion
    }
}
