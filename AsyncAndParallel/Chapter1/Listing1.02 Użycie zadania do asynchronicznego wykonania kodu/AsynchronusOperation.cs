using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter1.Listing1._2_Użycie_zadania_do_asynchronicznego_wykonania_kodu
{
    public class AsynchronusOperation
    {
        protected static readonly int totalSleepTime = 100;
        protected virtual void threadOperations()
        {
            Thread.Sleep(totalSleepTime);
        }

        Task<long> zadanie;

        public int makeThreadAction()
        {
            Func<object, long> akcja =
                (object argument) =>
                {
                    printMessage("Akcja: Początek, argument: " + argument.ToString());
                    threadOperations();
                    printMessage("Akcja: Koniec");
                    return DateTime.Now.Ticks;
                };


            zadanie = new Task<long>(akcja, "zadanie");
            zadanie.Start();
            printMessage("Start action: Początek");
            if (zadanie.Status != TaskStatus.Running &&
                zadanie.Status != TaskStatus.RanToCompletion)
                printMessage("Zadanie nie zostało uruchomione");
            else
                printMessage("Wynik: " + zadanie.Result);


            printMessage("Start action: Koniec");

            return totalSleepTime;
        }

        public void printResult()
        {
            
        }

        protected bool taskCurrentIdNotNull = Task.CurrentId.HasValue;
        protected string taskCurrentIdToString = Task.CurrentId.ToString();

        protected string getDataPrintMessage()
        {
            return taskCurrentIdNotNull ? taskCurrentIdToString : "UI";
        }

        private void printMessage(String komunikat)
        {
            string taskID = getDataPrintMessage();
            Console.WriteLine("! " + komunikat + " (" + taskID + ")");
        }
    }
}
