using System;
using System.Globalization;
using System.Windows.Data;

namespace TemperatureConverter
{
    public class FahrenheitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var kelvin = (double)value;
            var fahrenheit = Math.Round((kelvin - 273.15) * 1.8 + 32, 2);

            return fahrenheit.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var fahrenheit = double.Parse((string)value);
            var kelvin = Math.Round((fahrenheit - 32) / 1.8 + 273.15, 2);

            return kelvin;
        }
    }
}