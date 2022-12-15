using System;
using LearningCSharp.events;

namespace LearningCSharp.delegates
{
    public class CurrentConditionDisplay
    {
        private readonly WeatherStation _weatherStation;

        public CurrentConditionDisplay(WeatherStation weatherStation)
        {
            _weatherStation = weatherStation;
            _weatherStation.MeasurementDataChanged += OnMeasurementDataChanged;
        }

        public void OnMeasurementDataChanged(WeatherData weatherData)
        {
            this.Display(weatherData.Temperature, weatherData.Humidity, weatherData.Pressure);
        }

        private void Display(float temperature, float humidity, float pressure)
        {
            Console.WriteLine("Current Conditions: ");
            Console.WriteLine($"Temperature: {temperature}");
            Console.WriteLine($"Humidity: {humidity}");
            Console.WriteLine($"Pressure: {pressure}");
        }
    }
}

