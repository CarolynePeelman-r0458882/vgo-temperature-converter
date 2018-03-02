using System;
using System.Globalization;
using System.Windows.Data;

namespace TemperatureConverter
{
    public class CelsiusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var kelvin = (double)value;
            var celsius = Math.Round(kelvin - 273.15,2);

            return celsius.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var celsius = double.Parse((string)value);
            var kelvin = Math.Round(celsius + 273.15,2);

            return kelvin;
        }
    }
}