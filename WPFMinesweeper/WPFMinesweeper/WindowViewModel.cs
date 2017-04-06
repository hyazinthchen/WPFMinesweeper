using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPFMinesweeper
{
    public class WindowViewModel : INotifyPropertyChanged
    {

        public WindowViewModel() {
            Text = "Hallo mein ViewModel.";
        }


        /// <summary>
        ///    Liefert oder setzt den Text
        /// </summary>
        public string Text { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void GenerateMatrix() {
            List<Square> fields = new List<Square>();
            fields.Add(new Square() { IsMine = true });
            fields.Add(new Square() { IsMine = false });
            matrix.ItemSource = fields;
        }

        public class Square {
            public bool IsMine { get; set; }
        }
    }
}
