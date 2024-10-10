using System.Globalization;
using System.Windows.Data;

namespace ColorSensor.Converters
{
    public class GreaterThanMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = false;

            result = values is not null && values.Length == 2 &&
                double.TryParse(values[0].ToString(), out double value1) &&
                double.TryParse(values[1].ToString(), out double value2) &&
                value1 > value2;

            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
