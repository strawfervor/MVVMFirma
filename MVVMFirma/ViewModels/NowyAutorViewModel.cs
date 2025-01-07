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
    public class NowyAutorViewModel : JedenViewModel<Autorzy>, INotifyDataErrorInfo
    {
        #region Konstruktor
        public NowyAutorViewModel()
                    : base("Dodaj autora")
        {
            item = new Autorzy();
            ValidateAllProperties();

        }
        #endregion

        #region Pola
        //dla każdego pola na interfejsie tworzymy dodajemy properties

        public String Imie
        {
            get
            {
                return item.Imie;
            }
            set
            {
                ClearErrors(nameof(Imie));
                item.Imie = value;

                if (String.IsNullOrEmpty(Imie))
                {
                    AddError(nameof(Imie), "Pole imie nie może być puste");
                } else if (!char.IsUpper(Imie[0]))
                {
                    AddError(nameof(Imie), "Pole imie musi zaczynać się od Wielkiej litery");
                }

                OnPropertyChanged(() => Imie);
            }
        }

        public DateTime? DataUrodzenia
        {
            get
            {
                return item.DataUrodzenia;
            }
            set
            {
                ClearErrors(nameof(DataUrodzenia));
                item.DataUrodzenia = value;

                if (DataUrodzenia > DateTime.Now)
                {
                    AddError(nameof(DataUrodzenia), "Data nie może być w przyszłości");
                }

                OnPropertyChanged(() => DataUrodzenia);
            }
        }

        public String Nazwisko
        {
            get
            {
                return item.Nazwisko;
            }
            set
            {
                ClearErrors(nameof(Nazwisko));
                item.Nazwisko = value;

                if (String.IsNullOrEmpty(Nazwisko))
                {
                    AddError(nameof(Nazwisko), "Pole nazwisko nie może być puste");
                } else if (!char.IsUpper(Nazwisko[0]))
                {
                    AddError(nameof(Nazwisko), "Pole imie musi zaczynać się od Wielkiej litery");
                }

                OnPropertyChanged(() => Nazwisko);
            }
        }

        public String KrajPochodzenia
        {
            get
            {
                return item.KrajPochodzenia;
            }
            set
            {
                item.KrajPochodzenia = value;
                OnPropertyChanged(() => KrajPochodzenia);
            }
        }
        #endregion


        #region Właściwości dla ComboBoxów

        #endregion

        #region Helpers
        public override void Save()
        {
            bibliotekaEntites.Autorzy.Add(item);//dodaje wypozyczenie do lokalnej kolekcji
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
            AddError(nameof(Imie), "Pole imie nie może być puste");
            AddError(nameof(Nazwisko), "Pole nazwisko nie może być puste");
        }

        #endregion
    }
}