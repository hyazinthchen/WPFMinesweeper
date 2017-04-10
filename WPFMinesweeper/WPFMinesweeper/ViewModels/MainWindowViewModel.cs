using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WPFMinesweeper.ViewModels
{
    public class MainWindowViewModel : ICommand
    {
        private readonly Action _action;

        //neues MainWindowViewModel mit einer Action, die es ausführen soll
        public MainWindowViewModel(Action action)
        {
            _action = action;
        }

        //Gibt die gewünschte Action als Parameter an das MainWindowViewModel
        public void Execute(object parameter)
        {
            _action();
        }

        //Enabled den Konvertierbutton, bei False ist er disabled
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }
    }
}
