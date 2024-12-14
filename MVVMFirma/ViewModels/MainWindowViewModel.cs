using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Helper;
using System.Diagnostics;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using GalaSoft.MvvmLight.Messaging;

namespace MVVMFirma.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion

        #region Commands
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()
        {
            //to jest messenger, który oczekuje na stringa i jak go złapie to wywołuje metodę open, która jest zdefiniowana w regionie prywatnych helpersów.
            Messenger.Default.Register<string>(this, open);
            return new List<CommandViewModel>
            {
                //Wszystkie*ViewModel
                new CommandViewModel(
                    "███ Pokaż: ███",
                    new BaseCommand(() => this.ShowAll(new WszyscyAutorzyViewModel()))),
                new CommandViewModel(
                    "Adresy",
                    new BaseCommand(() => this.ShowAll(new WszystkieAdresyViewModel()))),
                new CommandViewModel(
                    "Autorzy",
                    new BaseCommand(() => this.ShowAll(new WszyscyAutorzyViewModel()))),
                new CommandViewModel(
                    "Czytelnicy",
                    new BaseCommand(() => this.ShowAll(new WszyswcyCzytelnicyViewModel()))),
                new CommandViewModel(
                    "Egzemplarze",
                    new BaseCommand(() => this.ShowAll(new WszystkieEgzemplarzeViewModel()))),
                new CommandViewModel(
                    "Kary",
                    new BaseCommand(() => this.ShowAll(new WszystkieKaryViewModel()))),
                new CommandViewModel(
                    "Konkursy",
                    new BaseCommand(() => this.ShowAll(new WszystkieKonkursyViewModel()))),
                new CommandViewModel(
                    "Książka-Tag (wszystkie)",
                    new BaseCommand(() => this.ShowAll(new WszystkieKsiazkaTagViewModel()))),
                new CommandViewModel(
                    "Książki",
                    new BaseCommand(() => this.ShowAll(new WszystkieKsiazkiViewModel()))),
                new CommandViewModel(
                    "Rezerwacje",
                    new BaseCommand(() => this.ShowAll(new WszystkieRezerwacjeViewModel()))),
                new CommandViewModel(
                    "Rodzaje Członkostwa",
                    new BaseCommand(() => this.ShowAll(new WszystkieRodzajeCzlonkostwaViewModel()))),
                new CommandViewModel(
                    "Rodzaje Literackie",
                    new BaseCommand(() => this.ShowAll(new WszystkieRodzajeLiterackieViewModel()))),
                new CommandViewModel(
                    "Tagi",
                    new BaseCommand(() => this.ShowAll(new WszystkieTagiViewModel()))),
                new CommandViewModel(
                    "Użytkownicy Systemu",
                    new BaseCommand(() => this.ShowAll(new WszyscyUzytkownicySystemuViewModel()))),
                new CommandViewModel(
                    "Wydawnictwa",
                    new BaseCommand(() => this.ShowAll(new WszystkieWydawnictwaViewModel()))),
                new CommandViewModel(
                    "Wypożyczenia",
                    new BaseCommand(() => this.ShowAll(new WszystkieWypozyczeniaViewModel()))),
                new CommandViewModel(
                    "Zgłoszenia",
                    new BaseCommand(() => this.ShowAll(new WszystkieZgloszeniaViewModel()))),


                //poniżej idą Nowe*ViewModel
                new CommandViewModel(
                    "███ Dodaj: ███",
                    new BaseCommand(() => this.CreateView(new NowaKaraViewModel()))),
                new CommandViewModel(
                    "Adres",
                    new BaseCommand(() => this.CreateView(new NowyAdresViewModel()))),
                new CommandViewModel(
                    "Autor",
                    new BaseCommand(() => this.CreateView(new NowyAutorViewModel()))),
                new CommandViewModel(
                    "Czytelnik",
                    new BaseCommand(() => this.CreateView(new NowyCzytelnikViewModel()))),
                new CommandViewModel(
                    "Egzemplarz",
                    new BaseCommand(() => this.CreateView(new NowyEgzemplarzViewModel()))),
                new CommandViewModel(
                    "Kara",
                    new BaseCommand(() => this.CreateView(new NowaKaraViewModel()))),
                new CommandViewModel(
                    "Konkurs",
                    new BaseCommand(() => this.CreateView(new NowyKonkursViewModel()))),
                new CommandViewModel(
                    "Książka",
                    new BaseCommand(() => this.CreateView(new NowaKsiazkaViewModel()))),
                new CommandViewModel(
                    "Książka-Tag",
                    new BaseCommand(() => this.CreateView(new NowyKsiazkaTagViewModel()))),
                new CommandViewModel(
                    "Rezerwacja",
                    new BaseCommand(() => this.CreateView(new NowaRezerwacjaViewModel()))),
                new CommandViewModel(
                    "Rodzaj Członkostwa",
                    new BaseCommand(() => this.CreateView(new NowyRodzajCzlonkostwaViewModel()))),
                new CommandViewModel(
                    "Rodzaj litercki",
                    new BaseCommand(() => this.CreateView(new NowyRodzajLiterackiViewModel()))),
                new CommandViewModel(
                    "Tag",
                    new BaseCommand(() => this.CreateView(new NowyTagViewModel()))),
                new CommandViewModel(
                    "Użytkownik Systemu",
                    new BaseCommand(() => this.CreateView(new NowyUzytkownikSystemuViewModel()))),
                new CommandViewModel(
                    "Wydawnictwo",
                    new BaseCommand(() => this.CreateView(new NoweWydawnictwoViewModel()))),
                new CommandViewModel(
                    "Wypożyczenie",
                    new BaseCommand(() => this.CreateView(new NoweWypozyczenieViewModel()))),
                new CommandViewModel(
                    "Zgłoszenie",
                    new BaseCommand(() => this.CreateView(new NoweZgloszenieViewModel()))),

                //poniżej idą pozostałe sytuacje:
                new CommandViewModel(
                    "███ Inne: ███",
                    new BaseCommand(() => this.ShowAll(new RaportWypozyczenViewModel()))),
                new CommandViewModel(
                    "Dostępność egzemplarzy",
                    new BaseCommand(() => this.ShowAll(new DostepnoscViewModel()))),
                new CommandViewModel(
                    "Raport Wypożyczeń",
                    new BaseCommand(() => this.ShowAll(new RaportWypozyczenViewModel()))),
                new CommandViewModel(
                    "Wyszkiwanie książki",
                    new BaseCommand(() => this.ShowAll(new DopasujViewModel()))),
            };
        }
        #endregion

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces

        #region Private Helpers

        private void CreateView(WorkspaceViewModel nowy) //tworzy nowa zakładkę i ją aktywuje
        {
            this.Workspaces.Add(nowy);//to jest dodanie zakładki do kolekcji zakłądek
            this.SetActiveWorkspace(nowy);//aktywowanie zakładki
        }
        //private void CreateTowar()
        //{
        //    NowyTowarViewModel workspace = new NowyTowarViewModel();
        //    this.Workspaces.Add(workspace);
        //    this.SetActiveWorkspace(workspace);
        //}
        //private void ShowAllTowar()
        //{
        //    WszystkieTowaryViewModel workspace =
        //        this.Workspaces.FirstOrDefault(vm => vm is WszystkieTowaryViewModel)
        //        as WszystkieTowaryViewModel;
        //    if (workspace == null)
        //    {
        //        workspace = new WszystkieTowaryViewModel();
        //        this.Workspaces.Add(workspace);
        //    }

        //    this.SetActiveWorkspace(workspace);
        //}

        private void ShowAll(WorkspaceViewModel workspace)//tworzenie nowych zakladek WszystkieCostam...
        {
            var existingWorkspace = this.Workspaces.FirstOrDefault(vm => vm.GetType() == workspace.GetType());//sprawdzanie czy zakładka takie typu już istnieje
            if (existingWorkspace == null)
            {
                this.Workspaces.Add(workspace);
            }
            else
            {
                workspace = existingWorkspace;
            }

            this.SetActiveWorkspace(workspace);
        }
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        private void open(string name)//name to jest wysłany komunikat messengerem
        {
            if (name == "KaryAdd")
                CreateView(new NowaKaraViewModel());
            if (name == "AdresyAdd")
                CreateView(new NowyAdresViewModel());
            if (name == "RezerwacjeAdd")
                CreateView(new NowaRezerwacjaViewModel());
            if (name == "WydawnictwaAdd")
                CreateView(new NoweWydawnictwoViewModel());
            if (name == "WypożyczeniaAdd")
                CreateView(new NoweWypozyczenieViewModel());
            if (name == "ZgłoszeniaAdd")
                CreateView(new NoweZgloszenieViewModel());
            if (name == "AutorzyAdd")
                CreateView(new NowyAutorViewModel());
            if (name == "Użytkownicy SystemuAdd")
                CreateView(new NowyUzytkownikSystemuViewModel());
            if (name == "EgzemplarzeAdd")
                CreateView(new NowyEgzemplarzViewModel());
            if (name == "Konkursy (wszystkie)Add")
                CreateView(new NowyKonkursViewModel());
            if (name == "Książka-TagAdd")
                CreateView(new NowyKsiazkaTagViewModel());
            if (name == "KsiążkiAdd")
                CreateView(new NowaKsiazkaViewModel());
            if (name == "RodzajeCzlonkostwaAdd")
                CreateView(new NowyRodzajCzlonkostwaViewModel());
            if (name == "Rodzaje LiterackieAdd")
                CreateView(new NowyRodzajLiterackiViewModel());
            if (name == "TagiAdd")
                CreateView(new NowyTagViewModel());
            if (name == "CzytelnicyAdd")
                CreateView(new NowyCzytelnikViewModel());
            if (name == "CzytelnicyAll")
                CreateView(new WszyswcyCzytelnicyViewModel());
        }
        #endregion
    }
}
