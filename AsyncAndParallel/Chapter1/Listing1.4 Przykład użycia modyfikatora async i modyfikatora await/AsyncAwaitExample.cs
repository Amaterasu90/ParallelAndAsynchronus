using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter1.Listing1._4_Przykład_użycia_modyfikatora_async_i_modyfikatora_await
{
    class AsyncAwaitExample
    {
        private Task<long> AsynchronusAct(object argument)
        {
            Func<object, long> akcja =
                (object _argument) =>
                {
                    printMessage("Akcja: Początek, argument: " + _argument.ToString());
                    Thread.Sleep(1000);
                    printMessage("Akcja Koniec");
                    return DateTime.Now.Ticks;
                };

            Task<long> zadanie = new Task<long>(akcja,argument);
            zadanie.Start();
            return zadanie;
        }

        private void printMessage(string messageContent)
        {
            String taskID = Task.CurrentId.HasValue ? Task.CurrentId.ToString() : "UI";
            Console.WriteLine("! " + messageContent + " (" + taskID + ")");
        }

        public async void runAsyncTask()
        {
            printMessage("runAsyncTask AsyncAwait: Początek");
            Task<long> zadanie = AsynchronusAct("zadanie-metoda");
            printMessage("runAsyncTask AsyncAwait: Akcja została uruchomiona");
            long wynik = await zadanie;
            printMessage("runAsyncTask AsyncAwait: Wynik: " + wynik);
            printMessage("runAsyncTask AsyncAwait: Koniec");
        }
    }
}
