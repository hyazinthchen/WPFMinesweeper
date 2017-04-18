using System;
using Com.QueoFlow.Commons;

namespace WPFMinesweeper.ViewModels
{
    public class TileViewModel : BaseViewModel {

        public TileViewModel(int x, int y, bool isMine) {
            _isMine = isMine;
            _x = x;
            _y = y;
        }

        public bool IsMine {
            get { return _isMine; }
            set { _isMine = value; }
        }

        public bool IsRevealed {
            get { return _isRevealed; }
            set {
                _isRevealed = value;
                OnPropertyChanged(this.GetPropertyName(x => x.IsRevealed));
            }
        }

        public int X {
            get { return _x; }
            set { _x = value; }
        }

        public int Y {
            get { return _y; }
            set { _y = value; }
        }

        public bool IsFlagged {
            get { return _isFlagged; }
            set {
                _isFlagged = value;
                OnPropertyChanged(this.GetPropertyName(x => x.IsFlagged));
            }
        }

        private bool _isMine;
        private bool _isRevealed;
        private bool _isFlagged;
        private int _x;
        private int _y;

        /// <summary>
        /// Command zum Flaggen von Buttons
        /// </summary>
        public DelegateCommand FlagCommand
        {
            get { return new DelegateCommand(ExecuteFlagButton); }
        }

        /// <summary>
        /// Markiert den Button mit einer Flagge
        /// </summary>
        private void ExecuteFlagButton(object parameter)
        {
            if (IsFlagged == false)
            {
                IsFlagged = true;
            }
            else
            {
                IsFlagged = false;
            }
        }

        /// <summary>
        /// Command zum Aufdecken von Feldern
        /// </summary>
        public DelegateCommand RevealCommand
        {
            get { return new DelegateCommand(ExecuteRevealTile); }
        }

        /// <summary>
        /// Zeigt das sich darunter befindende Feld
        /// </summary>
        private void ExecuteRevealTile(object parameter)
        {
            if (IsRevealed == false)
            {
                IsRevealed = true;
            }
        }
    }
}
