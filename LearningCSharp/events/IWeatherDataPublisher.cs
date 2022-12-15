using System;
namespace LearningCSharp.events
{
    public interface IWeatherDataPublisher
    {
        event EventHandler MeasurementChanged;

        event Action<WeatherData> MeasurementDataChanged;

        WeatherData WeatherData { get; }
    }
}

