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
    public class NowyEgzemplarzViewModel : JedenViewModel<Egzemplarze>, INotifyDataErrorInfo
    {
        #region Konstruktor
        public NowyEgzemplarzViewModel()
                    : base("Dodaj egzemplarz")
        {
            item = new Egzemplarze();
            ValidateAllProperties();
        }
        #endregion

        #region Pola
        //dla każdego pola na interfejsie tworzymy dodajemy properties

        public int? IdKsiazki
        {
            get
            {
                return item.IdKsiazki;
            }
            set
            {
                ClearErrors(nameof(IdKsiazki));
                item.IdKsiazki = value;

                if (IdKsiazki == null)
                {
                    AddError(nameof(IdKsiazki), "Proszę wybrać czytelnika");
                }

                OnPropertyChanged(() => IdKsiazki);
            }
        }

        public String NumerWewnetrznyEgzemplarzu
        {
            get
            {
                return item.NumerWewnetrznyEgzemplarzu;
            }
            set
            {
                ClearErrors(nameof(NumerWewnetrznyEgzemplarzu));
                item.NumerWewnetrznyEgzemplarzu = value;

                if (String.IsNullOrEmpty(NumerWewnetrznyEgzemplarzu))
                {
                    AddError(nameof(NumerWewnetrznyEgzemplarzu), "Pole nie może być puste");
                }

                OnPropertyChanged(() => NumerWewnetrznyEgzemplarzu);
            }
        }

        public String Stan
        {
            get
            {
                return item.Stan;
            }
            set
            {
                ClearErrors(nameof(Stan));
                item.Stan = value;

                if (String.IsNullOrEmpty(Stan))
                {
                    AddError(nameof(Stan), "Pole nie może być puste");
                }

                OnPropertyChanged(() => Stan);
            }
        }

        #endregion


        #region Właściwości dla ComboBoxów

        public IQueryable<KeyAndValue> KsiazkiItems
        {
            get
            {
                return new KsiazkaB(bibliotekaEntites).GetKsiazkiKeyAndValueItems();
            }
        }

        #endregion

        #region Helpers
        public override void Save()
        {
            bibliotekaEntites.Egzemplarze.Add(item);//dodaje wypozyczenie do lokalnej kolekcji
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
            AddError(nameof(IdKsiazki), "Proszę wybrać książkę");
            AddError(nameof(Stan), "Pole Stan nie może być puste");
            AddError(nameof(NumerWewnetrznyEgzemplarzu), "Numer wewnętrzny nie może być pusty");
        }

        #endregion

    }
}
