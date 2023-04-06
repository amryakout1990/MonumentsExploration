using MonumentsExploration.Stores;
using MonumentsExploration.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MonumentsExploration
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {


        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore _navigationStore = new NavigationStore();

            _navigationStore.CurrentViewModel = new MapVM(_navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainVM(_navigationStore)
            };
            MainWindow.Show();
        }
    }
}
