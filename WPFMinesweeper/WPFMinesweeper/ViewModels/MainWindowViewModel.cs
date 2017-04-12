using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Threading;

namespace WPFMinesweeper.ViewModels
{
    public class MainWindowViewModel : BaseViewModel {

        private int _currentTime;
        private DispatcherTimer _timer;

        public int CurrentTime {
            get { return _currentTime;}
            set {
                _currentTime = value;
                OnPropertyChanged("CurrentTime");
            }
        }

        public MainWindowViewModel()
        {
            InitializeTimer();
        }

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

        public ICommand StartTimerAgainCommand {
            get { return new DelegateCommand(StartTimerAgain);}
        }

        private void StartTimerAgain() {
            CurrentTime = 0;
        }
    }
}
