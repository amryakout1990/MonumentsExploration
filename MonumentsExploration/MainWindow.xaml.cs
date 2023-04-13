using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MonumentsExploration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton==MouseButton.Left)
            {
                try
                {
                    this.DragMove();
                }
                catch (Exception)
                {
                }
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount==2)
            {
                if (mw.WindowState == WindowState.Normal)
                {
                    mw.WindowState = WindowState.Maximized;
                }
                else if (mw.WindowState == WindowState.Maximized)
                {
                    mw.WindowState = WindowState.Normal;
                }

            }
        }

        private void FaClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void FaMini_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (mw.WindowState == WindowState.Normal)
            {
                mw.WindowState = WindowState.Minimized;
            }
            else if (mw.WindowState == WindowState.Maximized)
            {
                mw.WindowState = WindowState.Minimized;
            }

        }

        private void FaMax_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (mw.WindowState == WindowState.Normal)
            {
                mw.WindowState = WindowState.Maximized;
            }
            else if (mw.WindowState == WindowState.Maximized)
            {
                mw.WindowState = WindowState.Normal;
            }

        }
    }
}
