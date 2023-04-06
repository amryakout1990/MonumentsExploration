using MonumentsExploration.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentsExploration.Stores
{
    class NavigationStore:Utilites.ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { _currentViewModel = value; OnCurrentViewModelChanged(); }
        }
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action CurrentViewModelChanged;


    }
}
