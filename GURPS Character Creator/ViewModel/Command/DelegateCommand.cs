using System;
using System.Windows.Input;

namespace GURPS_Character_Creator.ViewModel.Command
{
    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> _CanExecute;
        private readonly Action<object> _Execute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _Execute = execute;
            _CanExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if(_CanExecute == null)
                return true;
            return _CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _Execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
