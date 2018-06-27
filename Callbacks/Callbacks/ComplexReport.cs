using System;
using System.Threading;
using System.Threading.Tasks;

namespace Callbacks
{
    public delegate void ReportResultDelegate(string reportResult);

    public class ComplexReport
    {
        private readonly string result;

        public ComplexReport(string result) => this.result = result;

        public string BuildSynchronously()
        {
            Thread.Sleep(5000);
            return result;
        }

        public async Task<string> BuildReportAsync()
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Preparing to build report...");

            await Task.Delay(2000); //долгая операция, имитирующая обращение к базе данных

            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Done. ");

            return result;
        }

        public void BuildWithCancelation(CancellationToken cancellationToken)
        {
            Task.Run(() =>
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        Console.WriteLine("Composing report....");
                        Thread.Sleep(1000);
                    }
                }, cancellationToken)
                .ContinueWith((task, o) => Console.WriteLine("Report building has been canceled"),
                    TaskContinuationOptions.OnlyOnCanceled);
        }

        public Task BuildAsynchronously(ReportResultDelegate callback) =>
            Task.Run(() => Thread.Sleep(1000)).ContinueWith(task => callback(result));

        public void BuildWithAction(Action<string> action) =>
            Task.Run(() => Thread.Sleep(5000)).ContinueWith(task => action(result));

        public void BuildWithFunc(Func<string, bool> func) => Task.Run(() => Thread.Sleep(5000)).ContinueWith(task =>
            Console.WriteLine(func("Report has been being built too long. Abort?") ? "Aborted" : "Continued"));
    }
}