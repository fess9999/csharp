using System;
using System.Threading;
using System.Threading.Tasks;

namespace Callbacks
{
    public class EventBasedReport
    {
        private ReportResultDelegate reportBuilt;

        public event ReportResultDelegate OnReportBuilt
        {
            add
            {
                Console.WriteLine($"Hey! I've got a subscriber {value.Method.Name}");
                reportBuilt += value;
            }
            remove
            {
                Console.WriteLine($"Ugrh! I've lost my subscriber {value.Method.Name}");
                reportBuilt -= value;
            }
        }

        //если не нужная особая логика при подписке/отписке код можно сократить до одной строчки
        //public event Action<string> OnReportBuilt;

        public void StartBuilding()
        {
            Task.Run(() => Thread.Sleep(1000)).ContinueWith(task => reportBuilt?.Invoke("42"));
        }
    }
}