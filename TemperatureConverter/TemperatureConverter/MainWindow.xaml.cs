using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TemperatureConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConvertFahrenheit(object sender, RoutedEventArgs e)
        {
            var input = textBoxFahrenheit.Text;
            var fahrenheit = double.Parse(input);
            var celsius = Math.Round((fahrenheit - 32) / 1.8, 2);
            var kelvin = celsius + 273.15;
            var output = Convert.ToString(celsius);
            textBoxCelsius.Text = Convert.ToString(celsius);
            textBoxKelvin.Text = Convert.ToString(kelvin);
        }

        private void ConvertCelsius(object sender, RoutedEventArgs e)
        {
            var input = textBoxCelsius.Text;
            var celsius = double.Parse(input);
            var fahrenheit = Math.Round(celsius * 1.8 + 32, 2);
            var kelvin = celsius + 273.15;
            textBoxFahrenheit.Text = Convert.ToString(fahrenheit);
            textBoxKelvin.Text = Convert.ToString(kelvin);
        }

        private void ConvertKelvin(object sender, RoutedEventArgs e)
        {
            var input = textBoxKelvin.Text;
            var kelvin = double.Parse(input);
            var celsius = kelvin - 273.15;
            var fahrenheit = Math.Round(celsius * 1.8 + 32, 2);
            textBoxCelsius.Text = Convert.ToString(celsius);
            textBoxFahrenheit.Text = Convert.ToString(fahrenheit);
        }
    }
}
