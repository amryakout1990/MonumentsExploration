using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MonumentsExploration.Utilites
{
    class ViewModelBase : INotifyPropertyChanged
    {
        public void OnPropertyChanged([CallerMemberName] string PropName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
