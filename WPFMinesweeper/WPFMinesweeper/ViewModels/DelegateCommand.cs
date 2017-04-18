using System;
using System.Windows.Input;

namespace WPFMinesweeper.ViewModels
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _action;

        public DelegateCommand(Action<object> action)
        {
            _action = action;
        }

        /// <summary>
        /// Enthält Anweisungen, die beim Command ausgeführt werden sollen.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _action(parameter);
        }

        /// <summary>
        /// Prüft, ob Execute ausgeführt werden kann.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Bei Änderungen die sich auf die Ausführung des Commands auswirken.
        /// </summary>
        public event EventHandler CanExecuteChanged;
    }
}
