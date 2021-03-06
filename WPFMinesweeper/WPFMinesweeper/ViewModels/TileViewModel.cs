﻿using System;
using WPFMinesweeper.Model;

namespace WPFMinesweeper.ViewModels {
    public class TileViewModel : BaseViewModel {

        /// <summary>
        /// Delegat ChangedEventHandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ChangedEventHandler(object sender, EventArgs e);

        private static MinesweeperModel _minesweeperModel = new MinesweeperModel(12);
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
        ///     Liefert das Model
        /// </summary>
        public static MinesweeperModel MinesweeperModel
        {
            get { return _minesweeperModel; }
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
                OnPropertyChanged("IsFlagged");
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
                OnPropertyChanged("IsRevealed");
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
        /// Flagged-Event 
        /// </summary>
        public event ChangedEventHandler Flagged;

        /// <summary>
        ///     Markiert den Button mit einer Flagge
        /// </summary>
        private void ExecuteFlagButton(object parameter) {
            if (IsFlagged == false) {
                IsFlagged = true;
                MinesweeperModel.FlagsLeft = MinesweeperModel.FlagsLeft - 1;
                if (Flagged != null) {
                    Flagged(this, EventArgs.Empty);
                }
            } else {
                IsFlagged = false;
                MinesweeperModel.FlagsLeft = MinesweeperModel.FlagsLeft + 1;
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