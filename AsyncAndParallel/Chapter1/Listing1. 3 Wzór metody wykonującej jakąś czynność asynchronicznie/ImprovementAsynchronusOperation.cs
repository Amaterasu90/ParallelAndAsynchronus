using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu;

namespace AsyncAndParallel.Chapter1.Listing1._3_Wzór_metody_wykonującej_jakąś_czynność_asynchronicznie
{
    public class ImprovementAsynchronusOperation
    {
        private WaitingManager _waitingManager;
        protected TimeProvider TimeProvider;
        private static readonly String _argument = "zadanie-metoda";

        public ImprovementAsynchronusOperation(WaitingManager waitingManager)
        {
            _waitingManager = waitingManager;
            TimeProvider = new TimeProvider();
        }
        public Task<long> DoSomethingAsync(object argument)
        {
            Func<object, long> action = (object _argument) =>
            {
                StreamPrinter.PrintMessage(this,"Akcja: Początek, argument: " + _argument.ToString());
                _waitingManager.Sleep();
                StreamPrinter.PrintMessage(this, "Akcja: Koniec");
                return TimeProvider.DateTimeTicks;
            };

            Task<long> task = new Task<long>(action,argument);
            task.Start();
            return task;
        }

        public void Run()
        {
            StreamPrinter.PrintMessage(this, "Run: Początek");
            Task<long> task = DoSomethingAsync(_argument);
            StreamPrinter.PrintMessage(this, "Akcja została uruchomiona");
            if(task.Status != TaskStatus.Running && task.Status != TaskStatus.RanToCompletion)
                StreamPrinter.PrintMessage(this, "Zadanie nie zostało uruchomione");
            else
                StreamPrinter.PrintMessage(this, "Wynik: " + task.Result);
            StreamPrinter.PrintMessage(this, "Run: Koniec");
        }
    }
}
