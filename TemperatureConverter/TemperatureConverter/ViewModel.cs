﻿using System;
using System.ComponentModel;

namespace TemperatureConverter
{
    public class ConverterViewModel : INotifyPropertyChanged
    {
        private double temperatureInKelvin;

        public event PropertyChangedEventHandler PropertyChanged;

        public ConverterViewModel()
        {
            this.Kelvin = new TemperatureScaleViewModel(this, new KelvinTemperatureScale());
            this.Celsius = new TemperatureScaleViewModel(this, new CelsiusTemperatureScale());
            this.Fahrenheit = new TemperatureScaleViewModel(this, new FahrenheitTemperatureScale());
        }

        public double TemperatureInKelvin
        {
            get
            {
                return temperatureInKelvin;
            }
            set
            {
                temperatureInKelvin = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TemperatureInKelvin)));
            }
        }

        public TemperatureScaleViewModel Kelvin { get; }

        public TemperatureScaleViewModel Celsius { get; }

        public TemperatureScaleViewModel Fahrenheit { get; }
    }

    public class TemperatureScaleViewModel : INotifyPropertyChanged
    {
        private readonly ConverterViewModel parent;

        private readonly ITemperatureScale temperatureScale;

        public TemperatureScaleViewModel(ConverterViewModel parent, ITemperatureScale temperatureScale)
        {
            this.parent = parent;
            this.temperatureScale = temperatureScale;

            this.parent.PropertyChanged += (sender, args) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Temperature)));
        }

        public String Name => temperatureScale.Name;

        public double Temperature
        {
            get
            {
                return temperatureScale.ConvertFromKelvin(parent.TemperatureInKelvin);
            }
            set
            {
                parent.TemperatureInKelvin = temperatureScale.ConvertToKelvin(value);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
