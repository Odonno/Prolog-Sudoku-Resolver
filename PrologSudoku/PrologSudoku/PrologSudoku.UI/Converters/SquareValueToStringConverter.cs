using System;
using System.Globalization;
using System.Windows.Data;

namespace PrologSudoku.UI.Converters
{
    internal class SquareValueToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var squareValue = (short) value;
            return (squareValue == 0) ? string.Empty : squareValue.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringValue = value as string;
            return string.IsNullOrEmpty(stringValue) ? 0 : short.Parse(stringValue);
        }
    }
}
