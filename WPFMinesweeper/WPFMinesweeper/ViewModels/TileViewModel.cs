using Com.QueoFlow.Commons;

namespace WPFMinesweeper.ViewModels {
    public class TileViewModel : BaseViewModel {
        private bool _isFlagged;

        private bool _isMine;
        private bool _isRevealed;
        private int _x;
        private int _y;

        /// <summary>
        ///     Konstruktor für das TileViewModel
        /// </summary>
        public TileViewModel() {
        }

        public TileViewModel(int x, int y, bool isMine) {
            _isMine = isMine;
            _x = x;
            _y = y;
        }

        /// <summary>
        ///     Command zum Flaggen von Buttons
        /// </summary>
        public DelegateCommand FlagCommand {
            get { return new DelegateCommand(ExecuteFlagButton); }
        }

        /// <summary>
        ///     Flagge oder keine Flagge
        /// </summary>
        public bool IsFlagged {
            get { return _isFlagged; }
            set {
                _isFlagged = value;
                OnPropertyChanged(this.GetPropertyName(x => x.IsFlagged));
            }
        }

        /// <summary>
        ///     Mine oder keine Mine
        /// </summary>
        public bool IsMine {
            get { return _isMine; }
            set { _isMine = value; }
        }

        /// <summary>
        ///     aufgedecktes oder nicht aufgedecktes Feld
        /// </summary>
        public bool IsRevealed {
            get { return _isRevealed; }
            set {
                _isRevealed = value;
                OnPropertyChanged(this.GetPropertyName(x => x.IsRevealed));
            }
        }

        /// <summary>
        ///     Command zum Aufdecken von Feldern
        /// </summary>
        public DelegateCommand RevealCommand {
            get { return new DelegateCommand(ExecuteRevealTile); }
        }

        /// <summary>
        ///     die X-Koordinate
        /// </summary>
        public int X {
            get { return _x; }
            set { _x = value; }
        }

        /// <summary>
        ///     die Y-Koordinate
        /// </summary>
        public int Y {
            get { return _y; }
            set { _y = value; }
        }

        /// <summary>
        ///     Markiert den Button mit einer Flagge
        /// </summary>
        private void ExecuteFlagButton(object parameter) {
            if (IsFlagged == false) {
                IsFlagged = true;
            } else {
                IsFlagged = false;
            }
        }

        /// <summary>
        ///     Zeigt das sich darunter befindende Feld
        /// </summary>
        private void ExecuteRevealTile(object parameter) {
            if (IsRevealed == false) {
                IsRevealed = true;
            }
        }
    }
}