using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPFMinesweeper.Model;

namespace WPFMinesweeper.ViewModels
{
    public class MatrixViewModel : ObservableObject
    {
        private readonly MinesweeperModel _textConverter = new MinesweeperModel(s => s.ToUpper());
        private string _someText;
        private readonly ObservableCollection<string> _history = new ObservableCollection<string>();

        public string SomeText
        {
            get { return _someText; }
            set
            {
                _someText = value;
                RaisePropertyChangedEvent("SomeText");
            }
        }

        public IEnumerable<string> History
        {
            get { return _history; }
        }

        public ICommand ConvertTextCommand
        {
            get { return new MainWindowViewModel(ConvertText); }
        }

        private void ConvertText()
        {
            if (string.IsNullOrWhiteSpace(SomeText)) return;
            AddToHistory(_textConverter.ConvertText(SomeText));
            SomeText = string.Empty;
        }

        private void AddToHistory(string item)
        {
            if (!_history.Contains(item))
                _history.Add(item);
        }
    }
}
