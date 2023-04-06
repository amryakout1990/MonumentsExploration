using MonumentsExploration.Stores;
using MonumentsExploration.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MonumentsExploration.ViewModels
{
    class MainVM:Utilites.ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        private bool _showGrid;
        public bool ShowGrid
        {
            get { return _showGrid; }
            set { _showGrid = value;OnPropertyChanged(); }
        }

        private bool _showIDSBool;
        public bool ShowIDSBool
        {
            get { return _showIDSBool; }
            set { _showIDSBool = value; OnPropertyChanged(); }
        }

        private bool _showLocationsBool;

        public bool ShowLocationsBool
        {
            get { return _showLocationsBool; }
            set { _showLocationsBool = value; OnPropertyChanged();}
        }

        public ICommand TextIdsCommand { get; private set; }
        public ICommand GetPointsCommand { get; private set; }
        public ICommand GetImageCommand { get; private set; }
        public ICommand ShowGridCommand { get; private set; }
        public ICommand HideGridCommand { get; private set; }
        public ICommand FaCloseCommand { get; private set; }
        public ICommand ShowIDSCommand { get; private set; }
        public ICommand HideIDSCommand { get; private set; }
        public ICommand ShowLocationsCommand { get; private set; }
        public ICommand HideLocationsCommand { get; private set; }

        public MainVM(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            ShowGrid = false;
            _navigationStore.CurrentViewModelChanged += _navigationStore_CurrentViewModelChanged;

            TextIdsCommand = new ParametrizedActionCommand(TextIds);
            GetPointsCommand = new ParametrizedActionCommand(GetPoints);
            GetImageCommand = new ParametrizedActionCommand(GetPoints);
            ShowGridCommand = new ActionCommand(Show);
            HideGridCommand = new ActionCommand(Hide);
            FaCloseCommand = new ActionCommand(FaClose);
            ShowIDSCommand = new ActionCommand(ShowIDS);
            HideIDSCommand = new ActionCommand(HideIDS);
            ShowLocationsCommand = new ActionCommand(ShowLocations);
            HideLocationsCommand = new ActionCommand(HideLocations);
        }

        private void GetImage(object CurrentImage)
        {
            MessageBox.Show(CurrentImage.ToString());
        }

        private void GetPoints(object CurrentPoint)
        {
            MessageBox.Show(CurrentPoint.ToString());

        }

        private void HideLocations()
        {
            ShowLocationsBool = false;
        }

        private void ShowLocations()
        {
            ShowLocationsBool = true;
        }

        private void _navigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void TextIds(object CurrentIDS)
        {
            MessageBox.Show(CurrentIDS.ToString());
        }

        private void HideIDS()
        {
            ShowIDSBool = false;
        }

        private void ShowIDS()
        {
            ShowIDSBool = true;
        }

        private void FaClose()
        {
            Application.Current.Shutdown();
        }

        private void Hide()
        {
            ShowGrid = false;
        }

        private void Show()
        {
            ShowGrid = true;
        }
    }
}
