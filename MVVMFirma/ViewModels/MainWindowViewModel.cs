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
            return new List<CommandViewModel>
            {
                new CommandViewModel(
                    "Towary",
                    new BaseCommand(() => this.ShowAllTowar())),

                new CommandViewModel(
                    "Kara",
                    new BaseCommand(() => this.CreateView(new NowaKaraViewModel()))),

                new CommandViewModel(
                    "Książka",
                    new BaseCommand(() => this.CreateView(new NowaKsiazkaViewModel()))),

                new CommandViewModel(
                    "Rezerwacja",
                    new BaseCommand(() => this.CreateView(new NowaRezerwacjaViewModel()))),

                new CommandViewModel(
                    "Wydawnictwo",
                    new BaseCommand(() => this.CreateView(new NoweWydawnictwoViewModel()))),

                new CommandViewModel(
                    "Wypożyczenie",
                    new BaseCommand(() => this.CreateView(new NoweWypozyczenieViewModel()))),

                new CommandViewModel(
                    "Zgłoszenie",
                    new BaseCommand(() => this.CreateView(new NoweZgloszenieViewModel()))),

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
                    "Książka-Tag (dodaj)",
                    new BaseCommand(() => this.CreateView(new NowyKsiazkaTagViewModel()))),

                new CommandViewModel(
                    "Rodzaj Członkostwa",
                    new BaseCommand(() => this.CreateView(new NowyRodzajCzlonkostwaViewModel()))),

                new CommandViewModel(
                    "RodzajLitercki",
                    new BaseCommand(() => this.CreateView(new NowyRodzajLiterackiViewModel()))),

                new CommandViewModel(
                    "Tag",
                    new BaseCommand(() => this.CreateView(new NowyTagViewModel()))),

                new CommandViewModel(
                    "Użytkownik Systemu",
                    new BaseCommand(() => this.CreateView(new NowyUzytkownikSystemuViewModel()))),
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
        private void ShowAllTowar()
        {
            WszystkieTowaryViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieTowaryViewModel)
                as WszystkieTowaryViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieTowaryViewModel();
                this.Workspaces.Add(workspace);
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
        #endregion
    }
}
