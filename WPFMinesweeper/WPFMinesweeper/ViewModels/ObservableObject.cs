using System.ComponentModel;

namespace WPFMinesweeper.ViewModels
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //Sagt der UI, dass sich am Model etwas geändert hat
        protected void RaisePropertyChangedEvent(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
