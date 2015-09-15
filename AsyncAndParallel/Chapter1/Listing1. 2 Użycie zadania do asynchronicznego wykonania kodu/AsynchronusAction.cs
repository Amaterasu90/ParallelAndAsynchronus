using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu
{
    public class AsynchronusAction
    {
        private static readonly String ARGUMENT = "asynchronicznie";
        private readonly AsynchronusActionProvider _provider;
        private Task<long> _task;
        public AsynchronusAction(AsynchronusActionProvider actionProvider)
        {
            _provider = actionProvider;
            _task = new Task<long>(_provider.ActionDelegate,ARGUMENT);
        }

        public Task<long> TaskInstance
        {
            get { return _task; }
        }

        protected void RunOperations()
        {
            StreamPrinter.PrintMessage(this,"Akcja została uruchomiona");
            if (TaskInstance.Status != TaskStatus.Running && TaskInstance.Status != TaskStatus.RanToCompletion)
                StreamPrinter.PrintMessage(this,"Zadanie nie zostało uruchomione");
            else
                StreamPrinter.PrintMessage(this, "Wynik: " + TaskInstance.Result);
            StreamPrinter.PrintMessage(this,"RunOperations: Koniec");
        }

        public void Run()
        {
            RunTask();
            RunOperations();
        }

        private void RunTask()
        {
            TaskInstance.Start();
        }

        public override String ToString()
        {
            return "AsynchronusAction";
        }
    }
}
