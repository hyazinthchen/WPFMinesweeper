using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFMinesweeper.Converter {
    public class BoolToFlagConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {

            string Flag = "ᐈ";
            string noFlag = "";

            bool boolValue = (bool) value;
            if (boolValue == true) {
                return Flag;
            } else {
                return noFlag;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
