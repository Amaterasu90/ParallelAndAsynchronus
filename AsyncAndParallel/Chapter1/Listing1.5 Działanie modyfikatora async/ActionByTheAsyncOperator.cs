using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndParallel.Chapter1.Listing1._5_Działanie_modyfikatora_async
{
    public class ActionByTheAsyncOperator
    {
        public async void AsyncOperation()
        {
            printMessage("AsyncOperation: Początek");
            long wynik = await AsyncWork("async/await");
            printMessage("Wynik: " + wynik.ToString());
            printMessage("AsyncOperation: Koniec");
        }

        private Task<long> AsyncWork(object argument)
        {
            Func<object,long> akcja =
                (object _argument) => {
                    printMessage("Akcja: Początek, argument" + _argument.ToString());
                    Thread.Sleep(1000);
                    printMessage("Akcja Koniec");
                    return DateTime.Now.Ticks;
                };
            Task<long> zadanie = new Task<long>(akcja,argument);
            zadanie.Start();
            return zadanie;
        }

        public void ProofOfAsyncWork()
        {
            printMessage("Proof: Początek");
            AsyncOperation();
            printMessage("Proof: Koniec");
        }

        private void printMessage(string komunikat)
        {
            String taskID = Task.CurrentId.HasValue ? Task.CurrentId.ToString() : "UI";
            Console.WriteLine("! " + komunikat + " (" + taskID + ")");
        }
    }
}
