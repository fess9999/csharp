using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MoreLinq;

namespace Callbacks
{
    class Program
    {
        private static int a = 5;

        private static readonly Dictionary<int, string> dictionary = new Dictionary<int, string>();

        private static readonly CancellationTokenSource tokenSource = new CancellationTokenSource();

        static void Main(string[] args)
        {
            var report = new ComplexReport("42");
            var anotherReport = new AnotherComplexReport();
            var eventBasedReport = new EventBasedReport();

            //Console.WriteLine("Let's build a report. Press any key to begin");
            //Console.ReadKey();

            //SyncReport(report);
            //AsyncReport(report);
            //MulticastReport(report);
            //ActionReport(report);
            //FuncReport(report);
            //AnotherReportProblem(anotherReport);
            //EventReport(eventBasedReport);
            //AnonymousEventReport(eventBasedReport);
            //LambdaEventReport(eventBasedReport);

            ProcessFun();
            //ThreadsFun();
            //RaceCondition1();
            //RaceCondition2();

            //CancelableReport(report);
            //SeveralReportsSimultaneously();
            //AsyncAwaitReport(report).Wait();

            while (true)
            {
                Console.WriteLine($"Echo: {Console.ReadLine()}");
                tokenSource.Cancel();
            }
        }

        private static async Task AsyncAwaitReport(ComplexReport report)
        {
            PrintReportResult(await report.BuildReportAsync());
        }

        private static void SeveralReportsSimultaneously()
        {
            var stopwatch = Stopwatch.StartNew();
            var tasks = Enumerable.Range(0, 10)
                .Select(i => new ComplexReport(i.ToString()).BuildAsynchronously(PrintReportResult)).ToArray();

            Task.WaitAll(tasks);
            Console.WriteLine($"All reports have been built in {stopwatch.Elapsed}");
        }

        private static void CancelableReport(ComplexReport report) => report.BuildWithCancelation(tokenSource.Token);

        private static void RaceCondition1()
        {
            while (true)
            {
                Console.ReadKey();
                a = 5;
                var thread1 = new Thread(() => a = a + 1);
                var thread2 = new Thread(() => a = a * 2);

                thread1.Start();
                thread2.Start();

                thread1.Join();
                thread2.Join();

                Console.WriteLine(a);
            }
        }

        private static void RaceCondition2()
        {
            var thread1 = new Thread(AddValues);
            var thread2 = new Thread(AddValues);

            thread1.Start();
            thread2.Start();
        }

        private static void AddValues() => Enumerable.Range(0, 10)
            .ForEach(i => AddKeyValue(i, $"value {Thread.CurrentThread.ManagedThreadId}"));

        private static void AddKeyValue(int key, string value)
        {
            lock (dictionary)
            {
                if (!dictionary.ContainsKey(key))
                    dictionary.Add(key, value);
            }
        }

        private static void AddKeyValueSynchronized(int key, string value)
        {
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
        }

        private static void ThreadsFun()
        {
            var currentThread = Thread.CurrentThread;
            Console.WriteLine(currentThread.Name);
            Console.WriteLine(currentThread.ManagedThreadId);
            Console.WriteLine(currentThread.Priority);
            Console.WriteLine(currentThread.CurrentCulture);
        }

        private static void ProcessFun()
        {
            var processes = Process.GetProcesses();
            processes.ForEach(process => Console.WriteLine($"{process.Id} {process.ProcessName}"));
        }

        private static void EventReport(EventBasedReport eventBasedReport)
        {
            eventBasedReport.OnReportBuilt += PrintReportResult;
            eventBasedReport.OnReportBuilt += SendReportResult;
            eventBasedReport.StartBuilding();

            //eventBasedReport.OnReportBuilt -= SendReportResult;
        }

        private static void AnonymousEventReport(EventBasedReport eventBasedReport)
        {
            eventBasedReport.OnReportBuilt += delegate(string result)
            {
                Console.WriteLine($"Anonymous report result: {result}");
            };
            eventBasedReport.OnReportBuilt += PrintReportResult;
            eventBasedReport.OnReportBuilt += SendReportResult;

            eventBasedReport.StartBuilding();
        }

        private static void LambdaEventReport(EventBasedReport eventBasedReport)
        {
            eventBasedReport.OnReportBuilt += result => Console.WriteLine($"Lambda report result: {result}");
            eventBasedReport.OnReportBuilt += PrintReportResult;
            eventBasedReport.OnReportBuilt += SendReportResult;

            eventBasedReport.StartBuilding();
        }

        private static void AnotherReportProblem(AnotherComplexReport report)
        {
            report.ReportBuilt = PrintReportResult;
            report.StartBuilding();

            //можно присвоить совершенного новый объект!!!
            report.ReportBuilt = SendReportResult;
            //или вообще обнулить его!!!
            report.ReportBuilt = null;
            //можно напрямую вызвать делегат!!! все внутренности делегата открыли
            report.ReportBuilt?.Invoke("42432");
        }

        private static void FuncReport(ComplexReport report)
        {
            report.BuildWithFunc(RequestConfirmation);
        }

        private static bool RequestConfirmation(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine().ToLower() == "y";
        }

        private static void ActionReport(ComplexReport report)
        {
            report.BuildWithAction(PrintReportResult);
        }

        private static void MulticastReport(ComplexReport report)
        {
            var myDelegate = new ReportResultDelegate(PrintReportResult);
            myDelegate += SendReportResult;
            //myDelegate.Invoke("none");

            report.BuildAsynchronously(myDelegate);
        }

        private static void PrintReportResult(string reportResult)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Report result: {reportResult}");
        }

        private static void SendReportResult(string reportResult)
        {
            Console.WriteLine("Sending report result by Email");
        }

        private static void SyncReport(ComplexReport report)
        {
            var result = report.BuildSynchronously();
            PrintReportResult(result);
        }

        private static void AsyncReport(ComplexReport report)
        {
            //явное создание экземпляра делегата
            var myDelegate = new ReportResultDelegate(PrintReportResult);
            report.BuildAsynchronously(myDelegate);

            //инлайним создание делегата в параметр метода
            //report.BuildAsynchronously(new ReportResultDelegate(PrintReportResult));

            //неявное создание экземпляра делегата
            //report.BuildAsynchronously(PrintReportResult);
        }
    }
}