using System;
using System.Windows.Input;
using System.Windows.Threading;

namespace WPFMinesweeper.ViewModels
{
    public class MainWindowViewModel : BaseViewModel {

        private int _flagsLeft = 12;
        private int _currentTime;
        private DispatcherTimer _timer;

        /// <summary>
        /// Anzahl noch verbleibender Flaggen
        /// </summary>
        public int FlagsLeft {
            get { return _flagsLeft; }
            set {
                _flagsLeft = value; 
                OnPropertyChanged("FlagsLeft");
            }
        }

        /// <summary>
        /// Die aufwärtszählende Zeit
        /// </summary>
        public int CurrentTime {
            get { return _currentTime;}
            set {
                _currentTime = value;
                OnPropertyChanged("CurrentTime");
            }
        }

        /// <summary>
        /// Konstruktor für das MainWindowViewModel
        /// </summary>
        public MainWindowViewModel()
        {
            InitializeTimer();
        }

        /// <summary>
        /// Initialisiert zu Programmstart den Timer
        /// </summary>
        private void InitializeTimer() {
            if (_timer != null) {
                return;
            }
            _timer = new DispatcherTimer(DispatcherPriority.Render) { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += (sender, args) => {
                CurrentTime++;
                if (CurrentTime == 30)
                {
                    _timer.Stop();
                }
            };
            CurrentTime = 0;
            _timer.Start();
        }

        /// <summary>
        /// Command zum Timer-Restart bei neuem Spiel
        /// </summary>
        public ICommand StartTimerAgainCommand {
            get { return new DelegateCommand(StartTimerAgain);}
        }

        /// <summary>
        /// Setzt die Zeit bei neuem Spiel zurück
        /// </summary>
        private void StartTimerAgain() {
            CurrentTime = 0;
        }
    }
}
