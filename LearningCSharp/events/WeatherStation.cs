using System;
namespace LearningCSharp.events
{
    public class WeatherStation : IWeatherDataPublisher
    {
        public WeatherStation()
        {
            WeatherData = new WeatherData();
        }

        public WeatherData WeatherData { get; }

        public event EventHandler MeasurementChanged;
        public event Action<WeatherData> MeasurementDataChanged;

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            WeatherData.Temperature = temperature;
            WeatherData.Humidity = humidity;
            WeatherData.Pressure = pressure;

            OnMeasurementChanged();
        }

        private void OnMeasurementChanged()
        {
            MeasurementChanged?.Invoke(this, EventArgs.Empty);
            MeasurementDataChanged?.Invoke(WeatherData);
        }
    }
}

