using System;
namespace LearningCSharp.AsyncConcepts
{
    public class TasksConcepts
    {
        public async void FireAndForget()
        {
            await Task.Delay(1000);

            Console.WriteLine("Still running...");
        }

        public async void FireAndForgetBad()
        {
            await Task.Delay(1000);

            Console.WriteLine("Still running...");

            throw new Exception("Boom got an exception");
        }

        public async Task NiceAsyncMethod()
        {
            await Task.Delay(1000);

            Console.WriteLine("Still running...");

            throw new Exception("Boom got an exception");
        }

        public async Task BadPractice1()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");

            var delayTask = Task.Delay(1000); // fire of an async opeartion
            delayTask.Wait();

            Console.WriteLine($"Hey Thread {Thread.CurrentThread.ManagedThreadId}, I was waiting for you");
        }

        public async Task<string> BadPractice2()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");

            HttpClient client = new HttpClient();
            var task = client.GetStringAsync("https://google.co.in");

            Console.WriteLine($"Still is on the Thread {Thread.CurrentThread.ManagedThreadId}");

            return task.Result;
        }

        public async Task<string> BadPractice3()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");

            HttpClient client = new HttpClient();
            var task = client.GetStringAsync("https://google.co.in");

            Console.WriteLine($"Still is on the Thread {Thread.CurrentThread.ManagedThreadId}");

            throw new Exception("error");

            return task.Result;
        }

        public async Task ContinuationStyleProgramming()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");

            var contentTask = new HttpClient().GetStringAsync("https://google.co.in");
            contentTask.ContinueWith(t =>
            {
                Console.WriteLine(contentTask.Result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        public async Task<string> DoSomeAsyncWorkAsync()
        {
            await Task.Delay(1000);

            // do some work

            await Task.Delay(10);

            return "good work";
        }

        public async Task<string> DoWorkAsync(CancellationToken ct)
        {
            await Task.Delay(30000, ct);

            return "done";
        }
    }
}

