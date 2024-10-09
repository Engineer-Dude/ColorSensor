using System.Globalization;
using System.Windows.Data;

namespace ColorSensor.Converters
{
    public class ValueDivisionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is not null &&
                double.TryParse(value.ToString(), out double val) &&
                double.TryParse(parameter.ToString(), out double param) ? val / param : double.NaN;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
