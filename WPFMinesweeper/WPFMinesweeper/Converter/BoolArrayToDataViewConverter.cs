using System;
using System.Data;
using System.Globalization;
using System.Windows.Data;

namespace WPFMinesweeper.Converter
{
    public class BoolArrayToDataViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {

            DataTable t = new DataTable();

            bool[,] field = value as bool[,];
            if (field == null) {
                return null;
            }

            int rows = field.GetLength(0);
            if (rows == 0) {
                return null;
            }

            int columns = field.GetLength(1);
            if (columns == 0) {
                return null;
            }

            for (int r = 0; r < rows; r++) {
                DataRow newRow = t.NewRow();
                for (int c = 0; c < columns; columns++) {
                    newRow[c] = field[r, c];
                }
                t.Rows.Add(newRow);
            }
            return t.DefaultView;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
