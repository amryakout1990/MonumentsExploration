using MonumentsExploration.Utilites;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace MonumentsExploration.ViewModels
{
    class MainVM:Utilites.ViewModelBase
    {
        private bool _inVis;

        public bool InVis
        {
            get { return _inVis; }
            set { _inVis = value; OnPropertyChanged();}
        }

        private string _indicator;
        public string Indicator
        {
            get { return _indicator; }
            set { _indicator = value; OnPropertyChanged(); }
        }

        private bool _cuckooCB;
        public bool CuckooCB
        {
            get { return _cuckooCB; }
            set { _cuckooCB = value; OnPropertyChanged();}
        }

        private bool _showCuckoo;
        public bool ShowCuckoo
        {
            get { return _showCuckoo; }
            set { _showCuckoo = value; OnPropertyChanged(); }
        }

        private bool _showArrow;
        public bool ShowArrow
        {
            get { return _showArrow; }
            set { _showArrow = value; OnPropertyChanged(); }
        }

        private bool _b1;
        public bool b1
        {
            get { return _b1; }
            set { _b1 = value; OnPropertyChanged(); }
        }

        private bool _b2;
        public bool b2
        {
            get { return _b2; }
            set { _b2 = value; OnPropertyChanged(); }
        }

        private bool _b3;
        public bool b3
        {
            get { return _b3; }
            set { _b3 = value; OnPropertyChanged(); }
        }

        private bool _b4;
        public bool b4
        {
            get { return _b4; }
            set { _b4 = value; OnPropertyChanged(); }
        }

        private bool _b5;
        public bool b5
        {
            get { return _b5; }
            set { _b5 = value; OnPropertyChanged(); }
        }
        private bool _b6;
        public bool b6
        {
            get { return _b6; }
            set { _b6 = value; OnPropertyChanged(); }
        }

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
        public ICommand StartCommand { get; private set; }

        public MainVM( )
        {
            CuckooCB = false;
            Indicator = "Ready";
            LoadIds();
            ShowGridCommand = new ActionCommand(Show);
            HideGridCommand = new ActionCommand(Hide);
            ShowIDSCommand = new ActionCommand(ShowIDS);
            HideIDSCommand = new ActionCommand(HideIDS);
            ShowLocationsCommand = new ActionCommand(ShowLocations);
            HideLocationsCommand = new ActionCommand(HideLocations);
            StartAnaylsissCommand = new ActionCommand(StartAnaylsiss);
            NewAnaylsissCommand = new ActionCommand(NewAnaylsiss);
            StartCommand = new ActionCommand(Start);
        }

        private void Start()
        {
            InVis = true;
        }

        private void NewAnaylsiss()
        {
            ShowColorsBool = false;
            ShowGridBool = false;
            ShowIDSBool = false;
            ShowLocationsBool = false;
            b1 = false;
            b2 = false;
            b3 = false;
            b4 = false;
            b5 = false;
            b6 = false;
            Indicator = "Ready";
        }

        private async void StartAnaylsiss()
        {
            if (ShowLocationsBool==true)
            {
                if (ShowColorsBool != true)
                {
                    Indicator = "Searching...";
                    if (CuckooCB==false)
                    {
                        ShowArrow = true;
                        await Task.Run(() => { Thread.Sleep(800); ShowColorsBool = true; ShowArrow = false; });
                        Indicator = "Succeeded";
                    }
                    else
                    {
                        ShowCuckoo = true;
                        await Task.Run(() => { Thread.Sleep(2400); ShowColorsBool = true; ShowCuckoo = false; });
                        Indicator = "Succeeded";
                    }
                }
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
