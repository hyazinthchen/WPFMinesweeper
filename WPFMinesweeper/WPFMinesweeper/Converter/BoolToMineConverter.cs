using System;
using System.Data;
using System.Globalization;
using System.Windows.Data;

namespace WPFMinesweeper.Converter
{
    /// <summary>
    /// Konvertiert einen Boolschen Wert zu einem String
    /// </summary>
    public class BoolToMineConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {

            string Mine = "💣";
            string noMine = "-";

            bool boolValue = (bool) value;
            if (boolValue == true) {
                return Mine;
            } else {
                return noMine;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
