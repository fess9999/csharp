using System;
using System.Threading;
using System.Threading.Tasks;

namespace Callbacks
{
    public class AnotherComplexReport
    {
        public Action<string> ReportBuilt { get; set; }

        //проблему инкапсуляции помогают отчасти решить методы регистрации колбэка
        //public void RegisterOnReportBuiltCallback(Action<string> callback)
        //{
        //    ReportBuilt += callback;
        //}

        //public void UnregisterOnReportBuiltCallback(Action<string> callback)
        //{
        //    ReportBuilt -= callback;
        //}

        public void StartBuilding()
        {
            Task.Run(() => Thread.Sleep(5000)).ContinueWith(task => ReportBuilt("42"));
        }
    }
}