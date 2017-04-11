using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Threading;

namespace WPFMinesweeper.ViewModels
{
    public class MainWindowViewModel : BaseViewModel {

        private int _currentTime;

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
            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Render) { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += (sender, args) => {
                CurrentTime++;
                if (CurrentTime == 30)
                {
                    timer.Stop();
                }
            };
            CurrentTime = 0;
            timer.Start();
        }

        public ICommand StartTimerAgainCommand {
            get { return new DelegateCommand(StartTimerAgain);}
        }

        private void StartTimerAgain() {
            InitializeTimer();
        }
    }
}
