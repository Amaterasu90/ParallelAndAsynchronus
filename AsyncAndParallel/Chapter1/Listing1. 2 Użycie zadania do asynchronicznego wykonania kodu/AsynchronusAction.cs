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
        public void Run()
        {
            Func<object, long> action =
                (object argument) =>
                {
                    StreamPrinter.PrintMessage(this,"Akcja: Początek, argument: " + argument.ToString());
                    Thread.Sleep(1000);
                    StreamPrinter.PrintMessage(this,"Akcja: Koniec");
                    return DateTime.Now.Ticks;
                };

            Task<long> task = new Task<long>(action,"zadanie");
            task.Start();
            StreamPrinter.PrintMessage(this,"Akcja została uruchomiona");
            if(task.Status != TaskStatus.Running && task.Status != TaskStatus.RanToCompletion)
                StreamPrinter.PrintMessage(this,"Zadanie nie zostało uruchomione");
            else
                StreamPrinter.PrintMessage(this,"Wynik: " + task.Result);
            StreamPrinter.PrintMessage(this,"Run: Koniec");
        }
    }
}
