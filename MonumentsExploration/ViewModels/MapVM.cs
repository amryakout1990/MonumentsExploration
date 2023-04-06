using MonumentsExploration.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentsExploration.ViewModels
{
    class MapVM : Utilites.ViewModelBase
    {
        private NavigationStore _navigationStore;

        public MapVM(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
    }
}
