using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NavigationWPF01.Core
{
    public class RelayCommand : ICommand
    {        
        public readonly Predicate<object> _canExecute;
        private readonly Action<object> _canExecuteAction;

        public RelayCommand(Action<object> canExecuteAction, Predicate<object> canExecute)
        {
            _canExecute = canExecute;
            _canExecuteAction = canExecuteAction;
        }
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _canExecuteAction(parameter);
        }
    }
}
