using LearningCSharp.delegates;
using LearningCSharp.delegates.BasicExample;

namespace LearningCSharpTest;

[TestClass]
public class DelegatesTest
{
    [TestMethod]
    public void SimpleExample1()
    {
        int sum1 = ArithmeticHelper.Operation(TestHelper.Add, 3, 4);

        int sum2 = ArithmeticHelper.OperationWithFunc((a, b) => a + b, 1, 3); // lambdas: (a, b) => a + b
 
        int diff1 = ArithmeticHelper.Operation(TestHelper.Sub, 3, 4);

        int diff2 = ArithmeticHelper.OperationWithFunc((a, b) => a - b, 1, 3);

        Assert.AreEqual(sum1, 7);
        Assert.AreEqual(sum2, 4);
        Assert.AreEqual(diff1, -1);
        Assert.AreEqual(diff2, -2);
    }

    [TestMethod]
    public void LinqExamples()
    {
        var values = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };

        var evenValues = values.FindAll(x => x % 2 == 0); // public delegate bool Predicate<in T> (T obj);
    }

    [TestMethod]
    public void WeatherExample1()
    {
        WeatherStation station = new WeatherStation();
        CurrentConditionDisplay display = new CurrentConditionDisplay(station);

        // station.MeasurementDataChanged = null;

        station.SetMeasurements(40, 80, 1);
    }
}
