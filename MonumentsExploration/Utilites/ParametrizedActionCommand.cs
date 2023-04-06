using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MonumentsExploration.Utilites
{
    class ParametrizedActionCommand : ICommand
    {
        private readonly Action<string> _execute;

        public ParametrizedActionCommand(Action<string> execute)
        {
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute((string)parameter);

        }

    }
}
