using System;

namespace Callbacks
{
    class Program
    {
        static void Main(string[] args)
        {
            var report = new ComplexReport();
            var anotherReport = new AnotherComplexReport();
            var eventBasedReport = new EventBasedReport();

            Console.WriteLine("Let's build a report. Press any key to begin");
            Console.ReadKey();

            SyncReport(report);
            //AsyncReport(report);
            //MulticastReport(report);
            //ActionReport(report);
            //FuncReport(report);
            //AnotherReportProblem(anotherReport);
            //EventReport(eventBasedReport);
            //AnonymousEventReport(eventBasedReport);
            //LambdaEventReport(eventBasedReport);

            while (true)
                Console.WriteLine($"Echo: {Console.ReadLine()}");
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
            Console.WriteLine($"Report result: {reportResult}");
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