using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NowaKaraViewModel: JedenViewModel<Kary>, INotifyDataErrorInfo
    {
        #region Konstruktor
        public NowaKaraViewModel()
                    : base("Dodaj karę")
        {
            item = new Kary();
            DataNaliczenia = DateTime.Now;

            //Wymuszenie walidacji, należy też dodać funkcję ValidateAllProperties

            ValidateAllProperties();
        }
        #endregion

        #region Pola
        //dla każdego pola na interfejsie tworzymy dodajemy properties

        public int? IdCzytelnika
        {
            get
            {
                return item.IdCzytelnika;
            }
            set
            {
                ClearErrors(nameof(IdCzytelnika));
                item.IdCzytelnika = value;

                if (IdCzytelnika == null)
                {
                    AddError(nameof(IdCzytelnika), "Proszę wybrać czytelnika");
                }

                OnPropertyChanged(() => IdCzytelnika);
            }
        }

        public DateTime? DataNaliczenia
        {
            get
            {
                return item.DataNaliczenia;
            }
            set
            {
                item.DataNaliczenia = value;
                OnPropertyChanged(() => DataNaliczenia);
            }
        }

        public String Opis
        {
            get
            {
                return item.Opis;
            }
            set
            {
                ClearErrors(nameof(Opis));

                if (string.IsNullOrEmpty(Opis))//musi byc nizej, bo dopiero teraz dostajemy pole
                {
                    AddError(nameof(Opis), "Pole Opis nie może być puste");
                }

                item.Opis = value;
                OnPropertyChanged(() => Opis);
            }
        }

        public decimal? Kwota
        {
            get
            {
                return item.Kwota;
            }
            set
            {
                ClearErrors(nameof(Kwota));

                if (Kwota <= 0)//dodawanie błędu to jest
                {
                    AddError(nameof(Kwota), "Kwota musi być większa od zera");
                }

                item.Kwota = value;
                OnPropertyChanged(() => Kwota);
            }
        }
        #endregion


        #region Właściwości dla ComboBoxów

        public IQueryable<KeyAndValue> CzytelnicyItems
        {
            get
            {
                return new CzytelnicyB(bibliotekaEntites).GetCzytelnicyKeyAndValueItems();
            }
        }



        #endregion

        #region Helpers
        public override void Save()
        {
            bibliotekaEntites.Kary.Add(item);//dodaje wypozyczenie do lokalnej kolekcji
            bibliotekaEntites.SaveChanges();//zapisuje zmiany do bazy danych
        }
        #endregion

        #region Errors

        //errory

        //tworzymy kolekcje:
        private readonly Dictionary<string, List<string>> _validationMessages = new Dictionary<string, List<string>>();

        public bool HasErrors => _validationMessages.Any(); //zmieniamy tutaj na ....Any()

        public new bool IsEnabledSaveButton => !HasErrors;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            //implementujemy nbajpier kolekcje, ktora jest pod koemntem //tworzymy kolekcje nazwa jesj = _validationMessages

            if (_validationMessages.ContainsKey(propertyName))
            {
                return _validationMessages[propertyName];//zwracamy dla danego property błąd
            }

            return null;
        }

        private void AddError(string propertyName, string validationMessage) //funkcja w seterze do dodawania errorow do kolekcji
        {
            if (!_validationMessages.ContainsKey(propertyName))
            {
                _validationMessages[propertyName] = new List<string>();
            }

            _validationMessages[propertyName].Add(validationMessage);

            OnErrorsChanged(propertyName);
        }

        private void ClearErrors(string propertyName)
        {
            if (_validationMessages.ContainsKey(propertyName))
            {
                _validationMessages.Remove(propertyName);
            }

            OnErrorsChanged(propertyName);
        }

        public void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            OnPropertyChanged(() => IsEnabledSaveButton);
        }

        //na końcu validacje implementujemy w setterach set

        //wymuszenie walidacji na początku
        private void ValidateAllProperties()
        {
            AddError(nameof(IdCzytelnika), "Proszę wybrać czytelnika");
            AddError(nameof(Opis), "Pole Opis nie może być puste");
            AddError(nameof(Kwota), "Kwota musi być większa od zera");
        }

        #endregion

    }

}
