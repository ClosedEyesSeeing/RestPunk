using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestPunk
{
    public sealed class PunkRelayCommand : ICommand
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?, bool>? _canExecute;
        public PunkRelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        { _execute = execute; _canExecute = canExecute; }
        public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;
        public void Execute(object? parameter) => _execute(parameter);
        public event EventHandler? CanExecuteChanged;
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

	public sealed class PunkRelayCommand<T> : ICommand
	{
		private readonly Action<T?> _execute;
		private readonly Func<T?, bool>? _canExecute;
		public PunkRelayCommand(Action<T?> execute, Func<T?, bool>? canExecute = null)
		{ _execute = execute; _canExecute = canExecute; }
		public bool CanExecute(object? parameter) => _canExecute?.Invoke((T)parameter) ?? true;
		public void Execute(object? parameter) => _execute((T)parameter);
		public event EventHandler? CanExecuteChanged;
		public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
	}
}
