using System;
using System.Threading;
using System.Threading.Tasks;

namespace Callbacks
{
    public delegate void ReportResultDelegate(string reportResult);

    public class ComplexReport
    {
        public string BuildSynchronously()
        {
            Thread.Sleep(5000);
            return "42";
        }

        public void BuildAsynchronously(ReportResultDelegate callback)
        {
            Task.Run(() => Thread.Sleep(5000)).ContinueWith(task => callback("42"));
        }

        public void BuildWithAction(Action<string> action)
        {
            Task.Run(() => Thread.Sleep(5000)).ContinueWith(task => action("42"));
        }

        public void BuildWithFunc(Func<string, bool> func)
        {
            Task.Run(() => Thread.Sleep(5000)).ContinueWith(task =>
            {
                Console.WriteLine(func("Report has been being built too long. Abort?") ? "Aborted" : "Continued");
            });
        }
    }
}