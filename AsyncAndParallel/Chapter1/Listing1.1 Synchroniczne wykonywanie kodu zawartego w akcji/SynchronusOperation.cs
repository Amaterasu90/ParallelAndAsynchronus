using AsyncAndParallel.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter1
{
    public class SynchronusOperation
    {
        protected static readonly int totalSleepTime = 10000;
        protected virtual void threadOperations()
        {
            Thread.Sleep(totalSleepTime);
        }

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

            printMessage("Start action: Początek");
            printMessage("Wynik: " + akcja("synchronicznie"));
            printMessage("Start action: Koniec");

            return totalSleepTime;
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
