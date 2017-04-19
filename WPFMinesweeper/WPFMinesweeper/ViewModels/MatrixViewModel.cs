using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Threading;
using Com.QueoFlow.Commons;

namespace WPFMinesweeper.ViewModels {
    public class MatrixViewModel : BaseViewModel {
        private readonly Random rnd = new Random();
        private readonly int _columnCount = 10;
        private int _currentTime;
        private int _flagsLeft = 12;
        private readonly int _mines = 12;

        private readonly int _rowCount = 10;
        private List<TileViewModel> _tiles = new List<TileViewModel>();
        private DispatcherTimer _timer;
        private bool[,] field;

        /// <summary>
        ///     Konstruktor für das MatrixViewModel
        /// </summary>
        public MatrixViewModel() {
            CalculateMines();
            GenerateMatrix();
            InitializeTimer();
        }

        /// <summary>
        ///     Anzahl der Spalten des Spielfelds
        /// </summary>
        public int ColumnCount {
            get { return _columnCount; }
        }

        /// <summary>
        ///     Die aufwärtszählende Zeit
        /// </summary>
        public int CurrentTime {
            get { return _currentTime; }
            set {
                _currentTime = value;
                OnPropertyChanged(this.GetPropertyName(x => x.CurrentTime));
            }
        }

        /// <summary>
        ///     Anzahl noch verbleibender Flaggen
        /// </summary>
        public int FlagsLeft {
            get { return _flagsLeft; }
            set {
                _flagsLeft = value;
                OnPropertyChanged(this.GetPropertyName(x => x.FlagsLeft));
            }
        }

        /// <summary>
        ///     Anzahl der Reihen des Spielfelds
        /// </summary>
        public int RowCount {
            get { return _rowCount; }
        }

        /// <summary>
        ///     Command zum Timer-Restart bei neuem Spiel
        /// </summary>
        public ICommand StartTimerAgainCommand {
            get { return new DelegateCommand(ExecuteStartTimerAgain); }
        }

        /// <summary>
        ///     Liste von Buttons auf dem Spielfeld
        /// </summary>
        public List<TileViewModel> Tiles {
            get { return _tiles; }
            set { _tiles = value; }
        }

        /// <summary>
        ///     Verteilt die Minen
        /// </summary>
        /// <returns></returns>
        private void CalculateMines() {
            field = new bool[_columnCount, _rowCount];

            int minesCount = 0;
            for (int i = 0; i < field.Length; i++) {
                if (minesCount == _mines) {
                    break;
                }

                int mineX = rnd.Next(9);
                int mineY = rnd.Next(9);
                if (field[mineX, mineY] == false) {
                    field[mineX, mineY] = true;
                    minesCount++;
                }
            }
        }

        /// <summary>
        ///     Setzt die Zeit bei neuem Spiel zurück
        /// </summary>
        private void ExecuteStartTimerAgain(object parameter) {
            CurrentTime = 0;
        }

        /// <summary>
        ///     Generiert das Spielfeld
        /// </summary>
        private void GenerateMatrix() {
            for (int i = 0; i < field.GetLength(0); i++) {
                for (int j = 0; j < field.GetLength(1); j++) {
                    bool isMine = field[i, j];
                    TileViewModel tileViewModel = new TileViewModel(i, j, isMine);
                    _tiles.Add(tileViewModel);
                }
            }
        }

        /// <summary>
        ///     Initialisiert zu Programmstart den Timer
        /// </summary>
        private void InitializeTimer() {
            if (_timer != null) {
                return;
            }
            _timer = new DispatcherTimer(DispatcherPriority.Render) {Interval = TimeSpan.FromSeconds(1)};
            _timer.Tick += (sender, args) => {
                CurrentTime++;
                if (CurrentTime == 30) {
                    _timer.Stop();
                }
            };
            CurrentTime = 0;
            _timer.Start();
        }
    }
}