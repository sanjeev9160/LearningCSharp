using System;
using LearningCSharp.AsyncConcepts;

namespace LearningCSharpTest
{
    [TestClass]
    public class TaskTest
    {
        [TestMethod]
        public async Task ContinuationStyle()
        {
            TasksConcepts tasksConcepts = new TasksConcepts();

            await tasksConcepts.ContinuationStyleProgramming();

            await Task.Delay(2000);

            var delayTask = Task.Delay(1000);

            Console.WriteLine("*** Done ***");
        }

        [TestMethod]
        public async Task BadStyle1()
        {
            TasksConcepts tasksConcepts = new TasksConcepts();

            await tasksConcepts.BadPractice1();

            Console.WriteLine("Done");
        }

        [TestMethod]
        public async Task BadStyle2()
        {
            TasksConcepts tasksConcepts = new TasksConcepts();

            await tasksConcepts.BadPractice2();

            Console.WriteLine("Done");
        }

        [TestMethod]
        public async Task BadStyle3()
        {
            TasksConcepts tasksConcepts = new TasksConcepts();

            try
            {
               var task = tasksConcepts.BadPractice3();
               var result = task.Result;
            }
            catch (AggregateException ae)
            {
                Console.WriteLine($"We got Aggregate Exception so we need to unwrap the exception with message {ae.GetBaseException().Message}");
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Exception is of type: {ex.GetType()}");
            }

            Console.WriteLine("Done");
        }

        [TestMethod]
        public async Task FireAndForget()
        {
            TasksConcepts tasksConcepts = new TasksConcepts();

            tasksConcepts.FireAndForget();

            Console.WriteLine("Done"); 
        }

        [TestMethod]
        public async Task FireAndForgetBad()
        {
            TasksConcepts tasksConcepts = new TasksConcepts();

            try
            {
                tasksConcepts.FireAndForgetBad();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught Exception");
                Assert.AreSame(ex.Message, "Boom got an exception");
            }

            Console.WriteLine("Done");
        }

        [TestMethod]
        public async Task NiceAsyncMethod()
        {
            TasksConcepts tasksConcepts = new TasksConcepts();

            try
            {
                await tasksConcepts.NiceAsyncMethod();
            } catch (Exception ex)
            {
                Console.WriteLine("Caught Exception");
                Assert.AreSame(ex.Message, "Boom got an exception");
            }

            Console.WriteLine("Done");
        }

        [TestMethod]
        public async Task AsyncWork()
        {
            TasksConcepts tasksConcepts = new TasksConcepts();

            var message = await tasksConcepts.DoSomeAsyncWorkAsync();

            Assert.AreEqual(message, "good work");
        }

        [TestMethod]
        public async Task CancellationTest()
        {
            TasksConcepts tasksConcepts = new TasksConcepts();
            CancellationTokenSource cts = new CancellationTokenSource();

            try
            {
                var task = tasksConcepts.DoWorkAsync(cts.Token);
                cts.Cancel();

                await task;
            } catch (TaskCanceledException tce)
            {
                Console.WriteLine("Operation Cancelled - Bailed out");
            }
        }
    }
}

