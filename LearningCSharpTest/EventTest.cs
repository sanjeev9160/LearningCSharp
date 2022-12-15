using System;
using LearningCSharp.events;

namespace LearningCSharpTest
{
    [TestClass]
    public class EventTest
    {
        [TestMethod]
        public void WeatherExample1()
        {
            WeatherStation station = new WeatherStation();
            CurrentConditionDisplay display1 = new CurrentConditionDisplay(station, "Screen 1");
            CurrentConditionDisplay display2 = new CurrentConditionDisplay(station, "Screen 2");

            station.MeasurementDataChanged += null;

            station.SetMeasurements(40, 80, 1);
        }
    }
}

