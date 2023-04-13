using MonumentsExploration.Utilites;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace MonumentsExploration.ViewModels
{
    class MainVM:Utilites.ViewModelBase
    {
        private bool _showGridBool;
        public bool ShowGridBool
        {
            get { return _showGridBool; }
            set { _showGridBool = value;OnPropertyChanged(); }
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

        private bool _showColorsBool;

        public bool ShowColorsBool
        {
            get { return _showColorsBool; }
            set { _showColorsBool = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Button> IdsButtons;
        private CollectionViewSource IdsButtonsCollection;
        public ICollectionView SourceCollection => IdsButtonsCollection.View;
        private Button IdsButton;

        public ICommand ShowGridCommand { get; private set; }
        public ICommand HideGridCommand { get; private set; }
        public ICommand ShowIDSCommand { get; private set; }
        public ICommand HideIDSCommand { get; private set; }
        public ICommand ShowLocationsCommand { get; private set; }
        public ICommand HideLocationsCommand { get; private set; }
        public ICommand StartAnaylsissCommand { get; private set; }
        public ICommand NewAnaylsissCommand { get; private set; }

        public MainVM( )
        {
            LoadIds();
            ShowGridCommand = new ActionCommand(Show);
            HideGridCommand = new ActionCommand(Hide);
            ShowIDSCommand = new ActionCommand(ShowIDS);
            HideIDSCommand = new ActionCommand(HideIDS);
            ShowLocationsCommand = new ActionCommand(ShowLocations);
            HideLocationsCommand = new ActionCommand(HideLocations);
            StartAnaylsissCommand = new ActionCommand(StartAnaylsiss);
            NewAnaylsissCommand = new ActionCommand(NewAnaylsiss);
        }

        private void NewAnaylsiss()
        {
            ShowColorsBool = false;
            ShowGridBool = false;
            ShowIDSBool = false;
            ShowLocationsBool = false;
        }

        private void StartAnaylsiss()
        {
            if (ShowLocationsBool==true)
            {
                ShowColorsBool = true;
            }
            else
            {
                MessageBox.Show("Please Show Locations First");
            }
        }

        private void LoadIds()
        {
            IdsButtons = new ObservableCollection<Button>();
            IdsButtons.Clear();
            for (int i = 1; i <=20; i++)
            {
                for (int i2 = 1; i2 <=20; i2++)
                {
                    IdsButton = new Button();
                    IdsButton.Content =i.ToString() + "," + i2.ToString();
                    IdsButton.Style=(Style)IdsButton.FindResource("ButtonIDS");
                    IdsButtons.Add(IdsButton);
                }
            }
            IdsButtonsCollection = new CollectionViewSource { Source = IdsButtons };
        }
        private void HideLocations()
        {
            ShowLocationsBool = false;
            ShowColorsBool = false;
        }

        private void ShowLocations()
        {
            ShowLocationsBool = true;
        }

        private void HideIDS()
        {
            ShowIDSBool = false;
        }

        private void ShowIDS()
        {
            ShowIDSBool = true;
        }

        private void Hide()
        {
            ShowGridBool = false;
        }

        private void Show()
        {
            ShowGridBool = true;
        }
    }
}
