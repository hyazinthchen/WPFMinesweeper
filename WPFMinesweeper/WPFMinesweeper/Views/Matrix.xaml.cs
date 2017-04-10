using System.Windows.Controls;

namespace WPFMinesweeper.Views
{
    /// <summary>
    /// Interaktionslogik für Matrix.xaml
    /// </summary>
    public partial class Matrix
    {
        public Matrix()
        {
            InitializeComponent();

            for (int i = 0; i < 100; i++) {
                Button button = new Button();
            }
        }
    }
}
