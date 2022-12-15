using System;
namespace LearningCSharp.delegates
{
    public class WeatherStation
    {
        public WeatherStation()
        {
            WeatherData = new WeatherData();
        }

        public EventHandler MeasurementChanged;

        public Action<WeatherData> MeasurementDataChanged;

        WeatherData WeatherData { get; }

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            WeatherData.Temperature = temperature;
            WeatherData.Humidity = humidity;
            WeatherData.Pressure = pressure;

            OnMeasurementChanged();
        }

        private void OnMeasurementChanged()
        {
            // MeasurementChanged?.Invoke(this, EventArgs.Empty);
            MeasurementDataChanged?.Invoke(WeatherData);
        }
    }
}

