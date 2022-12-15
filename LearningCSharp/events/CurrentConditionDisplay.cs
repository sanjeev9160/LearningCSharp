using System;

namespace LearningCSharp.events
{
    public class CurrentConditionDisplay
    {
        private readonly IWeatherDataPublisher _weatherDataPublisher;
        private float _temperature;
        private float _humidity;
        private float _pressure;
        private readonly string _name;

        public CurrentConditionDisplay(IWeatherDataPublisher weatherDataPublisher, string displayName)
        {
            _weatherDataPublisher = weatherDataPublisher;
            _weatherDataPublisher.MeasurementDataChanged += OnMeasurementDataChanged;
            _name = displayName;
        }

        private void OnMeasurementDataChanged(WeatherData weatherData)
        {
            _temperature = weatherData.Temperature;
            _humidity = weatherData.Humidity;
            _pressure = weatherData.Pressure;

            Display();
        }

        public void Display()
        {
            Console.WriteLine($"Current Conditions for :{_name}");
            Console.WriteLine($"Temperature: {_temperature}");
            Console.WriteLine($"Humidity: {_humidity}");
            Console.WriteLine($"Pressure: {_pressure}");
        }
    }
}

